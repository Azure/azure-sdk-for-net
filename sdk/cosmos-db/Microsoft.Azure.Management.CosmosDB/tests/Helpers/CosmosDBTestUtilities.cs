using System;
using System.Net;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Threading;
using Xunit;

namespace CosmosDB.Tests
{
    public class CosmosDBTestUtilities
    {
        // User name and password for admin user configured on compute cluster and file servers.
        public static string ADMIN_USER_NAME = "demoUser";
        public static string ADMIN_USER_PASSWORD = "Dem0Pa$$w0rd";
        // Location to run tests.
        public static string LOCATION = "eastus";

        public static CosmosDBManagementClient GetCosmosDBClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            CosmosDBManagementClient client = context.GetServiceClient<CosmosDBManagementClient>(handlers : handler);
            return client;
        }

        public static string CreateResourceGroup(ResourceManagementClient resourcesClient)
        {
            const string testPrefix = "CosmosDBResourceGroup";
            var rgname = TestUtilities.GenerateName(testPrefix);

            var resourceGroupDefinition = new ResourceGroup
            {
                Location = LOCATION
            };
            resourcesClient.ResourceGroups.CreateOrUpdate(rgname, resourceGroupDefinition);
            return rgname;
        }
    
        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            ResourceManagementClient resourcesClient = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return resourcesClient;
        }
    }
}
