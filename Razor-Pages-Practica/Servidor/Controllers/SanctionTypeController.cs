using BaseLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Servidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanctionTypeController(IGenericRepositoryInterface<SactionType> genericRepository)
        : GenericController<SactionType>(genericRepository)
    {

    }
}
