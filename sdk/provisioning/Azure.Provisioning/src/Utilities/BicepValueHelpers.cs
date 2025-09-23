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
                    break; // we cannot go into LiteralValue now because it would be the same instance
                }
                bicepValue = bicepValue.LiteralValue as IBicepValue;
            }
        }
    }
}
