// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class CertificateIssuerTests
    {
        [Test]
        public void UninitializedAdministrators()
        {
            CertificateIssuer issuer = new CertificateIssuer("test")
            {
                Provider = "provider",
                AccountId = "accountId",
            };

            using JsonStream json = new JsonStream();
            using (Utf8JsonWriter writer = json.CreateWriter())
            {
                writer.WriteStartObject();

                ((IJsonSerializable)issuer).WriteProperties(writer);

                writer.WriteEndObject();
            }

            Assert.AreEqual(@"{""provider"":""provider"",""credentials"":{""account_id"":""accountId""}}", json.ToString());
        }

        [Test]
        public void InitializedAdministrators()
        {
            CertificateIssuer issuer = new CertificateIssuer("test")
            {
                Provider = "provider",
                AccountId = "accountId",
                AdministratorContacts =
                {
                    new AdministratorContact
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

            Assert.AreEqual(@"{""provider"":""provider"",""credentials"":{""account_id"":""accountId""},""org_details"":{""admin_details"":[{""email"":""email@domain.tld""}]}}", json.ToString());
        }
    }
}
