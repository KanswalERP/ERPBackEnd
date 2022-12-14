using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NtierMvc.Model.Account;
using NtierMvc.Model;
using NtierMvc.Common;
using NtierMvc.Model.Customer;

namespace NtierMvc.BusinessLogic.Interface
{
    public interface ICustomerWorker
    {
        string SaveCustomerDetails(CustomerEntity entity);
        CustomerEntity GetUserCustDetails(string unitNo);
        string DeleteCustomerDetail(int CustomerId);

        CustomerEntityDetails GetCustomerDetails(int pageIndex, int pageSize, string SearchCountry = null, string SearchCustomerID = null, string SearchCustomerIsActive = null);

        CustomerEntity CustomerDetailsPopup(CustomerEntity Model);
        List<DropDownEntity> GetDdlValueForCustomer(string type, string CountryId, string CustomerId = null);
    }
}
