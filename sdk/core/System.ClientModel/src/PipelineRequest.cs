// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.Net.ClientModel.Core;

// TODO: Note WIP - starting to make this abstract and move implementation into RestPipelineTransport.Request
// What are the implications of this being abstract for Azure.Core's Request?
// What are the implications for HttpMessage needing a Request not a PipelineRequest?
// Multiple inheritance here, will need a pattern to address that.
public abstract class PipelineRequest
{
    // TODO: generator constraint requires us to make this settable, revisit later?
    public abstract void SetMethod(string method);

    // TODO: generator constraint requires us to make this settable, revisit later?
    public abstract Uri Uri { get; set; }

    // TODO: this stinks, can we make it go away?  It needs a step back and more rework.
    protected internal virtual Uri GetUri() => Uri;

    // TODO: Can we change this to BinaryData?
    public abstract RequestBody? Content { get; set; }

    public abstract void SetHeaderValue(string name, string value);
}