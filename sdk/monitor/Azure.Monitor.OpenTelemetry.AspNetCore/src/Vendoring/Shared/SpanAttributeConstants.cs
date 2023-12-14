// <copyright file="SpanAttributeConstants.cs" company="OpenTelemetry Authors">
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

#nullable enable

namespace OpenTelemetry.Trace;

/// <summary>
/// Defines well-known span attribute keys.
/// </summary>
internal static class SpanAttributeConstants
{
    public const string StatusCodeKey = "otel.status_code";
    public const string StatusDescriptionKey = "otel.status_description";
    public const string DatabaseStatementTypeKey = "db.statement_type";
}
