// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for OwnershipVoucherHeader Object
    /// </summary>
	[CBORConverter(typeof(OwnershipVoucherHeader))]
    internal sealed class Sample_OwnershipVoucherHeaderConverter : ICBORToFromConverter<OwnershipVoucherHeader>
    {
        private readonly CBORUtil cborUtil;

        public Sample_OwnershipVoucherHeaderConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert OwnershipVoucherHeader Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(OwnershipVoucherHeader obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborObject = CBORObject.NewArray()
                .Add((ushort)obj.Version)
                .Add(obj.Guid.ToByteArray())
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.RendezvousInfo))
                .Add(obj.DeviceInfo)
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.PublicKey))
                .Add(obj.DeviceCertChainHash != null ? Sample_CBORConverter.FromObjectToCBOR(obj.DeviceCertChainHash) : CBORObject.Null);
            return cborObject;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type OwnershipVoucherHeader
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public OwnershipVoucherHeader FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
#pragma warning disable CA1062 // Validate arguments of public methods, validated as not null in ValidateCBORObjectIsArray
#pragma warning disable CS8601 // Possible null reference assignment.
            OwnershipVoucherHeader ownershipVoucherHeader = new OwnershipVoucherHeader
            {
                Version = (ProtocolVersion)obj[0].AsInt32(),
                Guid = new Guid(obj[1].GetByteString()),
                RendezvousInfo = Sample_CBORConverter.ToObject<RendezvousInfo>(obj[2]),
                DeviceInfo = obj[3].AsString(),
                PublicKey = Sample_CBORConverter.ToObject<PublicKey>(obj[4]),
                DeviceCertChainHash = (obj.Count > 5 && obj[5] != CBORObject.Null) ? Sample_CBORConverter.ToObject<Hash>(obj[5]) : null
            };
            return ownershipVoucherHeader;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CA1062 // Validate arguments of public methods
        }
    }
}
