// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// To1 Hello RV Ack
    /// </summary>
    public class TO1HelloRVAck
    {
        /// <summary>
        /// NonceTO1Proof, contains a nonce to use as a guarantee of signature freshness in the TO1.ProveTORV
        /// </summary>
        public FDONonce NonceTO1Proof { get; set; }

        /// <summary>
        /// Signature Information; from Owner/Rendezvous to Device
        /// </summary>
        public SigInfo EBSigInfo { get; set; }

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
            if (obj is TO1HelloRVAck to1HelloRVAck)
            {
                return object.Equals(this.NonceTO1Proof, to1HelloRVAck.NonceTO1Proof) &&
                       object.Equals(this.EBSigInfo, to1HelloRVAck.EBSigInfo);
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.NonceTO1Proof?.GetHashCode() ?? 0,
                this.EBSigInfo?.GetHashCode() ?? 0);
        }
    }
}
