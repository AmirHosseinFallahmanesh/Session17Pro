using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session17Pro.Infrastruture.Helpers
{
    public class MemoryCache : ICache
    {
        private readonly IMemoryCache memoryCache;

        public MemoryCache(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public T Get<T>(object key)
        {
            return memoryCache.Get<T>(key);
        }

        public void Set<T>(object key, T value)
        {
            memoryCache.Set<T>(key, value);
        }
    }
}
