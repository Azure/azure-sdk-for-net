// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Internal;

namespace System.ClientModel;

public abstract class OutputMessage
{
    private readonly PipelineResponse _response;

    protected OutputMessage(PipelineResponse response)
    {
        ClientUtilities.AssertNotNull(response, nameof(response));

        _response = response;
    }

    /// <summary>
    /// Returns the HTTP response returned by the service.
    /// </summary>
    /// <returns>The HTTP response returned by the service.</returns>
    public PipelineResponse GetRawResponse() => _response;

    #region Factory methods for OutputMessage and subtypes

    public static OutputMessage FromResponse(PipelineResponse response)
        => new ClientModelOutputMessage(response);

    public static OutputMessage<T> FromValue<T>(T value, PipelineResponse response)
    {
        // Null values must use OptionalOutputMessage<T>
        if (value is null)
        {
            string message = "OutputMessage<T> contract guarantees that OutputMessage<T>.Value is non-null. " +
                "If you need to return an OutputMessage where the Value is null, please use OptionalOutputMessage<T> instead.";

            throw new ArgumentNullException(nameof(value), message);
        }

        return new ClientModelOutputMessage<T>(value, response);
    }

    public static OptionalOutputMessage<T> FromOptionalValue<T>(T? value, PipelineResponse response)
        => new ClientModelOptionalOutputMessage<T>(value, response);

    #endregion

    #region Private implementation subtypes of abstract OutputMessage types
    private class ClientModelOutputMessage : OutputMessage
    {
        public ClientModelOutputMessage(PipelineResponse response)
            : base(response) { }
    }

    private class ClientModelOptionalOutputMessage<T> : OptionalOutputMessage<T>
    {
        public ClientModelOptionalOutputMessage(T? value, PipelineResponse response)
            : base(value, response) { }
    }

    private class ClientModelOutputMessage<T> : OutputMessage<T>
    {
        public ClientModelOutputMessage(T value, PipelineResponse response)
            : base(value, response) { }
    }

    #endregion
}
