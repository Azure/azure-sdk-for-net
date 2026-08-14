// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class ImageRepositoryCredentials
    {
        /// <summary> Initializes a new instance of <see cref="ImageRepositoryCredentials"/>. </summary>
        /// <param name="registryUriString"> The URL of the authentication server used to validate the repository credentials. </param>
        /// <param name="username"> The username used to access an image in the target repository. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="registryUriString"/> or <paramref name="username"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageRepositoryCredentials(string registryUriString, string username)
            : this(null, registryUriString, username, null)
        {
        }
    }
}
