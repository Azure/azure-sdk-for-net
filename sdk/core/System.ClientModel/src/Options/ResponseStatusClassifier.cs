// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;

namespace System.ClientModel.Primitives;

internal class ResponseStatusClassifier : PipelineMessageClassifier
{
    private BitVector640 _successCodes;

    internal MessageClassificationHandler[]? Handlers { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="ResponseStatusClassifier"/>.
    /// </summary>
    /// <param name="successStatusCodes">The status codes that this classifier
    /// will consider not to be errors.</param>
    public ResponseStatusClassifier(ReadOnlySpan<ushort> successStatusCodes)
    {
        _successCodes = new();

        foreach (int statusCode in successStatusCodes)
        {
            AddClassifier(statusCode, isError: false);
        }
    }

    private ResponseStatusClassifier(BitVector640 successCodes, MessageClassificationHandler[]? handlers)
    {
        _successCodes = successCodes;
        Handlers = handlers;
    }

    public sealed override bool IsErrorResponse(PipelineMessage message)
    {
        message.AssertResponse();

        return !_successCodes[message.Response!.Status];
    }

    internal virtual ResponseStatusClassifier Clone()
        => new(_successCodes, Handlers);

    internal void AddClassifier(int statusCode, bool isError)
    {
        Argument.AssertInRange(statusCode, 0, 639, nameof(statusCode));

        _successCodes[statusCode] = !isError;
    }
}
