using System;
using System.Linq;
using Contracts;
using Xunit;

namespace Repository.Test
{
    public class UnitTest1
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UnitTest1(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [Fact]
        public void HasUser()
        {
            var Users = _repositoryWrapper.User.FindAll();

            Assert.False(Users.Count() == 0);
        }
    }
}
