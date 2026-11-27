// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

namespace OpenTelemetry.Internal;

internal static class SchemaUrls
{
    public static string Get(Version semanticConventionsVersion)
        => $"https://opentelemetry.io/schemas/{semanticConventionsVersion.ToString(3)}";
}
