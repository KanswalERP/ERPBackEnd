using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http.Description;
using Microsoft.AspNetCore.Mvc;
using NtierMvc.BusinessLogic.Interface;
using NtierMvc.BusinessLogic.Worker;
using NtierMvc.Model;
using NtierMvc.Model.DesignEng;

namespace NtierMvc.API.Controllers.Application
{
    public class DesignDetailsController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        IDesignWorker _repository = new DesignWorker();

        [Route("api/DesignDetails/GetProductRealisationDetails")]
        public IActionResult GetProductRealisationDetails(int pageIndex, int pageSize, string SearchTypeId = null, string SearchQuoteNo = null, string SearchSONo = null, string SearchVendorId = null, string SearchVendorName = null, string SearchProductGroup = null)
        {
            return Ok(_repository.GetProductRealisationDetails(pageIndex, pageSize, SearchTypeId, SearchQuoteNo, SearchSONo, SearchVendorId, SearchVendorName, SearchProductGroup));
        }

        [Route("api/DesignDetails/GetBOMList")]
        public IActionResult GetBOMList(string ProductName = null, string ProductCode = null, string PL = null, string ProductNo = null, string CasingSize = null, string CasingPPF = null, string Grade = null, string OpenHoleSize = null)
        {
            return Ok(_repository.GetBOMList(ProductName, ProductCode, PL, ProductNo, CasingSize, CasingPPF, Grade, OpenHoleSize));
        }

        [HttpPost]
        [ResponseType(typeof(ProductRealisation))]
        [Route("api/DesignDetails/PRPPopup")]
        public IActionResult PRPPopup(ProductRealisation Model)
        {
            return Ok(_repository.PRPPopup(Model));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/DesignDetails/SaveBOMDetails")]
        public IActionResult SaveBOMDetails(BOMEntity viewModel)
        {
            return Ok(_repository.SaveBOMDetails(viewModel));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/DesignDetails/SaveProductRealisationDetails")]
        public IActionResult SaveProductRealisationDetails(ProductRealisation viewModel)
        {
            return Ok(_repository.SaveProductRealisationDetails(viewModel));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/DesignDetails/BillDetailsPopup")]
        public IActionResult BillDetailsPopup(BillMonitoringEntity viewModel)
        {
            return Ok(_repository.BillDetailsPopup(viewModel));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/DesignDetails/SaveBillMonitoringDetails")]
        public IActionResult SaveBillMonitoringDetails(BillMonitoringEntity viewModel)
        {
            return Ok(_repository.SaveBillMonitoringDetails(viewModel));
        }

        [Route("api/DesignDetails/GetPoSLNoDetails")]
        public IActionResult GetPoSLNoDetails(string POSlNo = null)
        {
            return Ok(_repository.GetPoSLNoDetails(POSlNo));
        }

        [HttpGet]
        [ResponseType(typeof(DataTable))]
        [Route("api/DesignDetails/GetDataTablePRPData")]
        public IActionResult GetDataTablePRPData(string ReportType, string DateFrom, string DateTo, string VendorId = null, string SoNo = null)
        {
            return Ok(_repository.GetDataTablePRPData(ReportType, DateFrom, DateTo, VendorId, SoNo));
        }

        [HttpGet]
        [Route("api/DesignDetails/GetVendorIdFromQuoteType")]
        public IActionResult GetVendorIdFromQuoteType(string ReportType=null)
        {
            return Ok(_repository.GetVendorIdFromQuoteType(ReportType=null));
        }

        [HttpGet]
        [Route("api/DesignDetails/GetQuoteOrderDetailsForPRP")]
        public IActionResult GetQuoteOrderDetailsForPRP(string quoteType, string quoteNoId)
        {
            return Ok(_repository.GetQuoteOrderDetailsForPRP(quoteType, quoteNoId));
        }

    }
}
