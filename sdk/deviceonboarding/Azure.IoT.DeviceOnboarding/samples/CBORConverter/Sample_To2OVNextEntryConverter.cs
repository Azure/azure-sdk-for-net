// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography.Cose;
using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for TO2OVNextEntry Object
    /// </summary>
    [CBORConverter(typeof(TO2OVNextEntry))]
    internal class Sample_To2OVNextEntryConverter : ICBORToFromConverter<TO2OVNextEntry>
    {
        private readonly CBORUtil cborUtil;

        public Sample_To2OVNextEntryConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert TO2OVNextEntry Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(TO2OVNextEntry obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            byte[] encodedMessage = obj.Entry.Encode();
            CBORObject signObject = CBORObject.DecodeFromBytes(encodedMessage);
            CBORObject cborObj = CBORObject.NewArray()
                .Add((byte)obj.EntryNumber)
                .Add(signObject);
            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type TO2OVNextEntry
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TO2OVNextEntry FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
#pragma warning disable CA1062 // Validate arguments of public methods; validated as not null in ValidateCBORObjectIsArray
            byte[] msgBytes = obj[1].EncodeToBytes();
            CoseSign1Message coseSign1Message = CoseMessage.DecodeSign1(msgBytes);
            TO2OVNextEntry to2OvNextEntry = new TO2OVNextEntry
            {
                EntryNumber = Sample_CBORConverter.ToObject<byte>(obj[0]),
                Entry = coseSign1Message
            };
#pragma warning restore CA1062 // Validate arguments of public methods
            return to2OvNextEntry;
        }
    }
}
