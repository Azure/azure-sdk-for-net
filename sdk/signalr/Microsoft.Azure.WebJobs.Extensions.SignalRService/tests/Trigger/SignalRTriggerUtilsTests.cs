// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Newtonsoft.Json;
using Xunit;

namespace SignalRServiceExtension.Tests
{
    public class SignalRTriggerUtilsTests
    {
        public static IEnumerable<object[]> QueryStringTestData()
        {
            yield return new object[] { "?k=v", new Dictionary<string, string> { ["k"] = "v" } };
            yield return new object[] { "?k1=v1&k2=v2", new Dictionary<string, string> { ["k1"] = "v1", ["k2"] = "v2" } };
            yield return new object[] { "?k1=v1&k1=v2", new Dictionary<string, string> { ["k1"] = "v1,v2" } };
            yield return new object[] { "?k1=v1&k1=v2&k2=v3", new Dictionary<string, string> { ["k1"] = "v1,v2", ["k2"] = "v3" } };
        }

        public static IEnumerable<object[]> HeaderTestData()
        {
            var request1 = new HttpRequestMessage();
            request1.Headers.Add("k", "v");
            yield return new object[] { request1.Headers, new Dictionary<string, string> { ["k"] = "v" } };

            var request2 = new HttpRequestMessage();
            request2.Headers.Add("k1", "v1");
            request2.Headers.Add("K2", "v2");
            yield return new object[] { request2.Headers, new Dictionary<string, string> { ["k1"] = "v1", ["K2"] = "v2" } };

            var request3 = new HttpRequestMessage();
            request3.Headers.Add("k1", "v1");
            request3.Headers.Add("k1", "v2");
            yield return new object[] { request3.Headers, new Dictionary<string, string> { ["k1"] = "v1,v2" } };

            var request4 = new HttpRequestMessage();
            request4.Headers.Add("k1", "v1");
            request4.Headers.Add("k1", "v2");
            request4.Headers.Add("k2", "v3");
            yield return new object[] { request4.Headers, new Dictionary<string, string> { ["k1"] = "v1,v2", ["k2"] = "v3" } };
        }

        public static IEnumerable<object[]> ClaimsTestData()
        {
            yield return new object[] { "k: v", new Dictionary<string, string> { ["k"] = "v" } };
            yield return new object[] { "k1: v1, k2: v2", new Dictionary<string, string> { ["k1"] = "v1", ["k2"] = "v2" } };
            yield return new object[] { "k1: v1, k1: v2", new Dictionary<string, string> { ["k1"] = "v1" } };
            yield return new object[] { "k1: v1, k1: v2, k2: v3", new Dictionary<string, string> { ["k1"] = "v1", ["k2"] = "v3" } };
        }

        [Theory]
        [MemberData(nameof(QueryStringTestData))]
        public void GetQueryDictionaryTest(string queryString, object expectedResult)
        {
            var result = SignalRTriggerUtils.GetQueryDictionary(queryString);
            Assert.Equal(JsonConvert.SerializeObject(expectedResult), JsonConvert.SerializeObject(result));
        }

        [Theory]
        [MemberData(nameof(HeaderTestData))]
        public void GetHeaderDictionaryTest(HttpRequestHeaders headers, object expectedResult)
        {
            var result = SignalRTriggerUtils.GetHeaderDictionary(headers);
            Assert.Equal(JsonConvert.SerializeObject(expectedResult), JsonConvert.SerializeObject(result));
        }

        [Theory]
        [MemberData(nameof(ClaimsTestData))]
        public void GetClaimsDictionaryTest(string claims, object expectedResult)
        {
            var result = SignalRTriggerUtils.GetClaimDictionary(claims);
            Assert.Equal(JsonConvert.SerializeObject(expectedResult), JsonConvert.SerializeObject(result));
        }
    }
}