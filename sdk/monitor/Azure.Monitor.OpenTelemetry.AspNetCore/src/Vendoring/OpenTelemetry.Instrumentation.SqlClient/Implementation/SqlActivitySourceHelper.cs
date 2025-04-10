// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

using System.Diagnostics;
using System.Reflection;
using OpenTelemetry.Internal;
using OpenTelemetry.Trace;

namespace OpenTelemetry.Instrumentation.SqlClient.Implementation;

/// <summary>
/// Helper class to hold common properties used by both SqlClientDiagnosticListener on .NET Core
/// and SqlEventSourceListener on .NET Framework.
/// </summary>
internal sealed class SqlActivitySourceHelper
{
    public const string MicrosoftSqlServerDatabaseSystemName = "mssql";

    public static readonly Assembly Assembly = typeof(SqlActivitySourceHelper).Assembly;
    public static readonly AssemblyName AssemblyName = Assembly.GetName();
    public static readonly string ActivitySourceName = AssemblyName.Name!;
    public static readonly ActivitySource ActivitySource = new(ActivitySourceName, Assembly.GetPackageVersion());
    public static readonly string ActivityName = ActivitySourceName + ".Execute";

    public static readonly IEnumerable<KeyValuePair<string, object?>> CreationTags = new[]
    {
        new KeyValuePair<string, object?>(SemanticConventions.AttributeDbSystem, MicrosoftSqlServerDatabaseSystemName),
    };
}
