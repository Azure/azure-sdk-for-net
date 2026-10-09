// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers
{
    public class PageableWrapperProviderTests
    {
        [Test]
        public void AsPagesRetainsOverrideSignature([Values(false, true)] bool isAsync)
        {
            ManagementMockHelpers.LoadMockPlugin();
            var provider = new PageableWrapperProvider(isAsync);
            var method = provider.Methods.Single(m => m.Signature.Name == "AsPages");
            Assert.That(method.Signature.Parameters.Count, Is.EqualTo(2));
            Assert.That(method.Signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Override));
            if (isAsync)
            {
                Assert.That(method.BodyStatements!.ToDisplayString(), Does.Contain("AsPagesAsync(continuationToken, pageSizeHint, default)"));
                var iterator = provider.Methods.Single(m => m.Signature.Name == "AsPagesAsync");
                Assert.That(iterator.Signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Private | MethodSignatureModifiers.Async));
                Assert.That(iterator.Signature.Parameters.Last().Attributes.Single().ToDisplayString(),
                    Does.Contain(nameof(EnumeratorCancellationAttribute).Replace("Attribute", "")));
                Assert.That(iterator.BodyStatements!.ToDisplayString(),
                    Does.Contain(".AsPages(continuationToken, pageSizeHint).WithCancellation(cancellationToken).ConfigureAwait(false)"));
            }
            else
            {
                Assert.That(provider.Methods, Has.Length.EqualTo(1));
                Assert.That(method.BodyStatements!.ToDisplayString(), Does.Not.Contain("cancellationToken"));
            }
        }
    }
}
