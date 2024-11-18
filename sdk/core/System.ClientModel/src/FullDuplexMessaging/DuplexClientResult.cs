// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading;

namespace System.ClientModel.Primitives.FullDuplexMessaging;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class DuplexClientResult
{
    private readonly DuplexPipelineResponse _response;

    protected DuplexClientResult(DuplexPipelineResponse response)
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
    public static DuplexClientResult FromResponse(DuplexPipelineResponse response)
    {
        Argument.AssertNotNull(response, nameof(response));

        return new DuplexClientResult(response);
    }

    public static DuplexClientResult<T> FromValue<T>(T value, DuplexPipelineResponse response)
    {
        Argument.AssertNotNull(response, nameof(response));

        if (value is null)
        {
            string message = "DuplexClientResult<T> contract guarantees that DuplexClientResult<T>.Value is non-null. " +
                "If you need to return a DuplexClientResult where the Value is null, please use DuplexClientResult.FromOptionalValue instead.";

            throw new ArgumentNullException(nameof(value), message);
        }

        return new DuplexClientResult<T>(value, response);
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
