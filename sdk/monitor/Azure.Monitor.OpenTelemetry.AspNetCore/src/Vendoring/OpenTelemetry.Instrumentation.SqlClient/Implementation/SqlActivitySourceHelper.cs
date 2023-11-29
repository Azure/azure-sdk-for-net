// <copyright file="SqlActivitySourceHelper.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
using System.Diagnostics;
using System.Reflection;
using OpenTelemetry.Trace;

namespace OpenTelemetry.Instrumentation.SqlClient.Implementation;

/// <summary>
/// Helper class to hold common properties used by both SqlClientDiagnosticListener on .NET Core
/// and SqlEventSourceListener on .NET Framework.
/// </summary>
internal sealed class SqlActivitySourceHelper
{
    public const string MicrosoftSqlServerDatabaseSystemName = "mssql";

    public static readonly AssemblyName AssemblyName = typeof(SqlActivitySourceHelper).Assembly.GetName();
    public static readonly string ActivitySourceName = AssemblyName.Name;
    public static readonly Version Version = AssemblyName.Version;
    public static readonly ActivitySource ActivitySource = new(ActivitySourceName, Version.ToString());
    public static readonly string ActivityName = ActivitySourceName + ".Execute";

    public static readonly IEnumerable<KeyValuePair<string, object>> CreationTags = new[]
    {
        new KeyValuePair<string, object>(SemanticConventions.AttributeDbSystem, MicrosoftSqlServerDatabaseSystemName),
    };
}
