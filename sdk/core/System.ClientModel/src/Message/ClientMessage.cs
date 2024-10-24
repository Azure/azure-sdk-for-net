// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public abstract class ClientMessage
{
    /// <summary>
    /// Gets or sets the contents of the client message.
    /// </summary>
    public BinaryContent? Content
    {
        get => ContentCore;
        set => ContentCore = value;
    }

    /// <summary>
    /// Gets or sets the derived-type's value of the request's
    /// <see cref="Content"/>.
    /// </summary>
    protected abstract BinaryContent? ContentCore { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
