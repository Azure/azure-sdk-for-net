// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Mgmt.Providers;
using Azure.Generator.Mgmt.Tests.TestHelpers;
using Azure.Generator.Tests.Common;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests.Providers
{
    internal class MgmtLongRunningOperationProviderTests
    {
        [SetUp]
        public void SetUp()
        {
            MgmtMockHelpers.LoadMockPlugin();
        }

        [TestCase]
        public void Verify_NonGeneric_LROProviderGeneration()
        {
            var nonGenericLROProvider = new MgmtLongRunningOperationProvider(false);
            var codeFile = new TypeProviderWriter(nonGenericLROProvider).Write();
            var result = codeFile.Content;

            var exptected = Helpers.GetExpectedFromFile();

            Assert.AreEqual(exptected, result);
        }

        [TestCase]
        public void Verify_Generic_LROProviderGeneration()
        {
            var genericLROProvider = new MgmtLongRunningOperationProvider(true);
            var codeFile = new TypeProviderWriter(genericLROProvider).Write();
            var result = codeFile.Content;

            var exptected = Helpers.GetExpectedFromFile();

            Assert.AreEqual(exptected, result);
        }
    }
}
