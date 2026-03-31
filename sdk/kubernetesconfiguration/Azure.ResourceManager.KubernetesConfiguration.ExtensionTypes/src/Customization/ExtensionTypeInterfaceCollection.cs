// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes
{
    // Generator bug workaround: the multi-scope resource generates MockableSubscription/ResourceGroup
    // that pass extra scope parameters (location, clusterRp, etc.) to the collection constructor,
    // but the generated collection only has a 2-arg constructor. Add the missing overloads.
    public partial class ExtensionTypeInterfaceCollection
    {
        internal ExtensionTypeInterfaceCollection(ArmClient client, ResourceIdentifier id, string location)
            : this(client, id)
        {
        }

        internal ExtensionTypeInterfaceCollection(ArmClient client, ResourceIdentifier id, string clusterRp, string clusterResourceName, string clusterName)
            : this(client, id)
        {
        }
    }
}
