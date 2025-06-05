// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Providers;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Tests.Providers
{
    internal class MgmtLongRunningOperationProviderTests
    {
        [SetUp]
        public void SetUp()
        {
            MockHelpers.LoadMockPlugin();
        }

        [TestCase]
        public void Verify_NonGeneric_MgmtLROProviderGeneration()
        {
            var nonGenericLROProvider = new MgmtLongRunningOperationProvider(false);
            var codeFile = new TypeProviderWriter(nonGenericLROProvider).Write();
            var result = codeFile.Content;

            var exptected = Helpers.GetExpectedFromFile();

            Assert.AreEqual(exptected, result);
        }

        [TestCase]
        public void Verify_Generic_MgmtLROProviderGeneration()
        {
            var genericLROProvider = new MgmtLongRunningOperationProvider(true);
            var codeFile = new TypeProviderWriter(genericLROProvider).Write();
            var result = codeFile.Content;

            var exptected = Helpers.GetExpectedFromFile();

            Assert.AreEqual(exptected, result);
        }
    }
}
