// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

public class PipelineMessageClassifier
{
    internal static PipelineMessageClassifier Default { get; } = new PipelineMessageClassifier();

    public static PipelineMessageClassifier Create(ReadOnlySpan<ushort> successStatusCodes)
        => new ResponseStatusClassifier(successStatusCodes);

    protected internal PipelineMessageClassifier() { }

    /// <summary>
    /// Determines whether the Response property of <paramref name="message"/>
    /// is considered an error response by pipeline policies and the client.
    /// </summary>
    /// <param name="message">The message to classify.</param>
    /// <param name="isError">True if the classifer considers the message's
    /// response to be an error; false otherwise.</param>
    /// <returns>True if the classifier provided a value for <paramref name="isError"/>,
    /// false if it did not classify the message response. A classifier can return
    /// false if it wants to be composable with other classifiers and pass the
    /// decision on to another classifier instead of doing the classification
    /// itself.</returns>
    public virtual bool TryClassifyResponse(PipelineMessage message, out bool isError)
    {
        message.AssertResponse();

        int statusKind = message.Response!.Status / 100;
        isError = statusKind == 4 || statusKind == 5;

        // By returning true here, any type that derives from this type and
        // does not provide an implementation for this method will always stop
        // any composition of classifiers before passing control to the next one.
        return true;
    }
}
