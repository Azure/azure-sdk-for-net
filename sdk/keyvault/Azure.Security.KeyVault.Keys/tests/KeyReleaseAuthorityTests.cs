// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class KeyReleaseAuthorityTests
    {
        [Test]
        public void KeyReleaseAuthorityUriNull()=> Assert.Throws<ArgumentNullException>(() => new KeyReleaseAuthority(null, null));

        [Test]
        public void KeyReleaseAuthorityConditionsNull() => Assert.Throws<ArgumentNullException>(() => new KeyReleaseAuthority(new Uri("https://myvault.vault.azure.net"), null));

        [Test]
        public void EmptyConditionsRoundtrips()
        {
            KeyReleaseAuthority original = new KeyReleaseAuthority(new Uri("https://myvault.vault.azure.net"), Enumerable.Empty<KeyReleaseCondition>());

            using JsonStream json = new JsonStream();
            using (Utf8JsonWriter writer = json.CreateWriter())
            {
                json.WriteObject(original);
            }

            json.Reset();

            KeyReleaseAuthority actual = new KeyReleaseAuthority();
            actual.Deserialize(json.AsStream());

            Assert.AreEqual("https://myvault.vault.azure.net/", actual.Uri.ToString());
            Assert.IsEmpty(actual.Conditions);
        }

        [Test]
        public void Roundtrips()
        {
            KeyReleaseAuthority original = new KeyReleaseAuthority(
                new Uri("https://myvault.vault.azure.net"),
                new[]
                {
                    new KeyReleaseCondition("name", "value"),
                });

            using JsonStream json = new JsonStream();
            using (Utf8JsonWriter writer = json.CreateWriter())
            {
                json.WriteObject(original);
            }

            json.Reset();

            KeyReleaseAuthority actual = new KeyReleaseAuthority();
            actual.Deserialize(json.AsStream());

            Assert.AreEqual("https://myvault.vault.azure.net/", actual.Uri.ToString());
            Assert.AreEqual(1, actual.Conditions.Count);

            KeyReleaseCondition condition0 = actual.Conditions[0];
            Assert.AreEqual("name", condition0.ClaimType);
            Assert.AreEqual("equals", condition0.ClaimCondition);
            Assert.AreEqual("value", condition0.Value);
        }
    }
}
