//-----------------------------------------------------------------------
// <copyright file="APMTask.cs" company="Microsoft">
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
//    Contains code for the APMTask and APMTask[T] classes.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Tasks
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// A task that implements the conventional BeginXX(), EndXX() pattern.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Other class is a generic class with the same name.")]
    internal class APMTask : APMTask<NullTaskReturn>
    {
        /// <summary>
        /// Initializes a new instance of the APMTask class for sequence without any return value.
        /// </summary>
        /// <param name="begin">The APM function to begin operation.</param>
        /// <param name="end">The APM functon to end the operation.</param>
        public APMTask(Func<AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end) :
            base(
                begin,
                (asyncResult) =>
                    {
                        end(asyncResult);
                        return NullTaskReturn.Value;
                    })
        {
        }
    }

    /// <summary>
    /// A task that implements the conventional BeginXX(), EndXX() pattern.
    /// </summary>
    /// <typeparam name="T">The return type of the task.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Other class is a non-generic specialization with the same name.")]
    internal class APMTask<T> : Task<T>
    {
        /// <summary>
        /// Initializes a new instance of the APMTask class for use with normal APM.
        /// </summary>
        /// <param name="begin">The APM function to begin operation.</param>
        /// <param name="end">The APM functon to end the operation.</param>
        [DebuggerNonUserCode]
        public APMTask(Func<AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, T> end)
        {
            this.BeginFunc = begin;
            this.EndFunc = end;
        }

        /// <summary>
        /// Initializes a new instance of the APMTask class for use with normal APM.
        /// </summary>
        /// <param name="begin">The APM function to begin operation.</param>
        /// <param name="end">The APM functon to end the operation.</param>
        /// <param name="abort">The function used for aborting an operation.</param>
        [DebuggerNonUserCode]
        public APMTask(Func<AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, T> end, Action abort)
        {
            this.BeginFunc = begin;
            this.EndFunc = end;
            this.AbortFunc = abort;
        }

        /// <summary>
        /// Gets or sets the begin function.
        /// </summary>
        /// <value>The begin func.</value>
        public Func<AsyncCallback, object, IAsyncResult> BeginFunc { get; set; }

        /// <summary>
        /// Gets or sets the end function.
        /// </summary>
        /// <value>The end func.</value>
        public Func<IAsyncResult, T> EndFunc { get; set; }

        /// <summary>
        /// Gets or sets the abort function.
        /// </summary>
        /// <value>The abort func.</value>
        public Action AbortFunc { get; set; }
        
        /// <summary>
        /// Implementation of the library execution. Performs the APM operation.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Design",
            "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "The exception is logged.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Anvil.<Leak!Disposable>",
            "<1037>",
            Justification = "IAsyncResult is not neccesarily disposable as it is retrieved from any Func<IAsyncResult>, will go out of scope.")]
        [DebuggerNonUserCode]
        protected override void ExecuteInternal()
        {
            IAsyncResult ar;
            try
            {
                ar = this.BeginFunc(this.OnEnd, null);

                if (ar.CompletedSynchronously)
                {
                    this.Complete(true);
                }
            }
            catch (Exception ex)
            {
                this.Exception = ex;
                this.Complete(true);
            }
        }

        /// <summary>
        /// Implements the abort functionality.
        /// </summary>
        [DebuggerNonUserCode]
        protected override void AbortInternal()
        {
            if (this.AbortFunc != null)
            {
                this.AbortFunc();
            }
        }

        /// <summary>
        /// Callback for the APM function.
        /// </summary>
        /// <param name="ar">The async result for the APM model.</param>
        [DebuggerNonUserCode]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Design",
            "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "Exception is logged")]
        private void OnEnd(IAsyncResult ar)
        {
            try
            {
                this.Result = this.EndFunc(ar);
            }
            catch (Exception ex)
            {
                this.Exception = ex;
            }

            if (!ar.CompletedSynchronously)
            {
                this.Complete(false);
            }
        }
    }
}
