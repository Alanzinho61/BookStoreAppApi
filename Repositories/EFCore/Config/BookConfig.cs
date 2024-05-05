using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{

        public class BookConf : IEntityTypeConfiguration<Book>
        {
            public void Configure(EntityTypeBuilder<Book> builder)
            {
                builder.HasData(
                    new Book { Id = 1, BookName = "Leyla ile Mecnun", Price = 150 },
                    new Book { Id = 2, BookName = "Monte Cristo Kontu", Price = 250 },
                    new Book { Id = 3, BookName = "Dijital Kale", Price = 100 }
                    );
            }
        }
}
