// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace System.ClientModel;

/// <summary>
/// The exception that is thrown when the processing of a client request failed.
/// </summary>
[Serializable]
public class ClientResultException : Exception, ISerializable
{
    private const string DefaultMessage = "Service request failed.";

    private readonly PipelineResponse? _response;
    private int _status;

    /// <summary>
    /// Asynchronously create an instance of <see cref="ClientResultException"/>
    /// from the <see cref="PipelineResponse"/> containing the details of the
    /// service's error response.
    /// </summary>
    /// <param name="response">The service's error response.</param>
    /// <param name="innerException">The <see cref="Exception.InnerException"/>,
    /// if any, that threw the current exception.</param>
    /// <returns>The <see cref="ClientResultException"/> instance that was
    /// created.</returns>
    public static async Task<ClientResultException> CreateAsync(PipelineResponse response, Exception? innerException = default)
    {
        string message = await CreateMessageAsync(response).ConfigureAwait(false);
        return new ClientResultException(message, response, innerException);
    }

    /// <summary>
    /// Gets the HTTP status code of the response. Returns. <code>0</code> if response was not received.
    /// </summary>
    public int Status
    {
        get => _status;
        protected set => _status = value;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ClientResultException"/> from a
    /// <see cref="PipelineResponse"/> containing the details of the service's
    /// error response.  The <see cref="Exception.Message"/> is created from the
    /// provided <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The service's error response.</param>
    /// <param name="innerException">The <see cref="Exception.InnerException"/>,
    /// if any, that threw the current exception.</param>
    public ClientResultException(PipelineResponse response, Exception? innerException = default)
        : base(CreateMessage(response), innerException)
    {
        Argument.AssertNotNull(response, nameof(response));

        _response = response;
        _status = response.Status;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ClientResultException"/> with a
    /// custom exception message and an optional <see cref="PipelineResponse"/>.
    /// The <see cref="Exception.Message"/> is set to <paramref name="response"/>
    /// and if <paramref name="response"/> is provided, it will be returned from
    /// calls to this exception instance's <see cref="GetRawResponse"/> method.
    /// </summary>
    /// <param name="message">The message to set on <see cref="Exception.Message"/>.
    /// </param>
    /// <param name="response">The response, if any, to return from
    /// <see cref="GetRawResponse"/>.</param>
    /// <param name="innerException">The <see cref="Exception.InnerException"/>,
    /// if any, that threw the current exception.</param>
    public ClientResultException(string message, PipelineResponse? response = default, Exception? innerException = default)
        : base(message ?? DefaultMessage, innerException)
    {
        _response = response;
        _status = response?.Status ?? 0;
    }

    /// <inheritdoc />
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

    /// <summary>
    /// Gets the <see cref="PipelineResponse"/>, if any, that led to the exception.
    /// </summary>
    /// <returns>The <see cref="PipelineResponse"/>, if any, that led to the exception.</returns>
    public PipelineResponse? GetRawResponse() => _response;

    private static string CreateMessage(PipelineResponse response)
        => CreateMessageSyncOrAsync(response, async: false).EnsureCompleted();

    private static async ValueTask<string> CreateMessageAsync(PipelineResponse response)
        => await CreateMessageSyncOrAsync(response, async: true).ConfigureAwait(false);

    private static async ValueTask<string> CreateMessageSyncOrAsync(PipelineResponse response, bool async)
    {
        if (async)
        {
            await response.BufferContentAsync().ConfigureAwait(false);
        }
        else
        {
            response.BufferContent();
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
}
