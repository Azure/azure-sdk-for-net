//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using Microsoft.Azure.KeyVault;
using Xunit;

namespace KeyVault.ObjectIdentifier.Tests
{
    public class ObjectIdentifierTests
    {
        string vault = "https://myvault.vault.azure.net:443";
        string name = "myname";
        string version = "myversion";
        [Fact]
        public void KeyIdentifierTest()
        {
            string baseId = string.Format("{0}/keys/{1}", vault, name);
            string versionedId = string.Format("{0}/{1}", baseId, version);

            //unversioned
            var id = new KeyIdentifier(baseId);
            Assert.Equal(baseId, id.BaseIdentifier);
            Assert.Equal(baseId, id.Identifier);
            Assert.Equal(vault, id.Vault);
            Assert.Equal(name, id.Name);
            Assert.Equal(string.Empty, id.Version);
            Assert.True(KeyIdentifier.IsKeyIdentifier(baseId));

            //versioned
            id = new KeyIdentifier(versionedId);
            Assert.Equal(baseId, id.BaseIdentifier);
            Assert.Equal(versionedId, id.Identifier);
            Assert.Equal(vault, id.Vault);
            Assert.Equal(name, id.Name);
            Assert.Equal(version, id.Version);
            Assert.True(KeyIdentifier.IsKeyIdentifier(versionedId));
        }

        [Fact]
        public void SecretIdentifierTest()
        {
            string baseId = string.Format("{0}/secrets/{1}", vault, name);
            string versionedId = string.Format("{0}/{1}", baseId, version);

            //unversioned
            var id = new SecretIdentifier(baseId);
            Assert.Equal(baseId, id.BaseIdentifier);
            Assert.Equal(baseId, id.Identifier);
            Assert.Equal(vault, id.Vault);
            Assert.Equal(name, id.Name);
            Assert.Equal(string.Empty, id.Version);
            Assert.True(SecretIdentifier.IsSecretIdentifier(baseId));

            //versioned
            id = new SecretIdentifier(versionedId);
            Assert.Equal(baseId, id.BaseIdentifier);
            Assert.Equal(versionedId, id.Identifier);
            Assert.Equal(vault, id.Vault);
            Assert.Equal(name, id.Name);
            Assert.Equal(version, id.Version);
            Assert.True(SecretIdentifier.IsSecretIdentifier(versionedId));
        }
        
        [Fact]
        public void CertificateIdentifierTest()
        {
            string baseId = string.Format("{0}/certificates/{1}", vault, name);
            string versionedId = string.Format("{0}/{1}", baseId, version);

            //unversioned
            var id = new CertificateIdentifier(baseId);
            Assert.Equal(baseId, id.BaseIdentifier);
            Assert.Equal(baseId, id.Identifier);
            Assert.Equal(vault, id.Vault);
            Assert.Equal(name, id.Name);
            Assert.Equal(string.Empty, id.Version);
            Assert.True(CertificateIdentifier.IsCertificateIdentifier(baseId));

            //versioned
            id = new CertificateIdentifier(versionedId);
            Assert.Equal(baseId, id.BaseIdentifier);
            Assert.Equal(versionedId, id.Identifier);
            Assert.Equal(vault, id.Vault);
            Assert.Equal(name, id.Name);
            Assert.Equal(version, id.Version);
            Assert.True(CertificateIdentifier.IsCertificateIdentifier(versionedId));
        }

        [Fact]
        public void CertificateOperationIdentifierTest()
        {
            string baseId = string.Format("{0}/certificates/{1}/pending", vault, name);
            
            var id = new CertificateOperationIdentifier(baseId);
            Assert.Equal(baseId, id.BaseIdentifier);
            Assert.Equal(baseId, id.Identifier);
            Assert.Equal(vault, id.Vault);
            Assert.Equal(name, id.Name);
            Assert.Equal(string.Empty, id.Version);
            Assert.True(CertificateOperationIdentifier.IsCertificateOperationIdentifier(baseId));
            Assert.False(CertificateOperationIdentifier.IsCertificateOperationIdentifier(baseId + "/version"));
        }

        [Fact]
        public void IssuerIdentifierTest()
        {
            string baseId = string.Format("{0}/certificates/issuers/{1}", vault, name);

            var id = new IssuerIdentifier(baseId);
            Assert.Equal(baseId, id.BaseIdentifier);
            Assert.Equal(baseId, id.Identifier);
            Assert.Equal(vault, id.Vault);
            Assert.Equal(name, id.Name);
            Assert.Equal(string.Empty, id.Version);
            Assert.True(IssuerIdentifier.IsIssuerIdentifier(baseId));
            Assert.False(IssuerIdentifier.IsIssuerIdentifier(baseId + "/version"));
        }
    }
}
