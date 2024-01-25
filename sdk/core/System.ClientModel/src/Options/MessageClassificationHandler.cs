// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

/// <summary>
/// A type that analyzes an HTTP message and determines if the response it holds
/// should be treated as an error response. A classifier of this type may use information
/// from the request, the response, or other message property to decide
/// whether and how to classify the message.
/// <para/>
/// This type's <code>TryClassify</code> method allows chaining together handlers before
/// applying default classifier logic.
/// If a handler in the chain returns false from <code>TryClassify</code>,
/// the next handler will be tried, and so on.  The first handler that returns true
/// will determine whether the response is an error.
/// </summary>
public class MessageClassificationHandler
{
    public virtual bool TryClassify(PipelineMessage message, out bool isError)
    {
        isError = false;

        // Don't classify for errors unless overridden.
        return false;
    }

    public virtual bool TryClassify(PipelineMessage message, Exception? exception, out bool isRetriable)
    {
        isRetriable = false;

        // Don't classify for retries unless overridden.
        return false;
    }
}
