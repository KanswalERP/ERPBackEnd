using Microsoft.AspNetCore.Mvc;
using NtierMvc.BusinessLogic.Interface;
using NtierMvc.BusinessLogic.Worker;
using NtierMvc.Model;
using System.Web.Http.Description;

namespace NtierMvc.API.Controllers.Application
{
    public class QuotationDetailsController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        IQuotationWorker _repository = new QuotationWorker();


        //[HttpPost]
        //[ResponseType(typeof(string))]
        //[Route("api/QuotationDetails/SaveQuotationDetails")]
        //public IActionResult SaveQuotationDetails(QuotationEntity viewModel)
        //{
        //    return Ok(_repository.SaveQuotationDetails(viewModel));
        //}

        [HttpGet]
        [Route("api/QuotationDetails/GetUserQuoteDetails")]
        public IActionResult GetUserQuoteDetails(string unitNo)
        {
            return Ok(_repository.GetUserQuoteDetails(unitNo));
        }

        [HttpGet]
        [Route("api/QuotationDetails/GetVendorQuoteDetails")]
        public IActionResult GetVendorQuoteDetails(string vendorId)
        {
            return Ok(_repository.GetVendorQuoteDetails(vendorId));
        }

        [HttpPost]
        [Route("api/QuotationDetails/DeleteQuotationDetail")]
        [ResponseType(typeof(string))]
        public IActionResult DeleteQuotationDetail(int[] param)
        {
            return Ok(_repository.DeleteQuotationDetail(param[0]));
        }

        //[ResponseType(typeof(int))]
        //[Route("api/QuotationDetails/GetQuotationDetails")]
        //public IActionResult GetQuotationDetails(int pageIndex, int pageSize, string SearchQuoteType = null, string SearchQuoteVendorID = null, string SearchQuoteProductGroup = null, string SearchDeliveryTerms = null)
        //{
        //    return Ok(_repository.GetQuotationDetails(pageIndex, pageSize, SearchQuoteType, SearchQuoteVendorID, SearchQuoteProductGroup, SearchDeliveryTerms));
        //}

        [HttpGet]
        [Route("api/QuotationDetails/GetCityName")]
        public IActionResult GetCityName(string VendorName = "")
        {
            return Ok(_repository.GetCityName(VendorName));
        }
        

        //[HttpPost]
        //[ResponseType(typeof(QuotationEntity))]
        //[Route("api/QuotationDetails/AddQuotationDetailsPopup")]
        //public IActionResult AddQuotationDetailsPopup(QuotationEntity Model)
        //{
        //    return Ok(_repository.QuotationDetailsPopup(Model));
        //}

        [HttpPost]
        [ResponseType(typeof(QuotationEntity))]
        [Route("api/QuotationDetails/AddQuotationDetailsPopup")]
        [Route("api/QuotationDetails/QuotationDetailsPopup")]
        public IActionResult QuotationDetailsPopup(QuotationEntity Model)
        {
            return Ok(_repository.QuotationDetailsPopup(Model));
        }

        [HttpGet]
        [Route("api/QuotationDetails/GetDdlValueForQuote")]
        public IActionResult GetDdlValueForQuote(string type, string VendorId = null, string QuoteType = null, string SubjectId = null)
        {
            return Ok(_repository.GetDdlValueForQuote(type, VendorId, QuoteType, SubjectId));
        }

    }
}
