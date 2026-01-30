// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Immutable;
using Microsoft.CodeAnalysis.Testing;

namespace Azure.SdkAnalyzers.Tests
{
    internal static class AzureTestReferences
    {
        public static readonly ReferenceAssemblies DefaultReferenceAssemblies =
            ReferenceAssemblies.Default.AddPackages(ImmutableArray.Create(
                new PackageIdentity("Azure.Core", "1.50.0"),
                new PackageIdentity("Microsoft.Bcl.AsyncInterfaces", "10.0.2"),
                new PackageIdentity("System.Text.Json", "10.0.1"),
                new PackageIdentity("System.Threading.Tasks.Extensions", "4.6.3")));
    }
}
