using jsonParser.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsonParser.Functions
{
    public class restApi
    {
        public String Url = "https://api.epias.com.tr/epias/exchange/transparency";
        public List<clsDagitimModel> getDagitimBolgesi()
        {
            var client = new RestClient(Url);
            var request = new RestRequest("/consumption/distribution", Method.Get);            
            var response = client.Execute(request).Content;
            JObject jobj = JObject.Parse(response);            
            var body = jobj["body"]["distributionList"].ToString();
            var jsonModel = JsonConvert.DeserializeObject<List<clsDagitimModel>>(body);
            return jsonModel;
        }
        public List<clsPiyasaFiyatlariModel> getPtfSmf(DateTime basTar, DateTime bitTar)
        {
            var client = new RestClient(Url);

            var request = new RestRequest("/market/mcp-smp", Method.Get);
            request.AddParameter("startDate", basTar.ToString("yyyy-MM-dd"));
            request.AddParameter("endDate", bitTar.ToString("yyyy-MM-dd"));

            var response = client.Execute(request).Content;
            JObject jobj = JObject.Parse(response);            
            var body = jobj["body"]["mcpSmps"].ToString();
            

            var jsonModel = JsonConvert.DeserializeObject<List<clsPiyasaFiyatlariModel>>(body);
            return jsonModel;
        }
        public List<clsDgpTalimatOzet> dgpTalimatOzet(DateTime basTar, DateTime bitTar)
        {
            var client = new RestClient(Url);

            var request = new RestRequest("/market/bpm-order-summary", Method.Get);
            request.AddParameter("startDate", basTar.ToString("yyyy-MM-dd"));
            request.AddParameter("endDate", bitTar.ToString("yyyy-MM-dd"));

            var response = client.Execute(request).Content;
            JObject jobj = JObject.Parse(response);
            var body = jobj["body"]["bpmOrderSummaryList"].ToString();


            var jsonModel = JsonConvert.DeserializeObject<List<clsDgpTalimatOzet>>(body);
            return jsonModel;

        }
        public List<clsGercekZamanliUretim> gercekZamanliUretim(DateTime basTar, DateTime bitTar)
        {
            var client = new RestClient(Url);

            var request = new RestRequest("/production/real-time-generation", Method.Get);
            request.AddParameter("startDate", basTar.ToString("yyyy-MM-dd"));
            request.AddParameter("endDate", bitTar.ToString("yyyy-MM-dd"));

            var response = client.Execute(request).Content;
            JObject jobj = JObject.Parse(response);
            var body = jobj["body"]["hourlyGenerations"].ToString();
            var jsonModel = JsonConvert.DeserializeObject<List<clsGercekZamanliUretim>>(body);
           return jsonModel;
        }
        public List<clsAuf> getAuf(DateTime basTar, DateTime bitTar)
        {
            var client = new RestClient(Url);

            var request = new RestRequest("/market/auf", Method.Get);
            request.AddParameter("startDate", basTar.ToString("yyyy-MM-dd"));
            request.AddParameter("endDate", bitTar.ToString("yyyy-MM-dd"));

            var response = client.Execute(request).Content;
            JObject jobj = JObject.Parse(response);
            var body = jobj["body"]["aufList"].ToString();
            var jsonModel = JsonConvert.DeserializeObject<List<clsAuf>>(body);
            return jsonModel;
        }
    }
}
