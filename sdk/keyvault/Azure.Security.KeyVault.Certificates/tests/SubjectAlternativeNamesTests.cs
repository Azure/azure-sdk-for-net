// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class SubjectAlternativeNamesTests
    {
        [Test]
        public void NewIsEmpty()
        {
            SubjectAlternativeNames subjectAlternativeNames = new SubjectAlternativeNames();
            Assert.IsTrue(subjectAlternativeNames.IsEmpty);
        }

        [TestCaseSource(nameof(GetSubjectAlternativeNames))]
        public void AreEqual(SubjectAlternativeNames actual, string expectedJson)
        {
            Assert.IsFalse(actual.IsEmpty);

            using JsonStream json = new JsonStream();
            json.WriteObject(actual);

            string actualJson = json.ToString();
            Assert.AreEqual(expectedJson, actualJson);
        }

        private static IEnumerable GetSubjectAlternativeNames()
        {
            yield return new object[] { new SubjectAlternativeNames { DnsNames = { "www.example.com" }, Emails = { } }, @"{""dns_names"":[""www.example.com""]}" };
            yield return new object[] { new SubjectAlternativeNames { DnsNames = { }, Emails = { "webmaster@example.com" } }, @"{""emails"":[""webmaster@example.com""]}" };
            yield return new object[] { new SubjectAlternativeNames { DnsNames = { }, UserPrincipalNames = { "webmaster@example.com" } }, @"{""upns"":[""webmaster@example.com""]}" };
            yield return new object[] { new SubjectAlternativeNames { DnsNames = { }, UniformResourceIdentifiers = { "www.example.com" } }, @"{""uris"":[""www.example.com""]}" };
            yield return new object[] { new SubjectAlternativeNames { DnsNames = { }, IpAddresses = { "127.0.0.1", "1:db8:4006:812::e" } }, @"{""ipAddresses"":[""127.0.0.1"",""1:db8:4006:812::e""]}" };
            yield return new object[] {
                new SubjectAlternativeNames
                {
                    DnsNames =
                    {
                        "example.com",
                        "www.example.com",
                    },

                    Emails =
                    {
                        "webmaster@example.com",
                    },

                    UserPrincipalNames =
                    {
                        "webmaster@example.com",
                    },

                    UniformResourceIdentifiers =
                    {
                        "www.example.com",
                    },

                    IpAddresses =
                    {
                        "127.0.0.1",
                        "1:db8:4006:812::e"
                    },
                },

                @"{""dns_names"":[""example.com"",""www.example.com""],""emails"":[""webmaster@example.com""],""upns"":[""webmaster@example.com""],""uris"":[""www.example.com""],""ipAddresses"":[""127.0.0.1"",""1:db8:4006:812::e""]}"
            };

            SubjectAlternativeNames san1 = new SubjectAlternativeNames
            {
                DnsNames =
                    {
                        "example.com",
                        "www.example.com",
                    },

                Emails =
                    {
                        "webmaster@example.com",
                    },
            };

            san1.DnsNames.Clear();
            yield return new object[] { san1, @"{""emails"":[""webmaster@example.com""]}" };
        }
    }
}
