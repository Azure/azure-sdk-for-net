// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Adapted from https://raw.githubusercontent.com/dotnet/corefx/master/src/System.Net.Http/src/System/Net/Http/SocketsHttpHandler/HttpEnvironmentProxy.cs

using System.Collections.Generic;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace System.Net.Http.Tests
{
    [NonParallelizable]
    public class HttpEnvironmentProxyTest
    {
        private static readonly Uri s_fooHttp = new Uri("http://foo.com");
        private static readonly Uri s_fooHttps = new Uri("https://foo.com");

        // This will clean specific environmental variables
        // to be sure they do not interfere with the test.
        [TearDown]
        [SetUp]
        public static void CleanEnv()
        {
            var envVars = new List<string>() { "http_proxy", "HTTP_PROXY",
                                               "https_proxy", "HTTPS_PROXY",
                                               "all_proxy", "ALL_PROXY",
                                               "no_proxy", "NO_PROXY",
                                               "GATEWAY_INTERFACE" };

            foreach (string v in envVars)
            {
                Environment.SetEnvironmentVariable(v, null);
            }
        }

        [Test]
        public void HttpProxy_EnvironmentProxy_Loaded()
        {
            Uri u;

            // It should not return object if there are no variables set.
            Assert.That(HttpEnvironmentProxy.TryCreate(out IWebProxy p), Is.False);

            Environment.SetEnvironmentVariable("all_proxy", "http://1.1.1.1:3000");
            Assert.That(HttpEnvironmentProxy.TryCreate(out p), Is.True);
            Assert.That(p, Is.Not.Null);
            Assert.That(p.Credentials, Is.Null);

            u = p.GetProxy(s_fooHttp);
            Assert.That(u != null && u.Host == "1.1.1.1", Is.True);
            u = p.GetProxy(s_fooHttps);
            Assert.That(u != null && u.Host == "1.1.1.1", Is.True);

            Environment.SetEnvironmentVariable("http_proxy", "http://1.1.1.2:3001");
            Assert.That(HttpEnvironmentProxy.TryCreate(out p), Is.True);
            Assert.That(p, Is.Not.Null);

            // Protocol specific variables should take precedence over all_
            // and https should still use all_proxy.
            u = p.GetProxy(s_fooHttp);
            Assert.That(u != null && u.Host == "1.1.1.2" && u.Port == 3001, Is.True);
            u = p.GetProxy(s_fooHttps);
            Assert.That(u != null && u.Host == "1.1.1.1" && u.Port == 3000, Is.True);

            // Set https to invalid strings and use only IP & port for http.
            Environment.SetEnvironmentVariable("http_proxy", "1.1.1.3:3003");
            Environment.SetEnvironmentVariable("https_proxy", "ab!cd");
            Assert.That(HttpEnvironmentProxy.TryCreate(out p), Is.True);
            Assert.That(p, Is.Not.Null);

            u = p.GetProxy(s_fooHttp);
            Assert.That(u != null && u.Host == "1.1.1.3" && u.Port == 3003, Is.True);
            u = p.GetProxy(s_fooHttps);
            Assert.That(u != null && u.Host == "1.1.1.1" && u.Port == 3000, Is.True);

            // Try valid URI with unsupported protocol. It will be ignored
            // to mimic curl behavior.
            Environment.SetEnvironmentVariable("https_proxy", "socks5://1.1.1.4:3004");
            Assert.That(HttpEnvironmentProxy.TryCreate(out p), Is.True);
            Assert.That(p, Is.Not.Null);
            u = p.GetProxy(s_fooHttps);
            Assert.That(u != null && u.Host == "1.1.1.1" && u.Port == 3000, Is.True);

            // Set https to valid URI but different from http.
            Environment.SetEnvironmentVariable("https_proxy", "http://1.1.1.5:3005");
            Assert.That(HttpEnvironmentProxy.TryCreate(out p), Is.True);
            Assert.That(p, Is.Not.Null);

            u = p.GetProxy(s_fooHttp);
            Assert.That(u != null && u.Host == "1.1.1.3" && u.Port == 3003, Is.True);
            u = p.GetProxy(s_fooHttps);
            Assert.That(u != null && u.Host == "1.1.1.5" && u.Port == 3005, Is.True);
        }

        [Theory]
        [TestCase("1.1.1.5", "1.1.1.5", "80", null, null)]
        [TestCase("http://1.1.1.5:3005", "1.1.1.5", "3005", null, null)]
        [TestCase("http://foo@1.1.1.5", "1.1.1.5", "80", "foo", "")]
        [TestCase("http://[::1]:80", "[::1]", "80", null, null)]
        [TestCase("foo:bar@[::1]:3128", "[::1]", "3128", "foo", "bar")]
        [TestCase("foo:Pass$!#\\.$@127.0.0.1:3128", "127.0.0.1", "3128", "foo", "Pass$!#\\.$")]
        [TestCase("[::1]", "[::1]", "80", null, null)]
        [TestCase("domain\\foo:bar@1.1.1.1", "1.1.1.1", "80", "foo", "bar")]
        // cspell:disable-next-line
        [TestCase("domain%5Cfoo:bar@1.1.1.1", "1.1.1.1", "80", "foo", "bar")]
        [TestCase("HTTP://ABC.COM/", "abc.com", "80", null, null)]
        [TestCase("http://10.30.62.64:7890/", "10.30.62.64", "7890", null, null)]
        [TestCase("http://1.2.3.4:8888/foo", "1.2.3.4", "8888", null, null)]
        public void HttpProxy_Uri_Parsing(string input, string host, string port, string user, string password)
        {
            Environment.SetEnvironmentVariable("all_proxy", input);
            Uri u;

            Assert.That(HttpEnvironmentProxy.TryCreate(out IWebProxy p), Is.True);
            Assert.That(p, Is.Not.Null);

            u = p.GetProxy(s_fooHttp);
            Assert.That(u.Host, Is.EqualTo(host));
            Assert.That(u.Port, Is.EqualTo(Convert.ToInt32(port)));

            if (user != null)
            {
                NetworkCredential nc = p.Credentials.GetCredential(u, "Basic");
                Assert.That(nc, Is.Not.Null);
                Assert.That(nc.UserName, Is.EqualTo(user));
                Assert.That(nc.Password, Is.EqualTo(password));
            }
        }

        [Test]
        public void HttpProxy_CredentialParsing_Basic()
        {
            Environment.SetEnvironmentVariable("all_proxy", "http://foo:pwd1@1.1.1.1:3000");
            Assert.That(HttpEnvironmentProxy.TryCreate(out IWebProxy p), Is.True);
            Assert.That(p, Is.Not.Null);
            Assert.That(p.Credentials, Is.Not.Null);

            // Use user only without password.
            Environment.SetEnvironmentVariable("all_proxy", "http://foo@1.1.1.1:3000");
            Assert.That(HttpEnvironmentProxy.TryCreate(out p), Is.True);
            Assert.That(p, Is.Not.Null);
            Assert.That(p.Credentials, Is.Not.Null);

            // Use different user for http and https
            Environment.SetEnvironmentVariable("https_proxy", "http://foo1:pwd2@1.1.1.1:3000");
            Assert.That(HttpEnvironmentProxy.TryCreate(out p), Is.True);
            Assert.That(p, Is.Not.Null);
            Uri u = p.GetProxy(s_fooHttp);
            Assert.That(p.Credentials.GetCredential(u, "Basic"), Is.Not.Null);
            u = p.GetProxy(s_fooHttps);
            Assert.That(p.Credentials.GetCredential(u, "Basic"), Is.Not.Null);
            // This should not match Proxy Uri
            Assert.That(p.Credentials.GetCredential(s_fooHttp, "Basic"), Is.Null);
            Assert.That(p.Credentials.GetCredential(null, null), Is.Null);
        }

        [Test]
        public void HttpProxy_Exceptions_Match()
        {
            Environment.SetEnvironmentVariable("no_proxy", ".test.com,, foo.com");
            Environment.SetEnvironmentVariable("all_proxy", "http://foo:pwd1@1.1.1.1:3000");
            Assert.That(HttpEnvironmentProxy.TryCreate(out IWebProxy p), Is.True);
            Assert.That(p, Is.Not.Null);

            Assert.That(p.IsBypassed(s_fooHttp), Is.True);
            Assert.That(p.IsBypassed(s_fooHttps), Is.True);
            Assert.That(p.IsBypassed(new Uri("http://test.com")), Is.True);
            Assert.That(p.IsBypassed(new Uri("http://1test.com")), Is.False);
            Assert.That(p.IsBypassed(new Uri("http://www.test.com")), Is.True);
        }

        public static IEnumerable<object[]> HttpProxyNoProxyEnvVarMemberData()
        {
            yield return new object[] { "http_proxy", "no_proxy" };
            yield return new object[] { "http_proxy", "NO_PROXY" };
            yield return new object[] { "HTTP_PROXY", "no_proxy" };
            yield return new object[] { "HTTP_PROXY", "NO_PROXY" };
        }

        [Theory]
        [TestCaseSource(nameof(HttpProxyNoProxyEnvVarMemberData))]
        public void HttpProxy_TryCreate_CaseInsensitiveVariables(string proxyEnvVar, string noProxyEnvVar)
        {
            string proxy = "http://foo:pwd1@1.1.1.1:3000";

            Environment.SetEnvironmentVariable(proxyEnvVar, proxy);
            Environment.SetEnvironmentVariable(noProxyEnvVar, ".test.com, foo.com");

            var directUri = new Uri("http://test.com");
            var thruProxyUri = new Uri("http://atest.com");

            Assert.That(HttpEnvironmentProxy.TryCreate(out IWebProxy p), Is.True);
            Assert.That(p, Is.Not.Null);

            Assert.That(p.IsBypassed(directUri), Is.True);
            Assert.That(p.IsBypassed(thruProxyUri), Is.False);
            Assert.That(p.GetProxy(thruProxyUri), Is.EqualTo(new Uri(proxy)));
        }
    }
}
