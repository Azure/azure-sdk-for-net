// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Net;
using System.Text.Json;
using Azure.ResourceManager.NetApp.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.NetApp.Tests
{
    public class LdapConfigurationSerializationTests
    {
        private static readonly ModelReaderWriterOptions WireOptions = new ModelReaderWriterOptions("W");

        [Test]
        public void SerializeWritesCurrentLdapPropertiesAndPrefersSecureLdapType()
        {
            var configuration = new LdapConfiguration
            {
                Domain = "contoso.com",
                IsLdapOverTlsEnabled = false,
                SecureLdapType = SecureLdapType.LdapOverTls,
                ServerCACertificate = "certificate",
                CertificateCNHost = "ldap.contoso.com",
                LdapPort = 636,
                UserDN = "ou=users,dc=contoso,dc=com",
                GroupDN = "ou=groups,dc=contoso,dc=com",
                NetGroupDN = "ou=netgroups,dc=contoso,dc=com",
                BindAuthenticationLevel = BindAuthenticationLevel.Simple,
                BindDN = "cn=reader,dc=contoso,dc=com"
            };
            configuration.LdapServers.Add(IPAddress.Parse("10.0.0.4"));
            configuration.DnsServers.Add(IPAddress.Parse("10.0.0.5"));

            using JsonDocument document = Serialize(configuration);
            JsonElement root = document.RootElement;

            Assert.That(root.GetProperty("domain").GetString(), Is.EqualTo("contoso.com"));
            Assert.That(root.GetProperty("ldapServers")[0].GetString(), Is.EqualTo("10.0.0.4"));
            Assert.That(root.GetProperty("secureLdapType").GetString(), Is.EqualTo("LdapOverTLS"));
            Assert.That(root.GetProperty("serverCACertificate").GetString(), Is.EqualTo("certificate"));
            Assert.That(root.GetProperty("certificateCNHost").GetString(), Is.EqualTo("ldap.contoso.com"));
            Assert.That(root.GetProperty("dnsServers")[0].GetString(), Is.EqualTo("10.0.0.5"));
            Assert.That(root.GetProperty("ldapPort").GetInt32(), Is.EqualTo(636));
            Assert.That(root.GetProperty("userDN").GetString(), Is.EqualTo("ou=users,dc=contoso,dc=com"));
            Assert.That(root.GetProperty("groupDN").GetString(), Is.EqualTo("ou=groups,dc=contoso,dc=com"));
            Assert.That(root.GetProperty("netGroupDN").GetString(), Is.EqualTo("ou=netgroups,dc=contoso,dc=com"));
            Assert.That(root.GetProperty("bindAuthenticationLevel").GetString(), Is.EqualTo("Simple"));
            Assert.That(root.GetProperty("bindDN").GetString(), Is.EqualTo("cn=reader,dc=contoso,dc=com"));
            Assert.That(root.TryGetProperty("isLdapOverTlsEnabled", out _), Is.False);
        }

        [TestCase(true, "LdapOverTLS")]
        [TestCase(false, "None")]
        public void SerializeMapsLegacyTlsSettingToSecureLdapType(bool isEnabled, string expected)
        {
            var configuration = new LdapConfiguration
            {
                IsLdapOverTlsEnabled = isEnabled
            };

            using JsonDocument document = Serialize(configuration);

            Assert.That(document.RootElement.GetProperty("secureLdapType").GetString(), Is.EqualTo(expected));
            Assert.That(document.RootElement.TryGetProperty("isLdapOverTlsEnabled", out _), Is.False);
        }

        [Test]
        public void SerializeAccountIncludesLdapConfiguration()
        {
            var account = new NetAppAccountData("westus2")
            {
                LdapConfiguration = new LdapConfiguration
                {
                    Domain = "contoso.com",
                    SecureLdapType = SecureLdapType.LdapOverTls
                }
            };

            using JsonDocument document = Serialize(account);
            JsonElement ldapConfiguration = document.RootElement.GetProperty("properties").GetProperty("ldapConfiguration");

            Assert.That(ldapConfiguration.GetProperty("domain").GetString(), Is.EqualTo("contoso.com"));
            Assert.That(ldapConfiguration.GetProperty("secureLdapType").GetString(), Is.EqualTo("LdapOverTLS"));
            Assert.That(ldapConfiguration.EnumerateObject().GetEnumerator().MoveNext(), Is.True);
        }

        private static JsonDocument Serialize<T>(T model)
        {
            BinaryData data = ModelReaderWriter.Write(model, WireOptions, AzureResourceManagerNetAppContext.Default);
            return JsonDocument.Parse(data);
        }
    }
}
