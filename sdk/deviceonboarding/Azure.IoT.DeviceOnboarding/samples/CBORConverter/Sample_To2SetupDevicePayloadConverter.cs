// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for TO2SetupDevicePayload Object
    /// </summary>
    [CBORConverter(typeof(TO2SetupDevicePayload))]
    internal sealed class Sample_To2SetupDevicePayloadConverter : ICBORToFromConverter<TO2SetupDevicePayload>
    {
        private readonly CBORUtil cborUtil;

        public Sample_To2SetupDevicePayloadConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert TO2SetupDevicePayload Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(TO2SetupDevicePayload obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborObj = CBORObject.NewArray()
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.RendezvousInfo))
                .Add(obj.Guid.ToByteArray())
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.NonceTO2SetupDv))
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.Owner2Key));

            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type TO2SetupDevicePayload
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TO2SetupDevicePayload FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
            TO2SetupDevicePayload to2SetupDevicePayload = new TO2SetupDevicePayload
            {
                RendezvousInfo = Sample_CBORConverter.ToObject<RendezvousInfo>(obj[0]),
                Guid = new Guid(obj[1].GetByteString()),
                NonceTO2SetupDv = Sample_CBORConverter.ToObject<FDONonce>(obj[2]),
                Owner2Key = Sample_CBORConverter.ToObject<PublicKey>(obj[3])
            };

            return to2SetupDevicePayload;
        }
    }
}
