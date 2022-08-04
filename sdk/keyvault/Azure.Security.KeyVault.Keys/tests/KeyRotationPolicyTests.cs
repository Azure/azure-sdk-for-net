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

            Assert.AreEqual("https://test.vault.azure.net/keys/key-name/rotationpolicy", sut.Id.AbsoluteUri);
            Assert.AreEqual(2, sut.LifetimeActions.Count);
            Assert.AreEqual(KeyRotationPolicyAction.Rotate, sut.LifetimeActions[0].Action);
            Assert.AreEqual("P30D", sut.LifetimeActions[0].TimeBeforeExpiry);
            Assert.IsNull(sut.LifetimeActions[0].TimeAfterCreate);
            Assert.AreEqual(KeyRotationPolicyAction.Notify, sut.LifetimeActions[1].Action);
            Assert.AreEqual("P25D", sut.LifetimeActions[1].TimeAfterCreate);
            Assert.IsNull(sut.LifetimeActions[1].TimeBeforeExpiry);
            Assert.AreEqual("P45D", sut.ExpiresIn);
            Assert.AreEqual(DateTimeOffset.Parse("2021-10-05T22:37:59.0000000+00:00"), sut.CreatedOn);
            Assert.AreEqual(DateTimeOffset.Parse("2021-10-05T22:38:24.0000000+00:00"), sut.UpdatedOn);
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

            Assert.AreEqual(@"{""lifetimeActions"":[],""attributes"":{""expiryTime"":""P45D""}}", json.ToString());
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

            Assert.AreEqual(@"{""lifetimeActions"":[{""trigger"":{""timeBeforeExpiry"":""P30D""},""action"":{""type"":""Rotate""}}],""attributes"":{""expiryTime"":""P45D""}}", json.ToString());
        }
    }
}
