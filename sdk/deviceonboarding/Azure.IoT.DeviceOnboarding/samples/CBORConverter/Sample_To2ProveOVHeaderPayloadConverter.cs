// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for TO2ProveOVHeaderPayload Object
    /// </summary>
    [CBORConverter(typeof(TO2ProveOVHeaderPayload))]
    internal sealed class Sample_To2ProveOVHeaderPayloadConverter : ICBORToFromConverter<TO2ProveOVHeaderPayload>
    {
        private readonly CBORUtil cborUtil;

        public Sample_To2ProveOVHeaderPayloadConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert TO2ProveOVHeaderPayload Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(TO2ProveOVHeaderPayload obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborObj = CBORObject.NewArray()
                .Add(obj.Header)
                .Add((byte)obj.NumEntries)
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.Hmac))
                .Add(obj.NonceTO2ProveOV.NonceValue)
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.SigInfoB))
                .Add(obj.KexA)
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.HelloHash))
                .Add((ushort)obj.MaxMessageSize);

            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type TO2ProveOVHeaderPayload
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TO2ProveOVHeaderPayload FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
            TO2ProveOVHeaderPayload to2ProveOVHeaderPayload = new TO2ProveOVHeaderPayload
            {
                Header = obj[0].GetByteString(),
                NumEntries = Sample_CBORConverter.ToObject<byte>(obj[1]),
                Hmac = Sample_CBORConverter.ToObject<Hash>(obj[2]),
                NonceTO2ProveOV = new FDONonce(obj[3].GetByteString()),
                SigInfoB = Sample_CBORConverter.ToObject<SigInfo>(obj[4]),
                KexA = obj[5].GetByteString(),
                HelloHash = Sample_CBORConverter.ToObject<Hash>(obj[6]),
                MaxMessageSize = obj[7].AsNumber().ToUInt16Unchecked(),
            };
            return to2ProveOVHeaderPayload;
        }
    }
}
