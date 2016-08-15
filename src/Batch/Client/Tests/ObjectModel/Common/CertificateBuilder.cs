// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace BatchTestCommon
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using Mono.Security.X509;

    /// <summary>
    /// Static class for generating pfx and cer files.
    /// </summary>
    public static class CertificateBuilder
    {
        /// <summary>
        /// Create a self signed certificate in the specified file.
        /// </summary>
        /// <param name="subjectName">The subject of the certificate to create.</param>
        /// <param name="fileName">The file name to write the certificate to.</param>
        /// <param name="password">True if there is a password, false otherwise.  Note that if there is a password, PFX format is assumed.</param>
        public static void CreateSelfSignedInFile(string subjectName, string fileName, string password = "")
        {
            byte[] serialNumber = GenerateSerialNumber();
            string subject = string.Format("CN={0}", subjectName);

            using (RSA key = new RSACryptoServiceProvider(2048))
            {
                X509CertificateBuilder certificateBuilder = new X509CertificateBuilder
                {
                    SerialNumber = serialNumber,
                    IssuerName = subject,
                    NotBefore = DateTime.Now,
                    NotAfter = DateTime.Now, //expiry time is now for security purposes
                    SubjectName = subject,
                    SubjectPublicKey = key,
                    Hash = "SHA1"
                };

                //Get the raw certificate data
                byte[] rawCert = certificateBuilder.Sign(key);

                //If password is not empty, generate a PKCS#12 formatted file
                if (!string.IsNullOrEmpty(password))
                {
                    PKCS12 p12 = new PKCS12();
                    p12.Password = password;
                    p12.AddCertificate(new Mono.Security.X509.X509Certificate(rawCert));
                    p12.AddPkcs8ShroudedKeyBag(key);

                    p12.SaveToFile(fileName);
                }
                //If password is empty generate a DER formatted file
                else
                {
                    File.WriteAllBytes(fileName, rawCert);
                }
            }
        }

        private static byte[] GenerateSerialNumber()
        {
            byte[] sn = Guid.NewGuid().ToByteArray();

            //The high bit must be unset
            sn[0] &= 0x7F;

            return sn;
        }
    }
}
