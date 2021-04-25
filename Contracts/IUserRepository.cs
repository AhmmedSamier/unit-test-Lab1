using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IQueryable<User> FindWithRolesByCondition(Expression<Func<User, bool>> expression);

        bool Login(string email, string password);
    }
}
