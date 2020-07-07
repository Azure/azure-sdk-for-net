// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Blobs
{
    internal static class AsyncResultExtensions
    {
        // Currently there's no one right way to clean up an IAsyncResult after accessing AsyncWaitHandle.
        // The official documentation for IAsyncResult says to call AsyncWaitHandle.Close after accessing the handle.
        // However, for async/await, Task implements IAsyncResult and returns cached task instances, which don't work
        // correctly if that call is made.
        // Task and some newer IAsyncResult implementations also implement IDisposable, and calling Dispose on such
        // async results works correctly even for cached task instances (which no-op the task.Dispose call).
        // For now, the best that can be done is call IDisposable.Dispose on the async result itself when it implements
        // IDisposable and clean up the AsyncWaitHandle directly when it doesn't.
        // See: http://msdn.microsoft.com/en-us/library/vstudio/System.IAsyncResult(v=vs.100).aspx
        // including the Community Additions post describing the problem.
        public static void Dispose(this IAsyncResult result)
        {
            if (result == null)
            {
                throw new ArgumentNullException("result");
            }

            IDisposable disposable = result as IDisposable;

            if (disposable != null)
            {
                // When possible, cleanup the Task-friendly way (don't break cached tasks).
                disposable.Dispose();
            }
            else
            {
                // Otherwise, cleanup the traditional way (for older IAsyncResult implementations).
                result.AsyncWaitHandle.Dispose();
            }
        }
    }
}
