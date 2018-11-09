using Microsoft.AspNetCore.Mvc;
using Solution.Core.AspNetCore;
using Solution.Model.Models;

namespace Solution.Web.App
{
    [ApiController]
    [RouteController]
    public class ApplicationController : ControllerBase
    {
        [HttpGet]
        public ApplicationModel Get()
        {
            return new ApplicationModel();
        }
    }
}
