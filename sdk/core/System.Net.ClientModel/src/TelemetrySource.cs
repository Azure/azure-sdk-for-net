// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Reflection;
using System.Net.ClientModel.Internal;

namespace System.Net.ClientModel.Core
{
    internal class TelemetrySource
    {
        private readonly DiagnosticScopeFactory _factory;

        // TODO: Options needs to be ClientOptions to get the namespace for the service client library.
        // Loop back on this once we decide what ClientOptions is in this world.
        public TelemetrySource(PipelineOptions options, bool suppressNestedClientActivities = true)
        {
            _factory = new DiagnosticScopeFactory(
                options.GetType().Namespace!,
                GetResourceProviderNamespace(options.GetType().Assembly),
                // TODO: get the following value from options.Diagnostics.IsDistributedTracingEnabled
                true,
                suppressNestedClientActivities);
        }

        public TelemetrySpan CreateSpan(string name)
        {
            return new TelemetrySpan(_factory.CreateScope(name, ActivityKind.Internal));
        }

        private static string? GetResourceProviderNamespace(Assembly assembly)
        {
            foreach (var customAttribute in assembly.GetCustomAttributes(true))
            {
                // Weak bind internal shared type
                var attributeType = customAttribute.GetType();
                if (attributeType.Name == "AzureResourceProviderNamespaceAttribute")
                {
                    return attributeType.GetProperty("ResourceProviderNamespace")?.GetValue(customAttribute) as string;
                }
            }

            return null;
        }
    }
}