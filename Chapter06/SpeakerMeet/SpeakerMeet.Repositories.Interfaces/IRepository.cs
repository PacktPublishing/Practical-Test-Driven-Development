using System;
using System.Linq;
using System.Linq.Expressions;

namespace SpeakerMeet.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        T Get(Func<T, bool> predicate);
        IQueryable<T> GetAll();
        T Save(T item);
        IRepository<T> Include(Expression<Func<T, object>> path);
    }
}
