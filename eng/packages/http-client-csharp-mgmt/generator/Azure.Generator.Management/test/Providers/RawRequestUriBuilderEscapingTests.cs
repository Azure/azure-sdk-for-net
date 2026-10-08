// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator;
using NUnit.Framework;
using System.Reflection;

namespace Azure.Generator.Management.Tests.Providers;

internal class RawRequestUriBuilderEscapingTests
{
    [Test]
    public void UpdateQueryEscapesOnlyTheReplacementBranch()
    {
        var plugin = ManagementMockHelpers.LoadMockPlugin();
        var output = plugin.Object.OutputLibrary;
        var visitLibrary = typeof(LibraryVisitor).GetMethod("VisitLibrary", BindingFlags.Instance | BindingFlags.NonPublic)!;
        // Repeating the visitors must not introduce a second escape operation.
        for (var i = 0; i < 2; i++)
        {
            foreach (var visitor in plugin.Object.Visitors)
            {
                visitLibrary.Invoke(visitor, [output]);
            }
        }
        var helper = output.TypeProviders.Single(p => p.Name == "RawRequestUriBuilderExtensions");
        var method = helper.Methods.Single(m => m.Signature.Name == "UpdateQuery");
        var body = method.BodyStatements!.ToDisplayString();
        Assert.That(body, Does.Contain("global::System.Uri.EscapeDataString(value)"));
        Assert.That(body.Split("EscapeDataString").Length - 1, Is.EqualTo(1));
        Assert.That(body, Does.Contain("builder.AppendQuery(name, value, true)"));
    }
}
