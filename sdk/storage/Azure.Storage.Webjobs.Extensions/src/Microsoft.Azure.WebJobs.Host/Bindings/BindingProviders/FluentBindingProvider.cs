// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host
{
    // Base class to aide in private backwards compatability hooks for some bindings. 
    // Help in implementing a Fluent API design where these extra properties are set
    // via method cascading rather than all at once upfront. 
    internal class FluentBindingProvider<TAttribute>
    {
        protected internal Func<TAttribute, ParameterInfo, INameResolver, ParameterDescriptor> BuildParameterDescriptor { get; set; }
    }
}