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
    {
        // Null values are required to use OptionalOutputMessage<T>
        if (value is null)
        {
            throw new ArgumentException("OutputMessage<T> contract guarantees that OutputMessage<T>.Value is non-null.", nameof(value));
        }

        ClientUtilities.AssertNotNull(response, nameof(response));

        return new OutputMessage<T>(value, response);
    }

    public static OptionalOutputMessage<T> FromOptionalValue<T>(T? value, PipelineResponse response)
    {
        ClientUtilities.AssertNotNull(response, nameof(response));

        return new OptionalOutputMessage<T>(value, response);
    }

    private class NoModelOutputMessage : OutputMessage
    {
        public readonly PipelineResponse _response;

        public NoModelOutputMessage(PipelineResponse response)
            => _response = response;

        public override PipelineResponse GetRawResponse() => _response;
    }

    private class SimpleOptionalOutputMessage<T> : OptionalOutputMessage<T>
    {
        private readonly T? _value;
        private readonly PipelineResponse _response;

        public SimpleOptionalOutputMessage(T? value, PipelineResponse response)
        {
            if (response is null) throw new ArgumentNullException(nameof(response));

            _response = response;
            _value = value;
        }

        public override T? Value => _value;

        public override bool HasValue => _value != null;

        public override PipelineResponse GetRawResponse() => _response;
    }

}
