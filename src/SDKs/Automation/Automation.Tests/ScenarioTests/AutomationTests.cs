
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Automation.Tests.TestSupport;
using Microsoft.Azure.Management.Automation.Models;
using Microsoft.Rest.Azure;
//using Microsoft.Azure.Test;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.Management.Automation.Testing
{
    public class AutomationTest 
    {
        [Fact]
        public void CanCreateUpdateDeleteRunbook()
        {
            //using (var undoContext = UndoContext.Current)
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                //undoContext.Start();
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
                    Assert.Equal(runbook.LogProgress, true);
                    Assert.Equal(runbook.LogVerbose, false);
                    Assert.Equal(runbook.Description, updatedRunbook.Description);

                    var runbookContentV2 = RunbookDefinition.TestFasterWorkflow_V2.PsScript;
                    testFixture.UpdateRunbookContent(runbookName, runbookContentV2);

                    var updatedContent = testFixture.GetRunbookContent(runbookName);
                    Assert.Equal(runbookContentV2, updatedContent.ToString());

                    testFixture.DeleteRunbook(runbookName);

                    Assert.Throws<CloudException>(() =>
                    {
                        runbook = testFixture.GetRunbook(runbookName);
                    });
                }
            }
        }

        [Fact]
        public void CanCreateUpdateDeleteSchedule()
        {
            //using (var undoContext = UndoContext.Current)
            //{
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                //undoContext.Start();

                using (var _testFixture = new AutomationTestBase(context))
                {
                    var scheduleName = TestUtilities.GenerateName("hourlySche");
                    var startTime = DateTimeOffset.Now.AddMinutes(30);
                    var expiryTime = startTime.AddDays(5);

                    var schedule = _testFixture.CreateHourlySchedule(scheduleName, startTime, expiryTime);
                    Assert.NotNull(schedule);

                    schedule = _testFixture.GetSchedule(schedule.Name);
                    Assert.NotNull(schedule);
                    Assert.Equal((byte)1, schedule.Interval);
                    Assert.Equal(ScheduleFrequency.Hour.ToString(), schedule.Frequency);

                    schedule.IsEnabled = false;
                    schedule.Description = "hourly schedule";
                    _testFixture.UpdateSchedule(schedule);
                    var updatedSchedule = _testFixture.GetSchedule(schedule.Name);
                    Assert.False(updatedSchedule.IsEnabled);
                    Assert.Equal(schedule.Description, updatedSchedule.Description);

                    _testFixture.DeleteSchedule(schedule.Name);

                    Assert.Throws<CloudException>(() =>
                    {
                        schedule = _testFixture.GetSchedule(schedule.Name);
                    });
                }
            }
        }

        [Fact]
        public void CanCreateUpdateDeleteVariable()
        {
            //using (var undoContext = UndoContext.Current)
            //{
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                //undoContext.Start();

                using (AutomationTestBase _testFixture = new AutomationTestBase(context))
                {
                    var variableName = TestUtilities.GenerateName("variable");
                    var value = 10;

                    var variable = _testFixture.CreateVariable(variableName, value);
                    Assert.NotNull(variable);

                    variable = _testFixture.GetVariable(variable.Name);
                    Assert.NotNull(variable);
                    Assert.Equal(value, Convert.ToInt32(JsonConvert.DeserializeObject<object>(variable.Value)));

                    value = 20;
                    variable.Value = JsonConvert.SerializeObject(value);
                    variable.Description = "int typed variable";
                    _testFixture.UpdateVariable(variable);
                    var variables = _testFixture.GetVariables();
                    Assert.Equal(1, variables.ToList().Count);
                    var updatedVariable = variables.ToList()[0];
                    Assert.Equal(value, Convert.ToInt32(JsonConvert.DeserializeObject<object>(updatedVariable.Value)));
                    Assert.Equal(variable.Description, updatedVariable.Description);

                    _testFixture.DeleteVariable(variable.Name);

                    Assert.Throws<CloudException>(() =>
                    {
                        variable = _testFixture.GetVariable(variable.Name);
                    });
                }
            }
        }

        [Fact]
        public void CanCreateUpdateDeleteWebhook()
        {
            //using (var undoContext = UndoContext.Current)
            //{
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                //undoContext.Start();

                using (AutomationTestBase _testFixture = new AutomationTestBase(context))
                {
                    var webhookName = TestUtilities.GenerateName("webhook");
                    var runbookName = RunbookDefinition.TestFasterWorkflow.RunbookName;
                    var runbookContent = RunbookDefinition.TestFasterWorkflow.PsScript;

                    _testFixture.CreateRunbook(runbookName, runbookContent);
                    _testFixture.PublishRunbook(runbookName);
                    var runbook = _testFixture.GetRunbook(runbookName);
                    Assert.Equal("Published", runbook.State);

                    var uri = _testFixture.GenerateUriForWebhook();

                    Webhook webhook = _testFixture.CreateWebhook(webhookName, runbookName, uri);
                    Assert.NotNull(webhook);

                    webhook = _testFixture.GetWebhook(webhook.Name);
                    Assert.NotNull(webhook);
                    Assert.Equal(runbookName, webhook.Runbook.Name);

                    webhook.IsEnabled = false;
                    _testFixture.UpdateWebhook(webhook);
                    var webhooks = _testFixture.GetWebhooks();
                    Assert.Equal(1, webhooks.ToList().Count);
                    var updatedWebhook = webhooks.ToList()[0];
                    Assert.False(updatedWebhook.IsEnabled);

                    webhooks = _testFixture.GetWebhooks(runbookName);
                    Assert.Equal(1, webhooks.ToList().Count);
                    updatedWebhook = webhooks.ToList()[0];
                    Assert.False(updatedWebhook.IsEnabled);

                    _testFixture.DeleteWebhook(webhook.Name);
                    _testFixture.DeleteRunbook(runbookName);

                    Assert.Throws<CloudException>(() =>
                    {
                        webhook = _testFixture.GetWebhook(webhook.Name);
                    });
                }
            }
        }

        [Fact]
        public void CanCreateUpdateDeleteCredential()
        {
            //using (var undoContext = UndoContext.Current)
            //{
            //undoContext.Start();
            using (var context = MockContext.Start(this.GetType().FullName))
            {

                using (AutomationTestBase _testFixture = new AutomationTestBase(context))
                {
                    var credentialName = TestUtilities.GenerateName("credential");
                    var userName = "userName1";
                    var password = "pwd1";

                    Credential credential = _testFixture.CreateCredential(credentialName, userName, password);
                    Assert.NotNull(credential);

                    credential = _testFixture.GetCredential(credential.Name);
                    Assert.NotNull(credential);
                    Assert.Equal(userName, credential.UserName);

                    userName = "userName2";
                    password = "pwd2";
                    credential.Name = userName;
                    credential.Description = "description of credential";
                    _testFixture.UpdateCredential(credential, password);
                    var credentials = _testFixture.GetCredentials();
                    Assert.Equal(1, credentials.ToList().Count);
                    var updatedCredential = credentials.ToList()[0];
                    Assert.Equal(credential.UserName, updatedCredential.UserName);
                    Assert.Equal(credential.Description, updatedCredential.Description);

                    _testFixture.DeleteCredential(credential.Name);

                    Assert.Throws<CloudException>(() =>
                    {
                        credential = _testFixture.GetCredential(credential.Name);
                    });
                }
            }
        }
    }
}


