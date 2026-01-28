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

            Assert.That(uriBuilder.Scheme, Is.EqualTo(uri.Scheme));
            Assert.That(uriBuilder.Host, Is.EqualTo(uri.Host));
            Assert.That(uriBuilder.Port, Is.EqualTo(uri.Port));
            Assert.That(uriBuilder.Path, Is.EqualTo(uri.AbsolutePath));
            Assert.That(uriBuilder.Query, Is.EqualTo(uri.Query));
            Assert.That(uriBuilder.ToUri(), Is.EqualTo(uri));
            Assert.That(uriBuilder.ToUri(), Is.SameAs(uri));
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

            Assert.That(uriBuilder.ToUri().ToString(), Is.EqualTo(expected));
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

            Assert.That(uriBuilder.ToUri().ToString(), Is.EqualTo(expected));
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

            Assert.That(uriBuilder.ToUri().ToString(), Is.EqualTo("http://localhost/?a"));

            uriBuilder.Query = query;

            Assert.That(uriBuilder.ToUri().ToString(), Is.EqualTo("http://localhost/"));
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

            Assert.That(uriBuilder.ToUri().OriginalString, Is.EqualTo("http://localhost/" + path));
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

            Assert.That(uriBuilder.ToUri().OriginalString, Is.EqualTo("http://localhost/" + expected));
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

            Assert.That(uriBuilder.ToUri().ToString(), Is.EqualTo("http://localhost/?\u1234"));
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

            Assert.That(uriBuilder.ToUri().ToString(), Is.EqualTo("http://localhost/?a="));
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

            Assert.That(uriBuilder.ToUri().ToString(), Is.EqualTo(expectedResult));
        }

        [TestCase(null, new[] { "" }, "q", "http://localhost/?q")]
        [TestCase("/", new[] { "/" }, "q", "http://localhost/?q")]
        [TestCase(null, new[] { "p" }, "q", "http://localhost/p?q")]
        [TestCase("/", new[] { "p" }, "q", "http://localhost/p?q")]
        [TestCase("/", new[] { "ā", "p" }, "q", "http://localhost/%C4%81p?q", true)]
        [TestCase("/", new[] { "ā", "p" }, "q", "http://localhost/āp?q", false)]
        [TestCase("/", new[] { "/p" }, "q", "http://localhost/p?q")]
        [TestCase("", new[] { "\u1234" }, "q", "http://localhost/\u1234?q", false)]
        [TestCase("", new[] { "%E1%88%B4" }, "q", "http://localhost/%E1%88%B4?q", false)]
        [TestCase("", new[] { "\u1234" }, "q", "http://localhost/%E1%88%B4?q", true)]
        [TestCase("", new[] { "%E1%88%B4" }, "q", "http://localhost/%25E1%2588%25B4?q", true)]
        [TestCase(null, new[] { "" }, "", "http://localhost/")]
        [TestCase("/", new[] { "/" }, "", "http://localhost/")]
        [TestCase(null, new[] { "p" }, "", "http://localhost/p")]
        [TestCase("/", new[] { "p" }, "", "http://localhost/p")]
        [TestCase("/", new[] { "ā", "p" }, "", "http://localhost/%C4%81p", true)]
        [TestCase("/", new[] { "ā", "p" }, "", "http://localhost/āp", false)]
        [TestCase("/", new[] { "/p" }, "", "http://localhost/p")]
        [TestCase("", new[] { "\u1234" }, "", "http://localhost/\u1234", false)]
        [TestCase("", new[] { "%E1%88%B4" }, "", "http://localhost/%E1%88%B4", false)]
        [TestCase("", new[] { "\u1234" }, "", "http://localhost/%E1%88%B4", true)]
        [TestCase("", new[] { "%E1%88%B4" }, "", "http://localhost/%25E1%2588%25B4", true)]
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

            Assert.That(uriBuilder.ToUri().OriginalString, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AppendingQueryResetsUri()
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(new Uri("http://localhost/"));
            uriBuilder.AppendQuery("a", "b");

            Assert.That(uriBuilder.ToUri().ToString(), Is.EqualTo("http://localhost/?a=b"));
        }

        [Test]
        public void AppendingPathResetsUri()
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(new Uri("http://localhost/"));
            uriBuilder.AppendPath("a");

            Assert.That(uriBuilder.ToUri().ToString(), Is.EqualTo("http://localhost/a"));
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

            Assert.That(uriBuilder.ToUri().ToString(), Is.EqualTo("http://localhost/ab?query=value&c=d"));
        }

        [Test]
        public void AppendingPathWithSpecialCharacters()
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(new Uri("http://localhost/"));
            uriBuilder.AppendPath("/");
            uriBuilder.AppendPath("~!@#$%^&*()_+");
            uriBuilder.AppendPath("b/");

            Assert.That(uriBuilder.ToString(), Is.EqualTo("http://localhost/~%21%40%23%24%25%5E%26%2A%28%29_%2Bb%2F"));
#if NETCOREAPP
            Assert.That(uriBuilder.ToUri().ToString(), Is.EqualTo("http://localhost/~%21%40%23%24%25^%26%2A%28%29_%2Bb%2F"));
#else
            Assert.That(uriBuilder.ToUri().ToString(), Is.EqualTo("http://localhost/~!%40%23%24%25^%26*()_%2Bb%2F"));
#endif
        }

        [Test]
        public void AppendingQueryWithSpecialCharacters()
        {
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(new Uri("http://localhost/"));
            uriBuilder.AppendQuery("a", "~!@#$%^&*()_+");

            Assert.That(uriBuilder.ToString(), Is.EqualTo("http://localhost/?a=~%21%40%23%24%25%5E%26%2A%28%29_%2B"));
#if NETCOREAPP
            Assert.That(uriBuilder.ToUri().ToString(), Is.EqualTo("http://localhost/?a=~%21%40%23%24%25^%26%2A%28%29_%2B"));
#else
            Assert.That(uriBuilder.ToUri().ToString(), Is.EqualTo("http://localhost/?a=~!%40%23%24%25^%26*()_%2B"));
#endif
        }
    }
}
