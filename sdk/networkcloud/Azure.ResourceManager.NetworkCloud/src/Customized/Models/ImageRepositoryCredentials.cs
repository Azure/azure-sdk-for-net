// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    /// <summary> ImageRepositoryCredentials represents the credentials used to login to the image repository. </summary>
    public partial class ImageRepositoryCredentials
    {
        #pragma warning disable CA1056
        /// <summary> The URL of the authentication server used to validate the repository credentials. </summary>
        public string RegistryUri { get; set; }
        #pragma warning restore CA1056
    }
}
