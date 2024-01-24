// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

public class ErrorResponseClassifier
{
    internal static ErrorResponseClassifier Default { get; } = new();

    public static ErrorResponseClassifier Create(ReadOnlySpan<ushort> successStatusCodes)
        => new ResponseStatusClassifier(successStatusCodes);

    protected internal ErrorResponseClassifier() { }

    /// <summary>
    /// Specifies if the response contained in the <paramref name="message"/> is not successful.
    /// </summary>
    public virtual bool TryClassify(PipelineMessage message, out bool isError)
    {
        message.AssertResponse();

        int statusKind = message.Response!.Status / 100;
        isError = statusKind == 4 || statusKind == 5;

        // Note: always classify by default because we consider this "end of chain"
        // in client-author composition.
        return true;
    }
}
