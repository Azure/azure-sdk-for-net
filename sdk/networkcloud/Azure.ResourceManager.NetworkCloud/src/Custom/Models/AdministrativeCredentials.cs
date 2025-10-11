// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    /// <summary> AdministrativeCredentials represents the admin credentials for the device requiring password-based authentication. </summary>
    public partial class AdministrativeCredentials
    {
        /// <summary> Initializes a new instance of <see cref="AdministrativeCredentials"/>. </summary>

        /// <param name="username"> The username of the administrator of the device used during initialization. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="username"/> is null. </exception>
        public AdministrativeCredentials(string username)
        {
            Argument.AssertNotNull(username, nameof(username));
            Username = username;
        }
    }
}
