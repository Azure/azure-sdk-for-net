// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Utilities
{
    internal class BodyParameterNameNormalizerTests
    {
        [TestCase("IPAddress", "ipAddress")]
        [TestCase("IPv4Address", "ipv4Address")]
        [TestCase("IPv6Address", "ipv6Address")]
        [TestCase("IPV4Address", "ipV4Address")]
        [TestCase("IPV6Address", "ipV6Address")]
        [TestCase("IpAddress", "ipAddress")]
        [TestCase("Ipv4Address", "ipv4Address")]
        [TestCase("Ipv6Address", "ipv6Address")]
        [TestCase("IpV4Address", "ipv4Address")]
        [TestCase("IpV6Address", "ipv6Address")]
        [TestCase("DBAccount", "dbAccount")]
        [TestCase("OSProfile", "osProfile")]
        [TestCase("SourceIpAddress", "sourceIPAddress")]
        [TestCase("SourceDbAccount", "sourceDBAccount")]
        [TestCase("SourceOsProfile", "sourceOSProfile")]
        [TestCase("SourceIpv4Address", "sourceIPv4Address")]
        [TestCase("SourceIpv6Address", "sourceIPv6Address")]
        [TestCase("SourceIpV4Address", "sourceIPv4Address")]
        [TestCase("IpAddressIpAddress", "ipAddressIPAddress")]
        [TestCase("IpIpAddress", "ipIPAddress")]
        [TestCase("IPIPAddress", "ipIPAddress")]
        [TestCase("DBDBAccount", "dbDBAccount")]
        [TestCase("OSOSProfile", "osOSProfile")]
        [TestCase("SourceIPIpAddress", "sourceIPIPAddress")]
        [TestCase("DbAccountDbAccount", "dbAccountDBAccount")]
        [TestCase("OsProfileOsProfile", "osProfileOSProfile")]
        [TestCase("Ipv4AddressIpv6Address", "ipv4AddressIPv6Address")]
        [TestCase("SourceIpsecPolicy", "sourceIpsecPolicy")]
        [TestCase("SourceIpv4address", "sourceIpv4address")]
        [TestCase("IpsecPolicy", "ipsecPolicy")]
        [TestCase("DbcConfiguration", "dbcConfiguration")]
        [TestCase("Ostrich", "ostrich")]
        [TestCase("WidgetPatch", "patch")]
        [TestCase("IPDetails", "details")]
        [TestCase("IPv4Data", "data")]
        [TestCase("IPv6Content", "content")]
        [TestCase("IPParameters", "content")]
        [TestCase("DBRequest", "content")]
        [TestCase("OSOptions", "content")]
        [TestCase("IPInfo", "content")]
        [TestCase("IPv4Input", "content")]
        public void NormalizesTypeDerivedBodyName(string typeName, string expected)
        {
            var parameter = CreateParameter(typeName);

            Assert.That(BodyParameterNameNormalizer.GetNormalizedBodyParameterName(parameter), Is.EqualTo(expected));
            Assert.That(parameter.WireInfo.SerializedName, Is.EqualTo("parameters"));
        }

        [TestCase("patch")]
        [TestCase("details")]
        [TestCase("data")]
        [TestCase("content")]
        [TestCase("iPv4Address")]
        [TestCase("iPv6Address")]
        public void LeavesNonFallbackNamesUnchanged(string name)
        {
            var parameter = CreateParameter("IPv4Address", name);

            Assert.That(BodyParameterNameNormalizer.GetNormalizedBodyParameterName(parameter), Is.EqualTo(name));
        }

        [Test]
        public void IgnoresNonBodyParameters()
        {
            var parameter = CreateParameter("IPAddress", location: ParameterLocation.Path);

            Assert.That(BodyParameterNameNormalizer.GetNormalizedBodyParameterName(parameter), Is.Null);
        }

        [TestCase("IPv4Address")]
        [TestCase("WidgetPatch")]
        [TestCase("WidgetContent")]
        public void PreservesExactBodyNames(string typeName)
        {
            var model = InputFactory.Model(typeName);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            var input = InputFactory.MethodParameter("parameters", model, isRequired: true);
            typeof(InputParameter).GetProperty(nameof(InputParameter.IsExactName))!.SetValue(input, true);
            var parameter = new ParameterProvider(input);

            Assert.That(BodyParameterNameNormalizer.GetNormalizedBodyParameterName(parameter), Is.EqualTo("parameters"));
        }

        [Test]
        public void OperationBodyPreservesContractNamesAndSourceMetadata(
            [Values("IPv4Address", "IPv6Address")] string typeName,
            [Values] bool custom,
            [Values] bool async,
            [Values] bool exact,
            [Values] bool uppercase)
        {
            var (client, resourceModels) = InputResourceData.ClientWithResource();
            var model = InputFactory.Model(typeName);
            var legacyName = uppercase ? typeName : typeName == "IPv4Address" ? "iPv4Address" : "iPv6Address";
            var methodName = async ? "ConfigureAsync" : "Configure";
            var source = $$"""
                namespace Samples.Models { public class {{typeName}} { } }
                namespace Samples
                {
                    public class ResponseTypeResource
                    {
                        public void {{methodName}}(Samples.Models.{{typeName}} {{legacyName}}, System.Threading.CancellationToken cancellationToken = default) { }
                    }
                }
                """;
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [.. resourceModels, model],
                clients: () => [client],
                customizationSources: custom ? [source] : null,
                lastContractCompilation: custom ? null : () => Helpers.BuildCompilation([("Contract.cs", source)]));
            var resource = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceClientProvider>().Single();
            var input = InputFactory.MethodParameter("parameters", model, isRequired: true);
            typeof(InputParameter).GetProperty(nameof(InputParameter.IsExactName))!.SetValue(input, exact);
            var parameter = new ParameterProvider(input);
            var convenience = new MethodProvider(
                new MethodSignature(methodName, null, MethodSignatureModifiers.Public, null, null, [parameter, KnownParameters.CancellationTokenParameter]),
                MethodBodyStatement.Empty,
                resource);
            var serviceMethod = InputFactory.BasicServiceMethod(
                "configure",
                InputFactory.Operation("configure", httpMethod: "POST", parameters: [InputFactory.BodyParameter("parameters", model)]),
                parameters: [input]);

            var parameters = OperationMethodParameterHelper.GetOperationMethodParameters(
                serviceMethod, convenience, new ParameterContextRegistry([]), resource, methodName: methodName);

            Assert.That(parameters[0].Name, Is.EqualTo(exact ? "parameters" : legacyName));
            Assert.That(((VariableExpression)parameters[0]).ToDisplayString(), Is.EqualTo(exact ? "parameters" : legacyName));
            Assert.That(parameters[0].InputParameter, Is.SameAs(input));
            Assert.That(parameters[0].WireInfo, Is.SameAs(parameter.WireInfo));
            Assert.That(parameter.Name, Is.EqualTo("parameters"), "The shared convenience parameter must not be mutated.");
        }

        private static ParameterProvider CreateParameter(string typeName, string name = "parameters", ParameterLocation location = ParameterLocation.Body)
        {
            var model = InputFactory.Model(typeName);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            return new ParameterProvider(name, $"The body.", plugin.Object.TypeFactory.CreateCSharpType(model)!, location: location);
        }
    }
}
