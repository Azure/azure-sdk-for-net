// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for TO2AddressEntries Object
    /// </summary>
    [CBORConverter(typeof(TO2AddressEntries))]
    internal sealed class Sample_To2AddressEntriesConverter : ICBORToFromConverter<TO2AddressEntries>
    {
        private readonly CBORUtil cborUtil;

        public Sample_To2AddressEntriesConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert TO2AddressEntries Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(TO2AddressEntries obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            var cborArray = CBORObject.NewArray();
            foreach (TO2AddressEntry entry in obj)
            {
                _ = cborArray.Add(Sample_CBORConverter.FromObjectToCBOR(entry));
            }
            return cborArray;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type TO2AddressEntries
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TO2AddressEntries FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
            var list = new TO2AddressEntries();

            foreach (CBORObject entry in obj.Values)
            {
                TO2AddressEntry item = Sample_CBORConverter.ToObject<TO2AddressEntry>(entry);
                _ = list.AddLast(item);
            }
            return list;
        }
    }
}
