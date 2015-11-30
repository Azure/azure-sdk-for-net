namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using Org.BouncyCastle.Asn1;
    using Org.BouncyCastle.Asn1.Pkcs;
    using Org.BouncyCastle.Asn1.X509;
    using Org.BouncyCastle.Utilities.IO.Pem;

    /// <summary>
    /// Helper class to convert OpenSSH key to X509 cert
    /// </summary>
    internal class OpenSshToX509CertificateHelper
    {
        // A max length for key file that portal would accept
        // Use a related large numebr, 32KB, as max limit, since it would take user more than hours to generate
        private const int MaxLen = 32768;

        /// <summary>
        /// Convert OpenSSH public key or a OpenSSH public key file in RFC 4716 format to X509 certificate
        /// </summary>
        /// <param name="content">OpenSSH public key content</param>
        /// <param name="x509Subject">Subject for the x509 Certificate</param>
        /// <returns>X509 certificate content</returns>
        public string ConvertOpenSshPublicKeyToX509Cert(string content, string x509Subject)
        {
            string openSshKeyBody = null;

            if (this.IsRfc4716PublicKeyFile(content))
            {
                openSshKeyBody = this.ReadBodyRfc4716PublicKeyFile(content);
            }
            else if (this.IsOpenSshPublicKey(content))
            {
                openSshKeyBody = this.ReadBodyFromOpenSshPublicKey(content);
            }
            else
            {
                throw new InvalidOperationException("Given public key is not a valid OpenSSH key or OpenSSH key file in RFC 4716 format.");
            }

            var pkcs1Content = this.GeneratePkcs1PublicKeyFromRsaEncryptedOpenSshPublicKey(openSshKeyBody);
            return this.GenerateX509Cert(pkcs1Content, x509Subject);
        }

        /// <summary>
        /// Check if given content is a valid OpenSSH public key or a OpenSSH public key file in RFC 4716 format
        /// </summary>
        /// <param name="content">OpenSSH public key content</param>
        public bool IsValidOpenSshPublicKey(string content)
        {
            return this.IsOpenSshPublicKey(content) || this.IsRfc4716PublicKeyFile(content);
        }

        #region OpenSSH key

        /// <summary>
        /// Check if given content if a valid OpenSSH public key: "ssh-rsa {body} {info}"
        /// </summary>
        /// <param name="content">OpenSSH public key content</param>
        private bool IsOpenSshPublicKey(string content)
        {
            bool valid = false;
            if (!string.IsNullOrWhiteSpace(content) && content.Length < MaxLen)
            {
                string keyBody = this.ReadBodyFromOpenSshPublicKey(content);

                if (keyBody != null)
                {
                    try
                    {
                        var keyBodyInBiary = this.GetOpenSshPublicKeyInBinary(keyBody);
                        valid = keyBodyInBiary.Count == 3;
                    }
                    catch
                    {
                        // if there is any exception, must cause by invalid content
                    }
                }
            }

            return valid;
        }

        private string ReadBodyFromOpenSshPublicKey(string content)
        {
            if (!string.IsNullOrWhiteSpace(content))
            {
                string[] tokens = content.Split(' ');

                // should be in format "ssh-rsa {body} {info}"
                if (tokens.Length >= 2 && tokens[0].Equals("ssh-rsa", StringComparison.Ordinal))
                {
                    return tokens[1];
                }
            }

            return null;
        }

        #endregion

        #region OpenSSH key in RFC 4716 format

        /// <summary>
        /// Check if given content is a OpenSSH public key file in RFC 4716 format
        /// </summary>
        /// <param name="content">OpenSSH public key content</param>
        private bool IsRfc4716PublicKeyFile(string content)
        {
            bool valid = false;
            //// The first line of a conforming key file MUST be a begin marker, which
            //// is the literal text:
            //// ---- BEGIN SSH2 PUBLIC KEY ----
            //// The last line of a conforming key file MUST be an end marker, which
            //// is the literal text:
            //// ---- END SSH2 PUBLIC KEY ----

            if (!string.IsNullOrWhiteSpace(content)
                && content.Length <= MaxLen
                && content.StartsWith("---- BEGIN SSH2 PUBLIC KEY ----", StringComparison.Ordinal)
                && content.TrimEnd().EndsWith("---- END SSH2 PUBLIC KEY ----", StringComparison.Ordinal))
            {
                //// "TrimEnd()" in case there is NewLine at the end of file

                try
                {
                    string keyBody = this.ReadBodyRfc4716PublicKeyFile(content);
                    var keyBodyInBiary = this.GetOpenSshPublicKeyInBinary(keyBody);
                    valid = keyBodyInBiary.Count == 3;
                }
                catch
                {
                    // if there is any exception, must cause by invalid content
                }
            }

            return valid;
        }

        private string ReadBodyRfc4716PublicKeyFile(string content)
        {
            //// The first line of a conforming key file MUST be a begin marker, which
            //// is the literal text:
            //// ---- BEGIN SSH2 PUBLIC KEY ----
            //// The last line of a conforming key file MUST be an end marker, which
            //// is the literal text:
            //// ---- END SSH2 PUBLIC KEY ----

            //// The key file header section consists of multiple RFC822-style header
            //// fields.  Each field is a line of the following format:
            ////    Header-tag ':' ' ' Header-value

            //// A line is continued if the last character in the line is a '\'.  If
            //// the last character of a line is a '\', then the logical contents of
            //// the line are formed by removing the '\' and the line termination
            //// characters, and appending the contents of the next line.

            //// A line that is not a continuation line that has no ':' in it is the
            //// first line of the base64-encoded body.  (See Section 3.4.)

            //// Subject header
            ////      Subject: user

            //// Comment header
            ////      Comment: user@example.com

            //// Private Use Headers
            ////    x-Header-tag ':' ' ' Header-value

            //// Public Key File Body

            StringBuilder sb = new StringBuilder();

            using (StringReader sr = new StringReader(content))
            {
                string line = null;
                bool extendedLine = false;

                do
                {
                    line = sr.ReadLine();

                    if (line != null
                        && !extendedLine
                        && !line.Equals("---- BEGIN SSH2 PUBLIC KEY ----", StringComparison.Ordinal)
                        && !line.Equals("---- END SSH2 PUBLIC KEY ----", StringComparison.Ordinal)
                        && !line.Contains(":") && !line.EndsWith(@"\", StringComparison.Ordinal))
                    {
                        //// if not end of file
                        ////    not the first line
                        ////    not the last line
                        ////    not header, subject, comment, private header or '\' (extended line)
                        ////        Must be body (body is base 64 encoded, won`t contain ":" or "\", see page 24, http://tools.ietf.org/html/rfc2045)

                        sb.AppendLine(line);
                    }

                    extendedLine = line != null && line.EndsWith(@"\", StringComparison.Ordinal);
                }
                while (line != null);
            }

            return sb.ToString();
        }

        #endregion

        [SuppressMessage("Microsoft.Reliability", "CA2000:MustCallDispose", Justification = "When BinaryReader is disposed, underlying stream will also be disposed")]
        private List<byte[]> GetOpenSshPublicKeyInBinary(string keyBody)
        {
            //// From RFC 4253
            //// The "ssh-rsa" key format has the following specific encoding:
            ////     string    "ssh-rsa"
            ////     mpint     e
            ////     mpint     n
            //// Here the 'e' and 'n' parameters form the signature key blob.
            //// Signing and verifying using this key format is performed according to the RSASSA-PKCS1-v1_5 scheme in [RFC3447] using the SHA-1 hash.
            //// PS: we do not need to do any signing here, but as an information that we can use it to generate a PCKS #1 public key later

            //// From RFC 4251
            //// string : They are stored as a uint32 containing its length (number of bytes that follow) and zero (= empty string) or more bytes that are the value of the string. 
            //// mpint :  Represents multiple precision integers in two's complement format, stored as a string, 8 bits per byte, MSB first.

            var data = new List<byte[]>();  // data should have three item at the end

            // When BinaryReader is disposed, underlying stream will also be disposed
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(keyBody));
            using (BinaryReader reader = new BinaryReader(memoryStream))
            {
                // reset underlying stream to start from the begining
                reader.BaseStream.Position = 0;

                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    byte[] lenInBinary = reader.ReadBytes(4);   // uint32
                    Array.Reverse(lenInBinary);                 // MSB first
                    var length = BitConverter.ToUInt32(lenInBinary, 0);

                    // SHOULD BE save to convert uint to "int", 
                    //      first string is "algorightm" name, we currently only support "ssh-rsa", string is short
                    //      mpint "e" and "n" are positive integer accroding to RFC 3447
                    data.Add(reader.ReadBytes((int)length));
                }
            }

            return data;
        }

        private string GeneratePkcs1PublicKeyFromRsaEncryptedOpenSshPublicKey(string content)
        {
            List<byte[]> data = this.GetOpenSshPublicKeyInBinary(content);

            if (data.Count != 3)
            {
                throw new InvalidOperationException("Given OpenSSH key body is invalid.");
            }

            //// RFC 3447 (PKCS #1)
            //// 3.1 RSA public key
            //// For the purposes of this document, an RSA public key consists of two
            //// components:

            ////      n        the RSA modulus, a positive integer
            ////      e        the RSA public exponent, a positive integer

            //// A recommended syntax for interchanging RSA public keys between
            //// implementations is given in Appendix A.1.1; an implementation's
            //// internal representation may differ.

            //// A.1.1 RSA public key syntax
            //// An RSA public key should be represented with the ASN.1 type
            //// RSAPublicKey:
            ////   RSAPublicKey ::= SEQUENCE {
            ////       modulus           INTEGER,  -- n
            ////       publicExponent    INTEGER   -- e
            ////   }
            //// The fields of type RSAPublicKey have the following meanings:
            ////      * modulus is the RSA modulus n.
            ////      * publicExponent is the RSA public exponent e.

            //// RFC 4251: Strings are also used to store text.  In that case, US-ASCII is
            ////           used for internal names, and ISO-10646 UTF-8 for text that might be displayed to the user.
            string algorithmName = Encoding.UTF8.GetString(data[0]);
            if (!"ssh-rsa".Equals(algorithmName, StringComparison.Ordinal))
            {
                throw new InvalidOperationException("Invalid OpenSSH key body, expected 'ssh-rsa' encrypted.");
            }

            var publicExponent = new DerInteger(data[1]);
            var modulus = new DerInteger(data[2]);
            var sequence = new DerSequence(new Asn1Encodable[] { modulus, publicExponent });

            // Generate DER-encoded public key
            StringBuilder sb = new StringBuilder();
            using (var sw = new StringWriter(sb, CultureInfo.InvariantCulture))
            {
                var pemWriter = new Org.BouncyCastle.Utilities.IO.Pem.PemWriter(sw);
                pemWriter.WriteObject(new PemObject("RSA PUBLIC KEY", sequence.GetEncoded()));
            }

            return sb.ToString();
        }

        private string GenerateX509Cert(string publicKey, string x509Subject)
        {
            Asn1Sequence asn1Sequence = null;

            using (var reader = new StringReader(publicKey))
            {
                // Read the RSA public key from the input string.
                var pemReader = new PemReader(reader);
                var pemObject = pemReader.ReadPemObject();
                asn1Sequence = (Asn1Sequence)Asn1Object.FromByteArray(pemObject.Content);
            }

            // Generate a TBS certificate. We use placeholder-like values since
            // the consumer of this certificate should only use the subject
            // public key info.
            var tbsCertGen = new V3TbsCertificateGenerator();
            tbsCertGen.SetSerialNumber(new DerInteger(1));
            var signatureAlgId = new AlgorithmIdentifier(PkcsObjectIdentifiers.Sha1WithRsaEncryption, DerNull.Instance);
            tbsCertGen.SetSignature(signatureAlgId);
            tbsCertGen.SetIssuer(new X509Name("CN=Root Agency"));
            var dateTimeNow = DateTime.Now;
            tbsCertGen.SetStartDate(new Time(dateTimeNow.AddMinutes(-10)));
            tbsCertGen.SetEndDate(new Time(dateTimeNow.AddYears(1)));   // Openssh key doesn`t have any start/end date, this is to satisfy RDFE
            tbsCertGen.SetSubject(new X509Name(x509Subject));
            tbsCertGen.SetSubjectPublicKeyInfo(new SubjectPublicKeyInfo(new AlgorithmIdentifier(PkcsObjectIdentifiers.RsaEncryption, DerNull.Instance), asn1Sequence));
            var tbsCert = tbsCertGen.GenerateTbsCertificate();

            // Per RFC 3280, the layout of an X.509 v3 certificate looks like:
            // Certificate  ::=  SEQUENCE  {
            //     tbsCertificate       TBSCertificate,
            //     signatureAlgorithm   AlgorithmIdentifier,
            //     signatureValue       BIT STRING
            // }
            // Since we don't have access to the private key, we cannot create
            // a signature for the TBS. However, a valid certificate requires
            // a bit string for the signature value, so we use a 0-byte array
            // in its place.
            Asn1EncodableVector v = new Asn1EncodableVector();
            v.Add(tbsCert);
            v.Add(signatureAlgId);
            v.Add(new DerBitString(new byte[0]));
            var derSequence = new DerSequence(v);

            // Output the DER-encoded X509 certificate.
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb, CultureInfo.InvariantCulture))
            {
                var pemWriter = new PemWriter(writer);
                pemWriter.WriteObject(new PemObject("CERTIFICATE", derSequence.GetEncoded()));
            }

            return sb.ToString();
        }
    }
}
