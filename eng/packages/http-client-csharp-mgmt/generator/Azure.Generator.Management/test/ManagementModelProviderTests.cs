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
        [TestCase("WidgetContent", "WidgetContent")]
        [TestCase("content", "Content")]
        [TestCase("widget_content", "WidgetContent")]
        [TestCase("IpAddressContent", "IPAddressContent")]
        [TestCase("WidgetRequest", "WidgetRequest")]
        public void InputModelsPreserveManagementContentSuffix(string inputName, string expectedName)
        {
            var input = InputFactory.Model(inputName, usage: InputModelTypeUsage.Input | InputModelTypeUsage.Json);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input]);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;

            Assert.That(model.Name, Is.EqualTo(expectedName));
            Assert.That(model.Constructors.Select(c => c.Signature.Type.Name), Is.All.EqualTo(expectedName));
        }
    }
}
