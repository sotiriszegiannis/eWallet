using Domain;
using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eWallet
{
    
    public class MoneyModel
    {        
        public int Id { get; set; }     
        public float Amount { get; set; }        
        public string Description { get; set; }        
        public List<string> Tags { get; set; }         
        public MoneyType MoneyType { get; set; }
    }
}