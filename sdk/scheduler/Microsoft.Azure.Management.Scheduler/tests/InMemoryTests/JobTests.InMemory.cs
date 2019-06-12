﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure;
using Microsoft.Azure.Management.Scheduler;
using Microsoft.Azure.Management.Scheduler.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Scheduler.Test.Helpers;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Scheduler.Test.InMemoryTests
{
    public class JobTests : Base
    {
        #region APIs

        [Fact]
        public void InMemory_JobGet()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1/jobs/j1',
	                'type': 'Microsoft.Scheduler/jobCollections/jobs',
	                'name': 'jc1/j1',
	                'properties': {
		                'action': {
			                'queueMessage': {
				                'storageAccount': 'schedulersdktest',
				                'queueName': 'queue1',
				                'message': 'May 14 is the start date.'
			                },
			                'type': 'storageQueue'
		                },
		                'recurrence': {
			                'frequency': 'minute',
			                'endTime': '2015-06-14T07:00:00Z',
			                'interval': 1
		                },
		                'state': 'completed',
		                'status': {
			                'lastExecutionTime': '2015-06-14T06:59:03Z',
			                'executionCount': 40222,
			                'failureCount': 0,
			                'faultedCount': 0
		                }
	                }
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetSchedulerManagementClient(handler);

            var result = client.Jobs.Get("foo", "jc1", "j1");

            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1/jobs/j1", result.Id);
            Assert.Equal("Microsoft.Scheduler/jobCollections/jobs", result.Type);
            Assert.Equal("jc1/j1", result.Name);
            Assert.Equal("schedulersdktest", result.Properties.Action.QueueMessage.StorageAccount);
            Assert.Equal("queue1", result.Properties.Action.QueueMessage.QueueName);
            Assert.Equal("May 14 is the start date.", result.Properties.Action.QueueMessage.Message);
            Assert.Equal(RecurrenceFrequency.Minute, result.Properties.Recurrence.Frequency);
            Assert.Equal(new DateTime(2015, 6, 14, 7, 0, 0, DateTimeKind.Utc), result.Properties.Recurrence.EndTime);
            Assert.Equal(1, result.Properties.Recurrence.Interval);
            Assert.Equal(JobState.Completed, result.Properties.State);
            Assert.Equal(new DateTime(2015, 6, 14, 6, 59, 3, DateTimeKind.Utc), result.Properties.Status.LastExecutionTime);
            Assert.Equal(40222, result.Properties.Status.ExecutionCount);
            Assert.Equal(0, result.Properties.Status.FailureCount);
            Assert.Equal(0, result.Properties.Status.FaultedCount);
        }

        [Fact]
        public void InMemory_JobCreateUpdateDelete()
        {
            var createRresponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                  'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1/jobs/j1',
	                'type': 'Microsoft.Scheduler/jobCollections/jobs',
	                'name': 'jc1/j1',
	                'properties': {
		                'action': {
			                'request': {
				                'uri': 'http://www.bing.com/',
				                'method': 'GET',
                                'body': 'some body message!',
			                },
			                'type': 'http',
                            'retryPolicy': {
                                'retryType': 'Fixed',
                                'retryCount': '2',
                                'retryInterval': '00:01:00',
                            },
		                },
		                'recurrence': {
			                'frequency': 'week',
                            'endTime': '2015-06-14T07:00:00Z',
			                'interval': 1
		                },
		                'state': 'enabled',
		                'status': {
			                'lastExecutionTime': '2015-06-14T06:59:03Z',
			                'executionCount': 12345,
			                'failureCount': 123,
			                'faultedCount': 234
		                }
	                }
                }")
            };
            createRresponse.Headers.Add("x-ms-request-id", "1");
            var createHandler = new RecordedDelegatingHandler(createRresponse) { StatusCodeToReturn = HttpStatusCode.Created };
            var createClient = this.GetSchedulerManagementClient(createHandler);

            var result = createClient.Jobs.CreateOrUpdate(
                resourceGroupName: "foo",
                jobCollectionName: "jc1",
                jobName: "j1",
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
                                Uri = "http://www.bing.com",
                                Method = "GET",
                                Body = "some body message!"
                            }
                        },
                        Recurrence = new JobRecurrence()
                        {
                            Frequency = RecurrenceFrequency.Week,
                            Interval = 1
                        },
                        State = JobState.Enabled,
                    }
                });

            Assert.Equal(HttpMethod.Put, createHandler.Method);
            Assert.NotNull(createHandler.RequestHeaders.GetValues("Authorization"));

            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1/jobs/j1", result.Id);
            Assert.Equal("Microsoft.Scheduler/jobCollections/jobs", result.Type);
            Assert.Equal("jc1/j1", result.Name);
            Assert.Equal("http://www.bing.com/", result.Properties.Action.Request.Uri);
            Assert.Equal("GET", result.Properties.Action.Request.Method);
            Assert.Equal("some body message!", result.Properties.Action.Request.Body);
            Assert.Equal(RecurrenceFrequency.Week, result.Properties.Recurrence.Frequency);
            Assert.Equal(new DateTime(2015, 6, 14, 7, 0, 0, DateTimeKind.Utc), result.Properties.Recurrence.EndTime);
            Assert.Equal(1, result.Properties.Recurrence.Interval);
            Assert.Equal(JobState.Enabled, result.Properties.State);
            Assert.Equal(new DateTime(2015, 6, 14, 6, 59, 3, DateTimeKind.Utc), result.Properties.Status.LastExecutionTime);
            Assert.Equal(12345, result.Properties.Status.ExecutionCount);
            Assert.Equal(123, result.Properties.Status.FailureCount);
            Assert.Equal(234, result.Properties.Status.FaultedCount);

            var deleteHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            var deleteClient = this.GetSchedulerManagementClient(deleteHandler);
            deleteClient.Jobs.Delete("foo", "jc1", "j1");
        }

        [Fact]
        public void InMemory_JobPatch()
        {
            var createResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                  'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1/jobs/j1',
	                'type': 'Microsoft.Scheduler/jobCollections/jobs',
	                'name': 'jc1/j1',
	                'properties': {
		                'action': {
			                'request': {
				                'uri': 'http://www.bing.com/',
				                'method': 'GET'
			                },
			                'type': 'http'
		                },
		                'recurrence': {
			                'frequency': 'week',
                            'endTime': '2015-06-14T07:00:00Z',
			                'interval': 1
		                },
		                'state': 'enabled',
		                'status': {
			                'lastExecutionTime': '2015-06-14T06:59:03Z',
			                'executionCount': 12345,
			                'failureCount': 123,
			                'faultedCount': 234
		                }
	                }
                }")
            };
            createResponse.Headers.Add("x-ms-request-id", "1");
            var createHandler = new RecordedDelegatingHandler(createResponse) { StatusCodeToReturn = HttpStatusCode.OK };
            var createClient = this.GetSchedulerManagementClient(createHandler);

            var result = createClient.Jobs.CreateOrUpdate(
                resourceGroupName: "foo",
                jobCollectionName: "jc1",
                jobName: "j1",
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
                                Uri = "http://www.bing.com",
                                Method = "GET",
                            }
                        },
                        Recurrence = new JobRecurrence()
                        {
                            Frequency = RecurrenceFrequency.Week,
                            Interval = 1
                        },
                        State = JobState.Enabled,
                    }
                });

            var patchResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                  'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1/jobs/j1',
	                'type': 'Microsoft.Scheduler/jobCollections/jobs',
	                'name': 'jc1/j1',
	                'properties': {
                        'startTime': '2014-06-14T07:00:00Z',
		                'action': {
			                'request': {
				                'uri': 'http://www.google.com/',
				                'method': 'POST'
			                },
			                'type': 'https'
		                },
		                'recurrence': {
			                'frequency': 'day',
                            'endTime': '2015-06-14T07:00:00Z',
			                'interval': 2
		                },
		                'state': 'enabled',
		                'status': {
			                'lastExecutionTime': '2015-06-14T06:59:03Z',
			                'executionCount': 12345,
			                'failureCount': 123,
			                'faultedCount': 234
		                }
	                }
                }")
            };
            patchResponse.Headers.Add("x-ms-request-id", "1");
            var patchHandler = new RecordedDelegatingHandler(patchResponse) { StatusCodeToReturn = HttpStatusCode.OK };
            var patchClient = this.GetSchedulerManagementClient(patchHandler);

            var patchResult = patchClient.Jobs.Patch(
               resourceGroupName: "foo",
               jobCollectionName: "jc1",
               jobName: "j1",
               job: new JobDefinition()
               {
                   Properties = new JobProperties()
                   {
                       StartTime = new DateTime(2014, 6, 14, 7, 0, 0, DateTimeKind.Utc),
                       Action = new JobAction()
                       {
                           Type = JobActionType.Https,
                           Request = new HttpRequest()
                           {
                               Uri = "http://www.google.com/",
                               Method = "POST",
                           }
                       },
                       Recurrence = new JobRecurrence()
                       {
                           Frequency = RecurrenceFrequency.Day,
                           Interval = 2
                       }
                   }
               });

            Assert.Equal("PATCH", patchHandler.Method.ToString());
            Assert.NotNull(patchHandler.RequestHeaders.GetValues("Authorization"));

            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1/jobs/j1", patchResult.Id);
            Assert.Equal("Microsoft.Scheduler/jobCollections/jobs", patchResult.Type);
            Assert.Equal("jc1/j1", patchResult.Name);
            Assert.Equal(new DateTime(2014, 6, 14, 7, 0, 0, DateTimeKind.Utc), patchResult.Properties.StartTime);
            Assert.Equal("http://www.google.com/", patchResult.Properties.Action.Request.Uri);
            Assert.Equal("POST", patchResult.Properties.Action.Request.Method);
            Assert.Equal(RecurrenceFrequency.Day, patchResult.Properties.Recurrence.Frequency);
            Assert.Equal(new DateTime(2015, 6, 14, 7, 0, 0, DateTimeKind.Utc), patchResult.Properties.Recurrence.EndTime);
            Assert.Equal(2, patchResult.Properties.Recurrence.Interval);
            Assert.Equal(JobState.Enabled, patchResult.Properties.State);
            Assert.Equal(new DateTime(2015, 6, 14, 6, 59, 3, DateTimeKind.Utc), patchResult.Properties.Status.LastExecutionTime);
            Assert.Equal(12345, patchResult.Properties.Status.ExecutionCount);
            Assert.Equal(123, patchResult.Properties.Status.FailureCount);
            Assert.Equal(234, patchResult.Properties.Status.FaultedCount);

            var deleteHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            var deleteClient = this.GetSchedulerManagementClient(deleteHandler);
            deleteClient.Jobs.Delete("foo", "jc1", "j1");
        }

        [Fact]
        public void InMemory_JobListJobs()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
	                'value': [{
		                'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1/jobs/j1',
	                    'type': 'Microsoft.Scheduler/jobCollections/jobs',
	                    'name': 'jc1/j1',
	                    'properties': {
		                    'action': {
			                    'queueMessage': {
				                    'storageAccount': 'schedulersdktest',
				                    'queueName': 'queue1',
				                    'message': 'May 14 is the start date.'
			                    },
			                    'type': 'storageQueue'
		                    },
		                    'recurrence': {
			                    'frequency': 'minute',
			                    'endTime': '2015-06-14T07:00:00Z',
			                    'interval': 1
		                    },
		                    'state': 'completed',
		                    'status': {
			                    'lastExecutionTime': '2015-06-14T06:59:03Z',
			                    'executionCount': 40222,
			                    'failureCount': 0,
			                    'faultedCount': 0
		                    }
	                    }
	                },
	                {
		                'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1/jobs/j2',
	                    'type': 'Microsoft.Scheduler/jobCollections/jobs',
	                    'name': 'jc1/j1',
	                    'properties': {
		                    'action': {
			                    'request': {
				                    'uri': 'http://www.bing.com/',
				                    'method': 'GET'
			                    },
			                    'type': 'http'
		                    },
		                    'recurrence': {
			                    'frequency': 'week',
                                'endTime': '2015-06-14T07:00:00Z',
			                    'interval': 1
		                    },
		                    'state': 'enabled',
		                    'status': {
			                    'lastExecutionTime': '2015-06-14T06:59:03Z',
			                    'executionCount': 12345,
			                    'failureCount': 123,
			                    'faultedCount': 234
		                    }
	                    }
	                    }],
	                'nextLink': null
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetSchedulerManagementClient(handler);

            var result = client.Jobs.List("foo", "jc1");

            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            Assert.Null(result.NextPageLink);

            var job1 = result.Where(job => string.Compare(job.Id, "/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1/jobs/j1") == 0).FirstOrDefault();
            Assert.NotNull(job1);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1/jobs/j1", job1.Id);
            Assert.Equal("Microsoft.Scheduler/jobCollections/jobs", job1.Type);
            Assert.Equal("jc1/j1", job1.Name);
            Assert.Equal("schedulersdktest", job1.Properties.Action.QueueMessage.StorageAccount);
            Assert.Equal("queue1", job1.Properties.Action.QueueMessage.QueueName);
            Assert.Equal("May 14 is the start date.", job1.Properties.Action.QueueMessage.Message);
            Assert.Equal(RecurrenceFrequency.Minute, job1.Properties.Recurrence.Frequency);
            Assert.Equal(new DateTime(2015, 6, 14, 7, 0, 0, DateTimeKind.Utc), job1.Properties.Recurrence.EndTime);
            Assert.Equal(1, job1.Properties.Recurrence.Interval);
            Assert.Equal(JobState.Completed, job1.Properties.State);
            Assert.Equal(new DateTime(2015, 6, 14, 6, 59, 3, DateTimeKind.Utc), job1.Properties.Status.LastExecutionTime);
            Assert.Equal(40222, job1.Properties.Status.ExecutionCount);
            Assert.Equal(0, job1.Properties.Status.FailureCount);
            Assert.Equal(0, job1.Properties.Status.FaultedCount);

            var job2 = result.Where(job => string.Compare(job.Id, "/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1/jobs/j2") == 0).FirstOrDefault();
            Assert.NotNull(job2);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1/jobs/j2", job2.Id);
            Assert.Equal("Microsoft.Scheduler/jobCollections/jobs", job2.Type);
            Assert.Equal("jc1/j1", job2.Name);
            Assert.Equal("http://www.bing.com/", job2.Properties.Action.Request.Uri);
            Assert.Equal("GET", job2.Properties.Action.Request.Method);
            Assert.Equal(RecurrenceFrequency.Week, job2.Properties.Recurrence.Frequency);
            Assert.Equal(new DateTime(2015, 6, 14, 7, 0, 0, DateTimeKind.Utc), job2.Properties.Recurrence.EndTime);
            Assert.Equal(1, job2.Properties.Recurrence.Interval);
            Assert.Equal(JobState.Enabled, job2.Properties.State);
            Assert.Equal(new DateTime(2015, 6, 14, 6, 59, 3, DateTimeKind.Utc), job2.Properties.Status.LastExecutionTime);
            Assert.Equal(12345, job2.Properties.Status.ExecutionCount);
            Assert.Equal(123, job2.Properties.Status.FailureCount);
            Assert.Equal(234, job2.Properties.Status.FaultedCount);
        }

        [Fact]
        public void InMemory_JobListJobHistories()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
	                'value': [{
		                'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1/jobs/j1/history/02519680374658540720:09223372036854743747',
		                'type': 'Microsoft.Scheduler/jobCollections/jobs/history',
		                'name': 'jc1/j1/02519680374658540720:09223372036854743747',
		                'properties': {
			                'startTime': '2015-06-14T06:28:54Z',
			                'endTime': '2015-06-14T06:28:55Z',
			                'expectedExecutionTime': '2015-06-14T06:28:42Z',
			                'message': 'some message!',
			                'retryCount': 0,
			                'repeatCount': 727,
			                'actionName': 'MainAction'
		                }
	                },
	                {
		                'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1/jobs/j1/history/02519680410779413923:09223372036854745549',
		                'type': 'Microsoft.Scheduler/jobCollections/jobs/history',
		                'name': 'jc1/j1/02519680410779413923:09223372036854745549',
		                'properties': {
			                'startTime': '2015-06-14T05:28:42Z',
			                'endTime': '2015-06-14T05:28:42Z',
			                'expectedExecutionTime': '2015-06-14T05:28:25Z',
			                'message': 'some message!',
			                'retryCount': 0,
			                'repeatCount': 726,
			                'actionName': 'MainAction'
		                }
	                }],
	                'nextLink': null
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetSchedulerManagementClient(handler);

            var result = client.Jobs.ListJobHistory("foo", "jc1", "j1");

            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            Assert.Null(result.NextPageLink);

            var history1 = result.Where(history => string.Compare(history.Id, "/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1/jobs/j1/history/02519680374658540720:09223372036854743747") == 0).FirstOrDefault();
            Assert.NotNull(history1);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1/jobs/j1/history/02519680374658540720:09223372036854743747", history1.Id);
            Assert.Equal("Microsoft.Scheduler/jobCollections/jobs/history", history1.Type);
            Assert.Equal("jc1/j1/02519680374658540720:09223372036854743747", history1.Name);
            Assert.Equal(new DateTime(2015, 6, 14, 6, 28, 54, DateTimeKind.Utc), history1.Properties.StartTime);
            Assert.Equal(new DateTime(2015, 6, 14, 6, 28, 55, DateTimeKind.Utc), history1.Properties.EndTime);
            Assert.Equal(new DateTime(2015, 6, 14, 6, 28, 42, DateTimeKind.Utc), history1.Properties.ExpectedExecutionTime);
            Assert.Equal("some message!", history1.Properties.Message);
            Assert.Equal(0, history1.Properties.RetryCount);
            Assert.Equal(727, history1.Properties.RepeatCount);
            Assert.Equal(JobHistoryActionName.MainAction, history1.Properties.ActionName);

            var history2 = result.Where(history => string.Compare(history.Id, "/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1/jobs/j1/history/02519680410779413923:09223372036854745549") == 0).FirstOrDefault();
            Assert.NotNull(history2);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1/jobs/j1/history/02519680410779413923:09223372036854745549", history2.Id);
            Assert.Equal("Microsoft.Scheduler/jobCollections/jobs/history", history2.Type);
            Assert.Equal("jc1/j1/02519680410779413923:09223372036854745549", history2.Name);
            Assert.Equal(new DateTime(2015, 6, 14, 5, 28, 42, DateTimeKind.Utc), history2.Properties.StartTime);
            Assert.Equal(new DateTime(2015, 6, 14, 5, 28, 42, DateTimeKind.Utc), history2.Properties.EndTime);
            Assert.Equal(new DateTime(2015, 6, 14, 5, 28, 25, DateTimeKind.Utc), history2.Properties.ExpectedExecutionTime);
            Assert.Equal("some message!", history2.Properties.Message);
            Assert.Equal(0, history2.Properties.RetryCount);
            Assert.Equal(726, history2.Properties.RepeatCount);
            Assert.Equal(JobHistoryActionName.MainAction, history2.Properties.ActionName);
        }

        #endregion

        #region Exceptions

        [Fact]
        public void InMemory_JobCreateOrUpdateThrowsException()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var handler = new RecordedDelegatingHandler(response);
            var client = this.GetSchedulerManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Jobs.CreateOrUpdate(
               resourceGroupName: "foo",
               jobCollectionName: null,
               jobName: "j1",
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
                               Uri = "http://www.bing.com",
                               Method = "GET",
                               Body = "some body message!"
                           }
                       },
                       Recurrence = new JobRecurrence()
                       {
                           Frequency = RecurrenceFrequency.Week,
                           Interval = 1
                       },
                       State = JobState.Enabled,
                   }
               }));

            Assert.Throws<ValidationException>(() => client.Jobs.Patch(
               resourceGroupName: "fpp",
               jobCollectionName: "bar",
               jobName: null,
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
                               Uri = "http://www.bing.com",
                               Method = "GET",
                               Body = "some body message!"
                           }
                       },
                       Recurrence = new JobRecurrence()
                       {
                           Frequency = RecurrenceFrequency.Week,
                           Interval = 1
                       },
                       State = JobState.Enabled,
                   }
               }));

            Assert.Throws<ValidationException>(() => client.Jobs.Patch(
               resourceGroupName: "foo",
               jobCollectionName: "bar",
               jobName: null,
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
                               Uri = "http://www.bing.com",
                               Method = "GET",
                               Body = "some body message!"
                           }
                       },
                       Recurrence = new JobRecurrence()
                       {
                           Frequency = RecurrenceFrequency.Week,
                           Interval = 1
                       },
                       State = JobState.Enabled,
                   }
               }));

            Assert.Throws<ValidationException>(() => client.Jobs.Patch(
               resourceGroupName: "foo",
               jobCollectionName: "bar",
               jobName: "jn1",
               job: null));

            Assert.Throws<CloudException>(() => client.Jobs.Patch(
               resourceGroupName: "fpp",
               jobCollectionName: "bar",
               jobName: "jn1",
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
                               Uri = "http://www.bing.com",
                               Method = "GET",
                               Body = "some body message!"
                           }
                       },
                       Recurrence = new JobRecurrence()
                       {
                           Frequency = RecurrenceFrequency.Week,
                           Interval = 1
                       },
                       State = JobState.Enabled,
                   }
               }));
        }

        [Fact]
        public void InMemory_JobPatchThrowsException()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var handler = new RecordedDelegatingHandler(response);
            var client = this.GetSchedulerManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Jobs.Patch(
               resourceGroupName: "foo",
               jobCollectionName: null,
               jobName: "j1",
               job: new JobDefinition()
               {
                   Properties = new JobProperties()
                   {
                       StartTime = new DateTime(2014, 6, 14, 7, 0, 0, DateTimeKind.Utc),
                       Action = new JobAction()
                       {
                           Type = JobActionType.Https,
                           Request = new HttpRequest()
                           {
                               Uri = "http://www.google.com/",
                               Method = "POST",
                           }
                       },
                       Recurrence = new JobRecurrence()
                       {
                           Frequency = RecurrenceFrequency.Day,
                           Interval = 2
                       }
                   }
               }));

            Assert.Throws<ValidationException>(() => client.Jobs.Patch(
               resourceGroupName: "fpp",
               jobCollectionName: "bar",
               jobName: null,
               job: new JobDefinition()
               {
                   Properties = new JobProperties()
                   {
                       StartTime = new DateTime(2014, 6, 14, 7, 0, 0, DateTimeKind.Utc),
                       Action = new JobAction()
                       {
                           Type = JobActionType.Https,
                           Request = new HttpRequest()
                           {
                               Uri = "http://www.google.com/",
                               Method = "POST",
                           }
                       },
                       Recurrence = new JobRecurrence()
                       {
                           Frequency = RecurrenceFrequency.Day,
                           Interval = 2
                       }
                   }
               }));

            Assert.Throws<ValidationException>(() => client.Jobs.Patch(
               resourceGroupName: "foo",
               jobCollectionName: "bar",
               jobName: null,
               job: new JobDefinition()
               {
                   Properties = new JobProperties()
                   {
                       StartTime = new DateTime(2014, 6, 14, 7, 0, 0, DateTimeKind.Utc),
                       Action = new JobAction()
                       {
                           Type = JobActionType.Https,
                           Request = new HttpRequest()
                           {
                               Uri = "http://www.google.com/",
                               Method = "POST",
                           }
                       },
                       Recurrence = new JobRecurrence()
                       {
                           Frequency = RecurrenceFrequency.Day,
                           Interval = 2
                       }
                   }
               }));

            Assert.Throws<ValidationException>(() => client.Jobs.Patch(
               resourceGroupName: "foo",
               jobCollectionName: "bar",
               jobName: "jn1",
               job: null));

            Assert.Throws<CloudException>(() => client.Jobs.Patch(
               resourceGroupName: "fpp",
               jobCollectionName: "bar",
               jobName: "jn1",
               job: new JobDefinition()
               {
                   Properties = new JobProperties()
                   {
                       StartTime = new DateTime(2014, 6, 14, 7, 0, 0, DateTimeKind.Utc),
                       Action = new JobAction()
                       {
                           Type = JobActionType.Https,
                           Request = new HttpRequest()
                           {
                               Uri = "http://www.google.com/",
                               Method = "POST",
                           }
                       },
                       Recurrence = new JobRecurrence()
                       {
                           Frequency = RecurrenceFrequency.Day,
                           Interval = 2
                       }
                   }
               }));
        }

        [Fact]
        public void InMemory_JobRunThrowsException()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var handler = new RecordedDelegatingHandler(response);
            var client = this.GetSchedulerManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Jobs.Run(resourceGroupName: null, jobCollectionName: "bar", jobName: "jn1"));
            Assert.Throws<ValidationException>(() => client.Jobs.Run(resourceGroupName: "foo", jobCollectionName: null, jobName: "jn1"));
            Assert.Throws<ValidationException>(() => client.Jobs.Run(resourceGroupName: "foo", jobCollectionName: "bar", jobName: null));
            Assert.Throws<CloudException>(() => client.Jobs.Run(resourceGroupName: "foo", jobCollectionName: "bar", jobName: "jn1"));
        }

        [Fact]
        public void InMemory_JobDeleteThrowsException()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var handler = new RecordedDelegatingHandler(response);
            var client = this.GetSchedulerManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Jobs.Delete(resourceGroupName: null, jobCollectionName: "bar", jobName: "jn1"));
            Assert.Throws<ValidationException>(() => client.Jobs.Delete(resourceGroupName: "foo", jobCollectionName: null, jobName: "jn1"));
            Assert.Throws<ValidationException>(() => client.Jobs.Delete(resourceGroupName: "foo", jobCollectionName: "bar", jobName: null));
            Assert.Throws<CloudException>(() => client.Jobs.Delete(resourceGroupName: "foo", jobCollectionName: "bar", jobName: "jn1"));
        }

        [Fact]
        public void InMemory_JobGetThrowsException()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var handler = new RecordedDelegatingHandler(response);
            var client = this.GetSchedulerManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Jobs.Get(resourceGroupName: null, jobCollectionName: "bar", jobName: "jn1"));
            Assert.Throws<ValidationException>(() => client.Jobs.Get(resourceGroupName: "foo", jobCollectionName: null, jobName: "jn1"));
            Assert.Throws<ValidationException>(() => client.Jobs.Get(resourceGroupName: "foo", jobCollectionName: "bar", jobName: null));
            Assert.Throws<CloudException>(() => client.Jobs.Get(resourceGroupName: "foo", jobCollectionName: "bar", jobName: "jn1"));
        }

        [Fact]
        public void InMemory_JobListThrowsException()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var handler = new RecordedDelegatingHandler(response);
            var client = this.GetSchedulerManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Jobs.List(resourceGroupName: null, jobCollectionName: "bar"));
            Assert.Throws<ValidationException>(() => client.Jobs.List(resourceGroupName: "foo", jobCollectionName: null));
            Assert.Throws<CloudException>(() => client.Jobs.List(resourceGroupName: "foo", jobCollectionName: "bar"));
        }

        [Fact]
        public void InMemory_JobListJobHistoryThrowsException()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var handler = new RecordedDelegatingHandler(response);
            var client = this.GetSchedulerManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Jobs.ListJobHistory(resourceGroupName: null, jobCollectionName: "bar", jobName: "jn1"));
            Assert.Throws<ValidationException>(() => client.Jobs.ListJobHistory(resourceGroupName: "foo", jobCollectionName: null, jobName: "jn1"));
            Assert.Throws<ValidationException>(() => client.Jobs.ListJobHistory(resourceGroupName: "foo", jobCollectionName: "bar", jobName: null));
            Assert.Throws<CloudException>(() => client.Jobs.ListJobHistory(resourceGroupName: "foo", jobCollectionName: "bar", jobName: "jn1"));
        }

        #endregion
    }
}
