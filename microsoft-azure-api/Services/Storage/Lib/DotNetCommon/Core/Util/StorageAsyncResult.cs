//-----------------------------------------------------------------------
// <copyright file="StorageAsyncResult.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    using Microsoft.WindowsAzure.Storage;
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents the async result returned by operations that do not directly
    /// call into the Executor.
    /// </summary>
    /// <typeparam name="T">Async operation's result type</typeparam>
    internal class StorageAsyncResult<T> : StorageCommandAsyncResult
    {
        internal T Result { get; set; }

        internal OperationContext OperationContext { get; set; }

        internal IRequestOptions RequestOptions { get; set; }

        internal object OperationState { get; set; }

        internal Exception ExceptionRef { get; private set; }

        /// <summary>
        /// Initializes a new instance of the StorageAsyncResult class.
        /// </summary>
        /// <param name="callback">The callback method to be used on completion.</param>
        /// <param name="state">The state for the callback.</param>
        internal StorageAsyncResult(AsyncCallback callback, object state)
            : base(callback, state)
        {
        }

        /// <summary>
        /// Called on completion of the async operation to notify the user
        /// </summary>
        /// <param name="exception">Exception that was caught by the caller.</param>
        [DebuggerNonUserCode]
        internal void OnComplete(Exception exception)
        {
            // This method should not do anything else than just storing the exception,
            // as callers might simply call OnComplete() if there was no exception
            // and we do not override that method here.
            this.ExceptionRef = exception;
            this.OnComplete();
        }

        /// <summary>
        /// Blocks the calling thread until the async operation is completed and throws
        /// any stored exceptions.
        /// </summary>
        [DebuggerNonUserCode]
        internal override void End()
        {
            base.End();
            if (this.ExceptionRef != null)
            {
                throw this.ExceptionRef;
            }
        }
    }
}
