// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpClientTransportFunctionalTest : TransportFunctionalTests
    {
        // thumbprint 5A607F7B46D2B56736FE6CFD8AB3D07CCD7EC90C
        private static X509Certificate2 trustedCert = new X509Certificate2(Convert.FromBase64String("MIIBnjCCAQCgAwIBAgIJAO0P3fytvM6TMAoGCCqGSM49BAMCMBExDzANBgNVBAMTBmZvb2JhcjAeFw0yMTA4MTkyMTM3MzlaFw0yNjA4MTkyMTM3MzlaMBExDzANBgNVBAMTBmZvb2JhcjCBmzAQBgcqhkjOPQIBBgUrgQQAIwOBhgAEAGDcpzjt035+jCttrRemUCzxzgN8EKQWLflZKYnmUXplYg9LJFgo9usamIC2DC+VNd99Js1K3nN1/D140LdWokv5Aa6lTyFbDO/2VK/tM88vhVWbRag08+LMzC91DOut0jEyKboI3vpiMuKstKUbj9dJUzpE4mRJzUQ1wte6cafw1i8lMAoGCCqGSM49BAMCA4GLADCBhwJBSHypFfkTyKfES4jvd/mYmJsBGFn+VTlZZVNQjwlbYUyietoG00W/UcOC8wM9tM5P1RfavX/wKw/dM9rHf5lDPg0CQgHfPk9FHtJP58EedwjjSnb9WH9Bj1k7JbcHKNqG5c4v6ZsqWVwViRAa6ivCdi/UxfRF7RwSUgUnjlf9nEbuKHFeGQ=="));
        private const string trustedThumbprint = "5A607F7B46D2B56736FE6CFD8AB3D07CCD7EC90C";

        // thumbprint A32053FADFDCF8F91FC8B51972313B6E0FA1F2F6
        private static X509Certificate2 untrustedCert = new X509Certificate2(Convert.FromBase64String("MIIBnzCCAQCgAwIBAgIJAPsRMV88LfqxMAoGCCqGSM49BAMCMBExDzANBgNVBAMTBmZvb2JhcjAeFw0yMTA4MTkyMTI5NTBaFw0yNjA4MTkyMTI5NTBaMBExDzANBgNVBAMTBmZvb2JhcjCBmzAQBgcqhkjOPQIBBgUrgQQAIwOBhgAEAQ3bebjCd9KAAgaKsUWSHwi+vOiW3PuZHfd5CAp8FOYjunxKDYEZrKrt2JIaA8qV2qHYC8ppmYBcYPp0CzYOM7ZkAP7imTXTR/2oxcwELdfHqIVKSxQ65mncqWclArVMABWFY8E8cj20hb123XAUouZhbtRs/ypXaqgPs9++Fvfufp9tMAoGCCqGSM49BAMCA4GMADCBiAJCAMTPO+MsvYl0EdbUpsyGer1didx/p2EMOLFC2Ylu3rbqviKwrHSsOsgwjeVo0H9D6dsA25VnwfMn28kepYkMlJsaAkIBGmHCEtdeXXbkdkGX2+I0hmDirEg44kcLSxxf6P5yPBOhVskqx9OL7adTMzqsTwAVBA+cVUCX3ab7Ax4Y0jMl9GY="));
        private const string untrustedThumbprint = "A32053FADFDCF8F91FC8B51972313B6E0FA1F2F6";

        static HttpClientTransportFunctionalTest()
        {
            // No way to disable SSL check per HttpClient on NET461
#if NET461
            ServicePointManager.ServerCertificateValidationCallback += (_, _, _, _) => true;
#endif

        }

        public HttpClientTransportFunctionalTest(bool isAsync) : base(isAsync)
        { }

        protected override HttpPipelineTransport GetTransport(bool https = false)
        {
            if (https)
            {
#if !NET461
                return new HttpClientTransport(
                    new HttpClientHandler() { ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator });
#endif
            }
            return new HttpClientTransport();
        }

#if NETCOREAPP
        [Test]
        public void UsesSocketsClientTransportOnNetCoreApp()
        {
            var transport = (HttpClientTransport)GetTransport();
            HttpClient transportClient = transport.Client;
            var handler = (SocketsHttpHandler)GetHandler(transportClient);
            Assert.AreEqual(TimeSpan.FromSeconds(300), handler.PooledConnectionLifetime);
            Assert.GreaterOrEqual(handler.MaxConnectionsPerServer, 50);
        }
#else
        [Test]
        public void UsesHttpClientTransportOnNetStandart()
        {
            var transport = (HttpClientTransport)GetTransport();
            HttpClient transportClient = transport.Client;
            var handler = (HttpClientHandler)GetHandler(transportClient);
            Assert.AreEqual(50, handler.MaxConnectionsPerServer);
        }
#endif

        private static IEnumerable CertOptions = new[]
        {
            new object[] {true, trustedCert, true },
            new object[] {true, trustedCert, false },
            new object[] {true, untrustedCert, true },
            new object[] {true, untrustedCert, false },
            new object[] {false, new X509Certificate2(), true },
            new object[] {false, new X509Certificate2(), false },
        };

        [TestCaseSource(nameof(CertOptions))]
        public void CustomizeTransport(bool setCertCallback, X509Certificate2 certToTrust, bool trustAllCerts)
        {
            HttpClientTransport transport;
            bool certValidationCalled = false;
            HttpClientTransportOptions options;
            bool ValidationResult = false;

            options = new HttpClientTransportOptions { TrustAllServerCertificates = trustAllCerts };

            if (setCertCallback)
            {
                options.ServerCertificateCustomValidationCallback = certificate2 =>
                {
                    certValidationCalled = true;
                    return certificate2.Thumbprint == trustedCert.Thumbprint;
                };
            }

            transport = HttpClientTransport.CreateWithDefaultSettings(options);

            HttpClient transportClient = transport.Client;
            try
            {
#if NETCOREAPP
            var handler = (SocketsHttpHandler)GetHandler(transportClient);
            if (!setCertCallback && !trustAllCerts)
            {
                Assert.IsNull(handler.SslOptions.RemoteCertificateValidationCallback);
                return;
            }
            ValidationResult = handler.SslOptions.RemoteCertificateValidationCallback(this, certToTrust, null, SslPolicyErrors.None);
#else
            var handler = (HttpClientHandler)GetHandler(transportClient);
            if (!setCertCallback && !trustAllCerts)
            {
#if NET461
                Assert.IsNull(handler.ServerCertificateCustomValidationCallback);
#else
                Assert.AreEqual(HttpClientHandler.DangerousAcceptAnyServerCertificateValidator, handler.ServerCertificateCustomValidationCallback);
#endif
                return;
            }
                ValidationResult = handler.ServerCertificateCustomValidationCallback(
                    new HttpRequestMessage(HttpMethod.Get, new Uri("https://w.com")),
                    certToTrust,
                    null,
                    SslPolicyErrors.None);
#endif
            }
            catch (Exception ex) when(ex is not AssertionException)
            {
                if (ex.Message.Contains("OpenSSL") && RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    // expected on Mac
                    return;
                }
                throw;
            }
            if (trustAllCerts)
            {
                Assert.False(certValidationCalled);
                Assert.True(ValidationResult);
            }
            else
            {
                Assert.AreEqual(setCertCallback, certValidationCalled);
                if (certValidationCalled)
                {
                    Assert.AreEqual(ValidationResult, certToTrust.Thumbprint == trustedCert.Thumbprint);
                }
            }
        }

        private static object GetHandler(HttpClient transportClient)
        {
            return typeof(HttpMessageInvoker).GetField("_handler", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(transportClient);
        }
    }
}
