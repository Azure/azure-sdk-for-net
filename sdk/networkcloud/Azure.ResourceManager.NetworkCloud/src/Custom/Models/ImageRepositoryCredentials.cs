// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    /// <summary> ImageRepositoryCredentials represents the credentials used to login to the image repository. </summary>
    public partial class ImageRepositoryCredentials
    {
        /// <summary> Initializes a new instance of <see cref="ImageRepositoryCredentials"/>. </summary>

        /// <param name="registryUriString"> The URL of the authentication server used to validate the repository credentials. </param>
        /// <param name="username"> The username used to access an image in the target repository. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="registryUriString"/> or <paramref name="username"/> is null. </exception>
        public ImageRepositoryCredentials(string registryUriString, string username)
        {
            Argument.AssertNotNull(registryUriString, nameof(registryUriString));
            Argument.AssertNotNull(username, nameof(username));
            RegistryUriString = registryUriString;
            Username = username;
        }
    }
}
