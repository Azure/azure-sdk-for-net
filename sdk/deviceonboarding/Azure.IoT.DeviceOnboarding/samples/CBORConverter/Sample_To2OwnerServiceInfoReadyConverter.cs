// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples.CBORConverter
{
    /// <summary>
    /// Cbor Converter for TO2OwnerServiceInfoReady Object
    /// </summary>
    [CBORConverter(typeof(TO2OwnerServiceInfoReady))]
    internal class Sample_To2OwnerServiceInfoReadyConverter : ICBORToFromConverter<TO2OwnerServiceInfoReady>
    {
        private readonly CBORUtil cborUtil;

        public Sample_To2OwnerServiceInfoReadyConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert TO2OwnerServiceInfoReady Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(TO2OwnerServiceInfoReady obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborObj = CBORObject.NewArray();
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
        /// Parse CBORObjects and convert to the type TO2OwnerServiceInfoReady
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TO2OwnerServiceInfoReady FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
            TO2OwnerServiceInfoReady to2OwnerServiceInfoReady = new TO2OwnerServiceInfoReady
            {
                MaxMessageSize = obj[0].IsNull ? (ushort?)null : obj[0].AsNumber().ToUInt16Unchecked(),
            };
            return to2OwnerServiceInfoReady;
        }
    }
}
