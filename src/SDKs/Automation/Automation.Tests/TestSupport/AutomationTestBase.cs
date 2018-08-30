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
                        Sku = new Sku { Name = "Free", Family = "Test", Capacity = 1 }
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
                    Runbook = new RunbookAssociationProperty { Name = runbookName },
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

        public void CreatePSScriptRunbook(string runbookName, string runbookContent, string description = null)
        {
            AutomationClient.Runbook.CreateOrUpdate(ResourceGroup, AutomationAccount, runbookName,
                new RunbookCreateOrUpdateParameters
                {
                    Name = runbookName,
                    Description = description,
                    Location = Location,
                    RunbookType = RunbookTypeEnum.PowerShell,
                    Draft = new RunbookDraft()
                });

            UpdateRunbookContent(runbookName, runbookContent);
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


        #region Module Methods
        public Module CreateAutomationModule(string moduleName, string contentLink)
        {
            var module = AutomationClient.Module.CreateOrUpdate(ResourceGroup, AutomationAccount, moduleName,
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
            var module = AutomationClient.Module.Get(ResourceGroup, AutomationAccount, moduleName);
            return module;
        }

        public void DeleteModule(string moduleName, bool ignoreErrors = false)
        {
            try
            {
                AutomationClient.Module.Delete(ResourceGroup, AutomationAccount, moduleName);
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
            var job = AutomationClient.Job.Get(ResourceGroup, AutomationAccount, jobId.ToString());
            var endStates = new[] { "Stopped", "Suspended", "Failed", "Completed" };
            var retry = 0;
            while (job.Status != expectedState && retry < numRetries && !Array.Exists(endStates, s => s == job.Status))
            {
                TestUtilities.Wait(6000);
                job = AutomationClient.Job.Get(ResourceGroup, AutomationAccount, jobId.ToString());
                retry++;
            }

            return job;
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
            AutomationClient.RunbookDraft.ReplaceContent(ResourceGroup, AutomationAccount, runbookName, new MemoryStream(byteArray));
        }

        public void PublishRunbook(string runbookName)
        {
            AutomationClient.RunbookDraft.BeginPublish(ResourceGroup, AutomationAccount, runbookName);
        }

        public Job StartRunbook(string runbookName, IDictionary<string, string> parameters = null)
        {
            var job = AutomationClient.Job.Create(ResourceGroup, AutomationAccount, Guid.NewGuid().ToString(),
                new JobCreateParameters
                {
                    Runbook = new RunbookAssociationProperty { Name = runbookName },
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
            var runbook = AutomationClient.Runbook.Get(ResourceGroup, AutomationAccount, runbookName);
            return runbook;
        }

        public Stream GetRunbookContent(string runbookName)
        {
            var runbookContentStream =
                AutomationClient.RunbookDraft.GetContent(ResourceGroup, AutomationAccount, runbookName);
            return runbookContentStream;
        }

        public void DeleteRunbook(string runbookName)
        {
            AutomationClient.Runbook.Delete(ResourceGroup, AutomationAccount, runbookName);
        }

        #endregion

        #region Variables methods

        public void UpdateVariable(Variable variable)
        {
            AutomationClient.Variable.Update(ResourceGroup, AutomationAccount,
                variable.Name, new VariableUpdateParameters
                {
                    Value = variable.Value,
                    Name = variable.Name,
                    Description = variable.Description
                });
        }

        public void DeleteVariable(string variableName)
        {
            AutomationClient.Variable.Delete(ResourceGroup, AutomationAccount, variableName);
        }

        #endregion

        #region Schedules methods

        public void UpdateSchedule(Schedule schedule)
        {
            AutomationClient.Schedule.Update(ResourceGroup, AutomationAccount, schedule.Name,
                new ScheduleUpdateParameters
                {
                    Name = schedule.Name,
                    IsEnabled = schedule.IsEnabled,
                    Description = schedule.Description
                });
        }

        public Schedule GetSchedule(string scheduleName)
        {
            var schedule = AutomationClient.Schedule.Get(ResourceGroup, AutomationAccount, scheduleName);
            return schedule;
        }

        public void DeleteSchedule(string scheduleName)
        {
            AutomationClient.Schedule.Delete(ResourceGroup, AutomationAccount, scheduleName);
        }

        #endregion

        #region Credentials methods

        public Credential GetCredential(string credentialName)
        {
            return AutomationClient.Credential.Get(ResourceGroup, AutomationAccount, credentialName);
        }

        public IPage<Credential> GetCredentials()
        {
            IPage<Credential> credentials =
                AutomationClient.Credential.ListByAutomationAccount(ResourceGroup, AutomationAccount);
            return credentials;
        }

        public void UpdateCredential(Credential credential, string password = null, string userName = null)
        {
            AutomationClient.Credential.Update(ResourceGroup, AutomationAccount, credential.Name,
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
            var credentials = AutomationClient.Credential.ListByAutomationAccount(ResourceGroup, AutomationAccount);

            foreach (var cr in credentials)
            {
                DeleteCredential(cr.Name);
            }
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

        #endregion

        #region Webhook methods

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

        public void DeleteWebhook(string webhookName)
        {
            AutomationClient.Webhook.Delete(ResourceGroup, AutomationAccount, webhookName);
        }

        public void UpdateWebhook(Webhook webhook)
        {
            AutomationClient.Webhook.Update(ResourceGroup, AutomationAccount, webhook.Name, new WebhookUpdateParameters
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
            var webhooks = AutomationClient.Webhook.ListByAutomationAccount(ResourceGroup, AutomationAccount, filter);
            return webhooks;
        }

        public Webhook GetWebhook(string webhookName)
        {
            var webhook = AutomationClient.Webhook.Get(ResourceGroup, AutomationAccount, webhookName);
            return webhook;
        }

        #endregion

        #region DSC Configuration methods

        public DscConfiguration CreateDscConfiguration(string configName, string configContent,
            string description = null, string contentHashValue = null,
            string contentHashAlgorithm = "sha256", string contentType = null)
        {
            return AutomationClient.DscConfiguration.CreateOrUpdate(ResourceGroup, AutomationAccount, configName,
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
            return AutomationClient.DscConfiguration.Get(ResourceGroup, AutomationAccount, configName);
        }

        public IPage<DscConfiguration> GetDscConfigurations()
        {
            var dscConfigurations =
                AutomationClient.DscConfiguration.ListByAutomationAccount(ResourceGroup, AutomationAccount);
            return dscConfigurations;
        }

        public void DeleteDscConfiguration(string configName)
        {
            AutomationClient.DscConfiguration.Delete(ResourceGroup, AutomationAccount, configName);
        }

        public void UpdateDscConfiguration(DscConfiguration configuration, string configContent,
            string description = null, string contentHashValue = null,
            string contentHashAlgorithm = "sha256", string contentType = null)
        {
            AutomationClient.DscConfiguration.CreateOrUpdate(ResourceGroup, AutomationAccount, configuration.Name,
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
            return AutomationClient.DscNodeConfiguration.CreateOrUpdate(ResourceGroup, AutomationAccount,
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
                }
             );
        }

        public DscNodeConfiguration GetDscNodeConfiguration(string nodeConfigName)
        {
            return AutomationClient.DscNodeConfiguration.Get(ResourceGroup, AutomationAccount, nodeConfigName);
        }

        public void UpdateDscNodeConfiguration(DscNodeConfiguration nodeConfig, string configContent,
            string contentHashValue, string contentHashAlgorithm, string contentType, string contentVersion)
        {
            AutomationClient.DscNodeConfiguration.CreateOrUpdate(ResourceGroup, AutomationAccount,
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
            AutomationClient.DscNodeConfiguration.Delete(ResourceGroup, AutomationAccount, configName);
        }

        public IPage<DscNodeConfiguration> GetDscNodeConfigurations()
        {
            return AutomationClient.DscNodeConfiguration.ListByAutomationAccount(ResourceGroup, AutomationAccount);
        }

        #endregion

        #region SourceControl Methods

        public SourceControl CreateSourceControl(string sourceControlName, string repoUrl, string branch, string folderPath, bool autoSync,
                                                 bool publishRunbook, string sourceControlType, string accessToken, string description)
        {
            var securityTokenProperties = new SourceControlSecurityTokenProperties();
            securityTokenProperties.AccessToken = accessToken;
            securityTokenProperties.TokenType = "PersonalAccessToken";

            var sourceControl = AutomationClient.SourceControl.CreateOrUpdate(ResourceGroup, AutomationAccount, sourceControlName,
                    new SourceControlCreateOrUpdateParameters
                    {
                        RepoUrl = repoUrl,
                        Branch = branch,
                        FolderPath = folderPath,
                        AutoSync = autoSync,
                        PublishRunbook = publishRunbook,
                        SourceType = sourceControlType,
                        SecurityToken = securityTokenProperties,
                        Description = description
                    });
            return sourceControl;
        }

        public SourceControl UpdateSourceControl(string sourceControlName, string branch, bool autoSync)
        {
            var sourceControl = AutomationClient.SourceControl.Update(ResourceGroup, AutomationAccount, sourceControlName,
                    new SourceControlUpdateParameters
                    {
                        Branch = branch,
                        AutoSync = autoSync
                    });
            return sourceControl;
        }

        public SourceControl GetSourceControl(string sourceControlName)
        {
            var sourceControl = AutomationClient.SourceControl.Get(ResourceGroup, AutomationAccount, sourceControlName);
            return sourceControl;
        }

        public IPage<SourceControl> GetSourceControls()
        {
            var sourceControls = AutomationClient.SourceControl.ListByAutomationAccount(ResourceGroup, AutomationAccount);
            return sourceControls;
        }

        public void DeleteSourceControl(string sourceControlName)
        {
            AutomationClient.SourceControl.Delete(ResourceGroup, AutomationAccount, sourceControlName);
        }

        #endregion

        #region SourceControlSyncJob Methods

        public SourceControlSyncJob CreateSourceControlSyncJob(string sourceControlName, Guid sourceControlSyncJobId)
        {
            var sourceControlSyncJob = AutomationClient.SourceControlSyncJob.Create(ResourceGroup, AutomationAccount, sourceControlName, sourceControlSyncJobId,
                    new SourceControlSyncJobCreateParameters(""));

            return sourceControlSyncJob;
        }

        public SourceControlSyncJobById GetSourceControlSyncJob(string sourceControlName, Guid sourceControlSyncJobId)
        {
            var sourceControlSyncJob = AutomationClient.SourceControlSyncJob.Get(ResourceGroup, AutomationAccount,
                                                                                 sourceControlName, sourceControlSyncJobId);
            return sourceControlSyncJob;
        }

        public IPage<SourceControlSyncJob> GetSourceControlSyncJobs(string sourceControlName)
        {
            var sourceControlSyncJobs = AutomationClient.SourceControlSyncJob.ListByAutomationAccount(ResourceGroup, AutomationAccount, sourceControlName);
            return sourceControlSyncJobs;
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