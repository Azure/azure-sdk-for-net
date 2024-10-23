// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public abstract class ServiceResponse
{
    /// <summary>
    /// Gets the status code of the response.
    /// </summary>
    public abstract int Status { get; }

    public abstract BinaryData Content { get; }

    /// <summary>
    /// Indicates whether the status code of the returned response is considered
    /// an error code.
    /// </summary>
    // IsError must be virtual in order to maintain Azure.Core back-compatibility.
    public virtual bool IsError => IsErrorCore;

    /// <summary>
    /// Gets or sets the derived-type's value of <see cref="IsError"/>.
    /// </summary>
    protected internal virtual bool IsErrorCore { get; set; }
}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
