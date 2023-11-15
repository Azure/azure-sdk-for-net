// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Internal;

namespace System.ClientModel;

public abstract class OutputMessage
{
    public abstract PipelineResponse GetRawResponse();

    public static OutputMessage FromResponse(PipelineResponse response)
        => new NoModelOutputMessage(response);

    public static OutputMessage<T> FromValue<T>(T value, PipelineResponse response)
        where T : class, IPersistableModel<T>
    {
        // Null values are required to use NullableOutputMessage<T>
        if (value is null)
        {
            throw new ArgumentException("OutputMessage<T> contract guarantees that OutputMessage<T>.Value is non-null.", nameof(value));
        }

        ClientUtilities.AssertNotNull(response, nameof(response));

        return new OutputMessage<T>(value, response);
    }

    public static NullableOutputMessage<T> FromNullableValue<T>(T? value, PipelineResponse response)
        where T : class, IPersistableModel<T>
    {
        ClientUtilities.AssertNotNull(response, nameof(response));

        return new NullableOutputMessage<T>(value, response);
    }

    private class NoModelOutputMessage : OutputMessage
    {
        public readonly PipelineResponse _response;

        public NoModelOutputMessage(PipelineResponse response)
            => _response = response;

        public override PipelineResponse GetRawResponse() => _response;
    }
}
