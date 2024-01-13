// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

public class PipelineMessageClassifier
{
    internal static PipelineMessageClassifier Default { get; } = new PipelineMessageClassifier();

    protected internal PipelineMessageClassifier() { }

    /// <summary>
    /// Specifies if the response contained in the <paramref name="message"/> is not successful.
    /// </summary>
    public virtual bool IsErrorResponse(PipelineMessage message)
    {
        if (message.Response is null)
        {
            throw new InvalidOperationException("IsError must be called on a message where the OutputMessage is populated.");
        }

        int statusKind = message.Response.Status / 100;
        return statusKind == 4 || statusKind == 5;
    }
}
