using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OData.Edm;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.OData;

namespace Kutup.WebApi.Controllers
{
    public class ODataOpenApi : Controller
    {
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("ODataOpenApi.json")]
        public IActionResult OpenApi()
        {
            IEdmModel model = Startup.GetEdmModel();
            OpenApiDocument document = model.ConvertToOpenApi();
            var outputJSON = document.SerializeAsJson(OpenApiSpecVersion.OpenApi3_0);
            return Ok(outputJSON);
        }
    }
}
