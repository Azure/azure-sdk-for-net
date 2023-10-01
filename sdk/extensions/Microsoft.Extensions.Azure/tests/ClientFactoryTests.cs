// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
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
        public void ConvertsGuidConstructorParameters()
        {
            var guidValue = Guid.NewGuid().ToString();
            IConfiguration configuration = GetConfiguration(new KeyValuePair<string, string>("guid", guidValue));

            var clientOptions = new TestClientOptions();
            var client = (TestClient)ClientFactory.CreateClient(typeof(TestClient), typeof(TestClientOptions), clientOptions, configuration, null);

            Assert.AreEqual(guidValue, client.Guid.ToString());
            Assert.AreSame(clientOptions, client.Options);
        }

        [Test]
        public void FailsToConvertInvalidUriConfiguration()
        {
            IConfiguration configuration = GetConfiguration(new KeyValuePair<string, string>("uri", "no it its not"));

            var clientOptions = new TestClientOptions();
            Assert.Throws<UriFormatException>(() => ClientFactory.CreateClient(typeof(TestClient), typeof(TestClientOptions), clientOptions, configuration, null));
        }

        [Test]
        public void FailsToConvertInvalidGuidConfiguration()
        {
            IConfiguration configuration = GetConfiguration(new KeyValuePair<string, string>("guid", "no it its not"));

            var clientOptions = new TestClientOptions();
            Assert.Throws<FormatException>(() => ClientFactory.CreateClient(typeof(TestClient), typeof(TestClientOptions), clientOptions, configuration, null));
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
        public void ThrowsExceptionWithInformationAboutArguments()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("some section:a", "a"),
                new KeyValuePair<string, string>("some section:b:c", "b")
                ).GetSection("some section");

            var clientOptions = new TestClientOptions();
            var exception = Assert.Throws<InvalidOperationException>(() => ClientFactory.CreateClient(typeof(TestClientWithCredentials), typeof(TestClientOptions), clientOptions, configuration, null));
            Assert.AreEqual("Unable to find matching constructor while trying to create an instance of TestClientWithCredentials." + Environment.NewLine +
                "Expected one of the follow sets of configuration parameters:" + Environment.NewLine +
                "1. uri" + Environment.NewLine +
                "2. uri, credential:key" + Environment.NewLine +
                "3. uri, credential:signature" + Environment.NewLine +
                "4. uri" + Environment.NewLine +
                "" + Environment.NewLine +
                "Found the following configuration keys: b, b:c, a",
                exception.Message);
        }

        [Test]
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

            var additionalTenants = (string[])typeof(ClientCertificateCredential)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(f => f.Name.EndsWith("dditionallyAllowedTenantIds"))
                .GetValue(clientCertificateCredential);
            Assert.IsEmpty(additionalTenants);
        }

        [Test]
        [TestCase("*")]
        [TestCase("tenantId1;tenantId2;tenantId3")]
        [TestCase("tenantId1; tenantId2; tenantId3")]
        public void CreatesCertificateCredentialsAdditionalTenants(string additionalTenants)
        {
            var storeLocation = "currentUser";
            var expectedStore = StoreLocation.CurrentUser;
            var storeName = "my";
            var expectedName = StoreName.My;
            var localCert = new X509Store(expectedName, expectedStore);
            localCert.Open(OpenFlags.ReadOnly);
            var someLocalCert = localCert.Certificates[0].Thumbprint;
            localCert.Close();

            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("clientId", "ConfigurationClientId"),
                new KeyValuePair<string, string>("clientCertificate", someLocalCert),
                new KeyValuePair<string, string>("clientCertificateStoreLocation", storeLocation),
                new KeyValuePair<string, string>("clientCertificateStoreName", storeName),
                new KeyValuePair<string, string>("tenantId", "ConfigurationTenantId"),
                new KeyValuePair<string, string>("additionallyAllowedTenants", additionalTenants)
            );

            var credential = ClientFactory.CreateCredential(configuration);

            Assert.IsInstanceOf<ClientCertificateCredential>(credential);
            var clientCertificateCredential = (ClientCertificateCredential)credential;

            Assert.AreEqual("ConfigurationClientId", clientCertificateCredential.ClientId);
            // TODO: Reenable when Azure.Identity version is updated
            // Assert.AreEqual(someLocalCert, clientCertificateCredential.ClientCertificate.Thumbprint);
            Assert.AreEqual("ConfigurationTenantId", clientCertificateCredential.TenantId);

            var actualTenants = (string[])typeof(ClientCertificateCredential)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(f => f.Name.EndsWith("dditionallyAllowedTenantIds"))
                .GetValue(clientCertificateCredential);
            var expectedTenants = additionalTenants.Split(';')
                .Select(t => t.Trim())
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .ToList();
            Assert.AreEqual(expectedTenants, actualTenants);
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

            var additionalTenants = (string[])typeof(ClientSecretCredential)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(f => f.Name.EndsWith("dditionallyAllowedTenantIds"))
                .GetValue(clientSecretCredential);
            Assert.IsEmpty(additionalTenants);
        }

        [Test]
        [TestCase("*")]
        [TestCase("tenantId1;tenantId2;tenantId3")]
        [TestCase("tenantId1;tenantId2;;tenantId3")]
        [TestCase("tenantId1;tenantId2; ;tenantId3")]
        [TestCase("tenantId1; tenantId2; tenantId3")]
        public void CreatesClientSecretCredentials_AdditionalTenants(string additionalTenants)
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("clientId", "ConfigurationClientId"),
                new KeyValuePair<string, string>("clientSecret", "ConfigurationClientSecret"),
                new KeyValuePair<string, string>("tenantId", "ConfigurationTenantId"),
                new KeyValuePair<string, string>("additionallyAllowedTenants", additionalTenants)
            );

            var credential = ClientFactory.CreateCredential(configuration);

            Assert.IsInstanceOf<ClientSecretCredential>(credential);
            var clientSecretCredential = (ClientSecretCredential)credential;

            Assert.AreEqual("ConfigurationClientId", clientSecretCredential.ClientId);
            Assert.AreEqual("ConfigurationClientSecret", clientSecretCredential.ClientSecret);
            Assert.AreEqual("ConfigurationTenantId", clientSecretCredential.TenantId);

            var actualTenants = typeof(ClientSecretCredential)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(f => f.Name.EndsWith("dditionallyAllowedTenantIds"))
                .GetValue(clientSecretCredential);
            var expectedTenants = additionalTenants.Split(';')
                .Select(t => t.Trim())
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .ToList();
            Assert.AreEqual(expectedTenants, actualTenants);
        }

        [Test]
        [NonParallelizable]
        public void CreatesDefaultAzureCredential(
            [Values(true, false)] bool additionalTenants,
            [Values(true, false)] bool clientId,
            [Values(true, false)] bool tenantId,
            [Values(true, false)] bool resourceId)
        {
            List<KeyValuePair<string, string>> configEntries = new();
            string resourceIdValue = $"/subscriptions/{Guid.NewGuid()}";

            if (additionalTenants)
            {
                configEntries.Add(new KeyValuePair<string, string>("additionallyAllowedTenants", "tenantId2"));
            }
            if (clientId)
            {
                configEntries.Add(new KeyValuePair<string, string>("clientId", "clientId"));
            }
            if (tenantId)
            {
                configEntries.Add(new KeyValuePair<string, string>("tenantId", "tenantId"));
            }
            if (resourceId)
            {
                configEntries.Add(new KeyValuePair<string, string>("managedIdentityResourceId", resourceIdValue));
            }
            IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(configEntries).Build();

            // if both clientId and resourceId set, we expect an ArgumentException
            if (clientId && resourceId)
            {
                Assert.Throws<ArgumentException>(() => ClientFactory.CreateCredential(configuration));
                return;
            }
            var credential = ClientFactory.CreateCredential(configuration);

            // if all parameters were false we expect null
            if (!additionalTenants && !clientId && !tenantId && !resourceId)
            {
                Assert.IsNull(credential);
                return;
            }

            Assert.IsInstanceOf<DefaultAzureCredential>(credential);
            var defaultAzureCredential = (DefaultAzureCredential)credential;

            TokenCredential[] credentialChain = (TokenCredential[])typeof(DefaultAzureCredential)
                .GetField("_sources", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(defaultAzureCredential);
            ManagedIdentityCredential miCredential = credentialChain.OfType<ManagedIdentityCredential>().Single();
            AzurePowerShellCredential pwshCredential = credentialChain.OfType<AzurePowerShellCredential>().Single();
            if (additionalTenants)
            {
                var actualTenants = (string[])typeof(AzurePowerShellCredential)
                    .GetProperty("AdditionallyAllowedTenantIds", BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(pwshCredential);
                Assert.AreEqual("tenantId2", actualTenants.Single());
            }
            if (tenantId)
            {
                Assert.AreEqual("tenantId", pwshCredential.TenantId);
            }
            if (clientId)
            {
                Assert.AreEqual("clientId", miCredential.Client.ClientId);
            }
            if (resourceId)
            {
                Assert.AreEqual(resourceIdValue, miCredential.Client.ResourceIdentifier.ToString());
            }
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

            var client = (ManagedIdentityClient)typeof(ManagedIdentityCredential).GetProperty("Client", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(managedIdentityCredential);
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

            var client = (ManagedIdentityClient)typeof(ManagedIdentityCredential).GetProperty("Client", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(managedIdentityCredential);
            var clientId = typeof(ManagedIdentityClient).GetProperty("ClientId", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(client);

            Assert.Null(clientId);
        }

        [Test]
        public void CreatesManagedServiceIdentityCredentialsWithResourceId()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("managedIdentityResourceId", "ConfigurationResourceId"),
                new KeyValuePair<string, string>("credential", "managedidentity")
            );

            var credential = ClientFactory.CreateCredential(configuration);

            Assert.IsInstanceOf<ManagedIdentityCredential>(credential);
            var managedIdentityCredential = (ManagedIdentityCredential)credential;

            var resourceId = (string)typeof(ManagedIdentityCredential).GetField("_clientId", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(managedIdentityCredential);

            Assert.AreEqual("ConfigurationResourceId", resourceId);
        }

        [Test]
        public void CreatesManagedServiceIdentityCredentialsThrowsWhenResourceIdAndClientIdSpecified()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("managedIdentityResourceId", "ConfigurationResourceId"),
                new KeyValuePair<string, string>("clientId", "ConfigurationClientId"),
                new KeyValuePair<string, string>("credential", "managedidentity")
            );

            Assert.That(
                () => ClientFactory.CreateCredential(configuration),
                Throws.InstanceOf<ArgumentException>().With.Message.Contains("managedIdentityResourceId"));
        }

        [Test]
        public void CreatesWorkloadIdentityCredentialsWithOptions()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("tenantId", "ConfigurationTenantId"),
                new KeyValuePair<string, string>("clientId", "ConfigurationClientId"),
                new KeyValuePair<string, string>("tokenFilePath", "ConfigurationTokenFilePath"),
                new KeyValuePair<string, string>("additionallyAllowedTenants", "ExtraConfigurationTenantId1;ExtraConfigurationTenantId2"),
                new KeyValuePair<string, string>("credential", "workloadidentity")
            );

            var credential = ClientFactory.CreateCredential(configuration);

            Assert.IsInstanceOf<WorkloadIdentityCredential>(credential);
            var workloadIdentityCredential = (WorkloadIdentityCredential)credential;

            var credentialAssertion = (ClientAssertionCredential)typeof(WorkloadIdentityCredential).GetField("_clientAssertionCredential", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(workloadIdentityCredential);

            Assert.AreEqual("ConfigurationTenantId", credentialAssertion.TenantId);
            Assert.AreEqual("ConfigurationClientId", credentialAssertion.ClientId);

            Type fileCacheType = typeof(WorkloadIdentityCredential).Assembly.DefinedTypes.Single(x => x.FullName == "Azure.Identity.FileContentsCache");
            var fileCache = typeof(WorkloadIdentityCredential).GetField("_tokenFileCache", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(workloadIdentityCredential);
            var actualTokenFilePath = fileCacheType.GetField("_tokenFilePath", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(fileCache);

            Assert.AreEqual("ConfigurationTokenFilePath", actualTokenFilePath);

            string[] tenants = (string[])typeof(WorkloadIdentityCredential).GetProperty("AdditionallyAllowedTenantIds", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(workloadIdentityCredential);
            Assert.AreEqual(2, tenants.Length);
            Assert.AreEqual("ExtraConfigurationTenantId1", tenants[0]);
            Assert.AreEqual("ExtraConfigurationTenantId2", tenants[1]);
        }

        [Test]
        public void CreatesWorkloadIdentityCredentialsWithEnvironmentVariables()
        {
            IConfiguration configuration = GetConfiguration(new KeyValuePair<string, string>("credential", "workloadidentity"));
            using var envVariables = new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", "EnvTenantId" },
                { "AZURE_CLIENT_ID", "EnvClientId" },
                { "AZURE_FEDERATED_TOKEN_FILE", "EnvTokenFilePath" },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", "ExtraEnvTenantId1;ExtraEnvTenantId2" },
            });

            var credential = ClientFactory.CreateCredential(configuration);

            Assert.IsInstanceOf<WorkloadIdentityCredential>(credential);
            var workloadIdentityCredential = (WorkloadIdentityCredential)credential;

            var credentialAssertion = (ClientAssertionCredential)typeof(WorkloadIdentityCredential).GetField("_clientAssertionCredential", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(workloadIdentityCredential);

            Assert.AreEqual("EnvTenantId", credentialAssertion.TenantId);
            Assert.AreEqual("EnvClientId", credentialAssertion.ClientId);

            Type fileCacheType = typeof(WorkloadIdentityCredential).Assembly.DefinedTypes.Single(x => x.FullName == "Azure.Identity.FileContentsCache");
            var fileCache = typeof(WorkloadIdentityCredential).GetField("_tokenFileCache", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(workloadIdentityCredential);
            var actualTokenFilePath = fileCacheType.GetField("_tokenFilePath", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(fileCache);

            Assert.AreEqual("EnvTokenFilePath", actualTokenFilePath);

            string[] tenants = (string[])typeof(WorkloadIdentityCredential).GetProperty("AdditionallyAllowedTenantIds", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(workloadIdentityCredential);
            Assert.AreEqual(2, tenants.Length);
            Assert.AreEqual("ExtraEnvTenantId1", tenants[0]);
            Assert.AreEqual("ExtraEnvTenantId2", tenants[1]);
        }

        [TestCase(null, null, null)]
        [TestCase(null, "ConfigurationClientId", "ConfigurationTokenFilePath")]
        [TestCase("ConfigurationTenantId", null, "ConfigurationTokenFilePath")]
        [TestCase("ConfigurationTenantId", "ConfigurationClientId", null)]
        [TestCase("ConfigurationTenantId", null, null)]
        [TestCase(null, "ConfigurationClientId", null)]
        [TestCase(null, null, "ConfigurationTokenFilePath")]
        [TestCase(null, "ConfigurationClientId", null)]
        public void CreatesWorkloadIdentityCredentialsWithoutNecessaryOptions(string tenantId, string clientId, string tokenFilePath)
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("tenantId", tenantId),
                new KeyValuePair<string, string>("clientId", clientId),
                new KeyValuePair<string, string>("tokenFilePath", tokenFilePath),
                new KeyValuePair<string, string>("credential", "workloadidentity")
            );

            Assert.Throws<ArgumentException>(() => ClientFactory.CreateCredential(configuration));
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

        [Test]
        public void IgnoresNonTokenCredentialConstructors()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("uri", "http://localhost"),
                new KeyValuePair<string, string>("credential", "managedidentity"),
                new KeyValuePair<string, string>("clientId", "secret")
            );

            var clientOptions = new TestClientOptions();
            var client = (TestClientWithCredentials)ClientFactory.CreateClient(typeof(TestClientWithCredentials), typeof(TestClientOptions), clientOptions, configuration, new DefaultAzureCredential());

            Assert.AreEqual("http://localhost/", client.Uri.ToString());
            Assert.AreSame(clientOptions, client.Options);
            Assert.NotNull(client.Credential);
        }

        [Test]
        public void CanUseAzureKeyCredential()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("uri", "http://localhost"),
                new KeyValuePair<string, string>("credential:key", "key"),
                new KeyValuePair<string, string>("clientId", "secret")
            );

            var clientOptions = new TestClientOptions();
            var client = (TestClientWithCredentials)ClientFactory.CreateClient(typeof(TestClientWithCredentials), typeof(TestClientOptions), clientOptions, configuration, new DefaultAzureCredential());

            Assert.AreEqual("http://localhost/", client.Uri.ToString());
            Assert.AreSame(clientOptions, client.Options);
            Assert.AreEqual("key", client.AzureKeyCredential.Key);
        }

        [Test]
        public void CanUseAzureSasCredential()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("uri", "http://localhost"),
                new KeyValuePair<string, string>("credential:signature", "key"),
                new KeyValuePair<string, string>("clientId", "secret")
            );

            var clientOptions = new TestClientOptions();
            var client = (TestClientWithCredentials)ClientFactory.CreateClient(typeof(TestClientWithCredentials), typeof(TestClientOptions), clientOptions, configuration, new DefaultAzureCredential());

            Assert.AreEqual("http://localhost/", client.Uri.ToString());
            Assert.AreSame(clientOptions, client.Options);
            Assert.AreEqual("key", client.AzureSasCredential.Signature);
        }

        [Test]
        public void CanConfigureManagedIdentityCredentialRetryDefaults()
        {
            RetryOptions expected = CreateRetryOptions();

            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("credential", "managedidentity"));

            var credential = ClientFactory.CreateCredential(configuration);
            AssertRetryOptions<ManagedIdentityCredential>(expected, credential);
        }

        [Test]
        public void CanConfigureManagedIdentityCredentialRetry()
        {
            CanConfigureCredentialRetry<ManagedIdentityCredential>(
                new KeyValuePair<string, string>("credential", "managedidentity"));
        }

        [Test]
        public void CanConfigureWorkloadIdentityCredentialRetryDefaults()
        {
            RetryOptions expected = CreateRetryOptions();

            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("tenantId", "ExampleTenantId"),
                new KeyValuePair<string, string>("clientId", "ExampleClientId"),
                new KeyValuePair<string, string>("tokenFilePath", "ExampleTokenFilePath"),
                new KeyValuePair<string, string>("credential", "workloadidentity"));

            var credential = ClientFactory.CreateCredential(configuration);
            AssertRetryOptions<WorkloadIdentityCredential>(expected, credential);
        }

        [Test]
        public void CanConfigureWorkloadIdentityCredentialRetry()
        {
            CanConfigureCredentialRetry<WorkloadIdentityCredential>(
                new KeyValuePair<string, string>("tenantId", "ExampleTenantId"),
                new KeyValuePair<string, string>("clientId", "ExampleClientId"),
                new KeyValuePair<string, string>("tokenFilePath", "ExampleTokenFilePath"),
                new KeyValuePair<string, string>("credential", "workloadidentity"));
        }

        [Test]
        public void CanConfigureClientSecretCredentialRetryDefaults()
        {
            RetryOptions expected = CreateRetryOptions();

            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("tenantId", "ExampleTenantId"),
                new KeyValuePair<string, string>("clientId", "ExampleClientId"),
                new KeyValuePair<string, string>("clientSecret", "ExampleClientSecret"));

            var credential = ClientFactory.CreateCredential(configuration);
            AssertRetryOptions<ClientSecretCredential>(expected, credential);
        }

        [Test]
        public void CanConfigureClientSecretCredentialRetry()
        {
            CanConfigureCredentialRetry<ClientSecretCredential>(
                new KeyValuePair<string, string>("tenantId", "ExampleTenantId"),
                new KeyValuePair<string, string>("clientId", "ExampleClientId"),
                new KeyValuePair<string, string>("clientSecret", "ExampleClientSecret"));
        }

        [Test]
        public void CanConfigureClientCertificateCredentialRetryDefaults()
        {
            var localCert = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            localCert.Open(OpenFlags.ReadOnly);
            var someLocalCert = localCert.Certificates[0].Thumbprint;
            localCert.Close();

            RetryOptions expected = CreateRetryOptions();

            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("clientId", "ExampleClientId"),
                new KeyValuePair<string, string>("clientCertificate", someLocalCert),
                new KeyValuePair<string, string>("clientCertificateStoreLocation", "currentUser"),
                new KeyValuePair<string, string>("clientCertificateStoreName", "my"),
                new KeyValuePair<string, string>("tenantId", "ExampleTenantId"));

            var credential = ClientFactory.CreateCredential(configuration);
            AssertRetryOptions<ClientCertificateCredential>(expected, credential);
        }

        [Test]
        public void CanConfigureClientCertificateCredentialRetry()
        {
            var localCert = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            localCert.Open(OpenFlags.ReadOnly);
            var someLocalCert = localCert.Certificates[0].Thumbprint;
            localCert.Close();

            CanConfigureCredentialRetry<ClientCertificateCredential>(
                new KeyValuePair<string, string>("clientId", "ExampleClientId"),
                new KeyValuePair<string, string>("clientCertificate", someLocalCert),
                new KeyValuePair<string, string>("clientCertificateStoreLocation", "currentUser"),
                new KeyValuePair<string, string>("clientCertificateStoreName", "my"),
                new KeyValuePair<string, string>("tenantId", "ExampleTenantId"));
        }

        [Test]
        public void CanConfigureDefaultAzureCredentialRetryDefaults()
        {
            RetryOptions expected = CreateRetryOptions();

            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("clientId", "ExampleClientId"));

            var credential = ClientFactory.CreateCredential(configuration);
            AssertRetryOptions<DefaultAzureCredential>(expected, credential);
        }

        [Test]
        public void CanConfigureDefaultAzureCredentialRetry()
        {
            CanConfigureCredentialRetry<DefaultAzureCredential>(
                new KeyValuePair<string, string>("clientId", "ExampleClientId"));
        }

        private static void CanConfigureCredentialRetry<T>(
            params KeyValuePair<string, string>[] configurationItems)
            where T : TokenCredential
        {
            RetryOptions expected = CreateRetryOptions(
                delay: TimeSpan.FromSeconds(2),
                maxDelay: TimeSpan.FromMinutes(1),
                maxRetries: 12,
                networkTimeout: TimeSpan.FromMinutes(5));

            foreach (RetryMode mode in new RetryMode[] { RetryMode.Fixed, RetryMode.Exponential })
            {
                expected.Mode = mode;

                IConfiguration configuration = new ConfigurationBuilder()
                    .AddInMemoryCollection(configurationItems)
                    .AddInMemoryCollection(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>($"retry:{nameof(RetryOptions.Delay)}", expected.Delay.ToString()),
                        new KeyValuePair<string, string>($"retry:{nameof(RetryOptions.MaxDelay)}", expected.MaxDelay.ToString()),
                        new KeyValuePair<string, string>($"retry:{nameof(RetryOptions.MaxRetries)}", expected.MaxRetries.ToString()),
                        new KeyValuePair<string, string>($"retry:{nameof(RetryOptions.Mode)}", expected.Mode.ToString()),
                        new KeyValuePair<string, string>($"retry:{nameof(RetryOptions.NetworkTimeout)}", expected.NetworkTimeout.ToString())
                    })
                    .Build();

                var credential = ClientFactory.CreateCredential(configuration);
                AssertRetryOptions<T>(expected, credential);
            }
        }

        private IConfiguration GetConfiguration(params KeyValuePair<string, string>[] items)
        {
            return new ConfigurationBuilder().AddInMemoryCollection(items).Build();
        }

        private static RetryOptions CreateRetryOptions(
            TimeSpan? delay = null,
            TimeSpan? maxDelay = null,
            int maxRetries = 3,
            RetryMode mode = RetryMode.Exponential,
            TimeSpan? networkTimeout = null)
        {
            var options = Activator.CreateInstance(typeof(RetryOptions), nonPublic: true) as RetryOptions;
            options.Delay = delay ?? TimeSpan.FromSeconds(0.8);
            options.MaxDelay = maxDelay ?? TimeSpan.FromMinutes(1);
            options.MaxRetries = maxRetries;
            options.Mode = mode;
            options.NetworkTimeout = networkTimeout ?? TimeSpan.FromSeconds(100);

            return options;
        }

        private static void AssertRetryOptions<T>(RetryOptions expected, object actualCredential)
            where T : TokenCredential
        {
            Assembly azureCore = typeof(TokenCredential).Assembly;
            Assembly azureIdentity = typeof(DefaultAzureCredential).Assembly;

            // Unfortunately, much of this information is embedded in the internal HTTP pipeline,
            // so it takes a bit of effort to figure out whether classes were configured in the expected way.
            Assert.IsInstanceOf(typeof(T), actualCredential);
            Type credentialPipelineType = azureIdentity.DefinedTypes.Single(x => x.FullName == "Azure.Identity.CredentialPipeline");
            object credentialPipeline = typeof(T).GetField("_pipeline", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(actualCredential);
            HttpPipeline httpPipeline = credentialPipelineType.GetProperty("HttpPipeline", BindingFlags.Public | BindingFlags.Instance).GetValue(credentialPipeline) as HttpPipeline;
            ReadOnlyMemory<HttpPipelinePolicy> policies = (ReadOnlyMemory<HttpPipelinePolicy>)typeof(HttpPipeline).GetField("_pipeline", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(httpPipeline);

            // Validate RetryPolicy
            RetryPolicy actualRetryPolicy = policies.ToArray().Single(x => x.GetType() == typeof(RetryPolicy)) as RetryPolicy;
            DelayStrategy delayStrategy = typeof(RetryPolicy).GetField("_delayStrategy", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(actualRetryPolicy) as DelayStrategy;
            int maxRetries = (int)typeof(RetryPolicy).GetField("_maxRetries", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(actualRetryPolicy);

            Assert.AreEqual(expected.MaxRetries, maxRetries);

            Type expectedStrategyType = expected.Mode switch
            {
                RetryMode.Exponential => azureCore.DefinedTypes.Single(x => x.FullName == "Azure.Core.ExponentialDelayStrategy"),
                RetryMode.Fixed => azureCore.DefinedTypes.Single(x => x.FullName == "Azure.Core.FixedDelayStrategy"),
                _ => throw new AssertionException($"Unexpected retry mode: {expected.Mode}"),
            };

            Assert.IsInstanceOf(expectedStrategyType, delayStrategy);
            TimeSpan delay = (TimeSpan)expectedStrategyType.GetField("_delay", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(delayStrategy);
            Assert.AreEqual(expected.Delay, delay);

            if (expected.Mode == RetryMode.Exponential)
            {
                TimeSpan maxDelay = (TimeSpan)typeof(DelayStrategy).GetField("_maxDelay", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(delayStrategy);
                Assert.AreEqual(expected.MaxDelay, maxDelay);
            }

            // Validate ResponseBodyPolicy
            Type responseBodyPolicyType = azureCore.DefinedTypes.Single(x => x.FullName == "Azure.Core.Pipeline.ResponseBodyPolicy");
            object actualResponseBodyPolicy = policies.ToArray().Single(x => x.GetType() == responseBodyPolicyType);
            TimeSpan networkTimeout = (TimeSpan)responseBodyPolicyType.GetField("_networkTimeout", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(actualResponseBodyPolicy);

            Assert.AreEqual(expected.NetworkTimeout, networkTimeout);
        }
    }
}
