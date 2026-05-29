// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
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
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new CertificatePolicy(null, (string)null));
            Assert.AreEqual("issuerName", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new CertificatePolicy(string.Empty, (string)null));
            Assert.AreEqual("issuerName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => new CertificatePolicy("Self", (string)null));
            Assert.AreEqual("subject", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new CertificatePolicy("Self", string.Empty));
            Assert.AreEqual("subject", ex.ParamName);
        }

        [Test]
        public void CertificatePolicyWithSubjectAlternativeNamesValidation()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new CertificatePolicy(null, (SubjectAlternativeNames)null));
            Assert.AreEqual("issuerName", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new CertificatePolicy(string.Empty, "CN=contoso.com"));
            Assert.AreEqual("issuerName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => new CertificatePolicy("Self", (SubjectAlternativeNames)null));
            Assert.AreEqual("subjectAlternativeNames", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new CertificatePolicy("Self", new SubjectAlternativeNames()));
            Assert.AreEqual("subjectAlternativeNames", ex.ParamName);
        }

        [Test]
        public void CertificatePolicyWithSubjectAndSubjectAlternativeNamesValidation()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new CertificatePolicy(null, null, null));
            Assert.AreEqual("issuerName", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new CertificatePolicy(string.Empty, null, null));
            Assert.AreEqual("issuerName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => new CertificatePolicy("Self", null, null));
            Assert.AreEqual("subject", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new CertificatePolicy("Self", string.Empty, null));
            Assert.AreEqual("subject", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => new CertificatePolicy("Self", (SubjectAlternativeNames)null));
            Assert.AreEqual("subjectAlternativeNames", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new CertificatePolicy("Self", new SubjectAlternativeNames()));
            Assert.AreEqual("subjectAlternativeNames", ex.ParamName);
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
            Assert.AreEqual(CertificatePolicyAction.EmailContacts, policy.LifetimeActions[0].Action);
            Assert.AreEqual("Unknown", policy.IssuerName);
            Assert.IsTrue(policy.Enabled);
            Assert.AreEqual(DateTimeOffset.FromUnixTimeSeconds(1482188947), policy.CreatedOn);
            Assert.AreEqual(DateTimeOffset.FromUnixTimeSeconds(1482188947), policy.UpdatedOn);

            const string expectedJson = @"{
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

            using JsonStream expectedStream = new JsonStream();
            using (Utf8JsonWriter expectedWriter = expectedStream.CreateWriter())
            {
                using JsonDocument expectedDocument = JsonDocument.Parse(expectedJson);
                expectedDocument.WriteTo(expectedWriter);
            }

            using JsonStream actualStream = new JsonStream();
            actualStream.WriteObject(policy);

            Assert.AreEqual(expectedStream.ToString(), actualStream.ToString());
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

        [Test]
        public void PlatformManagedDeserializesSerializesRoundtrip()
        {
            string originalJson = @"{
    ""platformManaged"": {
        ""certificateUsage"": ""AzureFrontDoor"",
        ""metadata"": {
            ""provider"": ""contoso"",
            ""enabled"": true,
            ""settings"": {
                ""region"": ""westus""
            }
        }
    }
}";

            CertificatePolicy policy = new CertificatePolicy();
            using (JsonStream json = new JsonStream(originalJson))
            {
                policy.Deserialize(json.AsStream());
            }

            Assert.NotNull(policy.PlatformManaged);
            Assert.AreEqual("AzureFrontDoor", policy.PlatformManaged.CertificateUsage);
            Assert.AreEqual(@"""contoso""", policy.PlatformManaged.Metadata["provider"].ToString());
            Assert.AreEqual("true", policy.PlatformManaged.Metadata["enabled"].ToString());
            using (JsonDocument settings = JsonDocument.Parse(policy.PlatformManaged.Metadata["settings"].ToString()))
            {
                Assert.AreEqual("westus", settings.RootElement.GetProperty("region").GetString());
            }

            const string expectedJson = @"{
  ""platformManaged"": {
    ""certificateUsage"": ""AzureFrontDoor"",
    ""metadata"": {
      ""provider"": ""contoso"",
      ""enabled"": true,
      ""settings"": {
        ""region"": ""westus""
      }
    }
  }
}";

            using JsonStream expectedStream = new JsonStream();
            using (Utf8JsonWriter expectedWriter = expectedStream.CreateWriter())
            {
                using JsonDocument expectedDocument = JsonDocument.Parse(expectedJson);
                expectedDocument.WriteTo(expectedWriter);
            }

            using JsonStream actualStream = new JsonStream();
            actualStream.WriteObject(policy);

            Assert.AreEqual(expectedStream.ToString(), actualStream.ToString());
        }

        [Test]
        public void PlatformManagedSerialized()
        {
            CertificatePolicy policy = new CertificatePolicy
            {
                PlatformManaged = new PlatformManaged("AzureFrontDoor"),
            };
            policy.PlatformManaged.Metadata["provider"] = BinaryData.FromString(@"""contoso""");
            policy.PlatformManaged.Metadata["enabled"] = BinaryData.FromString("true");
            policy.PlatformManaged.Metadata["settings"] = BinaryData.FromString(@"{""region"":""westus""}");

            using JsonStream json = new JsonStream();
            json.WriteObject(policy);

            Assert.AreEqual(@"{""platformManaged"":{""certificateUsage"":""AzureFrontDoor"",""metadata"":{""provider"":""contoso"",""enabled"":true,""settings"":{""region"":""westus""}}}}", json.ToString());
        }

        [Test]
        public void PlatformManagedConstructorValidation()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new PlatformManaged(null));
            Assert.AreEqual("certificateUsage", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new PlatformManaged(string.Empty));
            Assert.AreEqual("certificateUsage", ex.ParamName);
        }

        [Test]
        public void PlatformManagedSerializedWithoutMetadataOmitsMetadataProperty()
        {
            CertificatePolicy policy = new CertificatePolicy
            {
                PlatformManaged = new PlatformManaged("AzureFrontDoor"),
            };

            using JsonStream json = new JsonStream();
            json.WriteObject(policy);

            Assert.AreEqual(@"{""platformManaged"":{""certificateUsage"":""AzureFrontDoor""}}", json.ToString());
        }

        [Test]
        public void CertificatePolicyWithoutPlatformManagedOmitsProperty()
        {
            CertificatePolicy policy = new CertificatePolicy();

            using JsonStream json = new JsonStream();
            json.WriteObject(policy);

            Assert.IsNull(policy.PlatformManaged);
            StringAssert.DoesNotContain("platformManaged", json.ToString());
        }

        [Test]
        public void PlatformManagedDeserializesNullValueAsNull()
        {
            const string originalJson = @"{""platformManaged"":null}";

            CertificatePolicy policy = new CertificatePolicy();
            using (JsonStream json = new JsonStream(originalJson))
            {
                policy.Deserialize(json.AsStream());
            }

            Assert.IsNull(policy.PlatformManaged);
        }

        [Test]
        public void PlatformManagedDeserializesEmptyMetadataAsEmpty()
        {
            const string originalJson = @"{""platformManaged"":{""certificateUsage"":""AzureFrontDoor"",""metadata"":{}}}";

            CertificatePolicy policy = new CertificatePolicy();
            using (JsonStream json = new JsonStream(originalJson))
            {
                policy.Deserialize(json.AsStream());
            }

            Assert.NotNull(policy.PlatformManaged);
            Assert.AreEqual("AzureFrontDoor", policy.PlatformManaged.CertificateUsage);
            Assert.AreEqual(0, policy.PlatformManaged.Metadata.Count);

            // An empty metadata dictionary must NOT be re-emitted as a "metadata" block.
            using JsonStream output = new JsonStream();
            output.WriteObject(policy);
            Assert.AreEqual(@"{""platformManaged"":{""certificateUsage"":""AzureFrontDoor""}}", output.ToString());
        }

        [Test]
        public void PlatformManagedDeserializesNullMetadataValue()
        {
            const string originalJson = @"{""platformManaged"":{""certificateUsage"":""AzureFrontDoor"",""metadata"":null}}";

            CertificatePolicy policy = new CertificatePolicy();
            using (JsonStream json = new JsonStream(originalJson))
            {
                policy.Deserialize(json.AsStream());
            }

            Assert.NotNull(policy.PlatformManaged);
            Assert.AreEqual("AzureFrontDoor", policy.PlatformManaged.CertificateUsage);
            Assert.AreEqual(0, policy.PlatformManaged.Metadata.Count);
        }

        [Test]
        public void PlatformManagedMetadataIsLazyInitialized()
        {
            PlatformManaged platformManaged = new PlatformManaged("AzureFrontDoor");
            Assert.NotNull(platformManaged.Metadata);
            Assert.AreEqual(0, platformManaged.Metadata.Count);

            // Ensure the same reference is returned on subsequent access (LazyInitializer behavior).
            Assert.AreSame(platformManaged.Metadata, platformManaged.Metadata);
        }

        [Test]
        public void PlatformManagedCertificateUsageIsMutable()
        {
            PlatformManaged platformManaged = new PlatformManaged("AzureFrontDoor");
            Assert.AreEqual("AzureFrontDoor", platformManaged.CertificateUsage);

            platformManaged.CertificateUsage = "AzureApplicationGateway";
            Assert.AreEqual("AzureApplicationGateway", platformManaged.CertificateUsage);
        }

        public static object[] KeyPolicySerializationTestCases =
        {
            new object[] {new CertificatePolicy() { KeyType = CertificateKeyType.Rsa }, @"{""key_props"":{""kty"":""RSA""}}" },
            new object[] {new CertificatePolicy() { ReuseKey = false }, @"{""key_props"":{""reuse_key"":false}}" },
            new object[] {new CertificatePolicy() { Exportable = false }, @"{""key_props"":{""exportable"":false}}" },
            new object[] {new CertificatePolicy() { KeyCurveName = CertificateKeyCurveName.P256 }, @"{""key_props"":{""crv"":""P-256""}}" },
            new object[] {new CertificatePolicy() { KeySize = 2048 }, @"{""key_props"":{""key_size"":2048}}" },
        };

        [Test]
        [TestCaseSource(nameof(KeyPolicySerializationTestCases))]
        public void KeyPolicySerialized(CertificatePolicy policy, string expectedJson)
        {
            using (JsonStream json = new JsonStream())
            {
                json.WriteObject(policy);

                Assert.That(json.ToString(), Is.EqualTo(expectedJson));
            }
        }

        [Test]
        public void DefaultWithSubjectName()
        {
            CertificatePolicy expected = new CertificatePolicy("Self", "CN=DefaultPolicy");
            AssertAreEqual(expected, CertificatePolicy.Default);
        }

        private static void AssertAreEqual(CertificatePolicy expected, CertificatePolicy actual)
        {
            Assert.AreEqual(expected.Subject, actual.Subject);
            AssertAreEqual(expected.SubjectAlternativeNames, actual.SubjectAlternativeNames);
            Assert.AreEqual(expected.IssuerName, actual.IssuerName);

            Assert.AreEqual(expected.CertificateTransparency, actual.CertificateTransparency);
            Assert.AreEqual(expected.CertificateType, actual.CertificateType);
            Assert.AreEqual(expected.ContentType, actual.ContentType);
            AssertAreEqual(expected.PlatformManaged, actual.PlatformManaged);
            Assert.AreEqual(expected.CreatedOn, actual.CreatedOn);
            Assert.AreEqual(expected.Enabled, actual.Enabled);
            CollectionAssert.AreEqual(expected.EnhancedKeyUsage, actual.EnhancedKeyUsage);
            Assert.AreEqual(expected.Exportable, actual.Exportable);
            Assert.AreEqual(expected.KeyCurveName, actual.KeyCurveName);
            Assert.AreEqual(expected.KeySize, actual.KeySize);
            Assert.AreEqual(expected.KeyType, actual.KeyType);
            CollectionAssert.AreEqual(expected.KeyUsage, actual.KeyUsage);
            CollectionAssert.AreEqual(expected.LifetimeActions, actual.LifetimeActions, LifetimeActionComparer.Instance);
            Assert.AreEqual(expected.ReuseKey, actual.ReuseKey);
            Assert.AreEqual(expected.UpdatedOn, actual.UpdatedOn);
            Assert.AreEqual(expected.ValidityInMonths, actual.ValidityInMonths);
        }

        private static void AssertAreEqual(SubjectAlternativeNames expected, SubjectAlternativeNames actual)
        {
            CollectionAssert.AreEqual(expected?.DnsNames, actual?.DnsNames, StringComparer.Ordinal);
            CollectionAssert.AreEqual(expected?.Emails, actual?.Emails, StringComparer.Ordinal);
            CollectionAssert.AreEqual(expected?.UserPrincipalNames, actual?.UserPrincipalNames, StringComparer.Ordinal);
            CollectionAssert.AreEqual(expected?.UniformResourceIdentifiers, actual?.UniformResourceIdentifiers, StringComparer.Ordinal);
            CollectionAssert.AreEqual(expected?.IpAddresses, actual?.IpAddresses, StringComparer.Ordinal);
        }

        private static void AssertAreEqual(PlatformManaged expected, PlatformManaged actual)
        {
            Assert.AreEqual(expected?.CertificateUsage, actual?.CertificateUsage);

            if (expected is null)
            {
                Assert.IsNull(actual);
                return;
            }

            Assert.NotNull(actual);
            Assert.AreEqual(expected.Metadata.Count, actual.Metadata.Count);
            foreach (KeyValuePair<string, BinaryData> metadata in expected.Metadata)
            {
                Assert.AreEqual(metadata.Value?.ToString(), actual.Metadata[metadata.Key]?.ToString());
            }
        }

        private class LifetimeActionComparer : IComparer<LifetimeAction>, IComparer
        {
            public static readonly LifetimeActionComparer Instance = new LifetimeActionComparer();

            public int Compare(LifetimeAction x, LifetimeAction y)
            {
                int comparison = Comparer<CertificatePolicyAction>.Default.Compare(x.Action, y.Action);
                if (comparison != 0)
                {
                    return comparison;
                }

                comparison = Comparer<int?>.Default.Compare(x.DaysBeforeExpiry, y.DaysBeforeExpiry);
                if (comparison != 0)
                {
                    return comparison;
                }

                return Comparer<int?>.Default.Compare(x.LifetimePercentage, y.LifetimePercentage);
            }

            public int Compare(object x, object y)
            {
                if (ReferenceEquals(x, y))
                {
                    return 0;
                }

                if (x is LifetimeAction left)
                {
                    if (y is LifetimeAction right)
                    {
                        return Compare(left, right);
                    }

                    return 1;
                }

                return -1;
            }
        }
    }
}
