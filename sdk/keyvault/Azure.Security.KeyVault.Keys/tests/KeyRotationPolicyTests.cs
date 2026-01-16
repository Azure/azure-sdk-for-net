// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class KeyRotationPolicyTests
    {
        [Test]
        public void Deserializes()
        {
            const string content = @"{
    ""id"": ""https://test.vault.azure.net/keys/key-name/rotationpolicy"",
    ""lifetimeActions"": [
        {
            ""trigger"": {
                ""timeBeforeExpiry"": ""P30D""
            },
            ""action"": {
                ""type"": ""Rotate""
            }
        },
        {
            ""trigger"": {
                ""timeAfterCreate"": ""P25D""
            },
            ""action"": {
                ""type"": ""Notify""
            }
        }
    ],
    ""attributes"": {
        ""expiryTime"": ""P45D"",
        ""created"": 1633473479,
        ""updated"": 1633473504
    }
}";

            KeyRotationPolicy sut = new();

            using (JsonStream json = new(content))
            {
                sut.Deserialize(json.AsStream());
            }

            Assert.That(sut.Id.AbsoluteUri, Is.EqualTo("https://test.vault.azure.net/keys/key-name/rotationpolicy"));
            Assert.That(sut.LifetimeActions.Count, Is.EqualTo(2));
            Assert.That(sut.LifetimeActions[0].Action, Is.EqualTo(KeyRotationPolicyAction.Rotate));
            Assert.That(sut.LifetimeActions[0].TimeBeforeExpiry, Is.EqualTo("P30D"));
            Assert.That(sut.LifetimeActions[0].TimeAfterCreate, Is.Null);
            Assert.That(sut.LifetimeActions[1].Action, Is.EqualTo(KeyRotationPolicyAction.Notify));
            Assert.That(sut.LifetimeActions[1].TimeAfterCreate, Is.EqualTo("P25D"));
            Assert.That(sut.LifetimeActions[1].TimeBeforeExpiry, Is.Null);
            Assert.That(sut.ExpiresIn, Is.EqualTo("P45D"));
            Assert.That(sut.CreatedOn, Is.EqualTo(DateTimeOffset.Parse("2021-10-05T22:37:59.0000000+00:00")));
            Assert.That(sut.UpdatedOn, Is.EqualTo(DateTimeOffset.Parse("2021-10-05T22:38:24.0000000+00:00")));
        }

        [Test]
        public void SerializesEmptyLifetimeActions()
        {
            KeyRotationPolicy sut = new()
            {
                ExpiresIn = "P45D",
                LifetimeActions = { },
            };

            using JsonStream json = new();
            json.WriteObject(sut);

            Assert.That(json.ToString(), Is.EqualTo(@"{""lifetimeActions"":[],""attributes"":{""expiryTime"":""P45D""}}"));
        }

        [Test]
        public void SerializesOnlyWritableProperties()
        {
            KeyRotationPolicy sut = new()
            {
                Id = new Uri("https://localhost"),
                ExpiresIn = "P45D",
                LifetimeActions =
                {
                    new KeyRotationLifetimeAction(KeyRotationPolicyAction.Rotate)
                    {
                        TimeBeforeExpiry= "P30D",
                    }
                },
                CreatedOn = DateTimeOffset.Now,
                UpdatedOn = DateTimeOffset.Now,
            };

            using JsonStream json = new();
            json.WriteObject(sut);

            Assert.That(json.ToString(), Is.EqualTo(@"{""lifetimeActions"":[{""trigger"":{""timeBeforeExpiry"":""P30D""},""action"":{""type"":""Rotate""}}],""attributes"":{""expiryTime"":""P45D""}}"));
        }
    }
}
