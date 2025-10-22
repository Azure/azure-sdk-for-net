// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Azure.Core.TestFramework;
using Azure.Identity;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

#if NET8_0_OR_GREATER
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
#endif

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
        public void CreatesClientSecretCredentialsAdditionalTenants(string additionalTenants)
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
        public void CreatesAzurePipelinesCredential()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("credential", "azurepipelines"),
                new KeyValuePair<string, string>("clientId", "ConfigurationClientId"),
                new KeyValuePair<string, string>("tenantId", "ConfigurationTenantId"),
                new KeyValuePair<string, string>("serviceConnectionId", "SomeServiceConnectionId"),
                new KeyValuePair<string, string>("systemAccessToken", "SomeSystemAccessToken")
            );

            var credential = ClientFactory.CreateCredential(configuration);

            Assert.IsInstanceOf<AzurePipelinesCredential>(credential);
            var pipelinesCredential = (AzurePipelinesCredential)credential;

            Assert.AreEqual("ConfigurationClientId", pipelinesCredential.Client.ClientId);
            Assert.AreEqual("ConfigurationTenantId", pipelinesCredential.TenantId);
            Assert.AreEqual("SomeServiceConnectionId", pipelinesCredential.ServiceConnectionId);
            Assert.AreEqual("SomeSystemAccessToken", pipelinesCredential.SystemAccessToken);

            var additionalTenants = (string[])typeof(AzurePipelinesCredential)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(f => f.Name.EndsWith("dditionallyAllowedTenantIds"))
                .GetValue(pipelinesCredential);

            Assert.IsEmpty(additionalTenants);
        }

        [Test]
        [TestCase("*")]
        [TestCase("tenantId1;tenantId2;tenantId3")]
        [TestCase("tenantId1;tenantId2;;tenantId3")]
        [TestCase("tenantId1;tenantId2; ;tenantId3")]
        [TestCase("tenantId1; tenantId2; tenantId3")]
        public void CreatesAzurePipelinesCredentialAdditionalTenants(string additionalTenants)
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("credential", "azurepipelines"),
                new KeyValuePair<string, string>("clientId", "ConfigurationClientId"),
                new KeyValuePair<string, string>("tenantId", "ConfigurationTenantId"),
                new KeyValuePair<string, string>("serviceConnectionId", "SomeServiceConnectionId"),
                new KeyValuePair<string, string>("systemAccessToken", "SomeSystemAccessToken"),
                new KeyValuePair<string, string>("additionallyAllowedTenants", additionalTenants)
            );

            var credential = ClientFactory.CreateCredential(configuration);

            Assert.IsInstanceOf<AzurePipelinesCredential>(credential);
            var pipelinesCredential = (AzurePipelinesCredential)credential;

            Assert.AreEqual("ConfigurationClientId", pipelinesCredential.Client.ClientId);
            Assert.AreEqual("ConfigurationTenantId", pipelinesCredential.TenantId);
            Assert.AreEqual("SomeServiceConnectionId", pipelinesCredential.ServiceConnectionId);
            Assert.AreEqual("SomeSystemAccessToken", pipelinesCredential.SystemAccessToken);

            var expectedTenants = additionalTenants.Split(';')
                .Select(t => t.Trim())
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .ToList();

            Assert.AreEqual(expectedTenants, pipelinesCredential.AdditionallyAllowedTenantIds);
        }

        [Test]
        [TestCase(null, null, null, null)]
        [TestCase("", "", "", "")]
        [TestCase("ConfigurationClientId", null, "", null)]
        [TestCase("", "ConfigurationTenantId", null, null)]
        [TestCase(null, "", "SomeServiceConnectionId", null)]
        [TestCase("", null, "", "SomeSystemAccessToken")]
        public void CreatesAzurePipelinesCredentialInvalidConfig(string clientId, string tenantId, string serviceConnectionId, string systemAccessToken)
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("credential", "azurepipelines"),
                new KeyValuePair<string, string>("clientId", clientId),
                new KeyValuePair<string, string>("tenantId", tenantId),
                new KeyValuePair<string, string>("serviceConnectionId", serviceConnectionId),
                new KeyValuePair<string, string>("systemAccessToken", systemAccessToken)
            );

            Assert.Throws<ArgumentException>(() => ClientFactory.CreateCredential(configuration));
        }

        [Test]
        [NonParallelizable]
        public void CreatesDefaultAzureCredential(
            [Values(true, false)] bool additionalTenants,
            [Values(true, false)] bool clientId,
            [Values(true, false)] bool managedIdentityClientId,
            [Values(true, false)] bool tenantId,
            [Values(true, false)] bool objectId,
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
            if (managedIdentityClientId)
            {
                configEntries.Add(new KeyValuePair<string, string>("managedIdentityClientId", "managedIdentityClientId"));
            }
            if (tenantId)
            {
                configEntries.Add(new KeyValuePair<string, string>("tenantId", "tenantId"));
            }
            if (resourceId)
            {
                configEntries.Add(new KeyValuePair<string, string>("managedIdentityResourceId", resourceIdValue));
            }
            if (objectId)
            {
                configEntries.Add(new KeyValuePair<string, string>("managedIdentityObjectId", "objectId"));
            }

            IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(configEntries).Build();

            // if multiple parameters for the managed identity are set, we expect an ArgumentException
            // We also expect an exception if objectId is set for DefaultAzureCredential, as it is only supported for ManagedIdentityCredential
            if ((clientId && resourceId) || (managedIdentityClientId && resourceId) || objectId)
            {
                Assert.Throws<ArgumentException>(() => ClientFactory.CreateCredential(configuration));
                return;
            }

            var credential = ClientFactory.CreateCredential(configuration);

            // if all parameters were false we expect null
            if (!additionalTenants && !clientId && !managedIdentityClientId && !tenantId && !resourceId)
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

            string managedIdentityId;
            int idType;
            ReflectIdAndType(miCredential, out managedIdentityId, out idType);

            // managedIdentityClientId takes precedence over clientId when both are present
            if (managedIdentityClientId)
            {
                Assert.AreEqual("managedIdentityClientId", managedIdentityId);
                Assert.AreEqual(1, idType); // 1 is the value for ClientId
            }
            else if (clientId)
            {
                Assert.AreEqual("clientId", managedIdentityId);
                Assert.AreEqual(1, idType); // 1 is the value for ClientId
            }

            if (resourceId)
            {
                Assert.AreEqual(resourceIdValue.ToString(), managedIdentityId);
                Assert.AreEqual(2, idType); // 2 is the value for ResourceId
            }

            if (objectId)
            {
                Assert.AreEqual("objectId", managedIdentityId);
                Assert.AreEqual(3, idType); // 3 is the value for ObjectId
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

            string clientId;
            int idType;
            ReflectIdAndType(managedIdentityCredential, out clientId, out idType);

            Assert.AreEqual("ConfigurationClientId", clientId);
            Assert.AreEqual(1, idType); // 1 is the value for ClientId
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

            string clientId;
            int idType;
            ReflectIdAndType(managedIdentityCredential, out clientId, out idType);

            Assert.Null(clientId);
            Assert.AreEqual(0, idType); // 0 is the value for SystemAssigned
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

            string resourceId;
            int idType;
            ReflectIdAndType(managedIdentityCredential, out resourceId, out idType);

            Assert.AreEqual("ConfigurationResourceId", resourceId);
            Assert.AreEqual(2, idType); // 2 is the value for ResourceId
        }

        [Test]
        public void CreatesManagedServiceIdentityCredentialsWithObjectId()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("managedIdentityObjectId", "ConfigurationObjectId"),
                new KeyValuePair<string, string>("credential", "managedidentity")
            );

            var credential = ClientFactory.CreateCredential(configuration);

            Assert.IsInstanceOf<ManagedIdentityCredential>(credential);
            var managedIdentityCredential = (ManagedIdentityCredential)credential;

            string objectId;
            int idType;
            ReflectIdAndType(managedIdentityCredential, out objectId, out idType);

            Assert.AreEqual("ConfigurationObjectId", objectId);
            Assert.AreEqual(3, idType); // 3 is the value for ObjectId
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
        public void CreatesManagedServiceIdentityCredentialsThrowsWhenClientIdAndObjectIdSpecified()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("managedIdentityObjectId", "ConfigurationObjectId"),
                new KeyValuePair<string, string>("clientId", "ConfigurationClientId"),
                new KeyValuePair<string, string>("credential", "managedidentity")
            );

            Assert.That(
                () => ClientFactory.CreateCredential(configuration),
                Throws.InstanceOf<ArgumentException>().With.Message.Contains("managedIdentityResourceId"));
        }

        [Test]
        public void CreatesManagedServiceIdentityCredentialsThrowsWhenResourceIdAndObjectIdSpecified()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("managedIdentityObjectId", "ConfigurationObjectId"),
                new KeyValuePair<string, string>("managedIdentityResourceId", "ConfigurationResourceId"),
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
        [TestCase("*")]
        [TestCase("tenantId1;tenantId2;tenantId3")]
        [TestCase("tenantId1;tenantId2;;tenantId3")]
        [TestCase("tenantId1;tenantId2; ;tenantId3")]
        [TestCase("tenantId1; tenantId2; tenantId3")]
        public void CreatesWorkloadIdentityCredentialAdditionalTenants(string additionalTenants)
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("credential", "workloadidentity"),
                new KeyValuePair<string, string>("additionallyAllowedTenants", additionalTenants)
            );

            using var envVariables = new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", "EnvTenantId" },
                { "AZURE_CLIENT_ID", "EnvClientId" },
                { "AZURE_FEDERATED_TOKEN_FILE", "EnvTokenFilePath" },
            });

            var credential = ClientFactory.CreateCredential(configuration);

            Assert.IsInstanceOf<WorkloadIdentityCredential>(credential);
            var workloadIdentityCredential = (WorkloadIdentityCredential)credential;

            var credentialAssertion = (ClientAssertionCredential)typeof(WorkloadIdentityCredential).GetField("_clientAssertionCredential", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(workloadIdentityCredential);

            Assert.AreEqual("EnvTenantId", credentialAssertion.TenantId);
            Assert.AreEqual("EnvClientId", credentialAssertion.ClientId);

            var expectedTenants = additionalTenants.Split(';')
                .Select(t => t.Trim())
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .ToList();

            Assert.AreEqual(expectedTenants, workloadIdentityCredential.AdditionallyAllowedTenantIds);
        }

        [Test]
        public void CreatesManagedFederatedIdentityCredentialWithManagedIdentityClientId()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("credential", "managedidentityasfederatedidentity"),
                new KeyValuePair<string, string>("tenantId", "TestTenantId"),
                new KeyValuePair<string, string>("clientId", "TestClientId"),
                new KeyValuePair<string, string>("managedIdentityClientId", "TestManagedIdentityClientId"),
                new KeyValuePair<string, string>("azureCloud", "public")
            );

            var credential = ClientFactory.CreateCredential(configuration);

            Assert.IsInstanceOf<Microsoft.Extensions.Azure.Internal.ManagedFederatedIdentityCredential>(credential);
            var mfCredential = (Microsoft.Extensions.Azure.Internal.ManagedFederatedIdentityCredential)credential;

            // Validate via reflection that the fields are set as expected
            var mic = typeof(Microsoft.Extensions.Azure.Internal.ManagedFederatedIdentityCredential)
                .GetField("_managedIdentityCredential", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(mfCredential);
            Assert.IsInstanceOf<ManagedIdentityCredential>(mic);

            var managedIdentityCredential = (ManagedIdentityCredential)mic;
            string clientId;
            int idType;
            ReflectIdAndType(managedIdentityCredential, out clientId, out idType);

            Assert.AreEqual("TestManagedIdentityClientId", clientId);
            Assert.AreEqual(1, idType); // 1 is the value for ClientId
        }

        [Test]
        public void CreatesManagedFederatedIdentityCredentialWithResourceId()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("credential", "managedidentityasfederatedidentity"),
                new KeyValuePair<string, string>("tenantId", "TestTenantId"),
                new KeyValuePair<string, string>("clientId", "TestClientId"),
                new KeyValuePair<string, string>("managedIdentityResourceId", "/subscriptions/test-sub/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity"),
                new KeyValuePair<string, string>("azureCloud", "public")
            );

            var credential = ClientFactory.CreateCredential(configuration);

            Assert.IsInstanceOf<Microsoft.Extensions.Azure.Internal.ManagedFederatedIdentityCredential>(credential);
            var mfCredential = (Microsoft.Extensions.Azure.Internal.ManagedFederatedIdentityCredential)credential;

            // Validate via reflection that the fields are set as expected
            var mic = typeof(Microsoft.Extensions.Azure.Internal.ManagedFederatedIdentityCredential)
                .GetField("_managedIdentityCredential", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(mfCredential);
            Assert.IsInstanceOf<ManagedIdentityCredential>(mic);

            var managedIdentityCredential = (ManagedIdentityCredential)mic;
            string resourceId;
            int idType;
            ReflectIdAndType(managedIdentityCredential, out resourceId, out idType);

            Assert.AreEqual("/subscriptions/test-sub/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity", resourceId);
            Assert.AreEqual(2, idType); // 2 is the value for ResourceId
        }

        [Test]
        public void CreatesManagedFederatedIdentityCredentialWithObjectId()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("credential", "managedidentityasfederatedidentity"),
                new KeyValuePair<string, string>("tenantId", "TestTenantId"),
                new KeyValuePair<string, string>("clientId", "TestClientId"),
                new KeyValuePair<string, string>("managedIdentityObjectId", "test-object-id-guid"),
                new KeyValuePair<string, string>("azureCloud", "public")
            );

            var credential = ClientFactory.CreateCredential(configuration);

            Assert.IsInstanceOf<Microsoft.Extensions.Azure.Internal.ManagedFederatedIdentityCredential>(credential);
            var mfCredential = (Microsoft.Extensions.Azure.Internal.ManagedFederatedIdentityCredential)credential;

            // Validate via reflection that the fields are set as expected
            var mic = typeof(Microsoft.Extensions.Azure.Internal.ManagedFederatedIdentityCredential)
                .GetField("_managedIdentityCredential", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(mfCredential);
            Assert.IsInstanceOf<ManagedIdentityCredential>(mic);

            var managedIdentityCredential = (ManagedIdentityCredential)mic;
            string objectId;
            int idType;
            ReflectIdAndType(managedIdentityCredential, out objectId, out idType);

            Assert.AreEqual("test-object-id-guid", objectId);
            Assert.AreEqual(3, idType); // 3 is the value for ObjectId
        }

        [Test]
        [TestCase("public")]
        [TestCase("usgov")]
        [TestCase("china")]
        public void CreatesManagedFederatedIdentityCredentialWithDifferentClouds(string azureCloud)
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("credential", "managedidentityasfederatedidentity"),
                new KeyValuePair<string, string>("tenantId", "TestTenantId"),
                new KeyValuePair<string, string>("clientId", "TestClientId"),
                new KeyValuePair<string, string>("managedIdentityClientId", "TestManagedIdentityClientId"),
                new KeyValuePair<string, string>("azureCloud", azureCloud)
            );

            var credential = ClientFactory.CreateCredential(configuration);

            Assert.IsInstanceOf<Microsoft.Extensions.Azure.Internal.ManagedFederatedIdentityCredential>(credential);
            var mfCredential = (Microsoft.Extensions.Azure.Internal.ManagedFederatedIdentityCredential)credential;

            // Validate via reflection that the fields are set as expected
            var mic = typeof(Microsoft.Extensions.Azure.Internal.ManagedFederatedIdentityCredential)
                .GetField("_managedIdentityCredential", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(mfCredential);
            Assert.IsInstanceOf<ManagedIdentityCredential>(mic);
        }

        [Test]
        public void CreatesManagedFederatedIdentityCredentialThrowsWhenMissingRequiredOptions()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("credential", "managedidentityasfederatedidentity"),
                new KeyValuePair<string, string>("tenantId", "TestTenantId"),
                new KeyValuePair<string, string>("clientId", "TestClientId")
                // missing azureCloud and one of the managed identity identifiers
            );

            Assert.Throws<ArgumentException>(() => ClientFactory.CreateCredential(configuration));
        }

        [Test]
        [TestCase(null, "TestClientId", "TestManagedIdentityClientId", "public")]  // missing tenantId
        [TestCase("TestTenantId", null, "TestManagedIdentityClientId", "public")]  // missing clientId
        [TestCase("TestTenantId", "TestClientId", "TestManagedIdentityClientId", null)]  // missing azureCloud
        [TestCase("TestTenantId", "TestClientId", null, "public")]  // missing managed identity identifier
        public void CreatesManagedFederatedIdentityCredentialThrowsWhenAnyRequiredOptionMissing(string tenantId, string clientId, string managedIdentityClientId, string azureCloud)
        {
            var items = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("credential", "managedidentityasfederatedidentity")
            };

            if (tenantId != null)
            {
                items.Add(new KeyValuePair<string, string>("tenantId", tenantId));
            }
            if (clientId != null)
            {
                items.Add(new KeyValuePair<string, string>("clientId", clientId));
            }
            if (managedIdentityClientId != null)
            {
                items.Add(new KeyValuePair<string, string>("managedIdentityClientId", managedIdentityClientId));
            }
            if (azureCloud != null)
            {
                items.Add(new KeyValuePair<string, string>("azureCloud", azureCloud));
            }

            IConfiguration configuration = GetConfiguration(items.ToArray());

            Assert.Throws<ArgumentException>(() => ClientFactory.CreateCredential(configuration));
        }

        [Test]
        public void CreatesManagedFederatedIdentityCredentialThrowsWhenMultipleManagedIdentityIdentifiersSpecified()
        {
            // Test multiple managed identity identifiers (should throw)
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("credential", "managedidentityasfederatedidentity"),
                new KeyValuePair<string, string>("tenantId", "TestTenantId"),
                new KeyValuePair<string, string>("clientId", "TestClientId"),
                new KeyValuePair<string, string>("managedIdentityClientId", "TestManagedIdentityClientId"),
                new KeyValuePair<string, string>("managedIdentityResourceId", "/subscriptions/test-sub/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity"),
                new KeyValuePair<string, string>("azureCloud", "public")
            );

            Assert.Throws<ArgumentException>(() => ClientFactory.CreateCredential(configuration));
        }

        [Test]
        public void CreatesManagedFederatedIdentityCredentialThrowsWhenInvalidAzureCloud()
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("credential", "managedidentityasfederatedidentity"),
                new KeyValuePair<string, string>("tenantId", "TestTenantId"),
                new KeyValuePair<string, string>("clientId", "TestClientId"),
                new KeyValuePair<string, string>("managedIdentityClientId", "TestManagedIdentityClientId"),
                new KeyValuePair<string, string>("azureCloud", "invalid-cloud")
            );

            // This should throw an ArgumentException due to invalid cloud
            Assert.Throws<ArgumentException>(() => ClientFactory.CreateCredential(configuration));
        }

        [Test]
        [TestCase("*")]
        [TestCase("tenantId1;tenantId2;tenantId3")]
        [TestCase("tenantId1;tenantId2;;tenantId3")]
        [TestCase("tenantId1;tenantId2; ;tenantId3")]
        [TestCase("tenantId1; tenantId2; tenantId3")]
        public void CreatesManagedFederatedIdentityCredentialAdditionalTenants(string additionalTenants)
        {
            IConfiguration configuration = GetConfiguration(
                new KeyValuePair<string, string>("credential", "managedidentityasfederatedidentity"),
                new KeyValuePair<string, string>("tenantId", "TestTenantId"),
                new KeyValuePair<string, string>("clientId", "TestClientId"),
                new KeyValuePair<string, string>("managedIdentityClientId", "TestManagedIdentityClientId"),
                new KeyValuePair<string, string>("azureCloud", "public"),
                new KeyValuePair<string, string>("additionallyAllowedTenants", additionalTenants)
            );

            var credential = ClientFactory.CreateCredential(configuration);

            Assert.IsInstanceOf<Microsoft.Extensions.Azure.Internal.ManagedFederatedIdentityCredential>(credential);
            var mfCredential = (Microsoft.Extensions.Azure.Internal.ManagedFederatedIdentityCredential)credential;

            var expectedTenants = additionalTenants.Split(';')
                .Select(t => t.Trim())
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .ToList();

            Assert.AreEqual(expectedTenants, mfCredential.AdditionallyAllowedTenants);
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

#if NET8_0_OR_GREATER
        [Test]
        public async Task AllowsAspNetCoreIntegrationTestHostConfiguration()
        {
            var expectedKeyVaultUriValue = "https://fake.vault.azure.net/";

            // When configuration is set using the test host, the behavior of IConfigurationSection
            // changes and the Value property is not null for a complex object.  Instead it returns an
            // empty string, which we don't want to treat as a connection string.
            //
            // This is a bug in the configuration system, but there's no commitment for when it will
            // be fixed.  See: https://github.com/dotnet/aspnetcore/issues/37680
            //
            var factory = new WebApplicationFactory<AspNetHost>()
                .WithWebHostBuilder(builder =>
                {
                    builder.UseContentRoot("aspnet-host");

                    builder.UseConfiguration(
                        GetConfiguration(
                            new KeyValuePair<string, string>("KeyVault:VaultUri", expectedKeyVaultUriValue)));
                });

            var client = factory.CreateClient();
            var response = await client.GetAsync("/keyvault");
            var keyVaultUriValue = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(expectedKeyVaultUriValue, keyVaultUriValue);
        }
#endif

        private IConfiguration GetConfiguration(params KeyValuePair<string, string>[] items)
        {
            return new ConfigurationBuilder().AddInMemoryCollection(items).Build();
        }

        private static void ReflectIdAndType(ManagedIdentityCredential managedIdentityCredential, out string clientId, out int idType)
        {
            var managedIdentityClient = typeof(ManagedIdentityCredential).GetProperty("Client", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(managedIdentityCredential);
            var managedIdentityClientOptions = managedIdentityClient.GetType().GetField("_options", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(managedIdentityClient);
            var managedIdentityId = managedIdentityClientOptions.GetType().GetProperty("ManagedIdentityId").GetValue(managedIdentityClientOptions);
            clientId = (string)typeof(ManagedIdentityId).GetField("_userAssignedId", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(managedIdentityId);
            idType = (int)typeof(ManagedIdentityId).GetField("_idType", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(managedIdentityId);
        }
    }
}