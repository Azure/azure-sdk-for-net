// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Automation.Tests.ScenarioTests
{
    using System;
    using System.IO;
    using System.Linq;
    using Automation.Tests.Helpers;
    using Automation.Tests.TestSupport;
    using Microsoft.Azure.Management.Automation.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json;
    using Xunit;
    using System.Threading;

    public class AutomationTest 
    {
        [Fact]
        public void CanCreateUpdateDeleteRunbook()
        {
            using (var context = MockContext.Start(GetType().FullName))
            {
                using (var testFixture = new AutomationTestBase(context))
                {
                    var runbookName = RunbookDefinition.TestFasterWorkflow.RunbookName;
                    var runbookContent = RunbookDefinition.TestFasterWorkflow.PsScript;

                    testFixture.CreateRunbook(runbookName, runbookContent);
                    var runbook = testFixture.GetRunbook(runbookName);
                    Assert.NotNull(runbook);

                    testFixture.PublishRunbook(runbook.Name);
                    runbook = testFixture.GetRunbook(runbookName);
                    Assert.Equal("Published", runbook.State);

                    const string description = "description of runbook";
                    runbook.LogProgress = true;
                    runbook.Description = description;

                    testFixture.UpdateRunbook(runbook);
                    var updatedRunbook = testFixture.GetRunbook(runbookName);
                    Assert.True(runbook.LogProgress);
                    Assert.False(runbook.LogVerbose);
                    Assert.Equal(runbook.Description, updatedRunbook.Description);

                    var runbookContentV2 = RunbookDefinition.TestFasterWorkflowV2.PsScript;
                    testFixture.UpdateRunbookContent(runbookName, runbookContentV2);

                    var updatedContent = testFixture.GetRunbookContent(runbookName);
                    Assert.Equal(runbookContentV2, updatedContent);

                    testFixture.DeleteRunbook(runbookName);

                    Assert.Throws<ErrorResponseException>(() =>
                    {
                        runbook = testFixture.GetRunbook(runbookName);
                    });
                }
            }
        }

        [Fact]
        public void CanCreateUpdateDeleteSchedule()
        {
            using (var context = MockContext.Start(GetType().FullName))
            {
                using (var testFixture = new AutomationTestBase(context))
                {
                    var scheduleName = TestUtilities.GenerateName("hourlySche");
                    var startTime = DateTimeOffset.Now.AddDays(1);
                    var expiryTime = startTime.AddDays(5);

                    var schedule = testFixture.CreateHourlySchedule(scheduleName, startTime, expiryTime);
                    Assert.NotNull(schedule);

                    schedule = testFixture.GetSchedule(schedule.Name);
                    Assert.NotNull(schedule);

                    Assert.Equal(1, (int)(long)schedule.Interval);
                    Assert.Equal(ScheduleFrequency.Hour, schedule.Frequency);

                    schedule.IsEnabled = false;
                    schedule.Description = "hourly schedule";
                    testFixture.UpdateSchedule(schedule);
                    var updatedSchedule = testFixture.GetSchedule(schedule.Name);
                    Assert.False(updatedSchedule.IsEnabled);
                    Assert.Equal(schedule.Description, updatedSchedule.Description);

                    testFixture.DeleteSchedule(schedule.Name);

                    Assert.Throws<ErrorResponseException>(() =>
                    {
                        schedule = testFixture.GetSchedule(schedule.Name);
                    });
                }
            }
        }

        [Fact]
        public void CanCreateUpdateDeleteVariable()
        {
            using (var context = MockContext.Start(GetType().FullName))
            {
                using (var testFixture = new AutomationTestBase(context))
                {
                    var variableName = TestUtilities.GenerateName("variable");
                    var value = 10;

                    var variable = testFixture.CreateVariable(variableName, value);
                    Assert.NotNull(variable);

                    variable = testFixture.GetVariable(variable.Name);
                    Assert.NotNull(variable);
                    Assert.Equal(value, Convert.ToInt32(JsonConvert.DeserializeObject<object>(variable.Value)));

                    value = 20;
                    variable.Value = JsonConvert.SerializeObject(value);
                    variable.Description = "int typed variable";

                    testFixture.UpdateVariable(variable);
                    var variables = testFixture.GetVariables();
                    Assert.Single(variables.ToList());
                    var updatedVariable = variables.ToList()[0];
                    Assert.Equal(value, Convert.ToInt32(JsonConvert.DeserializeObject<object>(updatedVariable.Value)));
                    Assert.Equal(variable.Description, updatedVariable.Description);

                    testFixture.DeleteVariable(variable.Name);

                    Assert.Throws<ErrorResponseException>(() =>
                    {
                        variable = testFixture.GetVariable(variable.Name);
                    });
                }
            }
        }

        [Fact]
        public void CanCreateUpdateDeleteWebhook()
        {
            using (var context = MockContext.Start(GetType().FullName))
            {
                using (var testFixture = new AutomationTestBase(context))
                {
                    var webhookName = TestUtilities.GenerateName("webhook");
                    var runbookName = RunbookDefinition.TestFasterWorkflow.RunbookName;
                    var runbookContent = RunbookDefinition.TestFasterWorkflow.PsScript;

                    testFixture.CreateRunbook(runbookName, runbookContent);
                    testFixture.PublishRunbook(runbookName);
                    var runbook = testFixture.GetRunbook(runbookName);
                    Assert.Equal("Published", runbook.State);

                    var uri = testFixture.GenerateUriForWebhook();

                    var webhook = testFixture.CreateWebhook(webhookName, runbookName, uri);
                    Assert.NotNull(webhook);

                    webhook = testFixture.GetWebhook(webhook.Name);
                    Assert.NotNull(webhook);
                    Assert.Equal(runbookName, webhook.Runbook.Name);

                    webhook.IsEnabled = false;

                    testFixture.UpdateWebhook(webhook);
                    var webhooks = testFixture.GetWebhooks();

                    Assert.Single(webhooks.ToList());
                    var updatedWebhook = webhooks.ToList()[0];
                    Assert.False(updatedWebhook.IsEnabled);

                    webhooks = testFixture.GetWebhooks(runbookName);

                    Assert.Single(webhooks.ToList());
                    updatedWebhook = webhooks.ToList()[0];
                    Assert.False(updatedWebhook.IsEnabled);

                    testFixture.DeleteWebhook(webhook.Name);
                    testFixture.DeleteRunbook(runbookName);

                    Assert.Throws<ErrorResponseException>(() =>
                    {
                        webhook = testFixture.GetWebhook(webhook.Name);
                    });
                }
            }
        }

        [Fact]
        public void CanCreateUpdateDeleteCredential()
        {
            using (var context = MockContext.Start(GetType().FullName))
            {
                using (var testFixture = new AutomationTestBase(context))
                {
                    var credentialName = TestUtilities.GenerateName("credential");
                    var userName = "userName1";
                    var password = "pwd1";

                    var credential = testFixture.CreateCredential(credentialName, userName, password);
                    Assert.NotNull(credential);

                    credential = testFixture.GetCredential(credential.Name);
                    Assert.NotNull(credential);
                    Assert.Equal(userName, credential.UserName);

                    userName = "userName2";
                    password = "pwd2";

                    credential.Description = "description of credential";
                    testFixture.UpdateCredential(credential, password, userName);
                    var credentials = testFixture.GetCredentials();

                    Assert.Single(credentials.ToList());
                    var updatedCredential = credentials.ToList()[0];
                    Assert.Equal(credential.UserName, updatedCredential.UserName);
                    Assert.Equal(credential.Description, updatedCredential.Description);

                    testFixture.DeleteCredential(credential.Name);

                    Assert.Throws<ErrorResponseException>(() =>
                    {
                        credential = testFixture.GetCredential(credential.Name);
                    });
                }
            }
        }

        [Fact]
        public void CanCreateUpdateDeleteDscConfiguration()
        {
            using (var context = MockContext.Start(GetType().FullName))
            {
                using (var testFixture = new AutomationTestBase(context))
                {
                    var configName = DscConfigurationDefinition.TestSimpleConfigurationDefinition.ConfigurationName;
                    var configContent = DscConfigurationDefinition.TestSimpleConfigurationDefinition.PsScript;
                    var description = DscConfigurationDefinition.TestSimpleConfigurationDefinition.Description;
                    var contentHashValue = DscConfigurationDefinition.TestSimpleConfigurationDefinition.ContentHashValue;
                    var contentHashAlgorithm = DscConfigurationDefinition.TestSimpleConfigurationDefinition.ContentHashAlgorithm;
                    var contentType = DscConfigurationDefinition.TestSimpleConfigurationDefinition.ContentType;

                    const string updatedDescription = "new sample configuration test";

                    var configuration = testFixture.CreateDscConfiguration(configName, configContent,
                        description, contentHashValue, contentHashAlgorithm, contentType);

                    var config = testFixture.GetDscConfiguration(configName);
                    Assert.NotNull(config);
                    Assert.Equal(config.Name, configuration.Name);
                    Assert.Equal(config.Description, configuration.Description);

                    config.Description = updatedDescription;
                    testFixture.UpdateDscConfiguration(config, configContent,
                        description, contentHashValue, contentHashAlgorithm, contentType);

                    var dscConfigurations = testFixture.GetDscConfigurations();
                    Assert.NotNull(dscConfigurations);
                    Assert.Single(dscConfigurations.ToList());
                    configuration = dscConfigurations.ToList()[0];
                    Assert.Equal(configName, configuration.Name);
                    
                    testFixture.DeleteDscConfiguration(configName);

                    Assert.Throws<ErrorResponseException>(() =>
                    {
                        config = testFixture.GetDscConfiguration(configName);
                    });
                }
            }
        }

        [Fact]
        public void CanCreateUpdateDeleteDscNodeConfiguration()
        {
            using (var context = MockContext.Start(GetType().FullName))
            {
                using (var testFixture = new AutomationTestBase(context))
                {

                    var configName = DscNodeConfigurationDefinition.TestSimpleConfigurationDefinition.ConfigurationName;
                    var nodeConfigName = DscNodeConfigurationDefinition.TestSimpleConfigurationDefinition.NodeConfigurationName;
                    var nodeConfigurationContent = DscNodeConfigurationDefinition.TestSimpleConfigurationDefinition.NodeConfigurationContent;
                    var nodeConfigContentHashValue = DscNodeConfigurationDefinition.TestSimpleConfigurationDefinition.ContentHashValue;
                    var nodeConfigContentHashAlgorithm = DscNodeConfigurationDefinition.TestSimpleConfigurationDefinition.ContentHashAlgorithm;
                    var nodeConfigContentType = DscNodeConfigurationDefinition.TestSimpleConfigurationDefinition.ContentType;
                    var nodeConfigContentVersion = 
                        DscNodeConfigurationDefinition.TestSimpleConfigurationDefinition.ContentVersion;
                    const string updatedConfigurationVersion = "2.0";

                    var configContent = DscConfigurationDefinition.TestSimpleConfigurationDefinition.PsScript;
                    var description = DscConfigurationDefinition.TestSimpleConfigurationDefinition.Description;
                    var contentHashValue = DscConfigurationDefinition.TestSimpleConfigurationDefinition.ContentHashValue;
                    var contentHashAlgorithm = DscConfigurationDefinition.TestSimpleConfigurationDefinition.ContentHashAlgorithm;
                    var contentType = DscConfigurationDefinition.TestSimpleConfigurationDefinition.ContentType;

                    testFixture.CreateDscConfiguration(configName, configContent,
                        description, contentHashValue, contentHashAlgorithm, contentType);

                    var nodeConfiguration = testFixture.CreateDscNodeConfiguration(nodeConfigName, configName,
                        nodeConfigurationContent, nodeConfigContentHashValue, nodeConfigContentHashAlgorithm, 
                        nodeConfigContentType, nodeConfigContentVersion);

                    var nodeConfig = testFixture.GetDscNodeConfiguration(nodeConfigName);
                    Assert.NotNull(nodeConfig);
                    Assert.Equal(nodeConfig.Name, nodeConfiguration.Name);

                    testFixture.UpdateDscNodeConfiguration(nodeConfig, nodeConfigurationContent, 
                        nodeConfigContentHashValue, nodeConfigContentHashAlgorithm, nodeConfigContentType,
                        updatedConfigurationVersion);

                    var dscConfigurations = testFixture.GetDscNodeConfigurations();
                    Assert.NotNull(dscConfigurations);
                    Assert.Single(dscConfigurations.ToList());
                    nodeConfiguration = dscConfigurations.ToList()[0];
                    Assert.Equal(nodeConfigName, nodeConfiguration.Name);

                    testFixture.DeleteDscNodeConfiguration(nodeConfigName);

                    Assert.Throws<ErrorResponseException>(() =>
                    {
                        nodeConfig = testFixture.GetDscNodeConfiguration(nodeConfigName);
                    });
                }
            }
        }

        [Fact]
        public void CanCreateUpdateDeleteAutomationModules()
        {
            using (var context = MockContext.Start(GetType().FullName))
            {
                using (var testFixture = new AutomationTestBase(context))
                {

                    var moduleName = "HelloAndSum";
                    // Content links don't have to be valid for playback. However, these are the actual module download locations used for recording.
                    var contentLink1 = "https://bhbrahmaprodtestingseau.blob.core.windows.net/module1/HelloAndSum.zip";
                    var contentLink2 = "https://bhbrahmaprodtestingseau.blob.core.windows.net/module2/HelloAndSum.zip";

                    testFixture.DeleteModule(moduleName, true);

                    var module = testFixture.CreateAutomationModule(moduleName, contentLink1);

                    Assert.NotNull(module);                    
                    Assert.Equal(ModuleProvisioningState.Creating, module.ProvisioningState);
                    EnsureModuleReachesSuccessProvisioningState(moduleName, testFixture, out module);
                    Assert.Equal(moduleName, module.Name);
                    Assert.Equal("1.0", module.Version);

                    // Update the module
                    module = testFixture.CreateAutomationModule(moduleName, contentLink2);
                    Assert.NotNull(module);
                    Assert.Equal(ModuleProvisioningState.Creating, module.ProvisioningState);
                    EnsureModuleReachesSuccessProvisioningState(moduleName, testFixture, out module);
                    Assert.Equal(moduleName, module.Name);
                    Assert.Equal("2.0", module.Version);

                    // Delete the module
                    bool deleteCompleted = false;
                    testFixture.DeleteModule(moduleName);
                    try
                    {
                        testFixture.GetAutomationModule(moduleName);
                    }
                    catch (ErrorResponseException)
                    {
                        // Exception expected
                        deleteCompleted = true;
                    }
                    Assert.True(deleteCompleted);
                }
            }
        }

        private void EnsureModuleReachesSuccessProvisioningState(string moduleName, AutomationTestBase testFixture, out Module module)
        {
            // Wait for the module Provisioing state to reach Succeeded
            var startTime = DateTime.Now;
            var endTime = startTime.AddMinutes(5);
            bool provisioningSucceeded = false;
            do
            {
                Thread.Sleep(50); // Used 5 seconds polling delay in the record mode, using 50 ms in playback for test to complete fast
                module = testFixture.GetAutomationModule(moduleName);
                if (module.ProvisioningState == ModuleProvisioningState.Succeeded)
                {
                    provisioningSucceeded = true;
                    break;
                }
            } while (DateTime.Now < endTime);
            Assert.True(provisioningSucceeded);
        }

    }
}


