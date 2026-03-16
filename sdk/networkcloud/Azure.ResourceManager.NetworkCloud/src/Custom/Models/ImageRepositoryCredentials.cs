// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class ImageRepositoryCredentials
    {
        /// <summary> Initializes a new instance of <see cref="ImageRepositoryCredentials"/>. </summary>
        /// <param name="password"> The password or token used to access an image in the target repository. </param>
        /// <param name="registryUrl"> The URL of the authentication server used to validate the repository credentials. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageRepositoryCredentials(string password, string registryUrl)
            : this(password, registryUrl, null, null)
        {
        }
    }
}
