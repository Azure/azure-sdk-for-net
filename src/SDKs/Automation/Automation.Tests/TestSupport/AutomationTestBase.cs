// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Automation.Tests.Helpers;
using Microsoft.Azure.Management.Automation;
using Microsoft.Azure.Management.Automation.Models;
using Microsoft.Azure.Management.Automation.Testing;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using HttpStatusCode = System.Net.HttpStatusCode;

//using Microsoft.Azure.Test;

namespace Automation.Tests.TestSupport
{
    public class AutomationTestBase : TestBase, IDisposable
    {
        private const string ResourceGroup = "SDKTestResourceGroup";
        private const string AutomationAccount = "SDKTestAccount";
        private const string Location = "East Us";

        public AutomationTestBase(MockContext context)
        {
            var handler = new RecordedDelegatingHandler();
            AutomationClient = ResourceGroupHelper.GetAutomationClient(context, handler);
            var resourcesClient = ResourceGroupHelper.GetResourcesClient(context, handler);

            try
            {
                resourcesClient.ResourceGroups.CreateOrUpdate(ResourceGroup,
                    new ResourceGroup
                    {
                        Location = Location
                    });

                AutomationClient.AutomationAccount.CreateOrUpdate(
                    ResourceGroup, AutomationAccount, new AutomationAccountCreateOrUpdateParameters
                    {
                        Name = AutomationAccount,
                        Location = Location,
                        Sku = new Sku {Name = "Free", Family = "Test", Capacity = 1}
                    });
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode != HttpStatusCode.Conflict) throw;
            }

            // Clean up the automation account, delete runbooks, schedules, variables, etc.
            CleanUpCredentials();
            CleanUpRunbooks();
            CleanUpSchedules();
            CleanUpVariables();
            CleanUpWebhooks();
        }

        public AutomationClient AutomationClient { get; private set; }

        public void CleanUpCredentials()
        {
            var credentials = AutomationClient.Credential.ListByAutomationAccount(ResourceGroup, AutomationAccount);

            foreach (var cr in credentials)
            {
                DeleteCredential(cr.Name);
            }
        }

        public void CleanUpRunbooks()
        {
            var runbooks = AutomationClient.Runbook.ListByAutomationAccount(ResourceGroup, AutomationAccount);

            foreach (var rb in runbooks)
            {
                DeleteRunbook(rb.Name);
            }
        }

        public void CleanUpSchedules()
        {
            var schedules = AutomationClient.Schedule.ListByAutomationAccount(ResourceGroup, AutomationAccount);

            foreach (var schedule in schedules)
            {
                DeleteSchedule(schedule.Name);
            }
        }

        public void CleanUpVariables()
        {
            var variables = AutomationClient.Variable.ListByAutomationAccount(ResourceGroup, AutomationAccount);

            foreach (var variable in variables)
            {
                DeleteVariable(variable.Name);
            }
        }

        public void CleanUpWebhooks()
        {
            var webhooks =
                AutomationClient.Webhook.ListByAutomationAccount(ResourceGroup, AutomationAccount);

            foreach (var webhook in webhooks)
            {
                DeleteWebhook(webhook.Name);
            }
        }

        public Credential CreateCredential(string credentialName, string userName, string password,
            string description = null)
        {
            var credential = AutomationClient.Credential.CreateOrUpdate(ResourceGroup, AutomationAccount,
                credentialName,
                new CredentialCreateOrUpdateParameters(credentialName,
                    userName,
                    password,
                    description));
            return credential;
        }

        public Webhook CreateWebhook(string webhookName, string runbookName, string uri, string description = null)
        {
            var webhook = AutomationClient.Webhook.CreateOrUpdate(ResourceGroup, AutomationAccount, webhookName,
                new WebhookCreateOrUpdateParameters
                {
                    Name = webhookName,
                    Runbook = new RunbookAssociationProperty {Name = runbookName},
                    Uri = uri,
                    IsEnabled = true,
                    ExpiryTime = DateTime.Now.AddYears(1)
                });
            return webhook;
        }

        public string GenerateUriForWebhook()
        {
            return AutomationClient.Webhook.GenerateUri(ResourceGroup, AutomationAccount);
        }

        public void CreateRunbook(string runbookName, string runbookContent, string description = null)
        {
            AutomationClient.Runbook.CreateOrUpdate(ResourceGroup, AutomationAccount, runbookName,
                new RunbookCreateOrUpdateParameters(runbookContent));
        }

        public Schedule CreateHourlySchedule(string scheduleName, DateTimeOffset startTime,
            DateTimeOffset expiryTime, string description = null, byte hourInterval = 1)
        {
            var schedule = AutomationClient.Schedule.CreateOrUpdate(ResourceGroup, AutomationAccount, scheduleName,
                new ScheduleCreateOrUpdateParameters
                {
                    Name = scheduleName,
                    StartTime = startTime.DateTime,
                    ExpiryTime = expiryTime.DateTime,
                    Description = description,
                    Interval = hourInterval,
                    Frequency = ScheduleFrequency.Hour
                });
            return schedule;
        }

        public Variable CreateVariable(string variableName, object value, string description = null)
        {
            var variable = AutomationClient.Variable.CreateOrUpdate(ResourceGroup, AutomationAccount, variableName,
                new VariableCreateOrUpdateParameters
                {
                    Name = variableName,
                    Value = JsonConvert.SerializeObject(value),
                    Description = description,
                    IsEncrypted = false
                });
            return variable;
        }

        public void DeleteCredential(string credentialName)
        {
            AutomationClient.Credential.Delete(ResourceGroup, AutomationAccount, credentialName);
        }

        public void DeleteRunbook(string runbookName)
        {
            AutomationClient.Runbook.Delete(ResourceGroup, AutomationAccount, runbookName);
        }

        public void DeleteSchedule(string scheduleName)
        {
            AutomationClient.Schedule.Delete(ResourceGroup, AutomationAccount, scheduleName);
        }

        public void DeleteVariable(string variableName)
        {
            AutomationClient.Variable.Delete(ResourceGroup, AutomationAccount, variableName);
        }

        public void DeleteWebhook(string webhookName)
        {
            AutomationClient.Webhook.Delete(ResourceGroup, AutomationAccount, webhookName);
        }

        public Credential GetCredential(string credentialName)
        {
            var credential = AutomationClient.Credential.Get(ResourceGroup, AutomationAccount, credentialName);
            return credential;
        }

        public IPage<Credential> GetCredentials()
        {
            IPage<Credential> credentials = AutomationClient.Credential.ListByAutomationAccount(ResourceGroup, AutomationAccount);
            return credentials;
        }

        public IPage<JobStream> GetJobStreams(Guid jobId, string streamType, DateTime startTime)
        {
            var jobStreams = AutomationClient.JobStream.ListByJob(ResourceGroup, AutomationAccount, jobId.ToString());
//            , new JobStreamListParameters 
//                {
//                    Time = string.Format(CultureInfo.InvariantCulture, "{0:O}", startTime.ToUniversalTime()),
//                    StreamType = streamType
//                });
//           
            return jobStreams;
        }

        public Runbook GetRunbook(string runbookName)
        {
            var runbook = AutomationClient.Runbook.Get(ResourceGroup, AutomationAccount, runbookName);
            return runbook;
        }

        public Stream GetRunbookContent(string runbookName)
        {
            var runbookContentStream = AutomationClient.RunbookDraft.GetContent(ResourceGroup, AutomationAccount, runbookName);
            return runbookContentStream;
        }

        public Schedule GetSchedule(string scheduleName)
        {
            var schedule = AutomationClient.Schedule.Get(ResourceGroup, AutomationAccount, scheduleName);
            return schedule;
        }

        public Variable GetVariable(string variableName)
        {
            var variable = AutomationClient.Variable.Get(ResourceGroup, AutomationAccount, variableName);
            return variable;
        }

        public IPage<Variable> GetVariables()
        {
            var variables = AutomationClient.Variable.ListByAutomationAccount(ResourceGroup, AutomationAccount);
            return variables;
        }

        public Webhook GetWebhook(string webhookName)
        {
            var webhook= AutomationClient.Webhook.Get(ResourceGroup, AutomationAccount, webhookName);
            return webhook;
        }

        public IPage<Webhook> GetWebhooks(string runbookName = null)
        {
            var webhooks = AutomationClient.Webhook.ListByAutomationAccount(ResourceGroup, AutomationAccount, runbookName);
            return webhooks;
        }
        public void PublishRunbook(string runbookName)
        {
            AutomationClient.RunbookDraft.BeginPublish(ResourceGroup, AutomationAccount, runbookName);
        }

        public Job StartRunbook(string runbookName, IDictionary<string, string> parameters = null)
        {
            var job = AutomationClient.Job.Create(ResourceGroup, AutomationAccount, Guid.NewGuid(), new JobCreateParameters
                {
                    Name = runbookName,
                    Parameters = parameters
                });
            return job;
        }

        public void UpdateCredential(Credential credential, string password = null)
        {
            AutomationClient.Credential.Update(ResourceGroup, AutomationAccount, credential.Name, 
                new CredentialUpdateParameters
            {
                Name = credential.Name,
                UserName = credential.UserName,
                Password = password,
                Description = credential.Description
            });
        }

        public void UpdateRunbook(Runbook runbook)
        {
            AutomationClient.Runbook.Update(ResourceGroup, AutomationAccount, runbook.Name, new RunbookUpdateParameters
            {
                Name = runbook.Name,
                Description = runbook.Description,
                LogProgress = runbook.LogProgress,
                LogVerbose = runbook.LogVerbose
            });

        }

        public void UpdateRunbookContent(string runbookName, string runbookContent)
        {
            var byteArray = Encoding.ASCII.GetBytes(runbookContent);
            AutomationClient.RunbookDraft.BeginCreateOrUpdate(ResourceGroup, AutomationAccount, runbookName, new MemoryStream(byteArray));
        }

        public void UpdateSchedule(Schedule schedule)
        {
            AutomationClient.Schedule.Update(ResourceGroup, AutomationAccount, schedule.Name, new ScheduleUpdateParameters
            {
                Name = schedule.Name,
                IsEnabled = schedule.IsEnabled,
                Description = schedule.Description
            });
        }

        public void UpdateVariable(Variable variable)
        {
            AutomationClient.Variable.Update(ResourceGroup, AutomationAccount, 
                variable.Name, new VariableUpdateParameters
            {
                Name = variable.Name,
                Description = variable.Description
            });
        }

        public void UpdateWebhook(Webhook webhook)
        {
            AutomationClient.Webhook.Update(ResourceGroup, AutomationAccount, webhook.Name, new WebhookUpdateParameters
            {
                Name = webhook.Name,
                IsEnabled = webhook.IsEnabled
            });
        }

        public Job WaitForJobCompletion(Guid jobId, string expectedState = "Completed", int numRetries = 50)
        {
            var job = AutomationClient.Job.Get(ResourceGroup, AutomationAccount, jobId);
            var endStates = new[] { "Stopped", "Suspended", "Failed", "Completed" };
            var retry = 0;
            while (job.Status != expectedState && retry < numRetries && !Array.Exists(endStates, s => s == job.Status))
            {
                TestUtilities.Wait(6000);
                job = AutomationClient.Job.Get(ResourceGroup, AutomationAccount, jobId);
                retry++;
            }

            return job;
        }

        public void Dispose()
        {
            AutomationClient.Dispose();
        }
    }
}
