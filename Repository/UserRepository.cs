using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IQueryable<User> FindWithRolesByCondition(Expression<Func<User, bool>> expression)
        {
            return this.RepositoryContext.Set<User>().Include(u => u.Roles).Where(expression).AsNoTracking();
        }

        public bool Login(string email, string password)
        {
            return this.RepositoryContext.Set<User>().Any(u=> u.Email == email && u.Password == password);
        }

    }
}
