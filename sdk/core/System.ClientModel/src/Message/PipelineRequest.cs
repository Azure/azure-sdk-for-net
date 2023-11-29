// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

public abstract class PipelineRequest : IDisposable
{
    public abstract string Method { get; set; }

    public abstract Uri Uri { get; set; }

    public abstract InputContent? Content { get; set; }

    public abstract MessageHeaders Headers { get; }

    public abstract void Dispose();
}