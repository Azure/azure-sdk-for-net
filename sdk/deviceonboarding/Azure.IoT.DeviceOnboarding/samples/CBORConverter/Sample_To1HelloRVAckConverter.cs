// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for TO1HelloRVAck Object
    /// </summary>
    [CBORConverter(typeof(TO1HelloRVAck))]
    internal class Sample_To1HelloRVAckConverter : ICBORToFromConverter<TO1HelloRVAck>
    {
        private readonly CBORUtil cborUtil;

        public Sample_To1HelloRVAckConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert TO1HelloRVAck Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(TO1HelloRVAck obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborObj = CBORObject.NewArray()
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.NonceTO1Proof))
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.EBSigInfo));
            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type TO1HelloRVAck
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TO1HelloRVAck FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
#pragma warning disable CA1062 // Validate arguments of public methods; validated as not null in ValidateCBORObjectIsArray
            TO1HelloRVAck to1HelloRVAck = new TO1HelloRVAck
            {
                NonceTO1Proof = Sample_CBORConverter.ToObject<FDONonce>(obj[0]),
                EBSigInfo = Sample_CBORConverter.ToObject<SigInfo>(obj[1]),
            };
            return to1HelloRVAck;
#pragma warning restore CA1062 // Validate arguments of public methods
        }
    }
}
