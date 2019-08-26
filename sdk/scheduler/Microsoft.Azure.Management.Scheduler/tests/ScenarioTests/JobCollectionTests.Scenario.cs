﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Scheduler;
using Microsoft.Azure.Management.Scheduler.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Scheduler.Test.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace Scheduler.Test.ScenarioTests
{
    public class JobCollectionTests
    {
        private const string subscriptionId = "623d50f1-4fa8-4e46-a967-a9214aed43ab";
        private const string resourceGroupName = "CS-SouthCentralUS-scheduler";
        private const string type = "Microsoft.Scheduler/jobCollections";
        private const string location = "South Central US";


        [Fact]
        public void Ensure_Microsoft_Rest_ClientRuntime_Azure_Authentication_Get_Deployed()
        {
            Microsoft.Rest.Azure.Authentication.AuthenticationException randomType = 
                new Microsoft.Rest.Azure.Authentication.AuthenticationException();
            Assert.True(randomType.GetType().ToString().Length != 0);
        }

        [Fact]
        public void Scenario_JobCollectionCreateUpdateDeleteP20Premium()
        {
            using (MockContext context = MockContext.Start("Scheduler.Test.ScenarioTests.JobCollectionTests"))
            {
                string jobCollectionName = TestUtilities.GenerateName("jc1");
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}", subscriptionId, resourceGroupName, jobCollectionName);

                var client = context.GetServiceClient<SchedulerManagementClient>();

                var createResult = client.JobCollections.CreateOrUpdate(
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
                                Name = SkuDefinition.P20Premium,
                            },
                            State = JobCollectionState.Suspended,
                            Quota = new JobCollectionQuota()
                            {
                                MaxJobCount = 20,
                                MaxRecurrence = new JobMaxRecurrence()
                                {
                                    Frequency = RecurrenceFrequency.Week,
                                    Interval = 1,
                                }
                            }
                        }
                    });

                Assert.Equal(location, createResult.Location);
                Assert.Equal(type, createResult.Type);
                Assert.Equal(jobCollectionName, createResult.Name);
                Assert.Equal(id, createResult.Id);
                Assert.Null(createResult.Tags);
                Assert.Equal(SkuDefinition.P20Premium, createResult.Properties.Sku.Name);
                Assert.Equal(JobCollectionState.Suspended, createResult.Properties.State);
                Assert.Equal(20, createResult.Properties.Quota.MaxJobCount);
                Assert.Equal(RecurrenceFrequency.Week, createResult.Properties.Quota.MaxRecurrence.Frequency);
                Assert.Equal(1, createResult.Properties.Quota.MaxRecurrence.Interval);

                var tags = new Dictionary<string, string>();
                tags.Add("department", "marketing");

                var updateResult = client.JobCollections.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobCollection: new JobCollectionDefinition()
                    {
                        Name = jobCollectionName,
                        Location = location,
                        Tags = tags,
                        Properties = new JobCollectionProperties()
                        {
                            Sku = new Sku()
                            {
                                Name = SkuDefinition.P10Premium,
                            },
                            State = JobCollectionState.Enabled,
                            Quota = new JobCollectionQuota()
                            {
                                MaxJobCount = 50,
                                MaxRecurrence = new JobMaxRecurrence()
                                {
                                    Frequency = RecurrenceFrequency.Day,
                                    Interval = 2,
                                }
                            }
                        }
                    });

                Assert.Equal(location, updateResult.Location);
                Assert.Equal(type, updateResult.Type);
                Assert.Equal(jobCollectionName, updateResult.Name);
                Assert.Equal(id, updateResult.Id);
                Assert.NotNull(updateResult.Tags);
                Assert.Equal("marketing", updateResult.Tags["department"]);
                Assert.Equal(SkuDefinition.P10Premium, updateResult.Properties.Sku.Name);
                Assert.Equal(JobCollectionState.Enabled, updateResult.Properties.State);
                Assert.Equal(50, updateResult.Properties.Quota.MaxJobCount);
                Assert.Equal(RecurrenceFrequency.Day, updateResult.Properties.Quota.MaxRecurrence.Frequency);
                Assert.Equal(2, updateResult.Properties.Quota.MaxRecurrence.Interval);

                client.JobCollections.Delete(resourceGroupName, jobCollectionName);
            }
        }

        [Fact]
        public void Scenario_JobCollectionCreateUpdateDelete()
        {
            using (MockContext context = MockContext.Start("Scheduler.Test.ScenarioTests.JobCollectionTests"))
            {
                string jobCollectionName = TestUtilities.GenerateName("jc1");
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}", subscriptionId, resourceGroupName, jobCollectionName);

                var client = context.GetServiceClient<SchedulerManagementClient>();
                
                var createResult = client.JobCollections.CreateOrUpdate(
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
                            State = JobCollectionState.Suspended,
                            Quota = new JobCollectionQuota()
                            {
                                MaxJobCount = 20,
                                MaxRecurrence = new JobMaxRecurrence()
                                {
                                    Frequency = RecurrenceFrequency.Week,
                                    Interval = 1,
                                }
                            }
                        }
                    });

                Assert.Equal(location, createResult.Location);
                Assert.Equal(type, createResult.Type);
                Assert.Equal(jobCollectionName, createResult.Name);
                Assert.Equal(id, createResult.Id);
                Assert.Null(createResult.Tags);
                Assert.Equal(SkuDefinition.Standard, createResult.Properties.Sku.Name);
                Assert.Equal(JobCollectionState.Suspended, createResult.Properties.State);
                Assert.Equal(20, createResult.Properties.Quota.MaxJobCount);
                Assert.Equal(RecurrenceFrequency.Week, createResult.Properties.Quota.MaxRecurrence.Frequency);
                Assert.Equal(1, createResult.Properties.Quota.MaxRecurrence.Interval);

                var tags = new Dictionary<string, string>();
                tags.Add("department", "marketing");

                var updateResult = client.JobCollections.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobCollection: new JobCollectionDefinition()
                    {
                        Name = jobCollectionName,
                        Location = location,
                        Tags = tags,
                        Properties = new JobCollectionProperties()
                        {
                            Sku = new Sku()
                            {
                                Name = SkuDefinition.P10Premium,
                            },
                            State = JobCollectionState.Enabled,
                            Quota = new JobCollectionQuota()
                            {
                                MaxJobCount = 50,
                                MaxRecurrence = new JobMaxRecurrence()
                                {
                                    Frequency = RecurrenceFrequency.Day,
                                    Interval = 2,
                                }
                            }
                        }
                    });

                Assert.Equal(location, updateResult.Location);
                Assert.Equal(type, updateResult.Type);
                Assert.Equal(jobCollectionName, updateResult.Name);
                Assert.Equal(id, updateResult.Id);
                Assert.NotNull(updateResult.Tags);
                Assert.Equal("marketing", updateResult.Tags["department"]);
                Assert.Equal(SkuDefinition.P10Premium, updateResult.Properties.Sku.Name);
                Assert.Equal(JobCollectionState.Enabled, updateResult.Properties.State);
                Assert.Equal(50, updateResult.Properties.Quota.MaxJobCount);
                Assert.Equal(RecurrenceFrequency.Day, updateResult.Properties.Quota.MaxRecurrence.Frequency);
                Assert.Equal(2, updateResult.Properties.Quota.MaxRecurrence.Interval);

                client.JobCollections.Delete(resourceGroupName, jobCollectionName);
            }
        }

        [Fact]
        public void Scenario_JobCollectionPatch()
        {
            using (MockContext context = MockContext.Start("Scheduler.Test.ScenarioTests.JobCollectionTests"))
            {
                string jobCollectionName = TestUtilities.GenerateName("jc1");
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}", subscriptionId, resourceGroupName, jobCollectionName);
                var tags = new Dictionary<string, string>();
                tags.Add("department", "marketing");

                var client = context.GetServiceClient<SchedulerManagementClient>();
                
                var createResult = client.JobCollections.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobCollection: new JobCollectionDefinition()
                    {
                        Name = jobCollectionName,
                        Location = location,
                        Tags = tags,
                        Properties = new JobCollectionProperties()
                        {
                            Sku = new Sku()
                            {
                                Name = SkuDefinition.P10Premium,
                            },
                            State = JobCollectionState.Enabled,
                            Quota = new JobCollectionQuota()
                            {
                                MaxJobCount = 50,
                                MaxRecurrence = new JobMaxRecurrence()
                                {
                                    Frequency = RecurrenceFrequency.Day,
                                    Interval = 2,
                                }
                            }
                        }
                    });

                tags["department"] = "marketing2";

                var patchResult = client.JobCollections.Patch(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName,
                    jobCollection: new JobCollectionDefinition()
                    {
                        Tags = tags,
                    });

                Assert.Equal(location, patchResult.Location);
                Assert.Equal(type, patchResult.Type);
                Assert.Equal(jobCollectionName, patchResult.Name);
                Assert.Equal(id, patchResult.Id);
                Assert.NotNull(patchResult.Tags);
                Assert.Equal("marketing2", patchResult.Tags["department"]);
                Assert.Equal(SkuDefinition.P10Premium, patchResult.Properties.Sku.Name);
                Assert.Equal(JobCollectionState.Enabled, patchResult.Properties.State);
                Assert.Equal(50, patchResult.Properties.Quota.MaxJobCount);
                Assert.Equal(RecurrenceFrequency.Day, patchResult.Properties.Quota.MaxRecurrence.Frequency);
                Assert.Equal(2, patchResult.Properties.Quota.MaxRecurrence.Interval);

                client.JobCollections.Delete(resourceGroupName, jobCollectionName);
            }
        }

        [Fact]
        public void Scenario_JobCollectionEnableDisable()
        {
            using (MockContext context = MockContext.Start("Scheduler.Test.ScenarioTests.JobCollectionTests"))
            {
                string jobCollectionName1 = TestUtilities.GenerateName("jc1");
                string jobCollectionName2 = TestUtilities.GenerateName("jc2");
                string id1 = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}", subscriptionId, resourceGroupName, jobCollectionName1);
                string id2 = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}", subscriptionId, resourceGroupName, jobCollectionName2);
                var tags = new Dictionary<string, string>();
                tags.Add("department", "marketing");

                var client = context.GetServiceClient<SchedulerManagementClient>();

                var createResult1 = client.JobCollections.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName1,
                    jobCollection: new JobCollectionDefinition()
                    {
                        Name = jobCollectionName1,
                        Location = location,
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
                                MaxRecurrence = new JobMaxRecurrence()
                                {
                                    Frequency = RecurrenceFrequency.Week,
                                    Interval = 1,
                                }
                            }
                        }
                    });

                var createResult2 = client.JobCollections.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName2,
                    jobCollection: new JobCollectionDefinition()
                    {
                        Name = jobCollectionName2,
                        Location = location,
                        Tags = tags,
                        Properties = new JobCollectionProperties()
                        {
                            Sku = new Sku()
                            {
                                Name = SkuDefinition.P10Premium,
                            },
                            State = JobCollectionState.Enabled,
                            Quota = new JobCollectionQuota()
                            {
                                MaxJobCount = 50,
                                MaxRecurrence = new JobMaxRecurrence()
                                {
                                    Frequency = RecurrenceFrequency.Day,
                                    Interval = 2,
                                }
                            }
                        }
                    });

                var getResult1 = client.JobCollections.Get(resourceGroupName, jobCollectionName1);
                var getResult2 = client.JobCollections.Get(resourceGroupName, jobCollectionName2);

                Assert.Equal(location, getResult1.Location);
                Assert.Equal(type, getResult1.Type);
                Assert.Equal(jobCollectionName1, getResult1.Name);
                Assert.Equal(id1, getResult1.Id);
                Assert.Null(getResult1.Tags);
                Assert.Equal(SkuDefinition.Standard, getResult1.Properties.Sku.Name);
                Assert.Equal(JobCollectionState.Suspended, getResult1.Properties.State);
                Assert.Equal(20, getResult1.Properties.Quota.MaxJobCount);
                Assert.Equal(RecurrenceFrequency.Week, getResult1.Properties.Quota.MaxRecurrence.Frequency);
                Assert.Equal(1, getResult1.Properties.Quota.MaxRecurrence.Interval);

                Assert.Equal(location, getResult2.Location);
                Assert.Equal(type, getResult2.Type);
                Assert.Equal(jobCollectionName2, getResult2.Name);
                Assert.Equal(id2, getResult2.Id);
                Assert.NotNull(getResult2.Tags);
                Assert.Equal("marketing", getResult2.Tags["department"]);
                Assert.Equal(SkuDefinition.P10Premium, getResult2.Properties.Sku.Name);
                Assert.Equal(JobCollectionState.Enabled, getResult2.Properties.State);
                Assert.Equal(50, getResult2.Properties.Quota.MaxJobCount);
                Assert.Equal(RecurrenceFrequency.Day, getResult2.Properties.Quota.MaxRecurrence.Frequency);
                Assert.Equal(2, getResult2.Properties.Quota.MaxRecurrence.Interval);

                client.JobCollections.Disable(resourceGroupName, jobCollectionName2);
                var disableResult = client.JobCollections.Get(resourceGroupName, jobCollectionName2);

                Assert.Equal(location, disableResult.Location);
                Assert.Equal(type, disableResult.Type);
                Assert.Equal(jobCollectionName2, disableResult.Name);
                Assert.Equal(id2, disableResult.Id);
                Assert.NotNull(disableResult.Tags);
                Assert.Equal("marketing", disableResult.Tags["department"]);
                Assert.Equal(SkuDefinition.P10Premium, disableResult.Properties.Sku.Name);
                Assert.Equal(JobCollectionState.Disabled, disableResult.Properties.State);
                Assert.Equal(50, disableResult.Properties.Quota.MaxJobCount);
                Assert.Equal(RecurrenceFrequency.Day, disableResult.Properties.Quota.MaxRecurrence.Frequency);
                Assert.Equal(2, disableResult.Properties.Quota.MaxRecurrence.Interval);

                client.JobCollections.Enable(resourceGroupName, jobCollectionName2);
                var enableResult = client.JobCollections.Get(resourceGroupName, jobCollectionName2);

                Assert.Equal(location, enableResult.Location);
                Assert.Equal(type, enableResult.Type);
                Assert.Equal(jobCollectionName2, enableResult.Name);
                Assert.Equal(id2, enableResult.Id);
                Assert.NotNull(enableResult.Tags);
                Assert.Equal("marketing", enableResult.Tags["department"]);
                Assert.Equal(SkuDefinition.P10Premium, enableResult.Properties.Sku.Name);
                Assert.Equal(JobCollectionState.Enabled, enableResult.Properties.State);
                Assert.Equal(50, enableResult.Properties.Quota.MaxJobCount);
                Assert.Equal(RecurrenceFrequency.Day, enableResult.Properties.Quota.MaxRecurrence.Frequency);
                Assert.Equal(2, enableResult.Properties.Quota.MaxRecurrence.Interval);

                client.JobCollections.Delete(resourceGroupName, jobCollectionName1);
                client.JobCollections.Delete(resourceGroupName, jobCollectionName2);
            }
        }

        [Fact]
        public void Scenario_JobCollectionListByResourceGroup()
        {
            using (MockContext context = MockContext.Start("Scheduler.Test.ScenarioTests.JobCollectionTests"))
            {
                string jobCollectionName1 = TestUtilities.GenerateName("jc1");
                string jobCollectionName2 = TestUtilities.GenerateName("jc2");
                string id1 = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}", subscriptionId, resourceGroupName, jobCollectionName1);
                string id2 = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}", subscriptionId, resourceGroupName, jobCollectionName2);
                var tags = new Dictionary<string, string>();
                tags.Add("department", "marketing");

                var client = context.GetServiceClient<SchedulerManagementClient>();

                var createResult1 = client.JobCollections.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName1,
                    jobCollection: new JobCollectionDefinition()
                    {
                        Name = jobCollectionName1,
                        Location = location,
                        Properties = new JobCollectionProperties()
                        {
                            Sku = new Sku()
                            {
                                Name = SkuDefinition.P10Premium,
                            },
                            State = JobCollectionState.Suspended,
                            Quota = new JobCollectionQuota()
                            {
                                MaxJobCount = 20,
                                MaxRecurrence = new JobMaxRecurrence()
                                {
                                    Frequency = RecurrenceFrequency.Week,
                                    Interval = 1,
                                }
                            }
                        }
                    });

                var createResult2 = client.JobCollections.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName2,
                    jobCollection: new JobCollectionDefinition()
                    {
                        Name = jobCollectionName2,
                        Location = location,
                        Tags = tags,
                        Properties = new JobCollectionProperties()
                        {
                            Sku = new Sku()
                            {
                                Name = SkuDefinition.P20Premium,
                            },
                            State = JobCollectionState.Enabled,
                            Quota = new JobCollectionQuota()
                            {
                                MaxJobCount = 50,
                                MaxRecurrence = new JobMaxRecurrence()
                                {
                                    Frequency = RecurrenceFrequency.Day,
                                    Interval = 2,
                                }
                            }
                        }
                    });

                var listByResourceGroupResult = client.JobCollections.ListByResourceGroup(resourceGroupName);

                Assert.True(listByResourceGroupResult.Count() >= 2);
                var listByResourceGroupResult1 = listByResourceGroupResult.Where(jc => string.Compare(jc.Id, id1) == 0).FirstOrDefault();
                var listByResourceGroupResult2 = listByResourceGroupResult.Where(jc => string.Compare(jc.Id, id2) == 0).FirstOrDefault();

                Assert.Equal(location, listByResourceGroupResult1.Location);
                Assert.Equal(type, listByResourceGroupResult1.Type);
                Assert.Equal(jobCollectionName1, listByResourceGroupResult1.Name);
                Assert.Equal(id1, listByResourceGroupResult1.Id);
                Assert.Null(listByResourceGroupResult1.Tags);
                Assert.Equal(SkuDefinition.P10Premium, listByResourceGroupResult1.Properties.Sku.Name);
                Assert.Equal(JobCollectionState.Suspended, listByResourceGroupResult1.Properties.State);
                Assert.Equal(20, listByResourceGroupResult1.Properties.Quota.MaxJobCount);
                Assert.Equal(RecurrenceFrequency.Week, listByResourceGroupResult1.Properties.Quota.MaxRecurrence.Frequency);
                Assert.Equal(1, listByResourceGroupResult1.Properties.Quota.MaxRecurrence.Interval);

                Assert.Equal(location, listByResourceGroupResult2.Location);
                Assert.Equal(type, listByResourceGroupResult2.Type);
                Assert.Equal(jobCollectionName2, listByResourceGroupResult2.Name);
                Assert.Equal(id2, listByResourceGroupResult2.Id);
                Assert.NotNull(listByResourceGroupResult2.Tags);
                Assert.Equal("marketing", listByResourceGroupResult2.Tags["department"]);
                Assert.Equal(SkuDefinition.P20Premium, listByResourceGroupResult2.Properties.Sku.Name);
                Assert.Equal(JobCollectionState.Enabled, listByResourceGroupResult2.Properties.State);
                Assert.Equal(50, listByResourceGroupResult2.Properties.Quota.MaxJobCount);
                Assert.Equal(RecurrenceFrequency.Day, listByResourceGroupResult2.Properties.Quota.MaxRecurrence.Frequency);
                Assert.Equal(2, listByResourceGroupResult2.Properties.Quota.MaxRecurrence.Interval);

                client.JobCollections.Delete(resourceGroupName, jobCollectionName1);
                client.JobCollections.Delete(resourceGroupName, jobCollectionName2);
            }
        }

        [Fact]
        public void Scenario_JobCollectionListBySubscription()
        {
            using (MockContext context = MockContext.Start("Scheduler.Test.ScenarioTests.JobCollectionTests"))
            {
                string jobCollectionName1 = TestUtilities.GenerateName("jc1");
                string jobCollectionName2 = TestUtilities.GenerateName("jc2");
                string id1 = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}", subscriptionId, resourceGroupName, jobCollectionName1);
                string id2 = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Scheduler/jobCollections/{2}", subscriptionId, resourceGroupName, jobCollectionName2);
                var tags = new Dictionary<string, string>();
                tags.Add("department", "marketing");

                var client = context.GetServiceClient<SchedulerManagementClient>();

                var createResult1 = client.JobCollections.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName1,
                    jobCollection: new JobCollectionDefinition()
                    {
                        Name = jobCollectionName1,
                        Location = location,
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
                                MaxRecurrence = new JobMaxRecurrence()
                                {
                                    Frequency = RecurrenceFrequency.Week,
                                    Interval = 1,
                                }
                            }
                        }
                    });

                var createResult2 = client.JobCollections.CreateOrUpdate(
                    resourceGroupName: resourceGroupName,
                    jobCollectionName: jobCollectionName2,
                    jobCollection: new JobCollectionDefinition()
                    {
                        Name = jobCollectionName2,
                        Location = location,
                        Tags = tags,
                        Properties = new JobCollectionProperties()
                        {
                            Sku = new Sku()
                            {
                                Name = SkuDefinition.P20Premium,
                            },
                            State = JobCollectionState.Enabled,
                            Quota = new JobCollectionQuota()
                            {
                                MaxJobCount = 50,
                                MaxRecurrence = new JobMaxRecurrence()
                                {
                                    Frequency = RecurrenceFrequency.Day,
                                    Interval = 2,
                                }
                            }
                        }
                    });

                var listBySubResult = client.JobCollections.ListBySubscription();

                Assert.True(listBySubResult.Count() >= 2);
                var listBySubResult1 = listBySubResult.Where(jc => string.Compare(jc.Id, id1) == 0).FirstOrDefault();
                var listBySubResult2 = listBySubResult.Where(jc => string.Compare(jc.Id, id2) == 0).FirstOrDefault();

                Assert.Equal(location, listBySubResult1.Location);
                Assert.Equal(type, listBySubResult1.Type);
                Assert.Equal(jobCollectionName1, listBySubResult1.Name);
                Assert.Equal(id1, listBySubResult1.Id);
                Assert.Null(listBySubResult1.Tags);
                Assert.Equal(SkuDefinition.Standard, listBySubResult1.Properties.Sku.Name);
                Assert.Equal(JobCollectionState.Suspended, listBySubResult1.Properties.State);
                Assert.Equal(20, listBySubResult1.Properties.Quota.MaxJobCount);
                Assert.Equal(RecurrenceFrequency.Week, listBySubResult1.Properties.Quota.MaxRecurrence.Frequency);
                Assert.Equal(1, listBySubResult1.Properties.Quota.MaxRecurrence.Interval);

                Assert.Equal(location, listBySubResult2.Location);
                Assert.Equal(type, listBySubResult2.Type);
                Assert.Equal(jobCollectionName2, listBySubResult2.Name);
                Assert.Equal(id2, listBySubResult2.Id);
                Assert.NotNull(listBySubResult2.Tags);
                Assert.Equal("marketing", listBySubResult2.Tags["department"]);
                Assert.Equal(SkuDefinition.P20Premium, listBySubResult2.Properties.Sku.Name);
                Assert.Equal(JobCollectionState.Enabled, listBySubResult2.Properties.State);
                Assert.Equal(50, listBySubResult2.Properties.Quota.MaxJobCount);
                Assert.Equal(RecurrenceFrequency.Day, listBySubResult2.Properties.Quota.MaxRecurrence.Frequency);
                Assert.Equal(2, listBySubResult2.Properties.Quota.MaxRecurrence.Interval);

                client.JobCollections.Delete(resourceGroupName, jobCollectionName1);
                client.JobCollections.Delete(resourceGroupName, jobCollectionName2);
            }
        }
    }
}
