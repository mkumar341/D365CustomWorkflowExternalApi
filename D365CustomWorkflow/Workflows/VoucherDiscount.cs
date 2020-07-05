using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D365CustomWorkflow.Services;
using D365CustomWorkflow.Utils;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;

namespace D365CustomWorkflow.Workflows
{
    

    public class VoucherDiscount : CodeActivity
    {
        [RequiredArgument]
        [Input("Voucher")]
        public InArgument<string> Voucher { get; set; }
                
        [Output("Discount")]
        public OutArgument<int> Discount{ get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string voucher = Voucher.Get(context);            

            var voucherDiscount = new ExternalServiceVoucher(new HttpClientApi());
            int discount= voucherDiscount.GetVoucherDiscount(voucher).Result;

            Discount.Set(context, discount);
        }
    }
}
