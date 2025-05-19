// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples.CBORConverter
{
    /// <summary>
    /// Cbor Converter for RendezvousDirective Object
    /// </summary>
    [CBORConverter(typeof(RendezvousDirective))]
    internal sealed class Sample_RendezvousDirectiveConverter : ICBORToFromConverter<RendezvousDirective>
    {
        private readonly CBORUtil cborUtil;

        public Sample_RendezvousDirectiveConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert RendezvousDirective Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(RendezvousDirective obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            var cborObj = CBORObject.NewArray();
            foreach (RendezvousInstruction rendezvousInstruction in obj)
            {
                _ = cborObj.Add(Sample_CBORConverter.FromObjectToCBOR(rendezvousInstruction));
            }
            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type RendezvousDirective
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public RendezvousDirective FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);

            var rendezvousDirective = new RendezvousDirective();
            foreach (CBORObject cborObj in obj.Values)
            {
                rendezvousDirective.Add(Sample_CBORConverter.ToObject<RendezvousInstruction>(cborObj));
            }
            return rendezvousDirective;
        }
    }
}
