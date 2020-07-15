﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.Storage.Blob;
using Moq.Language.Flow;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Blobs.Bindings
{
    internal static class ReturnsThrowsOfCloudBlobStreamICancellableAsyncResultExtensions
    {
        public static IReturnsResult<CloudBlobStream> ReturnsCompletedSynchronously(
            this IReturnsThrows<CloudBlobStream, IAsyncResult> returnsThrows)
        {
            if (returnsThrows == null)
            {
                throw new ArgumentNullException(nameof(returnsThrows));
            }

            return returnsThrows.Returns<AsyncCallback, object>((callback, state) =>
            {
                IAsyncResult result = new CompletedCancellableAsyncResult(state);
                InvokeCallback(callback, result);
                return result;
            });
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
