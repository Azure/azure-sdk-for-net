// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples.CBORConverter
{
    /// <summary>
    /// Cbor Converter for ErrorMessage Object
    /// </summary>
    [CBORConverter(typeof(ErrorMessage))]
    internal class Sample_ErrorMessageConverter : ICBORToFromConverter<ErrorMessage>
    {
        private readonly CBORUtil cborUtil;

        public Sample_ErrorMessageConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert ErrorMessage Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(ErrorMessage obj)
        {
            cborUtil.ValidateObjectNotNull(obj);
            CBORObject cborObj = CBORObject.NewArray()
                .Add((ushort)obj.ErrorCode)
                .Add((byte)obj.PrevMessageID)
                .Add(obj.Message)
                .Add(obj.TimeStamp)
                .Add((uint)obj.CorrelationID);

            return cborObj;
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type ErrorMessage
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ErrorMessage FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);
            ErrorMessage errorMessage = new ErrorMessage
            {
                ErrorCode = (ErrorCodes)obj[0].AsInt32(),
                PrevMessageID = obj[1].ToObject<byte>(),
                Message = obj[2].AsString(),
                TimeStamp = obj[3].AsString(),
                CorrelationID = obj[4].AsNumber().ToUInt32Unchecked(),
            };
            return errorMessage;
        }
    }
}
