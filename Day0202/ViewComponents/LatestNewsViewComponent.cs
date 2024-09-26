using Day0202.Data;
using Day0202.Models;
using Day0202.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day0202.ViewComponents
{
    
    public class LatestNewsViewComponent(NewsService service) : ViewComponent
    {
        //private readonly AppDbContext _context = new();

        //public LatestNewsViewComponent(AppDbContext context)
        //{
        //    _context = context;
        //}
        public IViewComponentResult Invoke(int newsCount, bool showNewsBody)
        {
            var news = service.GetAll().Take(newsCount).ToList();
            var model = new LatestNewsVm(news, showNewsBody);
            return View(model);
        }
    }

    public record LatestNewsVm(List<News> NewsList, bool ShowNewsBody);
}
