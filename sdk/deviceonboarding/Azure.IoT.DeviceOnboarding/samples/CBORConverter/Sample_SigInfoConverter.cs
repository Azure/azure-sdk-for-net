// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for SigInfo Object
    /// </summary>
    [CBORConverter(typeof(SigInfo))]
    internal sealed class Sample_SigInfoConverter : ICBORToFromConverter<SigInfo>
    {
        private readonly CBORUtil cborUtil;

        public Sample_SigInfoConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert SigInfo Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(SigInfo obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborObj = CBORObject.NewArray()
                .Add((int)obj.SigInfoType)
                .Add(obj.Info);
            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type SigInfo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public SigInfo FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
            SigInfo sigInfo = new SigInfo
            {
                SigInfoType = (DeviceSgType)obj[0].AsInt32(),
                Info = obj[1].GetByteString()
            };
            return sigInfo;
        }
    }
}
