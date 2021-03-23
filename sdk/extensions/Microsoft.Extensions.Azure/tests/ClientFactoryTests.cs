// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Azure.Identity;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Core.Extensions.Tests
{
    public class ClientFactoryTests
    {
        [Test]
        public void SelectsConstructorBaseOnConfiguration()
        {
            IConfiguration configuration = GetConfiguration(new KeyValuePair<string, string>("connectionstring", "CS"));

            var clientOptions = new TestClientOptions();
            var client = (TestClient)ClientFactory.CreateClient(typeof(TestClient), typeof(TestClientOptions), clientOptions, configuration, null);

            Assert.AreEqual("CS", client.ConnectionString);
            Assert.AreSame(clientOptions, client.Options);
        }

        [Test]
        public void ConvertsUriConstructorParameters()
        {
            IConfiguration configuration = GetConfiguration(new KeyValuePair<string, string>("uri", "http://localhost"));

            var clientOptions = new TestClientOptions();
            var client = (TestClient)ClientFactory.CreateClient(typeof(TestClient), typeof(TestClientOptions), clientOptions, configuration, null);

            Assert.AreEqual("http://localhost/", client.Uri.ToString());
            Assert.AreSame(clientOptions, client.Options);
        }

        [Test]
        public void ConvertsCompositeObjectsConstructorParameters()
        {
            IConfiguration configuration = GetConfiguration(new KeyValuePair<string, string>("composite:c", "http://localhost"));

            var clientOptions = new TestClientOptions();
            var client = (TestClient)ClientFactory.CreateClient(typeof(TestClient), typeof(TestClientOptions), clientOptions, configuration, null);

            Assert.AreEqual("http://localhost/", client.Composite.C.ToString());
            Assert.AreSame(clientOptions, client.Options);
        }

        [Test]
        public void ConvertsCompositeObjectsConstructorParameters2()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("composite:a", "a"),
                new KeyValuePair<string, string>("composite:b", "b"));

            var clientOptions = new TestClientOptions();
            var client = (TestClient)ClientFactory.CreateClient(typeof(TestClient), typeof(TestClientOptions), clientOptions, configuration, null);

            Assert.AreEqual("a", client.Composite.A);
            Assert.AreEqual("b", client.Composite.B);
            Assert.AreSame(clientOptions, client.Options);
        }

        [Test]
        public void UsesLongestConstructor()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("composite:c", "http://localhost"),
                new KeyValuePair<string, string>("uri", "http://otherhost")
                );

            var clientOptions = new TestClientOptions();
            var client = (TestClient)ClientFactory.CreateClient(typeof(TestClient), typeof(TestClientOptions), clientOptions, configuration, null);

            Assert.AreEqual("http://localhost/", client.Composite.C.ToString());
            Assert.AreEqual("http://otherhost/", client.Uri.ToString());
            Assert.AreSame(clientOptions, client.Options);
        }

        [Test]
        public void ThrowsWhenUnableToReadCompositeObject()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("composite:non-existent", "_"));

            var clientOptions = new TestClientOptions();
            var exception = Assert.Throws<InvalidOperationException>(() => ClientFactory.CreateClient(typeof(TestClient), typeof(TestClientOptions), clientOptions, configuration, null));
            Assert.AreEqual("Unable to convert section 'composite' to parameter type 'Azure.Core.Extensions.Tests.TestClient+CompositeObject', unable to find matching constructor.", exception.Message);
        }

        [Test]
        public void ThrowsExceptionWithInformationAboutArguments()
        {
            IConfiguration configuration = GetConfiguration();

            var clientOptions = new TestClientOptions();
            var exception = Assert.Throws<InvalidOperationException>(() => ClientFactory.CreateClient(typeof(TestClient), typeof(TestClientOptions), clientOptions, configuration, null));
            Assert.AreEqual("Unable to find matching constructor. Define one of the follow sets of configuration parameters:" + Environment.NewLine +
                "1. connectionString" + Environment.NewLine +
                "2. uri" + Environment.NewLine +
                "3. uri, composite" + Environment.NewLine +
                "4. composite" + Environment.NewLine,
                exception.Message);
        }

        [Theory]
        [TestCase("currentUser", StoreLocation.CurrentUser, "my", StoreName.My)]
        [TestCase("localMachine", StoreLocation.LocalMachine, "root", StoreName.Root)]
        [TestCase(null, StoreLocation.CurrentUser, null, StoreName.My)]
        public void CreatesCertificateCredentials(string storeLocation, StoreLocation expectedStore, string storeName, StoreName expectedName)
        {
            var localCert = new X509Store(expectedName, expectedStore);
            localCert.Open(OpenFlags.ReadOnly);
            var someLocalCert = localCert.Certificates[0].Thumbprint;
            localCert.Close();

            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("clientId", "ConfigurationClientId"),
                new KeyValuePair<string, string>("clientCertificate", someLocalCert),
                new KeyValuePair<string, string>("clientCertificateStoreLocation", storeLocation),
                new KeyValuePair<string, string>("clientCertificateStoreName", storeName),
                new KeyValuePair<string, string>("tenantId", "ConfigurationTenantId")
            );

            var credential = ClientFactory.CreateCredential(configuration);

            Assert.IsInstanceOf<ClientCertificateCredential>(credential);
            var clientCertificateCredential = (ClientCertificateCredential)credential;

            Assert.AreEqual("ConfigurationClientId", clientCertificateCredential.ClientId);
            // TODO: Reenable when Azure.Identity version is updated
            // Assert.AreEqual(someLocalCert, clientCertificateCredential.ClientCertificate.Thumbprint);
            Assert.AreEqual("ConfigurationTenantId", clientCertificateCredential.TenantId);
        }

        [Test]
        public void CreatesClientSecretCredentials()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("clientId", "ConfigurationClientId"),
                new KeyValuePair<string, string>("clientSecret", "ConfigurationClientSecret"),
                new KeyValuePair<string, string>("tenantId", "ConfigurationTenantId")
            );

            var credential = ClientFactory.CreateCredential(configuration);

            Assert.IsInstanceOf<ClientSecretCredential>(credential);
            var clientSecretCredential = (ClientSecretCredential)credential;

            Assert.AreEqual("ConfigurationClientId", clientSecretCredential.ClientId);
            Assert.AreEqual("ConfigurationClientSecret", clientSecretCredential.ClientSecret);
            Assert.AreEqual("ConfigurationTenantId", clientSecretCredential.TenantId);
        }

        [Test]
        public void CreatesManagedServiceIdentityCredentialsWithClientId()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("clientId", "ConfigurationClientId"),
                new KeyValuePair<string, string>("credential", "managedidentity")
            );

            var credential = ClientFactory.CreateCredential(configuration);

            Assert.IsInstanceOf<ManagedIdentityCredential>(credential);
            var managedIdentityCredential = (ManagedIdentityCredential)credential;

            var client = (ManagedIdentityClient)typeof(ManagedIdentityCredential).GetField("_client", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(managedIdentityCredential);
            var clientId = typeof(ManagedIdentityClient).GetProperty("ClientId", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(client);

            Assert.AreEqual("ConfigurationClientId", clientId);
        }

        [Test]
        public void CreatesManagedServiceIdentityCredentials()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("credential", "managedidentity")
            );

            var credential = ClientFactory.CreateCredential(configuration);

            Assert.IsInstanceOf<ManagedIdentityCredential>(credential);
            var managedIdentityCredential = (ManagedIdentityCredential)credential;

            var client = (ManagedIdentityClient)typeof(ManagedIdentityCredential).GetField("_client", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(managedIdentityCredential);
            var clientId = typeof(ManagedIdentityClient).GetProperty("ClientId", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(client);

            Assert.Null(clientId);
        }

        [Test]
        public void IgnoresConstructorWhenCredentialsNull()
        {
            IConfiguration configuration = GetConfiguration(new KeyValuePair<string, string>("uri", "http://localhost"));

            var clientOptions = new TestClientOptions();
            var client = (TestClientWithCredentials)ClientFactory.CreateClient(typeof(TestClientWithCredentials), typeof(TestClientOptions), clientOptions, configuration, null);

            Assert.AreEqual("http://localhost/", client.Uri.ToString());
            Assert.AreSame(clientOptions, client.Options);
        }

        private IConfiguration GetConfiguration(params KeyValuePair<string, string>[] items)
        {
            return new ConfigurationBuilder().AddInMemoryCollection(items).Build();
        }
    }
}
