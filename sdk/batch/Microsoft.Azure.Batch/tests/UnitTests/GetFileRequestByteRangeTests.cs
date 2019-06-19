// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Protocol.BatchRequests;
    using Microsoft.Azure.Batch.Protocol.Models;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Xunit.Abstractions;
    using Protocol = Microsoft.Azure.Batch.Protocol;

    public class GetFileRequestByteRangeTests
    {
        private ITestOutputHelper testOutputHelper;
        private const int DefaultServerTimeoutInSeconds = 30;
        private static readonly TimeSpan DefaultClientTimeout = TimeSpan.FromSeconds(60);

        public GetFileRequestByteRangeTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task WhenGettingTaskFileUsingReadAsString_OcpRangeHeaderIsSet()
        {
            await VerifyOcpRangeSetWhenDownloadingFileAsync<
                FileGetNodeFilePropertiesFromTaskBatchRequest,
                FileGetPropertiesFromTaskOptions,
                FileGetPropertiesFromTaskHeaders,
                FileGetFromTaskBatchRequest,
                FileGetFromTaskOptions,
                FileGetFromTaskHeaders>(
                (options) => options.OcpRange,
                async (client) => await client.JobOperations.GetNodeFileAsync("jobId", "taskId", "fileName"),
                async (nodeFile, byteRange) => await nodeFile.ReadAsStringAsync(byteRange: byteRange));
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task WhenGettingTaskFileUsingCopyToStream_OcpRangeHeaderIsSet()
        {
            await VerifyOcpRangeSetWhenDownloadingFileAsync<
                FileGetNodeFilePropertiesFromTaskBatchRequest,
                FileGetPropertiesFromTaskOptions,
                FileGetPropertiesFromTaskHeaders,
                FileGetFromTaskBatchRequest,
                FileGetFromTaskOptions,
                FileGetFromTaskHeaders>(
                (options) => options.OcpRange,
                async (client) => await client.JobOperations.GetNodeFileAsync("jobId", "taskId", "fileName"),
                async (nodeFile, byteRange) => await nodeFile.CopyToStreamAsync(new MemoryStream(), byteRange: byteRange));
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task WhenGettingNodeFileUsingReadAsString_OcpRangeHeaderIsSet()
        {
            await VerifyOcpRangeSetWhenDownloadingFileAsync<
                FileGetNodeFilePropertiesFromComputeNodeBatchRequest,
                FileGetPropertiesFromComputeNodeOptions,
                FileGetPropertiesFromComputeNodeHeaders,
                FileGetFromComputeNodeBatchRequest,
                FileGetFromComputeNodeOptions,
                FileGetFromComputeNodeHeaders>(
                (options) => options.OcpRange,
                async (client) => await client.PoolOperations.GetNodeFileAsync("poolId", "nodeId", "fileName"),
                async (nodeFile, byteRange) => await nodeFile.ReadAsStringAsync(byteRange: byteRange));
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task WhenGettingNodeFileUsingCopyToStream_OcpRangeHeaderIsSet()
        {
            await VerifyOcpRangeSetWhenDownloadingFileAsync<
                FileGetNodeFilePropertiesFromComputeNodeBatchRequest,
                FileGetPropertiesFromComputeNodeOptions,
                FileGetPropertiesFromComputeNodeHeaders,
                FileGetFromComputeNodeBatchRequest,
                FileGetFromComputeNodeOptions,
                FileGetFromComputeNodeHeaders>(
                (options) => options.OcpRange,
                async (client) => await client.PoolOperations.GetNodeFileAsync("poolId", "nodeId", "fileName"),
                async (nodeFile, byteRange) => await nodeFile.CopyToStreamAsync(new MemoryStream(), byteRange: byteRange));
        }

        private async Task VerifyOcpRangeSetWhenDownloadingFileAsync<
            TPropertiesRequest, TPropertiesOptions, TPropertiesHeaders, TDownloadRequest, TDownloadOptions, TDownloadHeaders>(
            Func<TDownloadOptions, string> getOcpRangeFunc,
            Func<BatchClient, Task<Microsoft.Azure.Batch.NodeFile>> getNodeFilePropertiesFunc, 
            Func<Microsoft.Azure.Batch.NodeFile,GetFileRequestByteRange, Task> downloadFileFunc)
            where TPropertiesRequest : Protocol.BatchRequest<TPropertiesOptions, AzureOperationHeaderResponse<TPropertiesHeaders>>
            where TPropertiesOptions : IOptions, new()
            where TPropertiesHeaders : IProtocolNodeFile, new()
            where TDownloadRequest : Protocol.BatchRequest<TDownloadOptions, AzureOperationResponse<Stream, TDownloadHeaders>>
            where TDownloadOptions : IOptions, new()
            where TDownloadHeaders : IProtocolNodeFile, new()
        {
            const int startRange = 100;
            const int endRange = 200;
            string expectedOcpRange = "bytes=100-200";
            GetFileRequestByteRange byteRange = new GetFileRequestByteRange(startRange, endRange);

            // This interceptor verifies that the OcpRange header was properly set according to the
            // GetFileRequestByteRange object defined above.
            InvocationTracker invocationTracker = new InvocationTracker();
            BatchClientBehavior confirmByteRangeIsSet = CreateOcpRangeConfirmationInterceptor<
                TDownloadRequest,
                TDownloadOptions,
                TDownloadHeaders>(
                expectedOcpRange,
                getOcpRangeFunc,
                invocationTracker);

            // In order to perform the "get file" API to verify that the OcpRange was set, we need to invoke the
            // "get file properties" API first to get a NodeFile instance. This interceptor skips the "get file
            // properties" call to the Batch service and instead builds a fake NodeFile.
            BatchClientBehavior getFakeNodeFile = CreateFakeNodeFileInterceptor<TPropertiesRequest, TPropertiesOptions, TPropertiesHeaders>();

            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                client.CustomBehaviors.Add(confirmByteRangeIsSet);
                client.CustomBehaviors.Add(getFakeNodeFile);
                // Get a NodeFile object by invoking the "get file properties" API.
                Microsoft.Azure.Batch.NodeFile nodeFile = await getNodeFilePropertiesFunc(client);
                // The download func invokes the "get file" API where the OcpRange header is actually set
                await downloadFileFunc(nodeFile, byteRange);
                // Verify the OcpRange validation interceptor was actually invoked
                Assert.True(invocationTracker.WasInvoked);
            }
        }

        private Protocol.RequestInterceptor CreateOcpRangeConfirmationInterceptor<TRequest, TOptions, THeaders>(
            string expectedOcpRange,
            Func<TOptions, string> getOcpRange,
            InvocationTracker invocationTracker)
            where TRequest : Protocol.BatchRequest<TOptions, AzureOperationResponse<Stream, THeaders>>
            where TOptions : IOptions, new()
            where THeaders : IProtocolNodeFile, new()
        {
            return new Protocol.RequestInterceptor(request =>
            {
                TRequest getFileRequest = request as TRequest;
                if (getFileRequest != null)
                {
                    getFileRequest.ServiceRequestFunc = t =>
                    {
                        invocationTracker.Invoke();
                        Assert.Equal(expectedOcpRange, getOcpRange(getFileRequest.Options));

                        THeaders headers = new THeaders();
                        SetFakeProtocolNodeFileHeaders(headers);
                        return Task.FromResult(new AzureOperationResponse<Stream, THeaders>()
                        {
                            Body = new MemoryStream(),
                            Headers = headers
                        });
                    };
                }
            });
        }

        private Protocol.RequestInterceptor CreateFakeNodeFileInterceptor<TRequest, TOptions, THeaders>()
            where TRequest : Protocol.BatchRequest<TOptions, AzureOperationHeaderResponse<THeaders>>
            where TOptions : IOptions, new()
            where THeaders : IProtocolNodeFile, new()
        {
            return new Protocol.RequestInterceptor(request =>
            {
                TRequest getFilePropertiesRequest = request as TRequest;
                if (getFilePropertiesRequest != null)
                {
                    getFilePropertiesRequest.ServiceRequestFunc = t =>
                    {
                        THeaders headers = new THeaders();
                        SetFakeProtocolNodeFileHeaders(headers);
                        return Task.FromResult(new AzureOperationHeaderResponse<THeaders>() { Headers = headers });
                    };
                }
            });
        }

        private void SetFakeProtocolNodeFileHeaders(IProtocolNodeFile nodeFile)
        {
            nodeFile.ContentLength = 100;
            nodeFile.ContentType = "text";
            nodeFile.LastModified = DateTime.UtcNow;
        }

        // The test method needs to know when a lambda defined in a helper method gets triggered.
        // While the lambda can work with a bool defined in the scope of the helper method, the 
        // outer test method needs to know whether this bool is updated. The test can't pass a bool
        // to the helper method by reference and also have it updated by the lambda, so this wrapper
        // class is used instead. 
        private class InvocationTracker
        {
            public bool WasInvoked { get; private set; }

            public void Invoke()
            {
                this.WasInvoked = true;
            }
        }
    }
}