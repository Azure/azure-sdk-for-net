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
    ///   Represents a base media context containing collections to operate on.
    /// </summary>
    public abstract class MediaContextBase
    {
        /// <summary>
        ///   Gets a collection to operate on AccessPolicies.
        /// </summary>
        /// <seealso cref="AccessPolicyCollection" />
        /// <seealso cref="IAccessPolicy" />
        //TODO, 26165, access policies should not be exposed on the base media context class
        public abstract AccessPolicyCollection AccessPolicies { get; }

        /// <summary>
        ///   Gets a collection to operate on Assets.
        /// </summary>
        /// <seealso cref="BaseAssetCollection" />
        /// <seealso cref="IAsset" />
        public abstract BaseAssetCollection Assets { get; }

        /// <summary>
        ///   Gets a collection to operate on ContentKeys.
        /// </summary>
        /// <seealso cref="BaseContentKeyCollection" />
        /// <seealso cref="IContentKey" />
        public abstract BaseContentKeyCollection ContentKeys { get; }

        /// <summary>
        ///   Gets a collection to operate on Files.
        /// </summary>
        /// <seealso cref="BaseFileInfoCollection" />
        /// <seealso cref="IFileInfo" />
        public abstract BaseFileInfoCollection Files { get; }

        /// <summary>
        ///   Gets a collection to operate on Jobs.
        /// </summary>
        /// <seealso cref="JobCollection" />
        /// <seealso cref="IJob" />
        public abstract JobCollection Jobs { get; }

        /// <summary>
        ///   Gets a collection to operate on MediaProcessors.
        /// </summary>
        /// <seealso cref="MediaProcessorCollection" />
        /// <seealso cref="IMediaProcessor" />
        public abstract MediaProcessorCollection MediaProcessors { get; }

       
    }
}
