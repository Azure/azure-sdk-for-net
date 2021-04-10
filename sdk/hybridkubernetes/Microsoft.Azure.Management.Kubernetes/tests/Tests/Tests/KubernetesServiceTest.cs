using System.Net;
using KubernetesService.Tests;
using Microsoft.Kubernetes;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace KubernetesService.Tests
{
    public partial class KubernetesServiceTests
    {
  
       private ResourceManagementClient resourceManagementClient;
       private ConnectedKubernetesClient kubernetesServiceClient;
       private RecordedDelegatingHandler handler = new RecordedDelegatingHandler();

       protected bool m_initialized = false;
       protected object m_lock = new object();

        protected void InitializeClients(MockContext context)
        {
            if (!m_initialized)
            {
                lock (m_lock)
                {
                    if (!m_initialized)
                    {
                        resourceManagementClient = KubernetesServiceTestUtilities.GetResourceManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        kubernetesServiceClient = KubernetesServiceTestUtilities.GetKubernetesServiceManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                    }
                }
            }
        }

        public ResourceManagementClient ResourceManagementClient
        {
            get
            {
                return resourceManagementClient;
            }
        }

        public ConnectedKubernetesClient ConnectedKubernetesClient
        {
            get
            {
                return kubernetesServiceClient;
            }
        }
    }
}
