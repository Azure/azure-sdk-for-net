// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    public partial class ContainerRegistryCredentials
    {
        // The `SourceRegistryCredentials` class now have more properties, add this property back for compatibility reason.
        /// <summary>
        /// The authentication mode which determines the source registry login scope. The credentials for the source registry
        /// will be generated using the given scope. These credentials will be used to login to
        /// the source registry during the run.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("sourceRegistry.loginMode")]
        public SourceRegistryLoginMode? SourceRegistryLoginMode
        {
            get => SourceRegistry is null ? default : SourceRegistry.LoginMode;
            set
            {
                if (SourceRegistry is null)
                    SourceRegistry = new SourceRegistryCredentials();
                SourceRegistry.LoginMode = value;
            }
        }
    }
}
