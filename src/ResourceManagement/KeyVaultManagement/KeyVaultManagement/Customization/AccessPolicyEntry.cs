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

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.Management.KeyVault
{
    public partial class AccessPolicyEntry
    {
        /// <summary>
        /// Initializes a new instance of the AccessPolicyEntry class.
        /// </summary>
        public AccessPolicyEntry()
        {
            _permissions = new Dictionary<string, string[]>();
        }

        /// <summary>
        /// Object ID of the principal
        /// </summary>
        public string ObjectId
        {
            get;
            set;
        }

        private Dictionary<string, string[]> _permissions;

        /// <summary>
        /// Permissions that the principal has for this vault, in the serialized JSON string format
        /// </summary>
        public string PermissionsRawJsonString
        {
            get { return JsonConvert.SerializeObject(_permissions); }
            set { this._permissions = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(value); }
        }
        
        /// <summary>
        /// Tenant ID of the principal
        /// </summary>
        public Guid TenantId
        {
            get;
            set;
        }

        /// <summary>
        /// Application ID of the client making request on behalf of a principal
        /// </summary>
        public Guid? ApplicationId
        {
            get;
            set;
        }

        /// <summary>
        /// Permissions to keys
        /// </summary>
        public string[] PermissionsToKeys
        {
            get
            {                
                return GetPermissions("keys");
            }
            set
            {
                AddPermissions(value, "keys");                
            }
        }

        /// <summary>
        /// Permissions to secrets
        /// </summary>
        public string[] PermissionsToSecrets
        {
            get
            {
                return GetPermissions("secrets");
            }
            set
            {
                AddPermissions(value, "secrets");
            }
        }

        private void AddPermissions(string[] perms, string objectType)
        { 
            if (perms != null && perms.Length > 0)
                _permissions[objectType] = perms;
            else
                _permissions.Remove(objectType);
        }

        private string[] GetPermissions(string objectType)
        {
            if (_permissions != null && _permissions.ContainsKey(objectType))
                return _permissions[objectType];
            else
                return new string[]{};
        }
    }
}
