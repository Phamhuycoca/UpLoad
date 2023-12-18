using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.IService;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IProductRepository _productRepo;
        public ProductController(IFileService fs, IProductRepository productRepo)
        {
            this._fileService = fs;
            this._productRepo = productRepo;
        }
        [HttpPost]
        public IActionResult Add([FromForm] Product model)
        {
            if (!ModelState.IsValid)
            {
               
                return Ok("ERRROR");
            }
            if (model.ImageFile != null)
            {
                var fileResult = _fileService.SaveImage(model.ImageFile);
                if (fileResult.Item1 == 1)
                {
                    model.ProductImage = "https://localhost:7273/Image/"+fileResult.Item2; // getting name of image
                }
                var productResult = _productRepo.Add(model);
                if (productResult)
                {
                    return Ok(productResult);
                }
                else
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productRepo.GetAll());
        }
    }
}
