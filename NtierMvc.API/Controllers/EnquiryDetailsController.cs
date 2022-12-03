using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Description;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using System.Collections;
using NtierMvc.BusinessLogic.Interface;
using NtierMvc.Model.Account;
using NtierMvc.BusinessLogic.Worker;
using NtierMvc.Model;
using Microsoft.AspNetCore.Mvc;

namespace NtierMvc.API.Controllers.Application
{
    public class EnquiryDetailsController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        IEnquiryWorker _repository = new EnquiryWorker();


        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/EnquiryDetails/SaveEnquiryDetails")]
        public IActionResult SaveEnquiryDetails(EnquiryEntity viewModel)
        {
            return Ok(_repository.SaveEnquiryDetails(viewModel));
        }

        [HttpGet]
        [Route("api/EnquiryDetails/GetUserDetails")]
        public IActionResult GetUserDetails(string unitNo)
        {
            return Ok(_repository.GetUserCustDetails(unitNo));
        }

        [HttpPost]
        [Route("api/EnquiryDetails/DeleteEnquiryDetail")]
        [ResponseType(typeof(string))]
        public IActionResult DeleteEnquiryDetail(int[] param)
        {
            return Ok(_repository.DeleteEnquiryDetail(param[0]));
        }

        [ResponseType(typeof(int))]
        [Route("api/EnquiryDetails/GetEnquiryDetails")]
        public IActionResult GetEnquiryDetails(int pageIndex, int pageSize, string SearchEQEnqType, string SearchCustomerName = null, string SearchEnqFor = null, string SearchEQDueDate = null, string SearchEOQ = null)
        {
            return Ok(_repository.GetEnquiryDetails(pageIndex, pageSize, SearchEQEnqType, SearchCustomerName, SearchEnqFor, SearchEQDueDate, SearchEOQ));
        }

        [HttpGet]
        [Route("api/EnquiryDetails/GetCityName")]
        public IActionResult GetCityName(string VendorName = "")
        {
            return Ok(_repository.GetCityName(VendorName));
        }
        

        //[HttpPost]
        //[ResponseType(typeof(EnquiryEntity))]
        //[Route("api/EnquiryDetails/AddEnquiryDetailsPopup")]
        //public IActionResult AddEnquiryDetailsPopup(EnquiryEntity Model)
        //{
        //    return Ok(_repository.EnquiryDetailsPopup(Model));
        //}

        [HttpPost]
        [ResponseType(typeof(EnquiryEntity))]
        [Route("api/EnquiryDetails/AddEnquiryDetailsPopup")]
        [Route("api/EnquiryDetails/EnquiryDetailsPopup")]
        public IActionResult EnquiryDetailsPopup(EnquiryEntity Model)
        {
            return Ok(_repository.EnquiryDetailsPopup(Model));
        }

        [HttpGet]
        [Route("api/EnquiryDetails/GetVendorDetailForEnquiry")]
        public IActionResult GetVendorDetailForEnquiry(string CustomerId)
        {
            return Ok(_repository.GetVendorDetailForEnquiry(CustomerId));
        }

        [HttpGet]
        [Route("api/EnquiryDetails/GetDdlValueForEnquiry")]
        public IActionResult GetDdlValueForEnquiry(string type, string EnqType = null, string CustomerId = null, string EnqFor = null, string DueDate = null)
        {
            return Ok(_repository.GetDdlValueForEnquiry(type, EnqType, CustomerId, EnqFor, DueDate));
        }

    }
}
