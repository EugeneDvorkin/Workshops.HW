using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.ApplicationServices;
using System.Web.Http;
using System.Web.Http.Results;
using Rocket.BL.Common.Models.UserRoles;
using Rocket.BL.Common.Services;

using Swashbuckle.Swagger.Annotations;

namespace Rocket.Web.Controllers.UserRole
{
    [RoutePrefix("roles")]
    public class RoleController : ApiController
    {
        private readonly IRoleService _roleManager;

        public RoleController(IRoleService roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        [Route("all")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK)]
        public IHttpActionResult GetAllRoles()
        {
            var result = _roleManager.Get();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.NotFound, "Data is not valid", typeof(string))]
        [SwaggerResponse(HttpStatusCode.OK)]
        public async Task<IHttpActionResult> GetRoleById(string id)
        {
            var model = _roleManager.GetById(id);
            return model == null ? (IHttpActionResult)NotFound() : Ok(model.Name);
        }

        [HttpPost]
        [Route("save")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Data is not valid", typeof(string))]
        [SwaggerResponse(HttpStatusCode.Created, "New Role description", typeof(Role))]
        public async Task<IHttpActionResult> SaveRole(string roleName)
        {
            if (roleName == null)
            {
                return BadRequest("Model cannot be empty");
            }

            var role = new Role { Name = roleName };

            _roleManager.Insert(role);
            return Created($"role/{roleName}", role);
        }

        [HttpPut]
        [Route("update")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.NoContent)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Data is not valid", typeof(string))]
        public async Task<IHttpActionResult> UpdateRole(string roleId, string roleName)
        {
            var model = _roleManager.GetById(roleId);

            if (model == null)
            {
                return new StatusCodeResult(HttpStatusCode.BadRequest, Request);
            }

            var role = new Role { Name = roleName, Id = roleId};

            _roleManager.Update(role);
            return new StatusCodeResult(HttpStatusCode.NoContent, Request);

        }

        [HttpDelete]
        [Route("delete")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.Accepted)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Data is not valid", typeof(string))]
        public async Task<IHttpActionResult> DeleteRoleById(string roleId)
        {
            var model = _roleManager.GetById(roleId);

            if (model == null)
            {
                return new StatusCodeResult(HttpStatusCode.BadRequest, Request);
            }

            _roleManager.Delete(roleId);
            return new StatusCodeResult(HttpStatusCode.Accepted, Request);
        }
    }
}