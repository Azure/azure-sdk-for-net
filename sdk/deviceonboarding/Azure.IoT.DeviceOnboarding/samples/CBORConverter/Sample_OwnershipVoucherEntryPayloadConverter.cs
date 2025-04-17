// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for OwnershipVoucherEntryPayload Object
    /// </summary>
    [CBORConverter(typeof(OwnershipVoucherEntryPayload))]
    internal sealed class Sample_OwnershipVoucherEntryPayloadConverter : ICBORToFromConverter<OwnershipVoucherEntryPayload>
    {
        private readonly CBORUtil cborUtil;

        public Sample_OwnershipVoucherEntryPayloadConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert OwnershipVoucherEntryPayload Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(OwnershipVoucherEntryPayload obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborObj = CBORObject.NewArray()
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.PreviousHash))
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.HeaderHash));

            if (obj.Extra != null)
            {
                _ = cborObj.Add(obj.Extra);
            }
            else
            {
                _ = cborObj.Add(CBORObject.Null);
            }
            _ = cborObj.Add(Sample_CBORConverter.FromObjectToCBOR(obj.OwnerPublicKey));

            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type OwnershipVoucherEntryPayload
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public OwnershipVoucherEntryPayload FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
#pragma warning disable CS8601 // Possible null reference assignment.
            OwnershipVoucherEntryPayload ownershipVoucherEntryPayload = new OwnershipVoucherEntryPayload
            {
                PreviousHash = Sample_CBORConverter.ToObject<Hash>(obj[0]),
                HeaderHash = Sample_CBORConverter.ToObject<Hash>(obj[1]),
                Extra = !obj[2].Equals(CBORObject.Null) ? obj[2].GetByteString() : null,
                OwnerPublicKey = Sample_CBORConverter.ToObject<PublicKey>(obj[3])
            };
            return ownershipVoucherEntryPayload;
#pragma warning restore CS8601 // Possible null reference assignment.
        }
    }
}
