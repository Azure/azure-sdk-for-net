// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;

namespace System.ClientModel;

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

    // Constructor from Response and InnerException
    public ClientRequestException(PipelineResponse response, string? message = default, Exception? innerException = default)
        : base(GetMessage(message, response), innerException)
    {
        _response = response;
        _status = response.Status;
    }

    // Constructor for case with no Response
    public ClientRequestException(string message, Exception? innerException = default)
        : base(message, innerException)
    {
        _status = 0;
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
    private static string GetMessage(string? message, PipelineResponse? response)
    {
        // Setting the message will override extracting it from the response.
        if (message is not null)
        {
            return message;
        }

        if (response is null)
        {
            return DefaultMessage;
        }

        if (!response.TryGetBufferedContent(out _))
        {
            BufferResponse(response);
        }

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

    private static void BufferResponse(PipelineResponse response)
    {
        if (response.ContentStream is null)
        {
            return;
        }

        var bufferedStream = new MemoryStream();
        response.ContentStream.CopyTo(bufferedStream);

        // Dispose the unbuffered stream
        response.ContentStream.Dispose();

        // Reset the position of the buffered stream and set it on the response
        bufferedStream.Position = 0;
        response.ContentStream = bufferedStream;
    }
}
