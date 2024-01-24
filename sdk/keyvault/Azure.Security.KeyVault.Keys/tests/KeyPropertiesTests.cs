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

        [TestCase(@"{""kid"":""https://vault/keys/key-name""}", null)]
        [TestCase(@"{""kid"":""https://vault/keys/key-name"",""attributes"":{""recoverableDays"":0}}", 0)]
        [TestCase(@"{""kid"":""https://vault/keys/key-name"",""attributes"":{""recoverableDays"":90}}", 90)]
        public void DeserializesRecoverableDays(string content, int? expected)
        {
            KeyProperties properties = new KeyProperties();
            using (JsonStream json = new JsonStream(content))
            {
                properties.Deserialize(json.AsStream());
            }

            Assert.AreEqual(expected, properties.RecoverableDays);
        }

        [TestCase(@"{""kid"":""https://vault/keys/key-name""}", null)]
        [TestCase(@"{""kid"":""https://vault/keys/key-name"",""attributes"":{""hsmPlatform"":null}}", null)]
        [TestCase(@"{""kid"":""https://vault/keys/key-name"",""attributes"":{""hsmPlatform"":""1""}}", "1")]
        public void DeserializesHsmPlatform(string content, string expected)
        {
            KeyProperties properties = new KeyProperties();
            using (JsonStream json = new JsonStream(content))
            {
                properties.Deserialize(json.AsStream());
            }

            Assert.AreEqual(expected, properties.HsmPlatform);
        }
    }
}
