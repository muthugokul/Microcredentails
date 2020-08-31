using Microcredentials.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Microcredentials.Test
{
    public class MicrocredentialsDbTestBase : IDisposable
    {
        protected readonly MicrocredentialsDbContext dbContext;

        public MicrocredentialsDbTestBase()
        {
            var options = new DbContextOptionsBuilder<MicrocredentialsDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            dbContext = new MicrocredentialsDbContext(options);

            dbContext.Database.EnsureCreated();

            MicrocredentialsDbInitializer.Initialize(dbContext);
        }

        public void Dispose()
        {
            dbContext.Database.EnsureDeleted();

            dbContext.Dispose();
        }
    }
}
