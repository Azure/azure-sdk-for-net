// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.IO;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// FDONonce
    /// </summary>
	public class FDONonce
    {
        /// <summary>
        /// FDONonce value
        /// </summary>
        private byte[] nonce;

        /// <summary>
        /// Create nonce
        /// </summary>
        /// <param name="nonce"></param>
        public FDONonce(byte[] nonce)
        {
            this.nonce = nonce;
        }

        /// <summary>
        /// Value of the nonce
        /// </summary>
        public byte[] NonceValue
        {
            get => this.nonce ?? Array.Empty<byte>();

            set => this.nonce = value;
        }

        /// <summary>
        /// Override for toString.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this.nonce == null)
            {
                return "";
            }

            try
            {
                return new Guid(this.nonce).ToString();
            }
            catch (IOException e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Override for equals.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj is FDONonce nonceObj)
            {
                return StructuralComparisons.StructuralEqualityComparer.Equals(nonce, nonceObj.nonce);
            }

            return false;
        }

        /// <summary>
        /// Generate new nonce from random guid
        /// </summary>
        /// <returns></returns>
        public static FDONonce FromRandomUuid()
        {
            var nonce = new FDONonce(Guid.NewGuid().ToByteArray());
            return nonce;
        }

        /// <summary>
        /// Override for getting Hash code.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return StructuralComparisons.StructuralEqualityComparer.GetHashCode(NonceValue);
        }
    }
}
