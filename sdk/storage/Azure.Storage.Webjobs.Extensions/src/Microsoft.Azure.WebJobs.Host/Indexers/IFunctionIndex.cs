// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Reflection;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host.Indexers
{
    internal interface IFunctionIndex : IFunctionIndexLookup
    {
        IEnumerable<IFunctionDefinition> ReadAll();

        IEnumerable<FunctionDescriptor> ReadAllDescriptors();

        IEnumerable<MethodInfo> ReadAllMethods();
    }
}
