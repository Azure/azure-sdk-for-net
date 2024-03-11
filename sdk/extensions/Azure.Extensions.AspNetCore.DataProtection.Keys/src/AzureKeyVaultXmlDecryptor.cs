// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core.Cryptography;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.Extensions.AspNetCore.DataProtection.Keys
{
#pragma warning disable CA1812 // False positive, AzureKeyVaultXmlDecryptor is used in AzureKeyVaultXmlEncryptor
    internal class AzureKeyVaultXmlDecryptor : IXmlDecryptor
#pragma warning restore
    {
        private readonly IKeyEncryptionKeyResolver _client;

        public AzureKeyVaultXmlDecryptor(IServiceProvider serviceProvider)
        {
            _client = serviceProvider.GetService<IKeyEncryptionKeyResolver>();
        }

        public XElement Decrypt(XElement encryptedElement)
        {
            var kid = (string)encryptedElement.Element("kid");
            var symmetricKey = Convert.FromBase64String((string)encryptedElement.Element("key"));
            var symmetricIV = Convert.FromBase64String((string)encryptedElement.Element("iv"));

            var encryptedValue = Convert.FromBase64String((string)encryptedElement.Element("value"));

            var key = _client.Resolve(kid);
            var result = key.UnwrapKey(AzureKeyVaultXmlEncryptor.DefaultKeyEncryption, symmetricKey);

            byte[] decryptedValue;
            using (var symmetricAlgorithm = AzureKeyVaultXmlEncryptor.DefaultSymmetricAlgorithmFactory())
            {
                using (var decryptor = symmetricAlgorithm.CreateDecryptor(result, symmetricIV))
                {
                    decryptedValue = decryptor.TransformFinalBlock(encryptedValue, 0, encryptedValue.Length);
                }
            }

            using (var memoryStream = new MemoryStream(decryptedValue))
            {
                return XElement.Load(memoryStream);
            }
        }
    }
}
