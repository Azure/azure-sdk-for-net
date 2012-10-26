//-----------------------------------------------------------------------
// <copyright file="RequestOptionsExtensions.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Core.Executor
{
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.Queue;
    using Microsoft.WindowsAzure.Storage.Table;

    internal static class RequestOptionsExtensions
    {
        /// <summary>
        /// Apply timeout options to StorageCommandBase
        /// </summary>
        /// <typeparam name="T">Return value type of StorageCommandBase</typeparam>
        /// <param name="cmd">An instance of StorageCommandBase to apply options to</param>
        internal static void ApplyToStorageCommand<T>(this BlobRequestOptions options, StorageCommandBase<T> cmd)
        {
            if (options.MaximumExecutionTime.HasValue)
            {
                cmd.ClientMaxTimeout = options.MaximumExecutionTime.Value;
            }

            if (options.ServerTimeout.HasValue)
            {
                cmd.ServerTimeoutInSeconds = (int)options.ServerTimeout.Value.TotalSeconds;
            }
        }

        /// <summary>
        /// Apply timeout options to StorageCommandBase
        /// </summary>
        /// <typeparam name="T">Return value type of StorageCommandBase</typeparam>
        /// <param name="cmd">An instance of StorageCommandBase to apply options to</param>
        internal static void ApplyToStorageCommand<T>(this QueueRequestOptions options, StorageCommandBase<T> cmd)
        {
            if (options.MaximumExecutionTime.HasValue)
            {
                cmd.ClientMaxTimeout = options.MaximumExecutionTime.Value;
            }

            if (options.ServerTimeout.HasValue)
            {
                cmd.ServerTimeoutInSeconds = (int)options.ServerTimeout.Value.TotalSeconds;
            }
        }

        /// <summary>
        /// Apply timeout options to StorageCommandBase
        /// </summary>
        /// <typeparam name="T">Return value type of StorageCommandBase</typeparam>
        /// <param name="cmd">An instance of StorageCommandBase to apply options to</param>
        internal static void ApplyToStorageCommand<T>(this TableRequestOptions requestOptions, StorageCommandBase<T> cmd)
        {
            if (requestOptions.MaximumExecutionTime.HasValue)
            {
                cmd.ClientMaxTimeout = requestOptions.MaximumExecutionTime.Value;
            }

            if (requestOptions.ServerTimeout.HasValue)
            {
                cmd.ServerTimeoutInSeconds = (int)requestOptions.ServerTimeout.Value.TotalSeconds;
            }
        }
    }
}
