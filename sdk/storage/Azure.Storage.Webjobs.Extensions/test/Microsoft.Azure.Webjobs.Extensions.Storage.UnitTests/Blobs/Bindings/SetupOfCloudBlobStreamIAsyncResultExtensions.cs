// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Storage.Blob;
using Moq.Language.Flow;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Blobs
{
    internal static class SetupOfCloudBlobStreamIAsyncResultExtensions
    {
        public static IReturnsResult<CloudBlobStream> ReturnsCompletedSynchronously(
            this ISetup<CloudBlobStream, IAsyncResult> setup)
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

        public static IReturnsResult<CloudBlobStream> ReturnsCompletingAsynchronously(
            this ISetup<CloudBlobStream, IAsyncResult> setup, AsyncCompletionSource completionSource)
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

        public static IReturnsResult<CloudBlobStream> ReturnsUncompleted(
            this ISetup<CloudBlobStream, IAsyncResult> setup)
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
