using FamilyBudget.DAL.Contexts;
using FamilyBudget.DAL.Contracts;
using FamilyBudget.DAL.Repositories;

namespace FamilyBudget.DAL.Infrastructure
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private FamilyBudgetContext _context;
        private readonly object _lockObject = new object();
        private readonly IDatabaseFactory _databaseFactory;

        private ICashAccountRepository _cashAccountRepository;
        private ICurrencyRepository _currencyRepository;
        private IOutcomeRepository _outcomeRepository;
        private IIncomeRepository _incomeRepository;
        private IIncomeCategoryRepository _incomeCategoryRepository;
        private IOutcomeCategoryRepository _outcomeCategoryRepository;
        private ICashAccountBalanceRepository _cashAccountBalanceRepository;

        public FamilyBudgetContext FamilyBudgetContext
        {
            get { return _context ?? (_context = _databaseFactory.Get()); }
        }

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public ICashAccountRepository CashAccounts
        {
            get
            {
                if (_cashAccountRepository == null)
                {
                    lock (_lockObject)
                    {
                        if (_cashAccountRepository == null)
                        {
                            _cashAccountRepository = new CashAccountRepository(_databaseFactory);
                        }
                    }
                }
                return _cashAccountRepository;
            }
        }

        public ICurrencyRepository Currencies
        {
            get
            {
                if (_currencyRepository == null)
                {
                    lock (_lockObject)
                    {
                        if (_currencyRepository == null)
                        {
                            _currencyRepository = new CurrencyRepository(_databaseFactory);
                        }
                    }
                }
                return _currencyRepository;
            }
        }

        public IOutcomeRepository Outcomes
        {
            get
            {
                if (_outcomeRepository == null)
                {
                    lock (_lockObject)
                    {
                        if (_outcomeRepository == null)
                        {
                            _outcomeRepository = new OutcomeRepository(_databaseFactory);
                        }
                    }
                }
                return _outcomeRepository;
            }
        }

        public IIncomeRepository Incomes
        {
            get
            {
                if (_incomeRepository == null)
                {
                    lock (_lockObject)
                    {
                        if (_incomeRepository == null)
                        {
                            _incomeRepository = new IncomeRepository(_databaseFactory);
                        }
                    }
                }
                return _incomeRepository;
            }
        }

        public IIncomeCategoryRepository IncomeCategories
        {
            get
            {
                if (_incomeCategoryRepository == null)
                {
                    lock (_lockObject)
                    {
                        if (_incomeCategoryRepository == null)
                        {
                            _incomeCategoryRepository = new IncomeCategoryRepository(_databaseFactory);
                        }
                    }
                }
                return _incomeCategoryRepository;
            }
        }

        public IOutcomeCategoryRepository OutcomeCategories
        {
            get
            {
                if (_outcomeCategoryRepository == null)
                {
                    lock (_lockObject)
                    {
                        if (_outcomeCategoryRepository == null)
                        {
                            _outcomeCategoryRepository = new OutcomeCategoryRepository(_databaseFactory);
                        }
                    }
                }
                return _outcomeCategoryRepository;
            }
        }

        public ICashAccountBalanceRepository CashAccountBalances
        {
            get
            {
                if (_cashAccountBalanceRepository == null)
                {
                    lock (_lockObject)
                    {
                        if (_cashAccountBalanceRepository == null)
                        {
                            _cashAccountBalanceRepository = new CashAccountBalanceRepository(_databaseFactory);
                        }
                    }
                }
                return _cashAccountBalanceRepository;
            }
        }

        protected override void DisposeCore()
        {
            lock (_lockObject)
            {
                _cashAccountRepository = null;
                _currencyRepository = null;
                _outcomeRepository = null;
                _incomeRepository = null;
                _incomeCategoryRepository = null;
                _outcomeCategoryRepository = null;
                _cashAccountBalanceRepository = null;
            }
            FamilyBudgetContext.Dispose();
        }

        public void Save()
        {
            FamilyBudgetContext.SaveChanges();
        }
    }
}
