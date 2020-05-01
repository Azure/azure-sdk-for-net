// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Extensions.AspNetCore.DataProtection.Keys.Tests;
using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.Extensions.AspNetCore.DataProtection.Blobs.Tests
{
    public class DataProtectionKeysFunctionalTests
    {
        [Test]
        [Category("Live")]
        public async Task ProtectsKeysWithKeyVaultKey()
        {
            var credential = new ClientSecretCredential(
                DataProtectionTestEnvironment.Instance.TenantId,
                DataProtectionTestEnvironment.Instance.ClientId,
                DataProtectionTestEnvironment.Instance.ClientSecret);
            var client = new KeyClient(new Uri(DataProtectionTestEnvironment.Instance.KeyVaultUrl), credential);
            var key = await client.CreateKeyAsync("TestEncryptionKey", KeyType.Rsa);

            var serviceCollection = new ServiceCollection();

            var testKeyRepository = new TestKeyRepository();

            serviceCollection.AddDataProtection().ProtectKeysWithAzureKeyVault(key.Value.Id, credential);

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