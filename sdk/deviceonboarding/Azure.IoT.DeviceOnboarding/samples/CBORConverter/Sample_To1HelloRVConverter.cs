// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for TO1HelloRV Object
    /// </summary>
    [CBORConverter(typeof(TO1HelloRV))]
    internal class Sample_To1HelloRVConverter : ICBORToFromConverter<TO1HelloRV>
    {
        private readonly CBORUtil cborUtil;

        public Sample_To1HelloRVConverter()
        {
            cborUtil = new CBORUtil();
        }
        /// <summary>
        /// Convert TO1HelloRV Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(TO1HelloRV obj)
        {
            cborUtil.ValidateObjectNotNull(obj);

            CBORObject cborObj = CBORObject.NewArray()
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.Guid.ToByteArray()))
                .Add(Sample_CBORConverter.FromObjectToCBOR(obj.EASigInfo));
            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type TO1HelloRV
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TO1HelloRV FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);

#pragma warning disable CA1062 // Validate arguments of public methods; validated as not null in ValidateCBORObjectIsArray
            TO1HelloRV to1HelloRV = new TO1HelloRV()
            {
                Guid = new Guid(obj[0].GetByteString()),
                EASigInfo = Sample_CBORConverter.ToObject<SigInfo>(obj[1])
            };
#pragma warning restore CA1062 // Validate arguments of public methods
            return to1HelloRV;
        }
    }
}
