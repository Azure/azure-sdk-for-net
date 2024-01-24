// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace System.ClientModel.Primitives;

public class ErrorResponseClassifier
{
    internal static ErrorResponseClassifier Default { get; } = new();

    public static ErrorResponseClassifier Create(ReadOnlySpan<ushort> successStatusCodes)
        => new ResponseStatusClassifier(successStatusCodes);

    public ErrorResponseClassifier() { }

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

    internal ErrorResponseClassifier GetChainingClassifier(List<ErrorResponseClassifier> classifiers)
    {
        return new ChainingErrorClassifier(classifiers, this);
    }

    internal class ChainingErrorClassifier : ErrorResponseClassifier
    {
        private readonly List<ErrorResponseClassifier> _classifiers;

        public ChainingErrorClassifier(List<ErrorResponseClassifier> classifiers, ErrorResponseClassifier last)
        {
            _classifiers = new List<ErrorResponseClassifier>(classifiers.Count + 1);
            _classifiers.AddRange(classifiers);
            _classifiers.Add(last);
        }

        public override bool TryClassify(PipelineMessage message, out bool isError)
        {
            foreach (ErrorResponseClassifier classifier in _classifiers)
            {
                if (classifier.TryClassify(message, out isError))
                {
                    return true;
                }
            }

            // TODO: refactor to get default implementation in one place!
            int statusKind = message.Response!.Status / 100;
            isError = statusKind == 4 || statusKind == 5;
            return true;
        }
    }
}
