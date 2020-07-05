using D365CustomWorkflow.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace D365CustomWorkflow.Services
{
    public class ExternalServiceVoucher : IExternalServiceVoucher
    {
        IHttpClientApi _httpClientApi;
        public ExternalServiceVoucher(IHttpClientApi httpClientApi)
        {
            _httpClientApi = httpClientApi;
        }
        public async Task<int> GetVoucherDiscount(string voucher)
        {
            int discount = 0;
            HttpResponseMessage response = await _httpClientApi.GetApiResponse($"voucher/voucher/{voucher}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                discount = int.Parse(content);

            }
            return discount;
        }
    }
}
