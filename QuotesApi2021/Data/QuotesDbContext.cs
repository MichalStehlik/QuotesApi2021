using Microsoft.EntityFrameworkCore;
using QuotesApi2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApi2021.Data
{
    public class QuotesDbContext : DbContext
    {
        public QuotesDbContext(DbContextOptions<QuotesDbContext> options) : base(options) { }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key#join-entity-type-configuration
            modelBuilder.Entity<Quote>().HasMany(q => q.Tags).WithMany(t => t.Quotes).UsingEntity<QuoteTag>(x => x.HasOne(qt => qt.Tag).WithMany().HasForeignKey(x => x.TagId), x => x.HasOne(qt => qt.Quote).WithMany().HasForeignKey(x => x.QuoteId));
            modelBuilder.Entity<Tag>().HasData(new Tag { Id = 1, Text = "Werich, Jan", Type = TagType.Author });
            modelBuilder.Entity<Tag>().HasData(new Tag { Id = 2, Text = "Hloupost", Type = TagType.Theme });
            modelBuilder.Entity<Tag>().HasData(new Tag { Id = 3, Text = "cs", Type = TagType.Language });
            modelBuilder.Entity<Tag>().HasData(new Tag { Id = 4, Text = "Blbec", Type = TagType.Theme });
            modelBuilder.Entity<Tag>().HasData(new Tag { Id = 5, Text = "Churchill, Winston", Type = TagType.Author });
            modelBuilder.Entity<Tag>().HasData(new Tag { Id = 6, Text = "Peklo", Type = TagType.Theme });
            modelBuilder.Entity<Tag>().HasData(new Tag { Id = 7, Text = "en", Type = TagType.Language });
            modelBuilder.Entity<Tag>().HasData(new Tag { Id = 8, Text = "Těžkosti", Type = TagType.Theme });

            modelBuilder.Entity<Quote>().HasData(new Quote { Id = 1, Text = "<p>Hloupost je největší zlo.</p>" });
            modelBuilder.Entity<Quote>().HasData(new Quote { Id = 2, Text = "<p>Kde blb, tam nebezpečno!</p>" });
            modelBuilder.Entity<Quote>().HasData(new Quote { Id = 3, Text = "<p>Jestliže se člověk hádá s blbcem víc, jak půl minuty, hádají se už dva blbci.</p>" });
            modelBuilder.Entity<Quote>().HasData(new Quote { Id = 4, Text = "<p>Největší životní lekcí je, že i blbci mají někdy pravdu.</p>" });
            modelBuilder.Entity<Quote>().HasData(new Quote { Id = 5, Text = "<p>If you’re going through hell, keep going.</p>" });
            
            modelBuilder.Entity<QuoteTag>().HasData(new QuoteTag { QuoteId = 1, TagId = 1}, new QuoteTag { QuoteId = 1, TagId = 2}, new QuoteTag { QuoteId = 1, TagId = 3});
            modelBuilder.Entity<QuoteTag>().HasData(new QuoteTag { QuoteId = 2, TagId = 1 }, new QuoteTag { QuoteId = 2, TagId = 4 }, new QuoteTag { QuoteId = 2, TagId = 3 });
            modelBuilder.Entity<QuoteTag>().HasData(new QuoteTag { QuoteId = 3, TagId = 1 }, new QuoteTag { QuoteId = 3, TagId = 4 }, new QuoteTag { QuoteId = 3, TagId = 3 });
            modelBuilder.Entity<QuoteTag>().HasData(new QuoteTag { QuoteId = 4, TagId = 5 }, new QuoteTag { QuoteId = 4, TagId = 4 }, new QuoteTag { QuoteId = 4, TagId = 3 });
            modelBuilder.Entity<QuoteTag>().HasData(new QuoteTag { QuoteId = 5, TagId = 5 }, new QuoteTag { QuoteId = 5, TagId = 6 }, new QuoteTag { QuoteId = 5, TagId = 8 }, new QuoteTag { QuoteId = 5, TagId = 7 });
        }
    }
}
