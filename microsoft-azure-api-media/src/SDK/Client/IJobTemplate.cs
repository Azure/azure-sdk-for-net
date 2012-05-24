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
    /// Represents a JobTemplate that can be used to create Jobs.
    /// </summary>
    /// <seealso cref="JobCollection.CreateJob(string,IJobTemplate,IInputAsset[])"/>
    public partial interface IJobTemplate
    {
        /// <summary>
        /// Gets a collection of TaskTemplates that compose this JobTemplate.
        /// </summary>
        /// <value>A collection of TaskTemplates composing this JobTemplate.</value>
        ReadOnlyCollection<ITaskTemplate> TaskTemplates { get; }
    }
}
