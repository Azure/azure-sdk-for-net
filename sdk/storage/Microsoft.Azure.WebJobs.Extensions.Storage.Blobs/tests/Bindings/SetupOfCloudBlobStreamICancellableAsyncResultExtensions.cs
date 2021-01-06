// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Moq.Language.Flow;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings
{
    internal static class SetupOfCloudBlobStreamICancellableAsyncResultExtensions
    {
        public static IReturnsResult<Stream> ReturnsCompletedSynchronously(
            this ISetup<Stream, IAsyncResult> setup)
        {
            if (setup == null)
            {
                throw new ArgumentNullException(nameof(setup));
            }

            return setup.Returns<byte[], int, int, AsyncCallback, object>((a1, a2, a3, callback, state) =>
            {
                IAsyncResult result = new CompletedCancellableAsyncResult(state);
                InvokeCallback(callback, result);
                return result;
            });
        }

        public static IReturnsResult<Stream> ReturnsUncompleted(
            this ISetup<Stream, IAsyncResult> setup)
        {
            if (setup == null)
            {
                throw new ArgumentNullException(nameof(setup));
            }

            return setup.Returns<byte[], int, int, AsyncCallback, object>((a1, a2, a3, a4, state) => new UncompletedCancellableAsyncResult(state));
        }

        private static void InvokeCallback(AsyncCallback callback, IAsyncResult result)
        {
            if (callback != null)
            {
                callback.Invoke(result);
            }
        }
    }
}
