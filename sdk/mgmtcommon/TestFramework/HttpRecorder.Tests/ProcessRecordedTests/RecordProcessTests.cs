// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace HttpRecorder.Tests.ProcessRecordedTests
{
    using HttpRecorder.Tests.DelegatingHandlers;
    using HttpRecorder.Tests.ResponseData;
    using HttpRecorder.Tests.TestClients.Redis;
    using HttpRecorder.Tests.TestClients.Redis.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Azure.Test.HttpRecorder.ProcessRecordings;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using Xunit;

    public class CompactLroRequestsTests : ProcessRecordingTestBase
    {
#if DEBUG
        [Fact]
        public void CRUDLroCompact()
        {
            string testIdentity = this.GetType().Name;
            LroResponseData responseData = new LroResponseData();
            List<HttpResponseMessage> responses = new List<HttpResponseMessage>();
            int putPollingCount = 20;
            int postPollingCount = 30;
            int deletePollingCount = 50;

            responses = this.AppendResponse(
                responseData.PutLroResponse(putPollingCount, LroHeaders.Location_And_AzureAsync),
                responseData.PostLroResponse(postPollingCount, LroHeaders.Location_And_AzureAsync),
                responseData.DeleteLroResponse(deletePollingCount, LroHeaders.Location_And_AzureAsync));

            LroResponseHandler lroHandler = new LroResponseHandler(responses);

            // RECORD
            this.CurrentRecordMode = HttpRecorderMode.Record;
            HttpMockServer.Initialize(testIdentity, TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Record);
            CreateRedisClient(lroHandler);
            CreateResource(this.TestClient);
            PostRequest(this.TestClient);
            DeleteResource(this.TestClient);
            string recordedFilePath = HttpMockServer.Flush(this.CurrentDir);

            CompactRecordedFile(recordedFilePath);

            // PLAYBACK
            HttpMockServer.RecordsDirectory = "";
            HttpMockServer.Initialize(testIdentity, TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Playback);

            responses = this.AppendResponse(
                responseData.PutLroResponse(putPollingCount, LroHeaders.Location_And_AzureAsync),
                responseData.PostLroResponse(postPollingCount, LroHeaders.Location_And_AzureAsync),
                responseData.DeleteLroResponse(deletePollingCount, LroHeaders.Location_And_AzureAsync));

            lroHandler = new LroResponseHandler(responses);

            CreateRedisClient(lroHandler);
            CreateResource(this.TestClient);
            PostRequest(this.TestClient);
            DeleteResource(this.TestClient);
            Assert.True(true);
        }

        #region Compact Files



        #endregion
#endif

        void CompactRecordedFile(string filePathToCompact)
        {
            ProcessRecordedFiles procRecFile = new ProcessRecordedFiles(filePathToCompact);
            procRecFile.CompactLroPolling();
            procRecFile.SerializeCompactData();
        }

        #region Drive Operations
        RedisResource CreateResource(IRedisManagementClient client)
        {
            RedisResource redisRes = client.RedisOperations.CreateOrUpdate(DefaultRG, DefaultResourceName, DefaultRedisParameters, DefaultSubscription);
            return redisRes;
        }

        void DeleteResource(IRedisManagementClient client)
        {
            client.RedisOperations.Delete(DefaultRG, DefaultResourceName, DefaultSubscription);
        }

        Sku PostRequest(IRedisManagementClient client)
        {
            Sku redisSku = client.RedisOperations.Post(DefaultRG, DefaultResourceName, DefaultSubscription);
            return redisSku;
        }

        void CreateRedisClient(RecordedDelegatingHandler handler)
        {
            this.TestClient = new RedisManagementClient(HttpMockServer.CreateInstance(), handler);
            this.TestClient.LongRunningOperationInitialTimeout = 0;
            this.TestClient.LongRunningOperationRetryTimeout = 0;
        }

        #endregion

        //internal string RecordLroOperation(HttpMethod method, int lroPollingCount)
        //{
        //    HttpMockServer.Initialize(this.GetType().Name, TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Record);
        //    LroResponseData responseData = new LroResponseData();
        //    //var responses = responseData.GetLroPUTResponse(lroPollingCount, true, false, true, HttpStatusCode.OK);
        //    var responses = responseData.PutLroResponse(lroPollingCount, LroHeaders.Location_And_AzureAsync);
        //    var lroHandler = new LroResponseHandler(responses);

        //    RedisManagementClient redisClient = new RedisManagementClient(HttpMockServer.CreateInstance(), lroHandler);
        //    redisClient.LongRunningOperationInitialTimeout = 1;
        //    redisClient.LongRunningOperationRetryTimeout = 1;
        //    redisClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

        //    string recordedFilePath = HttpMockServer.Flush(this.CurrentDir);

        //    return recordedFilePath;
        //}
    }

    public class ProcessRecordingTestBase
    {
        protected HttpRecorderMode CurrentRecordMode { get; set; }
        protected string DefaultRG { get; set; }
        protected string DefaultSubscription { get; set; }

        protected RedisCreateOrUpdateParameters DefaultRedisParameters { get; set; }

        protected string DefaultResourceName { get; set; }

        protected string CurrentDir { get; set; }

        public IRedisManagementClient TestClient { get; set; }

        public ProcessRecordingTestBase()
        {
            CurrentDir = Directory.GetCurrentDirectory();// Environment.CurrentDirectory;
            HttpMockServer.FileSystemUtilsObject = new FileSystemUtils();
            DefaultRedisParameters = new RedisCreateOrUpdateParameters();
            DefaultRG = "rg";
            DefaultSubscription = "1234";
            DefaultResourceName = "redis";
        }

        public List<HttpResponseMessage> AppendResponse(params IEnumerable<HttpResponseMessage>[] responses)
        {
            List<HttpResponseMessage> responseList = new List<HttpResponseMessage>();
            foreach (IEnumerable<HttpResponseMessage> res in responses)
            {
                responseList.AddRange(res);
            }

            return responseList;
        }
    }
}
