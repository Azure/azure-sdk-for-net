// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
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
            new Uri("http://localhost:80/ prefix"),
            new Uri("http://localhost:80/%25"),
            new Uri("http://localhost:80/~!@#$%^&*()_+=-"),
            new Uri("http://localhost:80/" + Uri.EscapeDataString("~!@#$%^&*()_+=-")),
            new UriBuilder(new Uri("http://localhost:80/"))
            {
                Path = "~!@#$%^&*()_+=-"
            }.Uri
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

        [TestCase("\u1234\u2345")]
        [TestCase("\u1234")]
        [TestCase("\u1234\u2345")]
        [TestCase(" ")]
        [TestCase("%#?&")]
        public void PathIsNotEscaped(string path)
        {
            var uriBuilder = new RequestUriBuilder
            {
                Scheme = "http",
                Host = "localhost",
                Port = 80,
                Path = path
            };

            Assert.AreEqual("http://localhost/" + path, uriBuilder.ToUri().OriginalString);
        }

        [TestCase("\u1234\u2345", "%E1%88%B4%E2%8D%85")]
        [TestCase("\u1234", "%E1%88%B4")]
        [TestCase("\u1234\u2345", "%E1%88%B4%E2%8D%85")]
        [TestCase(" ", "%20")]
        [TestCase("%#?&", "%25%23%3F%26")]
        public void PathIsEscaped(string path, string expected)
        {
            var uriBuilder = new RequestUriBuilder
            {
                Scheme = "http",
                Host = "localhost",
                Port = 80
            };

            uriBuilder.AppendPath(path);

            Assert.AreEqual("http://localhost/" + expected, uriBuilder.ToUri().OriginalString);
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

        [TestCase(null, new[] {""}, "q", "http://localhost/?q")]
        [TestCase("/", new[] {"/"}, "q", "http://localhost/?q")]
        [TestCase(null, new[] {"p"}, "q", "http://localhost/p?q")]
        [TestCase("/", new[] {"p"}, "q", "http://localhost/p?q")]
        [TestCase("/", new[] {"ā","p"}, "q", "http://localhost/%C4%81p?q", true)]
        [TestCase("/", new[] {"ā","p"}, "q", "http://localhost/āp?q", false)]
        [TestCase("/", new[] {"/p"}, "q", "http://localhost/p?q")]
        [TestCase("", new[] {"\u1234"}, "q", "http://localhost/\u1234?q", false)]
        [TestCase("", new[] {"%E1%88%B4"}, "q", "http://localhost/%E1%88%B4?q", false)]
        [TestCase("", new[] {"\u1234"}, "q", "http://localhost/%E1%88%B4?q", true)]
        [TestCase("", new[] {"%E1%88%B4"}, "q", "http://localhost/%25E1%2588%25B4?q", true)]
        [TestCase(null, new[] {""}, "", "http://localhost/")]
        [TestCase("/", new[] {"/"}, "", "http://localhost/")]
        [TestCase(null, new[] {"p"}, "", "http://localhost/p")]
        [TestCase("/", new[] {"p"}, "", "http://localhost/p")]
        [TestCase("/", new[] {"ā","p"}, "", "http://localhost/%C4%81p", true)]
        [TestCase("/", new[] {"ā","p"}, "", "http://localhost/āp", false)]
        [TestCase("/", new[] {"/p"}, "", "http://localhost/p")]
        [TestCase("", new[] {"\u1234"}, "", "http://localhost/\u1234", false)]
        [TestCase("", new[] {"%E1%88%B4"}, "", "http://localhost/%E1%88%B4", false)]
        [TestCase("", new[] {"\u1234"}, "", "http://localhost/%E1%88%B4", true)]
        [TestCase("", new[] {"%E1%88%B4"}, "", "http://localhost/%25E1%2588%25B4", true)]
        public void AppendPathWorks(string initialPath, string[] appends, string initialQuery, string expectedResult, bool escape = false)
        {
            var uriBuilder = new RequestUriBuilder
            {
                Scheme = "http",
                Host = "localhost",
                Port = 80,
                Path = initialPath,
                Query = initialQuery
            };

            foreach (var append in appends)
            {
                uriBuilder.AppendPath(append, escape);
            }

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

        [Test]
        public void AppendingPathWithSpecialCharacters()
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(new Uri("http://localhost/"));
            uriBuilder.AppendPath("/");
            uriBuilder.AppendPath("~!@#$%^&*()_+");
            uriBuilder.AppendPath("b/");

            Assert.AreEqual("http://localhost/~%21%40%23%24%25%5E%26%2A%28%29_%2Bb%2F", uriBuilder.ToString());
#if NETCOREAPP
            Assert.AreEqual("http://localhost/~%21%40%23%24%25^%26%2A%28%29_%2Bb%2F", uriBuilder.ToUri().ToString());
#else
            Assert.AreEqual("http://localhost/~!%40%23%24%25^%26*()_%2Bb%2F", uriBuilder.ToUri().ToString());
#endif
        }

        [Test]
        public void AppendingQueryWithSpecialCharacters()
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(new Uri("http://localhost/"));
            uriBuilder.AppendQuery("a", "~!@#$%^&*()_+");

            Assert.AreEqual("http://localhost/?a=~%21%40%23%24%25%5E%26%2A%28%29_%2B", uriBuilder.ToString());
#if NETCOREAPP
            Assert.AreEqual("http://localhost/?a=~%21%40%23%24%25^%26%2A%28%29_%2B", uriBuilder.ToUri().ToString());
#else
            Assert.AreEqual("http://localhost/?a=~!%40%23%24%25^%26*()_%2B", uriBuilder.ToUri().ToString());
#endif
        }
    }
}
