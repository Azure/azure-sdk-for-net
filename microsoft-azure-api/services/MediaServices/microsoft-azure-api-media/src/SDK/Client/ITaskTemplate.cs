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
    /// Represents a TaskTemplate.
    /// </summary>
    internal partial interface ITaskTemplate
    {
        /// <summary>
        /// Gets a collection of input assets to the templated Task.
        /// </summary>
        /// <value>A collection of Task input Assets.</value>
        /// <seealso cref="JobTemplateInputAsset"/>
        ReadOnlyCollection<IAsset> TaskInputs { get; }

        /// <summary>
        /// Gets a collection of output assets to the templated Task
        /// </summary>
        /// <value></value>
        ReadOnlyCollection<IAsset> TaskOutputs { get; }

        /// <summary>
        /// Gets the decrypted form of an encrypted task configuration for this task template.
        /// </summary>
        /// <returns>The decrypted form of an encrypted task configuration.</returns>
        string GetClearConfiguration();
    }
}
