// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AspNetCore.DataProtection.Blobs.Tests
{
    public class DataProtectionKeysFunctionalTests
    {
        private static readonly string TenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
        private static readonly string ClientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
        private static readonly string ClientSecret = Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET");
        private static readonly string KeyVaultUrl = Environment.GetEnvironmentVariable("AZURE_KEYVAULT_URL");

        [Test]
        [Category("Live")]
        public async Task ProtectsKeysWithKeyVaultKey()
        {
            var credential = new ClientSecretCredential(TenantId, ClientId, ClientSecret);
            var client = new KeyClient(new Uri(KeyVaultUrl), credential);
            var key = await client.CreateKeyAsync("TestEncryptionKey", KeyType.Rsa);

            var serviceCollection = new ServiceCollection();

            var testKeyRepository = new TestKeyRepository();

            serviceCollection.AddDataProtection().ProtectKeysWithAzureKeyVault(key.Value.Id.ToString(), credential);

            serviceCollection.Configure<KeyManagementOptions>(options =>
            {
                options.XmlRepository = testKeyRepository;
            });

            var services = serviceCollection.BuildServiceProvider();

            var dataProtector = services.GetService<IDataProtectionProvider>().CreateProtector("Fancy purpose");
            var protectedText = dataProtector.Protect("Hello world!");

            var anotherServices = serviceCollection.BuildServiceProvider();
            var anotherDataProtector = anotherServices.GetService<IDataProtectionProvider>().CreateProtector("Fancy purpose");
            var unprotectedText = anotherDataProtector.Unprotect(protectedText);

            Assert.AreEqual("Hello world!", unprotectedText);

            // double check that keys were protected with KeyVault

            foreach (var element in testKeyRepository.GetAllElements())
            {
                StringAssert.Contains("This key is encrypted with Azure KeyVault", element.ToString());
            }
        }

        private class TestKeyRepository: IXmlRepository
        {
            private List<XElement> _elements;

            public TestKeyRepository()
            {
                _elements = new List<XElement>();
            }

            public IReadOnlyCollection<XElement> GetAllElements()
            {
                lock (_elements)
                {
                    return _elements.ToArray();
                }
            }

            public void StoreElement(XElement element, string friendlyName)
            {
                lock (_elements)
                {
                    _elements.Add(element);
                }
            }
        }
    }
}