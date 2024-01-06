// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace System.ClientModel;

[Serializable]
public class ClientResultException : Exception, ISerializable
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

    public ClientResultException(PipelineResponse response, Exception? innerException = default)
        : base(CreateMessage(response), innerException)
    {
        Argument.AssertNotNull(response, nameof(response));

        _response = response;
        _status = response.Status;
    }

    public ClientResultException(string message, PipelineResponse? response = default, Exception? innerException = default)
        : base(message ?? DefaultMessage, innerException)
    {
        _response = response;
        _status = response?.Status ?? 0;
    }

    /// <summary>
    /// TBD
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected ClientResultException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
        _status = info.GetInt32(nameof(Status));
    }

    /// <inheritdoc />
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        Argument.AssertNotNull(info, nameof(info));

        info.AddValue(nameof(Status), Status);

        base.GetObjectData(info, context);
    }

    public PipelineResponse? GetRawResponse() => _response;

    private static string CreateMessage(PipelineResponse response)
    {
        response.BufferContent();

        StringBuilder messageBuilder = new();

        messageBuilder
            .AppendLine(DefaultMessage)
            .Append("Status: ")
            .Append(response.Status.ToString(CultureInfo.InvariantCulture));

        if (!string.IsNullOrEmpty(response.ReasonPhrase))
        {
            messageBuilder.Append(" (")
                .Append(response.ReasonPhrase)
                .AppendLine(")");
        }
        else
        {
            messageBuilder.AppendLine();
        }

        // Content or headers can be obtained from raw response so are not added here.

        return messageBuilder.ToString();
    }
}
