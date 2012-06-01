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

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Represents the application of an AccessPolicy to an Asset.
    /// </summary>
    /// <remarks>A locator provides access to an Asset using the <see cref="Path"/> property.</remarks>
    public partial interface ILocator
    {
        /// <summary>
        /// Gets the AccessPolicy that defines this locator.
        /// </summary>
        IAccessPolicy AccessPolicy { get; }

        /// <summary>
        /// Gets the Asset that this locator is attached to.
        /// </summary>
        IAsset Asset { get; }
    }
}
