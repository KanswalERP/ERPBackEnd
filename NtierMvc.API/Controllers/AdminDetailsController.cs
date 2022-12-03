using Microsoft.AspNetCore.Mvc;
using NtierMvc.BusinessLogic.Interface;
using NtierMvc.BusinessLogic.Worker;
using NtierMvc.Model.Admin;
using System.Web.Http.Description;

namespace NtierMvc.API.Controllers.Application
{
    public class AdminDetailsController : ControllerBase
    {
        IAdminWorker _repository = new AdminWorker();

        [Route("api/AdminDetails/GetRoleURLDetails")]
        public IActionResult GetRoleURLDetails(string skip = null, string pageSize = null, string sortColumn = null, string sortColumnDir = null, string search = null, string deptName = null, string mainMenu = null, string subMenu = null, string access = null)
        {
            var roleDetails = _repository.GetRoleURLDetails(skip, pageSize, sortColumn, sortColumnDir, search, deptName, mainMenu, subMenu, access);
            return Ok(roleDetails);
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/AdminDetails/SaveRoleAssigns")]
        public IActionResult SaveRoleAssigns(RoleAssignEntity viewModel)
        {
            return Ok(_repository.SaveRoleAssigns(viewModel));
        }

        [Route("api/AdminDetails/GetSubMenus")]
        public IActionResult GetSubMenus(string mainMenu)
        {
            return Ok(_repository.GetSubMenus(mainMenu));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/AdminDetails/SaveAdminAssigns")]
        public IActionResult SaveAdminAssigns(RoleAssignEntity viewModel)
        {
            return Ok(_repository.SaveAdminAssigns(viewModel));
        }

        [Route("api/AdminDetails/GetAdminAssigns")]
        public IActionResult GetAdminAssigns(string skip = null, string pageSize = null, string sortColumn = null, string sortColumnDir = null, string search = null)
        {
            return Ok(_repository.GetAdminAssigns(skip, pageSize, sortColumn, sortColumnDir, search));
        }


    }
}
