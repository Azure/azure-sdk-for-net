// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;

namespace System.ClientModel;

public abstract class ClientResult
{
    private readonly PipelineResponse _response;

    protected ClientResult(PipelineResponse response)
    {
        ClientUtilities.AssertNotNull(response, nameof(response));

        _response = response;
    }

    /// <summary>
    /// Returns the HTTP response returned by the service.
    /// </summary>
    /// <returns>The HTTP response returned by the service.</returns>
    public PipelineResponse GetRawResponse() => _response;

    #region Factory methods for ClientResult and subtypes

    public static ClientResult FromResponse(PipelineResponse response)
        => new ClientModelClientResult(response);

    public static ClientResult<T> FromValue<T>(T value, PipelineResponse response)
    {
        // Null values must use OptionalClientResult<T>
        if (value is null)
        {
            string message = "ClientResult<T> contract guarantees that ClientResult<T>.Value is non-null. " +
                "If you need to return an ClientResult where the Value is null, please use OptionalClientResult<T> instead.";

            throw new ArgumentNullException(nameof(value), message);
        }

        return new ClientModelClientResult<T>(value, response);
    }

    public static OptionalClientResult<T> FromOptionalValue<T>(T? value, PipelineResponse response)
        => new ClientModelOptionalClientResult<T>(value, response);

    #endregion

    #region Private implementation subtypes of abstract ClientResult types
    private class ClientModelClientResult : ClientResult
    {
        public ClientModelClientResult(PipelineResponse response)
            : base(response) { }
    }

    private class ClientModelOptionalClientResult<T> : OptionalClientResult<T>
    {
        public ClientModelOptionalClientResult(T? value, PipelineResponse response)
            : base(value, response) { }
    }

    private class ClientModelClientResult<T> : ClientResult<T>
    {
        public ClientModelClientResult(T value, PipelineResponse response)
            : base(value, response) { }
    }

    #endregion
}
