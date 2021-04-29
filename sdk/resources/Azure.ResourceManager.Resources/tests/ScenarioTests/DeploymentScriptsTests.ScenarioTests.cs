// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Resources.Tests;
using NUnit.Framework;

namespace DeploymentScripts.Tests
{
    public class LiveDeploymentScriptsTests : ResourceOperationsTestsBase
    {
        public LiveDeploymentScriptsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        private const string LocationWestUs = "West US";
        private const string AzurePowerShellVersion = "2.7.0";
        private static readonly TimeSpan RetentionInterval = new TimeSpan(1, 2, 0, 0, 0);
        private const string ResourceGroupName = "Ds-TestRg";
        private const string ScriptContent =
            "param([string] $helloWorld) Write-Output $helloWorld; $DeploymentScriptOutputs['output'] = $helloWorld";
        private const string MalformedScriptContent =
            "This-will-fail.";
        private const string ScriptArguments = "'Hello World'";

        [Test]
        public async Task CanCrudSimpleDeploymentScript()
        {
            // create user assigned managed identity during test run since we'll be using dynamic properties, such as subscriptionId from the test
            var managedIdentity = new ManagedServiceIdentity()
            {
                Type = "UserAssigned",
                UserAssignedIdentities =
                {
                    {
                        $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/filiz-user-assigned-msi",
                        new UserAssignedIdentity()
                    }
                }
            };

            // Create deployment script object with minimal properties
            var deploymentScriptName = GetCallingMethodName() + "--" + Recording.GenerateAssetName("csmd");

            var deploymentScript = new AzurePowerShellScript(managedIdentity, LocationWestUs, RetentionInterval, AzurePowerShellVersion)
            {
                ScriptContent = ScriptContent,
                Arguments = ScriptArguments
            };

            var rawCreateDeploymentScriptResult = await DeploymentScriptsOperations.StartCreateAsync(ResourceGroupName, deploymentScriptName, deploymentScript);
            var createDeploymentScriptResult = (await WaitForCompletionAsync(rawCreateDeploymentScriptResult)).Value as AzurePowerShellScript;

            Assert.NotNull(createDeploymentScriptResult);
            Assert.AreEqual(ScriptProvisioningState.Succeeded, createDeploymentScriptResult.ProvisioningState);

            AzurePowerShellScript getDeploymentScript = (await DeploymentScriptsOperations.GetAsync(ResourceGroupName, deploymentScriptName)).Value as AzurePowerShellScript;

            // Validate result
            Assert.NotNull(getDeploymentScript);
            Assert.AreEqual(deploymentScript.Location, getDeploymentScript.Location);
            Assert.AreEqual(deploymentScript.AzPowerShellVersion, getDeploymentScript.AzPowerShellVersion);
            Assert.AreEqual(deploymentScript.Identity.Type, getDeploymentScript.Identity.Type);
            Assert.NotNull(deploymentScript.Identity.UserAssignedIdentities.Values.FirstOrDefault());
            Assert.AreEqual(deploymentScript.Identity.UserAssignedIdentities.Keys.FirstOrDefault(),
                getDeploymentScript.Identity.UserAssignedIdentities.Keys.FirstOrDefault());
            Assert.NotNull(getDeploymentScript.ScriptContent);
            Assert.AreEqual(deploymentScript.ScriptContent, getDeploymentScript.ScriptContent);
            Assert.NotNull(getDeploymentScript.Arguments);
            Assert.AreEqual(deploymentScript.Arguments, getDeploymentScript.Arguments);
            Assert.NotNull(deploymentScript.RetentionInterval.ToString());
            Assert.AreEqual(deploymentScript.RetentionInterval, getDeploymentScript.RetentionInterval);

            // Validate read-only properties
            Assert.NotNull(getDeploymentScript.Id);
            Assert.NotNull(getDeploymentScript.Name);
            Assert.AreEqual(deploymentScriptName, getDeploymentScript.Name);
            Assert.NotNull(getDeploymentScript.Identity.UserAssignedIdentities.Values.FirstOrDefault().ClientId);
            Assert.NotNull(getDeploymentScript.Identity.UserAssignedIdentities.Values.FirstOrDefault().PrincipalId);
            Assert.NotNull(getDeploymentScript.ProvisioningState);
            Assert.NotNull(getDeploymentScript.Timeout);
            Assert.NotNull(getDeploymentScript.CleanupPreference);
            Assert.NotNull(getDeploymentScript.Status);
            Assert.NotNull(getDeploymentScript.Status.StartTime);
            Assert.NotNull(getDeploymentScript.Status.EndTime);
            Assert.NotNull(getDeploymentScript.Status.ContainerInstanceId);
            Assert.NotNull(getDeploymentScript.Status.StorageAccountId);
            Assert.IsNotEmpty(getDeploymentScript.Outputs);

            // List at resource group level and validate
            var listAtResourceGroupResult = await DeploymentScriptsOperations.ListByResourceGroupAsync(ResourceGroupName).ToEnumerableAsync();
            Assert.IsNotEmpty(listAtResourceGroupResult);
            Assert.NotNull(listAtResourceGroupResult.FirstOrDefault(p => p.Name.Equals(deploymentScriptName)));
            Assert.AreEqual(deploymentScript.AzPowerShellVersion,
                (listAtResourceGroupResult.First() as AzurePowerShellScript).AzPowerShellVersion);
            Assert.NotNull((listAtResourceGroupResult.First() as AzurePowerShellScript).ProvisioningState);

            // List at subscription level and validate
            var listAtSubscriptionResult = await DeploymentScriptsOperations.ListBySubscriptionAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(listAtSubscriptionResult);
            Assert.NotNull(listAtSubscriptionResult.FirstOrDefault(p => p.Name.Equals(deploymentScriptName)));
            Assert.AreEqual(AzurePowerShellVersion,
                (listAtSubscriptionResult.First() as AzurePowerShellScript).AzPowerShellVersion);
            Assert.NotNull((listAtSubscriptionResult.First() as AzurePowerShellScript).ProvisioningState);

            // Delete deployments script and validate
            await DeploymentScriptsOperations.DeleteAsync(ResourceGroupName, deploymentScriptName);
            var list = await DeploymentScriptsOperations.ListByResourceGroupAsync(ResourceGroupName).ToEnumerableAsync();
            Assert.IsEmpty(list.Where(p => p.Name.Equals(deploymentScriptName)));
            list = await DeploymentScriptsOperations.ListBySubscriptionAsync().ToEnumerableAsync();
            Assert.IsEmpty(list.Where(p => p.Name.Equals(deploymentScriptName)));
        }

        [Test]
        public async Task CanGetDeploymentScriptExecutionLogs()
        {
            // create user assigned managed identity during test run since we'll be using dynamic properties, such as subscriptionId from the test
            var managedIdentity = new ManagedServiceIdentity()
            {
                Type = "UserAssigned",
                UserAssignedIdentities =
                {
                    {
                        $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/filiz-user-assigned-msi",
                        new UserAssignedIdentity()
                    }
                }
            };

            // Create deployment script object with minimal properties
            var deploymentScriptName = GetCallingMethodName() + "--" + Recording.GenerateAssetName("csmd");

            var deploymentScript = new AzurePowerShellScript(managedIdentity, LocationWestUs, RetentionInterval, AzurePowerShellVersion)
            {
                ScriptContent = ScriptContent,
                Arguments = ScriptArguments
            };

            var rawcreateDeploymentScriptResult = await DeploymentScriptsOperations.StartCreateAsync(ResourceGroupName, deploymentScriptName, deploymentScript);
            var createDeploymentScriptResult = (await WaitForCompletionAsync(rawcreateDeploymentScriptResult)).Value as AzurePowerShellScript;

            Assert.NotNull(createDeploymentScriptResult);
            Assert.AreEqual(ScriptProvisioningState.Succeeded, createDeploymentScriptResult.ProvisioningState);

            AzurePowerShellScript getDeploymentScript = (await DeploymentScriptsOperations.GetAsync(ResourceGroupName, deploymentScriptName)).Value as AzurePowerShellScript;
            Assert.NotNull(getDeploymentScript);

            // Validate getlogs result
            var getLogsResult = DeploymentScriptsOperations.GetLogsDefaultAsync(ResourceGroupName, deploymentScriptName);
            Assert.NotNull(getLogsResult);

            // Delete deployments script
            await DeploymentScriptsOperations.DeleteAsync(ResourceGroupName, deploymentScriptName);
            var list = await DeploymentScriptsOperations.ListByResourceGroupAsync(ResourceGroupName).ToEnumerableAsync();
            Assert.IsEmpty(list.Where(p => p.Name.Equals(deploymentScriptName)));
        }

        [Test]
        public async Task CanReturnErrorOnScriptExecutionFailure()
        {
            // create user assigned managed identity during test run since we'll be using dynamic properties, such as subscriptionId from the test
            var managedIdentity = new ManagedServiceIdentity()
            {
                Type = "UserAssigned",
                UserAssignedIdentities = {
                    {
                        $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/filiz-user-assigned-msi",
                        new UserAssignedIdentity()
                    }
                }
            };

            // Create deployment script object with minimal properties
            var deploymentScriptName = GetCallingMethodName() + "--" + Recording.GenerateAssetName("csmd");
            var deploymentScript = new AzurePowerShellScript(managedIdentity, LocationWestUs, RetentionInterval, AzurePowerShellVersion)
            {
                ScriptContent = MalformedScriptContent
            };

            var rawcreateDeploymentScriptResult = await DeploymentScriptsOperations.StartCreateAsync(ResourceGroupName, deploymentScriptName, deploymentScript);
            var createDeploymentScriptResult = (await DeploymentScriptsOperations.GetAsync(ResourceGroupName, deploymentScriptName)).Value as AzurePowerShellScript;

            Assert.NotNull(createDeploymentScriptResult);
            if (this.IsAsync)
            {
                Assert.AreEqual(ScriptProvisioningState.Creating.ToString(), createDeploymentScriptResult.ProvisioningState.Value.ToString());
            }
            else
            {
                Assert.AreEqual(ScriptProvisioningState.ProvisioningResources.ToString(), createDeploymentScriptResult.ProvisioningState.Value.ToString());
            }

            AzurePowerShellScript getDeploymentScript;

            // wait until the deployment script fails
            var MaxPoll = 20;
            var pollCount = 0;

            do
            {
                Assert.True(pollCount < MaxPoll);

                getDeploymentScript =
                   (await DeploymentScriptsOperations.GetAsync(ResourceGroupName, deploymentScriptName)).Value as AzurePowerShellScript;

                if (Mode == RecordedTestMode.Record) Thread.Sleep(10*1000);

                pollCount++;
            } while (getDeploymentScript.ProvisioningState != ScriptProvisioningState.Failed);

            // Validate result
            Assert.NotNull(getDeploymentScript);
            Assert.NotNull(getDeploymentScript.Status.Error);
            Assert.AreEqual(typeof(ErrorResponse), getDeploymentScript.Status.Error.GetType());

            // Delete deployment script
            await DeploymentScriptsOperations.DeleteAsync(ResourceGroupName, deploymentScriptName);
            var list = await DeploymentScriptsOperations.ListByResourceGroupAsync(ResourceGroupName).ToEnumerableAsync();
            Assert.IsEmpty(list.Where(p => p.Name.Equals(deploymentScriptName)));
        }

        private string GetCallingMethodName([System.Runtime.CompilerServices.CallerMemberName] string memberName = "") => memberName ;
    }
}
