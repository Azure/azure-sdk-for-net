using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace TemplateSpecs.Tests
{
    public class LiveTemplateSpecsTests : TestBase
    {
        private const string TestLocation = "westus";

        [Fact]
        public void CanCrudTemplateSpec()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<TemplateSpecsClient>();
                var resourceGroupClient = context.GetServiceClient<ResourceManagementClient>();

                // Create our test resource group: 
                var resourceGroupName = $"{TestUtilities.GenerateName("TS-SDKTest-")}-RG";
                var resourceGroup = resourceGroupClient.ResourceGroups.CreateOrUpdate(
                    resourceGroupName, 
                    new ResourceGroup(TestLocation)
                );

                try
                {
                    var templateSpecName = $"{TestUtilities.GenerateName("TS-SDKTest-")}";
                    var templateSpecToCreate = new TemplateSpec
                    {
                        Description = "Description of my Template Spec",
                        DisplayName = $"{templateSpecName} (Test)",
                        Location = TestLocation
                    };

                    var createdTemplateSpec = client.TemplateSpecs.CreateOrUpdate(
                        resourceGroupName,
                        templateSpecName,
                        templateSpecToCreate
                    );

                    // Validate user specified details:

                    Assert.NotNull(createdTemplateSpec);
                    Assert.Equal(TestLocation, createdTemplateSpec.Location);
                    Assert.Equal(createdTemplateSpec.Name, templateSpecName);
                    Assert.Equal(createdTemplateSpec.Description, templateSpecToCreate.Description);
                    Assert.Equal(createdTemplateSpec.DisplayName, templateSpecToCreate.DisplayName);

                    // Validate readonly properties are present:

                    Assert.NotNull(createdTemplateSpec.Id);
                    Assert.NotNull(createdTemplateSpec.Type);
                    Assert.NotNull(createdTemplateSpec.SystemData?.CreatedAt);
                    Assert.NotNull(createdTemplateSpec.SystemData?.CreatedBy);
                    Assert.NotNull(createdTemplateSpec.SystemData?.CreatedByType);
                    Assert.NotNull(createdTemplateSpec.SystemData?.LastModifiedAt);
                    Assert.NotNull(createdTemplateSpec.SystemData?.LastModifiedBy);
                    Assert.NotNull(createdTemplateSpec.SystemData?.LastModifiedByType);

                    // Make sure our object returned from GET is equal to the one which was returned
                    // from the creation:

                    var templateSpecFromGet = client.TemplateSpecs.Get(resourceGroupName, templateSpecName);
                    Assert.Equal(
                        JsonConvert.SerializeObject(createdTemplateSpec),
                        JsonConvert.SerializeObject(templateSpecFromGet)
                    );

                    // Validate we can perform an update on the existing template spec:

                    var templateSpecUpdate = JsonConvert.DeserializeObject<TemplateSpec>(
                        JsonConvert.SerializeObject(templateSpecToCreate)
                    );

                    templateSpecUpdate.Description = "This is an updated description";

                    var updatedTemplateSpec = client.TemplateSpecs.CreateOrUpdate(
                        resourceGroupName,
                        templateSpecName,
                        templateSpecUpdate
                    );

                    updatedTemplateSpec.Description.Equals(templateSpecUpdate.Description);

                    // Validate we can get the template spec from a List at the resource group level:

                    var listAtResourceGroupResult = client.TemplateSpecs.ListByResourceGroup(resourceGroupName);
                    Assert.NotEmpty(listAtResourceGroupResult);

                    var templateSpecFromList = listAtResourceGroupResult.FirstOrDefault(
                        ts => ts.Name.Equals(templateSpecName)
                    );

                    Assert.NotNull(templateSpecFromList);

                    // Validate we can get the template spec from a List at the subscription level:

                    var listAtSubscriptionResult = client.TemplateSpecs.ListBySubscription();
                    Assert.NotEmpty(listAtSubscriptionResult);

                    templateSpecFromList = listAtResourceGroupResult.FirstOrDefault(
                        ts => ts.Name.Equals(templateSpecName)
                    );

                    Assert.NotNull(templateSpecFromList);

                    // Now delete the template spec and make sure it is no longer retrievable:

                    client.TemplateSpecs.Delete(resourceGroupName, templateSpecName);
                    Assert.ThrowsAny<Exception>(() => client.TemplateSpecs.Get(resourceGroupName, templateSpecName));
                }
                finally
                {
                    resourceGroupClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }

        [Fact]
        public void CanCrudSimpleTemplateSpecVersion()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<TemplateSpecsClient>();
                var resourceGroupClient = context.GetServiceClient<ResourceManagementClient>();

                // Create our test resource group: 
                var resourceGroupName = $"{TestUtilities.GenerateName("TS-SDKTest-")}-RG";
                var resourceGroup = resourceGroupClient.ResourceGroups.CreateOrUpdate(
                    resourceGroupName,
                    new ResourceGroup(TestLocation)
                );

                try
                {
                    // Create the template spec:

                    var templateSpecName = $"{TestUtilities.GenerateName("TS-SDKTest-")}";
                    var templateSpecToCreate = new TemplateSpec
                    {
                        Location = TestLocation
                    };

                    var createdTemplateSpec = client.TemplateSpecs.CreateOrUpdate(
                        resourceGroupName,
                        templateSpecName,
                        templateSpecToCreate
                    );

                    Assert.NotNull(createdTemplateSpec);

                    // Now create a simple template spec version:

                    var templateSpecVersionToCreate = new TemplateSpecVersion
                    {
                        Description = "My first version",
                        Location = TestLocation,
                        Template = JObject.Parse(
                            File.ReadAllText(
                                Path.Combine("ScenarioTests", "simple-storage-account.json")
                            )
                        )
                    };

                    const string versionName = "v1";

                    var createdTemplateSpecVersion = client.TemplateSpecVersions.CreateOrUpdate(
                        resourceGroupName,
                        templateSpecName,
                        "v1",
                        templateSpecVersionToCreate
                    );

                    Assert.NotNull(createdTemplateSpecVersion);

                    // Validate user specified details:

                    Assert.Equal(TestLocation, createdTemplateSpecVersion.Location);
                    Assert.Equal(createdTemplateSpecVersion.Name, versionName);
                    Assert.Equal(createdTemplateSpecVersion.Description, templateSpecVersionToCreate.Description);
                    Assert.Equal(createdTemplateSpecVersion.Template?.ToString(), templateSpecVersionToCreate.Template.ToString());

                    // Validate readonly properties are present:

                    Assert.NotNull(createdTemplateSpecVersion.Id);
                    Assert.NotNull(createdTemplateSpecVersion.Type);
                    Assert.NotNull(createdTemplateSpecVersion.SystemData?.CreatedAt);
                    Assert.NotNull(createdTemplateSpecVersion.SystemData?.CreatedBy);
                    Assert.NotNull(createdTemplateSpecVersion.SystemData?.CreatedByType);
                    Assert.NotNull(createdTemplateSpecVersion.SystemData?.LastModifiedAt);
                    Assert.NotNull(createdTemplateSpecVersion.SystemData?.LastModifiedBy);
                    Assert.NotNull(createdTemplateSpecVersion.SystemData?.LastModifiedByType);

                    // Make sure our object returned from GET is equal to the one which was returned
                    // from the creation:

                    var templateSpecVersionFromGet = client.TemplateSpecVersions.Get(resourceGroupName, templateSpecName, versionName);
                    Assert.Equal(
                        JsonConvert.SerializeObject(createdTemplateSpecVersion),
                        JsonConvert.SerializeObject(templateSpecVersionFromGet)
                    );

                    // Validate we can perform an update on the existing version:

                    var templateSpecVersionUpdate = JsonConvert.DeserializeObject<TemplateSpecVersion>(
                        JsonConvert.SerializeObject(templateSpecVersionToCreate)
                    );

                    templateSpecVersionUpdate.Description = "This is an updated description";

                    var updatedTemplateSpecVersion = client.TemplateSpecVersions.CreateOrUpdate(
                        resourceGroupName,
                        templateSpecName,
                        versionName,
                        templateSpecVersionUpdate
                    );

                    updatedTemplateSpecVersion.Description.Equals(templateSpecVersionUpdate.Description);

                    // Validate we can get the version when listing versions on the template spec:

                    var listVersionsResult = client.TemplateSpecVersions.List(resourceGroupName, templateSpecName);
                    Assert.Equal(1, listVersionsResult?.Count());

                    var versionFromList = listVersionsResult.FirstOrDefault(
                        tsv => tsv.Name.Equals(versionName)
                    );

                    Assert.NotNull(versionFromList);

                    // Now delete the template spec and make sure the version is no longer retrievable:

                    client.TemplateSpecs.Delete(resourceGroupName, templateSpecName);
                    Assert.ThrowsAny<Exception>(
                        () => client.TemplateSpecVersions.Get(resourceGroupName, templateSpecName, versionName)
                    );
                }
                finally
                {
                    resourceGroupClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }
    }
}
