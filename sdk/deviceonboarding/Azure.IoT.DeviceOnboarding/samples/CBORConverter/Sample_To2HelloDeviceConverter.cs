// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples.CBORConverter
{
    /// <summary>
    /// Cbor Converter for TO2HelloDevice Object
    /// </summary>
    [CBORConverter(typeof(TO2HelloDevice))]
    internal sealed class Sample_To2HelloDeviceConverter : ICBORToFromConverter<TO2HelloDevice>
    {
        private readonly CBORUtil cborUtil;

        public Sample_To2HelloDeviceConverter()
        {
            cborUtil = new CBORUtil();
        }
        /// <summary>
        /// Convert TO2HelloDevice Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(TO2HelloDevice obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborObj = CBORObject.NewArray()
                .Add((ushort)obj.MaxMessageSize)
                .Add(obj.Guid.ToByteArray())
                .Add(obj.NonceProveTo2Ov.NonceValue)
                .Add(obj.KexSuiteName)
                .Add((int)obj.CipherSuiteType)
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.EASigInfo));
            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type TO2HelloDevice
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TO2HelloDevice FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
            TO2HelloDevice to2HelloDevice = new TO2HelloDevice
            {
                MaxMessageSize = obj[0].AsNumber().ToUInt16Unchecked(),
                Guid = new Guid(obj[1].GetByteString()),
                NonceProveTo2Ov = new FDONonce(obj[2].GetByteString()),
                KexSuiteName = obj[3].AsString(),
                CipherSuiteType = (CipherSuiteType)obj[4].AsInt32(),
                EASigInfo = Sample_CBORConverter.ToObject<SigInfo>(obj[5]),
            };
            return to2HelloDevice;
        }
    }
}
