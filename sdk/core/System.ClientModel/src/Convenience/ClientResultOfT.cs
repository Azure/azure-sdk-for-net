// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel;

public class ClientResult<T> : ClientResult
{
    protected internal ClientResult(T value, PipelineResponse response)
        : base(response)
    {
        // TODO: What happens here?  What does this validation look like?
        // Null values must use OptionalClientResult<T>
        if (value is null)
        {
            string message = "ClientResult<T> contract guarantees that ClientResult<T>.Value is non-null. " +
                "If you need to return a ClientResult where the Value is null, please use OptionalClientResult<T> instead.";

            throw new ArgumentNullException(nameof(value), message);
        }

        Value = value;
    }

    public T Value { get; }

    // Notice: HasValue goes away.
}
