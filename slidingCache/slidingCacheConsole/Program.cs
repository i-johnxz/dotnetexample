using System;
using System.Runtime.Caching;
using System.Threading;

namespace slidingCacheConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var cache = MemoryCache.Default;
            CacheItemPolicy policy = new CacheItemPolicy
            {
                SlidingExpiration = TimeSpan.FromMinutes(1)
            };
            cache.Set(new CacheItem("item", 123), policy);
            var result = cache.Get("item");
            Console.WriteLine($"result1: {result}");

            Thread.Sleep(TimeSpan.FromMinutes(1.2));

            result = cache.Get("item");
            Console.WriteLine($"result2: {result}");
            Console.Read();
        }
    }
}
