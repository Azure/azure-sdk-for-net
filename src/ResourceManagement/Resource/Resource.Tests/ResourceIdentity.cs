// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Test
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

        public ResourceIdentity()
        {
            
        }

        public ResourceIdentity(string name, string resourceType, string apiVersion)
        {
            ResourceName = name;
            ResourceProviderNamespace = GetProviderFromResourceType(resourceType);
            ResourceType = GetTypeFromResourceType(resourceType);
            ResourceProviderApiVersion = apiVersion;
        }

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
