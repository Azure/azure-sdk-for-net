// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Host;
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

            Assert.That(options.BatchSize, Is.EqualTo(16));
            Assert.That(options.NewBatchThreshold, Is.EqualTo(8 * processorCount));
            Assert.That(options.MaxPollingInterval, Is.EqualTo(QueuePollingIntervals.DefaultMaximum));
            Assert.That(options.MessageEncoding, Is.EqualTo(QueueMessageEncoding.Base64));
        }

        [Test]
        public void NewBatchThreshold_CanSetAndGetValue()
        {
            int processorCount = Environment.ProcessorCount;

            QueuesOptions options = new QueuesOptions();

            // Unless explicitly set, NewBatchThreshold will be computed based
            // on the current BatchSize
            options.BatchSize = 20;
            Assert.That(options.NewBatchThreshold, Is.EqualTo(10 * processorCount));
            options.BatchSize = 1;
            Assert.That(options.NewBatchThreshold, Is.EqualTo(0 * processorCount));
            options.BatchSize = 32;
            Assert.That(options.NewBatchThreshold, Is.EqualTo(16 * processorCount));

            // Once set, the set value holds
            options.NewBatchThreshold = 1000;
            Assert.That(options.NewBatchThreshold, Is.EqualTo(1000));
            options.BatchSize = 8;
            Assert.That(options.NewBatchThreshold, Is.EqualTo(1000));

            // Value can be set to zero
            options.NewBatchThreshold = 0;
            Assert.That(options.NewBatchThreshold, Is.EqualTo(0));
        }

        [Test]
        public void VisibilityTimeout_CanGetAndSetValue()
        {
            QueuesOptions options = new QueuesOptions();

            Assert.That(options.VisibilityTimeout, Is.EqualTo(TimeSpan.Zero));

            options.VisibilityTimeout = TimeSpan.FromSeconds(30);
            Assert.That(options.VisibilityTimeout, Is.EqualTo(TimeSpan.FromSeconds(30)));
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
            Assert.That(options.MaxPollingInterval, Is.EqualTo(TimeSpan.FromMilliseconds(5000)));
            Assert.That(options.MessageEncoding, Is.EqualTo(QueueMessageEncoding.Base64));
        }
    }
}
