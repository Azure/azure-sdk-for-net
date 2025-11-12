// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Utilities
{
    internal static class BicepValueHelpers
    {
        internal static void SetSelf(this IBicepValue value, BicepValueReference? self)
        {
            IBicepValue? bicepValue = value;
            while (bicepValue is IBicepValue)
            {
                bicepValue.Self = self;
                if (bicepValue is ProvisionableConstruct)
                {
                    break; // Stop traversal at ProvisionableConstruct to avoid repeatedly processing the same instance (which would cause an infinite loop or redundant work), since its LiteralValue refers back to itself.
                }
                bicepValue = bicepValue.LiteralValue as IBicepValue;
            }
        }
    }
}
