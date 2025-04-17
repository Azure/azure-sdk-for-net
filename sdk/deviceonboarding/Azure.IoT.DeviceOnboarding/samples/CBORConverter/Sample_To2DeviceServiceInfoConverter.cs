// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples.CBORConverter
{
    /// <summary>
    /// Cbor Converter for TO2DeviceServiceInfo Object
    /// </summary>
    [CBORConverter(typeof(TO2DeviceServiceInfo))]
    internal sealed class Sample_To2DeviceServiceInfoConverter : ICBORToFromConverter<TO2DeviceServiceInfo>
    {
        private readonly CBORUtil cborUtil;

        public Sample_To2DeviceServiceInfoConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert TO2DeviceServiceInfo Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(TO2DeviceServiceInfo obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborArray = CBORObject.NewArray()
                .Add(obj.IsMoreServiceInfo)
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.ServiceInfo));
            return cborArray;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type TO2DeviceServiceInfo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TO2DeviceServiceInfo FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
            var value = new TO2DeviceServiceInfo
            {
                IsMoreServiceInfo = obj[0].AsBoolean(),
                ServiceInfo = Sample_CBORConverter.ToObject<ServiceInfo>(obj[1])
            };

            return value;
        }
    }
}
