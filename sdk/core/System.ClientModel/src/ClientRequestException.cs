// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Runtime.Serialization;

namespace System.ClientModel
{
    [Serializable]
    public class ClientRequestException : Exception, ISerializable
    {
        private const string DefaultMessage = "Service request failed.";

        private readonly PipelineResponse? _response;
        private int _status;

        /// <summary>
        /// Gets the HTTP status code of the response. Returns. <code>0</code> if response was not received.
        /// </summary>
        public int Status
        {
            get => _status;
            protected set => _status = value;
        }

        // Main constructor from Response
        public ClientRequestException(PipelineResponse response)
            : this(response, default, default)
        {
        }

        // Constructor from Response and InnerException
        public ClientRequestException(PipelineResponse response, Exception innerException)
            : this(response, default, innerException)
        {
        }

        // Constructor for case with no Response
        public ClientRequestException(string message, Exception? innerException = default)
            : this(default, message, innerException)
        {
        }

        // Base constructor that handles all cases.
        private ClientRequestException(PipelineResponse? response, string? message, Exception? innerException)
            : base(GetMessageFromResponse(response, message), innerException)
        {
            _response = response;
            _status = response?.Status ?? 0;
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ClientRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            _status = info.GetInt32(nameof(Status));
        }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ClientUtilities.AssertNotNull(info, nameof(info));

            info.AddValue(nameof(Status), Status);

            base.GetObjectData(info, context);
        }

        public PipelineResponse? GetRawResponse() => _response;

        // Create message from Response if available, and override message, if available.
        private static string GetMessageFromResponse(PipelineResponse? response, string? message)
        {
            // TODO: implement for real
            return $"Service error: {response?.Status}";
        }
    }
}
