// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using System.Diagnostics;
using System.Reflection;

namespace System.ServiceModel.Rest.Core
{
    public class TelemetrySource
    {
        private readonly DiagnosticScopeFactory _factory;

        public TelemetrySource(RequestOptions options, bool suppressNestedClientActivities = true)
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
#if NETCOREAPP2_1
            return new TelemetrySpan(_factory.CreateScope(name, TelemetrySpan.FromActivityKind(TelemetrySpan.ActivityKind.Internal)));
#else
            return new TelemetrySpan(_factory.CreateScope(name, ActivityKind.Internal));
#endif
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