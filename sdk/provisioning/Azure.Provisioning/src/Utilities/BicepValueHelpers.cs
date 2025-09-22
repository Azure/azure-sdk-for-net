// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                bicepValue = bicepValue.LiteralValue as IBicepValue;
            }
        }
    }
}
