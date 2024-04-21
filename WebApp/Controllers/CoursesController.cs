using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.ViewModels;

namespace WebApp.Controllers;
[Authorize]
public class CoursesController(HttpClient httpClient) : Controller
{
    private readonly HttpClient _httpClient = httpClient;

    [Route("/Courses")]
    public async Task<IActionResult> Index()
    {
        var viewmodel = new CourseIndexViewModel();

        var response = await _httpClient.GetAsync("https://localhost:7239/api/courses");
        if (response.IsSuccessStatusCode)
        {
            var courses = JsonConvert.DeserializeObject<IEnumerable<CourseViewModel>>(await response.Content.ReadAsStringAsync());
            if (courses != null && courses.Any())
                viewmodel.Courses = courses;
            
        }

        return View(viewmodel);
        
    }
}
