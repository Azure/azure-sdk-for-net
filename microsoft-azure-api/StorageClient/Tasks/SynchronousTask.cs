//-----------------------------------------------------------------------
// <copyright file="SynchronousTask.cs" company="Microsoft">
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
//    Contains code for the SynchronousTask and SynchronousTask[T] classes.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Tasks
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// A task that obtains a result synchronously.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Other class is a generic class with the same name.")]
    internal class SynchronousTask : SynchronousTask<NullTaskReturn>
    {
        /// <summary>
        /// Initializes a new instance of the SynchronousTask class.
        /// </summary>
        /// <param name="operation">The function to execute.</param>
        public SynchronousTask(Action operation)
            : base(() => { operation(); return NullTaskReturn.Value; })
        {
        }
    }

    /// <summary>
    /// A task that obtains a result synchronously.
    /// </summary>
    /// <typeparam name="T">The type of the result of the operation.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Other class is a non-generic specialization with the same name.")]
    internal class SynchronousTask<T> : Task<T>
    {
        /// <summary>
        /// The function to be executed.
        /// </summary>
        private Func<T> func;

        /// <summary>
        /// Initializes a new instance of the SynchronousTask class.
        /// </summary>
        /// <param name="operation">The function to execute.</param>
        public SynchronousTask(Func<T> operation)
        {
            this.func = operation;
        }

        /// <summary>
        /// Performs the task and marks it as completed.
        /// </summary>
        [DebuggerNonUserCode]
        protected override void ExecuteInternal()
        {
            this.SetResult(this.func);
            this.Complete(true);
        }

        /// <summary>
        /// Implements abort as NoOp.
        /// </summary>
        [DebuggerNonUserCode]
        protected override void AbortInternal()
        {
        }
    }
}
