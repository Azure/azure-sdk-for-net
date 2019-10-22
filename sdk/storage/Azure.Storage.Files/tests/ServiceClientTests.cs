﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Common;
using Azure.Storage.Files.Models;
using Azure.Storage.Files.Tests;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.Test
{
    public class ServiceClientTests : FileTestBase
    {
        public ServiceClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var fileEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var fileSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (default, default), (default, default), (default, default), (fileEndpoint, fileSecondaryEndpoint));

            FileServiceClient service = InstrumentClient(new FileServiceClient(connectionString.ToString(true), GetOptions()));

            var builder = new FileUriBuilder(service.Uri);

            Assert.AreEqual("", builder.ShareName);
            Assert.AreEqual("", builder.DirectoryOrFilePath);
            //Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            FileServiceClient service = GetServiceClient_SharedKey();

            // Act
            Response<FileServiceProperties> properties = await service.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(properties);
            var accountName = new FileUriBuilder(service.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => service.AccountName);
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            FileServiceClient service = InstrumentClient(
                new FileServiceClient(
                    s_invalidUri,
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey),
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetPropertiesAsync(),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        [NonParallelizable]
        public async Task SetPropertiesAsync()
        {
            // Arrange
            FileServiceClient service = GetServiceClient_SharedKey();
            Response<FileServiceProperties> properties = await service.GetPropertiesAsync();
            _ = properties.Value.Cors.ToArray();
            properties.Value.Cors.Clear();
            properties.Value.Cors.Add(
                new FileCorsRule
                {
                    MaxAgeInSeconds = 1000,
                    AllowedHeaders = "x-ms-meta-data*,x-ms-meta-target*,x-ms-meta-abc",
                    AllowedMethods = "PUT,GET",
                    AllowedOrigins = "*",
                    ExposedHeaders = "x-ms-meta-*"
                });

            // Act
            await service.SetPropertiesAsync(properties: properties);

            // Assert
            properties = await service.GetPropertiesAsync();
            Assert.AreEqual(1, properties.Value.Cors.Count());
            Assert.IsTrue(properties.Value.Cors[0].MaxAgeInSeconds == 1000);
        }

        [Test]
        public async Task SetPropertiesAsync_Error()
        {
            // Arrange
            FileServiceClient service = GetServiceClient_SharedKey();
            Response<FileServiceProperties> properties = await service.GetPropertiesAsync();
            FileServiceClient fakeService = InstrumentClient(
                new FileServiceClient(
                    new Uri("https://error.file.core.windows.net"),
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey),
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fakeService.SetPropertiesAsync(properties),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task ListSharesSegmentAsync()
        {
            // Arrange
            FileServiceClient service = GetServiceClient_SharedKey();

            // Ensure at least one share
            using (GetNewShare(out ShareClient share, service: service))
            {
                var shares = new List<ShareItem>();
                await foreach (Page<ShareItem> page in service.GetSharesAsync().AsPages())
                {
                    shares.AddRange(page.Values);
                }

                // Assert
                Assert.AreNotEqual(0, shares.Count);
                Assert.AreEqual(shares.Count, shares.Select(c => c.Name).Distinct().Count());
                Assert.IsTrue(shares.Any(c => share.Uri == service.GetShareClient(c.Name).Uri));
            }
        }

        [Test]
        public async Task ListShareSegmentAsync_Error()
        {
            // Arrange
            FileServiceClient service = InstrumentClient(
                new FileServiceClient(
                    new Uri("https://error.file.core.windows.net"),
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey),
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetSharesAsync().ToListAsync(),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task CreateShareAsync()
        {
            var name = GetNewShareName();
            FileServiceClient service = GetServiceClient_SharedKey();
            try
            {
                ShareClient share = InstrumentClient((await service.CreateShareAsync(name)).Value);
                Response<ShareProperties> properties = await share.GetPropertiesAsync();
                Assert.AreNotEqual(0, properties.Value.QuotaInGB);
            }
            finally
            {
                await service.DeleteShareAsync(name, false);
            }
        }

        [Test]
        public async Task DeleteShareAsync()
        {
            var name = GetNewShareName();
            FileServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient((await service.CreateShareAsync(name)).Value);

            await service.DeleteShareAsync(name, false);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await share.GetPropertiesAsync());
        }


    }
}
