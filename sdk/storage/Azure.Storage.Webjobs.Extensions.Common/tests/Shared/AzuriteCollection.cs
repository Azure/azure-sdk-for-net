// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Xunit;

namespace Azure.WebJobs.Extensions.Storage.Common.Tests
{
    [CollectionDefinition(Name)]
    public class AzuriteCollection : ICollectionFixture<AzuriteFixture>
    {
        public const string Name = nameof(AzuriteCollection);
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
        // It has to be compiled into assembly using it.
    }
}
