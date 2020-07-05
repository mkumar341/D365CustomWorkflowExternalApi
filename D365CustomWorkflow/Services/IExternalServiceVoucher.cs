using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365CustomWorkflow.Services
{
    public interface IExternalServiceVoucher
    {
        Task<int> GetVoucherDiscount(string voucher);

    }
}
