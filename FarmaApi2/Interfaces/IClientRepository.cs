using FarmaApi2.DTOs;
using FarmaApi2.Entity;

namespace FarmaApi2.Interfaces
{
    public interface IClientRepository
    {
        public Client GetClient(int id);
        public List<Client> GetClients();
        public Client CreateClient(Client client);
    }
}
