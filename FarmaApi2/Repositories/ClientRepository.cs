using FarmaApi2.DBContext;
using FarmaApi2.Entity;
using FarmaApi2.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public Client GetClient(int id)
        {
            throw new NotImplementedException();
        }

        public async List<Client> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }
    }
}
