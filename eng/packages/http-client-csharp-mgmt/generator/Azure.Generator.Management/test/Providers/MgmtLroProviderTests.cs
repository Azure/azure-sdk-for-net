// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers
{
    internal class MgmtLroProviderTests
    {
        [SetUp]
        public void SetUp()
        {
            ManagementMockHelpers.LoadMockPlugin();
        }

        [TestCase]
        public void Verify_NonGeneric_LROProviderGeneration()
        {
            var nonGenericLROProvider = new ManagementLongRunningOperationProvider(false);
            var codeFile = new TypeProviderWriter(nonGenericLROProvider).Write();
            var result = codeFile.Content;

            var exptected = Helpers.GetExpectedFromFile();

            Assert.AreEqual(exptected, result);
        }

        [TestCase]
        public void Verify_Generic_LROProviderGeneration()
        {
            var genericLROProvider = new ManagementLongRunningOperationProvider(true);
            var codeFile = new TypeProviderWriter(genericLROProvider).Write();
            var result = codeFile.Content;

            var exptected = Helpers.GetExpectedFromFile();

            Assert.AreEqual(exptected, result);
        }
    }
}
