// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Security.Attestation.Tests
{
    public class AttestationClientTestEnvironment : TestEnvironment
    {
        public string IsolatedAttestationUrl => GetRecordedVariable("ISOLATED_ATTESTATION_URL");
        public string AadAttestationUrl => GetRecordedVariable("AAD_ATTESTATION_URL");

        public X509Certificate2 PolicyCertificate0 => new X509Certificate2(Convert.FromBase64String(GetRecordedVariable("policySigningCertificate0")));
        public X509Certificate2 PolicyCertificate1 => new X509Certificate2(Convert.FromBase64String(GetRecordedVariable("policySigningCertificate1")));
        public X509Certificate2 PolicyCertificate2 => new X509Certificate2(Convert.FromBase64String(GetRecordedVariable("policySigningCertificate2")));

        public RSA PolicySigningKey0 => GetRSACryptoServiceProvider("serializedPolicySigningKey0");
        public RSA PolicySigningKey1 => GetRSACryptoServiceProvider("serializedPolicySigningKey1");
        public RSA PolicySigningKey2 => GetRSACryptoServiceProvider("serializedPolicySigningKey2");

        // Policy management keys.
        public X509Certificate2 PolicyManagementCertificate => new X509Certificate2(Convert.FromBase64String(GetRecordedVariable("isolatedSigningCertificate")));
        public RSA PolicyManagementKey => GetRSACryptoServiceProvider("serializedIsolatedSigningKey");

        public string SharedEusTest => "https://sharedeus.eus.test.attest.azure.net";
        public string SharedUkSouth => "https://shareduks.uks.test.attest.azure.net";

        private static Uri DataPlaneScope => new Uri($"https://attest.azure.net");

        public TokenCredential GetClientSecretCredential() => Credential;

        private RSACryptoServiceProvider GetRSACryptoServiceProvider(string variableName)
        {
            string serializedKey = GetRecordedVariable(variableName);
            System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(new StringReader(serializedKey));
            xmlReader.Read();
            if (xmlReader.Name != "RSAKeyValue")
            {
                throw new System.Xml.XmlException();
            }
            xmlReader.Read();

            RSAParameters parameters = new RSAParameters();
            while (xmlReader.NodeType != System.Xml.XmlNodeType.EndElement)
            {
                switch (xmlReader.Name)
                {
                    case "Modulus":
                        {
                            xmlReader.Read();
                            if (xmlReader.NodeType != System.Xml.XmlNodeType.Text)
                            {
                                throw new System.Xml.XmlException();
                            }
                            parameters.Modulus = Convert.FromBase64String(xmlReader.ReadContentAsString());
                            xmlReader.Read();
                        }
                        break;
                    case "Exponent":
                        {
                            xmlReader.Read();
                            if (xmlReader.NodeType != System.Xml.XmlNodeType.Text)
                            {
                                throw new System.Xml.XmlException();
                            }
                            parameters.Exponent = Convert.FromBase64String(xmlReader.ReadContentAsString());
                            xmlReader.Read();
                        }
                        break;
                    case "P":
                        {
                            xmlReader.Read();
                            if (xmlReader.NodeType != System.Xml.XmlNodeType.Text)
                            {
                                throw new System.Xml.XmlException();
                            }
                            parameters.P = Convert.FromBase64String(xmlReader.ReadContentAsString());
                            xmlReader.Read();
                        }
                        break;
                    case "Q":
                        {
                            xmlReader.Read();
                            if (xmlReader.NodeType != System.Xml.XmlNodeType.Text)
                            {
                                throw new System.Xml.XmlException();
                            }
                            parameters.Q = Convert.FromBase64String(xmlReader.ReadContentAsString());
                            xmlReader.Read();
                        }
                        break;
                    case "DP":
                        {
                            xmlReader.Read();
                            if (xmlReader.NodeType != System.Xml.XmlNodeType.Text)
                            {
                                throw new System.Xml.XmlException();
                            }
                            parameters.DP = Convert.FromBase64String(xmlReader.ReadContentAsString());
                            xmlReader.Read();
                        }
                        break;
                    case "DQ":
                        {
                            xmlReader.Read();
                            if (xmlReader.NodeType != System.Xml.XmlNodeType.Text)
                            {
                                throw new System.Xml.XmlException();
                            }
                            parameters.DQ = Convert.FromBase64String(xmlReader.ReadContentAsString());
                            xmlReader.Read();
                        }
                        break;
                    case "InverseQ":
                        {
                            xmlReader.Read();
                            if (xmlReader.NodeType != System.Xml.XmlNodeType.Text)
                            {
                                throw new System.Xml.XmlException();
                            }
                            parameters.InverseQ = Convert.FromBase64String(xmlReader.ReadContentAsString());
                            xmlReader.Read();
                        }
                        break;
                    case "D":
                        {
                            xmlReader.Read();
                            if (xmlReader.NodeType != System.Xml.XmlNodeType.Text)
                            {
                                throw new System.Xml.XmlException();
                            }
                            parameters.D = Convert.FromBase64String(xmlReader.ReadContentAsString());
                            xmlReader.Read();
                        }
                        break;
                    default:
                        throw new System.Xml.XmlException();
                }
            }

            var returnValue = new RSACryptoServiceProvider();
            returnValue.ImportParameters(parameters);
            return returnValue;
        }
    }
}
