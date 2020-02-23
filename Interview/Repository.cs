using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class Repository<T, I> : IRepository<T, I> where T : IStoreable<I>
    {
        protected List<T> entities;

        public Repository()
        {

            entities = new List<T>();
        }
        public void Delete(I id)
        {
            var item = Get(id);

            entities.Remove(item);
        }

        public T Get(I id)
        {
            return entities.Find(r => r.Id.Equals(id));
        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public void Save(T item)
        {
            entities.Add(item);
        }
    }
}
