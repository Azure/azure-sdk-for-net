// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Services.AppAuthentication.TestCommon
{
    public class CertUtil
    {
        /// <summary>
        /// Get certificate from the CurrentUser store, based on the given thumbprint.
        /// </summary>
        /// <param name="thumbprint"></param>
        /// <returns></returns>
        public static X509Certificate2 GetCertificate(string thumbprint)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadOnly);

            foreach (X509Certificate2 cert in store.Certificates)
            {
                if (cert.Thumbprint != null && string.Compare(cert.Thumbprint.ToLower(), thumbprint.ToLower(),
                        StringComparison.Ordinal) == 0)
                {
                    return cert;
                }
            }

            return null;
        }

        /// <summary>
        /// Import certificate into the CurrentUser store.
        /// </summary>
        /// <returns></returns>
        public static void ImportCertificate(X509Certificate2 cert)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadWrite);

            store.Add(cert);

#if FullNetFx
            store.Close();
#endif
        }

        /// <summary>
        /// Delete certificates with given thumbprint from CurrentUser store. 
        /// </summary>
        /// <param name="thumbprint"></param>
        public static void DeleteCertificate(string thumbprint)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadWrite);

            List<X509Certificate2> certsToDelete = new List<X509Certificate2>();

            foreach (X509Certificate2 cert in store.Certificates)
            {
                if (cert.Thumbprint != null && string.Compare(cert.Thumbprint.ToLower(), thumbprint.ToLower(),
                        StringComparison.Ordinal) == 0)
                {
                    certsToDelete.Add(cert);
                }
            }

            foreach (X509Certificate2 cert in certsToDelete)
            {
                store.Remove(cert);
            }

#if FullNetFx
            store.Close();
#endif
        }

    }
}
