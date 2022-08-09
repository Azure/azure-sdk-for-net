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

namespace Azure.ResourceManager.StreamAnalytics.Tests.Helpers
{
    public static class ResourceDataHelpers
    {
        private const string dummySSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC+wWK73dCr+jgQOAxNsHAnNNNMEMWOHYEccp6wJm2gotpr9katuF/ZAdou5AaW1C61slRkHRkpRRX9FA9CYBiitZgvCCz+3nWNN7l/Up54Zps/pHWGZLHNJZRYyAB6j5yVLMVHIHriY49d/GZTZVNB8GoJv9Gakwc/fuEZYYl4YDFiGMBP///TzlI4jhiJzjKnEvqPFki5p2ZRJqcbCiF4pJrxUQR/RXqVFQdbRLZgYfJ8xGB878RENq3yQ39d8dVOkq4edbkzwcUmwwwkYVPIoDGsYLaRHnG+To7FvMeyO7xDVQkMKzopTQV8AuKpyvpqu0a9pWOMaiCyDytO7GGN you@me.com";

        // Temporary solution since the one in Azure.ResourceManager.CognitiveServices is internal
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
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
            Assert.AreEqual(r1.Location, r2.Location);
            Assert.AreEqual(r1.Tags, r2.Tags);
        }

        #region Cluster
        public static void AssertCluster(StreamAnalyticsClusterData cluster1, StreamAnalyticsClusterData cluster2)
        {
            AssertTrackedResource(cluster1, cluster2);
            Assert.AreEqual(cluster1.Name, cluster2.Name);
        }

        public static StreamAnalyticsClusterData GetClusterData(AzureLocation location)
        {
            var data = new StreamAnalyticsClusterData(location)
            {
                Sku = new ClusterSku()
                {
                    Name = "Default",
                    Capacity = 36
                },
                Properties = new ClusterProperties(),
            };
            return data;
        }
        #endregion

        #region PrivateEndPoint
        public static void AssertEndPoint(StreamAnalyticsPrivateEndpointData point1, StreamAnalyticsPrivateEndpointData point2)
        {
            Assert.AreEqual(point1.Name, point2.Name);
            Assert.AreEqual(point1.Id, point2.Id);
            Assert.AreEqual(point1.ResourceType, point2.ResourceType);
            Assert.AreEqual(point1.ETag, point2.ETag);
        }
        public static StreamAnalyticsPrivateEndpointData GetEndPointData()
        {
            var data = new StreamAnalyticsPrivateEndpointData()
            {
                Properties = new PrivateEndpointProperties()
            };
            return data;
        }
        #endregion

        #region StreamingJob
        public static void AssertJob(StreamingJobData job1, StreamingJobData job2)
        {
            AssertTrackedResource(job1, job2);
            Assert.AreEqual(job1.Name, job2.Name);
        }
        public static StreamingJobData GetStreamingJobData(AzureLocation location)
        {
            var data = new StreamingJobData(location)
            {
                Sku = new StreamAnalyticsSku()
                {
                    Name = "Standard"
                },
                EventsOutOfOrderPolicy = new EventsOutOfOrderPolicy("Drop"),
                OutputErrorPolicy = new OutputErrorPolicy("Drop"),
                EventsOutOfOrderMaxDelayInSeconds = 0,
                EventsLateArrivalMaxDelayInSeconds = 5,
                DataLocale = "en-US",
                CompatibilityLevel = new CompatibilityLevel("1.0"),
                Transformation = new StreamingJobTransformationData()
                {
                    StreamingUnits = 1,
                    Query = "Select Id, Name from inputtest"
                }
            };
            return data;
        }
        #endregion

        #region StreamingJobInpt
        public static void AssertInput(StreamingJobInputData input1, StreamingJobInputData  input2)
        {
            Assert.AreEqual(input1.Name, input2.Name);
            Assert.AreEqual(input1.Id, input2.Id);
            Assert.AreEqual(input1.ResourceType, input2.ResourceType);
        }
        public static StreamingJobInputData GetStreamingJobInputData()
        {
            var data = new StreamingJobInputData()
            {
                Properties = new InputProperties()
            };
            return data;
        }
        #endregion

        #region JobOutput
        public static void AssertOutput(StreamingJobOutputData output1, StreamingJobOutputData output2)
        {
            Assert.AreEqual(output1.Name, output2.Name);
            Assert.AreEqual(output1.Id, output2.Id);
            Assert.AreEqual(output1.ResourceType, output2.ResourceType);
        }
        public static StreamingJobOutputData GetStreamingJobOutputData()
        {
            return new StreamingJobOutputData();
        }
        #endregion

        #region Function
        public static void AssertFunction(StreamingJobFunctionData function1, StreamingJobFunctionData function2)
        {
            Assert.AreEqual(function1.Name, function2.Name);
            Assert.AreEqual(function1.Id, function2.Id);
            Assert.AreEqual(function1.ResourceType, function2.ResourceType);
        }
        public static StreamingJobFunctionData GetStreamingJobFunctionData()
        {
            return new StreamingJobFunctionData()
            {
                Properties = new FunctionProperties()
                {
                    FunctionPropertiesType = "Scalar",
                    Binding = new FunctionBinding()
                    {
                        FunctionBindingType = "Microsoft.StreamAnalytics/JavascriptUdf"
                    },
                    Output = new FunctionOutput()
                    {
                        DataType = "Any"
                    }
                }
            };
        }
        #endregion

        #region Transformation
        public static void AssertTransformation(StreamingJobTransformationData transform1, StreamingJobTransformationData transform2)
        {
            Assert.AreEqual(transform1.Name, transform2.Name);
            Assert.AreEqual(transform1.Id, transform2.Id);
            Assert.AreEqual(transform1.ResourceType, transform2.ResourceType);
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
