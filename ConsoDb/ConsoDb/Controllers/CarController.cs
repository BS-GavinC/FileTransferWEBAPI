using System.Collections;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using ConsoDb_BLL.Interfaces;
using ConsoDb_Domain;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;

namespace ConsoDb.Controllers;

[ApiController]
[Route("[Controller]")]
public class CarController : ControllerBase
{

    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }


    [HttpPost]
    public ActionResult<int> Add(CarCreateDTO carCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(0);
        }

        return Ok(_carService.Add(carCreateDto.ToCar()));
    }

    [HttpGet]
    public async Task<ActionResult<string>> SendPic()
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
        {
            return true;
        };
        

        using (var httpClient = new HttpClient(clientHandler))
        {
            
            var file = System.IO.File.ReadAllBytes(Environment.CurrentDirectory + "/OriginFile/image.jpg");
            
            HttpContent httpContent =
                new StringContent(JsonSerializer.Serialize(new { Name = "MonFichier", Data = file }));
            
            

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            
            
            var result = await httpClient.PostAsync("https://localhost:7225/Car/receive", httpContent);
            
            return Ok(result.Content);
        }

    }
  




    [HttpPost("receive")]
    public async Task<ActionResult> ReceivePic(PicModel pic)
    {
        try
        {
            System.IO.File.WriteAllBytes(Environment.CurrentDirectory + "\\Datas\\img3.jpg", pic.Data);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Problem();
        }
        
        
        


    }
}