using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core;
using ServerAPI1.Repositories;

namespace ServerAPI1.Controllers
{
    [ApiController]
    [Route("api/shopping")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository mRepo;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderRepository repo, ILogger<OrderController> logger){
            _logger = logger;
            mRepo = repo;
        }
 
        [HttpGet]
        [Route("getall/")]
        public IEnumerable<Order> GetAll(){
            try
            {
                return mRepo.GetAll(); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all orders. Exception: {Message}", ex.Message);
                throw;
            }
        }
        
        [HttpGet]
        [Route("GetAllByUserId/{UserId:int}")]
        public IEnumerable<Order> GetAllByUserId(int UserId){
            try
            {
                return mRepo.GetAllByUserId(UserId); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all orders. Exception: {Message}", ex.Message);
                throw;
            }
        }
        

        [HttpPost]
        [Route("add")]
        public void AddItem(Order product){
            mRepo.AddItem(product);  
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public void DeleteItem(int id) {
            mRepo.DeleteById(id);
        }

        [HttpPut]
        [Route("update")]
        public void UpdateItem(Order product){
            mRepo.UpdateItem(product);
        }


    }
}
