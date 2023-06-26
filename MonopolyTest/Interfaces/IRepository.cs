using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyTest.Interfaces
{
    internal interface IRepository<T> where T : class
    {
        // надо оставить только те, что нужны
        /**
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        **/
        void Create(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}
