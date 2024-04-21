using Infrastructure.WebApp.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.Entities;
using Shared.Models;
using System.Text;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class DefaultController(ApplicationContext context, HttpClient http) : Controller
{
    private readonly ApplicationContext _context = context;
    private readonly HttpClient _http = http;
    private string SubscribeApiUrl = "https://localhost:7239/api/Subscribe";

    public IActionResult Home()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscribeViewModel model)
    {

        if (ModelState.IsValid)
        {

            var subscriberEntity = new SubscribersEntity
            {
                Email = model.Email,
                DailyNewsletter = model.DailyNewsletter,
                AdvertisingUpdates = model.AdvertisingUpdates,
                WeekinReview = model.WeekinReview,
                EventUpdates = model.EventUpdates,
                StartupsWeekly = model.StartupsWeekly,
                Podcasts = model.Podcasts
            };

            var content = new StringContent(JsonConvert.SerializeObject(subscriberEntity), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync(SubscribeApiUrl, content);



        }
        return RedirectToAction("Home", "Default", "subscribe");
    }
}
