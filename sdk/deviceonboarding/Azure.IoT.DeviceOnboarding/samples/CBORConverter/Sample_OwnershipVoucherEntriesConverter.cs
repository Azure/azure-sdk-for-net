// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography.Cose;
using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for OwnershipVoucherEntries Object
    /// </summary>
    [CBORConverter(typeof(OwnershipVoucherEntries))]
    internal sealed class Sample_OwnershipVoucherEntriesConverter : ICBORToFromConverter<OwnershipVoucherEntries>
    {
        private readonly CBORUtil cborUtil;

        public Sample_OwnershipVoucherEntriesConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert OwnershipVoucherEntries Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(OwnershipVoucherEntries obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            var cborObj = CBORObject.NewArray();
            foreach (CoseSign1Message coseSign1Message in obj)
            {
                byte[] encodedMessage = coseSign1Message.Encode();
                CBORObject signObject = CBORObject.DecodeFromBytes(encodedMessage);
                _ = cborObj.Add(signObject);
            }
            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type OwnershipVoucherEntries
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public OwnershipVoucherEntries FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
            var ownershipVoucherEntries = new OwnershipVoucherEntries();
            foreach (CBORObject cborObj in obj.Values)
            {
                byte[] msgBytes = cborObj.EncodeToBytes();
                CoseSign1Message coseSign1Message = CoseMessage.DecodeSign1(msgBytes);
                ownershipVoucherEntries.Add(coseSign1Message);
            }

            return ownershipVoucherEntries;
        }
    }
}
