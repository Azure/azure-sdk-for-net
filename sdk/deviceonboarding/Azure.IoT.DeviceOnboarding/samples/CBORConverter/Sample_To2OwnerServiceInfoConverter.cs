// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples.CBORConverter
{
    /// <summary>
    /// Cbor Converter for TO2OwnerServiceInfo Object
    /// </summary>
    [CBORConverter(typeof(TO2OwnerServiceInfo))]
    internal sealed class Sample_To2OwnerServiceInfoConverter : ICBORToFromConverter<TO2OwnerServiceInfo>
    {
        private readonly CBORUtil cborUtil;

        public Sample_To2OwnerServiceInfoConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert TO2OwnerServiceInfo Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(TO2OwnerServiceInfo obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborArray = CBORObject.NewArray()
                .Add(obj.IsMoreServiceInfo)
                .Add(obj.IsDone)
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.ServiceInfo));
            return cborArray;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type TO2OwnerServiceInfo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TO2OwnerServiceInfo FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
            var value = new TO2OwnerServiceInfo
            {
                IsMoreServiceInfo = obj[0].AsBoolean(),
                IsDone = obj[1].AsBoolean(),
                ServiceInfo = Sample_CBORConverter.ToObject<ServiceInfo>(obj[2])
            };
            return value;
        }
    }
}
