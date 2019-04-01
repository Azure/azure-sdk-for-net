// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿
namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Auth;
    using Protocol=Microsoft.Azure.Batch.Protocol;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Models = Microsoft.Azure.Batch.Protocol.Models;
    using System.Threading;
    using System.Net;

    public class ApplicationPackageUnitTests
    {
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task CheckListApplicationSummariesIsReturningAValidList()
        {
            const string applicationId = "blender.exe";
            const string displayName = "blender";

            IList<string> versions = new[] { "1.0", "1.5" };

            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(baseRequest =>
                    {
                        var request = (Protocol.BatchRequest<Models.ApplicationListOptions, AzureOperationResponse<IPage<Models.ApplicationSummary>, Models.ApplicationListHeaders>>)baseRequest;

                        request.ServiceRequestFunc = (token) =>
                            {
                                var response = new AzureOperationResponse<IPage<Models.ApplicationSummary>, Models.ApplicationListHeaders>
                                {
                                    Body = new FakePage<Models.ApplicationSummary>(new[]
                                    {
                                        new Models.ApplicationSummary
                                            {
                                                Id = applicationId,
                                                DisplayName = displayName,
                                                Versions = versions
                                            },
                                    })
                                };

                                return Task.FromResult(response);
                            };
                    });

                IPagedEnumerable<Microsoft.Azure.Batch.ApplicationSummary> applicationSummaries = client.ApplicationOperations.ListApplicationSummaries(additionalBehaviors: new List<BatchClientBehavior> { interceptor });

                Assert.Equal(1, applicationSummaries.Count());

                var applicationSummary = applicationSummaries.First();
                Assert.Equal(applicationId, applicationSummary.Id);
                Assert.Equal(displayName, applicationSummary.DisplayName);
                Assert.Equal(versions.First(), applicationSummary.Versions.First());
                Assert.Equal(versions.Count, applicationSummary.Versions.ToList().Count);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task GetApplicationSummaryAsyncTest()
        {
            const string applicationId = "blender.exe";
            const string displayName = "blender";

            IList<string> versions = new[] { "1.0", "1.5" };

            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(
                    baseRequest =>
                    {
                        var request = (Protocol.BatchRequest<Models.ApplicationGetOptions, AzureOperationResponse<Models.ApplicationSummary, Models.ApplicationGetHeaders>>)baseRequest;

                        request.ServiceRequestFunc = (token) =>
                            {
                                var response = new AzureOperationResponse<Models.ApplicationSummary, Models.ApplicationGetHeaders>
                                {
                                    Body = new Models.ApplicationSummary
                                    {
                                        Id = applicationId,
                                        DisplayName = displayName,
                                        Versions = versions
                                    }
                                };

                                return Task.FromResult(response);
                            };
                    });


                Microsoft.Azure.Batch.ApplicationSummary applicationSummary = client.ApplicationOperations.GetApplicationSummaryAsync(applicationId, additionalBehaviors: new List<BatchClientBehavior> { interceptor }).Result;
                Assert.Equal(applicationId, applicationSummary.Id);
                Assert.Equal(displayName, applicationSummary.DisplayName);


                Assert.Equal(versions.First(), applicationSummary.Versions.First());
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void GetApplicationSummaryTest()
        {
            const string applicationId = "blender.exe";
            const string displayName = "blender";

            IList<string> versions = new[] { "1.0", "1.5" };

            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(baseRequest =>
                {
                    var request = (Protocol.BatchRequest<Models.ApplicationGetOptions, AzureOperationResponse<Models.ApplicationSummary, Models.ApplicationGetHeaders>>)baseRequest;

                    request.ServiceRequestFunc = (token) =>
                    {
                        var response = new AzureOperationResponse<Models.ApplicationSummary, Models.ApplicationGetHeaders>
                        {
                            Body = new Models.ApplicationSummary
                            {
                                Id = applicationId,
                                DisplayName = displayName,
                                Versions = versions
                            }
                        };

                        return Task.FromResult(response);
                    };
                });


                Microsoft.Azure.Batch.ApplicationSummary applicationSummary = client.ApplicationOperations.GetApplicationSummary(applicationId, additionalBehaviors: new List<BatchClientBehavior> { interceptor });
                Assert.Equal(applicationId, applicationSummary.Id);
                Assert.Equal(displayName, applicationSummary.DisplayName);
                Assert.Equal(versions.First(), applicationSummary.Versions.First());
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task IfListApplicationSummariesReturnsNoSkipToken_ThenNoFurtherCallsAreMade()
        {
            var fakeResponse = @"{
""value"" : [
  { ""id"" : ""app1"", ""versions"" : [ ""1"", ""2"" ] },
  { ""id"" : ""app2"", ""versions"" : [ ""beta"" ] },
  { ""id"" : ""app3"", ""versions"" : [ ""1"", ""2"" ] }
]
}";

            var requests = new List<Uri>();
            var results = new List<Microsoft.Azure.Batch.ApplicationSummary>();

            Func<Uri, string> responseBody = uri =>
            {
                requests.Add(uri);

                return fakeResponse;
            };

            using (BatchClient client = BatchClient.Open(FakeClient.Create(HttpStatusCode.OK, responseBody)))
            {
                results = await client.ApplicationOperations.ListApplicationSummaries().ToListAsync();
            }

            Assert.Equal(1, requests.Count);

            Assert.Equal(3, results.Count);
            Assert.Equal("app1", results[0].Id);
            Assert.Equal("app3", results[2].Id);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task IfListApplicationSummariesReturnsASkipToken_ThenFurtherCallsAreMadeUntilItDoesnt()
        {
            var fakeResponse1 = @"{
""value"" : [
  { ""id"" : ""app1"", ""versions"" : [ ""1"", ""2"" ] },
  { ""id"" : ""app2"", ""versions"" : [ ""beta"" ] }
],
""odata.nextLink"" : ""http://skip1/"",
}";

            var fakeResponse2 = @"{
""value"" : [
  { ""id"" : ""app3"", ""versions"" : [ ""1"", ""2"" ] },
  { ""id"" : ""app4"", ""versions"" : [ ""beta"" ] }
],
""odata.nextLink"" : ""http://skip2/"",
}";

            var fakeResponse3 = @"{
""value"" : [
  { ""id"" : ""app5"", ""versions"" : [ ""1"", ""2"" ] }
]
}";

            var requests = new List<Uri>();
            var results = new List<Microsoft.Azure.Batch.ApplicationSummary>();

            Func<Uri, string> responseBody = uri =>
                {
                    requests.Add(uri);

                    switch (uri.AbsoluteUri)
                    {
                        case "http://skip1/": return fakeResponse2;
                        case "http://skip2/": return fakeResponse3;
                        default: return fakeResponse1;
                    }
                };

            using (BatchClient client = BatchClient.Open(FakeClient.Create(HttpStatusCode.OK, responseBody)))
            {
                results = await client.ApplicationOperations.ListApplicationSummaries().ToListAsync();
            }

            Assert.Equal(3, requests.Count);

            Assert.Equal(5, results.Count);
            Assert.Equal("app1", results[0].Id);
            Assert.Equal("app5", results[4].Id);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ApplicationPackageSummaryWithNullPropertiesFromProtocol()
        {
            ApplicationSummary summary = new ApplicationSummary(new Protocol.Models.ApplicationSummary());

            Assert.Null(summary.DisplayName);
            Assert.Null(summary.Id);
            Assert.Null(summary.Versions);
        }

    }
}
