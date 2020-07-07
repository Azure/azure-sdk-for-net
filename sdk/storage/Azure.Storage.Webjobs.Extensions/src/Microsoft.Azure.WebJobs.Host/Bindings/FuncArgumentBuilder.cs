// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    // Deelegate for binding helpers. Converts from an attribute and binding context to an IValueProvider. 
    // Common usage here is that this delegate is a closure that pulls in other information it needs to do the conversion. 
    internal delegate IValueProvider FuncArgumentBuilder<TAttribute>(TAttribute attribute, ValueBindingContext context);
}