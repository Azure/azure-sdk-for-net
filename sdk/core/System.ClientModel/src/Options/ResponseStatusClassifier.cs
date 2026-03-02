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
    /// <param name="successStatusCodeRanges">The inclusive ranges of status
    /// codes that this classifier will consider not to be errors.</param>
    public ResponseStatusClassifier(ReadOnlySpan<(ushort MinInclusive, ushort MaxInclusive)> successStatusCodeRanges)
    {
        _successCodes = new();

        foreach ((ushort min, ushort max) in successStatusCodeRanges)
        {
            Argument.AssertInRange((int)min, 0, 639, nameof(successStatusCodeRanges));
            Argument.AssertInRange((int)max, 0, 639, nameof(successStatusCodeRanges));

            if (min > max)
            {
                throw new ArgumentException("MinInclusive must be less than or equal to MaxInclusive.", nameof(successStatusCodeRanges));
            }

            for (int code = min; code <= max; code++)
            {
                AddClassifier(code, isError: false);
            }
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
