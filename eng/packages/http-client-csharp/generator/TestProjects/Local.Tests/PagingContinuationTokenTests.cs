// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using BasicTypeSpec;
using NUnit.Framework;

namespace TestProjects.Local.Tests
{
    public class PagingContinuationTokenTests
    {
        [Test]
        public async Task ReturnedNextLinkCanBeResumed(
            [Values(false, true)] bool isAsync,
            [Values("body", "string", "header")] string nextLinkLocation,
            [Values(
                "/items?api-version=2025-01-01&$skiptoken=page%2B2%2F%3D",
                "items?api-version=2025-01-01&$skiptoken=page%2B2%2F%3D",
                "https://example.test/items?api-version=2025-01-01&$skiptoken=page%2B2%2F%3D")] string nextLink)
        {
            var endpoint = new Uri("https://example.test/base/");
            using var handler = new PagingHandler(nextLink, nextLinkLocation == "header");
            using var httpClient = new HttpClient(handler);
            var client = new BasicTypeSpecClient(endpoint, new AzureKeyCredential("test-key"), new BasicTypeSpecClientOptions
            {
                Transport = new HttpClientTransport(httpClient)
            });

            var pages = await GetPages(client, isAsync, nextLinkLocation);
            Assert.AreEqual(2, pages.Count);
            Assert.AreEqual("first", pages[0].Values.Single().Name);
            Assert.AreEqual(nextLink, pages[0].ContinuationToken);
            Assert.AreEqual("second", pages[1].Values.Single().Name);
            Assert.IsNull(pages[1].ContinuationToken);

            var resumedPages = await GetPages(client, isAsync, nextLinkLocation, pages[0].ContinuationToken);
            Assert.AreEqual(1, resumedPages.Count);
            Assert.AreEqual("second", resumedPages[0].Values.Single().Name);
            Assert.IsNull(resumedPages[0].ContinuationToken);

            Assert.AreEqual(3, handler.Requests.Count);
            Assert.That(handler.Requests[0].Query, Does.Not.Contain("resumeFrom"));
            Assert.That(handler.Requests[0].Query, Does.Not.Contain("continuationToken"));
            var expectedNextUri = new Uri(endpoint, nextLink);
            Assert.AreEqual(expectedNextUri, handler.Requests[1]);
            Assert.AreEqual(expectedNextUri, handler.Requests[2]);
            Assert.That(handler.Requests.All(uri => uri.Scheme == Uri.UriSchemeHttps));
        }

        [Test]
        public void NextLinkMethodsDoNotExposeRequestToken()
        {
            foreach (var method in typeof(BasicTypeSpecClient).GetMethods().Where(
                m => m.Name is "GetWithNextLink" or "GetWithNextLinkAsync" or "GetWithHeaderNextLink" or "GetWithHeaderNextLinkAsync"))
            {
                Assert.That(method.GetParameters().All(p => p.Name != "resumeFrom"));
            }
        }

        [Test]
        public async Task RetainedRequestTokenIsSentOnFirstRequest([Values] bool isAsync, [Values] bool isProtocol)
        {
            using var handler = new PagingHandler("/items?page=2", false, emptyItems: true);
            using var httpClient = new HttpClient(handler);
            var client = new BasicTypeSpecClient(new Uri("https://example.test/"), new AzureKeyCredential("test-key"),
                new BasicTypeSpecClientOptions { Transport = new HttpClientTransport(httpClient) });
            const string token = "bare-token";
            if (isAsync)
            {
                if (isProtocol)
                {
                    await foreach (var item in new BasicTypeSpecClientGetWithNextLinkAsyncCollectionResult(client, token, null, "paging"))
                    {
                    }
                }
                else
                {
                    await foreach (var item in new BasicTypeSpecClientGetWithNextLinkAsyncCollectionResultOfT(client, token, null, "paging"))
                    {
                    }
                }
            }
            else if (isProtocol)
            {
                _ = new BasicTypeSpecClientGetWithNextLinkCollectionResult(client, token, null, "paging").ToList();
            }
            else
            {
                _ = new BasicTypeSpecClientGetWithNextLinkCollectionResultOfT(client, token, null, "paging").ToList();
            }
            Assert.AreEqual(2, handler.Requests.Count);
            Assert.That(handler.Requests[0].Query, Does.Contain("resumeFrom=bare-token"));
            Assert.That(handler.Requests[1].Query, Does.Not.Contain("resumeFrom"));
        }

        private static async Task<List<Page<ThingModel>>> GetPages(
            BasicTypeSpecClient client, bool isAsync, string nextLinkLocation, string? continuationToken = null)
        {
            if (!isAsync)
            {
                var result = nextLinkLocation switch
                {
                    "header" => client.GetWithHeaderNextLink(),
                    "string" => client.GetWithStringNextLink(),
                    _ => client.GetWithNextLink()
                };
                return result.AsPages(continuationToken).ToList();
            }

            var asyncResult = nextLinkLocation switch
            {
                "header" => client.GetWithHeaderNextLinkAsync(),
                "string" => client.GetWithStringNextLinkAsync(),
                _ => client.GetWithNextLinkAsync()
            };
            var pages = new List<Page<ThingModel>>();
            await foreach (var page in asyncResult.AsPages(continuationToken))
            {
                pages.Add(page);
            }
            return pages;
        }

        private sealed class PagingHandler(string nextLink, bool headerNextLink, bool emptyItems = false) : HttpMessageHandler
        {
            public List<Uri> Requests { get; } = new();

            protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Assert.IsFalse(request.Headers.Contains("x-continuation-token"));
                Requests.Add(request.RequestUri!);
                bool firstPage = Requests.Count == 1;
                string name = firstPage ? "first" : "second";
                string items = emptyItems ? "" : $"{{\"name\":\"{name}\"}}";
                string next = firstPage && !headerNextLink ? $",\"next\":\"{nextLink}\"" : "";
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent($"{{\"things\":[{items}]{next}}}", Encoding.UTF8, "application/json")
                };
                if (firstPage && headerNextLink)
                {
                    response.Headers.Add("next", nextLink);
                }
                return response;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
                => Task.FromResult(Send(request, cancellationToken));
        }
    }
}
