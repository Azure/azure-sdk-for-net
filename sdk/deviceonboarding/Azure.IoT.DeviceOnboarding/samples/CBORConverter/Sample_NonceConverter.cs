// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for FDONonce Object
    /// </summary>
    [CBORConverter(typeof(FDONonce))]
    internal class Sample_NonceConverter : ICBORToFromConverter<FDONonce>
    {
        private readonly CBORUtil cborUtil;
        private const int NonceByteArraySize = 16;

        public Sample_NonceConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert FDONonce Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(FDONonce obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            cborUtil.ValidateObjectNotNull(obj.NonceValue);
            CBORObject cborObj = CBORObject.FromObject(obj.NonceValue);

            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type FDONonce
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public FDONonce FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateByteStringWithSize(obj, NonceByteArraySize);
            FDONonce nonce = new FDONonce(obj.GetByteString());
            return nonce;
        }
    }
}
