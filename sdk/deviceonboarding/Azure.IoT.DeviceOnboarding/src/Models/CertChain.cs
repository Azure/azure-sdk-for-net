// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Class for certificate chain
    /// </summary>
    public class CertChain
    {
        /// <summary>
        /// Collection of certificates in the chain
        /// </summary>
        public ICollection<X509Certificate2> Chain { get; set; }

        /// <summary>
        /// Create a new instance of CertChain wiith empty chain
        /// </summary>
        public CertChain()
        {
            this.Chain = new List<X509Certificate2>();
        }

        /// <summary>
        /// Create a new instance of CertChain
        /// </summary>
        /// <param name="chain"></param>
        public CertChain(ICollection<X509Certificate2> chain)
        {
            this.Chain = chain ?? new List<X509Certificate2>();
        }

        /// <summary>
        /// Convert collection of certificates to CertChain
        /// </summary>
        /// <param name="chain"></param>
        /// <returns></returns>
        public static CertChain FromList(ICollection<X509Certificate2> chain)
        {
            return new CertChain(chain);
        }

        /// <summary>
        /// Override Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj is CertChain certChain)
            {
                int count = this.Chain.Count;
                if (count != certChain.Chain.Count)
                {
                    return false;
                }

                var listA = this.Chain.ToList();
                var listB = certChain.Chain.ToList();

                for (int i = 0; i < count; i++)
                {
                    if (!listA[i].Equals(listB[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Chain.Aggregate(0, (hash, cert) => HashCode.Combine(hash, cert?.GetHashCode() ?? 0));
        }
    }
}
