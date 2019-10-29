// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class CertificatePolicyTests
    {
        [Test]
        public void CertificatePolicyWithSubjectValidation()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new CertificatePolicy((string)null, null));
            Assert.AreEqual("subject", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new CertificatePolicy(string.Empty, null));
            Assert.AreEqual("subject", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => new CertificatePolicy("CN=contoso.com", null));
            Assert.AreEqual("issuerName", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new CertificatePolicy("CN=contoso.com", string.Empty));
            Assert.AreEqual("issuerName", ex.ParamName);
        }

        [Test]
        public void CertificatePolicyWithSubjectAlternativeNamesValidation()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new CertificatePolicy((SubjectAlternativeNames)null, null));
            Assert.AreEqual("subjectAlternativeNames", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => new CertificatePolicy("CN=contoso.com", null));
            Assert.AreEqual("issuerName", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new CertificatePolicy("CN=contoso.com", string.Empty));
            Assert.AreEqual("issuerName", ex.ParamName);
        }

        [Test]
        public void DeserializesSerializesRoundtrip()
        {
            string originalJson = @"{
    ""id"": ""https://testvault1021.vault.azure.net/certificates/updateCert01/policy"",
    ""key_props"": {
        ""kty"": ""RSA"",
        ""reuse_key"": false,
        ""exportable"": true,
        ""key_size"": 2048
    },
    ""secret_props"": {
        ""contentType"": ""application/x-pkcs12""
    },
    ""x509_props"": {
        ""subject"": ""CN=KeyVaultTest"",
        ""key_usage"": [],
        ""ekus"": [],
        ""validity_months"": 297,
        ""basic_constraints"": {
          ""ca"": false
        }
    },
    ""lifetime_actions"": [
        {
            ""trigger"": {
                ""lifetime_percentage"": 80
            },
            ""action"": {
                ""action_type"": ""EmailContacts""
            }
        }
    ],
    ""issuer"": {
        ""name"": ""Unknown""
    },
    ""attributes"": {
        ""enabled"": true,
        ""created"": 1482188947,
        ""updated"": 1482188947
    }
}";

            CertificatePolicy policy = new CertificatePolicy();
            using (JsonStream json = new JsonStream(originalJson))
            {
                policy.Deserialize(json.AsStream());
            }

            Assert.AreEqual(CertificateKeyType.Rsa, policy.KeyType);
            Assert.IsFalse(policy.ReuseKey);
            Assert.IsTrue(policy.Exportable);
            Assert.AreEqual(2048, policy.KeySize);
            Assert.AreEqual(CertificateContentType.Pkcs12, policy.ContentType);
            Assert.AreEqual("CN=KeyVaultTest", policy.Subject);
            Assert.NotNull(policy.KeyUsage);
            CollectionAssert.IsEmpty(policy.KeyUsage);
            Assert.NotNull(policy.EnhancedKeyUsage);
            CollectionAssert.IsEmpty(policy.EnhancedKeyUsage);
            Assert.AreEqual(297, policy.ValidityInMonths);
            Assert.NotNull(policy.LifetimeActions);
            Assert.AreEqual(1, policy.LifetimeActions.Count);
            Assert.AreEqual(80, policy.LifetimeActions[0].LifetimePercentage);
            Assert.AreEqual(Action.EmailContacts, policy.LifetimeActions[0].Action);
            Assert.AreEqual("Unknown", policy.IssuerName);
            Assert.IsTrue(policy.Enabled);
            Assert.AreEqual(DateTimeOffset.FromUnixTimeSeconds(1482188947), policy.Created);
            Assert.AreEqual(DateTimeOffset.FromUnixTimeSeconds(1482188947), policy.Updated);

            using (JsonStream json = new JsonStream())
            {
                JsonWriterOptions options = new JsonWriterOptions
                {
                    Indented = true,
                };

                json.WriteObject(policy, options);

                string expectedJson = @"{
  ""key_props"": {
    ""kty"": ""RSA"",
    ""reuse_key"": false,
    ""exportable"": true,
    ""key_size"": 2048
  },
  ""secret_props"": {
    ""contentType"": ""application/x-pkcs12""
  },
  ""x509_props"": {
    ""subject"": ""CN=KeyVaultTest"",
    ""key_usage"": [],
    ""ekus"": [],
    ""validity_months"": 297
  },
  ""issuer"": {
    ""name"": ""Unknown""
  },
  ""attributes"": {
    ""enabled"": true
  },
  ""lifetime_actions"": [
    {
      ""trigger"": {
        ""lifetime_percentage"": 80
      },
      ""action"": {
        ""action_type"": ""EmailContacts""
      }
    }
  ]
}";


                Assert.AreEqual(expectedJson, json.ToString());
            }
        }

        [Test]
        public void DisablePolicySerialized()
        {
            CertificatePolicy policy = new CertificatePolicy();

            using (JsonStream json = new JsonStream())
            {
                json.WriteObject(policy);

                Assert.AreEqual(@"{}", json.ToString());
            }

            policy.Enabled = false;

            using (JsonStream json = new JsonStream())
            {
                json.WriteObject(policy);

                Assert.AreEqual(@"{""attributes"":{""enabled"":false}}", json.ToString());
            }
        }
    }
}
