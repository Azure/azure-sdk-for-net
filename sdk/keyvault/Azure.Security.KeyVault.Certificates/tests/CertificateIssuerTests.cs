// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class CertificateIssuerTests
    {
        [Test]
        public void ConstructorArgumentValidation()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new CertificateIssuer((string)null));
            Assert.AreEqual("name", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new CertificateIssuer(string.Empty));
            Assert.AreEqual("name", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => new CertificateIssuer("test", null));
            Assert.AreEqual("provider", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new CertificateIssuer("test", string.Empty));
            Assert.AreEqual("provider", ex.ParamName);
        }

        [Test]
        public void UninitializedAdministrators()
        {
            CertificateIssuer issuer = new CertificateIssuer("test", "provider")
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

            Assert.AreEqual(@"{""provider"":""provider"",""credentials"":{""account_id"":""accountId""}}", json.ToString());
        }

        [Test]
        public void InitializedAdministrators()
        {
            const string expectedJson = @"{""provider"":""provider"",""credentials"":{""account_id"":""accountId""},""org_details"":{""admin_details"":[{""first_name"":""fName"",""last_name"":""lName"",""email"":""email@domain.tld"",""phone"":""1234""}]}}";
            CertificateIssuer issuer = new CertificateIssuer("test", "provider")
            {
                AccountId = "accountId",
                AdministratorContacts =
                {
                    new AdministratorContact
                    {
                        Email = "email@domain.tld",
                        FirstName ="fName",
                        LastName = "lName",
                        Phone = "1234"
                    },
                },
            };

            // Serialize the CertificateIssuer.
            using JsonStream json = new JsonStream();
            using (Utf8JsonWriter writer = json.CreateWriter())
            {
                writer.WriteStartObject();

                ((IJsonSerializable)issuer).WriteProperties(writer);

                writer.WriteEndObject();
            }

            // Assert that the CertificateIssuer was serialized properly.
            Assert.That(expectedJson, Is.EqualTo(json.ToString()));

            // De-Serialze the CertificateIssuer.
            var jDoc = JsonDocument.Parse(expectedJson);
            CertificateIssuer deserializedIssuer = new CertificateIssuer();
            ((IJsonDeserializable)deserializedIssuer).ReadProperties(jDoc.RootElement);

            // Assert that the CertificateIssuer was de-serialized properly.
            Assert.That(deserializedIssuer.AccountId, Is.EqualTo(issuer.AccountId));
            Assert.That(deserializedIssuer.AdministratorContacts[0].Email, Is.EqualTo(issuer.AdministratorContacts[0].Email));
            Assert.That(deserializedIssuer.AdministratorContacts[0].FirstName, Is.EqualTo(issuer.AdministratorContacts[0].FirstName));
            Assert.That(deserializedIssuer.AdministratorContacts[0].LastName, Is.EqualTo(issuer.AdministratorContacts[0].LastName));
            Assert.That(deserializedIssuer.AdministratorContacts[0].Phone, Is.EqualTo(issuer.AdministratorContacts[0].Phone));
        }

        [Test]
        public void NameDeSerialization()
        {
            const string name = "2100662614";
            Uri id = new Uri($"https://some.vault.azure.net/certificates/issuers/{name}");
            const string accountId = "accountId";
            const string firstName = "fName";
            const string lastName = "lName";
            const string email = "email@domain.tld";
            const string phone = "123-123-1234";

            string expectedJson = $@"{{""id"":""{id.AbsoluteUri}"",""provider"":""ssladmin"",""credentials"":{{""account_id"":""{accountId}""}},""org_details"":{{""zip"":0,""admin_details"":[{{""first_name"":""{firstName}"",""last_name"":""{lastName}"",""email"":""{email}"",""phone"":""{phone}""}}]}},""attributes"":{{""enabled"":true,""created"":1592839861,""updated"":1592839861}}}}";

            // De-Serialze the CertificateIssuer.
            var jDoc = JsonDocument.Parse(expectedJson);
            CertificateIssuer deserializedIssuer = new CertificateIssuer();
            ((IJsonDeserializable)deserializedIssuer).ReadProperties(jDoc.RootElement);

            // Assert that the CertificateIssuer was de-serialized properly.
            Assert.That(deserializedIssuer.Id, Is.EqualTo(id));
            Assert.That(deserializedIssuer.Name, Is.EqualTo(name));
            Assert.That(deserializedIssuer.AccountId, Is.EqualTo(accountId));
            Assert.That(deserializedIssuer.AdministratorContacts[0].Email, Is.EqualTo(email));
            Assert.That(deserializedIssuer.AdministratorContacts[0].FirstName, Is.EqualTo(firstName));
            Assert.That(deserializedIssuer.AdministratorContacts[0].LastName, Is.EqualTo(lastName));
            Assert.That(deserializedIssuer.AdministratorContacts[0].Phone, Is.EqualTo(phone));
        }
    }
}
