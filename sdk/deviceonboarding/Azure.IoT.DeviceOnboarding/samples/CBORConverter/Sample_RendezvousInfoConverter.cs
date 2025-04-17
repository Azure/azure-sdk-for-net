// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples.CBORConverter
{
    /// <summary>
    /// Cbor Converter for RendezvousInfo Object
    /// </summary>
    [CBORConverter(typeof(RendezvousInfo))]
    internal sealed class Sample_RendezvousInfoConverter : ICBORToFromConverter<RendezvousInfo>
    {
        private readonly CBORUtil cborUtil;

        public Sample_RendezvousInfoConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert RendezvousInfo Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(RendezvousInfo obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            var cborObj = CBORObject.NewArray();
            foreach (RendezvousDirective rendezvousDirective in obj)
            {
                _ = cborObj.Add(Sample_CBORConverter.FromObjectToCBOR(rendezvousDirective));
            }
            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type RendezvousInfo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public RendezvousInfo FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);

            var rendezvousInfo = new RendezvousInfo();
            foreach (CBORObject cborObj in obj.Values)
            {
                rendezvousInfo.Add(Sample_CBORConverter.ToObject<RendezvousDirective>(cborObj));
            }
            return rendezvousInfo;
        }
    }
}
