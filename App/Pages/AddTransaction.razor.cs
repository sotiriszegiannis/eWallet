using Microsoft.AspNetCore.Components;
using Domain;
using Repository;
using MudBlazor;

namespace eWallet.Pages
{
    public partial class AddTransaction
    {
        [Inject] private TransactionRepository TransactionRepository { get; set; } = default;
        [Inject] ISnackbar Snackbar { get; set; } = default;
        [Inject] DailyTransactionRegisterService DailyTransactionRegister { get; set; } = default;
        public TransactionModel moneyModel { get; set; }=new TransactionModel();
        protected override async Task OnInitializedAsync()
        {           
            await base.OnInitializedAsync();
        }
        private async Task Add()
        {
            var recId=await TransactionRepository.Add(new TransactionDTO()
            {
                Amount = moneyModel.Amount,
                Description = moneyModel.Description,
                TransactionType = moneyModel.TransactionType,
                Tags=moneyModel.Tags
            });

            if (recId > 0)
            {
                Snackbar.Add("Saved!", Severity.Success);
                await DailyTransactionRegister.NewTransaction(moneyModel);
            }
        }
    }
}