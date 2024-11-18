// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading;

namespace System.ClientModel.Primitives.BidirectionalClients;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class BidirectionalClientResult
{
    private readonly BidirectionalPipelineResponse _response;

    protected BidirectionalClientResult(BidirectionalPipelineResponse response)
    {
        Argument.AssertNotNull(response, nameof(response));

        _response = response;
    }

    /// <summary>
    /// TBD
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public WebSocketResponse GetWebSocketResponse() => _response as WebSocketResponse ??
        throw new NotSupportedException();

    /// <summary>
    /// TBD
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    public static BidirectionalClientResult FromResponse(BidirectionalPipelineResponse response)
    {
        Argument.AssertNotNull(response, nameof(response));

        return new BidirectionalClientResult(response);
    }

    public static BidirectionalClientResult<T> FromValue<T>(T value, BidirectionalPipelineResponse response)
    {
        Argument.AssertNotNull(response, nameof(response));

        if (value is null)
        {
            string message = "BidirectionalClientResult<T> contract guarantees that BidirectionalClientResult<T>.Value is non-null. " +
                "If you need to return a BidirectionalClientResult where the Value is null, please use BidirectionalClientResult.FromOptionalValue instead.";

            throw new ArgumentNullException(nameof(value), message);
        }

        return new BidirectionalClientResult<T>(value, response);
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
