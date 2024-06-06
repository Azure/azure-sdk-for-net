// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Storage.Sas;
using NUnit.Framework;
using EventLevel = System.Diagnostics.Tracing.EventLevel;

namespace Azure.Storage.Files.Shares.Tests
{
    public class ShareFileStringToSignLoggingTests : FileTestBase
    {
        public ShareFileStringToSignLoggingTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public void ShareFileSasStringToSignLogging()
        {
            // Arrange
            ShareServiceClient serviceClient = SharesClientBuilder.GetServiceClient_SharedKey();
            string shareName = GetNewShareName();
            ShareClient shareClient = InstrumentClient(serviceClient.GetShareClient(shareName));
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(1);

            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (e, message) =>
                {
                    Assert.AreEqual("GenerateServiceSasStringToSign", e.EventName);
                    Assert.IsTrue(message.Contains("Generated string to sign:\n"));
                },
                EventLevel.Verbose);

            // Act
            shareClient.GenerateSasUri(
                permissions: ShareSasPermissions.Read,
                expiresOn: expiresOn);
        }
    }
}
