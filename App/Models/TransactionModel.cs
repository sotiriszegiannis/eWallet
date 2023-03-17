using Domain;
using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eWallet
{
    
    public class TransactionModel
    {        
        public int Id { get; set; }     
        public float Amount { get; set; }        
        public string Description { get; set; }        
        public List<string> Tags { get; set; }         
        public TransactionType TransactionType { get; set; }
    }
}