// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using System.ClientModel.Primitives;
using System.ClientModel.Internal;

namespace System.ClientModel
{
    [Serializable]
    public class ClientRequestException : Exception, ISerializable
    {
        /// <summary>
        /// Gets the HTTP status code of the response. Returns. <code>0</code> if response was not received.
        /// </summary>
        public int Status { get; }

        public ClientRequestException(PipelineResponse response)
            : base(GetMessageFromResponse(response))
        {
            Status = response.Status;
        }

        public ClientRequestException(int? status, string? message, Exception? innerException = default)
            : base(message, innerException)
        {
            Status = status ?? 0;
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

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ClientUtilities.AssertNotNull(info, nameof(info));

            info.AddValue(nameof(Status), Status);

            base.GetObjectData(info, context);
        }

        public virtual PipelineResponse? GetRawResponse()
        {
            // Stubbed out for API review
            // TODO: pull over implementation from Azure.Core
            throw new NotImplementedException();
        }

        private static string GetMessageFromResponse(PipelineResponse response)
        {
            // TODO: implement for real
            return $"Service error: {response.Status}";
        }
    }
}
