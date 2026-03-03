// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Diagnostics;

namespace System.ClientModel.Primitives;

internal class ResponseStatusClassifier : PipelineMessageClassifier
{
    private BitVector640 _successCodes;

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

    /// <summary>
    /// Creates a new instance of <see cref="ResponseStatusClassifier"/>.
    /// </summary>
    /// <param name="minInclusive">The minimum success status code (inclusive).</param>
    /// <param name="maxInclusive">The maximum success status code (inclusive).</param>
    public ResponseStatusClassifier(ushort minInclusive, ushort maxInclusive)
    {
        Argument.AssertInRange((int)minInclusive, 0, 639, nameof(minInclusive));
        Argument.AssertInRange((int)maxInclusive, 0, 639, nameof(maxInclusive));

        if (minInclusive > maxInclusive)
        {
            throw new ArgumentException("minInclusive must be less than or equal to maxInclusive.", nameof(minInclusive));
        }

        _successCodes = new();

        for (int code = minInclusive; code <= maxInclusive; code++)
        {
            AddClassifier(code, isError: false);
        }
    }

    public override bool TryClassify(PipelineMessage message, out bool isError)
    {
        Argument.AssertNotNull(message, nameof(message));
        message.AssertResponse();

        isError = !_successCodes[message.Response!.Status];

        // BitVector-based classifiers should always end any chain.
        return true;
    }

    public override bool TryClassify(PipelineMessage message, Exception? exception, out bool isRetriable)
    {
        Argument.AssertNotNull(message, nameof(message));

        bool classified = Default.TryClassify(message, exception, out isRetriable);

        Debug.Assert(classified);

        // BitVector-based classifiers should always end any chain.
        return true;
    }

    private void AddClassifier(int statusCode, bool isError)
    {
        Argument.AssertInRange(statusCode, 0, 639, nameof(statusCode));

        _successCodes[statusCode] = !isError;
    }
}
