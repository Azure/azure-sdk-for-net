// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel;

public abstract class OptionalOutputMessage<T> : OutputMessage
{
    /// <summary>
    /// Gets a value indicating whether the current instance has a valid value of its underlying type.
    /// </summary>
    public abstract bool HasValue { get; }

    /// <summary>
    /// Gets the value returned by the service. Accessing this property will throw if <see cref="HasValue"/> is false.
    /// </summary>
    public abstract T? Value { get; }
}
