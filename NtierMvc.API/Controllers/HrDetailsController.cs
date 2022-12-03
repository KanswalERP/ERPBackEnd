using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Description;
using Microsoft.AspNetCore.Mvc;
using NtierMvc.BusinessLogic.Interface;
using NtierMvc.BusinessLogic.Worker;
using NtierMvc.Model;
using NtierMvc.Model.HR;

namespace NtierMvc.API.Controllers.Application
{
    public class HrDetailsController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        IHrWorker _repository = new HrWorker();


        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/HrDetails/SaveEmployeeDetails")]
        public IActionResult SaveEmployeeDetails(EmployeeEntity viewModel)
        {
            return Ok(_repository.SaveEmployeeDetails(viewModel));
        }


        [HttpGet]
        [Route("api/HrDetails/GetUserDetails")]
        public IActionResult GetUserDetails(string unitNo)
        {
            return Ok(_repository.GetUserEmployeeDetails(unitNo));
        }

        [HttpPost]
        [ResponseType(typeof(EmployeeEntity))]
        [Route("api/HrDetails/EmployeeDetailsPopup")]
        public IActionResult EmployeeDetailsPopup(EmployeeEntity Model)
        {
            return Ok(_repository.EmployeeDetailsPopup(Model));
        }

        [Route("api/HrDetails/GetEmployeeDetails")]
        public IActionResult GetEmployeeDetails(int pageIndex, int pageSize, string SearchEmployeeNameId = null, string SearchDesignation = null, string SearchDepartment = null, string SearchEmpStatus = null)
        {
            return Ok(_repository.GetEmployeeDetails(pageIndex, pageSize, SearchEmployeeNameId, SearchDesignation, SearchDepartment, SearchEmpStatus));
        }

        [HttpPost]
        [Route("api/HrDetails/DeleteEmpDetail")]
        [ResponseType(typeof(string))]
        public IActionResult DeleteEmpDetail(int[] param)
        {
            return Ok(_repository.DeleteEmployeeDetail(param[0]));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/HrDetails/SavePayrollDetails")]
        public IActionResult SavePayrollDetails(PayrollEntity payModel)
        {
            return Ok(_repository.SavePayrollDetails(payModel));
        }

        [HttpPost]
        [ResponseType(typeof(PayrollEntity))]
        [Route("api/HrDetails/GetEmpPayrollData")]
        public IActionResult GetEmpPayrollData(int[] param)
        {
            return Ok(_repository.GetEmpPayrollData(param[0],param[1],param[2]));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/HrDetails/SaveEmpLeaveDetails")]
        public IActionResult SaveEmpLeaveDetails(LeaveManagement lvModel)
        {
            return Ok(_repository.SaveEmpLeaveDetails(lvModel));
        }


        [Route("api/HrDetails/GetEmpLeaveList")]
        public IActionResult GetEmpLeaveList(int EmpId)
        {
            return Ok(_repository.GetEmpLeaveList(EmpId));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/HrDetails/SaveExperienceDetailsList")]
        public IActionResult SaveExperienceDetailsList(BulkUploadEntity iEntity)
        {
            return Ok(_repository.SaveExperienceDetailsList(iEntity));
        }

        [HttpGet]
        [Route("api/HrDetails/HRCertificates")]
        public IActionResult HRCertificates(int EmpId)
        {
            return Ok(_repository.HRCertificates(EmpId));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/HrDetails/SaveEmpCertificates")]
        public IActionResult SaveEmpCertificates(HRCertificatesEntity viewModel)
        {
            return Ok(_repository.SaveEmpCertificates(viewModel));
        }

    }
}
