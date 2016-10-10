// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿
namespace BatchClientUnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Rest.Azure;
    using Xunit;

    using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;

    using AutoScaleRun = Microsoft.Azure.Batch.Protocol.Models.AutoScaleRun;
    using AutoScaleRunError = Microsoft.Azure.Batch.Protocol.Models.AutoScaleRunError;
    using CertificateReference = Microsoft.Azure.Batch.Protocol.Models.CertificateReference;
    using EnvironmentSetting = Microsoft.Azure.Batch.Protocol.Models.EnvironmentSetting;
    using NameValuePair = Microsoft.Azure.Batch.Protocol.Models.NameValuePair;

    public class PoolTests
    {
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void GetPoolsListTest()
        {
            using (var client = FakeBatchClient.ConnectWithFakeCredentials(ClientUnitTestCommon.DummyBaseUrl))
            {
                client.FakeProtocolLayer.ListPoolsHandler = (skipToken, behaviors) => Task.FromResult(
                        new AzureOperationResponse<IPage<ProxyModels.CloudPool>, ProxyModels.PoolListHeaders>()
                            {
                                Body = new FakePage<ProxyModels.CloudPool>(new List<ProxyModels.CloudPool>()
                                    {
                                        new ProxyModels.CloudPool { DisplayName = "batch-test"},
                                        new ProxyModels.CloudPool { DisplayName = "foobar", CurrentOSVersion = "3" , AllocationState =  ProxyModels.AllocationState.Steady},
                                    })
                            });

                IPagedEnumerable<Microsoft.Azure.Batch.CloudPool> asyncPools = client.PoolOperations.ListPools();
                var pools = new List<Microsoft.Azure.Batch.CloudPool>(asyncPools);


                Assert.Equal(2, pools.Count);
                Assert.Equal("batch-test", pools[0].DisplayName);

                Assert.Equal("foobar", pools[1].DisplayName);

                // enums are in the same namespace. 
                Assert.Equal(AllocationState.Steady, pools[1].AllocationState);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void GetPoolTestNonNullProperties()
        {
            DateTime currentDateTime = DateTime.UtcNow;
            DateTime dateTimeMinusAnHour = currentDateTime.AddHours(-1);
            using (var client = FakeBatchClient.ConnectWithFakeCredentials(ClientUnitTestCommon.DummyBaseUrl))
            {
                client.FakeProtocolLayer.GetPoolHandler = (skipToken, behaviors) => Task.FromResult(
                        new AzureOperationResponse<ProxyModels.CloudPool, ProxyModels.PoolGetHeaders>
                            {
                                Body = new ProxyModels.CloudPool()
                                        {
                                            AllocationState = ProxyModels.AllocationState.Steady,
                                            AllocationStateTransitionTime = dateTimeMinusAnHour,
                                            AutoScaleFormula = string.Empty,
                                            AutoScaleRun = new AutoScaleRun(),
                                            DisplayName = "batch-test",
                                            CertificateReferences = new[]
                                                    {
                                                        new CertificateReference
                                                            {
                                                                StoreLocation = ProxyModels.CertificateStoreLocation.Currentuser,
                                                                StoreName = "My",
                                                                Thumbprint = string.Empty,
                                                                ThumbprintAlgorithm = "sha1",
                                                                Visibility = "rdp,starttask,task"
                                                            }
                                                    },
                                            CreationTime = dateTimeMinusAnHour,
                                            CurrentOSVersion = "*",
                                            CurrentDedicated = 3,
                                            ETag = "eTag=0x8D250D98B5D78AA",
                                            EnableAutoScale = false,
                                            LastModified = currentDateTime,
                                            MaxTasksPerNode = 4,
                                            OsFamily = "4",
                                            ResizeTimeout = new TimeSpan(),
                                            State = ProxyModels.PoolState.Active,
                                            StateTransitionTime = currentDateTime,
                                            TargetDedicated = 3,
                                            TargetOSVersion = "*",
                                            Url = "testbatch://batch-test.windows-int.net/pools/batch-test",
                                            TaskSchedulingPolicy = new Microsoft.Azure.Batch.Protocol.Models.TaskSchedulingPolicy { NodeFillType = ProxyModels.ComputeNodeFillType.Pack }
                                            
                                        }
                            });

                var pool = client.PoolOperations.GetPool("batch-test");

                Assert.Equal("batch-test", pool.DisplayName);
                Assert.Equal(AllocationState.Steady, pool.AllocationState);
                Assert.Equal(dateTimeMinusAnHour, pool.AllocationStateTransitionTime);
                Assert.Equal(dateTimeMinusAnHour, pool.CreationTime);
                Assert.Equal("*", pool.CurrentOSVersion);
                Assert.Equal(3, pool.CurrentDedicated);
                Assert.Equal(false, pool.AutoScaleEnabled);
                Assert.Equal(currentDateTime, pool.LastModified);
                Assert.Equal(4, pool.MaxTasksPerComputeNode);
                Assert.Equal("4", pool.OSFamily);
                Assert.Equal(PoolState.Active, pool.State);
                Assert.Equal(currentDateTime, pool.StateTransitionTime);
                Assert.Equal(ComputeNodeFillType.Pack, pool.TaskSchedulingPolicy.ComputeNodeFillType);
                Assert.Equal(3, pool.TargetDedicated);
                Assert.Equal("*", pool.TargetOSVersion);
                Assert.Equal("testbatch://batch-test.windows-int.net/pools/batch-test", pool.Url);

                var certs = pool.CertificateReferences;

                Assert.Equal(CertStoreLocation.CurrentUser, certs[0].StoreLocation);
                Assert.Equal("My", certs[0].StoreName);
                Assert.Equal(string.Empty, certs[0].Thumbprint);
                Assert.Equal("sha1", certs[0].ThumbprintAlgorithm);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void GetPoolResizeError()
        {
            var autoScaleRunError = new AutoScaleRunError
                                        {
                                            Code = "InsufficientSampleData",
                                            Message = "Autoscale evaluation failed due to insufficient sample data",
                                            Values = new List<NameValuePair>
                                                    {
                                                        new NameValuePair
                                                            {
                                                                Name = "Message",
                                                                Value = "Line 1, Col 24: Insufficient data from data set: $RunningTasks wanted 100%, received 0%"
                                                            }
                                                    }
                                        };

            var autoScaleError = new AutoScaleRun { Error = autoScaleRunError };

            using (var client = FakeBatchClient.ConnectWithFakeCredentials(ClientUnitTestCommon.DummyBaseUrl))
            {
                client.FakeProtocolLayer.GetPoolHandler = (skipToken, behaviors) => Task.FromResult(
                        new AzureOperationResponse<ProxyModels.CloudPool, ProxyModels.PoolGetHeaders>
                            {
                                Body = new ProxyModels.CloudPool
                                {
                                            DisplayName = "batch-test",
                                            AutoScaleFormula = "$RunningTasks.GetSample(10 * TimeInterval_Second, 0 * TimeInterval_Second, 100);",
                                            AutoScaleRun = autoScaleError,
                                            EnableAutoScale = true,
                                        }
                            });

                var pool = client.PoolOperations.GetPool("batch-test");

                Assert.Equal("batch-test", pool.DisplayName);
                Assert.Equal(pool.AutoScaleEnabled, true);
                Assert.Equal(pool.AutoScaleRun.Error.Code, "InsufficientSampleData");
                Assert.Equal(pool.AutoScaleRun.Error.Message, "Autoscale evaluation failed due to insufficient sample data");
                Assert.Equal(pool.AutoScaleRun.Error.Values.First().Name, "Message");
                Assert.Equal(pool.AutoScaleRun.Error.Values.First().Value, "Line 1, Col 24: Insufficient data from data set: $RunningTasks wanted 100%, received 0%");
            }
        }


        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void GetPoolStartTask()
        {
            var startTask = new Microsoft.Azure.Batch.Protocol.Models.StartTask
                                {
                                    CommandLine = "-start",
                                    EnvironmentSettings = new[] { new EnvironmentSetting { Name = "windows", Value = "foo" } },
                                    MaxTaskRetryCount = 3,
                                    RunElevated = false,
                                    WaitForSuccess = false
                                };


            using (var client = FakeBatchClient.ConnectWithFakeCredentials(ClientUnitTestCommon.DummyBaseUrl))
            {
                client.FakeProtocolLayer.GetPoolHandler = (skipToken, behaviors) => Task.FromResult(
                    new AzureOperationResponse<ProxyModels.CloudPool, ProxyModels.PoolGetHeaders>()
                        {
                            Body = new ProxyModels.CloudPool { DisplayName = "batch-test", StartTask = startTask, }
                        });

                var pool = client.PoolOperations.GetPool("batch-test");

                Assert.Equal("batch-test", pool.DisplayName);
                Assert.Equal(pool.StartTask.CommandLine, "-start");
                Assert.Equal(pool.StartTask.EnvironmentSettings.FirstOrDefault().Name, "windows");
                Assert.Equal(pool.StartTask.EnvironmentSettings.FirstOrDefault().Value, "foo");
                Assert.Equal(pool.StartTask.MaxTaskRetryCount, 3);
                Assert.Equal(pool.StartTask.RunElevated, false);
                Assert.Equal(pool.StartTask.WaitForSuccess, false);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ListComputeNodes()
        {
            var dateTime = DateTime.UtcNow;

            using (var client = FakeBatchClient.ConnectWithFakeCredentials(ClientUnitTestCommon.DummyBaseUrl))
            {
                client.FakeProtocolLayer.ListComputeNodesHandler =  (s, s1, arg3) => Task.FromResult(
                        new AzureOperationResponse<IPage<ProxyModels.ComputeNode>, ProxyModels.ComputeNodeListHeaders>()
                            {
                                Body = new FakePage<ProxyModels.ComputeNode>(new List<ProxyModels.ComputeNode>() 
                                    { 
                                        new Microsoft.Azure.Batch.Protocol.Models.ComputeNode()
                                            {
                                                State = ProxyModels.ComputeNodeState.Running, 
                                                LastBootTime = dateTime,
                                                Id = "computeNode1",
                                            }
                                    })
                            });

                List<Microsoft.Azure.Batch.ComputeNode> VMs = client.PoolOperations.ListComputeNodes("foo").ToList();

                Assert.Equal(VMs.Count, 1);
                Assert.Equal(VMs[0].Id, "computeNode1");
                Assert.Equal(VMs[0].State, ComputeNodeState.Running);
                Assert.Equal(VMs[0].LastBootTime, dateTime);
            }
        }
    }
}