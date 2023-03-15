using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository
{        
    public class MoneyRepository : BaseRepository<tbl_Money>
    {
        public MoneyRepository(IDbContextFactory<AppDbContext> dbContextFactory) : base(dbContextFactory){}
        public async Task<int> Add(MoneyDTO money)
        {
            List<tbl_Tag> tags = null;
            if (money.Tags != null)
            {
                var tagsRepo = new TagsRepository(dbContextFactory);
                tags = await tagsRepo.GetAllWithCriteria(p => money.Tags.Any(x => x == p.Name));
                money.Tags.Except(tags.Select(p => p.Name)).ToList().ForEach(async p =>
                {
                    var id = await tagsRepo.Save(new tbl_Tag()
                    {
                        Name = p
                    });
                    tags.Add(new tbl_Tag()
                    {
                        Id = id,
                        Name = p
                    });
                });
            }
            return await Save(new tbl_Money()
            {
                Amount = money.Amount,
                Description = money.Description,
                MoneyType = money.MoneyType,
                Tags = tags
            });
        }
    }
}
