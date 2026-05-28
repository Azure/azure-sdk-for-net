// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.HealthDataAIServices.Models
{
    public partial class DeidServicePatch
    {
        // NOTE: Since the generator also generates a type with the same name inside this namespace, here we must use the fully qualified name

        /// <summary> Updatable managed service identity. </summary>
        [CodeGenMember("Identity")]
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get; set; }
    }
}
