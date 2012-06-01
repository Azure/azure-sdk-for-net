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
    /// Specifies the allowed states of an Asset
    /// </summary>
    public enum AssetState
    {
        /// <summary>
        /// Specifies that the Asset is in initialized state.
        /// </summary>
        /// <remarks>This is the default. Assets in this state may not be used for Jobs or Tasks. Assets are allowed to have locators with full control while in this state.</remarks>
        Initialized,
        
        /// <summary>
        /// Specifies that the Asset is published.
        /// </summary>
        /// <remarks>Published Assets can be used in Job and Tasks, but are immutable. Assets are only allowed to have read and list locators in this state.</remarks>
        Published,

        /// <summary>
        /// Specifies that the Asset has been deleted.
        /// </summary>
        /// <remarks>Deleted Assets cannot be used in Job or Tasks, and do not actually exist and are only exposed for tracking purposes.</remarks>
        Deleted,
    }
}
