// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using NUnit.Framework;
using EventLevel = System.Diagnostics.Tracing.EventLevel;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class DataLakeStringToSignLoggingTests : DataLakeTestBase
    {
        public DataLakeStringToSignLoggingTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public void DataLakeSasStringToSignLogging()
        {
            // Arrange
            DataLakeServiceClient serviceClient = DataLakeClientBuilder.GetServiceClient_Hns();
            string fileSystemName = GetNewFileSystemName();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(serviceClient.GetFileSystemClient(fileSystemName));
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(1);

            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (e, message) =>
                {
                    Assert.AreEqual("GenerateServiceSasStringToSign", e.EventName);
                    Assert.IsTrue(message.Contains("Generated string to sign:\n"));
                },
                EventLevel.Verbose);

            // Act
            fileSystemClient.GenerateSasUri(
                permissions: DataLakeFileSystemSasPermissions.Read,
                expiresOn: expiresOn);
        }

        [RecordedTest]
        public async Task DataLakeUserDelegationSasStringToSignLogging()
        {
            // Arrange
            DataLakeServiceClient serviceClient = GetServiceClient_OAuth();
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(1);

            Response<UserDelegationKey> userDelegationKeyResponse = await serviceClient.GetUserDelegationKeyAsync(
                startsOn: startsOn,
                expiresOn: expiresOn);

            string fileSystemName = GetNewFileSystemName();

            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (e, message) =>
                {
                    Assert.AreEqual("GenerateUserDelegationSasStringToSign", e.EventName);
                    Assert.IsTrue(message.Contains("Generated string to sign:\n"));
                },
                EventLevel.Verbose);

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder(
                permissions: DataLakeFileSystemSasPermissions.Read,
                expiresOn: expiresOn);

            // Act
            dataLakeSasBuilder.ToSasQueryParameters(userDelegationKeyResponse.Value, serviceClient.AccountName);
        }
    }
}
