namespace RedisSample.Models
{
    public interface ICacheManager
    {
        void Set<T>(string key, T model);
        Task<bool> Clear();
        T Get<T>(string key);
    }
}
