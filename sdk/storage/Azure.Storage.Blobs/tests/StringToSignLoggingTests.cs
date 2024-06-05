// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Storage.Sas;
using Azure.Storage.Test.Shared;
using NUnit.Framework;
using EventLevel = System.Diagnostics.Tracing.EventLevel;

namespace Azure.Storage.Blobs.Tests
{
    public class StringToSignLoggingTests : BlobTestBase
    {
        public StringToSignLoggingTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void AccountSasStringToSignLogging()
        {
            // Arrange
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SharedKey();
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(1);
            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (e, message) =>
                {
                    Assert.AreEqual($"Generated string to sign:\n{service.AccountName}\nw\nb\nsco\n\n{SasExtensions.FormatTimesForSasSigning(expiresOn)}\n\n\n{SasQueryParametersInternals.DefaultSasVersionInternal}\n\n", message);
                },
                EventLevel.Verbose);

            // Act
            Uri sasUri = service.GenerateAccountSasUri(
                permissions: AccountSasPermissions.Write,
                expiresOn: expiresOn,
                AccountSasResourceTypes.All);
        }
    }
}
