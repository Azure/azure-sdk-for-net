
//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using Hyak.Common;
using Microsoft.Azure.Management.Automation.Models;
using Microsoft.Azure.Test;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.Management.Automation.Testing
{
    public class AutomationTest 
    {
        [Fact]
        public void CanCreateUpdateDeleteRunbook()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                using (AutomationTestBase _testFixture = new AutomationTestBase())
                {
                    string runbookName = RunbookDefinition.TestFasterWorkflow.RunbookName;
                    string runbookContent = RunbookDefinition.TestFasterWorkflow.PsScript;

                    _testFixture.CreateRunbook(runbookName, runbookContent);
                    var runbook = _testFixture.GetRunbook(runbookName);
                    Assert.NotNull(runbook);

                    _testFixture.PublishRunbook(runbook.Name);
                    runbook = _testFixture.GetRunbook(runbookName);
                    Assert.Equal("Published", runbook.Properties.State);

                    var description = "description of runbook";
                    runbook.Properties.LogProgress = true;
                    runbook.Properties.Description = description;

                    _testFixture.UpdateRunbook(runbook);
                    var updatedRunbook = _testFixture.GetRunbook(runbookName);
                    Assert.Equal(runbook.Properties.LogProgress, true);
                    Assert.Equal(runbook.Properties.LogVerbose, false);
                    Assert.Equal(runbook.Properties.Description, updatedRunbook.Properties.Description);

                    string runbookContentV2 = RunbookDefinition.TestFasterWorkflow_V2.PsScript;
                    _testFixture.UpdateRunbookContent(runbookName, runbookContentV2);

                    string updatedContent = _testFixture.GetRunbookContent(runbookName);
                    Assert.Equal(runbookContentV2, updatedContent);

                    _testFixture.DeleteRunbook(runbookName);

                    Assert.Throws<CloudException>(() =>
                    {
                        runbook = _testFixture.GetRunbook(runbookName);
                    });
                }
            }
        }

        [Fact]
        public void CanCreateUpdateDeleteSchedule()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                using (AutomationTestBase _testFixture = new AutomationTestBase())
                {
                    var scheduleName = TestUtilities.GenerateName("hourlySche");
                    var startTime = DateTimeOffset.Now.AddMinutes(30);
                    var expiryTime = startTime.AddDays(5);

                    Schedule schedule = _testFixture.CreateHourlySchedule(scheduleName, startTime, expiryTime);
                    Assert.NotNull(schedule);

                    schedule = _testFixture.GetSchedule(schedule.Name);
                    Assert.NotNull(schedule);
                    Assert.Equal((byte)1, schedule.Properties.Interval);
                    Assert.Equal(ScheduleFrequency.Hour.ToString(), schedule.Properties.Frequency);

                    schedule.Properties.IsEnabled = false;
                    schedule.Properties.Description = "hourly schedule";
                    _testFixture.UpdateSchedule(schedule);
                    var updatedSchedule = _testFixture.GetSchedule(schedule.Name);
                    Assert.False(updatedSchedule.Properties.IsEnabled);
                    Assert.Equal(schedule.Properties.Description, updatedSchedule.Properties.Description);

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
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                using (AutomationTestBase _testFixture = new AutomationTestBase())
                {
                    var variableName = TestUtilities.GenerateName("variable");
                    var value = 10;

                    Variable variable = _testFixture.CreateVariable(variableName, value);
                    Assert.NotNull(variable);

                    variable = _testFixture.GetVariable(variable.Name);
                    Assert.NotNull(variable);
                    Assert.Equal(value, Convert.ToInt32(JsonConvert.DeserializeObject<object>(variable.Properties.Value)));

                    value = 20;
                    variable.Properties.Value = JsonConvert.SerializeObject(value);
                    variable.Properties.Description = "int typed variable";
                    _testFixture.UpdateVariable(variable);
                    var variables = _testFixture.GetVariables();
                    Assert.Equal(1, variables.Count);
                    var updatedVariable = variables[0];
                    Assert.Equal(value, Convert.ToInt32(JsonConvert.DeserializeObject<object>(updatedVariable.Properties.Value)));
                    Assert.Equal(variable.Properties.Description, updatedVariable.Properties.Description);

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
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                using (AutomationTestBase _testFixture = new AutomationTestBase())
                {
                    var webhookName = TestUtilities.GenerateName("webhook");
                    var runbookName = RunbookDefinition.TestFasterWorkflow.RunbookName;
                    var runbookContent = RunbookDefinition.TestFasterWorkflow.PsScript;

                    _testFixture.CreateRunbook(runbookName, runbookContent);
                    _testFixture.PublishRunbook(runbookName);
                    var runbook = _testFixture.GetRunbook(runbookName);
                    Assert.Equal("Published", runbook.Properties.State);

                    var uri = _testFixture.GenerateUriForWebhook();

                    Webhook webhook = _testFixture.CreateWebhook(webhookName, runbookName, uri);
                    Assert.NotNull(webhook);

                    webhook = _testFixture.GetWebhook(webhook.Name);
                    Assert.NotNull(webhook);
                    Assert.Equal(runbookName, webhook.Properties.Runbook.Name);

                    webhook.Properties.IsEnabled = false;
                    _testFixture.UpdateWebhook(webhook);
                    var webhooks = _testFixture.GetWebhooks();
                    Assert.Equal(1, webhooks.Count);
                    var updatedWebhook = webhooks[0];
                    Assert.False(updatedWebhook.Properties.IsEnabled);

                    webhooks = _testFixture.GetWebhooks(runbookName);
                    Assert.Equal(1, webhooks.Count);
                    updatedWebhook = webhooks[0];
                    Assert.False(updatedWebhook.Properties.IsEnabled);

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
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                using (AutomationTestBase _testFixture = new AutomationTestBase())
                {
                    var credentialName = TestUtilities.GenerateName("credential");
                    var userName = "userName1";
                    var password = "pwd1";

                    Credential credential = _testFixture.CreateCredential(credentialName, userName, password);
                    Assert.NotNull(credential);

                    credential = _testFixture.GetCredential(credential.Name);
                    Assert.NotNull(credential);
                    Assert.Equal(userName, credential.Properties.UserName);

                    userName = "userName2";
                    password = "pwd2";
                    credential.Properties.UserName = userName;
                    credential.Properties.Description = "description of credential";
                    _testFixture.UpdateCredential(credential, password);
                    var credentials = _testFixture.GetCredentials();
                    Assert.Equal(1, credentials.Count);
                    var updatedCredential = credentials[0];
                    Assert.Equal(credential.Properties.UserName, updatedCredential.Properties.UserName);
                    Assert.Equal(credential.Properties.Description, updatedCredential.Properties.Description);

                    _testFixture.DeleteCredential(credential.Name);

                    Assert.Throws<CloudException>(() =>
                    {
                        credential = _testFixture.GetCredential(credential.Name);
                    });
                }
            }
        }

        [Fact]
        public void CanGetUsage()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                using (AutomationTestBase _testFixture = new AutomationTestBase())
                {
                    var usage = _testFixture.GetUsages();
                    Assert.Equal(2, usage.Count);

                    Assert.Equal(0, usage[0].CurrentValue);
                    Assert.Equal("AccountUsage", usage[0].Name.Value);
                    Assert.Equal(-1, usage[0].Limit);
                }
            }
        }

    }
}


