// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.HybridCompute;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Management.HybridCompute.Tests.Helpers
{
    public static class HybridComputeHelper
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <param name="context"></param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static HybridComputeManagementClient GetHybridComputeManagementClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<HybridComputeManagementClient>();
        }

        public static string GenerateName()
        {
            return TestUtilities.GenerateName("azuresdkfornetautoresthybridcompute");
        }
    }
}
