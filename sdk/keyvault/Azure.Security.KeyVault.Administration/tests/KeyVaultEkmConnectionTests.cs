// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class KeyVaultEkmConnectionTests
    {
        private static readonly byte[] s_cert1 = new byte[] { 0x01, 0x02, 0x03 };
        private static readonly byte[] s_cert2 = new byte[] { 0x0A, 0x0B, 0x0C, 0x0D };

        [Test]
        public void NewHostNullThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(
                () => new KeyVaultEkmConnection(null, new[] { s_cert1 }));
            Assert.That(ex.ParamName, Is.EqualTo("hostName"));
        }

        [Test]
        public void NewHostEmptyThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => new KeyVaultEkmConnection(string.Empty, new[] { s_cert1 }));
            Assert.That(ex.ParamName, Is.EqualTo("hostName"));
        }

        [Test]
        public void NewServerCaCertificatesNullThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(
                () => new KeyVaultEkmConnection("ekm.contoso.com", (IEnumerable<byte[]>)null));
            Assert.That(ex.ParamName, Is.EqualTo("serverCaCertificates"));
        }

        [Test]
        public void NewBinaryDataHostNullThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(
                () => new KeyVaultEkmConnection(null, new[] { BinaryData.FromBytes(s_cert1) }));
            Assert.That(ex.ParamName, Is.EqualTo("hostName"));
        }

        [Test]
        public void NewBinaryDataHostEmptyThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => new KeyVaultEkmConnection(string.Empty, new[] { BinaryData.FromBytes(s_cert1) }));
            Assert.That(ex.ParamName, Is.EqualTo("hostName"));
        }

        [Test]
        public void NewBinaryDataServerCaCertificatesNullThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(
                () => new KeyVaultEkmConnection("ekm.contoso.com", (IEnumerable<BinaryData>)null));
            Assert.That(ex.ParamName, Is.EqualTo("serverCaCertificates"));
        }

        [Test]
        public void CtorBinaryData_PopulatesProperties()
        {
            KeyVaultEkmConnection connection = new("ekm.contoso.com", new[] { BinaryData.FromBytes(s_cert1), BinaryData.FromBytes(s_cert2) });

            Assert.That(connection.HostName, Is.EqualTo("ekm.contoso.com"));
            Assert.That(connection.ServerCaCertificates, Has.Count.EqualTo(2));
            CollectionAssert.AreEqual(s_cert1, connection.ServerCaCertificates[0].ToArray());
            CollectionAssert.AreEqual(s_cert2, connection.ServerCaCertificates[1].ToArray());
        }

        [Test]
        public void Ctor_PopulatesProperties()
        {
            KeyVaultEkmConnection connection = new("ekm.contoso.com", new[] { s_cert1, s_cert2 });

            Assert.That(connection.HostName, Is.EqualTo("ekm.contoso.com"));
            Assert.That(connection.ServerCaCertificates, Has.Count.EqualTo(2));
            CollectionAssert.AreEqual(s_cert1, connection.ServerCaCertificates[0].ToArray());
            CollectionAssert.AreEqual(s_cert2, connection.ServerCaCertificates[1].ToArray());
            Assert.That(connection.PathPrefix, Is.Null);
            Assert.That(connection.ServerSubjectCommonName, Is.Null);
        }

        [Test]
        public void OptionalProperties_AreSettable()
        {
            KeyVaultEkmConnection connection = new("ekm.contoso.com", new[] { s_cert1 })
            {
                PathPrefix = "/keys",
                ServerSubjectCommonName = "CN=ekm.contoso.com",
            };

            Assert.That(connection.PathPrefix, Is.EqualTo("/keys"));
            Assert.That(connection.ServerSubjectCommonName, Is.EqualTo("CN=ekm.contoso.com"));
        }
    }
}