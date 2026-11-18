// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using NUnit.Framework;
using Specs.Azure.ClientGenerator.Core.ClientDoc;
using Specs.Azure.ClientGenerator.Core.ClientDoc._Documentation;
using DocumentationClient = Specs.Azure.ClientGenerator.Core.ClientDoc._Documentation.Documentation;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ClientDoc
{
    public class ClientDocTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientDoc_Documentation() => Test(async (host) =>
        {
            // XML comments are emitted alongside the assembly, not stored in reflection metadata.
            var documentation = XDocument.Load(Path.ChangeExtension(typeof(Plant).Assembly.Location, ".xml"));
            Assert.AreEqual(
                "A plant in the garden. This model is used to represent a plant in the client SDK.",
                GetSummary(documentation, $"T:{typeof(Plant).FullName}"));

            var harvestMethods = typeof(DocumentationClient).GetMethods()
                .Where(method => method.Name == nameof(DocumentationClient.Harvest) || method.Name == nameof(DocumentationClient.HarvestAsync))
                .ToArray();
            Assert.AreEqual(4, harvestMethods.Length);
            foreach (var method in harvestMethods)
            {
                var parameterTypes = string.Join(",", method.GetParameters().Select(parameter => parameter.ParameterType.FullName));
                var memberId = $"M:{method.DeclaringType!.FullName}.{method.Name}({parameterTypes})";
                var summary = GetSummary(documentation, memberId);
                StringAssert.Contains("Retrieves a plant from the garden by submitting its name.", summary, memberId);
                StringAssert.DoesNotContain("Internal operation to get a plant.", summary, memberId);
            }

            var response = await new ClientDocClient(host, null)
                .GetDocumentationClient().HarvestAsync(new Plant("Rose", "Rosa"));

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("Rose", response.Value.Name);
            Assert.AreEqual("Rosa", response.Value.Species);
        });

        private static string GetSummary(XDocument documentation, string memberId)
        {
            var member = documentation.Descendants("member").Single(element => (string?)element.Attribute("name") == memberId);
            var summary = member.Element("summary");
            Assert.IsNotNull(summary, $"Missing summary for {memberId}");
            return string.Join(" ", summary!.Value.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
