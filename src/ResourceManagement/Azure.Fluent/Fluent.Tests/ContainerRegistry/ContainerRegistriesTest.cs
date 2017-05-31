using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.ContainerRegistry.Fluent;

namespace Azure.Tests.Compute
{
    public class ContainerRegistriesTest
    {
        [Fact]
        public void Test()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var regName = TestUtilities.GenerateName("reg");
                var saName = TestUtilities.GenerateName("regsa");
                var registryManager = TestHelper.CreateRegistryManager();
                IRegistry registry = null;

                try
                {
                    registry = registryManager.ContainerRegistries.Define(regName)
                            .WithRegion(Region.USWest)
                            .WithNewResourceGroup()
                            .WithNewStorageAccount(saName)
                            .WithRegistryNameAsAdminUser()
                            .Create();

                    Assert.True(registry.AdminUserEnabled);
                    Assert.Equal(registry.StorageAccountName, saName);

                    registry = registry.Update()
                        .WithTag("tag2", "value2")
                        .WithTag("tag3", "value3")
                        .WithoutTag("tag1")
                        .Apply();

                    Assert.True(registry.Tags.ContainsKey("tag2"));
                    Assert.True(!registry.Tags.ContainsKey("tag1"));
                }
                finally
                {
                    try
                    {
                        registryManager.ContainerRegistries.DeleteById(registry.Id);
                    }
                    catch { }
                }

            }
        }
    }
}
