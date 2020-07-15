using System.Net;
using ContainerService.Tests;
using Microsoft.Azure.Management.ContainerService;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace ContainerService.Tests
{
    public partial class ContainerServiceTests
    {
  
       private ResourceManagementClient resourceManagementClient;
       private ContainerServiceClient containerServiceClient;
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
                        resourceManagementClient = ContainerServiceTestUtilities.GetResourceManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        containerServiceClient = ContainerServiceTestUtilities.GetContainerServiceManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
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

        public ContainerServiceClient ContainerServiceClient
        {
            get
            {
                return containerServiceClient;
            }
        }
    }
}
