// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class KeyReleasePolicyTests
    {
        [Test]
        public void KeyReleasePolicyAuthoritiesNull() => Assert.Throws<ArgumentNullException>(() => new KeyReleasePolicy(null));

        [Test]
        public void EmptyAuthoritiesRoundtrips()
        {
            KeyReleasePolicy original = new KeyReleasePolicy(Enumerable.Empty<KeyReleaseAuthority>());

            using JsonStream json = new JsonStream();
            using (Utf8JsonWriter writer = json.CreateWriter())
            {
                json.WriteObject(original);
            }

            json.Reset();

            KeyReleasePolicy actual = new KeyReleasePolicy();
            actual.Deserialize(json.AsStream());

            Assert.IsEmpty(actual.Authorities);
        }

        [Test]
        public void Roundtrips()
        {
            KeyReleasePolicy original = new KeyReleasePolicy(
                new[]
                {
                    new KeyReleaseAuthority(
                        new Uri("https://myvault.vault.azure.net"),
                        new[]
                        {
                            new KeyReleaseCondition("name", "value"),
                        }),
                });

            using JsonStream json = new JsonStream();
            using (Utf8JsonWriter writer = json.CreateWriter())
            {
                json.WriteObject(original);
            }

            json.Reset();

            KeyReleasePolicy actual = new KeyReleasePolicy();
            actual.Deserialize(json.AsStream());

            Assert.AreEqual("0.2", actual.Version);
            Assert.AreEqual(1, actual.Authorities.Count);

            KeyReleaseAuthority authority0 = actual.Authorities[0];
            Assert.AreEqual("https://myvault.vault.azure.net/", authority0.Uri.ToString());
            Assert.AreEqual(1, authority0.Conditions.Count);

            KeyReleaseCondition condition0 = authority0.Conditions[0];
            Assert.AreEqual("name", condition0.ClaimType);
            Assert.AreEqual("equals", condition0.ClaimCondition);
            Assert.AreEqual("value", condition0.Value);
        }
    }
}
