using Microsoft.Azure.Management.ApiApps.Models;
using Microsoft.Azure.Management.ApiApps.Tests.TestSupport;
using Xunit;

namespace Microsoft.Azure.Management.ApiApps.Tests.Templates
{
    public class GetTemplateMetadataTests : ApiAppTestBase
    {
        [Fact]
        public void CanGetTemplateMetadataForPackageWithNoDependencies()
        {
            UndoCtx.Start();
            WithNewGroup<ApiAppManagementClient>((groupName, client) =>
            {
                var response = client.Templates.GetMetadata(new GetDeploymentMetadataRequest()
                {
                    MicroserviceId = "Microsoft.Azure.AppService.ApiApps.TestBench",
                    ResourceGroupName = groupName
                });

                var metadata = response.Metadata;
                Assert.Equal("Microsoft.Azure.AppService.ApiApps.TestBench", metadata.MicroserviceId);
                Assert.Equal(0, metadata.DependsOn.Count);
                Assert.Equal(0, metadata.Parameters.Count);
            });
        }

        [Fact]
        public void CanGetTemplateMetadataForPackageWithParameters()
        {
            UndoCtx.Start();

            WithNewGroup<ApiAppManagementClient>((groupName, client) =>
            {
                var response = client.Templates.GetMetadata(new GetDeploymentMetadataRequest
                {
                    MicroserviceId = "SalesforceConnector",
                    ResourceGroupName = groupName
                });
                var metadata = response.Metadata;
                Assert.Equal("SalesforceConnector", metadata.MicroserviceId);
                Assert.Equal(1, metadata.Parameters.Count);
                Assert.Equal("salesforceentities", metadata.Parameters[0].Name);
            });
        }
    }
}
