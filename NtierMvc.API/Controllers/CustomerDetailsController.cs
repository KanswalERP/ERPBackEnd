using Microsoft.AspNetCore.Mvc;
using NtierMvc.BusinessLogic.Interface;
using NtierMvc.BusinessLogic.Worker;
using NtierMvc.Model.Customer;
using System.Web.Http.Description;

namespace NtierMvc.API.Controllers.Application
{
    public class CustomerDetailsController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        ICustomerWorker _repository = new CustomerWorker();


        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/CustomerDetails/SaveCustomerDetails")]
        public IActionResult SaveCustomerDetails(CustomerEntity viewModel)
        {
            return Ok(_repository.SaveCustomerDetails(viewModel));
        }

        [HttpGet]
        [Route("api/CustomerDetails/GetUserDetails")]
        public IActionResult GetUserDetails(string unitNo)
        {
            return Ok(_repository.GetUserCustDetails(unitNo));
        }

        [HttpPost]
        [ResponseType(typeof(CustomerEntity))]
        [Route("api/CustomerDetails/CustomerDetailsPopup")]
        public IActionResult CustomerDetailsPopup(CustomerEntity Model)
        {
            return Ok(_repository.CustomerDetailsPopup(Model));
        }

        [Route("api/CustomerDetails/GetCustomerDetails")]
        public IActionResult GetCustomerDetails(int pageIndex, int pageSize, string SearchCountry = null, string SearchCustomerID = null, string SearchCustomerIsActive = null)
        {
            return Ok(_repository.GetCustomerDetails(pageIndex, pageSize, SearchCountry, SearchCustomerID, SearchCustomerIsActive));
        }

        [HttpPost]
        [Route("api/CustomerDetails/DeleteCustomerDetail")]
        [ResponseType(typeof(string))]
        public IActionResult DeleteCustomerDetail(int[] param)
        {
            return Ok(_repository.DeleteCustomerDetail(param[0]));
        }

        [HttpGet]
        [Route("api/CustomerDetails/GetDdlValueForCustomer")]
        public IActionResult GetDdlValueForCustomer(string type, string CountryId, string CustomerId = null)
        {
            return Ok(_repository.GetDdlValueForCustomer(type, CountryId, CustomerId));
        }





    }
}
