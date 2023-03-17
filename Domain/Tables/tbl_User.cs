using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Users")]
    public class tbl_User : ITable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [TableColumnAttr]
        public int Id { get; set; }
        [TableColumnAttr]
        public string Name { get; set; }
        [TableColumnAttr]
        public string Username { get; set; }
        [TableColumnAttr]
        public string TimeZone { get; set; }
    }
}