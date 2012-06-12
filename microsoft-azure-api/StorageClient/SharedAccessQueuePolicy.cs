//-----------------------------------------------------------------------
// <copyright file="SharedAccessQueuePolicy.cs" company="Microsoft">
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
//    Contains code for the SharedAccessQueuePolicy class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Text;

    /// <summary>
    /// Represents a shared access policy for a queue, which specifies the start time, expiry time, 
    /// and permissions for a shared access signature.
    /// </summary>
    public class SharedAccessQueuePolicy
    {
        /// <summary>
        /// Initializes a new instance of the SharedAccessQueuePolicy class.
        /// </summary>
        public SharedAccessQueuePolicy()
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
        public SharedAccessQueuePermissions Permissions { get; set; }

        /// <summary>
        /// Converts the permissions specified for the shared access policy to a string.
        /// </summary>
        /// <param name="permissions">The shared access permissions.</param>
        /// <returns>The shared access permissions in string format.</returns>
        public static string PermissionsToString(SharedAccessQueuePermissions permissions)
        {
            // The queue service supports a fixed order => raup
            StringBuilder builder = new StringBuilder();
            if ((permissions & SharedAccessQueuePermissions.Read) == SharedAccessQueuePermissions.Read)
            {
                builder.Append("r");
            }

            if ((permissions & SharedAccessQueuePermissions.Add) == SharedAccessQueuePermissions.Add)
            {
                builder.Append("a");
            }

            if ((permissions & SharedAccessQueuePermissions.Update) == SharedAccessQueuePermissions.Update)
            {
                builder.Append("u");
            }

            if ((permissions & SharedAccessQueuePermissions.ProcessMessages) == SharedAccessQueuePermissions.ProcessMessages)
            {
                builder.Append("p");
            }

            return builder.ToString();
        }

        /// <summary>
        /// Constructs a <see cref="SharedAccessQueuePermissions"/> object from a permissions string.
        /// </summary>
        /// <param name="value">The shared access permissions in string format.</param>
        /// <returns>A set of shared access permissions.</returns>
        public static SharedAccessQueuePermissions PermissionsFromString(string value)
        {
            char[] chars = value.ToCharArray();
            SharedAccessQueuePermissions permissions = 0;

            foreach (char c in chars)
            {
                switch (c)
                {
                    case 'r':
                        permissions |= SharedAccessQueuePermissions.Read;
                        break;
                    case 'a':
                        permissions |= SharedAccessQueuePermissions.Add;
                        break;
                    case 'u':
                        permissions |= SharedAccessQueuePermissions.Update;
                        break;
                    case 'p':
                        permissions |= SharedAccessQueuePermissions.ProcessMessages;
                        break;
                    default:
                        CommonUtils.ArgumentOutOfRange("value", value);
                        break;
                }
            }

            // Incase we ever change none to be something other than 0
            if (permissions == 0)
            {
                permissions |= SharedAccessQueuePermissions.None;
            }

            return permissions;
        }
    }
}
