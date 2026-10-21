// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.Reflection;

namespace Azure.Generator.Management.Tests.Providers
{
    internal class PathParameterNamingTests
    {
        [TestCase("IPConfigurationName", "ipConfigurationName")]
        [TestCase("DBName", "dbName")]
        [TestCase("OSName", "osName")]
        [TestCase("IPv4AddressName", "ipv4AddressName")]
        [TestCase("IPv6AddressName", "ipv6AddressName")]
        [TestCase("publicIPConfigurationName", "publicIPConfigurationName")]
        [TestCase("virtualDBName", "virtualDBName")]
        [TestCase("guestOSName", "guestOSName")]
        [TestCase("publicIpConfigurationName", "publicIPConfigurationName")]
        [TestCase("virtualDbName", "virtualDBName")]
        [TestCase("guestOsName", "guestOSName")]
        [TestCase("publicIPv4AddressName", "publicIPv4AddressName")]
        [TestCase("publicIPv6AddressName", "publicIPv6AddressName")]
        [TestCase("publicIpv4AddressName", "publicIPv4AddressName")]
        [TestCase("publicIpv6AddressName", "publicIPv6AddressName")]
        [TestCase("iPv4AddressName", "ipv4AddressName")]
        [TestCase("iPv6AddressName", "ipv6AddressName")]
        [TestCase("IPV4AddressName", "ipV4AddressName")]
        [TestCase("IPV6AddressName", "ipV6AddressName")]
        [TestCase("sourceIP", "sourceIP")]
        [TestCase("sourceIp", "sourceIP")]
        [TestCase("sourceIpAddress", "sourceIPAddress")]
        [TestCase("sourceIPIpAddress", "sourceIPIPAddress")]
        [TestCase("sourceDb", "sourceDB")]
        [TestCase("sourceOs", "sourceOS")]
        [TestCase("Ipv4Address", "ipv4Address")]
        [TestCase("Ipv6Address", "ipv6Address")]
        [TestCase("sourceIpDbOsIpv4Ipv6Ip", "sourceIPDBOSIPv4IPv6IP")]
        [TestCase("sourceIpAddressIpName", "sourceIPAddressIPName")]
        [TestCase("sourceDbAccountDbName", "sourceDBAccountDBName")]
        [TestCase("sourceOsProfileOsName", "sourceOSProfileOSName")]
        [TestCase("sourceIpv4AddressIpv4Name", "sourceIPv4AddressIPv4Name")]
        [TestCase("sourceIpv6AddressIpv6Name", "sourceIPv6AddressIPv6Name")]
        [TestCase("IP", "ip")]
        [TestCase("DB", "db")]
        [TestCase("OS", "os")]
        [TestCase("ordinaryName", "ordinaryName")]
        [TestCase("SHIPPINGName", "shippingName")]
        [TestCase("IPv4thing", "iPv4thing")]
        [TestCase("sourceIPv6thing", "sourceIPv6thing")]
        [TestCase("Ipsec", "ipsec")]
        [TestCase("sourceIpsec", "sourceIpsec")]
        [TestCase("Ipv4address", "ipv4address")]
        [TestCase("sourceIpv4address", "sourceIpv4address")]
        [TestCase("Database", "database")]
        [TestCase("sourceDatabase", "sourceDatabase")]
        [TestCase("Ostrich", "ostrich")]
        [TestCase("sourceOstrich", "sourceOstrich")]
        public void NewPathParametersUseCamelCase(string wireName, string expectedName)
        {
            VerifyPathParameters(wireName, null, false, expectedName);
        }

        [TestCase("IPv4AddressName")]
        [TestCase("iPv4AddressName")]
        [TestCase("iPv6AddressName")]
        [TestCase("exactIPName")]
        public void ExactPathParameterNamesArePreserved(string exactName)
        {
            VerifyPathParameters("wireIPv4Name", exactName, true, exactName);
        }

        [Test]
        public void ClientNamesAreIndependentOfSerializedPlaceholders()
        {
            VerifyPathParameters("wireIPv4Name", "IPv6AddressName", false, "ipv6AddressName");
        }

        private static void VerifyPathParameters(string wireName, string? inputName, bool isExactName, string expectedName)
        {
            var (parentClient, childClient, models) = InputResourceData.ClientWithNestedChildResource(wireName, inputName, isExactName);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [parentClient, childClient]);
            var providers = plugin.Object.OutputLibrary.TypeProviders;
            var resource = providers.OfType<ResourceClientProvider>().Single(p => p.Name == "ChildTypeResource");
            var identifier = resource.Methods.Single(m => m.Signature.Name == "CreateResourceIdentifier");
            var identifierParameter = identifier.Signature.Parameters.Single(p => p.WireInfo.SerializedName == wireName);
            Assert.That(identifierParameter.Name, Is.EqualTo(expectedName));
            Assert.That(identifier.BodyStatements!.ToDisplayString(), Does.Contain($"{{{expectedName}}}"));
            var renderedIdentifier = new TypeProviderWriter(new TestTypeProvider(
                name: resource.Name, ns: resource.Type.Namespace, methods: [identifier])).Write().Content;
            Assert.That(renderedIdentifier, Does.Contain($"string {expectedName}"));

            var collection = providers.OfType<ResourceCollectionClientProvider>().Single(p => p.Name == "ChildTypeCollection");
            var parameter = collection.PathParameters.Single();
            Assert.That(parameter.Name, Is.EqualTo(expectedName));
            Assert.That(parameter.WireInfo.SerializedName, Is.EqualTo(wireName));
            Assert.That(parameter.Description!.ToString(), Does.Contain(expectedName));
            Assert.That(parameter.Field!.Name, Is.EqualTo($"_{expectedName}"));
            var constructor = collection.Constructors.Single(c => c.Signature.Parameters.Count > 0);
            Assert.That(constructor.BodyStatements!.ToDisplayString(), Does.Contain($"_{expectedName} = {expectedName}"));
            var renderedCollection = new TypeProviderWriter(collection).Write().Content;
            Assert.That(renderedCollection, Does.Contain($"string {expectedName}"));
            Assert.That(renderedCollection, Does.Contain($"_{expectedName} = {expectedName};"));

            var parent = providers.OfType<ResourceClientProvider>().Single(p => p.Name == "ParentTypeResource");
            var accessor = parent.Methods.Single(m => m.Signature.Name == "GetChildTypes");
            Assert.That(accessor.Signature.Parameters.Single().Name, Is.EqualTo(expectedName));
            Assert.That(accessor.BodyStatements!.ToDisplayString(), Does.Contain(expectedName));
            Assert.That(accessor.Signature.Parameters.Single().Description!.ToString(), Does.Contain(expectedName));
            Assert.That(accessor.Signature.Parameters.Single().Validation, Is.EqualTo(ParameterValidationType.None));
            foreach (var methodName in new[] { "GetChildType", "GetChildTypeAsync" })
            {
                var forwardingMethod = parent.Methods.Single(m => m.Signature.Name == methodName);
                Assert.That(forwardingMethod.Signature.Parameters[0].Name, Is.EqualTo(expectedName));
                Assert.That(forwardingMethod.BodyStatements!.ToDisplayString(), Does.Contain($"GetChildTypes({expectedName})"));
            }

            var getAll = collection.Methods.Single(m => m.Signature.Name == "GetAll");
            Assert.That(getAll.BodyStatements!.ToDisplayString(), Does.Contain($"_{expectedName}"));
            Assert.That(childClient.Methods.First().Operation.Path, Does.Contain($"{{{wireName}}}"));
        }

        [TestCase(false, "iPv4Name", false)]
        [TestCase(true, "iPv4Name", false)]
        [TestCase(false, "iPv6Name", false)]
        [TestCase(true, "iPv6Name", false)]
        [TestCase(false, "customIPName", true)]
        [TestCase(true, "publishedOSName", true)]
        [TestCase(false, "IPv4Name", false)]
        [TestCase(true, "IPv6Name", false)]
        public void ExistingIdentifierAndAccessorNamesArePreserved(bool published, string existingName, bool exactInputName)
        {
            var expectedName = exactInputName ? "IPv4ExactName" : existingName;
            var (parentClient, childClient, models) = InputResourceData.ClientWithNestedChildResource("IPv4Name",
                clientParameterName: exactInputName ? "IPv4ExactName" : null, isExactName: exactInputName);
            var source = $$"""
                namespace Samples
                {
                    public partial class ChildTypeResource
                    {
                        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, int unrelatedParameter, string childName) => null;
                        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string {{existingName}}, string childName) => null;
                    }
                    public partial class ChildTypeCollection { }
                    public partial class ParentTypeResource
                    {
                        public virtual ChildTypeCollection GetChildTypes(int unrelatedParameter) => null;
                        public virtual ChildTypeCollection GetChildTypes(string {{existingName}}) => null;
                    }
                }
                """;
            var compilation = Helpers.BuildCompilation([("PathContract.cs", source)]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models,
                clients: () => [parentClient, childClient],
                customizationCompilation: published ? null : () => compilation,
                lastContractCompilation: published ? () => compilation : null);
            var providers = plugin.Object.OutputLibrary.TypeProviders;
            var resource = providers.OfType<ResourceClientProvider>().Single(p => p.Name == "ChildTypeResource");
            var identifier = (MethodProvider)typeof(ResourceClientProvider).GetMethod("BuildCreateResourceIdentifierMethod", BindingFlags.Instance | BindingFlags.NonPublic)!.Invoke(resource, null)!;
            Assert.That(identifier.Signature.Parameters[3].Name, Is.EqualTo(expectedName));
            Assert.That(identifier.Signature.Parameters[3].WireInfo.SerializedName, Is.EqualTo("IPv4Name"));
            Assert.That(identifier.BodyStatements!.ToDisplayString(), Does.Contain($"{{{expectedName}}}"));
            var renderedIdentifier = new TypeProviderWriter(new TestTypeProvider(
                name: resource.Name, ns: resource.Type.Namespace, methods: [identifier])).Write().Content;
            Assert.That(renderedIdentifier, Does.Contain($"string {expectedName}"));
            Assert.That(SynthesizedParameterNameHelper.GetExistingParameterName(resource, "CreateResourceIdentifier", identifier.Signature.Parameters, 3),
                Is.EqualTo(exactInputName ? null : existingName));
            var collection = providers.OfType<ResourceCollectionClientProvider>().Single(p => p.Name == "ChildTypeCollection");
            Assert.That(collection.PathParameters.Single().Name, Is.EqualTo(expectedName));
            Assert.That(collection.PathParameters.Single().WireInfo.SerializedName, Is.EqualTo("IPv4Name"));
            Assert.That(collection.PathParameters.Single().Field!.Name, Is.EqualTo($"_{expectedName}"));
            var renderedCollection = new TypeProviderWriter(collection).Write().Content;
            Assert.That(renderedCollection, Does.Contain($"string {expectedName}"));
            Assert.That(renderedCollection, Does.Contain($"_{expectedName} = {expectedName};"));
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void ExistingMockableAndExtensionAccessorNamesArePreserved(bool published, bool extension)
        {
            var (parentClient, childClient, models) = InputResourceData.ClientWithNestedChildResource("IPv6Name", childHasParent: false);
            var source = extension
                ? """
                  namespace Samples
                  {
                      public partial class ChildTypeCollection { }
                      public static partial class SamplesExtensions
                      {
                          public static ChildTypeCollection GetChildTypes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string parentName, string wrongReceiverName) => null;
                          public static ChildTypeCollection GetChildTypes(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentName, string iPv6Name) => null;
                      }
                  }
                  """
                : """
                  namespace Samples { public partial class ChildTypeCollection { } }
                  namespace Samples.Mocking
                  {
                      public partial class MockableSamplesResourceGroupResource
                      {
                          public virtual Samples.ChildTypeCollection GetChildTypes(string parentName, string iPv6Name) => null;
                      }
                  }
                  """;
            var compilation = Helpers.BuildCompilation([("AccessorContract.cs", source)]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models,
                clients: () => [parentClient, childClient],
                customizationCompilation: published ? null : () => compilation,
                lastContractCompilation: published ? () => compilation : null);
            var collection = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceCollectionClientProvider>().Single(p => p.Name == "ChildTypeCollection");
            var parameter = collection.PathParameters.Single(p => p.WireInfo.SerializedName == "IPv6Name");
            Assert.That(parameter.Name, Is.EqualTo("iPv6Name"));
            Assert.That(parameter.Field!.Name, Is.EqualTo("_iPv6Name"));
            Assert.That(collection.Methods.Single(m => m.Signature.Name == "GetAll").BodyStatements!.ToDisplayString(), Does.Contain("_iPv6Name"));
        }

        [TestCase("ref", false)]
        [TestCase("ref", true)]
        [TestCase("out", false)]
        [TestCase("out", true)]
        [TestCase("in", false)]
        [TestCase("in", true)]
        [TestCase("generic", false)]
        [TestCase("generic", true)]
        public void NonmatchingParameterPassingModesAndGenericContractsAreIgnored(string kind, bool published)
        {
            var (parentClient, childClient, models) = InputResourceData.ClientWithNestedChildResource("IPv4Name");
            var genericArguments = kind == "generic" ? "<T>" : "";
            var modifier = kind == "generic" ? "" : kind + " ";
            var source = $$"""
                namespace Samples
                {
                    public partial class ChildTypeResource
                    {
                        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier{{genericArguments}}(string subscriptionId, string resourceGroupName, string parentName, {{modifier}}string wrongName, string childName) => throw new System.NotImplementedException();
                    }
                    public partial class ChildTypeCollection { }
                    public partial class ParentTypeResource
                    {
                        public virtual ChildTypeCollection GetChildTypes{{genericArguments}}({{modifier}}string wrongName) => throw new System.NotImplementedException();
                    }
                }
                """;
            var compilation = Helpers.BuildCompilation([("NonmatchingContract.cs", source)]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models,
                clients: () => [parentClient, childClient],
                customizationCompilation: published ? null : () => compilation,
                lastContractCompilation: published ? () => compilation : null);
            var providers = plugin.Object.OutputLibrary.TypeProviders;
            var resource = providers.OfType<ResourceClientProvider>().Single(p => p.Name == "ChildTypeResource");
            var identifier = (MethodProvider)typeof(ResourceClientProvider).GetMethod("BuildCreateResourceIdentifierMethod", BindingFlags.Instance | BindingFlags.NonPublic)!.Invoke(resource, null)!;
            Assert.That(identifier.Signature.Parameters[3].Name, Is.EqualTo("ipv4Name"));
            var collection = providers.OfType<ResourceCollectionClientProvider>().Single(p => p.Name == "ChildTypeCollection");
            Assert.That(collection.PathParameters.Single().Name, Is.EqualTo("ipv4Name"));
        }
    }
}
