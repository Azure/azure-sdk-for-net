// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using System.ServiceModel.Rest.Core;

namespace System.ServiceModel.Rest
{
    /// <summary>
    /// TODO
    /// </summary>
    public class RequestErrorException : Exception
    {
        /// <summary>
        /// Gets the HTTP status code of the response. Returns. <code>0</code> if response was not received.
        /// </summary>
        public int Status { get; }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="response"></param>
        public RequestErrorException(PipelineResponse response) : base(GetMessageFromresponse(response))
        {
            Status = response.Status;
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="response"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        protected RequestErrorException(PipelineResponse response, string message, Exception? innerException)
            // TODO: what is the actual behavior of the EBN RFE constructor that takes both erroCode and message?
            // Duplicate that here.
            : base(message, innerException)
        {
            Status = response.Status;
        }

        private static string GetMessageFromresponse(PipelineResponse response)
        {
            // TODO: implement for real
            return $"Service error: {response.Status}";
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected RequestErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Status = info.GetInt32(nameof(Status));
        }
    }
}
