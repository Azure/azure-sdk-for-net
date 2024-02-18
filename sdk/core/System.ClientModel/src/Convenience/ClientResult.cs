// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;

namespace System.ClientModel;

public class ClientResult
{
    private readonly PipelineResponse _response;

    protected ClientResult(PipelineResponse response)
    {
        Argument.AssertNotNull(response, nameof(response));

        _response = response;
    }

    /// <summary>
    /// Returns the HTTP response returned by the service.
    /// </summary>
    /// <returns>The HTTP response returned by the service.</returns>
    public PipelineResponse GetRawResponse() => _response;

    #region Factory methods for ClientResult and subtypes

    public static ClientResult FromResponse(PipelineResponse response)
        => new ClientResult(response);

    public static ClientResult<T> FromValue<T>(T value, PipelineResponse response)
    {
        if (value is null)
        {
            string message = "ClientResult<T> contract guarantees that ClientResult<T>.Value is non-null. " +
                "If you need to return a ClientResult where the Value is null, please use call ClientResult.FromOptionalValue instead.";

            throw new ArgumentNullException(nameof(value), message);
        }

        return new ClientResult<T>(value, response);
    }

    public static ClientResult<T?> FromOptionalValue<T>(T? value, PipelineResponse response)
        => new ClientResult<T?>(value, response);

    #endregion
}
