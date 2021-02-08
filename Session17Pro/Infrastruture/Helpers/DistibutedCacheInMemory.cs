using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Session17Pro.Infrastruture.Helpers
{
    public class DistibutedCacheInMemory:ICache
    {
        private readonly IDistributedCache distibutedMemoryCache;

        public DistibutedCacheInMemory(IDistributedCache distibutedMemoryCache)
        {
            this.distibutedMemoryCache = distibutedMemoryCache;
        }

        public T Get<T>(object key)
        {
            var data=distibutedMemoryCache.GetString(key.ToString());
            return JsonConvert.DeserializeObject<T>(data);

        }

        public void Set<T>(object key, T value)
        {
           string data= JsonConvert.SerializeObject(value);
            distibutedMemoryCache.SetString(key.ToString(), data);
        }
    }
}
