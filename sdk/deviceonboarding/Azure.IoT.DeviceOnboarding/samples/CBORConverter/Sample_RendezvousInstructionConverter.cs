// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for RendezvousInstruction Object
    /// </summary>
    [CBORConverter(typeof(RendezvousInstruction))]
    internal sealed class Sample_RendezvousInstructionConverter : ICBORToFromConverter<RendezvousInstruction>
    {
        private readonly CBORUtil cborUtil;

        public Sample_RendezvousInstructionConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert RendezvousInstruction Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(RendezvousInstruction obj)
        {
            cborUtil.ValidateObjectNotNull(obj);

            CBORObject cborObj = CBORObject.NewArray()
                .Add((byte)obj.Variable);

            if (obj.Variable is RendezvousVariable.DEV_ONLY ||
                obj.Variable is RendezvousVariable.OWNER_ONLY ||
                obj.Variable is RendezvousVariable.BYPASS)
            {
                return cborObj;
            }
            _ = cborObj.Add(obj.Value);
            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type RendezvousInstruction
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public RendezvousInstruction FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateObjectNotNull(obj);

            var rendezvousInstruction = new RendezvousInstruction();

            var variable = (RendezvousVariable)(obj[0].ToObject<byte>());
            rendezvousInstruction.Variable = variable;

            if (obj.Count > 1)
            {
                byte[] value = obj[1].GetByteString();
                rendezvousInstruction.Value = value;
            }
            return rendezvousInstruction;
        }
    }
}
