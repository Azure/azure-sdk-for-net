// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Collections.ObjectModel;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Describes a task within a job in the system.
    /// </summary>
    /// <seealso cref="IJob"/>
    public partial interface ITask
    {
        /// <summary>
        /// Gets the collection of input assets for the task.
        /// </summary>
        InputAssetCollection<IAsset> InputMediaAssets { get; }

        /// <summary>
        /// Gets the collection of output assets for the task.
        /// </summary>
        OutputAssetCollection OutputMediaAssets { get; }

        /// <summary>
        /// Gets the unencrypted configuration data.
        /// </summary>
        /// <returns>A string containing the configuration data. If the data was encrypted, the configuration returned is decrypted.</returns>
        string GetClearConfiguration();

        /// <summary>
        /// Gets the percentage of completion of the task.
        /// </summary>
        double Progress { get; }

        /// <summary>
        /// Gets a collection of <see cref="ErrorDetail"/> objects describing the errors encountered during task execution.
        /// </summary>
        ReadOnlyCollection<ErrorDetail> ErrorDetails { get; }
    }
}
