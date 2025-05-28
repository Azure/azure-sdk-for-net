// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples.CBORConverter
{
    /// <summary>
    /// Cbor Converter for TO1dPayload Object
    /// </summary>
    [CBORConverter(typeof(TO1dPayload))]
    internal sealed class Sample_TO1dPayloadConverter : ICBORToFromConverter<TO1dPayload>
    {
        private readonly CBORUtil cborUtil;

        public Sample_TO1dPayloadConverter()
        {
            cborUtil = new CBORUtil();
        }
        /// <summary>
        /// Convert TO1dPayload Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(TO1dPayload obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborArr = CBORObject.NewArray()
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.AddressEntries))
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.To1dTo0dHash));
            return cborArr;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type TO1dPayload
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TO1dPayload FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
            var to1dPayload = new TO1dPayload
            {
                AddressEntries = Sample_CBORConverter.ToObject<TO2AddressEntries>(obj[0]),
                To1dTo0dHash = Sample_CBORConverter.ToObject<Hash>(obj[1])
            };
            return to1dPayload;
        }
    }
}
