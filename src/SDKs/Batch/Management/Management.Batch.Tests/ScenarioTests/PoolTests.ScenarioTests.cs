using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;


namespace Batch.Tests.ScenarioTests
{
    public class PoolTests : BatchScenarioTestBase
    {
        [Fact]
        public async Task BatchPoolEndToEndAsync()
        {
            using (MockContext context = StartMockContextAndInitializeClients(this.GetType().FullName))
            {
                string resourceGroupName = TestUtilities.GenerateName();
                string batchAccountName = TestUtilities.GenerateName();
                string paasPoolName = "test_paas_pool";
                string iaasPoolName = "test_iaas_pool";
                ResourceGroup group = new ResourceGroup(this.Location);
                await this.ResourceManagementClient.ResourceGroups.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, group);

                // Create an account
                BatchAccountCreateParameters createParams = new BatchAccountCreateParameters(this.Location);
                await this.BatchManagementClient.BatchAccount.CreateAsync(resourceGroupName, batchAccountName, createParams);

                try
                {
                    // Create PaaS pool
                    Pool paasPool = new Pool();
                    paasPool.DisplayName = "test_pool";
                    paasPool.VmSize = "small";
                    paasPool.DeploymentConfiguration = new DeploymentConfiguration()
                    {
                        CloudServiceConfiguration = new CloudServiceConfiguration()
                        {
                            OsFamily = "5"
                        }
                    };
                    var resources = new List<ResourceFile>();
                    resources.Add(new ResourceFile("https://blobsource.com", "filename.txt"));
                    var environments = new List<EnvironmentSetting>();
                    environments.Add(new EnvironmentSetting("ENV_VAR", "env_value"));
                    paasPool.StartTask = new StartTask()
                    {
                        CommandLine = "cmd.exe /c \"echo hello world\"",
                        ResourceFiles = resources,
                        EnvironmentSettings = environments,
                        UserIdentity = new UserIdentity()
                        {
                            AutoUser = new AutoUserSpecification()
                            {
                                ElevationLevel = ElevationLevel.Admin
                            }
                        }
                    };
                    var accounts = new List<UserAccount>();
                    accounts.Add(new UserAccount("username", "randompasswd"));
                    paasPool.UserAccounts = accounts;
                    paasPool.ScaleSettings = new ScaleSettings()
                    {
                        FixedScale = new FixedScaleSettings()
                        {
                            TargetDedicatedNodes = 0,
                            TargetLowPriorityNodes = 0
                        }
                    };

                    var paasPoolResponse = await this.BatchManagementClient.Pool.CreateAsync(resourceGroupName, batchAccountName, paasPoolName, paasPool);
                    Assert.NotNull(paasPoolResponse.StartTask);
                    var referenceId =
                        $"/subscriptions/{this.BatchManagementClient.SubscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{batchAccountName}/pools/{paasPoolName.ToLowerInvariant()}";
                    Assert.Equal(referenceId, paasPoolResponse.Id);

                    // Create IaaS pool
                    Pool iaasPool = new Pool();
                    iaasPool.DisplayName = "test_pool";
                    iaasPool.VmSize = "Standard_A1";
                    iaasPool.DeploymentConfiguration = new DeploymentConfiguration()
                    {
                        VirtualMachineConfiguration = new VirtualMachineConfiguration()
                        {
                            ImageReference = new ImageReference()
                            {
                                Publisher = "MicrosoftWindowsServer",
                                Offer = "WindowsServer",
                                Sku = "2016-Datacenter-smalldisk"
                            },
                            NodeAgentSkuId = "batch.node.windows amd64",
                            WindowsConfiguration = new WindowsConfiguration(true)
                        }
                    };
                    iaasPool.ScaleSettings = new ScaleSettings()
                    {
                        FixedScale = new FixedScaleSettings()
                        {
                            TargetDedicatedNodes = 0,
                            TargetLowPriorityNodes = 0
                        }
                    };

                    var iaasPoolResponse = await this.BatchManagementClient.Pool.CreateAsync(resourceGroupName, batchAccountName, iaasPoolName, iaasPool);
                    Assert.Null(iaasPoolResponse.StartTask);
                    referenceId =
                        $"/subscriptions/{this.BatchManagementClient.SubscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{batchAccountName}/pools/{iaasPoolName.ToLowerInvariant()}";
                    Assert.Equal(referenceId, iaasPoolResponse.Id);

                    // Verify list operation
                    var pools = await this.BatchManagementClient.Pool.ListByBatchAccountAsync(resourceGroupName, batchAccountName);
                    Assert.Equal(2, pools.Count());

                    // Verify get operation
                    var pool = await this.BatchManagementClient.Pool.GetAsync(resourceGroupName, batchAccountName, iaasPoolName);
                    Assert.Equal("STANDARD_A1", pool.VmSize);
                    Assert.Null(pool.DisplayName);
                    Assert.Equal(AllocationState.Steady, pool.AllocationState);
                    Assert.Equal("batch.node.windows amd64", pool.DeploymentConfiguration.VirtualMachineConfiguration.NodeAgentSkuId);

                    // Verify stop resize operation
                    await this.BatchManagementClient.Pool.StopResizeAsync(resourceGroupName, batchAccountName, iaasPoolName);

                    // Verify disable auto scale operation
                    await this.BatchManagementClient.Pool.DisableAutoScaleAsync(resourceGroupName, batchAccountName, iaasPoolName);

                    // Delete the paas pool
                    try
                    {
                        await this.BatchManagementClient.Pool.DeleteAsync(resourceGroupName, batchAccountName, paasPoolName);
                    }
                    catch (CloudException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound)
                        {
                            throw;
                        }
                    }

                    // Delete iaaS pool
                    try
                    {
                        await this.BatchManagementClient.Pool.DeleteAsync(resourceGroupName, batchAccountName, iaasPoolName);
                    }
                    catch (CloudException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound)
                        {
                            throw;
                        }
                    }

                    // Verify pool was deleted. A GET operation will return a 404 error and result in an exception
                    try
                    {
                        await this.BatchManagementClient.Pool.GetAsync(resourceGroupName, batchAccountName, paasPoolName);
                    }
                    catch (CloudException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }

                }
                finally
                {
                    await this.BatchManagementClient.BatchAccount.DeleteAsync(resourceGroupName, batchAccountName);
                    await this.ResourceManagementClient.ResourceGroups.DeleteWithHttpMessagesAsync(resourceGroupName);
                }
            }
        }
    }
}
