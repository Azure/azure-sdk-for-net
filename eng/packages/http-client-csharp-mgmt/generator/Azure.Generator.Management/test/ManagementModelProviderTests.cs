// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests
{
    public class ManagementModelProviderTests
    {
        private static IEnumerable<TestCaseData> SuffixCases()
        {
            (string Name, string Expected)[] names =
            [
                ("WidgetContent", "WidgetContent"),
                ("content", "Content"),
                ("widget_content", "WidgetContent"),
                ("IpAddressContent", "IPAddressContent"),
                ("WidgetRequest", "WidgetContent"),
                ("IpAddressRequest", "IPAddressContent")
            ];
            InputModelTypeUsage[] usages =
            [
                InputModelTypeUsage.Input,
                InputModelTypeUsage.Output,
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                InputModelTypeUsage.Error
            ];
            foreach (var (name, expected) in names)
            {
                foreach (var usage in usages)
                {
                    yield return new TestCaseData(name, expected, usage);
                }
            }
        }

        [TestCaseSource(nameof(SuffixCases))]
        public void ModelsUseUpstreamSuffixNormalization(string inputName, string expectedName,
            InputModelTypeUsage usage)
        {
            var input = InputFactory.Model(inputName, usage: usage | InputModelTypeUsage.Json);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input]);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;

            Assert.That(model.Name, Is.EqualTo(expectedName));
            Assert.That(model.Constructors.Select(c => c.Signature.Type.Name), Is.All.EqualTo(expectedName));
        }
    }
}
