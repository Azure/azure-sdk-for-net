// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Moq.Language.Flow;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Blobs.Bindings
{
    internal static class SetupOfCloudBlobStreamICancellableAsyncResultExtensions
    {
        public static IReturnsResult<CloudBlobStream> ReturnsCompletedSynchronously(
            this ISetup<CloudBlobStream, IAsyncResult> setup)
        {
            if (setup == null)
            {
                throw new ArgumentNullException("setup");
            }

            return setup.Returns<byte[], int, int, AsyncCallback, object>((a1, a2, a3, callback, state) =>
            {
                IAsyncResult result = new CompletedCancellableAsyncResult(state);
                InvokeCallback(callback, result);
                return result;
            });
        }

        public static IReturnsResult<CloudBlobStream> ReturnsCompletedSynchronously(
            this ISetup<CloudBlobStream, IAsyncResult> setup, CompletedCancellationSpy spy)
        {
            if (setup == null)
            {
                throw new ArgumentNullException("setup");
            }

            return setup.Returns<AsyncCallback, object>((callback, state) =>
            {
                CompletedCancellableAsyncResult result = new CompletedCancellableAsyncResult(state);
                spy.SetAsyncResult(result);
                InvokeCallback(callback, result);
                return result;
            });
        }

        public static IReturnsResult<CloudBlobStream> ReturnsUncompleted(
            this ISetup<CloudBlobStream, IAsyncResult> setup)
        {
            if (setup == null)
            {
                throw new ArgumentNullException("setup");
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
