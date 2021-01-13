using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CustomSerializationSample
{
    public class ReceiptContext : DbContext
    {
        public DbSet<Receipt> Receipt { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => throw new NotImplementedException();
    }
}
