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
    /// Describes a job in the system.
    /// </summary>
    public partial interface IJob
    {
        /// <summary>
        /// Gets a collection of Asset Identifiers that are inputs to the Job.
        /// </summary>
        /// <value>A collection of Asset Identifiers.</value>
        ReadOnlyCollection<IAsset> InputMediaAssets { get; }
        /// <summary>
        /// Gets a collection of Asset Identifiers that are outputs of the Job.
        /// </summary>
        /// <value>A collection of Asset Identifiers.</value>
        ReadOnlyCollection<IAsset> OutputMediaAssets { get; }
        /// <summary>
        /// Gets a collection of Tasks that compose the Job.
        /// </summary>
        /// <value>A Enumerable of Tasks.</value>
        TaskCollection Tasks { get; }

        /// <summary>
        /// Sends request to cancel a job.
        /// </summary>
        void Cancel();

        /// <summary>
        /// Deletes this job instance
        /// </summary>
        void Delete();

        /// <summary>
        /// Submits this job instance.
        /// </summary>
        void Submit();

      

    }
}
