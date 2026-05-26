// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.MongoCluster.Models
{
    /// <summary> The authentication modes supporting on the Mongo cluster. </summary>
    public readonly partial struct MongoClusterAuthenticationMode
    {
        /// <summary> Microsoft Entra ID authentication mode using Entra users assigned to the cluster and auth mechanism 'MONGODB-OIDC'. </summary>
        public static MongoClusterAuthenticationMode MicrosoftEntraId => MicrosoftEntraID;
    }
}
