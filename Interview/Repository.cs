using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class Repository<T, I> : IRepository<T, I> where T : IStoreable<I>
    {
        public void Delete(I id)
        {
            throw new NotImplementedException();
        }

        public T Get(I id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(T item)
        {
            throw new NotImplementedException();
        }
    }
}
