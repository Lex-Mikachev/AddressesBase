using System.Diagnostics;
using AddressesBase.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AddressesBase.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public string Test()
    {
        return "Test detected...";
    }

    public async Task TestTest(int id = 0)
    {
        Response.ContentType = "text/html;charset=utf-8";
        await Response.WriteAsync($"<h2>Test: Test</h2><p>id = {id}</p>");
    }

    public IActionResult Test2(int id = 0)
    {
        if (id < 0)
        {
            return BadRequest("ERROR: Id is negative!");
        }
        return new HtmlResult($"<h2>Test2: id = {id}</h2>");
    }

    public IActionResult TestFileVirtual()
    {
        // используем VirtaulFileResult - с "виртуальным" адресом, от wwwroot
        string filePath = "Files/test.txt";
        string fileContentType = "text/plain";
        string fileOutputName = "TestFile.txt";
        return PhysicalFile(filePath, fileContentType, fileOutputName);
    }

    public IActionResult TestBinFile(int id = 0)
    {
        // используем PhysicalFileResult - с "физическим" адресом
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/test.txt");
        byte[] fileContent = System.IO.File.ReadAllBytes(filePath); // для отправки массива байт
        //FileStream fileContent = new FileStream(filePath, FileMode.Open);   // для отправки потока FileStreamResult 
        string fileContetntType = "text/plain";
        string fileOutputName = String.Concat("TestBinFile-", id.ToString(), ".txt");
        return File(fileContent, fileContetntType, fileOutputName);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}