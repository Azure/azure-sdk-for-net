// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for ServiceInfo Object
    /// </summary>
    [CBORConverter(typeof(ServiceInfo))]
    internal sealed class Sample_ServiceInfoConverter : ICBORToFromConverter<ServiceInfo>
    {
        private readonly CBORUtil cborUtil;

        public Sample_ServiceInfoConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert ServiceInfo Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(ServiceInfo obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            var cborArray = CBORObject.NewArray();
            foreach (ServiceInfoKeyValuePair keyValuePair in obj)
            {
                _ = cborArray.Add(Sample_CBORConverter.FromObjectToCBOR(keyValuePair));
            }
            return cborArray;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type ServiceInfo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ServiceInfo FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
            var list = new ServiceInfo();

            foreach (CBORObject keyValuePair in obj.Values)
            {
                ServiceInfoKeyValuePair item = Sample_CBORConverter.ToObject<ServiceInfoKeyValuePair>(keyValuePair);
                _ = list.AddLast(item);
            }

            return list;
        }
    }
}
