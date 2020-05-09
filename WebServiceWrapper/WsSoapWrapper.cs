using App.Service;
using App.Service.Models;
using CalculatorSoapWs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Cryptography.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceWrapper
{
    
    
    public class WsSoapWrapper:IClientMessageInspector 
    {
        private WsCatch SoapCatch;
        private WsCatch RestCatch;
        private IConfiguration _configuration;
        public WsSoapWrapper(IConfiguration  configuration)
        {
            Client = new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap);
             SoapCatch = new WsCatch() { type=Service_Type.Soap };
            RestCatch = new WsCatch() { type = Service_Type.Rest };
            _configuration = configuration;
        }
        public object BeforeSendRequest(
          ref Message request,
          IClientChannel channel)
        {
            return request;
        }

        public void AfterReceiveReply(
            ref Message reply,
            object correlationState)
        {
            string srequest = correlationState.ToString();
            string sresponse = reply.ToString();
            SoapCatch.Request = srequest;
            SoapCatch.Response = sresponse;
            SoapCatch.type = Service_Type.Soap;
            WsLogWriter logWriter =new WsLogWriter(_configuration);
            logWriter.WriteLinkedWsCatches(new List<WsCatch>() { SoapCatch, RestCatch });
        }
        CalculatorSoapWs.CalculatorSoapClient Client;
       
        public async System.Threading.Tasks.Task<WebServiceWrapper.AddResponse> AddAsync(Request request)
        {
            RestCatch.Request = JsonConvert.SerializeObject(request).ToString();
            CalculatorSoapWs.AddResponse SoapResponse = await Client.AddAsync(new CalculatorSoapWs.AddRequest() { intA = request.intA, intB = request.intB });
            return new WebServiceWrapper.AddResponse() { AddResult = SoapResponse.AddResult };
        }
        public async Task<WebServiceWrapper.SubtractResponse> SubtractAsync(Request request)
        {
            RestCatch.Request = JsonConvert.SerializeObject(request).ToString();
            CalculatorSoapWs.SubtractResponse SoapResponse= await Client.SubtractAsync(new CalculatorSoapWs.SubtractRequest() { intA = request.intA, intB = request.intB });
            return new WebServiceWrapper.SubtractResponse() { SubtractResult = SoapResponse.SubtractResult };
        }
        public async Task<WebServiceWrapper.MultiplyResponse> MultiplyAsync(Request request)
        {
            RestCatch.Request = JsonConvert.SerializeObject(request).ToString();
            CalculatorSoapWs.MultiplyResponse SoapResponse= await Client.MultiplyAsync(new CalculatorSoapWs.MultiplyRequest() { intA = request.intA, intB = request.intB });
            return new WebServiceWrapper.MultiplyResponse() { MultiplyResult = SoapResponse.MultiplyResult };

        }
        public async Task<WebServiceWrapper.DivideResponse> DivideAsync(Request request)
        {
            RestCatch.Request = JsonConvert.SerializeObject(request).ToString();
            CalculatorSoapWs.DivideResponse SoapResponse = await Client.DivideAsync(new CalculatorSoapWs.DivideRequest() { intA = request.intA, intB = request.intB });
            return new WebServiceWrapper.DivideResponse() { DivideResult = SoapResponse.DivideResult };
        }
    
    }
  
    public class Request
    {

        public int intA { get; set; }

        public int intB { get; set; }
    }

    public class AddResponse
    {

        public int AddResult;
    }
    public class DivideResponse
    {
        
        public int DivideResult;
    }
    
    public class MultiplyResponse
    {
        
        public int MultiplyResult;
    }
    
    public class SubtractResponse
    {
        
        public int SubtractResult;
    }
   
    
    public class AddRequest : Request
    {

    }
    
    public class SubtractRequest : Request
    {

    }
    
    public class MultiplyRequest:Request
    {
 
    }
    
    public class DivideRequest:Request
    {

    }
    
}
