// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class IssuerTests
    {
        [Test]
        public void UninitializedAdministrators()
        {
            Issuer issuer = new Issuer("test")
            {
                AccountId = "accountId",
            };

            using JsonStream json = new JsonStream();
            using (Utf8JsonWriter writer = json.CreateWriter())
            {
                writer.WriteStartObject();

                ((IJsonSerializable)issuer).WriteProperties(writer);

                writer.WriteEndObject();
            }

            Assert.AreEqual(@"{""credentials"":{""account_id"":""accountId""}}", json.ToString());
        }

        [Test]
        public void InitializedAdministrators()
        {
            Issuer issuer = new Issuer("test")
            {
                AccountId = "accountId",
                Administrators =
                {
                    new AdministratorDetails
                    {
                        Email = "email@domain.tld",
                    },
                },
            };

            using JsonStream json = new JsonStream();
            using (Utf8JsonWriter writer = json.CreateWriter())
            {
                writer.WriteStartObject();

                ((IJsonSerializable)issuer).WriteProperties(writer);

                writer.WriteEndObject();
            }

            Assert.AreEqual(@"{""credentials"":{""account_id"":""accountId""},""org_details"":{""admin_details"":[{""email"":""email@domain.tld""}]}}", json.ToString());
        }
    }
}
