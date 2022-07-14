// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    public class QueuesOptionsTests
    {
        [Test]
        public void Constructor_Defaults()
        {
            int processorCount = Environment.ProcessorCount;
            QueuesOptions options = new QueuesOptions();

            Assert.AreEqual(16, options.BatchSize);
            Assert.AreEqual(8 * processorCount, options.NewBatchThreshold);
            Assert.AreEqual(QueuePollingIntervals.DefaultMaximum, options.MaxPollingInterval);
            Assert.AreEqual(QueueMessageEncoding.Base64, options.MessageEncoding);
            Assert.AreEqual(Constants.MaxDepthDefault, options.JsonSerializerSettings.MaxDepth);
            Assert.AreEqual(DateParseHandling.DateTimeOffset, options.JsonSerializerSettings.DateParseHandling);
            Assert.AreEqual(NullValueHandling.Ignore, options.JsonSerializerSettings.NullValueHandling);
            Assert.AreEqual(Formatting.Indented, options.JsonSerializerSettings.Formatting);
            Assert.AreEqual(Constants.MaxDepthDefault, options.JsonSerializerSettings.MaxDepth);
        }

        [Test]
        public void NewBatchThreshold_CanSetAndGetValue()
        {
            int processorCount = Environment.ProcessorCount;

            QueuesOptions options = new QueuesOptions();

            // Unless explicitly set, NewBatchThreshold will be computed based
            // on the current BatchSize
            options.BatchSize = 20;
            Assert.AreEqual(10 * processorCount, options.NewBatchThreshold);
            options.BatchSize = 1;
            Assert.AreEqual(0 * processorCount, options.NewBatchThreshold);
            options.BatchSize = 32;
            Assert.AreEqual(16 * processorCount, options.NewBatchThreshold);

            // Once set, the set value holds
            options.NewBatchThreshold = 1000;
            Assert.AreEqual(1000, options.NewBatchThreshold);
            options.BatchSize = 8;
            Assert.AreEqual(1000, options.NewBatchThreshold);

            // Value can be set to zero
            options.NewBatchThreshold = 0;
            Assert.AreEqual(0, options.NewBatchThreshold);
        }

        [Test]
        public void VisibilityTimeout_CanGetAndSetValue()
        {
            QueuesOptions options = new QueuesOptions();

            Assert.AreEqual(TimeSpan.Zero, options.VisibilityTimeout);

            options.VisibilityTimeout = TimeSpan.FromSeconds(30);
            Assert.AreEqual(TimeSpan.FromSeconds(30), options.VisibilityTimeout);
        }

        [Test]
        public void JsonSerialization()
        {
            var jo = new JObject
            {
                { "MaxPollingInterval", "00:00:05" },
                { "MessageEncoding", "Base64" }
            };
            var options = jo.ToObject<QueuesOptions>();
            Assert.AreEqual(TimeSpan.FromMilliseconds(5000), options.MaxPollingInterval);
            Assert.AreEqual(QueueMessageEncoding.Base64, options.MessageEncoding);
        }

        [Test]
        public void JsonSerializationSettings_CanGetAndSetValue()
        {
            int processorCount = Environment.ProcessorCount;

            QueuesOptions options = new QueuesOptions()
            {
                JsonSerializerSettings = new JsonSerializerSettings()
                {
                    MaxDepth = 64
                }
            };
            Assert.AreEqual(64, options.JsonSerializerSettings.MaxDepth);

            QueuesOptions options2 = new QueuesOptions()
            {
                JsonSerializerSettings = new JsonSerializerSettings()
                {
                    Formatting = Formatting.None
                }
            };
            Assert.AreEqual(Formatting.None, options2.JsonSerializerSettings.Formatting);
        }
    }
}
