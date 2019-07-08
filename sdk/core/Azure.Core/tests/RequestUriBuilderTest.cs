// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            uriBuilder.Uri = uri;

            Assert.AreEqual(uri.Scheme, uriBuilder.Scheme);
            Assert.AreEqual(uri.Host, uriBuilder.Host);
            Assert.AreEqual(uri.Port, uriBuilder.Port);
            Assert.AreEqual(uri.AbsolutePath, uriBuilder.Path);
            Assert.AreEqual(uri.Query, uriBuilder.Query);
            Assert.AreEqual(uri, uriBuilder.Uri);
            Assert.AreSame(uri, uriBuilder.Uri);
        }

        [TestCase("", "http://localhost/")]
        [TestCase("/", "http://localhost/")]
        [TestCase("a", "http://localhost/a")]
        [TestCase("/a", "http://localhost/a")]
        public void AddsLeadingSlashToPath(string path, string expected)
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "localhost";
            uriBuilder.Port = 80;
            uriBuilder.Path = path;

            Assert.AreEqual(expected, uriBuilder.Uri.ToString());
        }

        [TestCase("", "http://localhost/")]
        [TestCase("?", "http://localhost/?")]
        [TestCase("a", "http://localhost/?a")]
        [TestCase("?a", "http://localhost/?a")]
        public void AddsLeadingQuestionMarkToQuery(string query, string expected)
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "localhost";
            uriBuilder.Port = 80;
            uriBuilder.Query = query;

            Assert.AreEqual(expected, uriBuilder.Uri.ToString());
        }

        [TestCase(null)]
        [TestCase("")]
        public void SettingQueryToEmptyRemovesQuestionMark(string query)
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "localhost";
            uriBuilder.Port = 80;
            uriBuilder.Query = "a";

            Assert.AreEqual("http://localhost/?a", uriBuilder.Uri.ToString());

            uriBuilder.Query = query;

            Assert.AreEqual("http://localhost/", uriBuilder.Uri.ToString());
        }

        [TestCase("\u1234\u2345", "%E1%88%B4%E2%8D%85")]
        [TestCase("\u1234", "%E1%88%B4")]
        [TestCase("\u1234\u2345", "%E1%88%B4%E2%8D%85")]
        [TestCase(" ", "%20")]
        [TestCase("%#?&", "%25#?&")]
        public void PathIsEscaped(string path, string expectedPath)
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "localhost";
            uriBuilder.Port = 80;
            uriBuilder.Path = path;

            Assert.AreEqual("http://localhost/" + expectedPath, uriBuilder.Uri.OriginalString);
        }

        [Test]
        public void QueryIsNotEscaped()
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "localhost";
            uriBuilder.Port = 80;
            uriBuilder.Query = "\u1234";

            Assert.AreEqual("http://localhost/?\u1234", uriBuilder.Uri.ToString());
        }

        [Test]
        public void AppendQueryWithEmptyValueWorks()
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "localhost";
            uriBuilder.Port = 80;
            uriBuilder.AppendQuery("a", null);

            Assert.AreEqual("http://localhost/?a=", uriBuilder.Uri.ToString());
        }

        [TestCase(null, "http://localhost/?a=b&c=d")]
        [TestCase("", "http://localhost/?a=b&c=d")]
        [TestCase("a", "http://localhost/?a&a=b&c=d")]
        [TestCase("?", "http://localhost/?a=b&c=d")]
        [TestCase("?initial", "http://localhost/?initial&a=b&c=d")]
        public void AppendQueryWorks(string initialQuery, string expectedResult)
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "localhost";
            uriBuilder.Port = 80;
            uriBuilder.Query = initialQuery;
            uriBuilder.AppendQuery("a","b");
            uriBuilder.AppendQuery("c","d");

            Assert.AreEqual(expectedResult, uriBuilder.Uri.ToString());
        }

        [TestCase(null, "", "http://localhost/")]
        [TestCase("/", "/", "http://localhost/")]
        [TestCase(null, "p", "http://localhost/p")]
        [TestCase("/", "p", "http://localhost/p")]
        [TestCase("/", "/p", "http://localhost/p")]
        [TestCase("", "\u1234", "http://localhost/%E1%88%B4")]
        public void AppendPathWorks(string initialPath, string append, string expectedResult)
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "localhost";
            uriBuilder.Port = 80;
            uriBuilder.Path = initialPath;
            uriBuilder.AppendPath(append);

            Assert.AreEqual(expectedResult, uriBuilder.Uri.OriginalString);
        }

        [Test]
        public void AppendingQueryResetsUri()
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Uri = new Uri("http://localhost/");
            uriBuilder.AppendQuery("a","b");

            Assert.AreEqual("http://localhost/?a=b", uriBuilder.Uri.ToString());
        }

        [Test]
        public void AppendingPathResetsUri()
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Uri = new Uri("http://localhost/");
            uriBuilder.AppendPath("a");

            Assert.AreEqual("http://localhost/a", uriBuilder.Uri.ToString());
        }

        [Test]
        public void AppendingPathAfterQueryAndSettingTheUriWorks()
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Uri = new Uri("http://localhost/");
            uriBuilder.AppendQuery("query", "value");
            uriBuilder.AppendPath("a");
            uriBuilder.AppendPath("b");
            uriBuilder.AppendQuery("c", "d");

            Assert.AreEqual("http://localhost/ab?query=value&c=d", uriBuilder.Uri.ToString());
        }
    }
}
