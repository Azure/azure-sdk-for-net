// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CR.Azure.NetCore.Tests.LROTests
{
    using CR.Azure.NetCore.Tests.Fakes;
    using CR.Azure.NetCore.Tests.TestClients.Models;
    using CR.Azure.NetCore.Tests.TestClients.RedisClient;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using System.Net.Http;
    using Xunit;

    /// <summary>
    /// 
    /// </summary>
    public class LRORulesTests
    {
        #region const
        //Original Resource URI is created in operations, best way is to find the entire URI at runtime
        private const string PutOriginalResourceRequestUrl = @"https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis";

        private const string PostOriginalResourceRequestUrl = @"https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redist";

        private const string DeleteOriginalResourceRequestUrl = @"https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redist";


        #region PUT URIs
        private const string Put201_AzAsyncOperationHeaderUrl = LroRules.PUTResponses.status201_AzureAsyncOperationHeaderUrl;
        private const string Put201_LocationHeaderUrl = LroRules.PUTResponses.status201_LocationHeaderUrl;

        private const string Put202_AzAsyncOperationHeaderUrl = LroRules.PUTResponses.status202_AzureAsyncOperationHeaderUrl;
        private const string Put202_LocationHeaderUrl = LroRules.PUTResponses.status202_LocationHeaderUrl;

        private const string AltPutLocationHeaderUrl = LroRules.PUTResponses.AltLocationHeaderUrl;
        #endregion

        #region POST URIs
        private const string Post201_AzAsyncOperationHeaderUrl = LroRules.POSTResponses.status201_PostAzureAsyncOperationHeaderUrl;
        private const string Post201_LocationHeaderUrl = LroRules.POSTResponses.status201_PostLocationHeaderUrl;

        private const string Post202_AzAsyncOperationHeaderUrl = LroRules.POSTResponses.status202_PostAzureAsyncOperationHeaderUrl;
        private const string Post202_LocationHeaderUrl = LroRules.POSTResponses.status202_PostLocationHeaderUrl;

        #endregion

        #region DELETE URIs
        private const string Delete201_AzAsyncOperationHeaderUrl = LroRules.DELETEResponses.status202_DelAzureAsyncOperationHeaderUrl;
        private const string Delete201_LocationHeaderUrl = LroRules.DELETEResponses.status201_DelLocationHeaderUrl;

        private const string Delete202_AzAsyncOperationHeaderUrl = LroRules.DELETEResponses.status202_DelAzureAsyncOperationHeaderUrl;
        private const string Delete202_LocationHeaderUrl = LroRules.DELETEResponses.status202_DelLocationHeaderUrl;

        #endregion

        #endregion

        #region helper functions
        private static RedisManagementClient GetClient(DelegatingHandler handlerToAdd)
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var fakeClient = new RedisManagementClient(tokenCredentials, handlerToAdd);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            return fakeClient;
        }

        private static void VerifyRequestCount(string httpStrMethod, PlaybackTestHandler handler, int putCount = 0, int patchCount = 0)
        {
            if (httpStrMethod.Equals("PUT"))
                Assert.Equal(putCount, handler.Requests.Count);
            else if (httpStrMethod.Equals("PATCH"))
                Assert.Equal(patchCount, handler.Requests.Count);
        }

        private static void VerifyHttpMethod(string expectedStrMethod, PlaybackTestHandler handler, int requestIndex = 0)
        {
            HttpMethod expMethod = null;

            switch (expectedStrMethod)
            {
                case "PUT":
                    expMethod = HttpMethod.Put;
                    break;

                case "PATCH":
                    expMethod = new HttpMethod("PATCH");
                    break;

                case "POST":
                    expMethod = HttpMethod.Post;
                    break;

                case "DELETE":
                    expMethod = HttpMethod.Delete;
                    break;
            }

            Assert.Equal(expMethod, handler.Requests[requestIndex].Method);
        }

        private static void VerifyRequestUrl(string expectedUrl, PlaybackTestHandler handler, int requestIndex = 0)
        {
            Assert.Equal(expectedUrl, handler.Requests[requestIndex].RequestUri.ToString());
        }

        //private static T ExecuteOperation<T>(string httpMethod, RedisManagementClient fakeClient) where T: class
        //{
        //    if (httpMethod.Equals("PUT"))
        //        return fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
        //    else if (httpMethod.Equals("PATCH"))
        //        return fakeClient.RedisOperations.Patch("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
        //    else if (httpMethod.Equals("POST"))
        //        return fakeClient.RedisOperations.Post("rg", "redist", "1234")
        //    else if (httpMethod.Equals("DELETE"))
        //        return fakeClient.RedisOperations.Patch("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
        //    else
        //        return null;
        //}
        #endregion

        #region PUT

        /// <summary>
        /// TODO
        /// </summary>
        public class PUTTests
        {
            #region const
            //Original Resource URI is created in operations, best way is to find the entire URI at runtime
            private const string PutOriginalResourceRequestUrl = @"https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis";

            private const string Put201_AzAsyncOperationHeaderUrl = LroRules.PUTResponses.status201_AzureAsyncOperationHeaderUrl;
            private const string Put201_LocationHeaderUrl = LroRules.PUTResponses.status201_LocationHeaderUrl;

            private const string Put202_AzAsyncOperationHeaderUrl = LroRules.PUTResponses.status202_AzureAsyncOperationHeaderUrl;
            private const string Put202_LocationHeaderUrl = LroRules.PUTResponses.status202_LocationHeaderUrl;

            private const string AltPutLocationHeaderUrl = LroRules.PUTResponses.AltLocationHeaderUrl;
            #endregion

            #region 201

            /// <summary>
            /// 
            /// </summary>
            public class Status201
            {
                /// <summary>
                /// 
                /// </summary>
                [Theory]
                [InlineData("PUT")]
                [InlineData("PATCH")]
                public void AzAsyncHeader201(string inlineHttpMethod)
                {
                    var handler = new PlaybackTestHandler(LroRules.PUTResponses.AzAsync201());
                    var fakeClient = GetClient(handler);
                    
                    ExecuteOperation(inlineHttpMethod, fakeClient);

                    VerifyHttpMethod(inlineHttpMethod, handler);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, 0);
                    VerifyRequestUrl(Put201_AzAsyncOperationHeaderUrl, handler, requestIndex: 1);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, requestIndex: 3);
                }

                /// <summary>
                /// 
                /// </summary>
                [Theory]
                [InlineData("PUT")]
                [InlineData("PATCH")]
                public void LocationHeader201(string inlineHttpMethod)
                {
                    var handler = new PlaybackTestHandler(LroRules.PUTResponses.Location201());
                    var fakeClient = GetClient(handler);
                    ExecuteOperation(inlineHttpMethod, fakeClient);

                    VerifyHttpMethod(inlineHttpMethod, handler);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler);
                    VerifyRequestUrl(Put201_LocationHeaderUrl, handler, requestIndex: 1);
                    VerifyRequestUrl(Put201_LocationHeaderUrl, handler, requestIndex: 2);
                }

                /// <summary>
                /// 
                /// </summary>
                [Theory]
                [InlineData("PUT")]
                [InlineData("PATCH")]
                public void LocationAndAzAsyncHeader201(string inlineHttpMethod)
                {
                    var handler = new PlaybackTestHandler(LroRules.PUTResponses.LocationAndAzAsync201());
                    var fakeClient = GetClient(handler);
                    ExecuteOperation(inlineHttpMethod, fakeClient);

                    VerifyHttpMethod(inlineHttpMethod, handler);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler);
                    VerifyRequestUrl(Put201_AzAsyncOperationHeaderUrl, handler, requestIndex: 1);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, requestIndex: 3);
                }

                /// <summary>
                /// 
                /// </summary>
                [Theory]
                [InlineData("PUT")]
                [InlineData("PATCH")]
                public void NoHeader201(string inlineHttpMethod)
                {
                    var handler = new PlaybackTestHandler(LroRules.PUTResponses.NoHeaders201());
                    var fakeClient = GetClient(handler);
                    ExecuteOperation(inlineHttpMethod, fakeClient);

                    VerifyHttpMethod(inlineHttpMethod, handler);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, requestIndex: 1);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, requestIndex: 2);
                }
            }

            #endregion

            #region 202
            /// <summary>
            /// 
            /// </summary>
            public class Status202
            {
                /// <summary>
                /// 
                /// </summary>
                [Theory]
                [InlineData("PUT")]
                [InlineData("PATCH")]
                public void AzAsyncHeader202(string inlineHttpMethod)
                {
                    var handler = new PlaybackTestHandler(LroRules.PUTResponses.AzAsync202());
                    var fakeClient = GetClient(handler);
                    ExecuteOperation(inlineHttpMethod, fakeClient);

                    VerifyHttpMethod(inlineHttpMethod, handler);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, 0);
                    VerifyRequestUrl(Put202_AzAsyncOperationHeaderUrl, handler, requestIndex: 1);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, requestIndex: 2);
                }

                /// <summary>
                /// 
                /// </summary>
                [Theory]
                [InlineData("PUT")]
                [InlineData("PATCH")]
                public void LocationHeader202(string inlineHttpMethod)
                {
                    var handler = new PlaybackTestHandler(LroRules.PUTResponses.Location202());
                    var fakeClient = GetClient(handler);
                    ExecuteOperation(inlineHttpMethod, fakeClient);

                    VerifyHttpMethod(inlineHttpMethod, handler);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, 0);
                    VerifyRequestUrl(Put202_LocationHeaderUrl, handler, requestIndex: 1);
                }

                /// <summary>
                /// 
                /// </summary>
                [Theory]
                [InlineData("PUT")]
                [InlineData("PATCH")]
                public void LocationAndAzAsyncHeader202(string inlineHttpMethod)
                {
                    var handler = new PlaybackTestHandler(LroRules.PUTResponses.LocationAndAzAsync202());
                    var fakeClient = GetClient(handler);
                    ExecuteOperation(inlineHttpMethod, fakeClient);

                    VerifyHttpMethod(inlineHttpMethod, handler);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, 0);
                    VerifyRequestUrl(Put202_AzAsyncOperationHeaderUrl, handler, requestIndex: 1);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, requestIndex: 2);
                }

                /// <summary>
                /// 
                /// </summary>
                [Theory]
                [InlineData("PUT")]
                [InlineData("PATCH")]
                public void NoHeaders202(string inlineHttpMethod)
                {
                    var handler = new PlaybackTestHandler(LroRules.PUTResponses.NoHeaders202());
                    var fakeClient = GetClient(handler);
                    ExecuteOperation(inlineHttpMethod, fakeClient);

                    VerifyHttpMethod(inlineHttpMethod, handler);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, requestIndex: 1);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, requestIndex: 2);
                }
            }
            #endregion

            #region 200
            /// <summary>
            /// 
            /// </summary>
            public class Status200
            {
                /// <summary>
                /// 
                /// </summary>
                [Theory]
                [InlineData("PUT")]
                [InlineData("PATCH")]
                public void AzAsyncHeader200(string inlineHttpMethod)
                {
                    var handler = new PlaybackTestHandler(LroRules.PUTResponses.AzAsync200());
                    var fakeClient = GetClient(handler);
                    RedisResource redisRes = ExecuteOperation(inlineHttpMethod, fakeClient);

                    VerifyHttpMethod(inlineHttpMethod, handler);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, 0);
                    VerifyRequestUrl(Put202_AzAsyncOperationHeaderUrl, handler, requestIndex: 1);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, requestIndex: 3);

                    Assert.Equal(4, handler.Requests.Count);
                    Assert.NotNull(redisRes.Location);
                }

                /// <summary>
                /// 
                /// </summary>
                [Theory]
                [InlineData("PUT")]
                [InlineData("PATCH")]
                public void LocationHeader200(string inlineHttpMethod)
                {
                    var handler = new PlaybackTestHandler(LroRules.PUTResponses.Location200());
                    var fakeClient = GetClient(handler);
                    RedisResource redisRes = ExecuteOperation(inlineHttpMethod, fakeClient);

                    VerifyHttpMethod(inlineHttpMethod, handler);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, 0);
                    VerifyRequestUrl(Put202_LocationHeaderUrl, handler, requestIndex: 1);

                    //Verify we do not execute Final GET on original resource URI
                    Assert.Equal(2, handler.Requests.Count);
                    //VerifyRequestCount(inlineHttpMethod, handler, putCount: 2, patchCount: 1);

                    Assert.NotNull(redisRes.Location);
                }

                /// <summary>
                /// 
                /// </summary>
                [Theory]
                [InlineData("PUT")]
                [InlineData("PATCH")]
                public void LocationAndAzAsyncHeader200(string inlineHttpMethod)
                {
                    var handler = new PlaybackTestHandler(LroRules.PUTResponses.LocationAndAzAsync200());
                    var fakeClient = GetClient(handler);
                    ExecuteOperation(inlineHttpMethod, fakeClient);

                    VerifyHttpMethod(inlineHttpMethod, handler);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, 0);
                    VerifyRequestUrl(Put202_AzAsyncOperationHeaderUrl, handler, requestIndex: 1);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, requestIndex: 2);

                    Assert.Equal(3, handler.Requests.Count);
                }

                /// <summary>
                /// 
                /// </summary>
                [Theory]
                [InlineData("PUT")]
                [InlineData("PATCH")]
                public void NoHeader200Success(string inlineHttpMethod)
                {
                    var handler = new PlaybackTestHandler(LroRules.PUTResponses.NoHeaders200Success());
                    var fakeClient = GetClient(handler);
                    RedisResource redisRes = ExecuteOperation(inlineHttpMethod, fakeClient);

                    VerifyHttpMethod(inlineHttpMethod, handler);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, 0);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, requestIndex: 1);

                    //Verify we do not execute Final GET on original resource URI
                    Assert.Equal(3, handler.Requests.Count);

                    Assert.NotNull(redisRes.Id);
                }

                /// <summary>
                /// 
                /// </summary>
                [Theory]
                [InlineData("PUT")]
                [InlineData("PATCH")]
                public void NoHeader200PassThrough(string inlineHttpMethod)
                {
                    var handler = new PlaybackTestHandler(LroRules.PUTResponses.NoHeader200PassThrough());
                    var fakeClient = GetClient(handler);
                    RedisResource redisRes = ExecuteOperation(inlineHttpMethod, fakeClient);

                    VerifyHttpMethod(inlineHttpMethod, handler);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, 0);
                    VerifyRequestUrl(PutOriginalResourceRequestUrl, handler, requestIndex: 1);

                    //Verify we do not execute Final GET on original resource URI
                    Assert.Equal(2, handler.Requests.Count);

                    Assert.Null(redisRes.Id);
                }
            }
            #endregion

            #region helper functions
            //private static RedisManagementClient GetClient(DelegatingHandler handlerToAdd)
            //{
            //    var tokenCredentials = new TokenCredentials("123", "abc");
            //    var fakeClient = new RedisManagementClient(tokenCredentials, handlerToAdd);
            //    fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            //    return fakeClient;
            //}

            //private static void VerifyRequestCount(string httpStrMethod, PlaybackTestHandler handler, int putCount = 0, int patchCount = 0)
            //{
            //    if (httpStrMethod.Equals("PUT"))
            //        Assert.Equal(putCount, handler.Requests.Count);
            //    else if (httpStrMethod.Equals("PATCH"))
            //        Assert.Equal(patchCount, handler.Requests.Count);
            //}

            ////private static void VerifyHttpMethod(HttpMethod expectedStrMethod, PlaybackTestHandler handler, int requestIndex = 0)
            ////{
            ////    Assert.Equal(expectedStrMethod, handler.Requests[requestIndex].Method);
            ////}
            //private static void VerifyHttpMethod(string expectedStrMethod, PlaybackTestHandler handler, int requestIndex = 0)
            //{
            //    HttpMethod expMethod = null;

            //    switch (expectedStrMethod)
            //    {
            //        case "PUT":
            //            expMethod = HttpMethod.Put;
            //            break;

            //        case "PATCH":
            //            expMethod = new HttpMethod("PATCH");
            //            break;

            //        case "POST":
            //            expMethod = HttpMethod.Post;
            //            break;

            //        case "DELETE":
            //            expMethod = HttpMethod.Delete;
            //            break;
            //    }

            //    Assert.Equal(expMethod, handler.Requests[requestIndex].Method);
            //}

            //private static void VerifyRequestUrl(string expectedUrl, PlaybackTestHandler handler, int requestIndex = 0)
            //{
            //    Assert.Equal(expectedUrl, handler.Requests[requestIndex].RequestUri.ToString());
            //}

            private static RedisResource ExecuteOperation(string httpMethod, RedisManagementClient fakeClient)
            {
                if (httpMethod.Equals("PUT"))
                    return fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
                else if (httpMethod.Equals("PATCH"))
                    return fakeClient.RedisOperations.Patch("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
                else
                    return null;
            }
            #endregion
        }
        #endregion

        #region POST
        /// <summary>
        /// 
        /// </summary>
        public class POSTTests
        {
            #region 201
            /// <summary>
            /// 
            /// </summary>
            [Fact]
            public void NoHeader201()
            {
                var handler = new PlaybackTestHandler(LroRules.POSTResponses.NoHeader201());
                var fakeClient = GetClient(handler);
                Assert.Throws<CloudException>(() => fakeClient.RedisOperations.Post("rg", "redist", "1234"));
            }
            #endregion

            #region 202

            /// <summary>
            /// 
            /// </summary>
            [Fact]
            public void AzAsyncHeader202()
            {
                var handler = new PlaybackTestHandler(LroRules.POSTResponses.AzAsync202());
                var fakeClient = GetClient(handler);
                fakeClient.RedisOperations.Post("rg", "redist", "1234");

                VerifyHttpMethod("POST", handler, requestIndex: 0);
                VerifyRequestUrl(PostOriginalResourceRequestUrl, handler, 0);
                VerifyRequestUrl(Post202_AzAsyncOperationHeaderUrl, handler, requestIndex: 1);
                VerifyRequestUrl(Post202_AzAsyncOperationHeaderUrl, handler, requestIndex: 2);

                Assert.Equal(3, handler.Requests.Count);
            }


            /// <summary>
            /// 
            /// </summary>
            [Fact]
            public void LocationHeader202()
            {
                var handler = new PlaybackTestHandler(LroRules.POSTResponses.Location202());
                var fakeClient = GetClient(handler);
                fakeClient.RedisOperations.Post("rg", "redist", "1234");

                VerifyHttpMethod("POST", handler, requestIndex: 0);
                VerifyRequestUrl(PostOriginalResourceRequestUrl, handler, 0);
                VerifyRequestUrl(Post202_LocationHeaderUrl, handler, requestIndex: 1);
                VerifyRequestUrl(Post202_LocationHeaderUrl, handler, requestIndex: 2);

                Assert.Equal(4, handler.Requests.Count);
            }

            /// <summary>
            /// 
            /// </summary>
            [Fact]
            public void LocationAndAzAsyncHeader202()
            {
                var handler = new PlaybackTestHandler(LroRules.PUTResponses.LocationAndAzAsync202());
                var fakeClient = GetClient(handler);
                fakeClient.RedisOperations.Post("rg", "redist", "1234");

                VerifyHttpMethod("POST", handler, requestIndex: 0);
                VerifyRequestUrl(PostOriginalResourceRequestUrl, handler, 0);
                VerifyRequestUrl(Post202_AzAsyncOperationHeaderUrl, handler, requestIndex: 1);
                VerifyRequestUrl(Post202_LocationHeaderUrl, handler, requestIndex: 2);

                Assert.Equal(3, handler.Requests.Count);
            }


            /// <summary>
            /// 
            /// </summary>
            [Fact]
            public void NoHeader202()
            {
                var handler = new PlaybackTestHandler(LroRules.POSTResponses.NoHeader202());
                var fakeClient = GetClient(handler);
                Assert.Throws<ValidationException>(() => fakeClient.RedisOperations.Post("rg", "redist", "1234"));
            }

            #endregion


            #region helper functions
            private static RedisManagementClient GetClient(DelegatingHandler handlerToAdd)
            {
                var tokenCredentials = new TokenCredentials("123", "abc");
                var fakeClient = new RedisManagementClient(tokenCredentials, handlerToAdd);
                fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
                return fakeClient;
            }

            private static void VerifyRequestCount(string httpStrMethod, PlaybackTestHandler handler, int putCount = 0, int patchCount = 0)
            {
                if (httpStrMethod.Equals("PUT"))
                    Assert.Equal(putCount, handler.Requests.Count);
                else if (httpStrMethod.Equals("PATCH"))
                    Assert.Equal(patchCount, handler.Requests.Count);
            }

            private static void VerifyHttpMethod(string expectedStrMethod, PlaybackTestHandler handler, int requestIndex = 0)
            {
                HttpMethod expMethod = null;

                switch (expectedStrMethod)
                {
                    case "PUT":
                        expMethod = HttpMethod.Put;
                        break;

                    case "PATCH":
                        expMethod = new HttpMethod("PATCH");
                        break;

                    case "POST":
                        expMethod = HttpMethod.Post;
                        break;

                    case "DELETE":
                        expMethod = HttpMethod.Delete;
                        break;
                }

                Assert.Equal(expMethod, handler.Requests[requestIndex].Method);
            }

            private static void VerifyRequestUrl(string expectedUrl, PlaybackTestHandler handler, int requestIndex = 0)
            {
                Assert.Equal(expectedUrl, handler.Requests[requestIndex].RequestUri.ToString());
            }

            //private static T ExecuteOperation<T>(string httpMethod, RedisManagementClient fakeClient) where T: class
            //{
            //    if (httpMethod.Equals("PUT"))
            //        return fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            //    else if (httpMethod.Equals("PATCH"))
            //        return fakeClient.RedisOperations.Patch("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            //    else if (httpMethod.Equals("POST"))
            //        return fakeClient.RedisOperations.Post("rg", "redist", "1234")
            //    else if (httpMethod.Equals("DELETE"))
            //        return fakeClient.RedisOperations.Patch("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            //    else
            //        return null;
            //}
            #endregion
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 
        /// </summary>
        public class DELETETests
        {
            #region 201

            /// <summary>
            /// 
            /// </summary>
            [Fact]
            public void AzAsyncHeader201()
            {
                var handler = new PlaybackTestHandler(LroRules.DELETEResponses.AzAsync201());
                var fakeClient = GetClient(handler);
                Assert.Throws<ValidationException>(() => fakeClient.RedisOperations.Delete("rg", "redist", "1234"));
            }


            /// <summary>
            /// 
            /// </summary>
            [Fact]
            public void LocationHeader201()
            {
                var handler = new PlaybackTestHandler(LroRules.DELETEResponses.Location201());
                var fakeClient = GetClient(handler);
                fakeClient.RedisOperations.Delete("rg", "redist", "1234");

                VerifyHttpMethod("DELETE", handler, requestIndex: 0);
                VerifyRequestUrl(DeleteOriginalResourceRequestUrl, handler, 0);
                VerifyRequestUrl(Delete201_LocationHeaderUrl, handler, requestIndex: 1);
                VerifyRequestUrl(Delete201_LocationHeaderUrl, handler, requestIndex: 2);

                Assert.Equal(4, handler.Requests.Count);
            }

            /// <summary>
            /// 
            /// </summary>
            [Fact]
            public void LocationAndAzAsyncHeader201()
            {
                var handler = new PlaybackTestHandler(LroRules.DELETEResponses.LocationAndAzAsync201());
                var fakeClient = GetClient(handler);
                fakeClient.RedisOperations.Delete("rg", "redist", "1234");

                VerifyHttpMethod("DELETE", handler, requestIndex: 0);
                VerifyRequestUrl(DeleteOriginalResourceRequestUrl, handler, 0);
                VerifyRequestUrl(Delete201_LocationHeaderUrl, handler, requestIndex: 1);
                VerifyRequestUrl(Delete201_LocationHeaderUrl, handler, requestIndex: 2);

                Assert.Equal(4, handler.Requests.Count);
            }

            /// <summary>
            /// 
            /// </summary>
            [Fact]
            public void NoHeader201()
            {
                var handler = new PlaybackTestHandler(LroRules.DELETEResponses.NoHeader201());
                var fakeClient = GetClient(handler);
                Assert.Throws<ValidationException>(() => fakeClient.RedisOperations.Delete("rg", "redist", "1234"));
            }

            
            /// <summary>
            /// 
            /// </summary>
            [Fact]
            public void FinalGet404ForLocationHeader201()
            {
                var handler = new PlaybackTestHandler(LroRules.DELETEResponses.Location201FinalGet404());
                var fakeClient = GetClient(handler);
                fakeClient.RedisOperations.Delete("rg", "redist", "1234");

                VerifyHttpMethod("DELETE", handler, requestIndex: 0);
                VerifyRequestUrl(DeleteOriginalResourceRequestUrl, handler, 0);
                VerifyRequestUrl(Delete201_LocationHeaderUrl, handler, requestIndex: 1);
                VerifyRequestUrl(Delete201_LocationHeaderUrl, handler, requestIndex: 2);

                Assert.Equal(4, handler.Requests.Count);
            }

            #endregion

            #region 202

            /// <summary>
            /// 
            /// </summary>
            [Fact]
            public void AzAsyncHeader202()
            {
                var handler = new PlaybackTestHandler(LroRules.DELETEResponses.AzAsync202());
                var fakeClient = GetClient(handler);
                fakeClient.RedisOperations.Delete("rg", "redist", "1234");

                VerifyHttpMethod("DELETE", handler, requestIndex: 0);
                VerifyRequestUrl(DeleteOriginalResourceRequestUrl, handler, 0);
                VerifyRequestUrl(Delete202_AzAsyncOperationHeaderUrl, handler, requestIndex: 1);
                VerifyRequestUrl(Delete202_AzAsyncOperationHeaderUrl, handler, requestIndex: 2);

                Assert.Equal(3, handler.Requests.Count);
            }

            /// <summary>
            /// 
            /// </summary>
            [Fact]
            public void LocationHeader202()
            {
                var handler = new PlaybackTestHandler(LroRules.DELETEResponses.Location202());
                var fakeClient = GetClient(handler);
                fakeClient.RedisOperations.Delete("rg", "redist", "1234");

                VerifyHttpMethod("DELETE", handler, requestIndex: 0);
                VerifyRequestUrl(DeleteOriginalResourceRequestUrl, handler, 0);
                VerifyRequestUrl(Delete202_LocationHeaderUrl, handler, requestIndex: 1);
                VerifyRequestUrl(Delete202_LocationHeaderUrl, handler, requestIndex: 2);

                Assert.Equal(4, handler.Requests.Count);
            }

            /// <summary>
            /// 
            /// </summary>
            [Fact]
            public void LocationAndAzAsyncHeader202()
            {
                var handler = new PlaybackTestHandler(LroRules.DELETEResponses.LocationAndAzAsync202());
                var fakeClient = GetClient(handler);
                fakeClient.RedisOperations.Delete("rg", "redist", "1234");

                VerifyHttpMethod("DELETE", handler, requestIndex: 0);
                VerifyRequestUrl(DeleteOriginalResourceRequestUrl, handler, 0);
                VerifyRequestUrl(Delete202_AzAsyncOperationHeaderUrl, handler, requestIndex: 1);
                VerifyRequestUrl(Delete202_AzAsyncOperationHeaderUrl, handler, requestIndex: 2);
                VerifyRequestUrl(Delete202_LocationHeaderUrl, handler, requestIndex: 3);

                Assert.Equal(4, handler.Requests.Count);
            }

            /// <summary>
            /// 
            /// </summary>
            [Fact]
            public void NoHeader202()
            {
                var handler = new PlaybackTestHandler(LroRules.DELETEResponses.NoHeader202());
                var fakeClient = GetClient(handler);
                Assert.Throws<ValidationException>(() => fakeClient.RedisOperations.Delete("rg", "redist", "1234"));
            }
            
            /// <summary>
            /// 
            /// </summary>
            [Fact]
            public void FinalGet404LocAndAzAsyncHeader202()
            {
                var handler = new PlaybackTestHandler(LroRules.DELETEResponses.LocationAndAzAsync202FinalGet404());
                var fakeClient = GetClient(handler);
                fakeClient.RedisOperations.Delete("rg", "redist", "1234");

                VerifyHttpMethod("DELETE", handler, requestIndex: 0);
                VerifyRequestUrl(DeleteOriginalResourceRequestUrl, handler, 0);
                VerifyRequestUrl(Delete202_AzAsyncOperationHeaderUrl, handler, requestIndex: 1);
                VerifyRequestUrl(Delete202_AzAsyncOperationHeaderUrl, handler, requestIndex: 2);
                VerifyRequestUrl(Delete202_LocationHeaderUrl, handler, requestIndex: 3);

                Assert.Equal(4, handler.Requests.Count);
            }

            #endregion

        }
        #endregion
    }
}
