// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Management.Utilities
{
    /// <summary>
    /// Utility class that provides extension methods for MethodProvider instances.
    /// </summary>
    internal static class MethodProviderExtensions
    {
        /// <summary>
        /// Determines whether the method provider is a non-resource method.
        /// The method must be cached in the non-resource method cache and its enclosing type
        /// must be either ExtensionProvider or MockableResourceProvider.
        /// </summary>
        /// <param name="methodProvider">The method provider to check.</param>
        /// <returns>true if the method provider is a non-resource method; otherwise, false.</returns>
        public static bool IsNonResourceMethod(this MethodProvider methodProvider)
        {
            return (methodProvider.EnclosingType is ExtensionProvider extensionProvider && extensionProvider.NonResourceMethodProviders.Contains(methodProvider) ||
                    methodProvider.EnclosingType is MockableResourceProvider mockableResource && mockableResource.NonResourceMethodProviders.Contains(methodProvider));
        }
    }
}