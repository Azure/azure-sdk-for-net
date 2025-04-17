// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for ServiceInfoKeyValuePair Object
    /// </summary>
    [CBORConverter(typeof(ServiceInfoKeyValuePair))]
    internal sealed class Sample_ServiceInfoKeyValuePairConverter : ICBORToFromConverter<ServiceInfoKeyValuePair>
    {
        private readonly CBORUtil cborUtil;

        public Sample_ServiceInfoKeyValuePairConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert ServiceInfoKeyValuePair Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(ServiceInfoKeyValuePair obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborArray = CBORObject.NewArray()
                .Add(obj.Key)
                .Add(obj.Value);
            return cborArray;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type ServiceInfoKeyValuePair
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ServiceInfoKeyValuePair FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
            var keyValuePair = new ServiceInfoKeyValuePair
            {
                Key = obj[0].AsString(),
                Value = obj[1].GetByteString()
            };
            return keyValuePair;
        }
    }
}
