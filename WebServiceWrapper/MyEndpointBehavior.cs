using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace WebServiceWrapper
{
    public class MyEndpointBehavior : IEndpointBehavior
    {
        public void Validate(
           ServiceEndpoint endpoint)
        {
        }

        public void AddBindingParameters(
            ServiceEndpoint endpoint,
            BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(
            ServiceEndpoint endpoint,
            EndpointDispatcher endpointDispatcher)
        {
        }

        public void ApplyClientBehavior(
            ServiceEndpoint endpoint,
            ClientRuntime clientRuntime)
        {
            //var myClientMessageInspector = new MyClientMessageInspector();

            //clientRuntime.MessageInspectors.Add(myClientMessageInspector);
        }
    }
}
