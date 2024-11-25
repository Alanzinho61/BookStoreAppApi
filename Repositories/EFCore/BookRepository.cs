﻿using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Repositories.EFCore
{
    public sealed class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneBook(Book book) => Create(book);
        

        public void DeleteOneBook(Book book) => Delete(book);
        

        public async Task<PagedList<Book>> GetAllBooksAsync(BookParameters bookParameters, bool trackChanges)
        {
            var books= await FindAll(trackChanges).FilterBooks(bookParameters.MinPrice,bookParameters.MaxPrice)
            .OrderBy(b=>b.Id)
            .ToListAsync();
            return PagedList<Book>.ToPagedList(books, bookParameters.PageNumber, bookParameters.PageSize);
        }

        public async Task<Book> GetOneBookAsync(int id, bool trackChanges)
        {
            return await FindByConditions(b => b.Id == id, trackChanges).SingleOrDefaultAsync();

        }

        public void UpdateOneBook(Book book) =>Update(book);
        
    }
}
