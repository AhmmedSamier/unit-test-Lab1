using System;
using System.Linq;
using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Repository.Test
{
    public class UnitTest1
    {
        // new comment
        // new comment 2
        private IRepositoryWrapper _repositoryWrapper;

        private DbContextOptions<RepositoryContext> DbContextOptions { get; }
        private string ConnectionString = "server=.;database=unit_test; trusted_connection = true;";

        public UnitTest1()
        {
            DbContextOptions = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(ConnectionString)
                .Options;

            _repositoryWrapper = new RepositoryWrapper(new RepositoryContext(DbContextOptions));
        }

        [Fact]
        public void TestHasUsers()
        {
            var users = _repositoryWrapper.User.FindAll();

            Assert.True(users.Any());
        }

        [Fact]
        public void TestHasAdminUser()
        {
            var users = _repositoryWrapper.User.FindWithRolesByCondition(u => u.Roles.Any(r => r.Name == "Admin"));

            Assert.True(users.Any());
        }

        [Fact]
        public void TestUserCanLogin()
        {
            var loggedIn = _repositoryWrapper.User.Login("admin@admin.com", "abcd");

            Assert.True(loggedIn);
        }
    }
}
