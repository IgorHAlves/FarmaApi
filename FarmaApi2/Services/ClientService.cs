using FarmaApi2.DTOs;
using FarmaApi2.Entity;
using FarmaApi2.Interfaces;

namespace FarmaApi2.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        public Client GetClient(Guid id)
        {
            try
            {
                Client client = _clientRepository.GetClient(id);

                return client;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao localizar cliente: "+ ex.Message);
            }
        }

        public List<Client> GetClients()
        {
            try
            {
                List<Client> clients = _clientRepository.GetClients();
                return clients;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar cliente: " + ex.Message);
            }
        }

        public Client CreateClient(CreateClientDTO dto)
        {
            try
            {
                Client client = new Client();

                client.Name = dto.Name;
                client.Email = dto.Email;
                client.Password = dto.Password;
                client.Username = dto.Username;

                Client newClient = _clientRepository.CreateClient(client);

                return newClient;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar cliente: "+ ex.Message);

            }
        }
    }
}
