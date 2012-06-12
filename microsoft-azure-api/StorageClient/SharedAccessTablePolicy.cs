//-----------------------------------------------------------------------
// <copyright file="SharedAccessTablePolicy.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
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
//    Contains code for the SharedAccessTablePolicy class.
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
    public class SharedAccessTablePolicy
    {
        /// <summary>
        /// Initializes a new instance of the SharedAccessTablePolicy class.
        /// </summary>
        public SharedAccessTablePolicy()
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
        public SharedAccessTablePermissions Permissions { get; set; }

        /// <summary>
        /// Converts the permissions specified for the shared access policy to a string.
        /// </summary>
        /// <param name="permissions">The shared access permissions.</param>
        /// <returns>The shared access permissions in string format.</returns>
        public static string PermissionsToString(SharedAccessTablePermissions permissions)
        {
            // The service supports a fixed order => raud
            StringBuilder builder = new StringBuilder();
            if ((permissions & SharedAccessTablePermissions.Query) == SharedAccessTablePermissions.Query)
            {
                builder.Append("r");
            }

            if ((permissions & SharedAccessTablePermissions.Add) == SharedAccessTablePermissions.Add)
            {
                builder.Append("a");
            }

            if ((permissions & SharedAccessTablePermissions.Update) == SharedAccessTablePermissions.Update)
            {
                builder.Append("u");
            }

            if ((permissions & SharedAccessTablePermissions.Delete) == SharedAccessTablePermissions.Delete)
            {
                builder.Append("d");
            }

            return builder.ToString();
        }

        /// <summary>
        /// Constructs a <see cref="SharedAccessTablePermissions"/> object from a permissions string.
        /// </summary>
        /// <param name="value">The shared access permissions in string format.</param>
        /// <returns>A set of shared access permissions.</returns>
        public static SharedAccessTablePermissions PermissionsFromString(string value)
        {
            char[] chars = value.ToCharArray();
            SharedAccessTablePermissions permissions = 0;

            foreach (char c in chars)
            {
                switch (c)
                {
                    case 'r':
                        permissions |= SharedAccessTablePermissions.Query;
                        break;
                    case 'a':
                        permissions |= SharedAccessTablePermissions.Add;
                        break;
                    case 'u':
                        permissions |= SharedAccessTablePermissions.Update;
                        break;
                    case 'd':
                        permissions |= SharedAccessTablePermissions.Delete;
                        break;
                    default:
                        CommonUtils.ArgumentOutOfRange("value", value);
                        break;
                }
            }

            // Incase we ever change none to be something other than 0
            if (permissions == 0)
            {
                permissions |= SharedAccessTablePermissions.None;
            }

            return permissions;
        }
    }
}
