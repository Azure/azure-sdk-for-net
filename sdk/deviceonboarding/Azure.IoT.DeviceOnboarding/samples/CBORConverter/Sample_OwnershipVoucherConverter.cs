// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples.CBORConverter
{
    /// <summary>
    /// Cbor Converter for OwnershipVoucher Object
    /// </summary>
    [CBORConverter(typeof(OwnershipVoucher))]
    internal sealed class Sample_OwnershipVoucherConverter : ICBORToFromConverter<OwnershipVoucher>
    {
        private readonly CBORUtil cborUtil;

        public Sample_OwnershipVoucherConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert OwnershipVoucher Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(OwnershipVoucher obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborObj = CBORObject.NewArray()
                .Add((ushort)obj.Version)
                .Add(obj.Header)
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.HeaderHmac))
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.DeviceCertChain))
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.OwnerEntries));

            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type OwnershipVoucher
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public OwnershipVoucher FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
#pragma warning disable CA1062 // Validate arguments of public methods, validated as not null in ValidateCBORObjectIsArray
#pragma warning disable CS8601 // Possible null reference assignment.
            OwnershipVoucher ov = new OwnershipVoucher
            {
                Version = (ProtocolVersion)obj[0].AsInt32(),
                Header = obj[1].GetByteString(),
                HeaderHmac = Sample_CBORConverter.ToObject<Hash>(obj[2]),
                DeviceCertChain = Sample_CBORConverter.ToObject<CertChain>(obj[3]),
                OwnerEntries = Sample_CBORConverter.ToObject<OwnershipVoucherEntries>(obj[4])
            };

            return ov;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CA1062 // Validate arguments of public methods
        }
    }
}
