//-----------------------------------------------------------------------
// <copyright file="SharedAccessPolicy.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the SharedAccessPolicy class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Text;

    /// <summary>
    /// Represents a shared access policy, which specifies the start time, expiry time, 
    /// and permissions for a shared access signature.
    /// </summary>
    public class SharedAccessPolicy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SharedAccessPolicy"/> class.
        /// </summary>
        public SharedAccessPolicy()
        {
        }

        /// <summary>
        /// Gets or sets the start time for a shared access signature associated with this shared access policy.
        /// </summary>
        /// <value>The shared access start time.</value>
        public DateTime? SharedAccessStartTime { get; set; }

        /// <summary>
        /// Gets or sets the expiry time for a shared access signature associated with this shared access policy.
        /// </summary>
        /// <value>The shared access expiry time.</value>
        public DateTime? SharedAccessExpiryTime { get; set; }

        /// <summary>
        /// Gets or sets the permissions for a shared access signature associated with this shared access policy.
        /// </summary>
        /// <value>The permissions.</value>
        public SharedAccessPermissions Permissions { get; set; }

        /// <summary>
        /// Converts the permissions specified for the shared access policy to a string.
        /// </summary>
        /// <param name="permissions">The shared access permissions.</param>
        /// <returns>The shared access permissions in string format.</returns>
        public static string PermissionsToString(SharedAccessPermissions permissions) 
        {
            // The service supports a fixed order => rwdl
            StringBuilder builder = new StringBuilder();
            if ((permissions & SharedAccessPermissions.Read) == SharedAccessPermissions.Read)
            {
                builder.Append("r");
            }

            if ((permissions & SharedAccessPermissions.Write) == SharedAccessPermissions.Write)
            {
                builder.Append("w");
            }

            if ((permissions & SharedAccessPermissions.Delete) == SharedAccessPermissions.Delete)
            {
                builder.Append("d");
            }

            if ((permissions & SharedAccessPermissions.List) == SharedAccessPermissions.List)
            {
                builder.Append("l");
            }

            return builder.ToString();
        }

        /// <summary>
        /// Constructs a <see cref="SharedAccessPermissions"/> object from a permissions string.
        /// </summary>
        /// <param name="value">The shared access permissions in string format.</param>
        /// <returns>A set of shared access permissions.</returns>
        public static SharedAccessPermissions PermissionsFromString(string value) 
        {
            char[] chars = value.ToCharArray();
            SharedAccessPermissions permissions = 0;

            foreach (char c in chars)
            {
                switch (c)
                {
                    case 'r':
                        permissions |= SharedAccessPermissions.Read;
                        break;
                    case 'w':
                        permissions |= SharedAccessPermissions.Write;
                        break;
                    case 'd':
                        permissions |= SharedAccessPermissions.Delete;
                        break;
                    case 'l':
                        permissions |= SharedAccessPermissions.List;
                        break;
                    default:
                        CommonUtils.ArgumentOutOfRange("value", value);
                        break;
                }
            }

            // Incase we ever change none to be something other than 0
            if (permissions == 0)
            {
                permissions |= SharedAccessPermissions.None;
            }

            return permissions;
        }
    }
}
