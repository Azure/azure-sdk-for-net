// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using System.Diagnostics;
using System.Reflection;

namespace System.ServiceModel.Rest
{
    /// <summary>
    /// TBD.
    /// </summary>
    public class TraceSpanFactory
    {
        private readonly DiagnosticScopeFactory _factory;

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="suppressNestedClientActivities"></param>
        public TraceSpanFactory(PipelineOptions options, bool suppressNestedClientActivities = true)
        {
            _factory = new DiagnosticScopeFactory(
                options.GetType().Namespace!,
                GetResourceProviderNamespace(options.GetType().Assembly),
                // TODO: get the following value from options.Diagnostics.IsDistributedTracingEnabled
                true,
                suppressNestedClientActivities);
        }

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
#if NETCOREAPP2_1
        public TraceSpan CreateSpan(string name, TraceSpan.ActivityKind kind = TraceSpan.ActivityKind.Internal)
#else
        public TraceSpan CreateSpan(string name, ActivityKind kind = ActivityKind.Internal)
#endif
        {
#if NETCOREAPP2_1
            DiagnosticScope.ActivityKind activityKind = TraceSpan.FromActivityKind(kind);
            return new TraceSpan(_factory.CreateScope(name, activityKind));
#else
            return new TraceSpan(_factory.CreateScope(name, kind));
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