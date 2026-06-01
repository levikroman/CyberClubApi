using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CyberClubApi.Controllers;
using CyberClubApi.Data;
using CyberClubApi.Models;
using Xunit;

namespace CyberClubApi.Tests
{
    public class ComputersControllerTests
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public async Task GetComputers_ReturnsAllComputers()
        {
            // 1. Arrange
            var context = GetInMemoryDbContext();

            context.Computers.Add(new Computer { Name = "Test-PC-1", Status = "Free", ZoneId = 1 });
            context.Computers.Add(new Computer { Name = "Test-PC-2", Status = "InGame", ZoneId = 2 });
            await context.SaveChangesAsync();

            var controller = new ComputersController(context);

            // 2. Act 
            var result = await controller.GetComputers();

            // 3. Assert 
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Computer>>>(result);
            var computers = Assert.IsAssignableFrom<IEnumerable<Computer>>(actionResult.Value);

            Assert.Equal(2, computers.Count());
        }
    }
}