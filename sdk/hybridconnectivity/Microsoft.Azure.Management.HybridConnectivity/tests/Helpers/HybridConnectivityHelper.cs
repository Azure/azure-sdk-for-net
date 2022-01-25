using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Management.HybridConnectivity.Tests.Helpers
{
    public static class HybridConnectivityHelper
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <param name="context"></param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static HybridConnectivityManagementClient GetHybridConnectivityManagementClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<HybridConnectivityManagementClient>();
        }
    }
}
