// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    // Backward compat: The old Swagger/AutoRest API constructor accepted only username.
    // The new TypeSpec-generated constructor requires both password and username parameters.
    // This overload preserves the old single-parameter constructor signature.
    public partial class AdministrativeCredentials
    {
        /// <summary> Initializes a new instance of <see cref="AdministrativeCredentials"/>. </summary>
        /// <param name="username"> The username of the administrator of the device used during initialization. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="username"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AdministrativeCredentials(string username)
            : this(null, username)
        {
        }
    }
}
