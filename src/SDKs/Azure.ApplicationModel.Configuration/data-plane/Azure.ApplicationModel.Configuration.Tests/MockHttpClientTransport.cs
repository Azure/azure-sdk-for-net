//// Copyright (c) Microsoft Corporation. All rights reserved.
//// Licensed under the MIT License. See License.txt in the project root for
//// license information.

//using Azure.Base.Http;
//using Azure.Base.Http.Pipeline;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Net.Http;
//using System.Text;
//using System.Text.Json;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Azure.ApplicationModel.Configuration.Test
//{

//    class UpdateMockTransport : MockHttpClientTransport
//    {
//        public UpdateMockTransport(ConfigurationSetting responseContent)
//        {
//            _expectedUri = $"https://contoso.azconfig.io/kv/{responseContent.Key}{GetExtraUriParameters(responseContent)}";
//            _expectedMethod = HttpMethod.Put;
//            _expectedRequestContent = GenerateExpectedRequestContent(responseContent);
//            _responseContent = Encoding.UTF8.GetString(Serialize(responseContent).ToArray());
//        }

//        protected override void VerifyRequestCore(HttpRequestMessage request)
//        {
//            Assert.IsTrue(request.Headers.Contains("If-Match"));
//        }
//    }

//    class DeleteMockTransport : MockHttpClientTransport
//    {
//        public DeleteMockTransport(string key, string label, ConfigurationSetting responseContent)
//        {
//            _expectedUri = $"https://contoso.azconfig.io/kv/{key}{GetExtraUriParameters(label)}";
//            _expectedRequestContent = null;
//            _expectedMethod = HttpMethod.Delete;
//            if (responseContent != null)
//            {
//                _responseContent = Encoding.UTF8.GetString(Serialize(responseContent).ToArray());
//            }
//        }

//        public DeleteMockTransport(string key, string label, HttpStatusCode statusCode)
//            : this(key, label, responseContent: null)
//        {
//            Responses.Clear();
//            Responses.Add(statusCode);
//        }
//    }

//    // TODO (pri 3): this should emit the etag response header
//    class GetMockTransport : MockHttpClientTransport
//    {
//        public GetMockTransport(string queryKey, string label, ConfigurationSetting responseContent)
//        {
//            _expectedMethod = HttpMethod.Get;
//            _expectedUri = $"https://contoso.azconfig.io/kv/{queryKey}{GetExtraUriParameters(label)}";
//            _expectedRequestContent = null;
//            if (responseContent != null)
//            {
//                _responseContent = Encoding.UTF8.GetString(Serialize(responseContent).Span.ToArray());
//            }
//        }

//        public GetMockTransport(string queryKey, string label, ConfigurationSetting result, params HttpStatusCode[] statusCodes)
//            : this(queryKey, label, result)
//        {
//            Responses.Clear();
//            foreach (var statusCode in statusCodes) {
//                Responses.Add(statusCode);
//            }
//        }
//    }

//    class LockingMockTransport : MockHttpClientTransport
//    {
//        public LockingMockTransport(ConfigurationSetting responseContent, bool lockOtherwiseUnlock)
//        {
//            _expectedUri = $"https://contoso.azconfig.io/locks/{responseContent.Key}{GetExtraUriParameters(responseContent)}";
//            _expectedRequestContent = null;
//            _expectedMethod = lockOtherwiseUnlock ? HttpMethod.Put : HttpMethod.Delete;
//            responseContent.Locked = lockOtherwiseUnlock;
//            _responseContent = Encoding.UTF8.GetString(Serialize(responseContent).ToArray());
//        }
//    }

//    class GetBatchMockTransport : MockHttpClientTransport
//    {
//        public List<ConfigurationSetting> KeyValues = new List<ConfigurationSetting>();

//        public List<(int index, int count)> Batches = new List<(int index, int count)>();

//        int _currentBathIndex = 0;

//        public GetBatchMockTransport(int numberOfItems)
//        {
//            _expectedMethod = HttpMethod.Get;
//            _expectedUri = new StringCheck("https://contoso.azconfig.io/kv/?", StringCheck.CheckKind.StartsWith);
//            _expectedRequestContent = null;
//            for (int i = 0; i < numberOfItems; i++)
//            {
//                var item = new ConfigurationSetting($"key{i}", "val")
//                {
//                    Label = "label", ETag = new ETag("c3c231fd-39a0-4cb6-3237-4614474b92c1"), ContentType = "text"
//                };
//                KeyValues.Add(item);
//            }
//        }

//        // this is just so the mock serialization works as desired, i.e. so that the payload has items property
//        class MockBatch
//        {
//            public List<ConfigurationSetting> Items = new List<ConfigurationSetting>();
//        }

//        protected override void WriteResponseCore(HttpResponseMessage response)
//        {
//            var batch = Batches[_currentBathIndex++];
//            var bathItems = new MockBatch();
//            int itemIndex = batch.index;
//            int count = batch.count;
//            while (count-- > 0)
//            {
//                bathItems.Items.Add(KeyValues[itemIndex++]);
//            }

//            ReadOnlyMemory<byte> content = Serialize(bathItems);

//            string json = Encoding.UTF8.GetString(content.Span.ToArray());
//            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

//            long jsonByteCount = Encoding.UTF8.GetByteCount(json);
//            response.Content.Headers.Add("Content-Length", jsonByteCount.ToString());
//            if (itemIndex < KeyValues.Count)
//            {
//                response.Headers.Add("Link", $"</kv?after={itemIndex}>;rel=\"next\"");
//            }
//        }
//    }
//}
