﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using System.Net.ClientModel.Core;

namespace System.Net.ClientModel
{
    public class ClientRequestException : Exception
    {
        /// <summary>
        /// Gets the HTTP status code of the response. Returns. <code>0</code> if response was not received.
        /// </summary>
        public int Status { get; }

        public ClientRequestException(MessageResponse response) : base(GetMessageFromResponse(response))
        {
            Status = response.Status;
        }

        protected ClientRequestException(MessageResponse response, string message, Exception? innerException)
            // TODO: what is the actual behavior of the EBN RFE constructor that takes both erroCode and message?
            // Duplicate that here.
            : base(message, innerException)
        {
            Status = response.Status;
        }

        internal ClientRequestException(string message, Exception? innerException) : base(message, innerException)
        {
            // TODO: What is the experience if someone tries to access this.Response?
        }

        public virtual MessageResponse? GetRawResponse()
        {
            // Stubbed out for API review
            // TODO: pull over implementation from Azure.Core
            throw new NotImplementedException();
        }

        private static string GetMessageFromResponse(MessageResponse response)
        {
            // TODO: implement for real
            return $"Service error: {response.Status}";
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ClientRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Status = info.GetInt32(nameof(Status));
        }
    }
}
