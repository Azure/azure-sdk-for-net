using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Net;
using System.Threading;

namespace NetApp.Tests.Helpers
{
    public static class NetAppTestUtilities
    {
        public static AzureNetAppFilesManagementClient GetNetAppManagementClient(MockContext context, RecordedDelegatingHandler handler = null)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            var client = context.GetServiceClient<AzureNetAppFilesManagementClient>(handlers:
                handler ?? new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
            return client;
        }
    }
}