using Core;

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

        
        // Opdaterer element med Id = item.Id.
        void UpdateItem(Order item);
    }
}