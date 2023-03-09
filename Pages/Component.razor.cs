using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using eWallet;
using eWallet.Shared;
using Microsoft.EntityFrameworkCore;
using Repository;
using Domain;

namespace eWallet.Pages
{
    public partial class Component
    {
        //[Inject] private MoneyRepository moneyRepository { get; set; } = default;
        [Inject] private Repository.MoneyRepository usersService { get; set; } = default;
        private int currentCount = 0;
        private List<tbl_Money> money = new List<tbl_Money>();
        protected override async Task OnInitializedAsync()
        {           
            await base.OnInitializedAsync();
            await usersService.GetAll();
        }
        private async Task Save()
        {
            //_Money = new testtbl_Money()
            //{
            //    Amount = _Money.Amount,
            //    Description = _Money.Description,
            //    Tags =new List<string>() { "test"}
            //};

            //int id = await MoneyRepository.Save(_Money);
            //if (id > 0)
            //    Moneys.Add(_Money);
        }
    }
}