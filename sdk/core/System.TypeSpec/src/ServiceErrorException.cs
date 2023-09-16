// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

namespace System.ServiceModel.Rest
{
    /// <summary>
    /// TODO
    /// </summary>
    public class ServiceErrorException : Exception
    {
        /// <summary>
        /// Gets the HTTP status code of the response. Returns. <code>0</code> if response was not received.
        /// </summary>
        public int Status { get; }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="result"></param>
        public ServiceErrorException(Result result) : base(GetMessageFromResult(result))
        {
            Status = result.Status;
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        protected ServiceErrorException(Result result, string message, Exception? innerException)
            // TODO: what is the actual behavior of the EBN RFE constructor that takes both erroCode and message?
            // Duplicate that here.
            : base(message, innerException)
        {
            Status = result.Status;
        }

        private static string GetMessageFromResult(Result result)
        {
            // TODO: implement for real
            return $"Service error: {result.Status}";
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ServiceErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Status = info.GetInt32(nameof(Status));
        }
    }
}
