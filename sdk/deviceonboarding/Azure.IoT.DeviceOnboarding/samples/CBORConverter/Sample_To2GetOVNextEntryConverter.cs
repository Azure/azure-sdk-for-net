// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples.CBORConverter
{
    /// <summary>
    /// Cbor Converter for To2GetNextEntry Object
    /// </summary>
    [CBORConverter(typeof(TO2GetOVNextEntry))]
    internal class Sample_To2GetOVNextEntryConverter : ICBORToFromConverter<TO2GetOVNextEntry>
    {
        private readonly CBORUtil cborUtil;

        public Sample_To2GetOVNextEntryConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert To2GetNextEntry Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(TO2GetOVNextEntry obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborObj = CBORObject.NewArray()
                .Add((byte)obj.EntryNumber);
            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type To2GetNextEntry
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TO2GetOVNextEntry FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
            TO2GetOVNextEntry to2GetNextEntry = new TO2GetOVNextEntry
            {
                EntryNumber = Sample_CBORConverter.ToObject<byte>(obj[0]),
            };
            return to2GetNextEntry;
        }
    }
}
