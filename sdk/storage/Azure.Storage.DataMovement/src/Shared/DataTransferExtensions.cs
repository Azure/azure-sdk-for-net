// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// DataTransfer Extension method to check the status of the transfer
    /// </summary>
    public static class DataTransferExtensions
    {
        /// <summary>
        /// Ensures completion of the DataTransfer and attempts to get result
        /// </summary>
        /// <param name="dataTransfer"></param>
        public static void EnsureCompleted(this DataTransfer dataTransfer)
        {
#if DEBUG
            VerifyTaskCompleted(dataTransfer.IsCompleted);
#endif
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
            //dataTransfer.GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
        }

        [Conditional("DEBUG")]
        private static void VerifyTaskCompleted(bool isCompleted)
        {
            if (!isCompleted)
            {
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
                // Throw an InvalidOperationException instead of using
                // Debug.Assert because that brings down nUnit immediately
                throw new InvalidOperationException("Data Transfer is not completed");
            }
        }

        /// <summary>
        /// Waits until the data transfer itself has completed
        /// </summary>
        /// <param name="dataTransfer"></param>
        public static Task AwaitCompletion(this DataTransfer dataTransfer)
        {
#if DEBUG
            VerifyTaskCompleted(dataTransfer.IsCompleted);
#endif
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
            //dataTransfer.GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.

            // TODO: Stub
            return Task.CompletedTask;
        }
    }
}
