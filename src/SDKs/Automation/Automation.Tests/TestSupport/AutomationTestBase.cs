// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Automation.Tests.Helpers;
using Microsoft.Azure.Management.Automation;
using Microsoft.Azure.Management.Automation.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using HttpStatusCode = System.Net.HttpStatusCode;

namespace Automation.Tests.TestSupport
{
    public class AutomationTestBase : TestBase, IDisposable
    {
        private const string ResourceGroup = "automation-sdk-test";
        private const string AutomationAccount = "automation-sdk-test-account";
        private const string Location = "East US 2";

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

                AutomationClient.AutomationAccount.CreateOrUpdate(ResourceGroup, AutomationAccount, 
                    new AutomationAccountCreateOrUpdateParameters
                    {
                        Name = AutomationAccount,
                        Location = Location,
                        Sku = new Sku {Name = "Free", Family = "Test", Capacity = 1}
                    });

                AutomationClient.ResourceGroupName = ResourceGroup;
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

        public void CleanUpRunbooks()
        {
            var runbooks = AutomationClient.Runbook.ListByAutomationAccount(AutomationAccount);

            foreach (var rb in runbooks)
            {
                DeleteRunbook(rb.Name);
            }
        }

        public void CleanUpSchedules()
        {
            var schedules = AutomationClient.Schedule.ListByAutomationAccount(AutomationAccount);

            foreach (var schedule in schedules)
            {
                DeleteSchedule(schedule.Name);
            }
        }

        public void CleanUpVariables()
        {
            var variables = AutomationClient.Variable.ListByAutomationAccount(AutomationAccount);

            foreach (var variable in variables)
            {
                DeleteVariable(variable.Name);
            }
        }

        public void CleanUpWebhooks()
        {
            var webhooks =
                AutomationClient.Webhook.ListByAutomationAccount(AutomationAccount);

            foreach (var webhook in webhooks)
            {
                DeleteWebhook(webhook.Name);
            }
        }

        public Credential CreateCredential(string credentialName, string userName, string password,
            string description = null)
        {
            var credential = AutomationClient.Credential.CreateOrUpdate(AutomationAccount,
            credentialName,
                new CredentialCreateOrUpdateParameters(credentialName,
                    userName,
                    password,
                    description));
            return credential;
        }

        public Webhook CreateWebhook(string webhookName, string runbookName, string uri, string description = null)
        {
            var webhook = AutomationClient.Webhook.CreateOrUpdate(AutomationAccount, webhookName,
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
            return AutomationClient.Webhook.GenerateUri(AutomationAccount);
        }

        public void CreateRunbook(string runbookName, string runbookContent, string description = null)
        {
            AutomationClient.Runbook.CreateOrUpdate(AutomationAccount, runbookName,
                new RunbookCreateOrUpdateParameters
                {
                    Name = runbookName,
                    Description = description,
                    Location = Location,
                    RunbookType = RunbookTypeEnum.PowerShellWorkflow,
                    Draft = new RunbookDraft()
                });

            UpdateRunbookContent(runbookName, runbookContent);
        }

        public Schedule CreateHourlySchedule(string scheduleName, DateTimeOffset startTime,
            DateTimeOffset expiryTime, string description = null, byte hourInterval = 1)
        {
            var schedule = AutomationClient.Schedule.CreateOrUpdate(AutomationAccount, scheduleName,
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


        #region Module Methods
        public Module CreateAutomationModule(string moduleName, string contentLink)
        {
            var module = AutomationClient.Module.CreateOrUpdate(AutomationAccount, moduleName,
                new ModuleCreateOrUpdateParameters
                {
                    Name = moduleName,
                    ContentLink = new ContentLink(contentLink),
                    Location = Location,
                    Tags = new Dictionary<string, string>()
                });
            return module;
        }

        public Module GetAutomationModule(string moduleName)
        {
            var module = AutomationClient.Module.Get(AutomationAccount, moduleName);
            return module;
        }

        public void DeleteModule(string moduleName, bool ignoreErrors = false)
        {
            try
            {
                AutomationClient.Module.Delete(AutomationAccount, moduleName);
            }
            catch (ErrorResponseException)
            {
                if (!ignoreErrors)
                {
                    throw;
                }
            }
        }

        #endregion


        #region Runbooks methods

        public Job WaitForJobCompletion(Guid jobId, string expectedState = "Completed", int numRetries = 50)
        {
            var job = AutomationClient.Job.Get(AutomationAccount, jobId);
            var endStates = new[] {"Stopped", "Suspended", "Failed", "Completed"};
            var retry = 0;
            while (job.Status != expectedState && retry < numRetries && !Array.Exists(endStates, s => s == job.Status))
            {
                TestUtilities.Wait(6000);
                job = AutomationClient.Job.Get(AutomationAccount, jobId);
                retry++;
            }

            return job;
        }

        public void UpdateRunbook(Runbook runbook)
        {
            AutomationClient.Runbook.Update(AutomationAccount, runbook.Name, new RunbookUpdateParameters
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
            AutomationClient.RunbookDraft.BeginCreateOrUpdate(AutomationAccount, runbookName,
                new MemoryStream(byteArray));
        }

        public void PublishRunbook(string runbookName)
        {
            AutomationClient.RunbookDraft.BeginPublish(AutomationAccount, runbookName);
        }

        public Job StartRunbook(string runbookName, IDictionary<string, string> parameters = null)
        {
            var job = AutomationClient.Job.Create(AutomationAccount, Guid.NewGuid(),
                new JobCreateParameters
                {
                    Name = runbookName,
                    Parameters = parameters
                });
            return job;
        }

        public IPage<JobStream> GetJobStreams(Guid jobId, string streamType, DateTime startTime)
        {
            var jobStreams = AutomationClient.JobStream.ListByJob(ResourceGroup, AutomationAccount, jobId.ToString());
            return jobStreams;
        }

        public Runbook GetRunbook(string runbookName)
        {
            var runbook = AutomationClient.Runbook.Get(AutomationAccount, runbookName);
            return runbook;
        }

        public Stream GetRunbookContent(string runbookName)
        {
            var runbookContentStream =
                AutomationClient.RunbookDraft.GetContent(AutomationAccount, runbookName);
            return runbookContentStream;
        }

        public void DeleteRunbook(string runbookName)
        {
            AutomationClient.Runbook.Delete(AutomationAccount, runbookName);
        }

        #endregion

        #region Variables methods

        public void UpdateVariable(Variable variable)
        {
            AutomationClient.Variable.Update(AutomationAccount,
                variable.Name, new VariableUpdateParameters
                {
                    Value = variable.Value,
                    Name = variable.Name,
                    Description = variable.Description
                });
        }

        public void DeleteVariable(string variableName)
        {
            AutomationClient.Variable.Delete(AutomationAccount, variableName);
        }

        #endregion

        #region Schedules methods

        public void UpdateSchedule(Schedule schedule)
        {
            AutomationClient.Schedule.Update(AutomationAccount, schedule.Name,
                new ScheduleUpdateParameters
                {
                    Name = schedule.Name,
                    IsEnabled = schedule.IsEnabled,
                    Description = schedule.Description
                });
        }

        public Schedule GetSchedule(string scheduleName)
        {
            var schedule = AutomationClient.Schedule.Get(AutomationAccount, scheduleName);
            return schedule;
        }

        public void DeleteSchedule(string scheduleName)
        {
            AutomationClient.Schedule.Delete(AutomationAccount, scheduleName);
        }

        #endregion

        #region Credentials methods

        public Credential GetCredential(string credentialName)
        {
            return AutomationClient.Credential.Get(AutomationAccount, credentialName);
        }

        public IPage<Credential> GetCredentials()
        {
            IPage<Credential> credentials =
                AutomationClient.Credential.ListByAutomationAccount(AutomationAccount);
            return credentials;
        }

        public void UpdateCredential(Credential credential, string password = null, string userName = null)
        {
            AutomationClient.Credential.Update(AutomationAccount, credential.Name,
                new CredentialUpdateParameters
                {
                    Name = userName,
                    UserName = credential.UserName,
                    Password = password,
                    Description = credential.Description
                });
        }

        public void CleanUpCredentials()
        {
            var credentials = AutomationClient.Credential.ListByAutomationAccount(AutomationAccount);

            foreach (var cr in credentials)
            {
                DeleteCredential(cr.Name);
            }
        }

        public Variable CreateVariable(string variableName, object value, string description = null)
        {
            var variable = AutomationClient.Variable.CreateOrUpdate(AutomationAccount, variableName,
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
            AutomationClient.Credential.Delete(AutomationAccount, credentialName);
        }

        #endregion

        #region Webhook methods

        public Variable GetVariable(string variableName)
        {
            var variable = AutomationClient.Variable.Get(AutomationAccount, variableName);
            return variable;
        }

        public IPage<Variable> GetVariables()
        {
            var variables = AutomationClient.Variable.ListByAutomationAccount(AutomationAccount);
            return variables;
        }

        public void DeleteWebhook(string webhookName)
        {
            AutomationClient.Webhook.Delete(AutomationAccount, webhookName);
        }

        public void UpdateWebhook(Webhook webhook)
        {
            AutomationClient.Webhook.Update(AutomationAccount, webhook.Name, new WebhookUpdateParameters
            {
                Name = webhook.Name,
                IsEnabled = webhook.IsEnabled
            });
        }

        public IPage<Webhook> GetWebhooks(string runbookName = null)
        {
            var odataFilter = new List<string>();
            string filter = null;
            if (runbookName != null)
            {
                odataFilter.Add("properties/runbook/name eq '" + Uri.EscapeDataString(runbookName) + "'");
            }
            if (odataFilter.Count > 0)
            {
                filter = string.Join(null, odataFilter);
            }
            var webhooks = AutomationClient.Webhook.ListByAutomationAccount(AutomationAccount, filter);
            return webhooks;
        }

        public Webhook GetWebhook(string webhookName)
        {
            var webhook = AutomationClient.Webhook.Get(AutomationAccount, webhookName);
            return webhook;
        }

        #endregion

        #region DSC Configuration methods

        public DscConfiguration CreateDscConfiguration(string configName, string configContent,
            string description = null, string contentHashValue = null,
            string contentHashAlgorithm = "sha256", string contentType = null)
        {
            return AutomationClient.DscConfiguration.CreateOrUpdate(AutomationAccount, configName,
                new DscConfigurationCreateOrUpdateParameters
                {
                    Location = Location,
                    Description = description,
                    Source = new ContentSource
                    {
                        Value = configContent,
                        Type = contentType,
                        Hash = new ContentHash
                        {
                            Value = contentHashValue,
                            Algorithm = contentHashAlgorithm
                        }
                    }
                }
            );
        }

        public DscConfiguration GetDscConfiguration(string configName)
        {
            return AutomationClient.DscConfiguration.Get(AutomationAccount, configName);
        }

        public IPage<DscConfiguration> GetDscConfigurations()
        {
            var dscConfigurations =
                AutomationClient.DscConfiguration.ListByAutomationAccount(AutomationAccount);
            return dscConfigurations;
        }

        public void DeleteDscConfiguration(string configName)
        {
            AutomationClient.DscConfiguration.Delete(AutomationAccount, configName);
        }

        public void UpdateDscConfiguration(DscConfiguration configuration, string configContent,
            string description = null, string contentHashValue = null,
            string contentHashAlgorithm = "sha256", string contentType = null)
        {
            AutomationClient.DscConfiguration.CreateOrUpdate(AutomationAccount, configuration.Name,
                new DscConfigurationCreateOrUpdateParameters
                {
                    Description = configuration.Description,
                    Source = new ContentSource
                    {
                        Value = configContent,
                        Type = contentType,
                        Hash = new ContentHash
                        {
                            Value = contentHashValue,
                            Algorithm = contentHashAlgorithm
                        }
                    },
                    Location = configuration.Location,
                    Name = configuration.Name
                });
        }

        #endregion

        #region Dsc Node Configuration Methods

        public DscNodeConfiguration CreateDscNodeConfiguration(string nodeConfigurationName, string configurationName,
            string nodeConfigurationContent, string contentHashValue, string contentHashAlgorithm, string contentType,
            string contentVersion)
        {
            return AutomationClient.DscNodeConfiguration.CreateOrUpdate(AutomationAccount,
                nodeConfigurationName, new DscNodeConfigurationCreateOrUpdateParameters
                {
                    Name = nodeConfigurationName,
                    Configuration = new DscConfigurationAssociationProperty(configurationName),
                    Source = new ContentSource
                    {
                        Value = nodeConfigurationContent,
                        Version = contentVersion,
                        Hash = new ContentHash
                        {
                            Value = contentHashValue,
                            Algorithm = contentHashAlgorithm
                        },
                        Type = contentType
                    }
                });
        }

        public DscNodeConfiguration GetDscNodeConfiguration(string nodeConfigName)
        {
            return AutomationClient.DscNodeConfiguration.Get(AutomationAccount, nodeConfigName);
        }

        public void UpdateDscNodeConfiguration(DscNodeConfiguration nodeConfig, string configContent,
            string contentHashValue, string contentHashAlgorithm, string contentType, string contentVersion)
        {
            AutomationClient.DscNodeConfiguration.CreateOrUpdate(AutomationAccount,
                nodeConfig.Name, new DscNodeConfigurationCreateOrUpdateParameters
                {
                    Name = nodeConfig.Name,
                    Configuration = new DscConfigurationAssociationProperty(nodeConfig.Configuration.Name),
                    Source = new ContentSource
                    {
                        Value = configContent,
                        Version = contentVersion,
                        Hash = new ContentHash
                        {
                            Value = contentHashValue,
                            Algorithm = contentHashAlgorithm
                        },
                        Type = contentType
                    }
                });
        }

        public void DeleteDscNodeConfiguration(string configName)
        {
            AutomationClient.DscNodeConfiguration.Delete(AutomationAccount, configName);
        }

        public IPage<DscNodeConfiguration> GetDscNodeConfigurations()
        {
            return AutomationClient.DscNodeConfiguration.ListByAutomationAccount(AutomationAccount);
        }

        #endregion

        #region Common Methods

        public void Dispose()
        {
            AutomationClient.Dispose();
        }

        #endregion
    }
}