// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

/// <summary>
/// Handler code typically imports this package's namespaces together with <c>OpenAI.Responses</c>
/// and <c>Azure.AI.Extensions.OpenAI</c>. A public type whose simple name also exists in one of those
/// namespaces makes every unqualified use fail with CS0104 in consumer code. The test project links
/// <c>OpenAITypeAliases.cs</c>, whose global aliases hide such ambiguities from the rest of the suite,
/// so this check inspects the public surface directly.
/// </summary>
public class ConsumerNameCollisionTests
{
    // Exposed by the public OutputItemCustomToolCall model; goes away once custom tool calls map to
    // OpenAI.Responses.CustomToolCallItem / CustomToolCallOutputItem.
    private static readonly HashSet<string> KnownCollisions = new(StringComparer.Ordinal)
    {
        "FunctionCallStatus",
    };

    [Test]
    public void PublicTypes_DoNotCollideWithOpenAIOrExtensionsTypeNames()
    {
        var ownTypes = PublicTypes(typeof(ResponseHandler).Assembly)
            .Where(t => IsInNamespace(t, "Azure.AI.AgentServer.Responses"));

        var consumerVisibleNames = PublicTypes(typeof(global::OpenAI.Responses.ResponseItem).Assembly)
            .Where(t => t.Namespace == "OpenAI.Responses")
            .Concat(PublicTypes(typeof(global::Azure.AI.Extensions.OpenAI.AgentReference).Assembly)
                .Where(t => IsInNamespace(t, "Azure.AI.Extensions.OpenAI")))
            .Select(t => t.Name)
            .ToHashSet(StringComparer.Ordinal);

        var collisions = ownTypes
            .Select(t => t.Name)
            .Where(consumerVisibleNames.Contains)
            .Where(name => !KnownCollisions.Contains(name))
            .Distinct()
            .OrderBy(name => name, StringComparer.Ordinal)
            .ToList();

        Assert.That(collisions, Is.Empty,
            "Public types that are ambiguous for consumers importing OpenAI.Responses or Azure.AI.Extensions.OpenAI: "
            + string.Join(", ", collisions));
    }

    private static IEnumerable<Type> PublicTypes(Assembly assembly)
        => assembly.GetExportedTypes().Where(t => !t.IsNested);

    private static bool IsInNamespace(Type type, string root)
        => type.Namespace is { } ns && (ns == root || ns.StartsWith(root + ".", StringComparison.Ordinal));
}
