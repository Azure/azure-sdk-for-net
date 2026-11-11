// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
	public class RequestPriorityTests : BlobTestBase
	{
		private const string RequestPriorityHeaderName = "x-ms-request-priority";
		private const int DefaultServicePriority = 3;

		public RequestPriorityTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
			: base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
		{
		}

		private BlobServiceClient GetServiceClient(int? requestPriority, AssertMessageContentsPolicy policy)
		{
			BlobClientOptions options = GetOptions();
			options.RequestPriority = requestPriority;
			options.AddPolicy(policy, HttpPipelinePosition.BeforeTransport);
			return InstrumentClient(new BlobServiceClient(
				new Uri(TestConfigDefault.BlobServiceEndpoint),
				new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey),
				options));
		}

		/// <summary>
		/// The service honors priorities from 0 through 7. Unset or out-of-range
		/// values fall back to the default priority of 3.
		/// </summary>
		private static int GetEffectivePriority(int? requestPriority)
			=> requestPriority is >= 0 and <= 7 ? requestPriority.Value : DefaultServicePriority;

		private static AssertMessageContentsPolicy GetAssertPolicy(int? requestPriority, List<string> observedRequests)
			=> new AssertMessageContentsPolicy(
				checkRequest: request =>
				{
					observedRequests.Add($"{request.Method} {request.Uri}");
					if (requestPriority.HasValue)
					{
						Assert.IsTrue(
							request.Headers.TryGetValue(RequestPriorityHeaderName, out string value),
							$"Missing {RequestPriorityHeaderName} header on {request.Method} {request.Uri}");
						Assert.AreEqual(requestPriority.Value.ToString(), value);
					}
					else
					{
						Assert.IsFalse(
							request.Headers.TryGetValue(RequestPriorityHeaderName, out _),
							$"Unexpected {RequestPriorityHeaderName} header on {request.Method} {request.Uri}");
					}
				});

		private static void AssertResponsePriority(Response response, int? requestPriority)
		{
			Assert.IsTrue(
				response.Headers.TryGetValue(RequestPriorityHeaderName, out string value),
				$"Missing {RequestPriorityHeaderName} response header");
			Assert.AreEqual(GetEffectivePriority(requestPriority).ToString(), value);
		}

		[RecordedTest]
		[TestCase(null)]
		[TestCase(-1)]
		[TestCase(0)]
		[TestCase(5)]
		[TestCase(7)]
		[TestCase(8)]
		public async Task RequestPriority_SingleRequestOperations(int? priority)
		{
			// Arrange
			List<string> observedRequests = new();
			AssertMessageContentsPolicy policy = GetAssertPolicy(priority, observedRequests);
			BlobServiceClient service = GetServiceClient(priority, policy);
			await using DisposingContainer test = await GetTestContainerAsync(service: service);
			BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));

			using (policy.CheckRequestScope())
			{
				// Act
				Response<BlobContentInfo> upload = await blob.UploadAsync(BinaryData.FromBytes(GetRandomBuffer(Constants.KB)));
				Response<BlobProperties> properties = await blob.GetPropertiesAsync();
				Response<BlobContainerProperties> containerProperties = await test.Container.GetPropertiesAsync();
				Response<AccountInfo> accountInfo = await service.GetAccountInfoAsync();

				BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(Recording.Random.NewGuid().ToString()));
				Response<BlobLease> acquired = await lease.AcquireAsync(TimeSpan.FromSeconds(15));
				Response<ReleasedObjectInfo> released = await lease.ReleaseAsync();

				// Assert
				AssertResponsePriority(upload.GetRawResponse(), priority);
				AssertResponsePriority(properties.GetRawResponse(), priority);
				AssertResponsePriority(containerProperties.GetRawResponse(), priority);
				AssertResponsePriority(accountInfo.GetRawResponse(), priority);
				AssertResponsePriority(acquired.GetRawResponse(), priority);
				AssertResponsePriority(released.GetRawResponse(), priority);
			}

			Assert.IsNotEmpty(observedRequests);
		}

		[RecordedTest]
		[TestCase(null)]
		[TestCase(-1)]
		[TestCase(0)]
		[TestCase(5)]
		[TestCase(7)]
		[TestCase(8)]
		public async Task RequestPriority_MultiRequestOperations(int? priority)
		{
			// Arrange
			const int dataSize = 4 * Constants.KB;
			List<string> observedRequests = new();
			AssertMessageContentsPolicy policy = GetAssertPolicy(priority, observedRequests);
			BlobServiceClient service = GetServiceClient(priority, policy);
			await using DisposingContainer test = await GetTestContainerAsync(service: service);
			BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
			byte[] data = GetRandomBuffer(dataSize);
			StorageTransferOptions transferOptions = new()
			{
				InitialTransferSize = Constants.KB,
				MaximumTransferSize = Constants.KB,
				MaximumConcurrency = 1,
			};

			using (policy.CheckRequestScope())
			{
				// Act - partitioned upload (stage blocks + commit block list)
				await blob.UploadAsync(
					BinaryData.FromBytes(data),
					new BlobUploadOptions { TransferOptions = transferOptions });

				// Act - partitioned download (multiple ranged GETs)
				using MemoryStream destination = new();
				Response download = await blob.DownloadToAsync(
					destination,
					new BlobDownloadToOptions { TransferOptions = transferOptions });

				// Act - paging
				List<BlobItem> blobs = new();
				await foreach (Page<BlobItem> page in test.Container.GetBlobsAsync().AsPages(pageSizeHint: 1))
				{
					blobs.AddRange(page.Values);
					AssertResponsePriority(page.GetRawResponse(), priority);
				}

				// Assert
				AssertResponsePriority(download, priority);
				CollectionAssert.AreEqual(data, destination.ToArray());
				Assert.AreEqual(1, blobs.Count);
			}

			// Upload: 4 Put Block + 1 Put Block List; Download: 4 ranged GETs; List: 1 page.
			Assert.GreaterOrEqual(observedRequests.Count, 10);
		}

		[RecordedTest]
		[TestCase(null)]
		[TestCase(-1)]
		[TestCase(0)]
		[TestCase(5)]
		[TestCase(7)]
		[TestCase(8)]
		public async Task RequestPriority_DerivedClientsInheritPriority(int? priority)
		{
			// Arrange
			List<string> observedRequests = new();
			AssertMessageContentsPolicy policy = GetAssertPolicy(priority, observedRequests);
			BlobServiceClient service = GetServiceClient(priority, policy);
			await using DisposingContainer test = await GetTestContainerAsync(service: service);

			BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
			BlockBlobClient blockBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
			AppendBlobClient appendBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
			PageBlobClient pageBlob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));

			using (policy.CheckRequestScope())
		    {
				// Act
				await blob.UploadAsync(BinaryData.FromBytes(GetRandomBuffer(Constants.KB)));
				Response<BlobContentInfo> blockUpload = await blockBlob.UploadAsync(new MemoryStream(GetRandomBuffer(Constants.KB)));
				Response<BlobContentInfo> appendCreate = await appendBlob.CreateAsync();
				Response<BlobContentInfo> pageCreate = await pageBlob.CreateAsync(Constants.KB);
				BlobContainerClient parent = blob.GetParentBlobContainerClient();
				Response<BlobContainerProperties> parentProperties = await parent.GetPropertiesAsync();
				BlobBaseClient snapshot = blob.WithSnapshot((await blob.CreateSnapshotAsync()).Value.Snapshot);
				Response<BlobProperties> snapshotProperties = await snapshot.GetPropertiesAsync();

				// Assert
				AssertResponsePriority(blockUpload.GetRawResponse(), priority);
				AssertResponsePriority(appendCreate.GetRawResponse(), priority);
				AssertResponsePriority(pageCreate.GetRawResponse(), priority);
				AssertResponsePriority(parentProperties.GetRawResponse(), priority);
				AssertResponsePriority(snapshotProperties.GetRawResponse(), priority);
			}

			Assert.IsNotEmpty(observedRequests);
		}
	}
}
