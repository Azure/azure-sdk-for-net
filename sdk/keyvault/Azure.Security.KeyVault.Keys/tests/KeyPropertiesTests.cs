// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class KeyPropertiesTests
    {
        [TestCase(@"{""kid"":""https://vault/keys/key-name""}", false)]
        [TestCase(@"{""kid"":""https://vault/keys/key-name"",""managed"":false}", false)]
        [TestCase(@"{""kid"":""https://vault/keys/key-name"",""managed"":true}", true)]
        public void DeserializesManaged(string content, bool expected)
        {
            KeyProperties properties = new KeyProperties();
            using (JsonStream json = new JsonStream(content))
            {
                properties.Deserialize(json.AsStream());
            }

            Assert.AreEqual(expected, properties.Managed);
        }
    }
}
