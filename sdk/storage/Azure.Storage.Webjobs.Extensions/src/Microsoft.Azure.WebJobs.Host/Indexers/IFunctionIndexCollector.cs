// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Reflection;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host.Indexers
{
    internal interface IFunctionIndexCollector
    {
        void Add(IFunctionDefinition function, FunctionDescriptor descriptor, MethodInfo method);
    }
}
