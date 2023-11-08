// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

#nullable enable

namespace Azure.Core.Pipeline
{
#pragma warning disable CA1001 // Types that own disposable fields should be disposable
    internal class DiagnosticScopeFactory
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        private static Dictionary<string, DiagnosticListener>? _listeners;
        private readonly string? _resourceProviderNamespace;
        private readonly DiagnosticListener? _source;
        private readonly bool _suppressNestedClientActivities;

#if NETCOREAPP2_1
        private static readonly ConcurrentDictionary<string, object?> ActivitySources = new();
#else
        private static readonly ConcurrentDictionary<string, ActivitySource?> ActivitySources = new();
#endif

        public DiagnosticScopeFactory(string clientNamespace, string? resourceProviderNamespace, bool isActivityEnabled, bool suppressNestedClientActivities = true)
        {
            _resourceProviderNamespace = resourceProviderNamespace;
            IsActivityEnabled = isActivityEnabled;
            _suppressNestedClientActivities = suppressNestedClientActivities;

            if (IsActivityEnabled)
            {
                var listeners = LazyInitializer.EnsureInitialized(ref _listeners);

                lock (listeners!)
                {
                    if (!listeners.TryGetValue(clientNamespace, out _source))
                    {
                        _source = new DiagnosticListener(clientNamespace);
                        listeners[clientNamespace] = _source;
                    }
                }
            }
        }

        public bool IsActivityEnabled { get; }

        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "The DiagnosticScope constructor is marked as RequiresUnreferencedCode because of the usage of the diagnosticSourceArgs parameter. Since we are passing in null here we can suppress this warning.")]
#if NETCOREAPP2_1
        public DiagnosticScope CreateScope(string name, DiagnosticScope.ActivityKind kind = DiagnosticScope.ActivityKind.Internal)
#else
        public DiagnosticScope CreateScope(string name, System.Diagnostics.ActivityKind kind = ActivityKind.Internal)
#endif
        {
            if (_source == null)
            {
                return default;
            }

            var scope = new DiagnosticScope(
                                scopeName: name,
                                source: _source,
                                diagnosticSourceArgs: null,
                                activitySource: GetActivitySource(_source.Name, name),
                                kind: kind,
                                suppressNestedClientActivities: _suppressNestedClientActivities);

            if (_resourceProviderNamespace != null)
            {
                scope.AddAttribute("az.namespace", _resourceProviderNamespace);
            }
            return scope;
        }

        /// <summary>
        /// This method combines client namespace and operation name into an ActivitySource name and creates the activity source.
        /// For example:
        ///     ns: Azure.Storage.Blobs
        ///     name: BlobClient.DownloadTo
        ///     result Azure.Storage.Blobs.BlobClient
        /// </summary>
#if NETCOREAPP2_1
        private static object? GetActivitySource(string ns, string name)
#else
        private static ActivitySource? GetActivitySource(string ns, string name)
#endif
        {
#if NETCOREAPP2_1
            if (!ActivityExtensions.SupportsActivitySource())
#else
            if (!ActivityExtensions.SupportsActivitySource)
#endif
            {
                return null;
            }

            int indexOfDot = name.IndexOf(".", StringComparison.OrdinalIgnoreCase);
            string clientName = ns + "." + ((indexOfDot < 0) ? name : name.Substring(0, indexOfDot));

#if NETCOREAPP2_1
            return ActivitySources.GetOrAdd(clientName, static n => ActivityExtensions.CreateActivitySource(n));
#else
            return ActivitySources.GetOrAdd(clientName, static n => new ActivitySource(n));
#endif
        }
    }
}
