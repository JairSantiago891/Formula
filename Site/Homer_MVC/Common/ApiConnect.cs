using Newtonsoft.Json;
using Homer_MVC.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using RestSharp;

namespace Homer_MVC.Common
{
    public static class ApiConnect
    {
        public static string  GetB64(byte[] imagen)
        {  
            return Convert.ToBase64String(imagen);
        }
        public static List<JsonRequest> GetPlaza( )
        {
            List<JsonRequest> item = new List<JsonRequest>(); 
            if (ConnectRest("http://webapi-prod-formula.us-east-2.elasticbeanstalk.com/Api/Plaza", ref item))
            {
                return item;
            }
            return null;
        }
        public static JsonRequest GetPlaza(Guid v)
        {
           var item = new JsonRequest(); 
            if (ConnectRest("http://webapi-prod-formula.us-east-2.elasticbeanstalk.com/Api/Plaza"+"/"+ v.ToString (), ref item))
            {
                return item;
            }
            return null;
        }

        public static EncoderIp GetEncoder(Guid v)
        {
            var item = new EncoderIp();
            if (ConnectRest("http://webapi-prod-formula.us-east-2.elasticbeanstalk.com/Api/Encoder" + "/" + v.ToString(), ref item))
            {
                return item;
            }
            return null;
        } 


        public static bool  ConnectRest(string _url, ref List<JsonRequest> response)
        {
            var client = new RestClient(_url);
            var request = new RestRequest("", Method.Get);
            var ret = client.Execute(request);
            var jsonResponse = ret.Content; // raw content as string
            if (
            ret.IsSuccessful)
            {
                response = JsonConvert.DeserializeObject<List<JsonRequest>>(jsonResponse);
            }
            return ret.IsSuccessful;
        }


        public static bool ConnectRest(string _url, ref List<EncoderIp> response)
        {
            var client = new RestClient(_url);
            var request = new RestRequest("", Method.Get);
            var ret = client.Execute(request);
            var jsonResponse = ret.Content; // raw content as string
            if (
            ret.IsSuccessful)
            {
                response = JsonConvert.DeserializeObject<List<EncoderIp>>(jsonResponse);
            }
            return ret.IsSuccessful;
        }

        public static bool ConnectRest(string _url, ref  EncoderIp  response)
        {
            var client = new RestClient(_url);
            var request = new RestRequest("", Method.Get);
            var ret = client.Execute(request);
            var jsonResponse = ret.Content; // raw content as string
            if (
            ret.IsSuccessful)
            {
                response = JsonConvert.DeserializeObject<  EncoderIp >(jsonResponse);
            }
            return ret.IsSuccessful;
        }

        public static bool AddEncoder(string _url, ref JsonRequest response, ref EncoderIp Item)
        {
            var client = new RestClient(_url);
            var request = new RestRequest("", Method.Post);
            Item.EncoderId = Guid.NewGuid ();
            request.AddJsonBody(Newtonsoft.Json.JsonConvert.SerializeObject( Item));
            var ret = client.Execute(request);
            var jsonResponse = ret.Content; // raw content as string
            if (
            ret.IsSuccessful)
            {
                response = JsonConvert.DeserializeObject<JsonRequest>(jsonResponse);
            }
            return ret.IsSuccessful;
        }


        public static bool AddEncoder( EncoderIp Item)
        {
            var response = new JsonRequest();
            AddEncoder("http://webapi-prod-formula.us-east-2.elasticbeanstalk.com/Api/Encoder", ref response, ref Item);
            return true;
        }
        public static bool ConnectRest(string _url, ref JsonRequest response)
        {
            var client = new RestClient(_url);
            var request = new RestRequest("", Method.Get);
            var ret = client.Execute(request);
            var jsonResponse = ret.Content; // raw content as string
            if (
            ret.IsSuccessful)
            {
                response = JsonConvert.DeserializeObject<JsonRequest>(jsonResponse);
            }
            return ret.IsSuccessful;
        }


        public static bool ConnectRest(string _url, PlazaModel v ,  ref  ResponsePlaza response)
        {
            var client = new RestClient(_url);
            var request = new RestRequest("", Method.Post);
            request.AddJsonBody(Newtonsoft.Json.JsonConvert.SerializeObject(new JsonRequest(v)));
            var ret = client.Execute(request);
            var jsonResponse = ret.Content; // raw content as string
            if (
            ret.IsSuccessful)
            { 
                response = JsonConvert.DeserializeObject<ResponsePlaza>(jsonResponse);
            }
            return ret.IsSuccessful; 
        }

        public static bool ActualizaConnectRest(string _url, PlazaModel v, ref ResponsePlaza response)
        {
            var client = new RestClient(_url + "/" + v.PlazaId) ;
            var request = new RestRequest("", Method.Put);
            request.AddJsonBody(Newtonsoft.Json.JsonConvert.SerializeObject(new JsonRequest(v)));
            var ret = client.Execute(request);
            var jsonResponse = ret.Content; // raw content as string
            if (
            ret.IsSuccessful)
            {
                response = JsonConvert.DeserializeObject<ResponsePlaza>(jsonResponse);
            }
            return ret.IsSuccessful;
        }
        public static bool DeleteConnectRest(string _url, PlazaModel v, ref ResponsePlaza response)
        {
            var client = new RestClient(_url + "/" + v.PlazaId);
            var request = new RestRequest("", Method.Delete); 
            var ret = client.Execute(request);
            var jsonResponse = ret.Content; // raw content as string
            if (
            ret.IsSuccessful)
            {
                response = JsonConvert.DeserializeObject<ResponsePlaza>(jsonResponse);
            }
            return ret.IsSuccessful;
        }

    }
}