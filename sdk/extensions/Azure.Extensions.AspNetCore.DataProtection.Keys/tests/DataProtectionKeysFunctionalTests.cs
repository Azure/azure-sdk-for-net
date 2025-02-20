// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Keys;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.Extensions.AspNetCore.DataProtection.Keys.Tests
{
    public class DataProtectionKeysFunctionalTests: LiveTestBase<DataProtectionTestEnvironment>
    {
        [Test]
        public async Task ProtectsKeysWithKeyVaultKey()
        {
            var client = new KeyClient(new Uri(TestEnvironment.KeyVaultUrl), TestEnvironment.Credential);
            var key = await client.CreateKeyAsync("TestEncryptionKey", KeyType.Rsa);

            var serviceCollection = new ServiceCollection();

            var testKeyRepository = new TestKeyRepository();

            serviceCollection.AddDataProtection().ProtectKeysWithAzureKeyVault(key.Value.Id, TestEnvironment.Credential);

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
                StringAssert.Contains("This key is encrypted with Azure Key Vault", element.ToString());
            }
        }

        [Test]
        public async Task CanDecryptEncryptedKeys()
        {
            var client = new KeyClient(new Uri(TestEnvironment.KeyVaultUrl), TestEnvironment.Credential);
            var key = await client.CreateKeyAsync("TestEncryptionKey2", KeyType.Rsa);

            var serviceCollection = new ServiceCollection();

            var testKeyRepository = new TestKeyRepository();

            // Configure data protection to use TokenCredential
            serviceCollection.AddDataProtection()
                .ProtectKeysWithAzureKeyVault(key.Value.Id, TestEnvironment.Credential);

            serviceCollection.Configure<KeyManagementOptions>(options =>
            {
                options.XmlRepository = testKeyRepository;
            });

            var services = serviceCollection.BuildServiceProvider();

            // Encrypt data
            var dataProtector = services.GetService<IDataProtectionProvider>().CreateProtector("Fancy purpose");
            var protectedText = dataProtector.Protect("Hello world!");

            // Decrypt data
            var unprotectedText = dataProtector.Unprotect(protectedText);

            Assert.AreEqual("Hello world!", unprotectedText);

            // double check that keys were protected with KeyVault

            foreach (var element in testKeyRepository.GetAllElements())
            {
                StringAssert.Contains("This key is encrypted with Azure", element.ToString());
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
