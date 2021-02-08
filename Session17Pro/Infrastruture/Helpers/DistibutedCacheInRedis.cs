using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Session17Pro.Infrastruture.Helpers
{
    public class DistibutedCacheInRedis : ICache
    {
        private readonly IDistributedCache distributedCache;

        public DistibutedCacheInRedis(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }
        public T Get<T>(object key)
        {
            var data = distributedCache.GetString(key.ToString());
            return JsonConvert.DeserializeObject<T>(data);
        }

        public void Set<T>(object key, T value)
        {
            string data = JsonConvert.SerializeObject(value);
            distributedCache.SetString(key.ToString(), data);
        }
    }
}
