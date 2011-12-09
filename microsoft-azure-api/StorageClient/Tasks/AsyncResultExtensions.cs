//-----------------------------------------------------------------------
// <copyright file="AsyncResultExtensions.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the AsyncResultExtensions class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Tasks
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    /// <summary>
    /// A class to extend a normal task.
    /// </summary>
    internal static class AsyncResultExtensions
    {
        /// <summary>
        /// Converts a Task to an a TaskAsyncResult to allow for exposing Tasks as IAsyncResult.
        /// </summary>
        /// <typeparam name="T">The return type of the task.</typeparam>
        /// <param name="async">The task to be converted.</param>
        /// <param name="callback">The callback to be called at the end of the task.</param>
        /// <param name="state">The callback's state.</param>
        /// <returns>A TaskAsyncResult that implements IAsyncResult.</returns>
        [DebuggerNonUserCode]
        internal static IAsyncResult ToAsyncResult<T>(this Task<T> async, AsyncCallback callback, object state)
        {
            return new TaskAsyncResult<T>(async, callback, state);
        }

        /// <summary>
        /// Converts a Task to an a TaskAsyncResult to allow for exposing Tasks as IAsyncResut.
        /// </summary>
        /// <param name="async">The task to be converted.</param>
        /// <param name="callback">The callback to be called at the end of the task.</param>
        /// <param name="state">The callback's state.</param>
        /// <returns>A TaskAsyncResult that implements IAsyncResult.</returns>
        [DebuggerNonUserCode]
        internal static IAsyncResult ToAsyncResult(this Task<NullTaskReturn> async, AsyncCallback callback, object state)
        {
            return new TaskAsyncResult<NullTaskReturn>(async, callback, state);
        }
    }
}