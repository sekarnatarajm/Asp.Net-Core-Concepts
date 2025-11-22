using AspNetCoreLearning.Caching.Model;

namespace AspNetCoreLearning.Caching.Service
{
    public interface ICacheService
    {
        bool SetCacheData(string cacheKey, List<Employee> data);
        List<Employee> GetCacheData(string cacheKey);
    }
}
