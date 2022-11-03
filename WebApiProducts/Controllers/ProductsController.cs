using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApiProducts.Data;
using WebApiProducts.Models;

namespace WebApiProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]

        public async Task <IActionResult> Create (ProductEntity  req)

        {
            try
            {
                _context.Add(req);
                await _context.SaveChangesAsync();
                return new OkResult();

            }catch(Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
            
        }

        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            try
            {
                return new OkObjectResult(await _context.Products.ToListAsync());

            }
            catch(Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
      
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(Guid id, ProductRequest req)
        {
            try
            {
                var  product = await _context.Products.FirstOrDefaultAsync(x=> x.Id == id);
                if(product!=null)

                {
                    product.ArticleNummer = req.ArticleNummer;
                    product.Name = req.Name;
                    product.Price = req.Price;
                    product.Description = req.Description;


                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    return new OkResult();

                }
                else
                {
                    return new NotFoundResult();
                }

            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete (Guid id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(x=> x.Id == id);
                if(product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    return new OkResult();
                }
                else
                {
                    return new NotFoundResult();
                }

            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

    }
}
