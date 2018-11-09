using Solution.Core.Objects;
using Solution.Model.Models;
using System.Collections.Generic;

namespace Solution.Domain.Domains
{
    public interface IUserDomain
    {
        PagedList<UserModel> List(PagedListParameters parameters);

        IEnumerable<UserModel> List();

        UserModel Select(long userId);
    }
}
