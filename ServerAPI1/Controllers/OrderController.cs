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
        
        [HttpPut("markaspurchased/{id}")]
        public IActionResult MarkAsPurchased(int id, [FromQuery] int buyerId)
        {
            try
            {
                // Call the repository method
                mRepo.MarkAsPurchased(id, buyerId);

                // You can add an additional check for the case when the order was not found
                // if the repository method doesn't return anything to indicate failure.

                return Ok(); // Successfully marked as purchased
            }
            catch (Exception ex)
            {
                // Handle the exception and return an error response
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }




        [HttpPut("reserve/{id}")]
        public IActionResult Reserve(int id, [FromQuery] int buyerId)
        {
            try
            {
                mRepo.ReserveItem(id, buyerId);  // Pass the buyerId along with id when reserving
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }




        [HttpPut("undoreserve/{id}")]
        public IActionResult UndoReserve(int id)
        {
            try
            {
                mRepo.UndoReservation(id);  // This will reset the BuyerId to 0
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
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
