// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for TO2ProveDevicePayload Object
    /// </summary>
    [CBORConverter(typeof(TO2ProveDevicePayload))]
    internal sealed class Sample_To2ProveDevicePayloadConverter : ICBORToFromConverter<TO2ProveDevicePayload>
    {
        private readonly CBORUtil cborUtil;

        public Sample_To2ProveDevicePayloadConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert TO2ProveDevicePayload Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(TO2ProveDevicePayload obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborObj = CBORObject.NewArray()
                .Add(obj.KexB);

            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type TO2ProveDevicePayload
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TO2ProveDevicePayload FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
            TO2ProveDevicePayload to2ProveDevicePayload = new TO2ProveDevicePayload
            {
                KexB = obj[0].GetByteString()
            };
            return to2ProveDevicePayload;
        }
    }
}
