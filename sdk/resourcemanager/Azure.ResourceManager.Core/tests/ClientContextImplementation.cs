using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;

namespace Azure.ResourceManager.Core.Tests
{
    class ClientContextImplementation : IClientContext
    {
        AzureResourceManagerClientOptions IClientContext.ClientOptions { get; set; }
        TokenCredential IClientContext.Credential { get; set; }
        Uri IClientContext.BaseUri { get; set; }

        public ClientContextImplementation()
        {
            ((IClientContext)this).ClientOptions = new AzureResourceManagerClientOptions();
            ((IClientContext)this).Credential = new DefaultAzureCredential(); // TODO: should make fake credential
            ((IClientContext)this).BaseUri = new Uri("http://foo.com");
        }
    }
}
