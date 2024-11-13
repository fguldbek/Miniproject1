using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Core;
using ServerAPI1.Repositories;

namespace ServerAPI1.Controllers
{
    [ApiController]
    [Route("api/shopping")]
    [EnableCors("AllowSpecificOrigin")]
    public class OrderController : ControllerBase
    {
        private IOrderRepository mRepo;

        public OrderController(IOrderRepository repo){
            mRepo = repo;
        }

        [HttpGet]
        [Route("getall")]
        public IEnumerable<Order> GetAll(){
            return mRepo.GetAll();
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
