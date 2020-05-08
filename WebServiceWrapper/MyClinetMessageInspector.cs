using App.Service.Models;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace WebServiceWrapper
{
    public class MyClientMessageInspector : IClientMessageInspector
    {

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
            var soapCatch = new WsCatch() {Request = srequest, Response= sresponse,type =Service_Type.Soap };
            //we can save now 
        }

        XElement StringToXml(string xmlstring)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlstring);
            return XElement.Parse(xmlstring);
        }
    }
}
