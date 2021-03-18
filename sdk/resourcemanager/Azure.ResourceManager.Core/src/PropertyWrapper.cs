// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Resources;
using System.Reflection;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    internal class PropertyWrapper
    {
        internal PropertyInfo Info { get; }

        internal object PropertyObject { get; }

        internal PropertyWrapper(PropertyInfo info, object propObject)
        {
            Info = info;
            PropertyObject = propObject;
        }
    }
}
