// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Common;
using Azure.Storage.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestConstants = Azure.Storage.Test.Constants;

namespace Azure.Storage.Blobs.Test
{
    [TestClass]
    public class BlobClientTests
    {
        [TestMethod]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new SharedKeyCredentials(accountName, accountKey);
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (blobEndpoint, blobSecondaryEndpoint), (default, default), (default, default), (default, default));

            var containerName = TestHelper.GetNewContainerName();
            var blobName = TestHelper.GetNewBlobName();

            var blob = new BlobClient(connectionString.ToString(true), containerName, blobName, TestHelper.GetOptions<BlobConnectionOptions>());

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual(containerName, builder.ContainerName);
            Assert.AreEqual(blobName, builder.BlobName);
            Assert.AreEqual("accountName", builder.AccountName);
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task DownloadAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var data = TestHelper.GetRandomBuffer(Constants.KB);
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                // Act
                var response = await blob.DownloadAsync();
                
                // Assert
                Assert.AreEqual(data.Length, response.Value.ContentLength);
                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                Assert.AreEqual(data.Length, actual.Length);
                var actualData = actual.GetBuffer();
                Assert.IsTrue(data.SequenceEqual(actualData));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task DownloadAsync_WithUnreliableConnection()
        {
            // Arrange
            var service = new BlobServiceClient(
                    new Uri(TestConfigurations.DefaultTargetTenant.BlobServiceEndpoint),
                    TestHelper.GetFaultyBlobConnectionOptions(
                        new SharedKeyCredentials(TestConfigurations.DefaultTargetTenant.AccountName, TestConfigurations.DefaultTargetTenant.AccountKey),
                        raiseAt: 256 * Constants.KB,
                        raise: new Exception("Unexpected")));

            using (TestHelper.GetNewContainer(out var container, service: service))
            {
                var data = TestHelper.GetRandomBuffer(Constants.KB);

                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                // Act
                var response = await blob.DownloadAsync();

                // Assert
                Assert.AreEqual(data.Length, response.Value.ContentLength);
                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                Assert.AreEqual(data.Length, actual.Length);
                var actualData = actual.GetBuffer();
                Assert.IsTrue(data.SequenceEqual(actualData));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task DownloadAsync_Range()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var data = TestHelper.GetRandomBuffer(10 * Constants.KB);
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var offset = Constants.KB;
                var count = 2 * Constants.KB;
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                // Act
                var response = await blob.DownloadAsync(range: new HttpRange(offset, count));

                // Assert
                Assert.AreEqual(count, response.Value.ContentLength);
                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                Assert.AreEqual(count, actual.Length);
                var actualData = actual.GetBuffer();
                Assert.IsTrue(data.Skip(offset).Take(count).SequenceEqual(actualData));
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditions_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task DownloadAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var data = TestHelper.GetRandomBuffer(Constants.KB);
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);
                var accessConditions = this.BuildAccessConditions(parameters);

                // Act
                var response = await blob.DownloadAsync(accessConditions: accessConditions);

                // Assert
                Assert.AreEqual(data.Length, response.Value.ContentLength);
                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                Assert.AreEqual(data.Length, actual.Length);
                var actualData = actual.GetBuffer();
                Assert.IsTrue(data.SequenceEqual(actualData));
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task DownloadAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var data = TestHelper.GetRandomBuffer(Constants.KB);
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                var accessConditions = this.BuildAccessConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.DownloadAsync(accessConditions: accessConditions),
                    e => { });
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task DownloadAsync_MD5()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var data = TestHelper.GetRandomBuffer(10 * Constants.KB);
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var offset = Constants.KB;
                var count = 2 * Constants.KB;
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                // Act
                var response = await blob.DownloadAsync(
                    range: new HttpRange(offset, count), 
                    rangeGetContentHash: true);

                // Assert
                var expectedMD5 = MD5.Create().ComputeHash(data.Skip(offset).Take(count).ToArray());
                Assert.IsTrue(expectedMD5.SequenceEqual(response.Value.ContentHash));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task DownloadAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.DownloadAsync(),
                    e => Assert.AreEqual("The specified blob does not exist.", e.Message.Split('\n')[0]));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task StartCopyFromUriAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var srcBlob = await this.GetNewBlobClient(container);
                var destBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // Act
                var response = await destBlob.StartCopyFromUriAsync(srcBlob.Uri);

                // Assert
                // data copied within an account, so copy should be instantaneous
                Assert.AreEqual(CopyStatus.Success, response.Value.CopyStatus);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task StartCopyFromUriAsync_Metadata()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var srcBlob = await this.GetNewBlobClient(container);
                var metadata = TestHelper.BuildMetadata();

                var destBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // Act
                await destBlob.StartCopyFromUriAsync(
                    source: srcBlob.Uri,
                    metadata: metadata);

                // Assert
                var response = await destBlob.GetPropertiesAsync();
                TestHelper.AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditions_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task StartCopyFromUriAsync_Source_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var srcBlob = await this.GetNewBlobClient(container);

                parameters.Match = await TestHelper.SetupBlobMatchCondition(srcBlob, parameters.Match);
                parameters.LeaseId = await TestHelper.SetupBlobLeaseCondition(srcBlob, parameters.LeaseId);
                var sourceAccessConditions = this.BuildAccessConditions(
                    parameters: parameters);

                var destBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // Act
                var response = await destBlob.StartCopyFromUriAsync(
                    source: srcBlob.Uri,
                    sourceAccessConditions: sourceAccessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task StartCopyFromUriAsync_Source_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var srcBlob = await this.GetNewBlobClient(container);

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(srcBlob, parameters.NoneMatch);

                var sourceAccessConditions = this.BuildAccessConditions(
                    parameters: parameters,
                    lease: false);

                var destBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    destBlob.StartCopyFromUriAsync(
                        source: srcBlob.Uri, 
                        sourceAccessConditions: sourceAccessConditions),
                    e => { });
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditions_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task StartCopyFromUriAsync_Destination_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var data = TestHelper.GetRandomBuffer(Constants.KB);
                var srcBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                using (var stream = new MemoryStream(data))
                {
                    await srcBlob.UploadAsync(stream);
                }
                var destBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // destBlob needs to exist so we can get its lease and etag
                using (var stream = new MemoryStream(data))
                {
                    await destBlob.UploadAsync(stream);
                }

                parameters.Match = await TestHelper.SetupBlobMatchCondition(destBlob, parameters.Match);
                parameters.LeaseId = await TestHelper.SetupBlobLeaseCondition(destBlob, parameters.LeaseId);

                var accessConditions = this.BuildAccessConditions(parameters: parameters);

                // Act
                var response = await destBlob.StartCopyFromUriAsync(
                    source: srcBlob.Uri,
                    destinationAccessConditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task StartCopyFromUriAsync_Destination_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var data = TestHelper.GetRandomBuffer(Constants.KB);
                var srcBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                using (var stream = new MemoryStream(data))
                {
                    await srcBlob.UploadAsync(stream);
                }

                // destBlob needs to exist so we can get its etag
                var destBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                using (var stream = new MemoryStream(data))
                {
                    await destBlob.UploadAsync(stream);
                }

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(destBlob, parameters.NoneMatch);
                var accessConditions = this.BuildAccessConditions(parameters: parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    destBlob.StartCopyFromUriAsync(
                        source: srcBlob.Uri,
                        destinationAccessConditions: accessConditions),
                    e => { });
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task StartCopyFromUriAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var srcBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var destBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    destBlob.StartCopyFromUriAsync(srcBlob.Uri),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task AbortCopyFromUriAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Blob);
                var data = TestHelper.GetRandomBuffer(8 * Constants.MB);

                var srcBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                using (var stream = new MemoryStream(data))
                {
                    await srcBlob.UploadAsync(stream);
                }

                var secondaryService = TestHelper.GetServiceClient_SecondaryAccount_SharedKey();
                using (TestHelper.GetNewContainer(out var destContainer, service: secondaryService))
                {
                    var destBlob = destContainer.GetBlockBlobClient(TestHelper.GetNewBlobName());

                    var copyResponse = await destBlob.StartCopyFromUriAsync(srcBlob.Uri);

                    // Act
                    try
                    {
                        var response = await destBlob.AbortCopyFromUriAsync(copyResponse.Value.CopyId);

                        // Assert
                        Assert.IsNotNull(response.Headers.RequestId);
                    }
                    catch (StorageRequestFailedException e) when (e.ErrorCode == "NoPendingCopyOperation")
                    {
                        Assert.Inconclusive("Copy may have completed too quickly to abort.");
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task AbortCopyFromUriAsync_Lease()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Blob);
                var data = TestHelper.GetRandomBuffer(8 * Constants.MB);

                var srcBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                using (var stream = new MemoryStream(data))
                {
                    await srcBlob.UploadAsync(stream);
                }
                var secondaryService = TestHelper.GetServiceClient_SecondaryAccount_SharedKey();
                using (TestHelper.GetNewContainer(out var destContainer, service: secondaryService))
                {
                    var destBlob = destContainer.GetBlockBlobClient(TestHelper.GetNewBlobName());
                    using (var stream = new MemoryStream(data))
                    {
                        await destBlob.UploadAsync(stream);
                    }

                    var duration = -1;
                    var leaseResponse = await destBlob.AcquireLeaseAsync(duration);

                    var copyResponse = await destBlob.StartCopyFromUriAsync(
                        source: srcBlob.Uri,
                        destinationAccessConditions: new BlobAccessConditions
                        {
                            LeaseAccessConditions = new LeaseAccessConditions
                            {
                                LeaseId = leaseResponse.Value.LeaseId
                            }
                        });


                    // Act
                    try
                    {
                        var response = await destBlob.AbortCopyFromUriAsync(
                            copyId: copyResponse.Value.CopyId,
                            leaseAccessConditions: new LeaseAccessConditions
                            {
                                LeaseId = leaseResponse.Value.LeaseId
                            });

                        // Assert
                        Assert.IsNotNull(response.Headers.RequestId);
                    }
                    catch (StorageRequestFailedException e) when (e.ErrorCode == "NoPendingCopyOperation")
                    {
                        Assert.Inconclusive("Copy may have completed too quickly to abort.");
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task AbortCopyFromUriAsync_LeaseFail()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Blob);
                var data = TestHelper.GetRandomBuffer(8 * Constants.MB);

                var srcBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                using (var stream = new MemoryStream(data))
                {
                    await srcBlob.UploadAsync(stream);
                }
                var secondaryService = TestHelper.GetServiceClient_SecondaryAccount_SharedKey();
                using (TestHelper.GetNewContainer(out var destContainer, service: secondaryService))
                {
                    var destBlob = destContainer.GetBlockBlobClient(TestHelper.GetNewBlobName());
                    using (var stream = new MemoryStream(data))
                    {
                        await destBlob.UploadAsync(stream);
                    }

                    var copyResponse = await destBlob.StartCopyFromUriAsync(
                        source: srcBlob.Uri);

                    var leaseId = Guid.NewGuid().ToString();

                    // Act
                    try
                    {
                        await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                            destBlob.AbortCopyFromUriAsync(
                                copyId: copyResponse.Value.CopyId,
                                leaseAccessConditions: new LeaseAccessConditions
                                {
                                    LeaseId = leaseId
                                }),
                            e =>
                            {
                                switch (e.ErrorCode)
                                {
                                    case "NoPendingCopyOperation":
                                        Assert.Inconclusive("Copy may have completed too quickly to abort.");
                                        break;
                                    default:
                                        Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode);
                                        break;
                                }
                            }
                            );
                    }
                    catch (StorageRequestFailedException e) when (e.ErrorCode == "NoPendingCopyOperation")
                    {
                        Assert.Inconclusive("Copy may have completed too quickly to abort.");
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task AbortCopyFromUriAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var copyId = Guid.NewGuid().ToString();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.AbortCopyFromUriAsync(copyId),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task DeleteAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                // Act
                var response = await blob.DeleteAsync();

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task DeleteAsync_Options()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);
                await blob.CreateSnapshotAsync();

                // Act
                await blob.DeleteAsync(deleteOptions: DeleteSnapshotsOption.Only);

                // Assert
                var response = await blob.GetPropertiesAsync();
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditions_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task DeleteAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);
                var accessConditions = this.BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                var response = await blob.DeleteAsync(accessConditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task DeleteAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                var accessConditions = this.BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException, Response>(
                    blob.DeleteAsync(accessConditions: accessConditions),
                    e => { });
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task DeleteAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException, Response>(
                    blob.DeleteAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        //[TestMethod]
        //[TestCategory("Live")]
        //public async Task DeleteAsync_Batch()
        //{
        //    using (TestHelper.GetNewContainer(out var container, serviceUri: TestHelper.GetServiceUri_PreviewAccount_SharedKey()))
        //    {
        //        const int blobSize = Constants.KB;
        //        var data = TestHelper.GetRandomBuffer(blobSize);

        //        var blob1 = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
        //        using (var stream = new MemoryStream(data))
        //        {
        //            await blob1.UploadAsync(stream);
        //        }

        //        var blob2 = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
        //        using (var stream = new MemoryStream(data))
        //        {
        //            await blob2.UploadAsync(stream);
        //        }

        //        var batch =
        //            blob1.DeleteAsync()
        //            .And(blob2.DeleteAsync())
        //            ;

        //        var result = await batch;

        //        Assert.IsNotNull(result);
        //        Assert.AreEqual(2, result.Length);
        //        Assert.IsNotNull(result[0].RequestId);
        //        Assert.IsNotNull(result[1].RequestId);
        //    }
        //}

        [TestMethod]
        [TestCategory("Live")]
        [DoNotParallelize]
        public async Task UndeleteAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await TestHelper.EnableSoftDelete();
                var blob = await this.GetNewBlobClient(container);

                await blob.DeleteAsync();

                // Act
                try
                {
                    var response = await blob.UndeleteAsync();

                    // Assert
                    response.Headers.TryGetValue("x-ms-version", out var version);
                    Assert.IsNotNull(version);
                }
                catch (StorageRequestFailedException ex) when (ex.ErrorCode == StorageErrorCode.BlobNotFound)
                {
                    Assert.Inconclusive("Delete may have happened before soft delete was fully enabled!");
                }
                finally
                {
                    // Cleanup
                    await TestHelper.DisableSoftDelete();
                }
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task UndeleteAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.UndeleteAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetAccountInfoAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // Act
                var response = await blob.GetAccountInfoAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetAccountInfoAsync_Error()
        {
            // Arrange
            var service = new BlobServiceClient(
                TestHelper.GetServiceClient_SharedKey().Uri,
                TestHelper.GetOptions<BlobConnectionOptions>());
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                blob.GetAccountInfoAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
    }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetPropertiesAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                // Act
                var response = await blob.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetPropertiesAsync_ContainerSAS()
        {
            var containerName = TestHelper.GetNewContainerName();
            var blobName = TestHelper.GetNewBlobName();
            using (TestHelper.GetNewContainer(out var container, containerName: containerName))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container, blobName);

                var sasBlob = TestHelper.GetServiceClient_BlobServiceSas_Container(
                    containerName: containerName)
                        .GetBlobContainerClient(containerName)
                        .GetBlockBlobClient(blobName);

                // Act
                var response = await sasBlob.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetPropertiesAsync_ContainerIdentitySAS()
        {
            var oauthService = await TestHelper.GetServiceClient_OauthAccount();
            var containerName = TestHelper.GetNewContainerName();
            var blobName = TestHelper.GetNewBlobName();
            using (TestHelper.GetNewContainer(out var container, containerName: containerName, service: oauthService))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container, blobName);

                var userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                    start: null,
                    expiry: DateTimeOffset.UtcNow.AddHours(1));

                var identitySasBlob = TestHelper.GetServiceClient_BlobServiceIdentitySas_Container(
                    containerName: containerName,
                    userDelegationKey: userDelegationKey)
                        .GetBlobContainerClient(containerName)
                        .GetBlockBlobClient(blobName);

                // Act
                var response = await identitySasBlob.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetPropertiesAsync_BlobSAS()
        {
            var containerName = TestHelper.GetNewContainerName();
            var blobName = TestHelper.GetNewBlobName();
            using (TestHelper.GetNewContainer(out var container, containerName: containerName))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container, blobName);

                var sasBlob = TestHelper.GetServiceClient_BlobServiceSas_Blob(
                    containerName: containerName,
                    blobName: blobName)
                        .GetBlobContainerClient(containerName)
                        .GetBlockBlobClient(blobName);

                // Act
                var response = await sasBlob.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetPropertiesAsync_BlobIdentitySAS()
        {
            var oauthService = await TestHelper.GetServiceClient_OauthAccount();
            var containerName = TestHelper.GetNewContainerName();
            var blobName = TestHelper.GetNewBlobName();
            using (TestHelper.GetNewContainer(out var container, containerName: containerName, service: oauthService))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container, blobName);

                var userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                    start: null,
                    expiry: DateTimeOffset.UtcNow.AddHours(1));

                var identitySasBlob = TestHelper.GetServiceClient_BlobServiceIdentitySas_Blob(
                    containerName: containerName,
                    blobName: blobName,
                    userDelegationKey: userDelegationKey)
                        .GetBlobContainerClient(containerName)
                        .GetBlockBlobClient(blobName);

                // Act
                var response = await identitySasBlob.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetPropertiesAsync_SnapshotSAS()
        {
            var containerName = TestHelper.GetNewContainerName();
            var blobName = TestHelper.GetNewBlobName();
            using (TestHelper.GetNewContainer(out var container, containerName: containerName))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container, blobName);
                var snapshotResponse = await blob.CreateSnapshotAsync();

                var sasBlob = TestHelper.GetServiceClient_BlobServiceSas_Snapshot(
                    containerName: containerName,
                    blobName: blobName,
                    snapshot: snapshotResponse.Value.Snapshot)
                        .GetBlobContainerClient(containerName)
                        .GetBlockBlobClient(blobName)
                        .WithSnapshot(snapshotResponse.Value.Snapshot);

                // Act
                var response = await sasBlob.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetPropertiesAsync_SnapshotIdentitySAS()
        {
            var oauthService = await TestHelper.GetServiceClient_OauthAccount();
            var containerName = TestHelper.GetNewContainerName();
            var blobName = TestHelper.GetNewBlobName();
            using (TestHelper.GetNewContainer(out var container, containerName: containerName, service: oauthService))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container, blobName);
                var snapshotResponse = await blob.CreateSnapshotAsync();

                var userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                    start: null,
                    expiry: DateTimeOffset.UtcNow.AddHours(1));

                var identitySasBlob = TestHelper.GetServiceClient_BlobServiceIdentitySas_Container(
                    containerName: containerName,
                    userDelegationKey: userDelegationKey)
                        .GetBlobContainerClient(containerName)
                        .GetBlockBlobClient(blobName)
                        .WithSnapshot(snapshotResponse.Value.Snapshot);

                // Act
                var response = await identitySasBlob.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditions_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task GetPropertiesAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);
                var accessConditions = this.BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                var response = await blob.GetPropertiesAsync(accessConditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task GetPropertiesAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                var accessConditions = this.BuildAccessConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.GetPropertiesAsync(accessConditions: accessConditions),
                    e => { });
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetPropertiesAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.GetPropertiesAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task SetHttpHeadersAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                // Act
                await blob.SetHttpHeadersAsync(new BlobHttpHeaders
                {
                    CacheControl = TestConstants.CacheControl,
                    ContentDisposition = TestConstants.ContentDisposition,
                    ContentEncoding = new string[] { TestConstants.ContentEncoding },
                    ContentLanguage = new string[] { TestConstants.ContentLanguage },
                    ContentHash = TestConstants.ContentMD5,
                    ContentType = TestConstants.ContentType
                });

                // Assert
                var response = await blob.GetPropertiesAsync();
                Assert.AreEqual(TestConstants.ContentType, response.Value.ContentType);
                Assert.IsTrue(TestConstants.ContentMD5.ToList().SequenceEqual(response.Value.ContentHash.ToList()));
                Assert.AreEqual(1, response.Value.ContentEncoding.Count());
                Assert.AreEqual(TestConstants.ContentEncoding, response.Value.ContentEncoding.First());
                Assert.AreEqual(1, response.Value.ContentLanguage.Count());
                Assert.AreEqual(TestConstants.ContentLanguage, response.Value.ContentLanguage.First());
                Assert.AreEqual(TestConstants.ContentDisposition, response.Value.ContentDisposition);
                Assert.AreEqual(TestConstants.CacheControl, response.Value.CacheControl);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditions_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task SetHttpHeadersAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);
                var accessConditions = this.BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                var response = await blob.SetHttpHeadersAsync(
                    httpHeaders: new BlobHttpHeaders(),
                    accessConditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task SetHttpHeadersAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                var accessConditions = this.BuildAccessConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.SetHttpHeadersAsync(
                        httpHeaders: new BlobHttpHeaders(),
                        accessConditions: accessConditions),
                    e => { });
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task SetHttpHeadersAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.SetHttpHeadersAsync(new BlobHttpHeaders()),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task SetMetadataAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);
                var metadata = TestHelper.BuildMetadata();

                // Act
                await blob.SetMetadataAsync(metadata);

                // Assert
                var response = await blob.GetPropertiesAsync();
                TestHelper.AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditions_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task SetMetadataAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);
                var metadata = TestHelper.BuildMetadata();

                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);
                var accessConditions = this.BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                var response = await blob.SetMetadataAsync(
                    metadata: metadata,
                    accessConditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task SetMetadataAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);
                var metadata = TestHelper.BuildMetadata();

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                var accessConditions = this.BuildAccessConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.SetMetadataAsync(
                        metadata: metadata,
                        accessConditions: accessConditions),
                    e => { });
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task SetMetadataAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var metadata = TestHelper.BuildMetadata();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.SetMetadataAsync(metadata),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task CreateSnapshotAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                // Act
                var response = await blob.CreateSnapshotAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditions_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task CreateSnapshotAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);
                var accessConditions = this.BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                var response = await blob.CreateSnapshotAsync(accessConditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task CreateSnapshotAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                var accessConditions = this.BuildAccessConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.CreateSnapshotAsync(accessConditions: accessConditions),
                    e => { });
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task CreateSnapshotAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.CreateSnapshotAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task AcquireLeaseAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                var leaseId = Guid.NewGuid().ToString();
                var duration = 15;

                // Act
                var response = await blob.AcquireLeaseAsync(duration, leaseId);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditions_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task AcquireLeaseAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                var leaseId = Guid.NewGuid().ToString();
                var duration = 15;

                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                var accessConditions = this.BuildHttpAccessConditions(
                    parameters: parameters);

                // Act
                var response = await blob.AcquireLeaseAsync(
                    duration: duration,
                    proposedID: leaseId,
                    httpAccessConditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task AcquireLeaseAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                var leaseId = Guid.NewGuid().ToString();
                var duration = 15;

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                var accessConditions = this.BuildHttpAccessConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.AcquireLeaseAsync(
                        duration: duration,
                        proposedID: leaseId,
                        httpAccessConditions: accessConditions),
                    e => { });
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task AcquireLeaseAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var leaseId = Guid.NewGuid().ToString();
                var duration = 15;

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.AcquireLeaseAsync(duration, leaseId),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task RenewLeaseAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                var leaseId = Guid.NewGuid().ToString();
                var duration = 15;

                await blob.AcquireLeaseAsync(duration, leaseId);

                // Act
                var response = await blob.RenewLeaseAsync(leaseId);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditions_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task RenewLeaseAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                var leaseId = Guid.NewGuid().ToString();
                var duration = 15;

                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                var accessConditions = this.BuildHttpAccessConditions(
                    parameters: parameters);

                await blob.AcquireLeaseAsync(
                    duration: duration,
                    proposedID: leaseId);

                // Act
                var response = await blob.RenewLeaseAsync(
                    leaseID: leaseId,
                    httpAccessConditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task RenewLeaseAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                var leaseId = Guid.NewGuid().ToString();
                var duration = 15;

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                var accessConditions = this.BuildHttpAccessConditions(parameters);

                await blob.AcquireLeaseAsync(
                    duration: duration,
                    proposedID: leaseId);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.RenewLeaseAsync(
                        leaseID: leaseId,
                        httpAccessConditions: accessConditions),
                    e => { });
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task RenewLeaseAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var leaseId = Guid.NewGuid().ToString();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.ReleaseLeaseAsync(leaseId),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task ReleaseLeaseAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                var leaseId = Guid.NewGuid().ToString();
                var duration = 15;

                await blob.AcquireLeaseAsync(duration, leaseId);

                // Act
                var response = await blob.ReleaseLeaseAsync(leaseId);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditions_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task ReleaseLeaseAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                var leaseId = Guid.NewGuid().ToString();
                var duration = 15;

                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                var accessConditions = this.BuildHttpAccessConditions(
                    parameters: parameters);

                await blob.AcquireLeaseAsync(
                    duration: duration,
                    proposedID: leaseId);

                // Act
                var response = await blob.ReleaseLeaseAsync(
                    leaseID: leaseId,
                    httpAccessConditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task ReleaseLeaseAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                var leaseId = Guid.NewGuid().ToString();
                var duration = 15;

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                var accessConditions = this.BuildHttpAccessConditions(parameters);

                await blob.AcquireLeaseAsync(
                    duration: duration,
                    proposedID: leaseId);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.ReleaseLeaseAsync(
                        leaseID: leaseId,
                        httpAccessConditions: accessConditions),
                    e => { });
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task ReleaseLeaseAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var leaseId = Guid.NewGuid().ToString();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.RenewLeaseAsync(leaseId),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task BreakLeaseAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                var leaseId = Guid.NewGuid().ToString();
                var duration = 15;

                await blob.AcquireLeaseAsync(duration, leaseId);

                // Act
                var response = await blob.BreakLeaseAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task BreakLeaseAsync_BreakPeriod()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                var leaseId = Guid.NewGuid().ToString();
                var duration = 15;
                var breakPeriod = 5;

                await blob.AcquireLeaseAsync(duration, leaseId);

                // Act
                var response = await blob.BreakLeaseAsync(breakPeriodInSeconds: breakPeriod);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditions_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task BreakLeaseAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                var leaseId = Guid.NewGuid().ToString();
                var duration = 15;

                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                var accessConditions = this.BuildHttpAccessConditions(
                    parameters: parameters);

                await blob.AcquireLeaseAsync(
                    duration: duration,
                    proposedID: leaseId);

                // Act
                var response = await blob.BreakLeaseAsync(
                    httpAccessConditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task BreakLeaseAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                var leaseId = Guid.NewGuid().ToString();
                var duration = 15;

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                var accessConditions = this.BuildHttpAccessConditions(parameters);

                await blob.AcquireLeaseAsync(
                    duration: duration,
                    proposedID: leaseId);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.BreakLeaseAsync(
                        httpAccessConditions: accessConditions),
                    e => { });
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task BreakLeaseAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.BreakLeaseAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task ChangeLeaseAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                var leaseId = Guid.NewGuid().ToString();
                var newLeaseId = Guid.NewGuid().ToString();
                var duration = 15;

                await blob.AcquireLeaseAsync(duration, leaseId);

                // Act
                var response = await blob.ChangeLeaseAsync(leaseId, newLeaseId);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditions_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task ChangeLeaseAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                var leaseId = Guid.NewGuid().ToString();
                var newLeaseId = Guid.NewGuid().ToString();
                var duration = 15;

                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                var accessConditions = this.BuildHttpAccessConditions(
                    parameters: parameters);

                await blob.AcquireLeaseAsync(
                    duration: duration,
                    proposedID: leaseId);

                // Act
                var response = await blob.ChangeLeaseAsync(
                    leaseID: leaseId,
                    proposedID: newLeaseId,
                    httpAccessConditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task ChangeLeaseAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                var leaseId = Guid.NewGuid().ToString();
                var newLeaseId = Guid.NewGuid().ToString();
                var duration = 15;

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                var accessConditions = this.BuildHttpAccessConditions(parameters);

                await blob.AcquireLeaseAsync(
                    duration: duration,
                    proposedID: leaseId);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.ChangeLeaseAsync(
                        leaseID: leaseId,
                        proposedID: newLeaseId,
                        httpAccessConditions: accessConditions),
                    e => { });
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task ChangeLeaseAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var leaseId = Guid.NewGuid().ToString();
                var newLeaseId = Guid.NewGuid().ToString();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.ChangeLeaseAsync(
                        leaseID: leaseId,
                        proposedID: newLeaseId),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task SetTierAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                // Act
                var response = await blob.SetTierAsync(AccessTier.Cool);

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task SetTierAsync_Lease()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.GetNewBlobClient(container);

                var leaseId = Guid.NewGuid().ToString();
                var duration = 15;

                await blob.AcquireLeaseAsync(duration, leaseId);

                // Act
                var response = await blob.SetTierAsync(
                    accessTier: AccessTier.Cool, 
                    leaseAccessConditions: new LeaseAccessConditions
                    {
                        LeaseId = leaseId
                    });

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task SetTierAsync_LeaseFail()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var data = TestHelper.GetRandomBuffer(Constants.KB);

                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                var leaseId = Guid.NewGuid().ToString();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException, Response>(
                    blob.SetTierAsync(
                        accessTier: AccessTier.Cool,
                        leaseAccessConditions: new LeaseAccessConditions
                        {
                            LeaseId = leaseId
                        }),
                    e => Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task SetTierAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var leaseId = Guid.NewGuid().ToString();
                var newLeaseId = Guid.NewGuid().ToString();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException, Response>(
                    blob.SetTierAsync(AccessTier.Cool),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        //[TestMethod]
        //[TestCategory("Live")]
        //public async Task SetTierAsync_Batch()
        //{
        //    using (TestHelper.GetNewContainer(out var container, service: TestHelper.GetServiceClient_PreviewAccount_SharedKey()))
        //    {
        //        const int blobSize = Constants.KB;
        //        var data = TestHelper.GetRandomBuffer(blobSize);

        //        var blob1 = containerUri.CreateBlockBlobUri(TestHelper.GetNewBlobName());
        //        using (var stream = new MemoryStream(data))
        //        {
        //            await blob1.UploadAsync(stream);
        //        }

        //        var blob2 = containerUri.CreateBlockBlobUri(TestHelper.GetNewBlobName());
        //        using (var stream = new MemoryStream(data))
        //        {
        //            await blob2.UploadAsync(stream);
        //        }

        //        var batch =
        //            blob1.SetTierAsync(AccessTier.Cool)
        //            .And(blob2.SetTierAsync(AccessTier.Cool))
        //            ;

        //        var result = await batch;

        //        Assert.IsNotNull(result);
        //        Assert.AreEqual(2, result.Length);
        //        Assert.IsNotNull(result[0].RequestId);
        //        Assert.IsNotNull(result[1].RequestId);
        //    }
        //}

        [TestMethod]
        public void WithSnapshot()
        {
            var containerName = TestHelper.GetNewContainerName();
            var blobName = TestHelper.GetNewBlobName();

            var service = TestHelper.GetServiceClient_SharedKey();

            var container = service.GetBlobContainerClient(containerName);

            var blob = container.GetBlockBlobClient(blobName);

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("", builder.Snapshot);

            blob = blob.WithSnapshot("foo");

            builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("foo", builder.Snapshot);

            blob = blob.WithSnapshot(null);

            builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("", builder.Snapshot);
        }

        private async Task<BlobClient> GetNewBlobClient(BlobContainerClient container, string blobName = default)
        {
            blobName = blobName ?? TestHelper.GetNewBlobName();
            var blob = container.GetBlockBlobClient(blobName);
            var data = TestHelper.GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            return blob;
        }

        public static IEnumerable<object[]> AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters
                {
                    IfModifiedSince = TestHelper.OldDate
                },
                new AccessConditionParameters
                {
                    IfUnmodifiedSince = TestHelper.NewDate
                },
                new AccessConditionParameters
                {
                    Match = TestHelper.ReceivedETag
                },
                new AccessConditionParameters
                {
                    NoneMatch = TestHelper.GarbageETag
                },
                new AccessConditionParameters
                {
                    LeaseId = TestHelper.ReceivedLeaseId
                }
            }.Select(x => new object[] { x });

        public static IEnumerable<object[]> AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters
                {
                    IfModifiedSince = TestHelper.NewDate
                },
                new AccessConditionParameters
                {
                    IfUnmodifiedSince = TestHelper.OldDate
                },
                new AccessConditionParameters
                {
                    Match = TestHelper.GarbageETag
                },
                new AccessConditionParameters
                {
                    NoneMatch = TestHelper.ReceivedETag
                },
                new AccessConditionParameters
                {
                    LeaseId = TestHelper.GarbageLeaseId
                },
             }.Select(x => new object[] { x });

        public static IEnumerable<object[]> NoLease_AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters
                {
                    IfModifiedSince = TestHelper.OldDate
                },
                new AccessConditionParameters
                {
                    IfUnmodifiedSince = TestHelper.NewDate
                },
                new AccessConditionParameters
                {
                    Match = TestHelper.ReceivedETag
                },
                new AccessConditionParameters
                {
                    NoneMatch = TestHelper.GarbageETag
                },
            }.Select(x => new object[] { x });

        public static IEnumerable<object[]> NoLease_AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters
                {
                    IfModifiedSince = TestHelper.NewDate
                },
                new AccessConditionParameters
                {
                    IfUnmodifiedSince = TestHelper.OldDate
                },
                new AccessConditionParameters
                {
                    Match = TestHelper.GarbageETag
                },
                new AccessConditionParameters
                {
                    NoneMatch = TestHelper.ReceivedETag
                },
            }.Select(x => new object[] { x });

        private HttpAccessConditions BuildHttpAccessConditions(
            AccessConditionParameters parameters)
            => new HttpAccessConditions
            {
                IfModifiedSince = parameters.IfModifiedSince,
                IfUnmodifiedSince = parameters.IfUnmodifiedSince,
                IfMatch = parameters.Match != null ? new ETag(parameters.Match) : default(ETag?),
                IfNoneMatch = parameters.NoneMatch != null ? new ETag(parameters.NoneMatch) : default(ETag?)
            };

        private BlobAccessConditions BuildAccessConditions(
            AccessConditionParameters parameters,
            bool lease = true)
        {
            var accessConditions = new BlobAccessConditions
            {
                HttpAccessConditions = this.BuildHttpAccessConditions(parameters)
            };
            if(lease)
            {
                accessConditions.LeaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = parameters.LeaseId
                };
            }
            return accessConditions;
        }

        public struct AccessConditionParameters
        {
            public DateTimeOffset? IfModifiedSince { get; set; }
            public DateTimeOffset? IfUnmodifiedSince { get; set; }
            public string Match { get; set; }
            public string NoneMatch { get; set; }
            public string LeaseId { get; set; }
        }
    }
}
