// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    /// <summary> The parameters that describes a set of credentials that will be used when a run is invoked. </summary>
    public partial class ContainerRegistryCredentials
    {
        /// <summary>
        /// The authentication mode which determines the source registry login scope. The credentials for the source registry
        /// will be generated using the given scope. These credentials will be used to login to
        /// the source registry during the run.
        /// </summary>
        [WirePath("sourceRegistry.loginMode")]
        [EditorBrowsable(EditorBrowsableState.Never)]
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
