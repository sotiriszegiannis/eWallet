using Microsoft.AspNetCore.Components;
using Domain;
using Repository;
using MudBlazor;

namespace eWallet.Pages
{
    public partial class AddMoney
    {
        [Inject] private MoneyRepository moneyRepository { get; set; } = default;
        [Inject] ISnackbar Snackbar { get; set; } = default;
        public MoneyModel moneyModel { get; set; }=new MoneyModel();
        protected override async Task OnInitializedAsync()
        {           
            await base.OnInitializedAsync();
        }
        private async Task Add()
        {
            var recId=await moneyRepository.Add(new MoneyDTO()
            {
                Amount = moneyModel.Amount,
                Description = moneyModel.Description,
                MoneyType = moneyModel.MoneyType,
                Tags=moneyModel.Tags
            });
            if (recId > 0)
                Snackbar.Add("Saved!", Severity.Success);
        }
    }
}