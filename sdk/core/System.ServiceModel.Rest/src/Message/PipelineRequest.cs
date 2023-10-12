// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ServiceModel.Rest.Core;

// TODO: Note WIP - starting to make this abstract and move implementation into RestPipelineTransport.Request
// What are the implications of this being abstract for Azure.Core's Request?
// What are the implications for HttpMessage needing a Request not a PipelineRequest?
// Multiple inheritance here, will need a pattern to address that.
public abstract class PipelineRequest : IDisposable
{
    public abstract string Method { get; set; }

    public abstract Uri Uri { get; set; }

    // TODO: Can we change this to BinaryData?
    public abstract RequestBody? Content { get; set; }

    public abstract MessageHeaders Headers { get; }

    // TODO: this is required by Azure.Core RequestAdapter constraint.  Revisit?
    public abstract void Dispose();
}