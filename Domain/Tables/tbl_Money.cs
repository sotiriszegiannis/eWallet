using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Money")]
    public class tbl_Money:ITable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [TableColumnAttr]
        public int Id { get; set; }
        [TableColumnAttr]
        public float Amount { get; set; }
        [TableColumnAttr]
        public string Description { get; set; }
        [TableColumnAttr]
        public List<tbl_Tag> Tags { get; set; }
        [TableColumnAttr]
        public MoneyType MoneyType { get; set; }
        [TableColumnAttr]
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    }
}