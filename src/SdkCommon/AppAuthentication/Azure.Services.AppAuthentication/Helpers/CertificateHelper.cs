// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Helper class to get certificates.  
    /// </summary>
    internal class CertificateHelper
    {
        /// <summary>
        /// Get certificates from cert store
        /// </summary>
        /// <param name="isThumbprint">If true, search for thumbprint, else for subjectName</param>
        /// <param name="location"></param>
        /// <param name="subjectNameOrThumbprint">The actual value to search for.</param>
        /// <returns></returns>
        public static List<X509Certificate2> GetCertificates(string subjectNameOrThumbprint,
            bool isThumbprint, StoreLocation location)
        {
            List<X509Certificate2> certs = new List<X509Certificate2>();
#if FullNetFx
            X509Store store = new X509Store(location);
#else
            X509Store store = new X509Store(StoreName.My, location);
#endif
            try
            {
                store.Open(OpenFlags.ReadOnly);

                X509Certificate2Collection certCollection = store.Certificates;

                foreach (X509Certificate2 cert in certCollection)
                {
                    // Only return certs where we have the private key, since we need to use it for authentication. 
                    if (cert != null && cert.HasPrivateKey)
                    {
                        if (isThumbprint && string.Equals(subjectNameOrThumbprint, cert.Thumbprint, StringComparison.OrdinalIgnoreCase)
                            || !isThumbprint && string.Equals(subjectNameOrThumbprint, cert.Subject, StringComparison.OrdinalIgnoreCase))
                        {
                            certs.Add(cert);
                        }
                    }
                }
            }
            finally
            {
#if FullNetFx
                store.Close();
#endif
            }

            return certs;
        }
        
    }
}
