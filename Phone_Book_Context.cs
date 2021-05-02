using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataBase_PhoneBook
{
    class Phone_Book_Context : DbContext
    {
        public Phone_Book_Context() : base("Phone_Book")
        {
            
        }

        public DbSet<Phone_Book> Abonents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<Phone_Book_Context>(null);
            base.OnModelCreating(modelBuilder);
        }

        
    }
}