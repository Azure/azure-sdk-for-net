// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer
{
#pragma warning disable CS1591
    public class RecognizeFormsOperation<T> : Operation<RecognizedFormCollection<T>>
    {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
        public override string Id => throw new NotImplementedException();

        public override RecognizedFormCollection<T> Value => throw new NotImplementedException();

        public override bool HasCompleted => throw new NotImplementedException();

        public override bool HasValue => throw new NotImplementedException();

#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations

        public override Response GetRawResponse()
        {
            throw new NotImplementedException();
        }

        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<Response<RecognizedFormCollection<T>>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<Response<RecognizedFormCollection<T>>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
#pragma warning restore CS1591
}
