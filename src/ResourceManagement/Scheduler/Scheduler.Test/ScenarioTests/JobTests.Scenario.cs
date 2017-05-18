﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Scheduler;
using Microsoft.Azure.Management.Scheduler.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Scheduler.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;
using SchedulerDayOfWeek = Microsoft.Azure.Management.Scheduler.Models.DayOfWeek;
using Microsoft.Rest.Azure.OData;

namespace Scheduler.Test.ScenarioTests
{
    public class JobTests
    {
        private const string subscriptionId = "623d50f1-4fa8-4e46-a967-a9214aed43ab";
        private const string resourceGroupName = "CS-SouthCentralUS-scheduler";
        private const string type = "Microsoft.Scheduler/jobCollections/jobs";
        private const string location = "South Central US";

        private static DateTime EndTime = new DateTime(2020, 10, 10, 10, 10, 10, DateTimeKind.Utc);

        [Fact]
        public void Scenario_JobCreateWithScheduleForDay()
        {
            using (MockContext context = MockContext.Start("Scheduler.Test.ScenarioTests.JobTests"))
            {
                string jobCollectionName = TestUtilities.GenerateName("jc1");
                string jobName = TestUtilities.GenerateName("j1");
                string jobDefinitionname = string.Format("{0}/{1}", jobCollectionName, jobName);
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}/jobs/{3}", subscriptionId, resourceGroupName, jobCollectionName, jobName);

                var client = context.GetServiceClient<SchedulerManagementClient>();
                this.CreateJobCollection(client, jobCollectionName);

                var result = client.Jobs.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 13),
                            Action = new JobAction()
                            {
                                Type = JobActionType.Http,
                                Request = new HttpRequest()
                                {
                                    Uri = "http://www.bing.com/",
                                    Method = "GET",
                                },
                                RetryPolicy = new RetryPolicy()
                                {
                                    RetryType = RetryType.None,
                                },
                                ErrorAction = new JobErrorAction()
                                {
                                    Type = JobActionType.StorageQueue,
                                    QueueMessage = new StorageQueueMessage()
                                    {
                                        StorageAccount = "schedulersdktest",
                                        QueueName = "queue1",
                                        Message = "some message!",
                                        SasToken = "ThIsiSmYtOkeNdoyOusEe",
                                    }
                                }
                            },
                            Recurrence = new JobRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Day,
                                Count = 100,
                                EndTime = JobTests.EndTime,
                                Schedule = new JobRecurrenceSchedule()
                                {
                                    Hours = new List<int?>() { 5, 10, 15, 20 },
                                    Minutes = new List<int?>() { 0, 10, 20, 30, 40, 50 },
                                }
                            },
                            State = JobState.Enabled,
                        }
                    });

                Assert.Equal(id, result.Id);
                Assert.Equal(type, result.Type);
                Assert.Equal(jobDefinitionname, result.Name);
                Assert.Equal(JobActionType.Http, result.Properties.Action.Type);
                Assert.Equal("http://www.bing.com/", result.Properties.Action.Request.Uri);
                Assert.Equal("GET", result.Properties.Action.Request.Method);
                Assert.Equal(RetryType.None, result.Properties.Action.RetryPolicy.RetryType);
                Assert.Equal(JobActionType.StorageQueue, result.Properties.Action.ErrorAction.Type);
                Assert.Equal("schedulersdktest", result.Properties.Action.ErrorAction.QueueMessage.StorageAccount);
                Assert.Equal("queue1", result.Properties.Action.ErrorAction.QueueMessage.QueueName);
                Assert.Equal("some message!", result.Properties.Action.ErrorAction.QueueMessage.Message);
                Assert.Null(result.Properties.Action.ErrorAction.QueueMessage.SasToken);
                Assert.Equal(JobState.Enabled, result.Properties.State);
                Assert.Equal(RecurrenceFrequency.Day, result.Properties.Recurrence.Frequency);
                Assert.Equal(100, result.Properties.Recurrence.Count);
                Assert.Equal(JobTests.EndTime, result.Properties.Recurrence.EndTime);
                Assert.Equal(new List<int?>() { 5, 10, 15, 20 }, result.Properties.Recurrence.Schedule.Hours);
                Assert.Equal(new List<int?>() { 0, 10, 20, 30, 40, 50 }, result.Properties.Recurrence.Schedule.Minutes);
                Assert.Null(result.Properties.Status.LastExecutionTime);
                Assert.Equal(0, result.Properties.Status.ExecutionCount);
                Assert.Equal(0, result.Properties.Status.FailureCount);
                Assert.Equal(0, result.Properties.Status.FaultedCount);

                var getResult = client.Jobs.Get(resourceGroupName, jobCollectionName, jobName);

                Assert.Equal(id, getResult.Id);
                Assert.Equal(type, getResult.Type);
                Assert.Equal(jobDefinitionname, getResult.Name);
                Assert.Equal(JobActionType.Http, getResult.Properties.Action.Type);
                Assert.Equal("http://www.bing.com/", getResult.Properties.Action.Request.Uri);
                Assert.Equal("GET", getResult.Properties.Action.Request.Method);
                Assert.Equal(RetryType.None, getResult.Properties.Action.RetryPolicy.RetryType);
                Assert.Equal(JobActionType.StorageQueue, getResult.Properties.Action.ErrorAction.Type);
                Assert.Equal("schedulersdktest", getResult.Properties.Action.ErrorAction.QueueMessage.StorageAccount);
                Assert.Equal("queue1", getResult.Properties.Action.ErrorAction.QueueMessage.QueueName);
                Assert.Equal("some message!", getResult.Properties.Action.ErrorAction.QueueMessage.Message);
                Assert.Null(getResult.Properties.Action.ErrorAction.QueueMessage.SasToken);
                Assert.Equal(JobState.Enabled, getResult.Properties.State);
                Assert.Equal(RecurrenceFrequency.Day, getResult.Properties.Recurrence.Frequency);
                Assert.Equal(100, getResult.Properties.Recurrence.Count);
                Assert.Equal(JobTests.EndTime, getResult.Properties.Recurrence.EndTime);
                Assert.Equal(new List<int?>() { 5, 10, 15, 20 }, getResult.Properties.Recurrence.Schedule.Hours);
                Assert.Equal(new List<int?>() { 0, 10, 20, 30, 40, 50 }, getResult.Properties.Recurrence.Schedule.Minutes);
                Assert.Null(getResult.Properties.Status.LastExecutionTime);
                Assert.Equal(0, getResult.Properties.Status.ExecutionCount);
                Assert.Equal(0, getResult.Properties.Status.FailureCount);
                Assert.Equal(0, getResult.Properties.Status.FaultedCount);

                client.JobCollections.Delete(resourceGroupName, jobCollectionName);
            }
        }

        [Fact]
        public void Scenario_JobCreateWithScheduleForWeek()
        {
            using (MockContext context = MockContext.Start("Scheduler.Test.ScenarioTests.JobTests"))
            {
                string jobCollectionName = TestUtilities.GenerateName("jc1");
                string jobName = TestUtilities.GenerateName("j1");
                string jobDefinitionname = string.Format("{0}/{1}", jobCollectionName, jobName);
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}/jobs/{3}", subscriptionId, resourceGroupName, jobCollectionName, jobName);

                var client = context.GetServiceClient<SchedulerManagementClient>();
                this.CreateJobCollection(client, jobCollectionName);

                var result = client.Jobs.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 13),
                            Action = new JobAction()
                            {
                                Type = JobActionType.StorageQueue,
                                QueueMessage = new StorageQueueMessage()
                                {
                                    StorageAccount = "schedulersdktest",
                                    QueueName = "queue1",
                                    Message = "some message!",
                                    SasToken = "ThIsiSmYtOkeNdoyOusEe",
                                },
                                RetryPolicy = new RetryPolicy()
                                {
                                    RetryType = RetryType.Fixed,
                                    RetryCount = 2,
                                    RetryInterval = TimeSpan.FromMinutes(1),
                                },
                            },
                            Recurrence = new JobRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Week,
                                Interval = 1,
                                Count = 10000,
                                EndTime = JobTests.EndTime,
                                Schedule = new JobRecurrenceSchedule()
                                {
                                    WeekDays = new List<SchedulerDayOfWeek?>() { SchedulerDayOfWeek.Monday },
                                    Hours = new List<int?>() { 5, 10, 15, 20 },
                                    Minutes = new List<int?>() { 0, 10, 20, 30, 40, 50 },
                                }
                            },
                            State = JobState.Enabled,
                        }
                    });

                Assert.Equal(id, result.Id);
                Assert.Equal(type, result.Type);
                Assert.Equal(jobDefinitionname, result.Name);
                Assert.Equal(JobActionType.StorageQueue, result.Properties.Action.Type);
                Assert.Equal("schedulersdktest", result.Properties.Action.QueueMessage.StorageAccount);
                Assert.Equal("queue1", result.Properties.Action.QueueMessage.QueueName);
                Assert.Equal("some message!", result.Properties.Action.QueueMessage.Message);
                Assert.Null(result.Properties.Action.QueueMessage.SasToken);
                Assert.Equal(RetryType.Fixed, result.Properties.Action.RetryPolicy.RetryType);
                Assert.Equal(2, result.Properties.Action.RetryPolicy.RetryCount);
                Assert.Equal(TimeSpan.FromMinutes(1), result.Properties.Action.RetryPolicy.RetryInterval);
                Assert.Equal(JobState.Enabled, result.Properties.State);
                Assert.Equal(RecurrenceFrequency.Week, result.Properties.Recurrence.Frequency);
                Assert.Equal(1, result.Properties.Recurrence.Interval);
                Assert.Equal(10000, result.Properties.Recurrence.Count);
                Assert.Equal(JobTests.EndTime, result.Properties.Recurrence.EndTime);
                Assert.Equal(new List<SchedulerDayOfWeek?>() { SchedulerDayOfWeek.Monday }, result.Properties.Recurrence.Schedule.WeekDays);
                Assert.Equal(new List<int?>() { 5, 10, 15, 20 }, result.Properties.Recurrence.Schedule.Hours);
                Assert.Equal(new List<int?>() { 0, 10, 20, 30, 40, 50 }, result.Properties.Recurrence.Schedule.Minutes);
                Assert.Null(result.Properties.Status.LastExecutionTime);
                Assert.Equal(0, result.Properties.Status.ExecutionCount);
                Assert.Equal(0, result.Properties.Status.FailureCount);
                Assert.Equal(0, result.Properties.Status.FaultedCount);

                var getResult = client.Jobs.Get(resourceGroupName, jobCollectionName, jobName);

                Assert.Equal(type, getResult.Type);
                Assert.Equal(jobDefinitionname, getResult.Name);
                Assert.Equal(JobActionType.StorageQueue, getResult.Properties.Action.Type);
                Assert.Equal("schedulersdktest", getResult.Properties.Action.QueueMessage.StorageAccount);
                Assert.Equal("queue1", getResult.Properties.Action.QueueMessage.QueueName);
                Assert.Equal("some message!", getResult.Properties.Action.QueueMessage.Message);
                Assert.Null(getResult.Properties.Action.QueueMessage.SasToken);
                Assert.Equal(RetryType.Fixed, getResult.Properties.Action.RetryPolicy.RetryType);
                Assert.Equal(2, getResult.Properties.Action.RetryPolicy.RetryCount);
                Assert.Equal(TimeSpan.FromMinutes(1), getResult.Properties.Action.RetryPolicy.RetryInterval);
                Assert.Equal(JobState.Enabled, getResult.Properties.State);
                Assert.Equal(RecurrenceFrequency.Week, getResult.Properties.Recurrence.Frequency);
                Assert.Equal(1, getResult.Properties.Recurrence.Interval);
                Assert.Equal(10000, getResult.Properties.Recurrence.Count);
                Assert.Equal(JobTests.EndTime, getResult.Properties.Recurrence.EndTime);
                Assert.Equal(new List<SchedulerDayOfWeek?>() { SchedulerDayOfWeek.Monday }, getResult.Properties.Recurrence.Schedule.WeekDays);
                Assert.Equal(new List<int?>() { 5, 10, 15, 20 }, getResult.Properties.Recurrence.Schedule.Hours);
                Assert.Equal(new List<int?>() { 0, 10, 20, 30, 40, 50 }, getResult.Properties.Recurrence.Schedule.Minutes);
                Assert.Null(getResult.Properties.Status.LastExecutionTime);
                Assert.Equal(0, getResult.Properties.Status.ExecutionCount);
                Assert.Equal(0, getResult.Properties.Status.FailureCount);
                Assert.Equal(0, getResult.Properties.Status.FaultedCount);

                client.JobCollections.Delete(resourceGroupName, jobCollectionName);
            }
        }

        [Fact]
        public void Scenario_JobCreateWithScheduleForMonth()
        {
            using (MockContext context = MockContext.Start("Scheduler.Test.ScenarioTests.JobTests"))
            {
                string jobCollectionName = TestUtilities.GenerateName("jc1");
                string jobName = TestUtilities.GenerateName("j1");
                string jobDefinitionname = string.Format("{0}/{1}", jobCollectionName, jobName);
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}/jobs/{3}", subscriptionId, resourceGroupName, jobCollectionName, jobName);

                var client = context.GetServiceClient<SchedulerManagementClient>();
                this.CreateJobCollection(client, jobCollectionName);

                var result = client.Jobs.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 13),
                            Action = new JobAction()
                            {
                                Type = JobActionType.StorageQueue,
                                QueueMessage = new StorageQueueMessage()
                                {
                                    StorageAccount = "schedulersdktest",
                                    QueueName = "queue1",
                                    Message = "some message!",
                                    SasToken = "ThIsiSmYtOkeNdoyOusEe",
                                },
                                RetryPolicy = new RetryPolicy()
                                {
                                    RetryType = RetryType.Fixed,
                                    RetryCount = 2,
                                    RetryInterval = TimeSpan.FromMinutes(1),
                                },
                                ErrorAction = new JobErrorAction()
                                {
                                    Type = JobActionType.Http,
                                    Request = new HttpRequest()
                                    {
                                        Uri = "http://www.bing.com/",
                                        Method = "GET",
                                    },
                                }
                            },
                            Recurrence = new JobRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Month,
                                Interval = 1,
                                Count = 10000,
                                EndTime = JobTests.EndTime,
                                Schedule = new JobRecurrenceSchedule()
                                {
                                    MonthDays = new List<int?>() { 15, 30 },
                                    Hours = new List<int?>() { 5, 10, 15, 20 },
                                    Minutes = new List<int?>() { 0, 10, 20, 30, 40, 50 },
                                }
                            },
                            State = JobState.Enabled,
                        }
                    });

                Assert.Equal(id, result.Id);
                Assert.Equal(type, result.Type);
                Assert.Equal(jobDefinitionname, result.Name);
                Assert.Equal(JobActionType.StorageQueue, result.Properties.Action.Type);
                Assert.Equal("schedulersdktest", result.Properties.Action.QueueMessage.StorageAccount);
                Assert.Equal("queue1", result.Properties.Action.QueueMessage.QueueName);
                Assert.Equal("some message!", result.Properties.Action.QueueMessage.Message);
                Assert.Null(result.Properties.Action.QueueMessage.SasToken);
                Assert.Equal(RetryType.Fixed, result.Properties.Action.RetryPolicy.RetryType);
                Assert.Equal(2, result.Properties.Action.RetryPolicy.RetryCount);
                Assert.Equal(TimeSpan.FromMinutes(1), result.Properties.Action.RetryPolicy.RetryInterval);
                Assert.Equal(JobActionType.Http, result.Properties.Action.ErrorAction.Type);
                Assert.Equal("http://www.bing.com/", result.Properties.Action.ErrorAction.Request.Uri);
                Assert.Equal("GET", result.Properties.Action.ErrorAction.Request.Method);
                Assert.Equal(JobState.Enabled, result.Properties.State);
                Assert.Equal(RecurrenceFrequency.Month, result.Properties.Recurrence.Frequency);
                Assert.Equal(1, result.Properties.Recurrence.Interval);
                Assert.Equal(10000, result.Properties.Recurrence.Count);
                Assert.Equal(JobTests.EndTime, result.Properties.Recurrence.EndTime);
                Assert.Equal(new List<int?>() { 15, 30 }, result.Properties.Recurrence.Schedule.MonthDays);
                Assert.Equal(new List<int?>() { 5, 10, 15, 20 }, result.Properties.Recurrence.Schedule.Hours);
                Assert.Equal(new List<int?>() { 0, 10, 20, 30, 40, 50 }, result.Properties.Recurrence.Schedule.Minutes);
                Assert.Null(result.Properties.Status.LastExecutionTime);
                Assert.Equal(0, result.Properties.Status.ExecutionCount);
                Assert.Equal(0, result.Properties.Status.FailureCount);
                Assert.Equal(0, result.Properties.Status.FaultedCount);

                var getResult = client.Jobs.Get(resourceGroupName, jobCollectionName, jobName);

                Assert.Equal(type, getResult.Type);
                Assert.Equal(jobDefinitionname, getResult.Name);
                Assert.Equal(JobActionType.StorageQueue, getResult.Properties.Action.Type);
                Assert.Equal("schedulersdktest", getResult.Properties.Action.QueueMessage.StorageAccount);
                Assert.Equal("queue1", getResult.Properties.Action.QueueMessage.QueueName);
                Assert.Equal("some message!", getResult.Properties.Action.QueueMessage.Message);
                Assert.Null(getResult.Properties.Action.QueueMessage.SasToken);
                Assert.Equal(RetryType.Fixed, getResult.Properties.Action.RetryPolicy.RetryType);
                Assert.Equal(2, getResult.Properties.Action.RetryPolicy.RetryCount);
                Assert.Equal(TimeSpan.FromMinutes(1), getResult.Properties.Action.RetryPolicy.RetryInterval);
                Assert.Equal(JobActionType.Http, getResult.Properties.Action.ErrorAction.Type);
                Assert.Equal("http://www.bing.com/", getResult.Properties.Action.ErrorAction.Request.Uri);
                Assert.Equal("GET", getResult.Properties.Action.ErrorAction.Request.Method);
                Assert.Equal(JobState.Enabled, getResult.Properties.State);
                Assert.Equal(RecurrenceFrequency.Month, getResult.Properties.Recurrence.Frequency);
                Assert.Equal(1, getResult.Properties.Recurrence.Interval);
                Assert.Equal(10000, getResult.Properties.Recurrence.Count);
                Assert.Equal(JobTests.EndTime, getResult.Properties.Recurrence.EndTime);
                Assert.Equal(new List<int?>() { 15, 30 }, getResult.Properties.Recurrence.Schedule.MonthDays);
                Assert.Equal(new List<int?>() { 5, 10, 15, 20 }, getResult.Properties.Recurrence.Schedule.Hours);
                Assert.Equal(new List<int?>() { 0, 10, 20, 30, 40, 50 }, getResult.Properties.Recurrence.Schedule.Minutes);
                Assert.Null(getResult.Properties.Status.LastExecutionTime);
                Assert.Equal(0, getResult.Properties.Status.ExecutionCount);
                Assert.Equal(0, getResult.Properties.Status.FailureCount);
                Assert.Equal(0, getResult.Properties.Status.FaultedCount);

                client.JobCollections.Delete(resourceGroupName, jobCollectionName);
            }
        }

        [Fact]
        public void Scenario_JobCreateWithScheduleForMonthlyOccurrence()
        {
            using (MockContext context = MockContext.Start("Scheduler.Test.ScenarioTests.JobTests"))
            {
                string jobCollectionName = TestUtilities.GenerateName("jc1");
                string jobName = TestUtilities.GenerateName("j1");
                string jobDefinitionname = string.Format("{0}/{1}", jobCollectionName, jobName);
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}/jobs/{3}", subscriptionId, resourceGroupName, jobCollectionName, jobName);

                var client = context.GetServiceClient<SchedulerManagementClient>();
                this.CreateJobCollection(client, jobCollectionName);

                var result = client.Jobs.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 13),
                            Action = new JobAction()
                            {
                                Type = JobActionType.StorageQueue,
                                QueueMessage = new StorageQueueMessage()
                                {
                                    StorageAccount = "schedulersdktest",
                                    QueueName = "queue1",
                                    Message = "some message!",
                                    SasToken = "ThIsiSmYtOkeNdoyOusEe",
                                },
                                RetryPolicy = new RetryPolicy()
                                {
                                    RetryType = RetryType.Fixed,
                                    RetryCount = 2,
                                    RetryInterval = TimeSpan.FromMinutes(1),
                                },
                                ErrorAction = new JobErrorAction()
                                {
                                    Type = JobActionType.Http,
                                    Request = new HttpRequest()
                                    {
                                        Uri = "http://www.bing.com/",
                                        Method = "GET",
                                    },
                                }
                            },
                            Recurrence = new JobRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Month,
                                Interval = 1,
                                Count = 10000,
                                EndTime = JobTests.EndTime,
                                Schedule = new JobRecurrenceSchedule()
                                {
                                    Hours = new List<int?>() { 5, 10, 15, 20 },
                                    Minutes = new List<int?>() { 0, 10, 20, 30, 40, 50 },
                                    MonthlyOccurrences = new List<JobRecurrenceScheduleMonthlyOccurrence>() 
                                    { 
                                        new JobRecurrenceScheduleMonthlyOccurrence()
                                        {
                                            Day = JobScheduleDay.Monday,
                                            Occurrence = 1,
                                        },
                                        new JobRecurrenceScheduleMonthlyOccurrence()
                                        {
                                            Day = JobScheduleDay.Friday,
                                            Occurrence = 1,
                                        }
                                    },
                                }
                            },
                            State = JobState.Enabled,
                        }
                    });

                Assert.Equal(id, result.Id);
                Assert.Equal(type, result.Type);
                Assert.Equal(jobDefinitionname, result.Name);
                Assert.Equal(JobActionType.StorageQueue, result.Properties.Action.Type);
                Assert.Equal("schedulersdktest", result.Properties.Action.QueueMessage.StorageAccount);
                Assert.Equal("queue1", result.Properties.Action.QueueMessage.QueueName);
                Assert.Equal("some message!", result.Properties.Action.QueueMessage.Message);
                Assert.Null(result.Properties.Action.QueueMessage.SasToken);
                Assert.Equal(RetryType.Fixed, result.Properties.Action.RetryPolicy.RetryType);
                Assert.Equal(2, result.Properties.Action.RetryPolicy.RetryCount);
                Assert.Equal(TimeSpan.FromMinutes(1), result.Properties.Action.RetryPolicy.RetryInterval);
                Assert.Equal(JobActionType.Http, result.Properties.Action.ErrorAction.Type);
                Assert.Equal("http://www.bing.com/", result.Properties.Action.ErrorAction.Request.Uri);
                Assert.Equal("GET", result.Properties.Action.ErrorAction.Request.Method);
                Assert.Equal(JobState.Enabled, result.Properties.State);
                Assert.Equal(RecurrenceFrequency.Month, result.Properties.Recurrence.Frequency);
                Assert.Equal(1, result.Properties.Recurrence.Interval);
                Assert.Equal(10000, result.Properties.Recurrence.Count);
                Assert.Equal(JobTests.EndTime, result.Properties.Recurrence.EndTime);
                Assert.Equal(2, result.Properties.Recurrence.Schedule.MonthlyOccurrences.Count);
                Assert.Equal(JobScheduleDay.Monday, result.Properties.Recurrence.Schedule.MonthlyOccurrences[0].Day);
                Assert.Equal(1, result.Properties.Recurrence.Schedule.MonthlyOccurrences[0].Occurrence);
                Assert.Equal(JobScheduleDay.Friday, result.Properties.Recurrence.Schedule.MonthlyOccurrences[1].Day);
                Assert.Equal(1, result.Properties.Recurrence.Schedule.MonthlyOccurrences[1].Occurrence);
                Assert.Equal(new List<int?>() { 5, 10, 15, 20 }, result.Properties.Recurrence.Schedule.Hours);
                Assert.Equal(new List<int?>() { 0, 10, 20, 30, 40, 50 }, result.Properties.Recurrence.Schedule.Minutes);
                Assert.Null(result.Properties.Status.LastExecutionTime);
                Assert.Equal(0, result.Properties.Status.ExecutionCount);
                Assert.Equal(0, result.Properties.Status.FailureCount);
                Assert.Equal(0, result.Properties.Status.FaultedCount);

                var getResult = client.Jobs.Get(resourceGroupName, jobCollectionName, jobName);

                Assert.Equal(type, getResult.Type);
                Assert.Equal(jobDefinitionname, getResult.Name);
                Assert.Equal(JobActionType.StorageQueue, getResult.Properties.Action.Type);
                Assert.Equal("schedulersdktest", getResult.Properties.Action.QueueMessage.StorageAccount);
                Assert.Equal("queue1", getResult.Properties.Action.QueueMessage.QueueName);
                Assert.Equal("some message!", getResult.Properties.Action.QueueMessage.Message);
                Assert.Null(getResult.Properties.Action.QueueMessage.SasToken);
                Assert.Equal(RetryType.Fixed, getResult.Properties.Action.RetryPolicy.RetryType);
                Assert.Equal(2, getResult.Properties.Action.RetryPolicy.RetryCount);
                Assert.Equal(TimeSpan.FromMinutes(1), getResult.Properties.Action.RetryPolicy.RetryInterval);
                Assert.Equal(JobActionType.Http, getResult.Properties.Action.ErrorAction.Type);
                Assert.Equal("http://www.bing.com/", getResult.Properties.Action.ErrorAction.Request.Uri);
                Assert.Equal("GET", getResult.Properties.Action.ErrorAction.Request.Method);
                Assert.Equal(JobState.Enabled, getResult.Properties.State);
                Assert.Equal(RecurrenceFrequency.Month, getResult.Properties.Recurrence.Frequency);
                Assert.Equal(1, getResult.Properties.Recurrence.Interval);
                Assert.Equal(10000, getResult.Properties.Recurrence.Count);
                Assert.Equal(JobTests.EndTime, getResult.Properties.Recurrence.EndTime);
                Assert.Equal(2, getResult.Properties.Recurrence.Schedule.MonthlyOccurrences.Count);
                Assert.Equal(JobScheduleDay.Monday, getResult.Properties.Recurrence.Schedule.MonthlyOccurrences[0].Day);
                Assert.Equal(1, getResult.Properties.Recurrence.Schedule.MonthlyOccurrences[0].Occurrence);
                Assert.Equal(JobScheduleDay.Friday, getResult.Properties.Recurrence.Schedule.MonthlyOccurrences[1].Day);
                Assert.Equal(1, getResult.Properties.Recurrence.Schedule.MonthlyOccurrences[1].Occurrence);
                Assert.Equal(new List<int?>() { 5, 10, 15, 20 }, getResult.Properties.Recurrence.Schedule.Hours);
                Assert.Equal(new List<int?>() { 0, 10, 20, 30, 40, 50 }, getResult.Properties.Recurrence.Schedule.Minutes);
                Assert.Null(getResult.Properties.Status.LastExecutionTime);
                Assert.Equal(0, getResult.Properties.Status.ExecutionCount);
                Assert.Equal(0, getResult.Properties.Status.FailureCount);
                Assert.Equal(0, getResult.Properties.Status.FaultedCount);

                client.JobCollections.Delete(resourceGroupName, jobCollectionName);
            }
        }

        [Fact]
        public void Scenario_JobCreateUpdateDeleteHttpJob()
        {
            using (MockContext context = MockContext.Start("Scheduler.Test.ScenarioTests.JobTests"))
            {
                string jobCollectionName = TestUtilities.GenerateName("jc1");
                string jobName = TestUtilities.GenerateName("j1");
                string jobDefinitionname = string.Format("{0}/{1}", jobCollectionName, jobName);
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}/jobs/{3}", subscriptionId, resourceGroupName, jobCollectionName, jobName);

                var client = context.GetServiceClient<SchedulerManagementClient>();
                this.CreateJobCollection(client, jobCollectionName);

                var header = new Dictionary<string, string>();
                header.Add("content-type", "application/xml");

                var result = client.Jobs.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 13),
                            Action = new JobAction()
                            {
                                Type = JobActionType.Http,
                                Request = new HttpRequest()
                                {
                                    Uri = "http://www.bing.com/",
                                    Method = "GET",
                                    Body = "some body message!",
                                    Headers = header,
                                },
                                RetryPolicy = new RetryPolicy()
                                {
                                    RetryType = RetryType.Fixed,
                                    RetryCount = 2,
                                    RetryInterval = TimeSpan.FromMinutes(1),
                                },
                                ErrorAction = new JobErrorAction()
                                {
                                    Type = JobActionType.StorageQueue,
                                    QueueMessage = new StorageQueueMessage()
                                    {
                                        StorageAccount = "schedulersdktest",
                                        QueueName = "queue1",
                                        Message = "some message!",
                                        SasToken = "ThIsiSmYtOkeNdoyOusEe",
                                    }
                                }
                            },
                            Recurrence = new JobRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Week,
                                Interval = 1,
                                Count = 10000,
                                EndTime = JobTests.EndTime,
                            },
                            State = JobState.Enabled,
                        }
                    });

                Assert.Equal(id, result.Id);
                Assert.Equal(type, result.Type);
                Assert.Equal(jobDefinitionname, result.Name);
                Assert.Equal(JobActionType.Http, result.Properties.Action.Type);
                Assert.Equal("http://www.bing.com/", result.Properties.Action.Request.Uri);
                Assert.Equal("GET", result.Properties.Action.Request.Method);
                Assert.Equal("some body message!", result.Properties.Action.Request.Body);
                Assert.Equal(header, result.Properties.Action.Request.Headers);
                Assert.Equal(RetryType.Fixed, result.Properties.Action.RetryPolicy.RetryType);
                Assert.Equal(2, result.Properties.Action.RetryPolicy.RetryCount);
                Assert.Equal(TimeSpan.FromMinutes(1), result.Properties.Action.RetryPolicy.RetryInterval);
                Assert.Equal(JobActionType.StorageQueue, result.Properties.Action.ErrorAction.Type);
                Assert.Equal("schedulersdktest", result.Properties.Action.ErrorAction.QueueMessage.StorageAccount);
                Assert.Equal("queue1", result.Properties.Action.ErrorAction.QueueMessage.QueueName);
                Assert.Equal("some message!", result.Properties.Action.ErrorAction.QueueMessage.Message);
                Assert.Null(result.Properties.Action.ErrorAction.QueueMessage.SasToken);
                Assert.Equal(JobState.Enabled, result.Properties.State);
                Assert.Equal(RecurrenceFrequency.Week, result.Properties.Recurrence.Frequency);
                Assert.Equal(1, result.Properties.Recurrence.Interval);
                Assert.Equal(10000, result.Properties.Recurrence.Count);
                Assert.Equal(JobTests.EndTime, result.Properties.Recurrence.EndTime);
                Assert.Null(result.Properties.Status.LastExecutionTime);
                Assert.Equal(0, result.Properties.Status.ExecutionCount);
                Assert.Equal(0, result.Properties.Status.FailureCount);
                Assert.Equal(0, result.Properties.Status.FaultedCount);

                var updateResult = client.Jobs.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 13),
                            Action = new JobAction()
                            {
                                Type = JobActionType.Http,
                                Request = new HttpRequest()
                                {
                                    Uri = "http://www.bing.com/",
                                    Method = "GET",
                                }
                            },
                            State = JobState.Disabled,
                        }
                    });

                Assert.Equal(id, updateResult.Id);
                Assert.Equal(type, updateResult.Type);
                Assert.Equal(jobDefinitionname, updateResult.Name);
                Assert.Equal(JobActionType.Http, updateResult.Properties.Action.Type);
                Assert.Equal("http://www.bing.com/", updateResult.Properties.Action.Request.Uri);
                Assert.Equal("GET", updateResult.Properties.Action.Request.Method);
                Assert.Null(updateResult.Properties.Action.Request.Body);
                Assert.Null(updateResult.Properties.Action.RetryPolicy);
                Assert.Null(updateResult.Properties.Action.ErrorAction);
                Assert.Equal(JobState.Disabled, updateResult.Properties.State);
                Assert.Null(updateResult.Properties.Recurrence);
                Assert.Null(updateResult.Properties.Status);

                client.JobCollections.Delete(resourceGroupName, jobCollectionName);
            }
        }

        [Fact]
        public void Scenario_JobCreateHttpJobWithBasicAuth()
        {
            using (MockContext context = MockContext.Start("Scheduler.Test.ScenarioTests.JobTests"))
            {
                string jobCollectionName = TestUtilities.GenerateName("jc1");
                string jobName = TestUtilities.GenerateName("j1");
                string jobDefinitionname = string.Format("{0}/{1}", jobCollectionName, jobName);
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}/jobs/{3}", subscriptionId, resourceGroupName, jobCollectionName, jobName);

                var client = context.GetServiceClient<SchedulerManagementClient>();
                this.CreateJobCollection(client, jobCollectionName);

                var header = new Dictionary<string, string>();
                header.Add("content-type", "application/xml");

                var result = client.Jobs.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 13),
                            Action = new JobAction()
                            {
                                Type = JobActionType.Http,
                                Request = new HttpRequest()
                                {
                                    Uri = "http://www.bing.com/",
                                    Method = "GET",
                                    Body = "some body message!",
                                    Headers = header,
                                    Authentication = new BasicAuthentication() 
                                    { 
                                        Username = "username",
                                        Password = "pasworrd",
                                        Type = HttpAuthenticationType.Basic,
                                    }
                                },
                                RetryPolicy = new RetryPolicy()
                                {
                                    RetryType = RetryType.Fixed,
                                    RetryCount = 2,
                                    RetryInterval = TimeSpan.FromMinutes(1),
                                },
                                ErrorAction = new JobErrorAction()
                                {
                                    Type = JobActionType.StorageQueue,
                                    QueueMessage = new StorageQueueMessage()
                                    {
                                        StorageAccount = "schedulersdktest",
                                        QueueName = "queue1",
                                        Message = "some message!",
                                        SasToken = "ThIsiSmYtOkeNdoyOusEe",
                                    }
                                }
                            },
                            Recurrence = new JobRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Week,
                                Interval = 1,
                                Count = 10000,
                                EndTime = JobTests.EndTime,
                            },
                            State = JobState.Enabled,
                        }
                    });

                Assert.Equal(id, result.Id);
                Assert.Equal(type, result.Type);
                Assert.Equal(jobDefinitionname, result.Name);
                Assert.Equal(JobActionType.Http, result.Properties.Action.Type);
                Assert.Equal("http://www.bing.com/", result.Properties.Action.Request.Uri);
                Assert.Equal("GET", result.Properties.Action.Request.Method);
                Assert.Equal("some body message!", result.Properties.Action.Request.Body);
                Assert.Equal(header, result.Properties.Action.Request.Headers);
                Assert.NotNull(result.Properties.Action.Request.Authentication);
                Assert.Equal(HttpAuthenticationType.Basic, result.Properties.Action.Request.Authentication.Type);
                Assert.Equal(RetryType.Fixed, result.Properties.Action.RetryPolicy.RetryType);
                Assert.Equal(2, result.Properties.Action.RetryPolicy.RetryCount);
                Assert.Equal(TimeSpan.FromMinutes(1), result.Properties.Action.RetryPolicy.RetryInterval);
                Assert.Equal(JobActionType.StorageQueue, result.Properties.Action.ErrorAction.Type);
                Assert.Equal("schedulersdktest", result.Properties.Action.ErrorAction.QueueMessage.StorageAccount);
                Assert.Equal("queue1", result.Properties.Action.ErrorAction.QueueMessage.QueueName);
                Assert.Equal("some message!", result.Properties.Action.ErrorAction.QueueMessage.Message);
                Assert.Null(result.Properties.Action.ErrorAction.QueueMessage.SasToken);
                Assert.Equal(JobState.Enabled, result.Properties.State);
                Assert.Equal(RecurrenceFrequency.Week, result.Properties.Recurrence.Frequency);
                Assert.Equal(1, result.Properties.Recurrence.Interval);
                Assert.Equal(10000, result.Properties.Recurrence.Count);
                Assert.Equal(JobTests.EndTime, result.Properties.Recurrence.EndTime);
                Assert.Null(result.Properties.Status.LastExecutionTime);
                Assert.Equal(0, result.Properties.Status.ExecutionCount);
                Assert.Equal(0, result.Properties.Status.FailureCount);
                Assert.Equal(0, result.Properties.Status.FaultedCount);

                var updateResult = client.Jobs.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 13),
                            Action = new JobAction()
                            {
                                Type = JobActionType.Http,
                                Request = new HttpRequest()
                                {
                                    Uri = "http://www.bing.com/",
                                    Method = "GET",
                                }
                            },
                            State = JobState.Disabled,
                        }
                    });

                Assert.Equal(id, updateResult.Id);
                Assert.Equal(type, updateResult.Type);
                Assert.Equal(jobDefinitionname, updateResult.Name);
                Assert.Equal(JobActionType.Http, updateResult.Properties.Action.Type);
                Assert.Equal("http://www.bing.com/", updateResult.Properties.Action.Request.Uri);
                Assert.Equal("GET", updateResult.Properties.Action.Request.Method);
                Assert.Null(updateResult.Properties.Action.Request.Body);
                Assert.Null(updateResult.Properties.Action.RetryPolicy);
                Assert.Null(updateResult.Properties.Action.ErrorAction);
                Assert.Equal(JobState.Disabled, updateResult.Properties.State);
                Assert.Null(updateResult.Properties.Recurrence);
                Assert.Null(updateResult.Properties.Status);

                client.JobCollections.Delete(resourceGroupName, jobCollectionName);
            }
        }

        [Fact]
        public void Scenario_JobCreateHttpJobWithOAuth()
        {
            using (MockContext context = MockContext.Start("Scheduler.Test.ScenarioTests.JobTests"))
            {
                string jobCollectionName = TestUtilities.GenerateName("jc1");
                string jobName = TestUtilities.GenerateName("j1");
                string jobDefinitionname = string.Format("{0}/{1}", jobCollectionName, jobName);
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}/jobs/{3}", subscriptionId, resourceGroupName, jobCollectionName, jobName);

                var client = context.GetServiceClient<SchedulerManagementClient>();
                this.CreateJobCollection(client, jobCollectionName);

                var header = new Dictionary<string, string>();
                header.Add("content-type", "application/xml");

                var result = client.Jobs.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 13),
                            Action = new JobAction()
                            {
                                Type = JobActionType.Http,
                                Request = new HttpRequest()
                                {
                                    Uri = "https://management.azure.com/subscriptions/11111111-1111-1111-1111-111111111111/",
                                    Method = "GET",
                                    Body = "some body message!",
                                    Headers = header,
                                    Authentication = new OAuthAuthentication()
                                    {
                                        // [SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
                                        Secret = "ThisIsFakeSecret",
                                        Audience = "https://management.core.windows.net/",
                                        ClientId = "11111111-1111-1111-1111-111111111111",
                                        Tenant = "fake.tenant.com",
                                        Type = HttpAuthenticationType.ActiveDirectoryOAuth,
                                    }
                                },
                                RetryPolicy = new RetryPolicy()
                                {
                                    RetryType = RetryType.Fixed,
                                    RetryCount = 2,
                                    RetryInterval = TimeSpan.FromMinutes(1),
                                },
                                ErrorAction = new JobErrorAction()
                                {
                                    Type = JobActionType.StorageQueue,
                                    QueueMessage = new StorageQueueMessage()
                                    {
                                        StorageAccount = "schedulersdktest",
                                        QueueName = "queue1",
                                        Message = "some message!",
                                        SasToken = "ThIsiSmYtOkeNdoyOusEe",
                                    }
                                }
                            },
                            Recurrence = new JobRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Week,
                                Interval = 1,
                                Count = 10000,
                                EndTime = JobTests.EndTime,
                            },
                            State = JobState.Enabled,
                        }
                    });

                Assert.Equal(id, result.Id);
                Assert.Equal(type, result.Type);
                Assert.Equal(jobDefinitionname, result.Name);
                Assert.Equal(JobActionType.Http, result.Properties.Action.Type);
                Assert.Equal("https://management.azure.com/subscriptions/9d4e2ad0-e20b-4464-9219-353bded52513/", result.Properties.Action.Request.Uri);
                Assert.Equal("GET", result.Properties.Action.Request.Method);
                Assert.Equal("some body message!", result.Properties.Action.Request.Body);
                Assert.Equal(header, result.Properties.Action.Request.Headers);
                Assert.Equal(HttpAuthenticationType.ActiveDirectoryOAuth, result.Properties.Action.Request.Authentication.Type);
                Assert.Equal(RetryType.Fixed, result.Properties.Action.RetryPolicy.RetryType);
                Assert.Equal(2, result.Properties.Action.RetryPolicy.RetryCount);
                Assert.Equal(TimeSpan.FromMinutes(1), result.Properties.Action.RetryPolicy.RetryInterval);
                Assert.Equal(JobActionType.StorageQueue, result.Properties.Action.ErrorAction.Type);
                Assert.Equal("schedulersdktest", result.Properties.Action.ErrorAction.QueueMessage.StorageAccount);
                Assert.Equal("queue1", result.Properties.Action.ErrorAction.QueueMessage.QueueName);
                Assert.Equal("some message!", result.Properties.Action.ErrorAction.QueueMessage.Message);
                Assert.Null(result.Properties.Action.ErrorAction.QueueMessage.SasToken);
                Assert.Equal(JobState.Enabled, result.Properties.State);
                Assert.Equal(RecurrenceFrequency.Week, result.Properties.Recurrence.Frequency);
                Assert.Equal(1, result.Properties.Recurrence.Interval);
                Assert.Equal(10000, result.Properties.Recurrence.Count);
                Assert.Equal(JobTests.EndTime, result.Properties.Recurrence.EndTime);
                Assert.Null(result.Properties.Status.LastExecutionTime);
                Assert.Equal(0, result.Properties.Status.ExecutionCount);
                Assert.Equal(0, result.Properties.Status.FailureCount);
                Assert.Equal(0, result.Properties.Status.FaultedCount);

                var updateResult = client.Jobs.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 13),
                            Action = new JobAction()
                            {
                                Type = JobActionType.Http,
                                Request = new HttpRequest()
                                {
                                    Uri = "http://www.bing.com/",
                                    Method = "GET",
                                }
                            },
                            State = JobState.Disabled,
                        }
                    });

                Assert.Equal(id, updateResult.Id);
                Assert.Equal(type, updateResult.Type);
                Assert.Equal(jobDefinitionname, updateResult.Name);
                Assert.Equal(JobActionType.Http, updateResult.Properties.Action.Type);
                Assert.Equal("http://www.bing.com/", updateResult.Properties.Action.Request.Uri);
                Assert.Equal("GET", updateResult.Properties.Action.Request.Method);
                Assert.Null(updateResult.Properties.Action.Request.Body);
                Assert.Null(updateResult.Properties.Action.RetryPolicy);
                Assert.Null(updateResult.Properties.Action.ErrorAction);
                Assert.Equal(JobState.Disabled, updateResult.Properties.State);
                Assert.Null(updateResult.Properties.Recurrence);
                Assert.Null(updateResult.Properties.Status);

                client.JobCollections.Delete(resourceGroupName, jobCollectionName);
            }
        }

        [Fact]
        public void Scenario_JobCreateHttpJobWithClientCertAuth()
        {
            using (MockContext context = MockContext.Start("Scheduler.Test.ScenarioTests.JobTests"))
            {
                string jobCollectionName = TestUtilities.GenerateName("jc1");
                string jobName = TestUtilities.GenerateName("j1");
                string jobDefinitionname = string.Format("{0}/{1}", jobCollectionName, jobName);
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}/jobs/{3}", subscriptionId, resourceGroupName, jobCollectionName, jobName);

                var client = context.GetServiceClient<SchedulerManagementClient>();
                this.CreateJobCollection(client, jobCollectionName);

                var header = new Dictionary<string, string>();
                header.Add("content-type", "application/xml");

                var result = client.Jobs.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 13),
                            Action = new JobAction()
                            {
                                Type = JobActionType.Http,
                                Request = new HttpRequest()
                                {
                                    Uri = "https://www.bing.com/",
                                    Method = "GET",
                                    Body = "some body message!",
                                    Headers = header,
                                    Authentication = new ClientCertAuthentication()
                                    {
                                        Password = "FakePassword",
                                        Pfx = "ThisIsfakePfx",
                                        Type = HttpAuthenticationType.ClientCertificate,
                                    }
                                },
                                RetryPolicy = new RetryPolicy()
                                {
                                    RetryType = RetryType.Fixed,
                                    RetryCount = 2,
                                    RetryInterval = TimeSpan.FromMinutes(1),
                                },
                                ErrorAction = new JobErrorAction()
                                {
                                    Type = JobActionType.StorageQueue,
                                    QueueMessage = new StorageQueueMessage()
                                    {
                                        StorageAccount = "schedulersdktest",
                                        QueueName = "queue1",
                                        Message = "some message!",
                                        SasToken = "ThIsiSmYtOkeNdoyOusEe",
                                    }
                                }
                            },
                            Recurrence = new JobRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Week,
                                Interval = 1,
                                Count = 10000,
                                EndTime = JobTests.EndTime,
                            },
                            State = JobState.Enabled,
                        }
                    });

                Assert.Equal(id, result.Id);
                Assert.Equal(type, result.Type);
                Assert.Equal(jobDefinitionname, result.Name);
                Assert.Equal(JobActionType.Http, result.Properties.Action.Type);
                Assert.Equal("https://www.bing.com/", result.Properties.Action.Request.Uri);
                Assert.Equal("GET", result.Properties.Action.Request.Method);
                Assert.Equal("some body message!", result.Properties.Action.Request.Body);
                Assert.Equal(header, result.Properties.Action.Request.Headers);
                Assert.Equal(HttpAuthenticationType.ClientCertificate, result.Properties.Action.Request.Authentication.Type);
                Assert.Equal(RetryType.Fixed, result.Properties.Action.RetryPolicy.RetryType);
                Assert.Equal(2, result.Properties.Action.RetryPolicy.RetryCount);
                Assert.Equal(TimeSpan.FromMinutes(1), result.Properties.Action.RetryPolicy.RetryInterval);
                Assert.Equal(JobActionType.StorageQueue, result.Properties.Action.ErrorAction.Type);
                Assert.Equal("schedulersdktest", result.Properties.Action.ErrorAction.QueueMessage.StorageAccount);
                Assert.Equal("queue1", result.Properties.Action.ErrorAction.QueueMessage.QueueName);
                Assert.Equal("some message!", result.Properties.Action.ErrorAction.QueueMessage.Message);
                Assert.Null(result.Properties.Action.ErrorAction.QueueMessage.SasToken);
                Assert.Equal(JobState.Enabled, result.Properties.State);
                Assert.Equal(RecurrenceFrequency.Week, result.Properties.Recurrence.Frequency);
                Assert.Equal(1, result.Properties.Recurrence.Interval);
                Assert.Equal(10000, result.Properties.Recurrence.Count);
                Assert.Equal(JobTests.EndTime, result.Properties.Recurrence.EndTime);
                Assert.Null(result.Properties.Status.LastExecutionTime);
                Assert.Equal(0, result.Properties.Status.ExecutionCount);
                Assert.Equal(0, result.Properties.Status.FailureCount);
                Assert.Equal(0, result.Properties.Status.FaultedCount);

                var updateResult = client.Jobs.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 13),
                            Action = new JobAction()
                            {
                                Type = JobActionType.Http,
                                Request = new HttpRequest()
                                {
                                    Uri = "http://www.bing.com/",
                                    Method = "GET",
                                }
                            },
                            State = JobState.Disabled,
                        }
                    });

                Assert.Equal(id, updateResult.Id);
                Assert.Equal(type, updateResult.Type);
                Assert.Equal(jobDefinitionname, updateResult.Name);
                Assert.Equal(JobActionType.Http, updateResult.Properties.Action.Type);
                Assert.Equal("http://www.bing.com/", updateResult.Properties.Action.Request.Uri);
                Assert.Equal("GET", updateResult.Properties.Action.Request.Method);
                Assert.Null(updateResult.Properties.Action.Request.Body);
                Assert.Null(updateResult.Properties.Action.RetryPolicy);
                Assert.Null(updateResult.Properties.Action.ErrorAction);
                Assert.Equal(JobState.Disabled, updateResult.Properties.State);
                Assert.Null(updateResult.Properties.Recurrence);
                Assert.Null(updateResult.Properties.Status);

                client.JobCollections.Delete(resourceGroupName, jobCollectionName);
            }
        }

        [Fact]
        public void Scenario_JobCreatePatchDeleteStorageJob()
        {
            using (MockContext context = MockContext.Start("Scheduler.Test.ScenarioTests.JobTests"))
            {
                string jobCollectionName = TestUtilities.GenerateName("jc1");
                string jobName = TestUtilities.GenerateName("j1");
                string jobDefinitionname = string.Format("{0}/{1}", jobCollectionName, jobName);
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}/jobs/{3}", subscriptionId, resourceGroupName, jobCollectionName, jobName);

                var client = context.GetServiceClient<SchedulerManagementClient>();
                this.CreateJobCollection(client, jobCollectionName);

                var result = client.Jobs.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 13),
                            Action = new JobAction()
                            {
                                Type = JobActionType.StorageQueue,
                                QueueMessage = new StorageQueueMessage()
                                {
                                    StorageAccount = "schedulersdktest",
                                    QueueName = "queue1",
                                    Message = "some message!",
                                    SasToken = "ThIsiSmYtOkeNdoyOusEe",
                                },
                                RetryPolicy = new RetryPolicy()
                                {
                                    RetryType = RetryType.Fixed,
                                    RetryCount = 2,
                                    RetryInterval = TimeSpan.FromMinutes(1),
                                },
                                ErrorAction = new JobErrorAction()
                                {
                                    Type = JobActionType.Http,
                                    Request = new HttpRequest()
                                    {
                                        Uri = "http://www.bing.com/",
                                        Method = "GET",
                                    },
                                }
                            },
                            Recurrence = new JobRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Week,
                                Interval = 1,
                                Count = 10000,
                                EndTime = JobTests.EndTime,
                            },
                            State = JobState.Enabled,
                        }
                    });

                Assert.Equal(id, result.Id);
                Assert.Equal(type, result.Type);
                Assert.Equal(jobDefinitionname, result.Name);
                Assert.Equal(JobActionType.StorageQueue, result.Properties.Action.Type);
                Assert.Equal("schedulersdktest", result.Properties.Action.QueueMessage.StorageAccount);
                Assert.Equal("queue1", result.Properties.Action.QueueMessage.QueueName);
                Assert.Equal("some message!", result.Properties.Action.QueueMessage.Message);
                Assert.Null(result.Properties.Action.QueueMessage.SasToken);
                Assert.Equal(RetryType.Fixed, result.Properties.Action.RetryPolicy.RetryType);
                Assert.Equal(2, result.Properties.Action.RetryPolicy.RetryCount);
                Assert.Equal(TimeSpan.FromMinutes(1), result.Properties.Action.RetryPolicy.RetryInterval);
                Assert.Equal(JobActionType.Http, result.Properties.Action.ErrorAction.Type);
                Assert.Equal("http://www.bing.com/", result.Properties.Action.ErrorAction.Request.Uri);
                Assert.Equal("GET", result.Properties.Action.ErrorAction.Request.Method);
                Assert.Equal(JobState.Enabled, result.Properties.State);
                Assert.Equal(RecurrenceFrequency.Week, result.Properties.Recurrence.Frequency);
                Assert.Equal(1, result.Properties.Recurrence.Interval);
                Assert.Equal(10000, result.Properties.Recurrence.Count);
                Assert.Equal(JobTests.EndTime, result.Properties.Recurrence.EndTime);
                Assert.Null(result.Properties.Status.LastExecutionTime);
                Assert.Equal(0, result.Properties.Status.ExecutionCount);
                Assert.Equal(0, result.Properties.Status.FailureCount);
                Assert.Equal(0, result.Properties.Status.FaultedCount);

                var patchResult = client.Jobs.Patch(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 14),
                            Recurrence = new JobRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Day,
                                Interval = 1,
                            },
                        }
                    });

                Assert.Equal(type, patchResult.Type);
                Assert.Equal(jobDefinitionname, patchResult.Name);
                Assert.Equal(new DateTime(2015, 7, 14, 0, 0, 0, DateTimeKind.Utc), patchResult.Properties.StartTime);
                Assert.Equal(JobActionType.StorageQueue, patchResult.Properties.Action.Type);
                Assert.Equal("schedulersdktest", patchResult.Properties.Action.QueueMessage.StorageAccount);
                Assert.Equal("queue1", patchResult.Properties.Action.QueueMessage.QueueName);
                Assert.Equal("some message!", patchResult.Properties.Action.QueueMessage.Message);
                Assert.Null(patchResult.Properties.Action.QueueMessage.SasToken);
                Assert.Equal(RetryType.Fixed, patchResult.Properties.Action.RetryPolicy.RetryType);
                Assert.Equal(2, patchResult.Properties.Action.RetryPolicy.RetryCount);
                Assert.Equal(TimeSpan.FromMinutes(1), patchResult.Properties.Action.RetryPolicy.RetryInterval);
                Assert.Equal(JobActionType.Http, patchResult.Properties.Action.ErrorAction.Type);
                Assert.Equal("http://www.bing.com/", patchResult.Properties.Action.ErrorAction.Request.Uri);
                Assert.Equal("GET", patchResult.Properties.Action.ErrorAction.Request.Method);
                Assert.Equal(JobState.Enabled, patchResult.Properties.State);
                Assert.Equal(RecurrenceFrequency.Day, patchResult.Properties.Recurrence.Frequency);
                Assert.Equal(1, patchResult.Properties.Recurrence.Interval);
                Assert.Equal(10000, patchResult.Properties.Recurrence.Count);
                Assert.Equal(JobTests.EndTime, patchResult.Properties.Recurrence.EndTime);
                Assert.Null(patchResult.Properties.Status.LastExecutionTime);
                Assert.Equal(0, patchResult.Properties.Status.ExecutionCount);
                Assert.Equal(0, patchResult.Properties.Status.FailureCount);
                Assert.Equal(0, patchResult.Properties.Status.FaultedCount);

                client.JobCollections.Delete(resourceGroupName, jobCollectionName);
            }
        }

        [Fact]
        public void Scenario_JobCreateUpdateDeleteServiceBusQueueJob()
        {
            using (MockContext context = MockContext.Start("Scheduler.Test.ScenarioTests.JobTests"))
            {
                string jobCollectionName = TestUtilities.GenerateName("jc1");
                string jobName = TestUtilities.GenerateName("j1");
                string jobDefinitionname = string.Format("{0}/{1}", jobCollectionName, jobName);
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}/jobs/{3}", subscriptionId, resourceGroupName, jobCollectionName, jobName);

                // [SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
                var sasKey = "ThisIsFakeSasKey";
                var sasKeyName = "RootManageSharedAccessKey";
                var contentType = "Application/Json";
                var brokerMessageProperties = new ServiceBusBrokeredMessageProperties()
                {
                    ContentType = contentType,
                    TimeToLive = TimeSpan.FromSeconds(5),
                };
                var customMessageProperties = new Dictionary<string, string>();
                customMessageProperties.Add("customMessagePropertyName", "customMessagePropertyValue");
                var message = "Some Message!";
                var namespaceProperty = "scheduler-sdk-ns";
                var queueName = "scheduler-sdk-queue";
                var topicPath = "scheduler-sdk-topic";

                var client = context.GetServiceClient<SchedulerManagementClient>();
                this.CreateJobCollection(client, jobCollectionName);

                var header = new Dictionary<string, string>();
                header.Add("content-type", "application/xml");

                var result = client.Jobs.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 13),
                            Action = new JobAction()
                            {
                                Type = JobActionType.ServiceBusQueue,
                                ServiceBusQueueMessage = new ServiceBusQueueMessage()
                                {
                                    Authentication = new ServiceBusAuthentication()
                                    {
                                        SasKey = sasKey,
                                        SasKeyName = sasKeyName,
                                        Type = ServiceBusAuthenticationType.SharedAccessKey,
                                    },
                                    BrokeredMessageProperties = brokerMessageProperties,
                                    CustomMessageProperties = customMessageProperties,
                                    Message = message,
                                    NamespaceProperty = namespaceProperty,
                                    QueueName = queueName,
                                    TransportType = ServiceBusTransportType.NetMessaging,
                                },
                                RetryPolicy = new RetryPolicy()
                                {
                                    RetryType = RetryType.Fixed,
                                    RetryCount = 2,
                                    RetryInterval = TimeSpan.FromMinutes(1),
                                },
                                ErrorAction = new JobErrorAction()
                                {
                                    Type = JobActionType.ServiceBusTopic,
                                    ServiceBusTopicMessage = new ServiceBusTopicMessage()
                                    {
                                        Authentication = new ServiceBusAuthentication()
                                        {
                                            SasKey = sasKey,
                                            SasKeyName = sasKeyName,
                                            Type = ServiceBusAuthenticationType.SharedAccessKey,
                                        },
                                        BrokeredMessageProperties = brokerMessageProperties,
                                        CustomMessageProperties = customMessageProperties,
                                        Message = message,
                                        NamespaceProperty = namespaceProperty,
                                        TopicPath = topicPath,
                                        TransportType = ServiceBusTransportType.NetMessaging,
                                    },
                                }
                            },
                            Recurrence = new JobRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Week,
                                Interval = 1,
                                Count = 10000,
                                EndTime = JobTests.EndTime,
                            },
                            State = JobState.Enabled,
                        }
                    });

                Assert.Equal(id, result.Id);
                Assert.Equal(type, result.Type);
                Assert.Equal(jobDefinitionname, result.Name);

                Assert.Equal(JobActionType.ServiceBusQueue, result.Properties.Action.Type);
                Assert.Null(result.Properties.Action.ServiceBusQueueMessage.Authentication.SasKey);
                Assert.Equal(sasKeyName, result.Properties.Action.ServiceBusQueueMessage.Authentication.SasKeyName);
                Assert.Equal(ServiceBusAuthenticationType.SharedAccessKey, result.Properties.Action.ServiceBusQueueMessage.Authentication.Type);
                Assert.Equal(contentType, result.Properties.Action.ServiceBusQueueMessage.BrokeredMessageProperties.ContentType);
                Assert.Equal(customMessageProperties, result.Properties.Action.ServiceBusQueueMessage.CustomMessageProperties);
                Assert.Equal(message, result.Properties.Action.ServiceBusQueueMessage.Message);
                Assert.Equal(namespaceProperty, result.Properties.Action.ServiceBusQueueMessage.NamespaceProperty);
                Assert.Equal(queueName, result.Properties.Action.ServiceBusQueueMessage.QueueName);
                Assert.Equal(ServiceBusTransportType.NetMessaging, result.Properties.Action.ServiceBusQueueMessage.TransportType);

                Assert.Equal(RetryType.Fixed, result.Properties.Action.RetryPolicy.RetryType);
                Assert.Equal(2, result.Properties.Action.RetryPolicy.RetryCount);
                Assert.Equal(TimeSpan.FromMinutes(1), result.Properties.Action.RetryPolicy.RetryInterval);

                Assert.Equal(JobActionType.ServiceBusTopic, result.Properties.Action.ErrorAction.Type);
                Assert.Null(result.Properties.Action.ErrorAction.ServiceBusTopicMessage.Authentication.SasKey);
                Assert.Equal(sasKeyName, result.Properties.Action.ErrorAction.ServiceBusTopicMessage.Authentication.SasKeyName);
                Assert.Equal(ServiceBusAuthenticationType.SharedAccessKey, result.Properties.Action.ErrorAction.ServiceBusTopicMessage.Authentication.Type);
                Assert.Equal(contentType, result.Properties.Action.ErrorAction.ServiceBusTopicMessage.BrokeredMessageProperties.ContentType);
                Assert.Equal(customMessageProperties, result.Properties.Action.ErrorAction.ServiceBusTopicMessage.CustomMessageProperties);
                Assert.Equal(message, result.Properties.Action.ErrorAction.ServiceBusTopicMessage.Message);
                Assert.Equal(namespaceProperty, result.Properties.Action.ErrorAction.ServiceBusTopicMessage.NamespaceProperty);
                Assert.Equal(topicPath, result.Properties.Action.ErrorAction.ServiceBusTopicMessage.TopicPath);
                Assert.Equal(ServiceBusTransportType.NetMessaging, result.Properties.Action.ErrorAction.ServiceBusTopicMessage.TransportType);

                Assert.Equal(JobState.Enabled, result.Properties.State);
                Assert.Equal(RecurrenceFrequency.Week, result.Properties.Recurrence.Frequency);
                Assert.Equal(1, result.Properties.Recurrence.Interval);
                Assert.Equal(10000, result.Properties.Recurrence.Count);
                Assert.Equal(JobTests.EndTime, result.Properties.Recurrence.EndTime);
                Assert.Null(result.Properties.Status.LastExecutionTime);
                Assert.Equal(0, result.Properties.Status.ExecutionCount);
                Assert.Equal(0, result.Properties.Status.FailureCount);
                Assert.Equal(0, result.Properties.Status.FaultedCount);

                var updateResult = client.Jobs.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 13),
                            Action = new JobAction()
                            {
                                Type = JobActionType.Http,
                                Request = new HttpRequest()
                                {
                                    Uri = "http://www.bing.com/",
                                    Method = "GET",
                                }
                            },
                            State = JobState.Disabled,
                        }
                    });

                Assert.Equal(id, updateResult.Id);
                Assert.Equal(type, updateResult.Type);
                Assert.Equal(jobDefinitionname, updateResult.Name);
                Assert.Equal(JobActionType.Http, updateResult.Properties.Action.Type);
                Assert.Equal("http://www.bing.com/", updateResult.Properties.Action.Request.Uri);
                Assert.Equal("GET", updateResult.Properties.Action.Request.Method);
                Assert.Null(updateResult.Properties.Action.Request.Body);
                Assert.Null(updateResult.Properties.Action.RetryPolicy);
                Assert.Null(updateResult.Properties.Action.ErrorAction);
                Assert.Equal(JobState.Disabled, updateResult.Properties.State);
                Assert.Null(updateResult.Properties.Recurrence);
                Assert.Null(updateResult.Properties.Status);

                client.JobCollections.Delete(resourceGroupName, jobCollectionName);
            }
        }

        [Fact]
        public void Scenario_JobCreateUpdateDeleteServiceBusTopicJob()
        {
            using (MockContext context = MockContext.Start("Scheduler.Test.ScenarioTests.JobTests"))
            {
                string jobCollectionName = TestUtilities.GenerateName("jc1");
                string jobName = TestUtilities.GenerateName("j1");
                string jobDefinitionname = string.Format("{0}/{1}", jobCollectionName, jobName);
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}/jobs/{3}", subscriptionId, resourceGroupName, jobCollectionName, jobName);

                // [SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
                var sasKey = "ThisIsFakeSasKey";
                var sasKeyName = "RootManageSharedAccessKey";
                var contentType = "Application/Json";
                var brokerMessageProperties = new ServiceBusBrokeredMessageProperties()
                {
                    ContentType = contentType,
                };
                var customMessageProperties = new Dictionary<string, string>();
                customMessageProperties.Add("customMessagePropertyName", "customMessagePropertyValue");
                var message = "Some Message!";
                var namespaceProperty = "scheduler-sdk-ns";
                var queueName = "scheduler-sdk-queue";
                var topicPath = "scheduler-sdk-topic";

                var client = context.GetServiceClient<SchedulerManagementClient>();
                this.CreateJobCollection(client, jobCollectionName);

                var header = new Dictionary<string, string>();
                header.Add("content-type", "application/xml");

                var result = client.Jobs.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 13),
                            Action = new JobAction()
                            {
                                Type = JobActionType.ServiceBusTopic,
                                ServiceBusTopicMessage = new ServiceBusTopicMessage()
                                {
                                    Authentication = new ServiceBusAuthentication()
                                    {
                                        SasKey = sasKey,
                                        SasKeyName = sasKeyName,
                                        Type = ServiceBusAuthenticationType.SharedAccessKey,
                                    },
                                    BrokeredMessageProperties = brokerMessageProperties,
                                    CustomMessageProperties = customMessageProperties,
                                    Message = message,
                                    NamespaceProperty = namespaceProperty,
                                    TopicPath = topicPath,
                                    TransportType = ServiceBusTransportType.NetMessaging,
                                },
                                RetryPolicy = new RetryPolicy()
                                {
                                    RetryType = RetryType.Fixed,
                                    RetryCount = 2,
                                    RetryInterval = TimeSpan.FromMinutes(1),
                                },
                                ErrorAction = new JobErrorAction()
                                {
                                    Type = JobActionType.ServiceBusQueue,
                                    ServiceBusQueueMessage = new ServiceBusQueueMessage()
                                    {
                                        Authentication = new ServiceBusAuthentication()
                                        {
                                            SasKey = sasKey,
                                            SasKeyName = sasKeyName,
                                            Type = ServiceBusAuthenticationType.SharedAccessKey,
                                        },
                                        BrokeredMessageProperties = brokerMessageProperties,
                                        CustomMessageProperties = customMessageProperties,
                                        Message = message,
                                        NamespaceProperty = namespaceProperty,
                                        QueueName = queueName,
                                        TransportType = ServiceBusTransportType.NetMessaging,
                                    },
                                }
                            },
                            Recurrence = new JobRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Week,
                                Interval = 1,
                                Count = 10000,
                                EndTime = JobTests.EndTime,
                            },
                            State = JobState.Enabled,
                        }
                    });

                Assert.Equal(id, result.Id);
                Assert.Equal(type, result.Type);
                Assert.Equal(jobDefinitionname, result.Name);

                Assert.Equal(JobActionType.ServiceBusTopic, result.Properties.Action.Type);
                Assert.Null(result.Properties.Action.ServiceBusTopicMessage.Authentication.SasKey);
                Assert.Equal(sasKeyName, result.Properties.Action.ServiceBusTopicMessage.Authentication.SasKeyName);
                Assert.Equal(ServiceBusAuthenticationType.SharedAccessKey, result.Properties.Action.ServiceBusTopicMessage.Authentication.Type);
                Assert.Equal(contentType, result.Properties.Action.ServiceBusTopicMessage.BrokeredMessageProperties.ContentType);
                Assert.Equal(customMessageProperties, result.Properties.Action.ServiceBusTopicMessage.CustomMessageProperties);
                Assert.Equal(message, result.Properties.Action.ServiceBusTopicMessage.Message);
                Assert.Equal(namespaceProperty, result.Properties.Action.ServiceBusTopicMessage.NamespaceProperty);
                Assert.Equal(topicPath, result.Properties.Action.ServiceBusTopicMessage.TopicPath);
                Assert.Equal(ServiceBusTransportType.NetMessaging, result.Properties.Action.ServiceBusTopicMessage.TransportType);

                Assert.Equal(RetryType.Fixed, result.Properties.Action.RetryPolicy.RetryType);
                Assert.Equal(2, result.Properties.Action.RetryPolicy.RetryCount);
                Assert.Equal(TimeSpan.FromMinutes(1), result.Properties.Action.RetryPolicy.RetryInterval);

                Assert.Equal(JobActionType.ServiceBusQueue, result.Properties.Action.ErrorAction.Type);
                Assert.Null(result.Properties.Action.ErrorAction.ServiceBusQueueMessage.Authentication.SasKey);
                Assert.Equal(sasKeyName, result.Properties.Action.ErrorAction.ServiceBusQueueMessage.Authentication.SasKeyName);
                Assert.Equal(ServiceBusAuthenticationType.SharedAccessKey, result.Properties.Action.ErrorAction.ServiceBusQueueMessage.Authentication.Type);
                Assert.Equal(contentType, result.Properties.Action.ErrorAction.ServiceBusQueueMessage.BrokeredMessageProperties.ContentType);
                Assert.Equal(customMessageProperties, result.Properties.Action.ErrorAction.ServiceBusQueueMessage.CustomMessageProperties);
                Assert.Equal(message, result.Properties.Action.ErrorAction.ServiceBusQueueMessage.Message);
                Assert.Equal(namespaceProperty, result.Properties.Action.ErrorAction.ServiceBusQueueMessage.NamespaceProperty);
                Assert.Equal(queueName, result.Properties.Action.ErrorAction.ServiceBusQueueMessage.QueueName);
                Assert.Equal(ServiceBusTransportType.NetMessaging, result.Properties.Action.ErrorAction.ServiceBusQueueMessage.TransportType);

                Assert.Equal(JobState.Enabled, result.Properties.State);
                Assert.Equal(RecurrenceFrequency.Week, result.Properties.Recurrence.Frequency);
                Assert.Equal(1, result.Properties.Recurrence.Interval);
                Assert.Equal(10000, result.Properties.Recurrence.Count);
                Assert.Equal(JobTests.EndTime, result.Properties.Recurrence.EndTime);
                Assert.Null(result.Properties.Status.LastExecutionTime);
                Assert.Equal(0, result.Properties.Status.ExecutionCount);
                Assert.Equal(0, result.Properties.Status.FailureCount);
                Assert.Equal(0, result.Properties.Status.FaultedCount);

                var updateResult = client.Jobs.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 13),
                            Action = new JobAction()
                            {
                                Type = JobActionType.Http,
                                Request = new HttpRequest()
                                {
                                    Uri = "http://www.bing.com/",
                                    Method = "GET",
                                }
                            },
                            State = JobState.Disabled,
                        }
                    });

                Assert.Equal(id, updateResult.Id);
                Assert.Equal(type, updateResult.Type);
                Assert.Equal(jobDefinitionname, updateResult.Name);
                Assert.Equal(JobActionType.Http, updateResult.Properties.Action.Type);
                Assert.Equal("http://www.bing.com/", updateResult.Properties.Action.Request.Uri);
                Assert.Equal("GET", updateResult.Properties.Action.Request.Method);
                Assert.Null(updateResult.Properties.Action.Request.Body);
                Assert.Null(updateResult.Properties.Action.RetryPolicy);
                Assert.Null(updateResult.Properties.Action.ErrorAction);
                Assert.Equal(JobState.Disabled, updateResult.Properties.State);
                Assert.Null(updateResult.Properties.Recurrence);
                Assert.Null(updateResult.Properties.Status);

                client.JobCollections.Delete(resourceGroupName, jobCollectionName);
            }
        }

        [Fact]
        public void Scenario_JobList()
        {
            using (MockContext context = MockContext.Start("Scheduler.Test.ScenarioTests.JobTests"))
            {
                string jobCollectionName = TestUtilities.GenerateName("jc1");
                string jobName1 = TestUtilities.GenerateName("j1");
                string jobName2 = TestUtilities.GenerateName("j2");
                string jobDefinitionName1 = string.Format("{0}/{1}", jobCollectionName, jobName1);
                string jobDefinitionName2 = string.Format("{0}/{1}", jobCollectionName, jobName2);
                string id1 = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}/jobs/{3}", subscriptionId, resourceGroupName, jobCollectionName, jobName1);
                string id2 = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}/jobs/{3}", subscriptionId, resourceGroupName, jobCollectionName, jobName2);

                var client = context.GetServiceClient<SchedulerManagementClient>();
                this.CreateJobCollection(client, jobCollectionName);

                client.Jobs.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName1,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 13),
                            Action = new JobAction()
                            {
                                Type = JobActionType.Http,
                                Request = new HttpRequest()
                                {
                                    Uri = "http://www.bing.com/",
                                    Method = "GET",
                                }
                            },
                            State = JobState.Enabled,
                        }
                    });

                client.Jobs.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobName: jobName2,
                    job: new JobDefinition()
                    {
                        Properties = new JobProperties()
                        {
                            StartTime = new DateTime(2015, 7, 14),
                            Action = new JobAction()
                            {
                                Type = JobActionType.Http,
                                Request = new HttpRequest()
                                {
                                    Uri = "http://www.google.com/",
                                    Method = "POST",
                                }
                            },
                            State = JobState.Disabled,
                        }
                    });

                var disabledJob = client.Jobs.List(resourceGroupName, jobCollectionName, new ODataQuery<JobStateFilter>(filter => filter.State == JobState.Disabled) { Top = 5 });

                Assert.Equal(1, disabledJob.Count());
                Assert.True(disabledJob.All(job => job.Properties.State == JobState.Disabled));

                var enabledJob = client.Jobs.List(resourceGroupName, jobCollectionName, new ODataQuery<JobStateFilter>(filter => filter.State == JobState.Enabled) { Top = 5 });

                Assert.Equal(1, enabledJob.Count());
                Assert.True(enabledJob.All(job => job.Properties.State == JobState.Enabled));

                var listResult = client.Jobs.List(resourceGroupName, jobCollectionName);

                Assert.Equal(2, listResult.Count());

                var listResult1 = listResult.Where(job => string.Compare(job.Id, id1) == 0).FirstOrDefault();
                var listResult2 = listResult.Where(job => string.Compare(job.Id, id2) == 0).FirstOrDefault();

                Assert.Equal(jobDefinitionName1, listResult1.Name);
                Assert.Equal(new DateTime(2015, 7, 13, 0, 0, 0, DateTimeKind.Utc), listResult1.Properties.StartTime);
                Assert.Equal(JobActionType.Http, listResult1.Properties.Action.Type);
                Assert.Equal("http://www.bing.com/", listResult1.Properties.Action.Request.Uri);
                Assert.Equal("GET", listResult1.Properties.Action.Request.Method);
                Assert.Equal(JobState.Enabled, listResult1.Properties.State);

                Assert.Equal(jobDefinitionName2, listResult2.Name);
                Assert.Equal(new DateTime(2015, 7, 14, 0, 0, 0, DateTimeKind.Utc), listResult2.Properties.StartTime);
                Assert.Equal(JobActionType.Http, listResult2.Properties.Action.Type);
                Assert.Equal("http://www.google.com/", listResult2.Properties.Action.Request.Uri);
                Assert.Equal("POST", listResult2.Properties.Action.Request.Method);
                Assert.Equal(JobState.Disabled, listResult2.Properties.State);

                client.JobCollections.Delete(resourceGroupName, jobCollectionName);
            }
        }

        [Fact]
        public void Scenario_JobHistoryList()
        {
            using (MockContext context = MockContext.Start("Scheduler.Test.ScenarioTests.JobTests"))
            {
                const string existingJobCollectionName = "sdk-test";
                const string existingJobName = "http_job";
                const string historyType = "Microsoft.Scheduler/jobCollections/jobs/history";
                string jobDefinitionName = string.Format("{0}/{1}", existingJobCollectionName, existingJobName);
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}/jobs/{3}", subscriptionId, resourceGroupName, existingJobCollectionName, existingJobName);

                var client = context.GetServiceClient<SchedulerManagementClient>();

                var completedHistories = client.Jobs.ListJobHistory(resourceGroupName, existingJobCollectionName, existingJobName, new ODataQuery<JobHistoryFilter>(filter => filter.Status == JobExecutionStatus.Completed));

                Assert.True(completedHistories.Count() >= 0);
                Assert.True(completedHistories.All(history => history.Properties.Status == null));

                var failedHistories = client.Jobs.ListJobHistory(resourceGroupName, existingJobCollectionName, existingJobName, new ODataQuery<JobHistoryFilter>(filter => filter.Status == JobExecutionStatus.Failed));

                Assert.True(failedHistories.Count() >= 0);
                Assert.True(failedHistories.All(history => history.Properties.Status == JobExecutionStatus.Failed));

                var listTopResult = client.Jobs.ListJobHistory(resourceGroupName, existingJobCollectionName, existingJobName, new ODataQuery<JobHistoryFilter> { Top = 5 });
                var listSkipResult = client.Jobs.ListJobHistory(resourceGroupName, existingJobCollectionName, existingJobName, new ODataQuery<JobHistoryFilter> { Top = 5, Skip = 5 });
                var listResult = client.Jobs.ListJobHistory(resourceGroupName, existingJobCollectionName, existingJobName);

                Assert.True(listResult.Count() >= 0);
                Assert.True(listResult.ElementAt(0).Id.Contains(id));
                Assert.True(listResult.ElementAt(0).Name.Contains(jobDefinitionName));
                Assert.Equal(historyType, listResult.ElementAt(0).Type);
                Assert.Equal(JobHistoryActionName.MainAction, listResult.ElementAt(0).Properties.ActionName);
                Assert.NotNull(listResult.ElementAt(0).Properties.EndTime);
                Assert.NotNull(listResult.ElementAt(0).Properties.ExpectedExecutionTime);
                Assert.NotNull(listResult.ElementAt(0).Properties.Message);
                Assert.True(listResult.ElementAt(0).Properties.RepeatCount > 0);
                Assert.True(listResult.ElementAt(0).Properties.RetryCount >= 0);
                Assert.NotNull(listResult.ElementAt(0).Properties.StartTime);
                
                Assert.True(listTopResult.Count() == 5);
                Assert.Equal(listResult.ElementAt(0).Type, listTopResult.ElementAt(0).Type);
                Assert.Equal(listResult.ElementAt(0).Properties.ActionName, listTopResult.ElementAt(0).Properties.ActionName);
                Assert.Equal(listResult.ElementAt(0).Properties.EndTime, listTopResult.ElementAt(0).Properties.EndTime);
                Assert.Equal(listResult.ElementAt(0).Properties.ExpectedExecutionTime, listTopResult.ElementAt(0).Properties.ExpectedExecutionTime);
                Assert.Equal(listResult.ElementAt(0).Properties.Message, listTopResult.ElementAt(0).Properties.Message);
                Assert.Equal(listResult.ElementAt(0).Properties.RepeatCount, listTopResult.ElementAt(0).Properties.RepeatCount);
                Assert.Equal(listResult.ElementAt(0).Properties.RetryCount, listTopResult.ElementAt(0).Properties.RetryCount);
                Assert.Equal(listResult.ElementAt(0).Properties.StartTime, listTopResult.ElementAt(0).Properties.StartTime);

                Assert.True(listSkipResult.Count() == 5);
                Assert.True(listTopResult.ElementAt(0).Properties.EndTime > listSkipResult.ElementAt(0).Properties.EndTime);
                Assert.True(listTopResult.ElementAt(0).Properties.ExpectedExecutionTime > listSkipResult.ElementAt(0).Properties.ExpectedExecutionTime);
                Assert.True(listTopResult.ElementAt(0).Properties.StartTime > listSkipResult.ElementAt(0).Properties.StartTime);
            }
        }

        private void CreateJobCollection(SchedulerManagementClient client, string jobCollectionName)
        {
            client.JobCollections.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                jobCollectionName: jobCollectionName,
                jobCollection: new JobCollectionDefinition()
                {
                    Name = jobCollectionName,
                    Location = location,
                    Properties = new JobCollectionProperties()
                    {
                        Sku = new Sku()
                        {
                            Name = SkuDefinition.Standard,
                        },
                        State = JobCollectionState.Enabled,
                        Quota = new JobCollectionQuota()
                        {
                            MaxJobCount = 50,
                            MaxRecurrence = new JobMaxRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Minute,
                                Interval = 1,
                            }
                        }
                    }
                });
        }
    }
}