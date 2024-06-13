// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using NUnit.Framework;
using EventLevel = System.Diagnostics.Tracing.EventLevel;

namespace Azure.Storage.Queues.Tests
{
    public class QueueStringToSignLoggingTests : QueueTestBase
    {
        public QueueStringToSignLoggingTests(bool async, QueueClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public void QueueSasStringToSignLogging()
        {
            // Arrange
            QueueServiceClient serviceClient = GetServiceClient_SharedKey();
            string queueName = GetNewQueueName();
            QueueClient queueClient = InstrumentClient(serviceClient.GetQueueClient(queueName));
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(1);

            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (e, message) =>
                {
                    Assert.AreEqual("GenerateServiceSasStringToSign", e.EventName);
                    Assert.IsTrue(message.Contains("Generated string to sign:\n"));
                },
                EventLevel.Verbose);

            // Act
            queueClient.GenerateSasUri(
                permissions: Sas.QueueSasPermissions.Read,
                expiresOn: expiresOn);
        }
    }
}
