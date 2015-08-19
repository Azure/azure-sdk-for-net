using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test;

namespace Helpers
{
    public static class ClientExtensions
    {
        public static ResourceManagementClient GetResourceManagementClientWithSpn(this TestBase testBase)
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(new CsmSpnFactory());
        }
    }
}
