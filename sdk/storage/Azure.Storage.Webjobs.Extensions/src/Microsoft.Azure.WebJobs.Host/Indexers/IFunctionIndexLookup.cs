// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Reflection;

namespace Microsoft.Azure.WebJobs.Host.Indexers
{
    public interface IFunctionIndexLookup
    {
        IFunctionDefinition Lookup(string functionId);

        IFunctionDefinition Lookup(MethodInfo method);

        // This uses the function's short name ("Class.Method"), which can also be overriden
        // by the FunctionName attribute. 
        IFunctionDefinition LookupByName(string name);
    }
}
