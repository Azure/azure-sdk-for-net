using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests.Unit
{
    [Parallelizable]
    public class HttpPipelineTests
    {
        [Test]
        public void CaeSupport()
        {
            int callCount = 0;
            var option = new ArmClientOptions()
            {
                // we mock a CAE challenge before the actual response is returned
                Transport = new MockTransport((r) =>
                {
                    callCount++;

                    if (callCount == 1)
                    {
                        return new MockResponse(401).WithHeader("WWW-Authenticate", CaeChallenge);
                    }
                    var response = new MockResponse(200);
                    response.SetContent(SubscriptionData);
                    return response;
                })
            };
            var client = new ArmClient(new MockCredential(), "83aa47df-e3e9-49ff-877b-94304bf3d3ad", option);
            var subscription = client.GetDefaultSubscription();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("83aa47df-e3e9-49ff-877b-94304bf3d3ad", subscription.Data.Id.SubscriptionId);
            Assert.AreEqual("Subscription2", subscription.Data.DisplayName);
            Assert.IsEmpty(subscription.Data.Tags);
        }

        [Test]
        public void InvalidCaeResponse()
        {
            int callCount = 0;
            var option = new ArmClientOptions()
            {
                // we mock a CAE challenge before the actual response is returned
                Transport = new MockTransport((r) =>
                {
                    callCount++;

                    if (callCount == 1)
                    {
                        return new MockResponse(401).WithHeader("WWW-Authenticate", InvalidCaeChallenge);
                    }
                    var response = new MockResponse(200);
                    response.SetContent(SubscriptionData);
                    return response;
                })
            };
            var client = new ArmClient(new MockCredential(), "83aa47df-e3e9-49ff-877b-94304bf3d3ad", option);
            Assert.Throws<RequestFailedException>(() => client.GetDefaultSubscription());
            Assert.AreEqual(1, callCount);
        }

        private const string CaeChallenge = """Bearer realm="", error_description="Continuous access evaluation resulted in challenge", error="insufficient_claims", claims="eyJhY2Nlc3NfdG9rZW4iOnsibmJmIjp7ImVzc2VudGlhbCI6dHJ1ZSwgInZhbHVlIjoiMTcyNjI1ODEyMiJ9fX0=" """;

        private const string InvalidCaeChallenge = """Bearer realm="", error_description="", error="insufficient_claims", claims="" """;

        private const string SubscriptionData = @"{
  ""id"": ""/subscriptions/83aa47df-e3e9-49ff-877b-94304bf3d3ad"",
  ""authorizationSource"": ""Legacy"",
  ""subscriptionId"": ""83aa47df-e3e9-49ff-877b-94304bf3d3ad"",
  ""displayName"": ""Subscription2"",
  ""state"": ""Enabled"",
  ""subscriptionPolicies"": {
    ""locationPlacementId"": ""Internal_2014-09-01"",
    ""quotaId"": ""Internal_2014-09-01"",
    ""spendingLimit"": ""Off""
  }
}";
    }
}
