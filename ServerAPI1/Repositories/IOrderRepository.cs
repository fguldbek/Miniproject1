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
        
        void MarkAsPurchased(int id, int BuyerId);
        void ReserveItem(int id, int buyerId);
        void UndoReservation(int id);

        Order[] GetAll();

        Order[] GetAllByUserId(int buyerId);
        
        // Opdaterer element med Id = item.Id.
        void UpdateItem(Order item);
    }
}