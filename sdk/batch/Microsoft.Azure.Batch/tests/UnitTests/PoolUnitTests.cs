// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿
namespace Azure.Batch.Unit.Tests
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
    using Protocol=Microsoft.Azure.Batch.Protocol;
    using Models = Microsoft.Azure.Batch.Protocol.Models;

    public class PoolUnitTests
    {
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void GetPoolsListTest()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(baseRequest =>
            {
                var request = (Protocol.BatchRequest<Models.PoolListOptions, AzureOperationResponse<IPage<Models.CloudPool>, Models.PoolListHeaders>>)baseRequest;

                request.ServiceRequestFunc = async (token) =>
                {
                    var response = new AzureOperationResponse<IPage<Models.CloudPool>, Models.PoolListHeaders>
                    {
                        Body = new FakePage<Models.CloudPool>(new List<Models.CloudPool>
                                    {
                                            new Models.CloudPool { DisplayName = "batch-test"},
                                            new Models.CloudPool { DisplayName = "foobar", VirtualMachineConfiguration = new Models.VirtualMachineConfiguration(imageReference: new Models.ImageReference(), nodeAgentSKUId: "df"), AllocationState = Models.AllocationState.Steady},
                                    })
                    };

                    Task<AzureOperationResponse<IPage<Models.CloudPool>, Models.PoolListHeaders>> task = Task.FromResult(response);
                    return await task;
                };
            });

            IPagedEnumerable<Microsoft.Azure.Batch.CloudPool> asyncPools = client.PoolOperations.ListPools(additionalBehaviors: new List<BatchClientBehavior> { interceptor });
            var pools = new List<Microsoft.Azure.Batch.CloudPool>(asyncPools);

            Assert.Equal(2, pools.Count);
            Assert.Equal("batch-test", pools[0].DisplayName);

            Assert.Equal("foobar", pools[1].DisplayName);

            // enums are in the same namespace. 
            Assert.Equal(AllocationState.Steady, pools[1].AllocationState);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void GetPoolTestNonNullProperties()
        {
            DateTime currentDateTime = DateTime.UtcNow;
            DateTime dateTimeMinusAnHour = currentDateTime.AddHours(-1);

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(baseRequest =>
            {
                var request = (Protocol.BatchRequest<Models.PoolGetOptions, AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>>)baseRequest;

                request.ServiceRequestFunc = async (token) =>
                {
                    var response = new AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>
                    {
                        Body = new Models.CloudPool
                        {
                            AllocationState = Models.AllocationState.Steady,
                            AllocationStateTransitionTime = dateTimeMinusAnHour,
                            AutoScaleFormula = string.Empty,
                            AutoScaleRun = new Models.AutoScaleRun(),
                            DisplayName = "batch-test",
                            CertificateReferences = new[]
                                                {
                                                        new Models.CertificateReference
                                                            {
                                                                StoreLocation = Models.CertificateStoreLocation.CurrentUser,
                                                                StoreName = "My",
                                                                Thumbprint = string.Empty,
                                                                ThumbprintAlgorithm = "sha1",
                                                                Visibility = new List<Models.CertificateVisibility>()
                                                                    {
                                                                        Models.CertificateVisibility.RemoteUser,
                                                                        Models.CertificateVisibility.StartTask,
                                                                        Models.CertificateVisibility.Task
                                                                    }
                                                            }
                                                },
                            CreationTime = dateTimeMinusAnHour,
                            VirtualMachineConfiguration = new Models.VirtualMachineConfiguration(imageReference: new Models.ImageReference(), nodeAgentSKUId: "df"),
                            CurrentDedicatedNodes = 3,
                            ETag = "eTag=0x8D250D98B5D78AA",
                            EnableAutoScale = false,
                            LastModified = currentDateTime,
                            TaskSlotsPerNode = 4,
                            ResizeTimeout = new TimeSpan(),
                            State = Models.PoolState.Active,
                            StateTransitionTime = currentDateTime,
                            TargetDedicatedNodes = 3,
                            Url = "testbatch://batch-test.windows-int.net/pools/batch-test",
                            TaskSchedulingPolicy = new Microsoft.Azure.Batch.Protocol.Models.TaskSchedulingPolicy { NodeFillType = Models.ComputeNodeFillType.Pack }
                        }
                    };

                    var task = Task.FromResult(response);
                    return await task;
                };
            });

            var pool = client.PoolOperations.GetPool("batch-test", additionalBehaviors: new List<BatchClientBehavior> { interceptor });

            Assert.Equal("batch-test", pool.DisplayName);
            Assert.Equal(AllocationState.Steady, pool.AllocationState);
            Assert.Equal(dateTimeMinusAnHour, pool.AllocationStateTransitionTime);
            Assert.Equal(dateTimeMinusAnHour, pool.CreationTime);
            Assert.Equal("df", pool.VirtualMachineConfiguration.NodeAgentSkuId);
            Assert.Equal(3, pool.CurrentDedicatedComputeNodes);
            Assert.Equal(false, pool.AutoScaleEnabled);
            Assert.Equal(currentDateTime, pool.LastModified);
            Assert.Equal(4, pool.TaskSlotsPerNode);
            Assert.Equal(PoolState.Active, pool.State);
            Assert.Equal(currentDateTime, pool.StateTransitionTime);
            Assert.Equal(ComputeNodeFillType.Pack, pool.TaskSchedulingPolicy.ComputeNodeFillType);
            Assert.Equal(3, pool.TargetDedicatedComputeNodes);
            Assert.Equal("testbatch://batch-test.windows-int.net/pools/batch-test", pool.Url);

            var certs = pool.CertificateReferences;

            Assert.Equal(CertStoreLocation.CurrentUser, certs[0].StoreLocation);
            Assert.Equal("My", certs[0].StoreName);
            Assert.Equal(string.Empty, certs[0].Thumbprint);
            Assert.Equal("sha1", certs[0].ThumbprintAlgorithm);
        }
        
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void GetPoolResizeError()
        {
            var autoScaleRunError = new Models.AutoScaleRunError
            {
                Code = "InsufficientSampleData",
                Message = "Autoscale evaluation failed due to insufficient sample data",
                Values = new List<Models.NameValuePair>
                        {
                            new Models.NameValuePair
                                {
                                    Name = "Message",
                                    Value = "Line 1, Col 24: Insufficient data from data set: $RunningTasks wanted 100%, received 0%"
                                }
                        }
            };

            var autoScaleError = new Models.AutoScaleRun { Error = autoScaleRunError };

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(baseRequest =>
            {
                var request = (Protocol.BatchRequest<Models.PoolGetOptions, AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>>)baseRequest;

                request.ServiceRequestFunc = async (token) =>
                    {
                        var response = new AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>
                        {
                            Body = new Models.CloudPool
                            {
                                DisplayName = "batch-test",
                                AutoScaleFormula = "$RunningTasks.GetSample(10 * TimeInterval_Second, 0 * TimeInterval_Second, 100);",
                                AutoScaleRun = autoScaleError,
                                EnableAutoScale = true,
                            }
                        };

                        var task = Task.FromResult(response);
                        return await task;
                    };
            });

            var pool = client.PoolOperations.GetPool("batch-test", additionalBehaviors: new List<BatchClientBehavior> { interceptor });

            Assert.Equal("batch-test", pool.DisplayName);
            Assert.Equal(true, pool.AutoScaleEnabled);
            Assert.Equal("InsufficientSampleData", pool.AutoScaleRun.Error.Code);
            Assert.Equal("Autoscale evaluation failed due to insufficient sample data", pool.AutoScaleRun.Error.Message);
            Assert.Equal("Message", pool.AutoScaleRun.Error.Values.First().Name);
            Assert.Equal("Line 1, Col 24: Insufficient data from data set: $RunningTasks wanted 100%, received 0%", pool.AutoScaleRun.Error.Values.First().Value);
        }


        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void GetPoolStartTask()
        {
            var startTask = new Protocol.Models.StartTask
                                {
                                    CommandLine = "-start",
                                    EnvironmentSettings = new[] { new Models.EnvironmentSetting { Name = "windows", Value = "foo" } },
                                    MaxTaskRetryCount = 3,
                                    UserIdentity = new Protocol.Models.UserIdentity(
                                        autoUser: new Protocol.Models.AutoUserSpecification(elevationLevel: Protocol.Models.ElevationLevel.NonAdmin)),
                                    WaitForSuccess = false
                                };

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(baseRequest =>
            {
                var request = (Protocol.BatchRequest<Models.PoolGetOptions, AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>>)baseRequest;

                request.ServiceRequestFunc = async (token) =>
                    {
                        var response = new AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>
                        {
                            Body = new Models.CloudPool { DisplayName = "batch-test", StartTask = startTask, }
                        };

                        var task = Task.FromResult(response);
                        return await task;
                    };
            });

            var pool = client.PoolOperations.GetPool("batch-test", additionalBehaviors: new List<BatchClientBehavior> { interceptor });

            Assert.Equal("batch-test", pool.DisplayName);
            Assert.Equal("-start", pool.StartTask.CommandLine);
            Assert.Equal("windows", pool.StartTask.EnvironmentSettings.FirstOrDefault().Name);
            Assert.Equal("foo", pool.StartTask.EnvironmentSettings.FirstOrDefault().Value);
            Assert.Equal(3, pool.StartTask.MaxTaskRetryCount);
            Assert.Equal(ElevationLevel.NonAdmin, pool.StartTask.UserIdentity.AutoUser.ElevationLevel);
            Assert.Equal(false, pool.StartTask.WaitForSuccess);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ListComputeNodes()
        {
            var dateTime = DateTime.UtcNow;

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(baseRequest =>
            {
                var request = (Protocol.BatchRequest<Models.ComputeNodeListOptions, AzureOperationResponse<IPage<Models.ComputeNode>, Models.ComputeNodeListHeaders>>)baseRequest;

                request.ServiceRequestFunc = async (token) =>
                {
                    var response = new AzureOperationResponse<IPage<Models.ComputeNode>, Models.ComputeNodeListHeaders>
                    {
                        Body = new FakePage<Models.ComputeNode>(new[]
                        {
                                new Microsoft.Azure.Batch.Protocol.Models.ComputeNode
                                {
                                    State = Models.ComputeNodeState.Running,
                                    LastBootTime = dateTime,
                                    Id = "computeNode1",
                                },
                        })
                    };

                    var task = Task.FromResult(response);
                    return await task;
                };
            });

            List<ComputeNode> vms = client.PoolOperations.ListComputeNodes("foo", additionalBehaviors: new List<BatchClientBehavior> { interceptor }).ToList();

            Assert.Single(vms);
            Assert.Equal("computeNode1", vms[0].Id);
            Assert.Equal(ComputeNodeState.Running, vms[0].State);
            Assert.Equal(vms[0].LastBootTime, dateTime);
        }
    }
}