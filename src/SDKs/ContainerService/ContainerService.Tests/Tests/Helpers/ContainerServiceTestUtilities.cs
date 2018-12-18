using System;
using System.Collections.Generic;
using System.Text;
using ContainerService.Tests;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Management.ContainerService.Tests
{
    public class ContainerServiceTestUtilities
    {
        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            throw new NotImplementedException();
        }

        internal static ContainerServiceClient GetContainerServiceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            throw new NotImplementedException();
        }

        internal static object CreateResourceGroup(ResourceManagementClient resourceClient)
        {
            throw new NotImplementedException();
        }
    }
}
