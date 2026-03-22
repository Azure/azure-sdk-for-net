// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Diagnostics;

namespace System.ClientModel.Primitives;

/// <summary>
/// A factory for creating <see cref="DiagnosticScope"/> instances that provide
/// distributed tracing support for client libraries built on System.ClientModel.
/// </summary>
/// <remarks>
/// This class is intended to be used by client library authors only.
/// Applications should use the System.Diagnostics package directly for custom tracing.
/// </remarks>
public class DiagnosticScopeFactory
{
    private const string ScmScopeLabel = "scm.sdk.scope";
    private static readonly object ScmScopeValue = bool.TrueString;
    private static readonly ConcurrentDictionary<string, ActivitySource> ActivitySources = new();

    private readonly string _clientNamespace;
    private readonly bool _isActivityEnabled;
    private readonly bool _suppressNestedClientActivities;

    /// <summary>
    /// Creates a new instance of <see cref="DiagnosticScopeFactory"/>.
    /// </summary>
    /// <param name="clientNamespace">The namespace of the client, used as prefix for ActivitySource names.</param>
    /// <param name="isActivityEnabled">Whether distributed tracing is enabled.</param>
    /// <param name="suppressNestedClientActivities">Whether to suppress nested client activities.</param>
    public DiagnosticScopeFactory(string clientNamespace, bool isActivityEnabled, bool suppressNestedClientActivities = true)
    {
        _clientNamespace = clientNamespace;
        _isActivityEnabled = isActivityEnabled;
        _suppressNestedClientActivities = suppressNestedClientActivities;
    }

    /// <summary>
    /// Creates a new <see cref="DiagnosticScope"/> with the specified name.
    /// The scope is not started until <see cref="DiagnosticScope.Start"/> is called,
    /// allowing links, trace context, and attributes to be added before starting.
    /// </summary>
    /// <param name="name">The name of the scope (typically "ClientName.MethodName").</param>
    /// <param name="kind">The kind of activity to create.</param>
    /// <returns>A new <see cref="DiagnosticScope"/> instance.</returns>
    public DiagnosticScope CreateScope(string name, ActivityKind kind = ActivityKind.Internal)
    {
        if (!_isActivityEnabled)
        {
            return default;
        }

        bool shouldSuppressNested = (kind == ActivityKind.Client || kind == ActivityKind.Internal) && _suppressNestedClientActivities;
        if (shouldSuppressNested && ScmScopeValue.Equals(Activity.Current?.GetCustomProperty(ScmScopeLabel)))
        {
            return default;
        }

        ActivitySource activitySource = GetActivitySource(_clientNamespace, name);

        return new DiagnosticScope(activitySource, name, kind, shouldSuppressNested);
    }

    /// <summary>
    /// Gets or creates an ActivitySource for the given client namespace and operation name.
    /// </summary>
    /// <remarks>
    /// This method combines client namespace and operation name into an ActivitySource name.
    /// For example:
    ///     ns: Contoso.WidgetService
    ///     name: WidgetClient.GetWidget
    ///     result: Contoso.WidgetService.WidgetClient
    /// </remarks>
    private static ActivitySource GetActivitySource(string ns, string name)
    {
        int indexOfDot = name.IndexOf(".", StringComparison.OrdinalIgnoreCase);
        string clientName = ns + "." + ((indexOfDot < 0) ? name : name.Substring(0, indexOfDot));

        return ActivitySources.GetOrAdd(clientName, static n => new ActivitySource(n));
    }
}
