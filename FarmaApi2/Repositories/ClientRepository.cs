using FarmaApi2.Data.DBContext;
using FarmaApi2.Entity;
using FarmaApi2.Interfaces;

namespace FarmaApi2.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly Context _context;

        public ClientRepository(Context context)
        {
            _context = context;
        }
        public Client CreateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public Client GetClient(Guid id)
        {
            return _context.Clients
                .Select(client => client)
                .Where(client => client.Id.Equals(id))
                .First();
        }

        public List<Client> GetClients()
        {
            return _context.Clients
                .Select(client => client)
                .ToList();
        }
    }
}
