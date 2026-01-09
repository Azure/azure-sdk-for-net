// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.StreamAnalytics.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Azure.Core;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Azure.ResourceManager.StreamAnalytics.Tests.Helpers
{
    public static class ResourceDataHelpers
    {
        // Temporary solution since the one in Azure.ResourceManager.StreamAnalytics is internal
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)
        {
            dest.Clear();
            foreach (var kv in src)
            {
                dest.Add(kv);
            }

            return dest;
        }

        public static void AssertTrackedResource(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.Multiple(() =>
            {
                Assert.That(r2.Name, Is.EqualTo(r1.Name));
                Assert.That(r2.Id, Is.EqualTo(r1.Id));
                Assert.That(r2.ResourceType, Is.EqualTo(r1.ResourceType));
                Assert.That(r2.Location, Is.EqualTo(r1.Location));
                Assert.That(r2.Tags, Is.EqualTo(r1.Tags));
            });
        }

        #region Cluster
        public static void AssertCluster(StreamAnalyticsClusterData cluster1, StreamAnalyticsClusterData cluster2)
        {
            AssertTrackedResource(cluster1, cluster2);
            Assert.That(cluster2.Name, Is.EqualTo(cluster1.Name));
        }

        public static StreamAnalyticsClusterData GetClusterData(AzureLocation location)
        {
            var data = new StreamAnalyticsClusterData(location)
            {
                Sku = new StreamAnalyticsClusterSku()
                {
                    Name = "Default",
                    Capacity = 36
                },
                Properties = new StreamAnalyticsClusterProperties(),
            };
            return data;
        }
        #endregion

        #region PrivateEndPoint
        public static void AssertEndPoint(StreamAnalyticsPrivateEndpointData point1, StreamAnalyticsPrivateEndpointData point2)
        {
            Assert.Multiple(() =>
            {
                Assert.That(point2.Name, Is.EqualTo(point1.Name));
                Assert.That(point2.Id, Is.EqualTo(point1.Id));
                Assert.That(point2.ResourceType, Is.EqualTo(point1.ResourceType));
                Assert.That(point2.ETag, Is.EqualTo(point1.ETag));
            });
        }
        public static StreamAnalyticsPrivateEndpointData GetEndPointData()
        {
            var data = new StreamAnalyticsPrivateEndpointData()
            {
                Properties = new StreamAnalyticsPrivateEndpointProperties()
                {
                    ManualPrivateLinkServiceConnections =
                    {
                        new StreamAnalyticsPrivateLinkServiceConnection()
                        {
                            PrivateLinkServiceId = new ResourceIdentifier("/subscriptions/113d0adc-1017-40e9-84ff-763f52896cc2/resourceGroups/sjrg5830/providers/Microsoft.EventHub/namespaces/testeventhub4asacluster"),
                            GroupIds =
                            {
                                "namespace"
                            }
                        }
                    }
                }
            };
            return data;
        }
        #endregion

        #region StreamingJob
        public static void AssertJob(StreamingJobData job1, StreamingJobData job2)
        {
            AssertTrackedResource(job1, job2);
            Assert.That(job2.Name, Is.EqualTo(job1.Name));
        }
        public static StreamingJobData GetStreamingJobData(AzureLocation location)
        {
            var data = new StreamingJobData(location)
            {
                Sku = new StreamAnalyticsSku()
                {
                    Name = "Standard"
                },
                EventsOutOfOrderPolicy = EventsOutOfOrderPolicy.Drop,
                OutputErrorPolicy = StreamingJobOutputErrorPolicy.Drop,
                EventsOutOfOrderMaxDelayInSeconds = 0,
                EventsLateArrivalMaxDelayInSeconds = 5,
                DataLocalion = "en-US",
                CompatibilityLevel = StreamingJobCompatibilityLevel.Level1_0,
            };
            return data;
        }
        #endregion

        #region StreamingJobInput
        public static void AssertInput(StreamingJobInputData input1, StreamingJobInputData  input2)
        {
            Assert.Multiple(() =>
            {
                Assert.That(input2.Name, Is.EqualTo(input1.Name));
                Assert.That(input2.Id, Is.EqualTo(input1.Id));
                Assert.That(input2.ResourceType, Is.EqualTo(input1.ResourceType));
            });
        }
        public static StreamingJobInputData GetStreamingJobInputData()
        {
            var data = new StreamingJobInputData()
            {
                Properties = new StreamInputProperties()
                {
                    Datasource = new BlobStreamInputDataSource()
                    {
                        StorageAccounts =
                        {
                            new StreamAnalyticsStorageAccount()
                            {
                                AccountKey = "$testAccountName$",
                                AccountName = "myhditest0811hdistorage"
                            }
                        },
                        Container = "differentContainer",
                        PathPattern = "{date}/{time}",
                        DateFormat = "yyyy/MM/dd",
                        TimeFormat = "HH",
                        SourcePartitionCount = 16
                    },
                    Serialization = new CsvFormatSerialization()
                    {
                        FieldDelimiter = ",",
                        Encoding = StreamAnalyticsDataSerializationEncoding.Utf8
                    }
                }
            };
            return data;
        }
        #endregion

        #region JobOutput
        public static void AssertOutput(StreamingJobOutputData output1, StreamingJobOutputData output2)
        {
            Assert.Multiple(() =>
            {
                Assert.That(output2.Name, Is.EqualTo(output1.Name));
                Assert.That(output2.Id, Is.EqualTo(output1.Id));
                Assert.That(output2.ResourceType, Is.EqualTo(output1.ResourceType));
            });
        }
        public static StreamingJobOutputData GetStreamingJobOutputData()
        {
            return new StreamingJobOutputData()
            {
                Serialization = new CsvFormatSerialization()
                {
                    FieldDelimiter = ",",
                    Encoding = StreamAnalyticsDataSerializationEncoding.Utf8
                },
                Datasource = new BlobOutputDataSource()
                {
                    StorageAccounts =
                    {
                        new StreamAnalyticsStorageAccount()
                        {
                            AccountKey = "$testAccountName$",
                            AccountName = "myhditest0811hdistorage"
                        }
                    },
                    Container = "differentContainer",
                    PathPattern = "{date}/{time}",
                    DateFormat = "yyyy/MM/dd",
                    TimeFormat = "HH"
                }
            };
        }
        #endregion

        #region Function
        public static void AssertFunction(StreamingJobFunctionData function1, StreamingJobFunctionData function2)
        {
            Assert.Multiple(() =>
            {
                Assert.That(function2.Name, Is.EqualTo(function1.Name));
                Assert.That(function2.Id, Is.EqualTo(function1.Id));
                Assert.That(function2.ResourceType, Is.EqualTo(function1.ResourceType));
            });
        }
        public static StreamingJobFunctionData GetStreamingJobFunctionData()
        {
            return new StreamingJobFunctionData()
            {
                Properties = new ScalarFunctionProperties()
                {
                    Binding = new JavaScriptFunctionBinding()
                    {
                        Script = @"function (x, y) { return x + y; }"
                    },
                    Output = new StreamingJobFunctionOutput()
                    {
                        DataType = "Any"
                    },
                    Inputs =
                    {
                        new StreamingJobFunctionInput()
                        {
                            DataType = @"nvarchar(max)",
                            IsConfigurationParameter = null
                        }
                    }
                }
            };
        }
        #endregion

        #region Transformation
        public static void AssertTransformation(StreamingJobTransformationData transform1, StreamingJobTransformationData transform2)
        {
            Assert.Multiple(() =>
            {
                Assert.That(transform2.Name, Is.EqualTo(transform1.Name));
                Assert.That(transform2.Id, Is.EqualTo(transform1.Id));
                Assert.That(transform2.ResourceType, Is.EqualTo(transform1.ResourceType));
            });
        }
        public static StreamingJobTransformationData GetStreamingJobTransformation()
        {
            return new StreamingJobTransformationData()
            {
                StreamingUnits = 6,
                Query = "Select Id, Name from inputtest"
            };
        }
        #endregion
    }
}
