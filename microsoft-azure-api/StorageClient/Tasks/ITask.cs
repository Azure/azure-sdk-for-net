//-----------------------------------------------------------------------
// <copyright file="ITask.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the ITask interface.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Tasks
{
    using System;

    /// <summary>
    /// An asynchronous computation.
    /// </summary>
    internal interface ITask
    {
        /// <summary>
        /// Gets a value indicating whether the task has completed synchronously.
        /// </summary>
        /// <value>
        /// Is <c>true</c> if completed synchronously; otherwise, <c>false</c>.
        /// </value>
        bool CompletedSynchronously { get; }

        /// <summary>
        /// Gets exception raised by this task (if any).
        /// </summary>
        /// <value>The exception.</value>
        Exception Exception { get; }

        /// <summary>
        /// Perform the next async step.
        /// </summary>
        /// <param name="cont">The action to be performed on completion.</param>
        void ExecuteStep(Action cont);

        /// <summary>
        /// Abort the task operation.
        /// </summary>
        void Abort();
    }
}
