// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for TO2Done2 Object
    /// </summary>
    [CBORConverter(typeof(TO2Done2))]
    internal sealed class Sample_To2Done2Converter : ICBORToFromConverter<TO2Done2>
    {
        private readonly CBORUtil cborUtil;

        public Sample_To2Done2Converter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert TO2Done2 Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(TO2Done2 obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborObj = CBORObject.NewArray()
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.NonceTO2SetupDevice));
            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type TO2Done2
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TO2Done2 FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
            TO2Done2 to2Done2 = new TO2Done2
            {
                NonceTO2SetupDevice = Sample_CBORConverter.ToObject<FDONonce>(obj[0]),
            };
            return to2Done2;
        }
    }
}
