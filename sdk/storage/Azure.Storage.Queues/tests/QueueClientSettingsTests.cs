// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Storage.Queues.Tests
{
#pragma warning disable SCME0002 // Experimental type
    public class QueueClientSettingsTests
    {
        [Test]
        public void QueueUri_GetSet()
        {
            var settings = new QueueClientSettings();
            var uri = new Uri("https://account.queue.core.windows.net/myqueue");

            settings.QueueUri = uri;

            Assert.AreEqual(uri, settings.QueueUri);
        }

        [Test]
        public void ConnectionString_GetSet()
        {
            var settings = new QueueClientSettings();

            settings.ConnectionString = "DefaultEndpointsProtocol=https;AccountName=test";

            Assert.AreEqual("DefaultEndpointsProtocol=https;AccountName=test", settings.ConnectionString);
        }

        [Test]
        public void QueueName_GetSet()
        {
            var settings = new QueueClientSettings();

            settings.QueueName = "myqueue";

            Assert.AreEqual("myqueue", settings.QueueName);
        }

        [Test]
        public void Options_GetSet()
        {
            var settings = new QueueClientSettings();
            var options = new QueueClientOptions();

            settings.Options = options;

            Assert.AreSame(options, settings.Options);
        }
    }
#pragma warning restore SCME0002
}
