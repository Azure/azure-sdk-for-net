// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for TO2Done Object
    /// </summary>
    [CBORConverter(typeof(TO2Done))]
    internal sealed class Sample_To2DoneConverter : ICBORToFromConverter<TO2Done>
    {
        private readonly CBORUtil cborUtil;

        public Sample_To2DoneConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert TO2Done Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(TO2Done obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborObj = CBORObject.NewArray()
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.NonceTO2ProveDevice));
            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type TO2Done
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TO2Done FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
            TO2Done to2Done = new TO2Done
            {
                NonceTO2ProveDevice = Sample_CBORConverter.ToObject<FDONonce>(obj[0]),
            };
            return to2Done;
        }
    }
}
