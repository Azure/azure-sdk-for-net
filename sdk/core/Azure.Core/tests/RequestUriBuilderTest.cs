// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Http;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RequestUriBuilderTest
    {
        public static Uri[] Uris { get; } = {
            new Uri("https://localhost:20/query?query"),
            new Uri("https://localhost"),
            new Uri("http://localhost"),
            new Uri("http://localhost?query"),
            new Uri("https://localhost:443/"),
            new Uri("http://localhost:80/"),
            new Uri("http://localhost:80/ ? "),
        };

        [TestCaseSource(nameof(Uris))]
        public void RoundtripWithUri(Uri uri)
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(uri);

            Assert.AreEqual(uri.Scheme, uriBuilder.Scheme);
            Assert.AreEqual(uri.Host, uriBuilder.Host);
            Assert.AreEqual(uri.Port, uriBuilder.Port);
            Assert.AreEqual(uri.AbsolutePath, uriBuilder.Path);
            Assert.AreEqual(uri.Query, uriBuilder.Query);
            Assert.AreEqual(uri, uriBuilder.ToUri());
            Assert.AreSame(uri, uriBuilder.ToUri());
        }

        [TestCase("", "http://localhost/")]
        [TestCase("/", "http://localhost/")]
        [TestCase("a", "http://localhost/a")]
        [TestCase("/a", "http://localhost/a")]
        public void AddsLeadingSlashToPath(string path, string expected)
        {
            var uriBuilder = new RequestUriBuilder
            {
                Scheme = "http",
                Host = "localhost",
                Port = 80,
                Path = path
            };

            Assert.AreEqual(expected, uriBuilder.ToUri().ToString());
        }

        [TestCase("", "http://localhost/")]
        [TestCase("?", "http://localhost/?")]
        [TestCase("a", "http://localhost/?a")]
        [TestCase("?a", "http://localhost/?a")]
        public void AddsLeadingQuestionMarkToQuery(string query, string expected)
        {
            var uriBuilder = new RequestUriBuilder
            {
                Scheme = "http",
                Host = "localhost",
                Port = 80,
                Query = query
            };

            Assert.AreEqual(expected, uriBuilder.ToUri().ToString());
        }

        [TestCase(null)]
        [TestCase("")]
        public void SettingQueryToEmptyRemovesQuestionMark(string query)
        {
            var uriBuilder = new RequestUriBuilder
            {
                Scheme = "http",
                Host = "localhost",
                Port = 80,
                Query = "a"
            };

            Assert.AreEqual("http://localhost/?a", uriBuilder.ToUri().ToString());

            uriBuilder.Query = query;

            Assert.AreEqual("http://localhost/", uriBuilder.ToUri().ToString());
        }

        [TestCase("\u1234\u2345", "%E1%88%B4%E2%8D%85")]
        [TestCase("\u1234", "%E1%88%B4")]
        [TestCase("\u1234\u2345", "%E1%88%B4%E2%8D%85")]
        [TestCase(" ", "%20")]
        [TestCase("%#?&", "%25#?&")]
        public void PathIsEscaped(string path, string expectedPath)
        {
            var uriBuilder = new RequestUriBuilder
            {
                Scheme = "http",
                Host = "localhost",
                Port = 80,
                Path = path
            };

            Assert.AreEqual("http://localhost/" + expectedPath, uriBuilder.ToUri().OriginalString);
        }

        [Test]
        public void QueryIsNotEscaped()
        {
            var uriBuilder = new RequestUriBuilder
            {
                Scheme = "http",
                Host = "localhost",
                Port = 80,
                Query = "\u1234"
            };

            Assert.AreEqual("http://localhost/?\u1234", uriBuilder.ToUri().ToString());
        }

        [Test]
        public void AppendQueryWithEmptyValueWorks()
        {
            var uriBuilder = new RequestUriBuilder
            {
                Scheme = "http",
                Host = "localhost",
                Port = 80
            };
            uriBuilder.AppendQuery("a", null);

            Assert.AreEqual("http://localhost/?a=", uriBuilder.ToUri().ToString());
        }

        [TestCase(null, "http://localhost/?a=b&c=d")]
        [TestCase("", "http://localhost/?a=b&c=d")]
        [TestCase("a", "http://localhost/?a&a=b&c=d")]
        [TestCase("?", "http://localhost/?a=b&c=d")]
        [TestCase("?initial", "http://localhost/?initial&a=b&c=d")]
        public void AppendQueryWorks(string initialQuery, string expectedResult)
        {
            var uriBuilder = new RequestUriBuilder
            {
                Scheme = "http",
                Host = "localhost",
                Port = 80,
                Query = initialQuery
            };
            uriBuilder.AppendQuery("a", "b");
            uriBuilder.AppendQuery("c", "d");

            Assert.AreEqual(expectedResult, uriBuilder.ToUri().ToString());
        }

        [TestCase(null, "", "http://localhost/")]
        [TestCase("/", "/", "http://localhost/")]
        [TestCase(null, "p", "http://localhost/p")]
        [TestCase("/", "p", "http://localhost/p")]
        [TestCase("/", "/p", "http://localhost/p")]
        [TestCase("", "\u1234", "http://localhost/%E1%88%B4")]
        public void AppendPathWorks(string initialPath, string append, string expectedResult)
        {
            var uriBuilder = new RequestUriBuilder
            {
                Scheme = "http",
                Host = "localhost",
                Port = 80,
                Path = initialPath
            };
            uriBuilder.AppendPath(append);

            Assert.AreEqual(expectedResult, uriBuilder.ToUri().OriginalString);
        }

        [Test]
        public void AppendingQueryResetsUri()
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(new Uri("http://localhost/"));
            uriBuilder.AppendQuery("a", "b");

            Assert.AreEqual("http://localhost/?a=b", uriBuilder.ToUri().ToString());
        }

        [Test]
        public void AppendingPathResetsUri()
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(new Uri("http://localhost/"));
            uriBuilder.AppendPath("a");

            Assert.AreEqual("http://localhost/a", uriBuilder.ToUri().ToString());
        }

        [Test]
        public void AppendingPathAfterQueryAndSettingTheUriWorks()
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(new Uri("http://localhost/"));
            uriBuilder.AppendQuery("query", "value");
            uriBuilder.AppendPath("a");
            uriBuilder.AppendPath("b");
            uriBuilder.AppendQuery("c", "d");

            Assert.AreEqual("http://localhost/ab?query=value&c=d", uriBuilder.ToUri().ToString());
        }

        [TestCase("?a", "?a")]
        [TestCase("?a=b", "?a=b")]
        [TestCase("?a=b&", "?a=b&")]
        [TestCase("?a=b&d", "?a=b&d")]
        [TestCase("?a=b&d=1&", "?a=b&d=*&")]
        [TestCase("?a=b&d=1&a1", "?a=b&d=*&a1")]
        [TestCase("?a=b&d=1&a1=", "?a=b&d=*&a1=")]
        [TestCase("?a=b&d=11&a1=&", "?a=b&d=*&a1=&")]
        [TestCase("?d&d&d&", "?d&d&d&")]
        [TestCase("?a&a&a&a", "?a&a&a&a")]
        [TestCase("?&&&&&&&", "?&&&&&&&")]
        [TestCase("?d", "?d")]
        public void QueryIsSanitized(string input, string expected)
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(new Uri("http://localhost/" + input));

            Assert.AreEqual("http://localhost/" + expected, uriBuilder.ToString(new[]
            {
                "A",
                "a1",
                "a-2"
            }, "*"));
        }
    }
}
