using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Nelibur.ServiceModel.Services
{
    /// <summary>
    /// This behavior prevents the raise of <see cref="SerializationException"/> for the clients if there was a fault on the backend service.
    /// </summary>
    /// <remarks>
    /// https://msdn.microsoft.com/en-us/library/ms733786.aspx
    /// </remarks>
    public class DetailedFaultsEndpointBehavior : IEndpointBehavior
    {
        public void Validate(ServiceEndpoint endpoint)
        {
            // No implementation necessary
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            // No implementation necessary
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            // No implementation necessary
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new MessageWithFaultInspector());
        }
    }
}
