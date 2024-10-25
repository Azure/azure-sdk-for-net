// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading;

namespace System.ClientModel.Primitives.TwoWayClient;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class TwoWayResult
{
    private readonly TwoWayPipelineServiceMessage _response;

    protected TwoWayResult(TwoWayPipelineServiceMessage response)
    {
        Argument.AssertNotNull(response, nameof(response));

        _response = response;
    }

    /// <summary>
    /// TBD
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public WebSocketServiceMessage GetWebSocketResponse() => _response as WebSocketServiceMessage ??
        throw new NotSupportedException();

    /// <summary>
    /// TBD
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    public static TwoWayResult FromResponse(TwoWayPipelineServiceMessage response)
    {
        Argument.AssertNotNull(response, nameof(response));

        return new TwoWayResult(response);
    }

    public static TwoWayResult<T> FromValue<T>(T value, TwoWayPipelineServiceMessage response)
    {
        Argument.AssertNotNull(response, nameof(response));

        if (value is null)
        {
            string message = "TwoWayResult<T> contract guarantees that TwoWayResult<T>.Value is non-null. " +
                "If you need to return a TwoWayResult where the Value is null, please use TwoWayResult.FromOptionalValue instead.";

            throw new ArgumentNullException(nameof(value), message);
        }

        return new TwoWayResult<T>(value, response);
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
