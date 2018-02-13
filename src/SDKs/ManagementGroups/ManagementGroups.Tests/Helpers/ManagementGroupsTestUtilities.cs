using System.Net;
using Microsoft.Azure.Management.ManagementGroups;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using ResourceGroups.Tests;

namespace Resource.Tests.Helpers
{
    public static class ManagementGroupsTestUtilities
    {

        public static ManagementGroupsAPIClient GetManagementGroupsApiClient(MockContext context,
            RecordedDelegatingHandler handler = null)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            var client = context.GetServiceClient<ManagementGroupsAPIClient>(
                handlers: handler ?? new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

            return client;
        }
    }
}