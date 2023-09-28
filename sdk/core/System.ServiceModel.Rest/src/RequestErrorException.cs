﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using System.ServiceModel.Rest.Core;

namespace System.ServiceModel.Rest
{
    public class RequestErrorException : Exception
    {
        /// <summary>
        /// Gets the HTTP status code of the response. Returns. <code>0</code> if response was not received.
        /// </summary>
        public int Status { get; }

        public RequestErrorException(PipelineResponse response) : base(GetMessageFromResponse(response))
        {
            Status = response.Status;
        }

        protected RequestErrorException(PipelineResponse response, string message, Exception? innerException)
            // TODO: what is the actual behavior of the EBN RFE constructor that takes both erroCode and message?
            // Duplicate that here.
            : base(message, innerException)
        {
            Status = response.Status;
        }

        internal RequestErrorException(string message, Exception? innerException) : base(message, innerException)
        {
            // TODO: What is the experience if someone tries to access this.Response?
        }

        private static string GetMessageFromResponse(PipelineResponse response)
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
