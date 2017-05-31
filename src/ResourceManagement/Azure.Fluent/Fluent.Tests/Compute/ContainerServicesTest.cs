using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;

namespace Azure.Tests.Compute
{
    public class ContainerServicesTest
    {
        [Fact]
        public void Test()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var csName = TestUtilities.GenerateName("cr");
                var saName = TestUtilities.GenerateName("crsa");
                var dnsPrefix = TestUtilities.GenerateName("dns");
                var computeManager = TestHelper.CreateComputeManager();
                IContainerService containerService = null;
                try
                {
                    string sshKeyData = this.getSshKey();
                    containerService = computeManager.ContainerServices.Define(csName)
                            .WithRegion(Region.USWest)
                            .WithNewResourceGroup()
                            .WithDcosOrchestration()
                            .WithLinux()
                            .WithRootUsername("testUserName")
                            .WithSshKey(sshKeyData)
                            .WithMasterNodeCount(ContainerServiceMasterProfileCount.MIN)
                            .WithMasterLeafDomainLabel("mp1" + dnsPrefix)
                            .DefineAgentPool("agentPool0" + csName)
                                .WithVMCount(1)
                                .WithVMSize(ContainerServiceVMSizeTypes.StandardA1)
                                .WithLeafDomainLabel("ap0" + dnsPrefix)
                                .Attach()
                            .WithDiagnostics()
                            .WithTag("tag1", "value1")
                            .Create();
                    Assert.NotNull(containerService.Id);
                    Assert.Equal(containerService.Region, Region.USWest);
                    Assert.Equal(containerService.MasterNodeCount, (int)ContainerServiceMasterProfileCount.MIN);
                    Assert.Equal(containerService.LinuxRootUsername, "testUserName");
                    Assert.Equal(containerService.AgentPoolCount, 1);
                    Assert.Equal(containerService.AgentPoolName, "agentPool0" + csName);
                    Assert.Equal(containerService.AgentPoolLeafDomainLabel, "ap0" + dnsPrefix);
                    Assert.Equal(containerService.AgentPoolVMSize, ContainerServiceVMSizeTypes.StandardA1);
                    Assert.Equal(containerService.OrchestratorType, ContainerServiceOchestratorTypes.DCOS);
                    Assert.True(containerService.IsDiagnosticsEnabled);
                    Assert.True(containerService.Tags.ContainsKey("tag1"));


                    containerService = containerService.Update()
                        .WithAgentVMCount(5)
                        .WithoutDiagnostics()
                        .WithTag("tag2", "value2")
                        .WithTag("tag3", "value3")
                        .WithoutTag("tag1")
                        .Apply();

                    Assert.True(containerService.AgentPoolCount == 5);
                    Assert.True(containerService.Tags.ContainsKey("tag2"));
                    Assert.True(!containerService.Tags.ContainsKey("tag1"));
                    Assert.True(!containerService.IsDiagnosticsEnabled);

                }
                finally
                {
                    try
                    {
                        computeManager.ContainerServices.DeleteById(containerService.Id);
                    }
                    catch { }
                }

            }
        }

        private string getSshKey()
        {
            return "ssh-rsa  ";
    }
}
}
