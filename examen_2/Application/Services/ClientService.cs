using examen_2.Application.DTOs.Response;
using examen_2.Application.Interfaces;
using examen_2.Domain.Interfaces;

namespace examen_2.Application.Services;

public class ClientService: IClientService
{
        private readonly IUnitOfWork _unitOfWork;
        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ClientDto>> GetClientsByContent(string name)
        {
            var clients = await _unitOfWork.Clients.GetAllClientsByContent(name);
            Console.WriteLine(clients.ToString());
            return clients.Select(c => new ClientDto
            {
                Id = c.Clientid,
                Email = c.Email,
                Name = c.Name
            });
            
        }
}