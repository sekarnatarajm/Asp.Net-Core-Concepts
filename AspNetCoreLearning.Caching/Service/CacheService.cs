using AspNetCoreLearning.Caching.Model;
using Microsoft.Extensions.Caching.Memory;

namespace AspNetCoreLearning.Caching.Service
{
    public class CacheService(IMemoryCache _cache) : ICacheService
    {

        public bool SetCacheData(string cacheKey, List<Employee> data)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(3),
                SlidingExpiration = TimeSpan.FromMinutes(2),
                Size = 1024,
            };
            _cache.Set(cacheKey, data, cacheEntryOptions);
            return true;
        }
        public List<Employee> GetCacheData(string cacheKey)
        {
            _cache.TryGetValue(cacheKey, out List<Employee> employees);
            return employees;
        }
    }
}
