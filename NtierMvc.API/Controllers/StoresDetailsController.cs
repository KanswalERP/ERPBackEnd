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
using NtierMvc.Model.Stores;
using Microsoft.AspNetCore.Mvc;

namespace NtierMvc.API.Controllers.Application
{
    public class StoresDetailsController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        IStoresWorker _repository = new StoresWorker();

        [HttpGet]
        [Route("api/StoresDetails/FetchGoodsRecieptList")]
        public IActionResult FetchGoodsRecieptList(int pageIndex, int pageSize, string SearchVendorTypeId = null, string SearchSupplierId = null, string SearchRMCategory = null, string SearchDeliveryDateFrom = null, string SearchDeliveryDateTo = null)
        {
            return Ok(_repository.FetchGoodsRecieptList(pageIndex, pageSize, SearchVendorTypeId, SearchSupplierId, SearchRMCategory, SearchDeliveryDateFrom, SearchDeliveryDateTo));
        }

        [HttpGet]
        [Route("api/StoresDetails/GetDetailForGateControlNo")]
        public IActionResult GetDetailForGateControlNo(string GateControlNo, string GRNo = null)
        {
            return Ok(_repository.GetDetailForGateControlNo(GateControlNo, GRNo));
        }

        [HttpGet]
        [Route("api/StoresDetails/GetGRDetailsPopup")]
        public IActionResult GetGRDetailsPopup(string GRno=null)
        {
            return Ok(_repository.GetGRDetailsPopup(GRno));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/StoresDetails/SaveGoodsRecieptEntryDetails")]
        public IActionResult SaveGoodsRecieptEntryDetails(BulkUploadEntity iEntity)
        {
            return Ok(_repository.SaveGoodsRecieptEntryDetails(iEntity));
        }


        [HttpGet]
        [Route("api/StoresDetails/GetGoodsListDataForDocument")]
        public IActionResult GetGoodsListDataForDocument(string GRno)
        {
            return Ok(_repository.GetGoodsListDataForDocument(GRno));
        }

        [HttpGet]
        [Route("api/StoresDetails/GetGoodsDetailForDocument")]
        public IActionResult GetGoodsDetailForDocument(string GRno)
        {
            return Ok(_repository.GetGoodsDetailForDocument(GRno));
        }

    }
}
