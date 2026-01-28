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
            Assert.That(ex.ParamName, Is.EqualTo("issuerName"));

            ex = Assert.Throws<ArgumentException>(() => new CertificatePolicy(string.Empty, (string)null));
            Assert.That(ex.ParamName, Is.EqualTo("issuerName"));

            ex = Assert.Throws<ArgumentNullException>(() => new CertificatePolicy("Self", (string)null));
            Assert.That(ex.ParamName, Is.EqualTo("subject"));

            ex = Assert.Throws<ArgumentException>(() => new CertificatePolicy("Self", string.Empty));
            Assert.That(ex.ParamName, Is.EqualTo("subject"));
        }

        [Test]
        public void CertificatePolicyWithSubjectAlternativeNamesValidation()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new CertificatePolicy(null, (SubjectAlternativeNames)null));
            Assert.That(ex.ParamName, Is.EqualTo("issuerName"));

            ex = Assert.Throws<ArgumentException>(() => new CertificatePolicy(string.Empty, "CN=contoso.com"));
            Assert.That(ex.ParamName, Is.EqualTo("issuerName"));

            ex = Assert.Throws<ArgumentNullException>(() => new CertificatePolicy("Self", (SubjectAlternativeNames)null));
            Assert.That(ex.ParamName, Is.EqualTo("subjectAlternativeNames"));

            ex = Assert.Throws<ArgumentException>(() => new CertificatePolicy("Self", new SubjectAlternativeNames()));
            Assert.That(ex.ParamName, Is.EqualTo("subjectAlternativeNames"));
        }

        [Test]
        public void CertificatePolicyWithSubjectAndSubjectAlternativeNamesValidation()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new CertificatePolicy(null, null, null));
            Assert.That(ex.ParamName, Is.EqualTo("issuerName"));

            ex = Assert.Throws<ArgumentException>(() => new CertificatePolicy(string.Empty, null, null));
            Assert.That(ex.ParamName, Is.EqualTo("issuerName"));

            ex = Assert.Throws<ArgumentNullException>(() => new CertificatePolicy("Self", null, null));
            Assert.That(ex.ParamName, Is.EqualTo("subject"));

            ex = Assert.Throws<ArgumentException>(() => new CertificatePolicy("Self", string.Empty, null));
            Assert.That(ex.ParamName, Is.EqualTo("subject"));

            ex = Assert.Throws<ArgumentNullException>(() => new CertificatePolicy("Self", (SubjectAlternativeNames)null));
            Assert.That(ex.ParamName, Is.EqualTo("subjectAlternativeNames"));

            ex = Assert.Throws<ArgumentException>(() => new CertificatePolicy("Self", new SubjectAlternativeNames()));
            Assert.That(ex.ParamName, Is.EqualTo("subjectAlternativeNames"));
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

            Assert.That(policy.KeyType, Is.EqualTo(CertificateKeyType.Rsa));
            Assert.That(policy.ReuseKey, Is.False);
            Assert.That(policy.Exportable, Is.True);
            Assert.That(policy.KeySize, Is.EqualTo(2048));
            Assert.That(policy.ContentType, Is.EqualTo(CertificateContentType.Pkcs12));
            Assert.That(policy.Subject, Is.EqualTo("CN=KeyVaultTest"));
            Assert.That(policy.KeyUsage, Is.Not.Null);
            Assert.That(policy.KeyUsage, Is.Empty);
            Assert.That(policy.EnhancedKeyUsage, Is.Not.Null);
            Assert.That(policy.EnhancedKeyUsage, Is.Empty);
            Assert.That(policy.ValidityInMonths, Is.EqualTo(297));
            Assert.That(policy.LifetimeActions, Is.Not.Null);
            Assert.That(policy.LifetimeActions.Count, Is.EqualTo(1));
            Assert.That(policy.LifetimeActions[0].LifetimePercentage, Is.EqualTo(80));
            Assert.That(policy.LifetimeActions[0].Action, Is.EqualTo(CertificatePolicyAction.EmailContacts));
            Assert.That(policy.IssuerName, Is.EqualTo("Unknown"));
            Assert.That(policy.Enabled, Is.True);
            Assert.That(policy.CreatedOn, Is.EqualTo(DateTimeOffset.FromUnixTimeSeconds(1482188947)));
            Assert.That(policy.UpdatedOn, Is.EqualTo(DateTimeOffset.FromUnixTimeSeconds(1482188947)));

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

            Assert.That(actualStream.ToString(), Is.EqualTo(expectedStream.ToString()));
        }

        [Test]
        public void DisablePolicySerialized()
        {
            CertificatePolicy policy = new CertificatePolicy();

            using (JsonStream json = new JsonStream())
            {
                json.WriteObject(policy);

                Assert.That(json.ToString(), Is.EqualTo(@"{}"));
            }

            policy.Enabled = false;

            using (JsonStream json = new JsonStream())
            {
                json.WriteObject(policy);

                Assert.That(json.ToString(), Is.EqualTo(@"{""attributes"":{""enabled"":false}}"));
            }
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
            Assert.That(actual.Subject, Is.EqualTo(expected.Subject));
            AssertAreEqual(expected.SubjectAlternativeNames, actual.SubjectAlternativeNames);
            Assert.That(actual.IssuerName, Is.EqualTo(expected.IssuerName));

            Assert.That(actual.CertificateTransparency, Is.EqualTo(expected.CertificateTransparency));
            Assert.That(actual.CertificateType, Is.EqualTo(expected.CertificateType));
            Assert.That(actual.ContentType, Is.EqualTo(expected.ContentType));
            Assert.That(actual.CreatedOn, Is.EqualTo(expected.CreatedOn));
            Assert.That(actual.Enabled, Is.EqualTo(expected.Enabled));
            Assert.That(actual.EnhancedKeyUsage, Is.EqualTo(expected.EnhancedKeyUsage).AsCollection);
            Assert.That(actual.Exportable, Is.EqualTo(expected.Exportable));
            Assert.That(actual.KeyCurveName, Is.EqualTo(expected.KeyCurveName));
            Assert.That(actual.KeySize, Is.EqualTo(expected.KeySize));
            Assert.That(actual.KeyType, Is.EqualTo(expected.KeyType));
            Assert.That(actual.KeyUsage, Is.EqualTo(expected.KeyUsage).AsCollection);
            Assert.That(actual.LifetimeActions, Is.EqualTo(expected.LifetimeActions).Using(LifetimeActionComparer.Instance));
            Assert.That(actual.ReuseKey, Is.EqualTo(expected.ReuseKey));
            Assert.That(actual.UpdatedOn, Is.EqualTo(expected.UpdatedOn));
            Assert.That(actual.ValidityInMonths, Is.EqualTo(expected.ValidityInMonths));
        }

        private static void AssertAreEqual(SubjectAlternativeNames expected, SubjectAlternativeNames actual)
        {
            Assert.That(actual?.DnsNames, Is.EqualTo(expected?.DnsNames).Using((IEqualityComparer<string>)StringComparer.Ordinal));
            Assert.That(actual?.Emails, Is.EqualTo(expected?.Emails).Using((IEqualityComparer<string>)StringComparer.Ordinal));
            Assert.That(actual?.UserPrincipalNames, Is.EqualTo(expected?.UserPrincipalNames).Using((IEqualityComparer<string>)StringComparer.Ordinal));
            Assert.That(actual?.UniformResourceIdentifiers, Is.EqualTo(expected?.UniformResourceIdentifiers).Using((IEqualityComparer<string>)StringComparer.Ordinal));
            Assert.That(actual?.IpAddresses, Is.EqualTo(expected?.IpAddresses).Using((IEqualityComparer<string>)StringComparer.Ordinal));
        }

        private class LifetimeActionComparer : IComparer<LifetimeAction>
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
