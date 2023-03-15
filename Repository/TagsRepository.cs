using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository
{        
    public class TagsRepository : BaseRepository<tbl_Tag>
    {
        public TagsRepository(IDbContextFactory<AppDbContext> dbContextFactory) : base(dbContextFactory) { }
    }
}
