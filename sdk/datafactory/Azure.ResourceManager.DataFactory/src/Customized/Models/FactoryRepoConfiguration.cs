// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Restores the protected constructor dropped by MPG generator (issue #59298).

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    public abstract partial class FactoryRepoConfiguration
    {
        /// <summary> Initializes a new instance of <see cref="FactoryRepoConfiguration"/>. </summary>
        /// <param name="accountName"> Account name. </param>
        /// <param name="repositoryName"> Repository name. </param>
        /// <param name="collaborationBranch"> Collaboration branch. </param>
        /// <param name="rootFolder"> Root folder. </param>
        protected FactoryRepoConfiguration(string accountName, string repositoryName, string collaborationBranch, string rootFolder)
            : this(null, accountName, repositoryName, collaborationBranch, rootFolder)
        {
        }
    }
}
