//-----------------------------------------------------------------------
// <copyright file="SharedAccessBlobPolicy.cs" company="Microsoft">
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob
{
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using System;
    using System.Text;

    /// <summary>
    /// Represents a shared access policy, which specifies the start time, expiry time, 
    /// and permissions for a shared access signature.
    /// </summary>
    public sealed class SharedAccessBlobPolicy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SharedAccessBlobPolicy"/> class.
        /// </summary>
        public SharedAccessBlobPolicy()
        {
        }

        /// <summary>
        /// Gets or sets the start time for a shared access signature associated with this shared access policy.
        /// </summary>
        /// <value>The shared access start time.</value>
        public DateTimeOffset? SharedAccessStartTime { get; set; }

        /// <summary>
        /// Gets or sets the expiry time for a shared access signature associated with this shared access policy.
        /// </summary>
        /// <value>The shared access expiry time.</value>
        public DateTimeOffset? SharedAccessExpiryTime { get; set; }

        /// <summary>
        /// Gets or sets the permissions for a shared access signature associated with this shared access policy.
        /// </summary>
        /// <value>The permissions.</value>
        public SharedAccessBlobPermissions Permissions { get; set; }

        /// <summary>
        /// Converts the permissions specified for the shared access policy to a string.
        /// </summary>
        /// <param name="permissions">The shared access permissions.</param>
        /// <returns>The shared access permissions in string format.</returns>
        public static string PermissionsToString(SharedAccessBlobPermissions permissions) 
        {
            // The service supports a fixed order => rwdl
            StringBuilder builder = new StringBuilder();

            if ((permissions & SharedAccessBlobPermissions.Read) == SharedAccessBlobPermissions.Read)
            {
                builder.Append("r");
            }

            if ((permissions & SharedAccessBlobPermissions.Write) == SharedAccessBlobPermissions.Write)
            {
                builder.Append("w");
            }

            if ((permissions & SharedAccessBlobPermissions.Delete) == SharedAccessBlobPermissions.Delete)
            {
                builder.Append("d");
            }

            if ((permissions & SharedAccessBlobPermissions.List) == SharedAccessBlobPermissions.List)
            {
                builder.Append("l");
            }

            return builder.ToString();
        }

        /// <summary>
        /// Constructs a <see cref="SharedAccessBlobPermissions"/> object from a permissions string.
        /// </summary>
        /// <param name="input">The shared access permissions in string format.</param>
        /// <returns>A set of shared access permissions.</returns>
        public static SharedAccessBlobPermissions PermissionsFromString(string input) 
        {
            CommonUtility.AssertNotNull("input", input);

            SharedAccessBlobPermissions permissions = 0;

            foreach (char c in input)
            {
                switch (c)
                {
                    case 'r':
                        permissions |= SharedAccessBlobPermissions.Read;
                        break;

                    case 'w':
                        permissions |= SharedAccessBlobPermissions.Write;
                        break;

                    case 'd':
                        permissions |= SharedAccessBlobPermissions.Delete;
                        break;

                    case 'l':
                        permissions |= SharedAccessBlobPermissions.List;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("input");
                }
            }

            // Incase we ever change none to be something other than 0
            if (permissions == 0)
            {
                permissions |= SharedAccessBlobPermissions.None;
            }

            return permissions;
        }
    }
}
