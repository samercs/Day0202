using Day0202.Data;
using Day0202.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Day0202.Services;

public class NewsService(AppDbContext context, IMemoryCache memoryCache)
{
    public List<News> GetAll()
    {
        if (memoryCache.TryGetValue("news", out List<News> newsList))
        {
            return newsList;
        }

        var news = context.News.ToList();
        var cachOption = new MemoryCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30),
            SlidingExpiration = TimeSpan.FromSeconds(10)
        };
        memoryCache.Set("news", news, cachOption);
        return news;
    }
}