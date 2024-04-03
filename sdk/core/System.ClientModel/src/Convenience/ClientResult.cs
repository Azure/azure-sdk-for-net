// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;

namespace System.ClientModel;

/// <summary>
/// Represents the result of a cloud service operation.
/// </summary>
public class ClientResult
{
    private readonly PipelineResponse _response;

    /// <summary>
    /// Create a new instance of <see cref="ClientResult"/> from a service
    /// response.
    /// </summary>
    /// <param name="response">The <see cref="PipelineResponse"/> received
    /// from the service.</param>
    protected ClientResult(PipelineResponse response)
    {
        Argument.AssertNotNull(response, nameof(response));

        _response = response;
    }

    /// <summary>
    /// Gets the <see cref="PipelineResponse"/> received from the service.
    /// </summary>
    /// <returns>the <see cref="PipelineResponse"/> received from the service.
    /// </returns>
    public PipelineResponse GetRawResponse() => _response;

    #region Factory methods for ClientResult and subtypes

    /// <summary>
    /// Creates a new instance of <see cref="ClientResult"/> that holds the
    /// <see cref="PipelineResponse"/> received from the service.
    /// </summary>
    /// <param name="response">The response received from the service.</param>
    /// <returns>A new instance of <see cref="ClientResult{T}"/> holding the
    /// provided <paramref name="response"/>.
    /// </returns>
    public static ClientResult FromResponse(PipelineResponse response)
        => new ClientResult(response);

    /// <summary>
    /// Creates a new instance of <see cref="ClientResult{T}"/> that holds the
    /// provided model value and <see cref="PipelineResponse"/> received from
    /// the service.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The strongly-typed representation of the service
    /// response payload value.</param>
    /// <param name="response">The response received from the service.</param>
    /// <returns>A new instance of <see cref="ClientResult{T}"/> holding the
    /// provided <paramref name="value"/> and <paramref name="response"/>.
    /// </returns>
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

    /// <summary>
    /// Creates a new instance of <see cref="ClientResult{T}"/> that holds the
    /// provided model value, if any, and the <see cref="PipelineResponse"/>
    /// received from the service. This method is used to create a return value
    /// for a service method representing a service operation that may or may not
    /// contain a payload. Callers of the client's service method must check
    /// whether <see cref="ClientResult{T}.Value"/> is null to determine whether
    /// the service provided a value in its response. Nullable annotations
    /// indicate to the end-user the need to check whether
    /// <see cref="ClientResult{T}.Value"/> is null.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The strongly-typed representation of the service
    /// response payload value.</param>
    /// <param name="response">The response received from the service.</param>
    /// <returns>A new instance of <see cref="ClientResult{T}"/> holding the
    /// provided <paramref name="value"/> and <paramref name="response"/>.
    /// </returns>
    public static ClientResult<T?> FromOptionalValue<T>(T? value, PipelineResponse response)
        => new ClientResult<T?>(value, response);

    #endregion
}
