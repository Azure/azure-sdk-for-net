// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//


namespace IotCentral.Tests.Helpers
{
    using System.Net;
    using Microsoft.Azure.Management.IotCentral;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public class IotCentralTestUtilities
    {
        public static string DefaultLocation = "WestUS";
        public static string DefaultIotCentralName = "dotnetsdkapp";
        public static string DefaultUpdateIotCentralName = "dotnetsdkapppdate";
        public static string DefaultResourceGroupName = "DotNetSdkIotCentralRG";
        public static string DefaultUpdateResourceGroupName = "UpdateDotNetSdkIotCentralRG";

        public static IotCentralClient GetIotCentralClient(MockContext context, RecordedDelegatingHandler handler = null)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            return context.GetServiceClient<IotCentralClient>(handlers: handler ?? new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
        }

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return client;
        }
    }
}
