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
    public class TechnicalDetailsController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        ITechnicalWorker _repository = new TechnicalWorker();


        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/TechnicalDetails/SaveQuotationDetails")]
        public IActionResult SaveQuotationDetails(QuotationEntity viewModel)
        {
            return Ok(_repository.SaveQuotationDetails(viewModel));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/TechnicalDetails/SaveQuotePreparation")]
        public IActionResult SaveQuotePreparation(QuotationPreparationEntity entity)
        {
            return Ok(_repository.SaveQuotePreparation(entity));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetUserQuoteDetails")]
        public IActionResult GetUserQuoteDetails(string unitNo)
        {
            return Ok(_repository.GetUserQuoteDetails(unitNo));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetVendorQuoteDetails")]
        public IActionResult GetVendorQuoteDetails(string vendorId)
        {
            return Ok(_repository.GetVendorQuoteDetails(vendorId));
        }

        [HttpPost]
        [Route("api/TechnicalDetails/DeleteQuotationDetail")]
        [ResponseType(typeof(string))]
        public IActionResult DeleteQuotationDetail(int[] param)
        {
            return Ok(_repository.DeleteQuotationDetail(param[0]));
        }

        [ResponseType(typeof(int))]
        [Route("api/TechnicalDetails/GetQuoteRegList")]
        public IActionResult GetQuoteRegList(int pageIndex, int pageSize, string SearchQuoteType = null, string SearchQuoteCustomerID = null, string SearchSubject = null, string SearchDeliveryTerms = null)
        {
            return Ok(_repository.GetQuoteRegList(pageIndex, pageSize, SearchQuoteType, SearchQuoteCustomerID, SearchSubject, SearchDeliveryTerms));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetCityName")]
        public IActionResult GetCityName(string VendorName = "")
        {
            return Ok(_repository.GetCityName(VendorName));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetProductLineList")]
        public IActionResult GetProductLineList(string productLine = "")
        {
            return Ok(_repository.GetProductLineList(productLine));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetProductNumber")]
        public IActionResult GetProductNumber(string productNameId = "", int productType = 0)
        {
            return Ok(_repository.GetProductNumber(productNameId, productType));
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
        [Route("api/TechnicalDetails/AddQuotationDetailsPopup")]
        [Route("api/TechnicalDetails/QuotationDetailsPopup")]
        public IActionResult QuotationDetailsPopup(QuotationEntity Model)
        {
            return Ok(_repository.QuotationDetailsPopup(Model));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetEnqNoList")]
        public IActionResult GetEnqNoList(string vendorId = "")
        {
            return Ok(_repository.GetEnqNoList(vendorId));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetQuoteNo")]
        public IActionResult GetQuoteNo(string quotetypeId = null, string finYear = null)
        {
            return Ok(_repository.GetQuoteNo(quotetypeId, finYear));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetQuoteNoList")]
        public IActionResult GetQuoteNoList(string quotetypeId = "", string SoNo = null)
        {
            return Ok(_repository.GetQuoteNoList(quotetypeId, SoNo));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetQuoteItemSlNoList")]
        public IActionResult GetQuoteItemSlNoList(string quotetypeId = "", string SoNo = null)
        {
            return Ok(_repository.GetQuoteItemSlNoList(quotetypeId, SoNo));
        }

        [HttpPost]
        [Route("api/TechnicalDetails/GetQuoteEnqNoList")]
        public IActionResult GetQuoteEnqNoList(QuotationEntity qE)
        {
            return Ok(_repository.GetQuoteEnqNoList(qE));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetPrepProductNames")]
        public IActionResult GetPrepProductNames(string productId, string casingSize, string type = null)
        {
            return Ok(_repository.GetPrepProductNames(productId, casingSize, type));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/TechnicalDetails/SaveOrderDetail")]
        public IActionResult SaveOrderDetail(OrderEntity oEntity)
        {
            return Ok(_repository.SaveOrderDetail(oEntity));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetUserOrderDetails")]
        public IActionResult GetUserOrderDetails(string unitNo)
        {
            return Ok(_repository.GetUserOrderDetails(unitNo));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetVendorOrderDetails")]
        public IActionResult GetVendorOrderDetails(string vendorId)
        {
            return Ok(_repository.GetVendorOrderDetails(vendorId));
        }

        [HttpPost]
        [Route("api/TechnicalDetails/DeleteOrderDetail")]
        [ResponseType(typeof(string))]
        public IActionResult DeleteOrderDetail(int[] param)
        {
            return Ok(_repository.DeleteOrderDetail(param[0]));
        }

        [ResponseType(typeof(int))]
        [Route("api/TechnicalDetails/GetOrderDetails")]
        public IActionResult GetOrderDetails(int pageIndex, int pageSize, string SearchQuoteType = null, string SearchCustomerID = null, string SearchProductGroup = null, string SearchDeliveryTerms = null, string SearchPODeliveryDate = null)
        {
            return Ok(_repository.GetOrderDetails(pageIndex, pageSize, SearchQuoteType, SearchCustomerID, SearchProductGroup, SearchDeliveryTerms, SearchPODeliveryDate));
        }


        [HttpPost]
        [ResponseType(typeof(OrderEntity))]
        [Route("api/TechnicalDetails/AddOrderDetailsPopup")]
        [Route("api/TechnicalDetails/OrderDetailsPopup")]
        public IActionResult OrderDetailsPopup(OrderEntity Model)
        {
            return Ok(_repository.OrderDetailsPopup(Model));
        }


        [HttpGet]
        [Route("api/TechnicalDetails/GetOrderQuoteDetails")]
        public IActionResult GetOrderQuoteDetails(string quoteType, string quoteNoId)
        {
            return Ok(_repository.GetOrderQuoteDetails(quoteType, quoteNoId));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetQuoteOrderDetails")]
        public IActionResult GetQuoteOrderDetails(string quoteType, string quoteNoId)
        {
            return Ok(_repository.GetQuoteOrderDetails(quoteType, quoteNoId));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetOrderDetailsFromSO")]
        public IActionResult GetOrderDetailsFromSO(string SoNoView)
        {
            return Ok(_repository.GetOrderDetailsFromSO(SoNoView));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/TechnicalDetails/SaveItemDetailList")]
        public IActionResult SaveItemDetailList(BulkUploadEntity iEntity)
        {
            return Ok(_repository.SaveItemDetailList(iEntity));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/TechnicalDetails/SaveItemDetail")]
        public IActionResult SaveItemDetail(ItemEntity iEntity)
        {
            return Ok(_repository.SaveItemDetail(iEntity));
        }


        [HttpGet]
        [Route("api/TechnicalDetails/GetDataForDocument")]
        public IActionResult GetDataForDocument(string downloadTypeId, string quoteTypeId, string quoteNumberId)
        {
            return Ok(_repository.GetDataForDocument(downloadTypeId, quoteTypeId, quoteNumberId));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetListForDocument")]
        public IActionResult GetListForDocument(string downloadTypeId, string quoteTypeId, string quoteNumberId)
        {
            return Ok(_repository.GetListForDocument(downloadTypeId, quoteTypeId, quoteNumberId));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/TechnicalDetails/SaveRevisedQuotationDetails")]
        public IActionResult SaveRevisedQuotationDetails(QuotationEntity qEntity)
        {
            return Ok(_repository.SaveRevisedQuotationDetails(qEntity));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetVendorDetails")]
        public IActionResult GetVendorDetails(string quotetypeId)
        {
            return Ok(_repository.GetVendorDetails(quotetypeId));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetQuotePrepDetails")]
        public IActionResult GetQuotePrepDetails(string itemNoId, string quoteType, string quoteNo, string QuotePrepId, string financialYear)
        {
            return Ok(_repository.GetQuotePrepDetails(itemNoId, quoteType, quoteNo, QuotePrepId, financialYear));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/TechnicalDetails/SaveClarificationData")]
        public IActionResult SaveClarificationData(ClarificationEntity cObj)
        {
            return Ok(_repository.SaveClarificationData(cObj));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/TechnicalDetails/SaveOrderClarificationData")]
        public IActionResult SaveOrderClarificationData(ClarificationEntity cEntity)
        {
            return Ok(_repository.SaveOrderClarificationData(cEntity));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/TechnicalDetails/SaveQuoteNotes")]
        public IActionResult SaveQuoteNotes(ClarificationEntity viewModel)
        {
            return Ok(_repository.SaveQuoteNotes(viewModel));
        }

        [HttpPost]
        [Route("api/TechnicalDetails/DeleteClarificationMails")]
        [ResponseType(typeof(string))]
        public IActionResult DeleteClarificationMails(string[] param)
        {
            return Ok(_repository.DeleteClarificationMails(param));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetSoNoDetails")]
        public IActionResult GetSoNoDetails(string soNo)
        {
            return Ok(_repository.GetSoNoDetails(soNo));
        }

        [HttpPost]
        [Route("api/TechnicalDetails/DeleteOrderClarifications")]
        [ResponseType(typeof(string))]
        public IActionResult DeleteOrderClarifications(string[] param)
        {
            return Ok(_repository.DeleteOrderClarifications(param));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/TechnicalDetails/SaveNewDescDetail")]
        public IActionResult SaveNewDescDetail(DescEntity viewModel)
        {
            return Ok(_repository.SaveNewDescDetail(viewModel));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/TechnicalDetails/SaveOrderNote")]
        public IActionResult SaveOrderNote(OrderEntity viewModel)
        {
            return Ok(_repository.SaveOrderNote(viewModel));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/LoadDescDetail")]
        public IActionResult LoadDescDetail(int skip, int pageSize, string sortColumn, string sortColumnDir, string search)
        {
            return Ok(_repository.LoadDescDetail(skip, pageSize, sortColumn, sortColumnDir, search));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/TechnicalDetails/SaveRevisedOrderDetails")]
        public IActionResult SaveRevisedOrderDetails(OrderEntity oEntity)
        {
            return Ok(_repository.SaveRevisedOrderDetails(oEntity));
        }


        [HttpGet]
        [Route("api/TechnicalDetails/GetItemNosForEnqs")]
        public IActionResult GetItemNosForEnqs(string EnqNo)
        {
            return Ok(_repository.GetItemNosForEnqs(EnqNo));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetDataForContractReview")]
        public IActionResult GetDataForContractReview(string EnqNo, string ItemNo, string type)
        {
            return Ok(_repository.GetDataForContractReview(EnqNo, ItemNo, type));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/TechnicalDetails/SaveContractReviewData")]
        public IActionResult SaveContractReviewData(ContractReview viewModel)
        {
            return Ok(_repository.SaveContractReviewData(viewModel));
        }

        [HttpGet]
        public IActionResult GetWorkAuthReport(string SoNo, string FromDate = null, string ToDate = null, string ReportType=null)
        {
            return Ok(_repository.GetWorkAuthReport(SoNo, FromDate, ToDate, ReportType));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/LoadMasterPLlist")]
        public IActionResult LoadMasterPLlist(int skip, int pageSize, string sortColumn, string sortColumnDir, string search)
        {
            return Ok(_repository.LoadMasterPLlist(skip, pageSize, sortColumn, sortColumnDir, search));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/LoadQuotePrepListDetails")]
        public IActionResult LoadQuotePrepListDetails(int skip, int pageSize, string sortColumn, string sortColumnDir, string search, string quoteType = null, string quoteNo = null, string itemNo = null, string financialYear = null)
        {
            return Ok(_repository.LoadQuotePrepListDetails(skip, pageSize, sortColumn, sortColumnDir, search, quoteType, quoteNo, itemNo, financialYear));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/LoadItemWiseOrders")]
        public IActionResult LoadItemWiseOrders(int skip, int pageSize, string sortColumn, string sortColumnDir, string search)
        {
            return Ok(_repository.LoadItemWiseOrders(skip, pageSize, sortColumn, sortColumnDir, search));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetContractReviews")]
        public IActionResult GetContractReviews(string customerId = null)
        {
            return Ok(_repository.GetContractReviews(customerId));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetQuoteItemSlNos")]
        public IActionResult GetQuoteItemSlNos(string quoteType, string quoteNo, string finYear)
        {
            return Ok(_repository.GetQuoteItemSlNos(quoteType, quoteNo, finYear));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetQuoteNoDetailsforRevisedQuote")]
        public IActionResult GetQuoteNoDetailsforRevisedQuote(string quoteNoId, string quotetypeId, string financialYr)
        {
            return Ok(_repository.GetQuoteNoDetailsforRevisedQuote(quoteNoId, quotetypeId, financialYr));
        }

        [HttpGet]
        [Route("api/TechnicalDetails/GetRevAndOriginalQuotes")]
        public IActionResult GetRevAndOriginalQuotes(string quotetypeId, string financialYr, string quoteAddOn = null)
        {
            return Ok(_repository.GetRevAndOriginalQuotes(quotetypeId, financialYr, quoteAddOn));
        }


    }
}
