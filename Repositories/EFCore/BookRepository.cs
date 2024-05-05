﻿using Entities.Models;
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
        

        public IQueryable<Book> GetAllBooks(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(b=>b.Id);
        }

        public Book GetOneBook(int id, bool trackChanges)
        {
            return FindByConditions(b => b.Id == id, trackChanges).SingleOrDefault();

        }

        public void UpdateOneBook(Book book) =>Update(book);
        
    }
}