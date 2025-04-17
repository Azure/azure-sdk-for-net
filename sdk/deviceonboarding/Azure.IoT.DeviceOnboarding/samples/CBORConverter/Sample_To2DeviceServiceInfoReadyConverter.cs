// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples.CBORConverter
{
    /// <summary>
    /// Cbor Converter for TO2DeviceServiceInfoReady Object
    /// </summary>
    [CBORConverter(typeof(TO2DeviceServiceInfoReady))]
    internal class Sample_To2DeviceServiceInfoReadyConverter : ICBORToFromConverter<TO2DeviceServiceInfoReady>
    {
        private readonly CBORUtil cborUtil;

        public Sample_To2DeviceServiceInfoReadyConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert TO2DeviceServiceInfoReady Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(TO2DeviceServiceInfoReady obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborObj = CBORObject.NewArray()
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.Hmac));

            if (obj.MaxMessageSize != null)
            {
                cborObj.Add((ushort)obj.MaxMessageSize);
            }
            else
            {
                cborObj.Add(CBORObject.Null);
            }

            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type TO2DeviceServiceInfoReady
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TO2DeviceServiceInfoReady FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
            TO2DeviceServiceInfoReady to2DeviceServiceInfoReady = new TO2DeviceServiceInfoReady
            {
                Hmac = Sample_CBORConverter.ToObject<Hash>(obj[0]),
                MaxMessageSize = obj[1].IsNull ? (ushort?)null : obj[1].AsNumber().ToUInt16Unchecked(),
            };
            return to2DeviceServiceInfoReady;
        }
    }
}
