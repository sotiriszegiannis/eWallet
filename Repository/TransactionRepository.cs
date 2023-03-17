using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository
{        
    public class TransactionRepository : BaseRepository<tbl_Transaction>
    {
        public TransactionRepository(IDbContextFactory<AppDbContext> dbContextFactory) : base(dbContextFactory){}
        public async Task<int> Add(TransactionDTO transaction)
        {
            List<tbl_Tag> tags = null;
            if (transaction.Tags != null)
            {
                var tagsRepo = new TagsRepository(dbContextFactory);
                tags = await tagsRepo.GetAllWithCriteria(p => transaction.Tags.Any(x => x == p.Name));
                transaction.Tags.Except(tags.Select(p => p.Name)).ToList().ForEach(async p =>
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
            return await Save(new tbl_Transaction()
            {
                Amount = transaction.Amount,
                Description = transaction.Description,
                Type = transaction.TransactionType,
                Tags = tags
            });
        }
        public async Task<TransactionDTO> GetAllForToday()
    }
}
