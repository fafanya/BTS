using System.Collections.Generic;

namespace Kernel.Service
{
    public abstract class TServiceDB
    {
        public string ConnectionString { get; set; }

        public abstract int Insert(TStorage obj);

        public abstract void Update(TStorage obj);

        public abstract void Delete(TStorage obj);

        public abstract TStorage LoadDetails(TStorage query);

        public abstract IEnumerable<TStorage> LoadList(TStorage query);
    }
}