// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for TO2AddressEntry Object
    /// </summary>
    [CBORConverter(typeof(TO2AddressEntry))]
    internal sealed class Sample_To2AddressEntryConverter : ICBORToFromConverter<TO2AddressEntry>
    {
        private readonly CBORUtil cborUtil;

        public Sample_To2AddressEntryConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert TO2AddressEntry Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(TO2AddressEntry obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject to2AddressEntry = CBORObject.NewArray();

            if (obj.IpAddress != null)
            {
                _ = to2AddressEntry.Add(obj.IpAddress);
            }
            else
            {
                _ = to2AddressEntry.Add(CBORObject.Null);
            }

            if (obj.DnsAddress != null)
            {
                _ = to2AddressEntry.Add(obj.DnsAddress);
            }
            else
            {
                _ = to2AddressEntry.Add(CBORObject.Null);
            }

            to2AddressEntry.Add((ushort)obj.Port);
            to2AddressEntry.Add((ushort)obj.Protocol);

            return to2AddressEntry;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type TO2AddressEntry
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TO2AddressEntry FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);

            string dnsAddress = null;
            if (obj[1].Type == CBORType.TextString)
            {
                dnsAddress = obj[1].AsString();
            }

            var to2AddressEntry = new TO2AddressEntry
            {
                IpAddress = obj[0].ToObject<byte[]>(),
                DnsAddress = dnsAddress,
                Port = obj[2].AsNumber().ToUInt16Unchecked(),
                Protocol = (TransportProtocol)obj[3].AsInt32(),
            };

            return to2AddressEntry;
        }
    }
}
