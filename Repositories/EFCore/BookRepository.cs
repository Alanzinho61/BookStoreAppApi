using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneBook(Book book) => Create(book);
        

        public void DeleteOneBook(Book book) => Delete(book);
        

        public async Task<IEnumerable<Book>> GetAllBooksAsync(BookParameters bookParameters, bool trackChanges)
        {
            return  await FindAll(trackChanges)
                .OrderBy(b=>b.Id)
                .Skip((bookParameters.pageNumber-1)*bookParameters.pageSize)
                .ToListAsync();
        }

        public async Task<Book> GetOneBookAsync(int id, bool trackChanges)
        {
            return await FindByConditions(b => b.Id == id, trackChanges).SingleOrDefaultAsync();

        }

        public void UpdateOneBook(Book book) =>Update(book);
        
    }
}
