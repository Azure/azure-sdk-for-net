// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for Hash Object
    /// </summary>
    [CBORConverter(typeof(Hash))]
    internal sealed class Sample_HashConverter : ICBORToFromConverter<Hash>
    {
        private readonly CBORUtil cborUtil;

        public Sample_HashConverter()
        {
            cborUtil = new CBORUtil();
        }
        /// <summary>
        /// Convert Hash Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(Hash obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborObj = CBORObject.NewArray()
                .Add((int)obj.HashType)
                .Add(obj.HashValue);
            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type Hash
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Hash FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
            Hash hash = new Hash
            {
                HashType = (HashType)obj[0].AsInt32(),
                HashValue = obj[1].GetByteString()
            };
            return hash;
        }
    }
}
