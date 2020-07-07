// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using Moq.Language.Flow;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Blobs
{
    internal static class SetupOfStreamIAsyncResultExtensions
    {
        public static IReturnsResult<Stream> ReturnsCompletedSynchronously(this ISetup<Stream, IAsyncResult> setup)
        {
            if (setup == null)
            {
                throw new ArgumentNullException("setup");
            }

            return setup.Returns<byte[], int, int, AsyncCallback, object>((i1, i2, i3, callback, state) =>
            {
                IAsyncResult result = new CompletedAsyncResult(state);
                InvokeCallback(callback, result);
                return result;
            });
        }

        public static IReturnsResult<Stream> ReturnsCompletingAsynchronously(this ISetup<Stream, IAsyncResult> setup,
            AsyncCompletionSource completionSource)
        {
            if (setup == null)
            {
                throw new ArgumentNullException("setup");
            }

            return setup.Returns<byte[], int, int, AsyncCallback, object>((i1, i2, i3, callback, state) =>
            {
                CompletingAsyncResult result = new CompletingAsyncResult(callback, state);
                completionSource.SetAsyncResult(result);
                return result;
            });
        }

        public static IReturnsResult<Stream> ReturnsUncompleted(this ISetup<Stream, IAsyncResult> setup)
        {
            if (setup == null)
            {
                throw new ArgumentNullException("setup");
            }

            return setup.Returns<byte[], int, int, AsyncCallback, object>((i1, i2, i3, i4, state) =>
                new UncompletedAsyncResult(state));
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
