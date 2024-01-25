// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RawRequestUriBuilderTest
    {
        [Theory]
        [TestCase("ht|tp|://", "localhost", null, "http://localhost/")]
        [TestCase("http://|local|host", null, null, "http://localhost/")]
        [TestCase("https://|local|host", null, null, "https://localhost/")]
        [TestCase("http://|local|host", "override", null, "http://override/")]
        [TestCase("http://|local|host|:12345", null, null, "http://localhost:12345/")]
        [TestCase("http://|local|host:12345", null, null, "http://localhost:12345/")]
        [TestCase("http://localhost/with|some|path", null, "/andMore", "http://localhost/withsomepath/andMore")]
        [TestCase("http://localhost:12345/with|some|path", null, "/andMore", "http://localhost:12345/withsomepath/andMore")]
        [TestCase("http://localhost|:12345/with|some|path", null, "/andMore", "http://localhost:12345/withsomepath/andMore")]
        [TestCase("http://|localhost:12345|/with|some|path", null, "/andMore", "http://localhost:12345/withsomepath/andMore")]
        [TestCase("http://|localhost:12345|withsomepath", null, "/andMore/", "http://localhost:12345/withsomepath/andMore/")]
        [TestCase("http://|localhost:12345/|withsomepath", null, "/andMore/", "http://localhost:12345/withsomepath/andMore/")]
        [TestCase("http://localhost|/more|/andMore|/evenMore", null, null, "http://localhost/more/andMore/evenMore")]
        [TestCase("http://localhost|/more/andMore|/evenMore/", null, null, "http://localhost/more/andMore/evenMore/")]
        [TestCase("http://|localhost:12345|/more/andMore|/evenMore/", null, null, "http://localhost:12345/more/andMore/evenMore/")]
        [TestCase("http://localhost|/more|/andMore|?one=1", null, null, "http://localhost/more/andMore?one=1")]
        [TestCase("http://localhost|/more|/andMore?one=1", null, null, "http://localhost/more/andMore?one=1")]
        [TestCase("http://localhost/|more?one=1", null, null, "http://localhost/more?one=1")]
        [TestCase("http://localhost|/more?one=1", null, "/andMore", "http://localhost/more/andMore?one=1")]
        [TestCase("http://localhost|/more?one=1|&two=2|&three=3", null, null, "http://localhost/more?one=1&two=2&three=3")]
        [TestCase("http://localhost/more?one=1&two=2|&three=3", null, null, "http://localhost/more?one=1&two=2&three=3")]
        [TestCase("http://localhost/more|?one=1&two=2|&three=3", null, null, "http://localhost/more?one=1&two=2&three=3")]
        [TestCase("http://localhost/more|?one=1|&two=2&three=3", null, null, "http://localhost/more?one=1&two=2&three=3")]
        [TestCase("http://localhost|/more?one=1&two=2&three=3", null, null, "http://localhost/more?one=1&two=2&three=3")]
        [TestCase("http://|localhost:12345|/more|?one=1|&two=2|&three=3", null, null, "http://localhost:12345/more?one=1&two=2&three=3")]
        [TestCase("http://|localhost|:12345|/more|?one=1|&two=2|&three=3", null, null, "http://localhost:12345/more?one=1&two=2&three=3")]
        [TestCase("http://localhost|/more?one=&two=&three=", null, null, "http://localhost/more?one=&two=&three=")]
        [TestCase("http://localhost|/more?one&two&three", null, null, "http://localhost/more?one=&two=&three=")]
        [TestCase("http://localhost|/more?one&&&&&&&three", null, null, "http://localhost/more?one=&three=")]
        public void AppendRawWorks(string rawPart, string host, string pathPart, string expected)
        {
            var builder = new RawRequestUriBuilder();
            foreach (var c in rawPart.Split('|'))
            {
                builder.AppendRaw(c, false);
            }

            if (host != null)
            {
                builder.Host = host;
            }

            if (pathPart != null)
            {
                builder.AppendPath(pathPart, false);
            }

            Assert.AreEqual(expected, builder.ToUri().ToString());
        }

        [Theory]
        [TestCase("http://localhost:12345", "/more/", "andMore", "http://localhost:12345/more/andMore")]
        [TestCase("http://localhost", "/more/", "andMore", "http://localhost/more/andMore")]
        [TestCase("http://localhost", "/more/", "andMore?one=1", "http://localhost/more/andMore?one=1")]
        [TestCase("http://localhost", "/more/", "andMore|?one=1", "http://localhost/more/andMore?one=1")]
        [TestCase("http://localhost", "/more/", "andMore|?one=1&two=2", "http://localhost/more/andMore?one=1&two=2")]
        [TestCase("http://localhost", "/more/", "andMore|?one=1|&two=2", "http://localhost/more/andMore?one=1&two=2")]
        [TestCase("http://localhost", "/more/", "andMore?one=1|&two=2", "http://localhost/more/andMore?one=1&two=2")]
        [TestCase("http://localhost/", "more/|andMore", "?one=1", "http://localhost/more/andMore?one=1")]
        [TestCase("http://local|host/", "more/|andMore", "?one=1", "http://localhost/more/andMore?one=1")]
        [TestCase("http://localhost|/", "more/|andMore", "?one=1", "http://localhost/more/andMore?one=1")]
        [TestCase("http://localhost", "more|/|andMore|/", "evenMore?one=1", "http://localhost/more/andMore/evenMore?one=1")]
        [TestCase("http://localhost/|more|/", "andMore|/", "evenMore|/|most", "http://localhost/more/andMore/evenMore/most")]
        public void AppendRawThenPathThenRaw(string rawPartBefore, string pathPart, string rawPartAfter, string expected)
        {
            var builder = new RawRequestUriBuilder();
            foreach (var c in rawPartBefore.Split('|'))
            {
                builder.AppendRaw(c, false);
            }

            foreach (var c in pathPart.Split('|'))
            {
                builder.AppendPath(c, false);
            }

            foreach (var c in rawPartAfter.Split('|'))
            {
                builder.AppendRaw(c, false);
            }

            Assert.AreEqual(expected, builder.ToUri().ToString());
        }

        [Theory]
        [TestCase("http://localhost/", "one", "1", "more?two=2", "http://localhost/more?one=1&two=2")]
        [TestCase("http://localhost:12345/", "one", "1", "more?two=2", "http://localhost:12345/more?one=1&two=2")]
        [TestCase("http://localhost/more/", "one", "1", "andMore?two=2", "http://localhost/more/andMore?one=1&two=2")]
        [TestCase("http://localhost/more", "one", "1", "/andMore?two=2", "http://localhost/more/andMore?one=1&two=2")]
        [TestCase("http://localhost", "one", "1", "/more?two=2", "http://localhost/more?one=1&two=2")]
        [TestCase("http://localhost:12345", "one", "1", "/more?two=2", "http://localhost:12345/more?one=1&two=2")]
        [TestCase("http://localhost", "one", "1", "/more|/andMore?two=2", "http://localhost/more/andMore?one=1&two=2")]
        [TestCase("http://localhost|/more", "one", "1", "/andMore?two=2", "http://localhost/more/andMore?one=1&two=2")]
        [TestCase("http://localhost|/|more", "one", "1", "/|andMore?two=2", "http://localhost/more/andMore?one=1&two=2")]
        [TestCase("http://localhost|/", "one", "1", "more|/|andMore?two=2", "http://localhost/more/andMore?one=1&two=2")]
        [TestCase("http://localhost/", "one", "1", "more/|andMore?two=2|&three=3", "http://localhost/more/andMore?one=1&two=2&three=3")]
        [TestCase("http://localhost:12345/", "one", "1", "more/|andMore?two=2|&three=3", "http://localhost:12345/more/andMore?one=1&two=2&three=3")]
        public void AppendRawThenQueryThenRaw(string rawPartBefore, string queryName, string queryValue, string rawPartAfter, string expected)
        {
            var builder = new RawRequestUriBuilder();
            foreach (var c in rawPartBefore.Split('|'))
            {
                builder.AppendRaw(c, false);
            }

            builder.AppendQuery(queryName, queryValue);

            foreach (var c in rawPartAfter.Split('|'))
            {
                builder.AppendRaw(c, false);
            }

            Assert.AreEqual(expected, builder.ToUri().ToString());
        }

        [Theory]
        [TestCase(long.MinValue)]
        [TestCase(0L)]
        [TestCase(long.MaxValue)]
        public void AppendPathTypeLong(long longPathPart)
        {
            const string Endpoint = "http://localhost:12345/getByLong/";

            var builder = new RawRequestUriBuilder();
            builder.AppendRaw(Endpoint, false);
            builder.AppendPath(longPathPart, true);

            Assert.AreEqual($"{Endpoint}{longPathPart:G}", builder.ToUri().ToString());
        }
    }
}
