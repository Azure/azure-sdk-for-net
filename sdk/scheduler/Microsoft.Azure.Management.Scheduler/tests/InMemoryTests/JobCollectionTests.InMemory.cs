﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure;
using Microsoft.Azure.Management.Scheduler;
using Microsoft.Azure.Management.Scheduler.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Scheduler.Test.Helpers;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Scheduler.Test.InMemoryTests
{
    public class JobCollectionTests : Base
    {
        #region APIs

        [Fact]
        public void InMemory_JobCollectionGet()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                  'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1',
                  'type': 'Microsoft.Scheduler/jobCollections',
                  'name': 'jc1',
                  'location': 'South Central US',
                  'tags' : {
                        'department':'finance',
                        'tagname':'tagvalue'
                    },
                   'properties': {
                        'sku': {
			                'name': 'Standard'
		                },
		                'state': 'Enabled',
		                'quota': {
			                'maxJobCount': 10,
                            'maxJobOccurrence': 50,
			                'maxRecurrence': {
				                'frequency': 'Day',
				                'interval': 1
			                }
		                }
                    }
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetSchedulerManagementClient(handler);

            var result = client.JobCollections.Get("foo", "jc1");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            Assert.Equal("South Central US", result.Location);
            Assert.Equal("Microsoft.Scheduler/jobCollections", result.Type);
            Assert.Equal("jc1", result.Name);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1", result.Id);
            Assert.Equal("finance", result.Tags["department"]);
            Assert.Equal("tagvalue", result.Tags["tagname"]);
            Assert.Equal(SkuDefinition.Standard, result.Properties.Sku.Name);
            Assert.Equal(JobCollectionState.Enabled, result.Properties.State);
            Assert.Equal(10, result.Properties.Quota.MaxJobCount);
            Assert.Equal(50, result.Properties.Quota.MaxJobOccurrence);
            Assert.Equal(RecurrenceFrequency.Day, result.Properties.Quota.MaxRecurrence.Frequency);
            Assert.Equal(1, result.Properties.Quota.MaxRecurrence.Interval);
        }

        [Fact]
        public void InMemory_JobCollectionCreateUpdateDelete()
        {
            var createRresponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                  'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1',
                  'type': 'Microsoft.Scheduler/jobCollections',
                  'name': 'jc1',
                  'location': 'South Central US',
                  'properties': {
                        'sku': {
			                'name': 'Standard'
		                },
		                'state': 'Suspended',
		                'quota': {
			                'maxJobCount': 20,
                            'maxJobOccurrence': 300,
			                'maxRecurrence': {
				                'frequency': 'Week',
				                'interval': 1
			                }
		                }
                    }
                }")
            };
            createRresponse.Headers.Add("x-ms-request-id", "1");
            var createHandler = new RecordedDelegatingHandler(createRresponse) { StatusCodeToReturn = HttpStatusCode.Created };
            var createClient = this.GetSchedulerManagementClient(createHandler);

            var result = createClient.JobCollections.CreateOrUpdate(
                resourceGroupName: "foo",
                jobCollectionName: "jc1",
                jobCollection: new JobCollectionDefinition()
                {
                    Name = "jc1",
                    Location = "South Central US",
                    Properties = new JobCollectionProperties()
                    {
                        Sku = new Sku()
                        {
                            Name = SkuDefinition.Standard,
                        },
                        State = JobCollectionState.Suspended,
                        Quota = new JobCollectionQuota()
                        {
                            MaxJobCount = 20,
                            MaxJobOccurrence = 300,
                            MaxRecurrence = new JobMaxRecurrence() 
                            { 
                                Frequency = RecurrenceFrequency.Week,
                                Interval = 1,
                            }
                        }
                    }
                });

            // Validate headers
            Assert.Equal(HttpMethod.Put, createHandler.Method);
            Assert.NotNull(createHandler.RequestHeaders.GetValues("Authorization"));

            Assert.Equal("South Central US", result.Location);
            Assert.Equal("Microsoft.Scheduler/jobCollections", result.Type);
            Assert.Equal("jc1", result.Name);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1", result.Id);
            Assert.Equal(SkuDefinition.Standard, result.Properties.Sku.Name);
            Assert.Equal(JobCollectionState.Suspended, result.Properties.State);
            Assert.Equal(20, result.Properties.Quota.MaxJobCount);
            Assert.Equal(300, result.Properties.Quota.MaxJobOccurrence);
            Assert.Equal(RecurrenceFrequency.Week, result.Properties.Quota.MaxRecurrence.Frequency);
            Assert.Equal(1, result.Properties.Quota.MaxRecurrence.Interval);

            var deleteHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            var deleteClient = this.GetSchedulerManagementClient(deleteHandler);
            deleteClient.JobCollections.Delete("foo", "jc1");
        }

        [Fact]
        public void InMemory_JobCollectionPatch()
        {
            var createResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                  'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1',
                  'type': 'Microsoft.Scheduler/jobCollections',
                  'name': 'jc1',
                  'location': 'South Central US',
                  'properties': {
                        'sku': {
			                'name': 'Standard'
		                },
		                'state': 'Disabled',
		                'quota': {
			                'maxJobCount': 20,
                            'maxJobOccurrence': 300,
			                'maxRecurrence': {
				                'frequency': 'Week',
				                'interval': 1
			                }
		                }
                    }
                }")
            };
            createResponse.Headers.Add("x-ms-request-id", "1");
            var createHandler = new RecordedDelegatingHandler(createResponse) { StatusCodeToReturn = HttpStatusCode.OK };
            var createClient = this.GetSchedulerManagementClient(createHandler);

            var createResult = createClient.JobCollections.CreateOrUpdate(
                resourceGroupName: "foo",
                jobCollectionName: "jc1",
                jobCollection: new JobCollectionDefinition()
                {
                    Name = "jc1",
                    Location = "South Central US",
                    Properties = new JobCollectionProperties()
                    {
                        Sku = new Sku()
                        {
                            Name = SkuDefinition.Standard,
                        },
                        State = JobCollectionState.Disabled,
                        Quota = new JobCollectionQuota()
                        {
                            MaxJobCount = 20,
                            MaxJobOccurrence = 300,
                            MaxRecurrence = new JobMaxRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Week,
                                Interval = 1,
                            }
                        }
                    }
                });


            var patchResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                  'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1',
                  'type': 'Microsoft.Scheduler/jobCollections',
                  'name': 'jc1',
                  'location': 'South Central US',
                  'properties': {
                        'sku': {
			                'name': 'Standard'
		                },
		                'state': 'Enabled',
		                'quota': {
			                'maxJobCount': 30,
                            'maxJobOccurrence': 100,
			                'maxRecurrence': {
				                'frequency': 'Month',
				                'interval': 2
			                }
		                }
                    }
                }")
            };
            patchResponse.Headers.Add("x-ms-request-id", "1");
            var patchHandler = new RecordedDelegatingHandler(patchResponse) { StatusCodeToReturn = HttpStatusCode.OK };
            var patchClient = this.GetSchedulerManagementClient(patchHandler);

            var patchResult = patchClient.JobCollections.Patch(
                resourceGroupName: "foo",
                jobCollectionName: "jc1",
                jobCollection: new JobCollectionDefinition()
                {
                    Properties = new JobCollectionProperties()
                    {
                        State = JobCollectionState.Enabled,
                        Quota = new JobCollectionQuota()
                        {
                            MaxJobCount = 30,
                            MaxJobOccurrence = 100,
                            MaxRecurrence = new JobMaxRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Month,
                                Interval = 2,
                            }
                        }
                    }
                });

            // Validate headers
            Assert.Equal("PATCH", patchHandler.Method.ToString());
            Assert.NotNull(patchHandler.RequestHeaders.GetValues("Authorization"));

            Assert.Equal("South Central US", patchResult.Location);
            Assert.Equal("Microsoft.Scheduler/jobCollections", patchResult.Type);
            Assert.Equal("jc1", patchResult.Name);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1", patchResult.Id);
            Assert.Equal(SkuDefinition.Standard, patchResult.Properties.Sku.Name);
            Assert.Equal(JobCollectionState.Enabled, patchResult.Properties.State);
            Assert.Equal(30, patchResult.Properties.Quota.MaxJobCount);
            Assert.Equal(100, patchResult.Properties.Quota.MaxJobOccurrence);
            Assert.Equal(RecurrenceFrequency.Month, patchResult.Properties.Quota.MaxRecurrence.Frequency);
            Assert.Equal(2, patchResult.Properties.Quota.MaxRecurrence.Interval);

            var deleteHandler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            var deleteClient = this.GetSchedulerManagementClient(deleteHandler);
            deleteClient.JobCollections.Delete("foo", "jc1");
        }

        [Fact]
        public void InMemory_JobCollectionListByResourceGroup()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
	                'value': [{
		                'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1',
		                'type': 'Microsoft.Scheduler/jobCollections',
		                'name': 'jc1',
		                'location': 'North Central US',
		                'properties': {
			                'sku': {
				                'name': 'standard'
			                },
			                'state': 'Enabled',
			                'quota': {
				                'maxJobCount': 5,
                                'maxJobOccurrence': 200,
				                'maxRecurrence': {
					                'frequency': 'minute',
					                'interval': 10
				                }
			                }
		                }
	                },
	                {
		                'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc2',
		                'type': 'Microsoft.Scheduler/jobCollections',
		                'name': 'jc2',
		                'location': 'South Central US',
		                'properties': {
			                'sku': {
				                'name': 'P10Premium'
			                },
			                'state': 'Enabled',
			                'quota': {
				                'maxJobCount': 10,
                                'maxJobOccurrence': 100,
				                'maxRecurrence': {
					                'frequency': 'hour',
					                'interval': 5
				                }
			                }
		                }
	                }],
	                'nextLink': null
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetSchedulerManagementClient(handler);

            var result = client.JobCollections.ListByResourceGroup("foo");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            Assert.Null(result.NextPageLink);

            var jc1 = result.Where(jc => string.Compare(jc.Id, "/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc1") == 0).FirstOrDefault();
            Assert.NotNull(jc1);
            Assert.Equal("North Central US", jc1.Location);
            Assert.Equal("Microsoft.Scheduler/jobCollections", jc1.Type);
            Assert.Equal("jc1", jc1.Name);
            Assert.Equal(SkuDefinition.Standard, jc1.Properties.Sku.Name);
            Assert.Equal(JobCollectionState.Enabled, jc1.Properties.State);
            Assert.Equal(5, jc1.Properties.Quota.MaxJobCount);
            Assert.Equal(200, jc1.Properties.Quota.MaxJobOccurrence);
            Assert.Equal(RecurrenceFrequency.Minute, jc1.Properties.Quota.MaxRecurrence.Frequency);
            Assert.Equal(10, jc1.Properties.Quota.MaxRecurrence.Interval);

            var jc2 = result.Where(jc => string.Compare(jc.Id, "/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Scheduler/jobCollections/jc2") == 0).FirstOrDefault();
            Assert.NotNull(jc2);
            Assert.Equal("South Central US", jc2.Location);
            Assert.Equal("Microsoft.Scheduler/jobCollections", jc2.Type);
            Assert.Equal("jc2", jc2.Name);
            Assert.Equal(SkuDefinition.P10Premium, jc2.Properties.Sku.Name);
            Assert.Equal(JobCollectionState.Enabled, jc2.Properties.State);
            Assert.Equal(10, jc2.Properties.Quota.MaxJobCount);
            Assert.Equal(100, jc2.Properties.Quota.MaxJobOccurrence);
            Assert.Equal(RecurrenceFrequency.Hour, jc2.Properties.Quota.MaxRecurrence.Frequency);
            Assert.Equal(5, jc2.Properties.Quota.MaxRecurrence.Interval);
        }

        [Fact]
        public void InMemory_JobCollectionListBySubscription()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
	                'value': [{
		                'id': '/subscriptions/12345/providers/Microsoft.Scheduler/jobCollections/jc1',
		                'type': 'Microsoft.Scheduler/jobCollections',
		                'name': 'jc1',
		                'location': 'North Central US',
		                'properties': {
			                'sku': {
				                'name': 'standard'
			                },
			                'state': 'Enabled',
			                'quota': {
				                'maxJobCount': 5,
                                'maxJobOccurrence': 200,
				                'maxRecurrence': {
					                'frequency': 'minute',
					                'interval': 10
				                }
			                }
		                }
	                },
	                {
		                'id': '/subscriptions/12345/providers/Microsoft.Scheduler/jobCollections/jc2',
		                'type': 'Microsoft.Scheduler/jobCollections',
		                'name': 'jc2',
		                'location': 'South Central US',
		                'properties': {
			                'sku': {
				                'name': 'P20Premium'
			                },
			                'state': 'Enabled',
			                'quota': {
				                'maxJobCount': 10,
                                'maxJobOccurrence': 100,
				                'maxRecurrence': {
					                'frequency': 'hour',
					                'interval': 5
				                }
			                }
		                }
	                }],
	                'nextLink': null
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetSchedulerManagementClient(handler);

            var result = client.JobCollections.ListBySubscription();

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            Assert.Null(result.NextPageLink);

            var jc1 = result.Where(jc => string.Compare(jc.Id, "/subscriptions/12345/providers/Microsoft.Scheduler/jobCollections/jc1") == 0).FirstOrDefault();
            Assert.NotNull(jc1);
            Assert.Equal("North Central US", jc1.Location);
            Assert.Equal("Microsoft.Scheduler/jobCollections", jc1.Type);
            Assert.Equal("jc1", jc1.Name);
            Assert.Equal(SkuDefinition.Standard, jc1.Properties.Sku.Name);
            Assert.Equal(JobCollectionState.Enabled, jc1.Properties.State);
            Assert.Equal(5, jc1.Properties.Quota.MaxJobCount);
            Assert.Equal(200, jc1.Properties.Quota.MaxJobOccurrence);
            Assert.Equal(RecurrenceFrequency.Minute, jc1.Properties.Quota.MaxRecurrence.Frequency);
            Assert.Equal(10, jc1.Properties.Quota.MaxRecurrence.Interval);

            var jc2 = result.Where(jc => string.Compare(jc.Id, "/subscriptions/12345/providers/Microsoft.Scheduler/jobCollections/jc2") == 0).FirstOrDefault();
            Assert.NotNull(jc2);
            Assert.Equal("South Central US", jc2.Location);
            Assert.Equal("Microsoft.Scheduler/jobCollections", jc2.Type);
            Assert.Equal("jc2", jc2.Name);
            Assert.Equal(SkuDefinition.P20Premium, jc2.Properties.Sku.Name);
            Assert.Equal(JobCollectionState.Enabled, jc2.Properties.State);
            Assert.Equal(10, jc2.Properties.Quota.MaxJobCount);
            Assert.Equal(100, jc2.Properties.Quota.MaxJobOccurrence);
            Assert.Equal(RecurrenceFrequency.Hour, jc2.Properties.Quota.MaxRecurrence.Frequency);
            Assert.Equal(5, jc2.Properties.Quota.MaxRecurrence.Interval);
        }

        #endregion

        #region Exceptions

        [Fact]
        public void InMemory_JobCollectionCreateOrUpdateThrowsException()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var handler = new RecordedDelegatingHandler(response);
            var client = this.GetSchedulerManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.JobCollections.CreateOrUpdate(
                resourceGroupName: null, 
                jobCollectionName: "bar", 
                jobCollection: new JobCollectionDefinition()
                {
                    Name = "jc1",
                    Location = "South Central US",
                    Properties = new JobCollectionProperties()
                    {
                        Sku = new Sku()
                        {
                            Name = SkuDefinition.Standard,
                        },
                        State = JobCollectionState.Suspended,
                        Quota = new JobCollectionQuota()
                        {
                            MaxJobCount = 20,
                            MaxJobOccurrence = 300,
                            MaxRecurrence = new JobMaxRecurrence() 
                            { 
                                Frequency = RecurrenceFrequency.Week,
                                Interval = 1,
                            }
                        }
                    }
                }));

            Assert.Throws<ValidationException>(() => client.JobCollections.CreateOrUpdate(
                resourceGroupName: "foo",
                jobCollectionName: null,
                jobCollection: new JobCollectionDefinition()
                {
                    Name = "jc1",
                    Location = "South Central US",
                    Properties = new JobCollectionProperties()
                    {
                        Sku = new Sku()
                        {
                            Name = SkuDefinition.Standard,
                        },
                        State = JobCollectionState.Suspended,
                        Quota = new JobCollectionQuota()
                        {
                            MaxJobCount = 20,
                            MaxJobOccurrence = 300,
                            MaxRecurrence = new JobMaxRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Week,
                                Interval = 1,
                            }
                        }
                    }
                }));

            Assert.Throws<ValidationException>(() => client.JobCollections.CreateOrUpdate(
                resourceGroupName: "foo",
                jobCollectionName: "bar",
                jobCollection: null));

            Assert.Throws<CloudException>(() => client.JobCollections.CreateOrUpdate(
                resourceGroupName: "foo",
                jobCollectionName: "bar",
                jobCollection: new JobCollectionDefinition()
                {
                    Name = "jc1",
                    Location = "South Central US",
                    Properties = new JobCollectionProperties()
                    {
                        Sku = new Sku()
                        {
                            Name = SkuDefinition.Standard,
                        },
                        State = JobCollectionState.Suspended,
                        Quota = new JobCollectionQuota()
                        {
                            MaxJobCount = 20,
                            MaxJobOccurrence = 300,
                            MaxRecurrence = new JobMaxRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Week,
                                Interval = 1,
                            }
                        }
                    }
                }));
        }

        [Fact]
        public void InMemory_JobCollectionPatchThrowsException()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var handler = new RecordedDelegatingHandler(response);
            var client = this.GetSchedulerManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.JobCollections.Patch(
                resourceGroupName: null,
                jobCollectionName: "bar",
                jobCollection: new JobCollectionDefinition()
                {
                    Properties = new JobCollectionProperties()
                    {
                        State = JobCollectionState.Enabled,
                        Quota = new JobCollectionQuota()
                        {
                            MaxJobCount = 30,
                            MaxJobOccurrence = 100,
                            MaxRecurrence = new JobMaxRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Month,
                                Interval = 2,
                            }
                        }
                    }
                }));

            Assert.Throws<ValidationException>(() => client.JobCollections.Patch(
                resourceGroupName: "foo",
                jobCollectionName: null,
                jobCollection: new JobCollectionDefinition()
                {
                    Properties = new JobCollectionProperties()
                    {
                        State = JobCollectionState.Enabled,
                        Quota = new JobCollectionQuota()
                        {
                            MaxJobCount = 30,
                            MaxJobOccurrence = 100,
                            MaxRecurrence = new JobMaxRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Month,
                                Interval = 2,
                            }
                        }
                    }
                }));

            Assert.Throws<ValidationException>(() => client.JobCollections.Patch(
                resourceGroupName: "foo",
                jobCollectionName: "bar",
                jobCollection: null));

            Assert.Throws<CloudException>(() => client.JobCollections.Patch(
                resourceGroupName: "foo",
                jobCollectionName: "bar",
                jobCollection: new JobCollectionDefinition()
                {
                    Properties = new JobCollectionProperties()
                    {
                        State = JobCollectionState.Enabled,
                        Quota = new JobCollectionQuota()
                        {
                            MaxJobCount = 30,
                            MaxJobOccurrence = 100,
                            MaxRecurrence = new JobMaxRecurrence()
                            {
                                Frequency = RecurrenceFrequency.Month,
                                Interval = 2,
                            }
                        }
                    }
                }));
        }

        [Fact]
        public void InMemory_JobCollectionDeleteThrowsException()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var handler = new RecordedDelegatingHandler(response);
            var client = this.GetSchedulerManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.JobCollections.Delete(resourceGroupName: null, jobCollectionName: "bar"));
            Assert.Throws<ValidationException>(() => client.JobCollections.Delete(resourceGroupName: "foo", jobCollectionName: null));
            Assert.Throws<CloudException>(() => client.JobCollections.Delete(resourceGroupName: "foo", jobCollectionName: "bar"));
        }

        [Fact]
        public void InMemory_JobCollectionDisableThrowsException()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var handler = new RecordedDelegatingHandler(response);
            var client = this.GetSchedulerManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.JobCollections.Disable(resourceGroupName: null, jobCollectionName: "bar"));
            Assert.Throws<ValidationException>(() => client.JobCollections.Disable(resourceGroupName: "foo", jobCollectionName: null));
            Assert.Throws<CloudException>(() => client.JobCollections.Disable(resourceGroupName: "foo", jobCollectionName: "bar"));
        }

        [Fact]
        public void InMemory_JobCollectionEnableThrowsException()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var handler = new RecordedDelegatingHandler(response);
            var client = this.GetSchedulerManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.JobCollections.Enable(resourceGroupName: null, jobCollectionName: "bar"));
            Assert.Throws<ValidationException>(() => client.JobCollections.Enable(resourceGroupName: "foo", jobCollectionName: null));
            Assert.Throws<CloudException>(() => client.JobCollections.Enable(resourceGroupName: "foo", jobCollectionName: "bar"));
        }

        [Fact]
        public void InMemory_JobCollectionGetThrowsException()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var handler = new RecordedDelegatingHandler(response);
            var client = this.GetSchedulerManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.JobCollections.Get(resourceGroupName: null, jobCollectionName: "bar"));
            Assert.Throws<ValidationException>(() => client.JobCollections.Get(resourceGroupName: "foo", jobCollectionName: null));
            Assert.Throws<CloudException>(() => client.JobCollections.Get(resourceGroupName: "foo", jobCollectionName: "bar"));
        }

        [Fact]
        public void InMemory_JobCollectionListByResourceGroupThrowsException()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var handler = new RecordedDelegatingHandler(response);
            var client = this.GetSchedulerManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.JobCollections.ListByResourceGroup(resourceGroupName: null));
            Assert.Throws<CloudException>(() => client.JobCollections.ListByResourceGroup(resourceGroupName: "foo"));
        }
        
        #endregion
    }
}