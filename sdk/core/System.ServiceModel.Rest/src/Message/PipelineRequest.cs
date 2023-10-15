// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ServiceModel.Rest.Core;

public abstract class PipelineRequest : IDisposable
{
    public abstract string Method { get; set; }

    public abstract Uri Uri { get; set; }

    public abstract BinaryData? Content { get; set; }

    public abstract MessageHeaders Headers { get; }

    // TODO: this is required by Azure.Core RequestAdapter constraint.  Revisit?
    public abstract void Dispose();
}