// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Runtime.Serialization;

namespace System.ClientModel
{
    [Serializable]
    public class ClientRequestException : Exception, ISerializable
    {
        private readonly PipelineResponse? _response;

        /// <summary>
        /// Gets the HTTP status code of the response. Returns. <code>0</code> if response was not received.
        /// </summary>
        public int Status { get; }

        public ClientRequestException(PipelineResponse response)
            : this(response, GetMessageFromResponse(response))
        {
        }

        public ClientRequestException(PipelineResponse? response, string? message, Exception? innerException = default)
            : base(message, innerException)
        {
            _response = response;

            Status = response?.Status ?? 0;
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ClientRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Status = info.GetInt32(nameof(Status));
        }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info is null) throw new ArgumentNullException(nameof(info));

            info.AddValue(nameof(Status), Status);

            base.GetObjectData(info, context);
        }

        public PipelineResponse? GetRawResponse() => _response;

        private static string GetMessageFromResponse(PipelineResponse response)
        {
            // TODO: implement for real
            return $"Service error: {response.Status}";
        }
    }
}
