// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace DeploymentScripts.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class LiveDeploymentScriptsTests : TestBase
    {
        private const string LocationWestUs = "West US";
        private const string AzurePowerShellVersion = "2.7.0";
        private static readonly TimeSpan RetentionInterval = new TimeSpan(1, 2, 0, 0, 0);
        private const string ResourceGroupName = "Ds-TestRg";

        private const string ScriptContent =
            "param([string] $helloWorld) Write-Output $helloWorld; $DeploymentScriptOutputs['output'] = $helloWorld";

        private const string MalformedScriptContent =
            "This-will-fail.";

        private const string ScriptArguments = "'Hello World'";

        [Fact]
        public void CanCrudSimpleDeploymentScript()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<DeploymentScriptsClient>();

                // create user assigned managed identity during test run since we'll be using dynamic properties, such as subscriptionId from the test 
                var userAssignedIdentities = new Dictionary<string, UserAssignedIdentity>
                {
                    {
                        $"/subscriptions/{client.SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/filiz-user-assigned-msi",
                        new UserAssignedIdentity()
                    }
                };

                var managedIdentity =
                    new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned, userAssignedIdentities);

                // Create deployment script object with minimal properties
                var deploymentScriptName = TestUtilities.GetCurrentMethodName() + "--" + TestUtilities.GenerateName();

                var deploymentScript = new AzurePowerShellScript(LocationWestUs, RetentionInterval,
                    AzurePowerShellVersion, identity: managedIdentity, scriptContent: ScriptContent, arguments: ScriptArguments);

                var createDeploymentScriptResult =
                    client.DeploymentScripts.Create(ResourceGroupName, deploymentScriptName, deploymentScript) as
                        AzurePowerShellScript;

                Assert.NotNull(createDeploymentScriptResult);
                Assert.Equal(ScriptProvisioningState.Succeeded, createDeploymentScriptResult.ProvisioningState);

                AzurePowerShellScript getDeploymentScript = client.DeploymentScripts.Get(ResourceGroupName, deploymentScriptName) as AzurePowerShellScript;

               // Validate result
                Assert.NotNull(getDeploymentScript);
                Assert.Equal(deploymentScript.Location, getDeploymentScript.Location);
                Assert.Equal(deploymentScript.AzPowerShellVersion, getDeploymentScript.AzPowerShellVersion);
                Assert.Equal(deploymentScript.Identity.Type.ToLower(), getDeploymentScript.Identity.Type.ToLower());
                Assert.NotNull(deploymentScript.Identity.UserAssignedIdentities.Values.FirstOrDefault());
                Assert.Equal(deploymentScript.Identity.UserAssignedIdentities.Keys.FirstOrDefault(),
                    getDeploymentScript.Identity.UserAssignedIdentities.Keys.FirstOrDefault());
                Assert.NotNull(getDeploymentScript.ScriptContent);
                Assert.Equal(deploymentScript.ScriptContent, getDeploymentScript.ScriptContent);
                Assert.NotNull(getDeploymentScript.Arguments);
                Assert.Equal(deploymentScript.Arguments, getDeploymentScript.Arguments);
                Assert.NotNull(deploymentScript.RetentionInterval.ToString());
                Assert.Equal(deploymentScript.RetentionInterval, getDeploymentScript.RetentionInterval);

                // Validate read-only properties 
                Assert.NotNull(getDeploymentScript.Id);
                Assert.NotNull(getDeploymentScript.Name);
                Assert.Equal(deploymentScriptName, getDeploymentScript.Name);
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
                Assert.NotEmpty(getDeploymentScript.Outputs);

                // List at resource group level and validate
                var listAtResourceGroupResult = client.DeploymentScripts.ListByResourceGroup(ResourceGroupName);
                Assert.NotEmpty(listAtResourceGroupResult);
                Assert.NotNull(listAtResourceGroupResult.FirstOrDefault(p => p.Name.Equals(deploymentScriptName)));
                Assert.Equal(deploymentScript.AzPowerShellVersion,
                    (listAtResourceGroupResult.First() as AzurePowerShellScript).AzPowerShellVersion);
                Assert.NotNull((listAtResourceGroupResult.First() as AzurePowerShellScript).ProvisioningState);

                // List at subscription level and validate
                var listAtSubscriptionResult = client.DeploymentScripts.ListBySubscription();
                Assert.NotEmpty(listAtSubscriptionResult);
                Assert.NotNull(listAtSubscriptionResult.FirstOrDefault(p => p.Name.Equals(deploymentScriptName)));
                Assert.Equal(AzurePowerShellVersion,
                    (listAtSubscriptionResult.First() as AzurePowerShellScript).AzPowerShellVersion);
                Assert.NotNull((listAtSubscriptionResult.First() as AzurePowerShellScript).ProvisioningState);

                // Delete deployments script and validate
                client.DeploymentScripts.Delete(ResourceGroupName, deploymentScriptName);
                var list = client.DeploymentScripts.ListByResourceGroup(ResourceGroupName);
                Assert.Empty(list.Where(p => p.Name.Equals(deploymentScriptName)));
                list = client.DeploymentScripts.ListBySubscription();
                Assert.Empty(list.Where(p => p.Name.Equals(deploymentScriptName)));
            }
        }

        [Fact]
        public void CanGetDeploymentScriptExecutionLogs()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<DeploymentScriptsClient>();

                // create user assigned managed identity during test run since we'll be using dynamic properties, such as subscriptionId from the test 
                var userAssignedIdentities = new Dictionary<string, UserAssignedIdentity>
                {
                    {
                        $"/subscriptions/{client.SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/filiz-user-assigned-msi",
                        new UserAssignedIdentity()
                    }
                };

                var managedIdentity =
                    new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned, userAssignedIdentities);

                // Create deployment script object with minimal properties
                var deploymentScriptName = TestUtilities.GetCurrentMethodName() + "--" + TestUtilities.GenerateName();

                var deploymentScript = new AzurePowerShellScript(LocationWestUs, RetentionInterval,
                    AzurePowerShellVersion, identity: managedIdentity, scriptContent: ScriptContent, arguments: ScriptArguments);

                var createDeploymentScriptResult =
                    client.DeploymentScripts.Create(ResourceGroupName, deploymentScriptName, deploymentScript) as
                        AzurePowerShellScript;
                Assert.NotNull(createDeploymentScriptResult);
                Assert.Equal(ScriptProvisioningState.Succeeded, createDeploymentScriptResult.ProvisioningState);

                AzurePowerShellScript getDeploymentScript = client.DeploymentScripts.Get(ResourceGroupName, deploymentScriptName) as AzurePowerShellScript;
                Assert.NotNull(getDeploymentScript);

                // Validate getlogs result
                var getLogsResult = client.DeploymentScripts.GetLogsDefault(ResourceGroupName, deploymentScriptName);
                Assert.NotNull(getLogsResult);

                // Delete deployments script 
                client.DeploymentScripts.Delete(ResourceGroupName, deploymentScriptName);
                var list = client.DeploymentScripts.ListByResourceGroup(ResourceGroupName);
                Assert.Empty(list.Where(p => p.Name.Equals(deploymentScriptName)));
            }
        }

        [Fact]
        public void CanReturnErrorOnScriptExecutionFailure()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var client = context.GetServiceClient<DeploymentScriptsClient>();

                // create user assigned managed identity during test run since we'll be using dynamic properties, such as subscriptionId from the test 
                var userAssignedIdentities = new Dictionary<string, UserAssignedIdentity>
                {
                    {
                        $"/subscriptions/{client.SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/filiz-user-assigned-msi",
                        new UserAssignedIdentity()
                    }
                };

                var managedIdentity =
                    new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned, userAssignedIdentities);

                // Create deployment script object with minimal properties
                var deploymentScriptName = TestUtilities.GetCurrentMethodName() + "--" + TestUtilities.GenerateName();

                var deploymentScript = new AzurePowerShellScript(LocationWestUs, RetentionInterval,
                    AzurePowerShellVersion, identity: managedIdentity, scriptContent: MalformedScriptContent);

                var createDeploymentScriptResult =
                    client.DeploymentScripts.BeginCreate(ResourceGroupName, deploymentScriptName,
                        deploymentScript) as AzurePowerShellScript;

                Assert.NotNull(createDeploymentScriptResult);
                Assert.Equal(ScriptProvisioningState.Creating, createDeploymentScriptResult.ProvisioningState);

                AzurePowerShellScript getDeploymentScript;

                // wait until the deployment script fails
                var MaxPoll = 20;
                var pollCount = 0;

                do
                {
                    Assert.True(pollCount < MaxPoll);

                    getDeploymentScript =
                        client.DeploymentScripts.Get(ResourceGroupName, deploymentScriptName) as AzurePowerShellScript;

                    TestUtilities.Wait(10000);

                    pollCount++;

                } while (getDeploymentScript.ProvisioningState != ScriptProvisioningState.Failed);

                // Validate result
                Assert.NotNull(getDeploymentScript);
                Assert.NotNull(getDeploymentScript.Status.Error);
                Assert.Equal(typeof(ErrorResponse), getDeploymentScript.Status.Error.GetType());

                // Delete deployment script 
                client.DeploymentScripts.Delete(ResourceGroupName, deploymentScriptName);
                var list = client.DeploymentScripts.ListByResourceGroup(ResourceGroupName);
                Assert.Empty(list.Where(p => p.Name.Equals(deploymentScriptName)));
            }
        }
    }
}

