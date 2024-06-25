using BaseLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Servidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OvertimeTypeController(IGenericRepositoryInterface<OvertimeType> genericRepository)
        : GenericController<OvertimeType>(genericRepository)
    {

    }
}
