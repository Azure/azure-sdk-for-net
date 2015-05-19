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
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.WindowsAzure.Management.Automation;
using Microsoft.WindowsAzure.Management.Automation.Models;
using Microsoft.Azure.Test;
using Newtonsoft.Json;

namespace Microsoft.WindowsAzure.Management.Automation.Testing
{
    public class AutomationTestBase : TestBase, IDisposable
    {
        private const string automationAccount = "TestAutomationAccount";

        public AutomationTestBase()
        {
            AutomationClient = GetServiceClient<AutomationManagementClient>();

            // Clean up the automation account, delete runbooks, schedules, variables, etc.
            this.CleanUpCredentials();
            this.CleanUpRunbooks();
            this.CleanUpSchedules();
            this.CleanUpVariables();
        }

        public AutomationManagementClient AutomationClient { get; private set; }

        public void CleanUpCredentials()
        {
            IList<Credential> credentials = AutomationClient.PsCredentials.List(automationAccount).Credentials;

            foreach (Credential cr in credentials)
            {
                this.DeleteCredential(cr.Name);
            }
        }

        public void CleanUpRunbooks()
        {
            IList<Runbook> runbooks = AutomationClient.Runbooks.List(automationAccount).Runbooks;

            foreach (Runbook rb in runbooks)
            {
                this.DeleteRunbook(rb.Name);
            }
        }

        public void CleanUpSchedules()
        {
            IList<Schedule> schedules = this.AutomationClient.Schedules.List(
                        automationAccount).Schedules;

            foreach (Schedule schedule in schedules)
            {
                this.DeleteSchedule(schedule.Name);
            }
        }

        public void CleanUpVariables()
        {
            IList<Variable> variables = this.AutomationClient.Variables.List(
                        automationAccount).Variables;

            foreach (Variable variable in variables)
            {
                this.DeleteVariable(variable.Name);
            }
        }

        public Credential CreateCredential(string credentialName, string userName, string password, string description = null)
        {
            var response = AutomationClient.PsCredentials.Create(automationAccount, new CredentialCreateParameters
            {
                Name = credentialName,
                Properties = new CredentialCreateProperties
                {
                    UserName = userName,
                    Password = password,
                    Description = description
                }
            });
            return response.Credential;
        }

        public void CreateRunbook(string runbookName, string runbookContent, string description = null)
        {
            AutomationClient.Runbooks.CreateWithDraft(automationAccount, new RunbookCreateDraftParameters 
            {
                Name = runbookName,
                Properties = new RunbookCreateDraftProperties 
                {
                    Description = description,
                    RunbookType = RunbookTypeEnum.Script,
                    Draft = new RunbookDraft()
                }
            });

            this.UpdateRunbookContent(runbookName, runbookContent);
        }

        public Schedule CreateHourlySchedule(string scheduleName, DateTimeOffset startTime, 
            DateTimeOffset expiryTime, string description = null, byte hourInterval = 1)
        {
            var response = AutomationClient.Schedules.Create(automationAccount,  new ScheduleCreateParameters
            {
                Name = scheduleName,
                Properties = new ScheduleCreateProperties
                {
                    StartTime = startTime.ToUniversalTime(),
                    ExpiryTime = expiryTime.ToUniversalTime(),
                    Description = description,
                    Interval = hourInterval,
                    Frequency = ScheduleFrequency.Hour.ToString()
                }
            });
            return response.Schedule;
        }

        public Variable CreateVariable(string variableName, object value, string description = null)
        {
            var response = AutomationClient.Variables.Create(automationAccount, new VariableCreateParameters
            {
                Name = variableName,
                Properties = new VariableCreateProperties
                {
                    Value = JsonConvert.SerializeObject(value),
                    Description = description
                }
            });
            return response.Variable;
        }

        public void DeleteCredential(string credentialName)
        {
            AutomationClient.PsCredentials.Delete(automationAccount, credentialName);
        }

        public void DeleteRunbook(string runbookName)
        {
            AutomationClient.Runbooks.Delete(automationAccount, runbookName);
        }

        public void DeleteSchedule(string scheduleName)
        {
            AutomationClient.Schedules.Delete(automationAccount, scheduleName);
        }

        public void DeleteVariable(string variableName)
        {
            AutomationClient.Variables.Delete(automationAccount, variableName);
        }

        public Credential GetCredential(string credentialName)
        {
            var response = AutomationClient.PsCredentials.Get(automationAccount, credentialName);
            return response.Credential;
        }

        public IList<Credential> GetCredentials()
        {
            var response = AutomationClient.PsCredentials.List(automationAccount);
            return response.Credentials;
        }

        public IList<JobStream> GetJobStreams(Guid jobId, string streamType, DateTime startTime)
        {
            var response = AutomationClient.JobStreams.List(automationAccount, jobId, new JobStreamListParameters 
                {
                    Time = string.Format(CultureInfo.InvariantCulture, "{0:O}", startTime.ToUniversalTime()),
                    StreamType = streamType
                });
           
            return response.JobStreams;
        }

        public Runbook GetRunbook(string runbookName)
        {
            var response = AutomationClient.Runbooks.Get(automationAccount, runbookName);
            return response.Runbook;
        }

        public string GetRunbookContent(string runbookName)
        {
            var response = AutomationClient.RunbookDraft.Content(automationAccount, runbookName);
            return response.Stream;
        }

        public Schedule GetSchedule(string scheduleName)
        {
            var response = AutomationClient.Schedules.Get(automationAccount, scheduleName);
            return response.Schedule;
        }

        public Variable GetVariable(string variableName)
        {
            var response = AutomationClient.Variables.Get(automationAccount, variableName);
            return response.Variable;
        }

        public IList<Variable> GetVariables()
        {
            var response = AutomationClient.Variables.List(automationAccount);
            return response.Variables;
        }

        public void PublishRunbook(string runbookName)
        {
            var response = AutomationClient.RunbookDraft.BeginPublish(automationAccount, new RunbookDraftPublishParameters
                {
                    Name = runbookName,
                    PublishedBy = "SDK_Tests"
                });
        }

        public Job StartRunbook(string runbookName, IDictionary<string, string> parameters = null)
        {
            var response = AutomationClient.Jobs.Create(automationAccount, new JobCreateParameters
                {
                    Properties = new JobCreateProperties 
                        {
                            Runbook = new RunbookAssociationProperty
                            {
                                Name = runbookName
                            },
                            Parameters = parameters
                        }
                });
            return response.Job;
        }

        public void UpdateCredential(Credential credential, string password = null)
        {
            AutomationClient.PsCredentials.Update(automationAccount, new CredentialUpdateParameters
            {
                Name = credential.Name,
                Properties = new CredentialUpdateProperties
                {
                    UserName = credential.Properties.UserName,
                    Password = password,
                    Description = credential.Properties.Description
                }
            });
        }

        public void UpdateRunbook(Runbook runbook)
        {
            AutomationClient.Runbooks.Update(automationAccount, new RunbookUpdateParameters
            {
                Name = runbook.Name,
                Properties = new RunbookUpdateProperties
                {
                    Description = runbook.Properties.Description,
                    LogProgress = runbook.Properties.LogProgress,
                    LogVerbose = runbook.Properties.LogVerbose
                }
            });

        }

        public void UpdateRunbookContent(string runbookName, string runbookContent)
        {
            AutomationClient.RunbookDraft.BeginUpdate(automationAccount, new RunbookDraftUpdateParameters 
            { 
                Name = runbookName,
                Stream = runbookContent
            });
        }

        public void UpdateSchedule(Schedule schedule)
        {
            AutomationClient.Schedules.Update(automationAccount, new  ScheduleUpdateParameters
            {
                Name = schedule.Name,
                Properties = new ScheduleUpdateProperties
                {
                    IsEnabled = schedule.Properties.IsEnabled,
                    Description = schedule.Properties.Description
                }
            });
        }

        public void UpdateVariable(Variable variable)
        {
            AutomationClient.Variables.Update(automationAccount, new VariableUpdateParameters
            {
                Name = variable.Name,
                Properties = new VariableUpdateProperties
                {
                    Value = variable.Properties.Value,
                    Description = variable.Properties.Description
                }
            });
        }

        public Job WaitForJobCompletion(Guid jobId, string expectedState = "Completed", int numRetries = 50)
        {
            var response = AutomationClient.Jobs.Get(automationAccount, jobId);
            string[] endStates = new string[4] { "Stopped", "Suspended", "Failed", "Completed" };
            var job = response.Job;
            var retry = 0;
            while (job.Properties.Status != expectedState && retry < numRetries && !Array.Exists(endStates, s => s == job.Properties.Status))
            {
                TestUtilities.Wait(6000);
                job = AutomationClient.Jobs.Get(automationAccount, jobId).Job;
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
