// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for TO1ProveToRV Object
    /// </summary>
    [CBORConverter(typeof(TO1ProveToRV))]
    internal class Sample_To1ProveToRVConverter : ICBORToFromConverter<TO1ProveToRV>
    {
        private readonly CBORUtil cborUtil;

        public Sample_To1ProveToRVConverter()
        {
            cborUtil = new CBORUtil();
        }
        /// <summary>
        /// Convert TO1ProveToRV Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(TO1ProveToRV obj)
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

            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type TO1ProveToRV
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TO1ProveToRV FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsMap(obj);

            var to1ProveToRV = new TO1ProveToRV();

            if (obj.ContainsKey(FDOConstants.EatNonce))
            {
                to1ProveToRV.Nonce = Sample_CBORConverter.ToObject<FDONonce>(obj[FDOConstants.EatNonce]);
            }

            if (obj.ContainsKey(FDOConstants.EatUeid))
            {
                cborUtil.ValidateByteStringWithSize(obj[FDOConstants.EatUeid], FDOConstants.UeidByteArraySize);
                byte[] byteArr = obj[FDOConstants.EatUeid].GetByteString();
                to1ProveToRV.Guid = cborUtil.ExtractGuidFromUEID(byteArr, FDOConstants.GuidByteArraySize, FDOConstants.EatRand);
            }

            return to1ProveToRV;
        }
    }
    }
