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
        public static string DefaultLocation = "EastUS";
        public static string DefaultResourceName = "defaultdotnetsdkapp";
        public static string DefaultUpdateResourceName = "defaultdotnetsdkappupdate";
        public static string DefaultSubdomain = "defaultdotnetsdksubdomain";
        public static string DefaultUpdateSubdomain = "defaultdotnetsdksubdomainupdate";
        public static string DefaultResourceGroupName = "DefaultDotNetSdkIotCentralRG";
        public static string DefaultUpdateResourceGroupName = "DefaultDotNetSdkIotCentralRGUpdate";
        
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
