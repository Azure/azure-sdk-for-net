// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

#nullable enable

namespace OpenTelemetry.Trace;

/// <summary>
/// Defines well-known span attribute keys.
/// </summary>
internal static class SpanAttributeConstants
{
    public const string StatusCodeKey = "otel.status_code";
    public const string StatusDescriptionKey = "otel.status_description";
}
