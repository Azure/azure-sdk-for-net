// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ServiceModel.Rest.Core;

// TODO: Note WIP - starting to make this abstract and move implementation into RestPipelineTransport.Request
// What are the implications of this being abstract for Azure.Core's Request?
// What are the implications for HttpMessage needing a Request not a PipelineRequest?
// Multiple inheritance here, will need a pattern to address that.
public abstract class PipelineRequest
{
    // TODO: generator constraint requires us to make this settable, revisit later?
    public abstract void SetMethod(string method);

    public abstract string GetMethod();

    // TODO: generator constraint requires us to make this settable, revisit later?
    public abstract void SetUri(Uri uri);

    public abstract Uri GetUri();

    // TODO: RequestBody or BinaryData?  What are the considerations?
    public abstract void SetContent(RequestBody content);

    public abstract RequestBody? GetContent();

    public abstract void SetHeaderValue(string name, string value);
}