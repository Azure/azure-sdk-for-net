// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

namespace Microsoft.Azure
{
    /// <summary>
    /// Resource identity.
    /// </summary>
    public partial class ResourceIdentity
    {
        private string _parentResourcePath;

        /// <summary>
        /// Optional. Gets or sets parent resource path (optional).
        /// </summary>
        public string ParentResourcePath
        {
            get { return this._parentResourcePath; }
            set { this._parentResourcePath = value; }
        }

        private string _resourceName;

        /// <summary>
        /// Required. Gets or sets resource name.
        /// </summary>
        public string ResourceName
        {
            get { return this._resourceName; }
            set { this._resourceName = value; }
        }

        private string _resourceProviderApiVersion;

        /// <summary>
        /// Required. Gets or sets API version of the resource provider.
        /// </summary>
        public string ResourceProviderApiVersion
        {
            get { return this._resourceProviderApiVersion; }
            set { this._resourceProviderApiVersion = value; }
        }

        private string _resourceProviderNamespace;

        /// <summary>
        /// Required. Gets or sets namespace of the resource provider.
        /// </summary>
        public string ResourceProviderNamespace
        {
            get { return this._resourceProviderNamespace; }
            set { this._resourceProviderNamespace = value; }
        }

        private string _resourceType;

        /// <summary>
        /// Required. Gets or sets resource type.
        /// </summary>
        public string ResourceType
        {
            get { return this._resourceType; }
            set { this._resourceType = value; }
        }

        /// <summary>
        /// Initializes a new instance of the ResourceIdentity class.
        /// </summary>
        public ResourceIdentity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ResourceIdentity class.
        /// </summary>
        public ResourceIdentity(string name, string resourceType, string apiVersion)
        {
            ResourceName = name;
            ResourceProviderNamespace = GetProviderFromResourceType(resourceType);
            ResourceType = GetTypeFromResourceType(resourceType);
            ResourceProviderApiVersion = apiVersion;
        }

        /// <summary>
        /// Returns provider string from resource type.
        /// </summary>
        /// <param name="resourceType">Resource type.</param>
        /// <returns>Provider</returns>
        public static string GetProviderFromResourceType(string resourceType)
        {
            if (resourceType == null)
            {
                return null;
            }

            int indexOfSlash = resourceType.IndexOf('/');
            if (indexOfSlash < 0)
            {
                return string.Empty;
            }
            else
            {
                return resourceType.Substring(0, indexOfSlash);
            }
        }

        /// <summary>
        /// Returns type string from resource type.
        /// </summary>
        /// <param name="resourceType">Resource type.</param>
        /// <returns>Type</returns>
        public static string GetTypeFromResourceType(string resourceType)
        {
            if (resourceType == null)
            {
                return null;
            }

            int lastIndexOfSlash = resourceType.LastIndexOf('/');
            if (lastIndexOfSlash < 0)
            {
                return string.Empty;
            }
            else
            {
                return resourceType.Substring(lastIndexOfSlash + 1);
            }
        }
    }
}
