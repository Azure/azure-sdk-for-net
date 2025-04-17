// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure.IoT.DeviceOnboarding.Models;
using Microsoft.Identity.Client;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples.CBORConverter
{
    /// <summary>
    /// Cbor Converter for TO2ProveDevice Object
    /// </summary>
    [CBORConverter(typeof(TO2ProveDevice))]
    internal class Sample_To2ProveDeviceConverter : ICBORToFromConverter<TO2ProveDevice>
    {
        private readonly CBORUtil cborUtil;

        public Sample_To2ProveDeviceConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert TO2ProveDevice Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(TO2ProveDevice obj)
        {
            cborUtil.ValidateObjectNotNull(obj);

            var cborObj = CBORObject.NewMap();

            if (obj.Nonce != null)
            {
                _ = cborObj.Add(FDOConstants.EatNonce, obj.Nonce.NonceValue);
            }
            if (obj.Guid != Guid.Empty)
            {
                cborUtil.AddUeidToCBOR(obj.Guid, cborObj, FDOConstants.EatRand,
                     FDOConstants.EatUeid, FDOConstants.UeidByteArraySize);
            }
            if (obj.FdoClaim != null)
            {
                TO2ProveDevicePayload to2ProveDevicePayload = (TO2ProveDevicePayload)Convert.ChangeType(obj.FdoClaim, typeof(TO2ProveDevicePayload), CultureInfo.InvariantCulture);
                _ = cborObj.Add(FDOConstants.EatFdo, Sample_CBORConverter.FromObjectToCBOR(to2ProveDevicePayload));
            }

            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type TO2ProveDevice
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TO2ProveDevice FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsMap(obj);

            var to2ProveDevice = new TO2ProveDevice();

            if (obj.ContainsKey(FDOConstants.EatNonce))
            {
                to2ProveDevice.Nonce = Sample_CBORConverter.ToObject<FDONonce>(obj[FDOConstants.EatNonce]);
            }

            if (obj.ContainsKey(FDOConstants.EatUeid))
            {
                cborUtil.ValidateByteStringWithSize(obj[FDOConstants.EatUeid], FDOConstants.UeidByteArraySize);
                byte[] byteArr = obj[FDOConstants.EatUeid].GetByteString();
                to2ProveDevice.Guid = cborUtil.ExtractGuidFromUEID(byteArr, FDOConstants.GuidByteArraySize, FDOConstants.EatRand);
            }

            if (obj.ContainsKey(FDOConstants.EatFdo))
            {
                TO2ProveDevicePayload to2ProveDevicePayload = Sample_CBORConverter.ToObject<TO2ProveDevicePayload>(obj[FDOConstants.EatFdo]);
                to2ProveDevice.FdoClaim = to2ProveDevicePayload;
            }

            return to2ProveDevice;
        }
    }
}
