using Repository;

namespace eWallet
{
    public class DailyTransactionRegisterService
    {
        private float IncomeTotal,ExpenseTotal;
        private TransactionRepository MoneyRepository { get; set; } = default;
        public Action<Total> OnNewTransaction { get; set; } = default;
        public DailyTransactionRegisterService(TransactionRepository moneyRepository)
        {
            this.MoneyRepository = moneyRepository;            
            IncomeTotal = 0;
            ExpenseTotal = 0;
        }
        public async Task<Total> Get()
        {
            return new Total(IncomeTotal, ExpenseTotal);
        }
        public async Task NewTransaction(TransactionModel transactionModel)
        {
            try
            {
                if (transactionModel != null)
                {
                    switch (transactionModel.TransactionType)
                    {
                        case Domain.TransactionType.Income:
                            IncomeTotal+=transactionModel.Amount;
                            break;
                        case Domain.TransactionType.Expense:
                            ExpenseTotal+=transactionModel.Amount;
                            break;
                    }
                }
                OnNewTransaction?.Invoke(new Total(this.IncomeTotal, this.ExpenseTotal));
            }
            catch(Exception ex)
            {

            }            
        }
        public class Total
        {
            public Total() { }
            public Total(float income, float expenses)
            {
                Income = income;
                Expenses = expenses;
            }

            public float Income { get; set; }
            public float Expenses { get; set; }
        }
    }
}
