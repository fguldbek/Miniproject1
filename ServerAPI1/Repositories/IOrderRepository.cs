using System;
using Core;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ServerAPI1.Repositories
{
    /*
     * Repræsenterer en samling af ShoppingItems.
     */
    public interface IOrderRepository
    {
        //Tildeler item en unik id og tilføjer den.
        void AddItem(Order item);

        // Fjerner item, hvor item.Id = id. Hvis den ikke
        // findes, sker ingenting
        void DeleteById(int id);

        Order[] GetAll();

        Order[] GetAllByUserId(ObjectId buyerId);
        
        // Opdaterer element med Id = item.Id.
        void UpdateItem(Order item);
    }
}