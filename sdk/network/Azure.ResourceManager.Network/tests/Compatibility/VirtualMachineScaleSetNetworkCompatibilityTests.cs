// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Mocking;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    [NUnit.Framework.Category("Compatibility")]
    public class VirtualMachineScaleSetNetworkCompatibilityTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
        private const string ScaleSetPath = "/subscriptions/" + SubscriptionId + "/resourceGroups/rg/providers/Microsoft.Compute/virtualMachineScaleSets/selectedScaleSet";
        private const string VmPath = ScaleSetPath + "/virtualMachines/37";
        private const string NicName = "selectedNic";
        private const string IpName = "selectedIp";
        private const string PublicIpName = "selectedPublicIp";

        [Test]
        public void FacadesRetainReleasedContracts()
        {
            AssertFacade(typeof(VirtualMachineScaleSetNetworkResource), "Microsoft.Compute/virtualMachineScaleSets");
            AssertFacade(typeof(VirtualMachineScaleSetVmNetworkResource), "Microsoft.Compute/virtualMachineScaleSets/virtualMachines");
            AssertPair<NetworkInterfaceData>(typeof(VirtualMachineScaleSetNetworkResource), "GetAllNetworkInterfaceData", true, 0, "cancellationToken");
            AssertPair<PublicIPAddressData>(typeof(VirtualMachineScaleSetNetworkResource), "GetAllPublicIPAddressData", true, 0, "cancellationToken");
            AssertPair<NetworkInterfaceData>(typeof(VirtualMachineScaleSetVmNetworkResource), "GetAllNetworkInterfaceData", true, 0, "cancellationToken");
            AssertPair<NetworkInterfaceData>(typeof(VirtualMachineScaleSetVmNetworkResource), "GetNetworkInterfaceData", false, 1, "networkInterfaceName", "expand", "cancellationToken");
            AssertPair<NetworkInterfaceIPConfigurationData>(typeof(VirtualMachineScaleSetVmNetworkResource), "GetAllIPConfigurationData", true, 1, "networkInterfaceName", "expand", "cancellationToken");
            AssertPair<NetworkInterfaceIPConfigurationData>(typeof(VirtualMachineScaleSetVmNetworkResource), "GetIPConfigurationData", false, 2, "networkInterfaceName", "ipConfigurationName", "expand", "cancellationToken");
            AssertPair<PublicIPAddressData>(typeof(VirtualMachineScaleSetVmNetworkResource), "GetAllPublicIPAddressData", true, 2, "networkInterfaceName", "ipConfigurationName", "cancellationToken");
            AssertPair<PublicIPAddressData>(typeof(VirtualMachineScaleSetVmNetworkResource), "GetPublicIPAddressData", false, 3, "networkInterfaceName", "ipConfigurationName", "publicIPAddressName", "expand", "cancellationToken");

            foreach (string name in new[] { "GetVirtualMachineScaleSetNetworkResource", "GetVirtualMachineScaleSetVmNetworkResource" })
            {
                MethodInfo mockable = typeof(MockableNetworkArmClient).GetMethod(name);
                Assert.That(mockable.IsVirtual, Is.True);
                Assert.That(mockable.GetParameters().Single().Name, Is.EqualTo("id"));
                Assert.That(mockable.GetParameters().Single().ParameterType, Is.EqualTo(typeof(ResourceIdentifier)));
                Assert.That(mockable.GetParameters().Single().IsOptional, Is.False);
                AssertCanonical(mockable);
                MethodInfo extension = typeof(NetworkExtensions).GetMethod(name);
                Assert.That(extension.GetParameters().Select(parameter => parameter.Name), Is.EqualTo(new[] { "client", "id" }));
                Assert.That(extension.ReturnType, Is.EqualTo(mockable.ReturnType));
                AssertCanonical(extension);
            }
        }

        [Test]
        public void GettersAreLocalAndUseRootCachedMockableClient()
        {
            var transport = new MockTransport();
            var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
            ResourceIdentifier scaleSetId = new ResourceIdentifier(ScaleSetPath);
            ResourceIdentifier vmId = new ResourceIdentifier(VmPath);

            Assert.That(client.GetVirtualMachineScaleSetNetworkResource(id: scaleSetId).Id, Is.EqualTo(scaleSetId));
            Assert.That(client.GetVirtualMachineScaleSetVmNetworkResource(id: vmId).Id, Is.EqualTo(vmId));
            var mockable = client.GetCachedClient<MockableNetworkArmClient>(_ => throw new InvalidOperationException("The extension must cache the mockable client."));
            Assert.That(mockable.Id, Is.EqualTo(ResourceIdentifier.Root));
            Assert.That(mockable.GetVirtualMachineScaleSetNetworkResource(id: scaleSetId).Id, Is.EqualTo(scaleSetId));
            Assert.That(mockable.GetVirtualMachineScaleSetVmNetworkResource(id: vmId).Id, Is.EqualTo(vmId));
#if DEBUG
            Assert.That(Assert.Throws<ArgumentException>(() => client.GetVirtualMachineScaleSetNetworkResource(vmId)).ParamName, Is.EqualTo("id"));
            Assert.That(Assert.Throws<ArgumentException>(() => client.GetVirtualMachineScaleSetVmNetworkResource(scaleSetId)).ParamName, Is.EqualTo("id"));
#endif
            Assert.That(Assert.Throws<ArgumentNullException>(() => NetworkExtensions.GetVirtualMachineScaleSetNetworkResource(null, scaleSetId)).ParamName, Is.EqualTo("client"));
            Assert.That(Assert.Throws<ArgumentNullException>(() => NetworkExtensions.GetVirtualMachineScaleSetVmNetworkResource(null, vmId)).ParamName, Is.EqualTo("client"));
            Assert.That(transport.Requests, Is.Empty);
        }

        [Test]
        public void ExtensionsDispatchToVirtualMockableGetters()
        {
            var client = new ArmClientProbe();
            var scaleSetId = new ResourceIdentifier(ScaleSetPath);
            var vmId = new ResourceIdentifier(VmPath);
            Assert.That(client.GetVirtualMachineScaleSetNetworkResource(scaleSetId), Is.SameAs(client.Probe.ScaleSet));
            Assert.That(client.Probe.LastId, Is.EqualTo(scaleSetId));
            Assert.That(client.GetVirtualMachineScaleSetVmNetworkResource(vmId), Is.SameAs(client.Probe.Vm));
            Assert.That(client.Probe.LastId, Is.EqualTo(vmId));
        }

        [Test]
        public async Task EveryHistoricalOperationUsesItsExactRoute([Range(0, 7)] int operation, [Values(false, true)] bool async)
        {
            string nicPath = VmPath + "/networkInterfaces/" + NicName;
            string path = operation switch
            {
                0 => ScaleSetPath + "/networkInterfaces",
                1 => ScaleSetPath + "/publicipaddresses",
                2 => VmPath + "/networkInterfaces",
                3 => nicPath,
                4 => nicPath.Replace("/Microsoft.Compute/", "/microsoft.Compute/") + "/ipConfigurations",
                5 => nicPath + "/ipConfigurations/" + IpName,
                6 => nicPath + "/ipconfigurations/" + IpName + "/publicipaddresses",
                _ => nicPath + "/ipconfigurations/" + IpName + "/publicipaddresses/" + PublicIpName
            };
            bool pageable = operation is 0 or 1 or 2 or 4 or 6;
            string nextLink = "https://management.azure.com" + path + "?api-version=2018-10-01&$skiptoken=next";
            string firstItem = $"{{\"id\":\"{(pageable ? path + "/first" : path)}\",\"name\":\"first\",\"properties\":{{}}}}";
            string secondItem = $"{{\"id\":\"{path}/second\",\"name\":\"second\",\"properties\":{{}}}}";
            MockResponse[] responses = pageable
                ? new[] { new MockResponse(200).SetContent($"{{\"value\":[{firstItem}],\"nextLink\":\"{nextLink}\"}}"), new MockResponse(200).SetContent($"{{\"value\":[{secondItem}]}}") }
                : new[] { new MockResponse(200).SetContent(firstItem) };
            var transport = new MockTransport(responses);
            var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
            var scaleSet = client.GetVirtualMachineScaleSetNetworkResource(new ResourceIdentifier(ScaleSetPath));
            var vm = client.GetVirtualMachineScaleSetVmNetworkResource(new ResourceIdentifier(VmPath));
            const string expand = "ipConfigurations/publicIPAddress";
            using var cancellation = new CancellationTokenSource();
            string[] names;

            switch (operation)
            {
                case 0:
                    names = async
                        ? await ReadAsync(scaleSet.GetAllNetworkInterfaceDataAsync(cancellation.Token), item => item.Name, responses)
                        : Read(scaleSet.GetAllNetworkInterfaceData(cancellation.Token), item => item.Name, responses);
                    break;
                case 1:
                    names = async
                        ? await ReadAsync(scaleSet.GetAllPublicIPAddressDataAsync(cancellation.Token), item => item.Name, responses)
                        : Read(scaleSet.GetAllPublicIPAddressData(cancellation.Token), item => item.Name, responses);
                    break;
                case 2:
                    names = async
                        ? await ReadAsync(vm.GetAllNetworkInterfaceDataAsync(cancellation.Token), item => item.Name, responses)
                        : Read(vm.GetAllNetworkInterfaceData(cancellation.Token), item => item.Name, responses);
                    break;
                case 3:
                    names = AssertSingle(async
                        ? await vm.GetNetworkInterfaceDataAsync(NicName, expand, cancellation.Token)
                        : vm.GetNetworkInterfaceData(NicName, expand, cancellation.Token), item => item.Name, responses[0]);
                    break;
                case 4:
                    names = async
                        ? await ReadAsync(vm.GetAllIPConfigurationDataAsync(NicName, expand, cancellation.Token), item => item.Name, responses)
                        : Read(vm.GetAllIPConfigurationData(NicName, expand, cancellation.Token), item => item.Name, responses);
                    break;
                case 5:
                    names = AssertSingle(async
                        ? await vm.GetIPConfigurationDataAsync(NicName, IpName, expand, cancellation.Token)
                        : vm.GetIPConfigurationData(NicName, IpName, expand, cancellation.Token), item => item.Name, responses[0]);
                    break;
                case 6:
                    names = async
                        ? await ReadAsync(vm.GetAllPublicIPAddressDataAsync(NicName, IpName, cancellation.Token), item => item.Name, responses)
                        : Read(vm.GetAllPublicIPAddressData(NicName, IpName, cancellation.Token), item => item.Name, responses);
                    break;
                default:
                    names = AssertSingle(async
                        ? await vm.GetPublicIPAddressDataAsync(NicName, IpName, PublicIpName, expand, cancellation.Token)
                        : vm.GetPublicIPAddressData(NicName, IpName, PublicIpName, expand, cancellation.Token), item => item.Name, responses[0]);
                    break;
            }

            Assert.That(names, Is.EqualTo(pageable ? new[] { "first", "second" } : new[] { "first" }));
            Assert.That(transport.Requests, Has.Count.EqualTo(responses.Length));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
        }

        [Test]
        public void ReleasedArgumentValidationIsPreserved([Values(false, true)] bool async)
        {
            var transport = new MockTransport();
            var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
            var vm = client.GetVirtualMachineScaleSetVmNetworkResource(new ResourceIdentifier(VmPath));
            if (async)
            {
                Assert.That(Assert.ThrowsAsync<ArgumentException>(async () => await vm.GetNetworkInterfaceDataAsync("")).ParamName, Is.EqualTo("networkInterfaceName"));
                Assert.That(Assert.ThrowsAsync<ArgumentException>(async () => await vm.GetIPConfigurationDataAsync(NicName, "")).ParamName, Is.EqualTo("ipConfigurationName"));
                Assert.That(Assert.ThrowsAsync<ArgumentException>(async () => await vm.GetPublicIPAddressDataAsync(NicName, IpName, "")).ParamName, Is.EqualTo("publicIPAddressName"));
                Assert.That(Assert.Throws<ArgumentException>(() => vm.GetAllPublicIPAddressDataAsync("", IpName)).ParamName, Is.EqualTo("networkInterfaceName"));
                Assert.That(Assert.Throws<ArgumentException>(() => vm.GetAllPublicIPAddressDataAsync(NicName, "")).ParamName, Is.EqualTo("ipConfigurationName"));
            }
            else
            {
                Assert.That(Assert.Throws<ArgumentException>(() => vm.GetNetworkInterfaceData("")).ParamName, Is.EqualTo("networkInterfaceName"));
                Assert.That(Assert.Throws<ArgumentException>(() => vm.GetIPConfigurationData(NicName, "")).ParamName, Is.EqualTo("ipConfigurationName"));
                Assert.That(Assert.Throws<ArgumentException>(() => vm.GetPublicIPAddressData(NicName, IpName, "")).ParamName, Is.EqualTo("publicIPAddressName"));
                Assert.That(Assert.Throws<ArgumentException>(() => vm.GetAllPublicIPAddressData("", IpName)).ParamName, Is.EqualTo("networkInterfaceName"));
                Assert.That(Assert.Throws<ArgumentException>(() => vm.GetAllPublicIPAddressData(NicName, "")).ParamName, Is.EqualTo("ipConfigurationName"));
            }
            Assert.That(transport.Requests, Is.Empty);
        }

        private static void AssertFacade(Type type, string resourceType)
        {
            Assert.That(type.BaseType, Is.EqualTo(typeof(ArmResource)));
            AssertCanonical(type);
            Assert.That(type.GetConstructors(), Is.Empty);
            Assert.That(type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null).IsFamily, Is.True);
            Assert.That(type.GetMethod("CreateResourceIdentifier", BindingFlags.Public | BindingFlags.Static), Is.Null);
            Assert.That(type.GetMethod("CreateResourceIdentifier", BindingFlags.NonPublic | BindingFlags.Static).IsAssembly, Is.True);
            FieldInfo field = type.GetField("ResourceType");
            Assert.That(field.IsInitOnly, Is.True);
            Assert.That(field.GetValue(null).ToString(), Is.EqualTo(resourceType));
        }

        private static void AssertPair<T>(Type type, string name, bool pageable, int required, params string[] names)
        {
            for (int async = 0; async < 2; async++)
            {
                MethodInfo method = type.GetMethod(name + (async == 1 ? "Async" : ""));
                Assert.That(method, Is.Not.Null);
                Assert.That(method.IsVirtual, Is.True);
                AssertCanonical(method);
                ParameterInfo[] parameters = method.GetParameters();
                Assert.That(parameters.Select(parameter => parameter.Name), Is.EqualTo(names));
                for (int i = 0; i < parameters.Length; i++)
                {
                    Assert.That(parameters[i].ParameterType, Is.EqualTo(i == parameters.Length - 1 ? typeof(CancellationToken) : typeof(string)));
                    Assert.That(parameters[i].IsOptional, Is.EqualTo(i >= required));
                    if (i >= required)
                    {
                        Assert.That(parameters[i].HasDefaultValue, Is.True);
                        Assert.That(parameters[i].DefaultValue, Is.Null);
                    }
                }
                Assert.That(method.ReturnType, Is.EqualTo(pageable
                    ? (async == 1 ? typeof(AsyncPageable<T>) : typeof(Pageable<T>))
                    : (async == 1 ? typeof(Task<Response<T>>) : typeof(Response<T>))));
            }
        }

        private static void AssertCanonical(MemberInfo member)
        {
            Assert.That(member.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(member.GetCustomAttribute<EditorBrowsableAttribute>(), Is.Null);
        }

        private static string[] Read<T>(Pageable<T> items, Func<T, string> name, MockResponse[] responses)
        {
            var names = new List<string>();
            int index = 0;
            foreach (Page<T> page in items.AsPages())
            {
                Assert.That(page.GetRawResponse(), Is.SameAs(responses[index++]));
                names.AddRange(page.Values.Select(name));
            }
            Assert.That(index, Is.EqualTo(responses.Length));
            return names.ToArray();
        }

        private static async Task<string[]> ReadAsync<T>(AsyncPageable<T> items, Func<T, string> name, MockResponse[] responses)
        {
            var names = new List<string>();
            int index = 0;
            await foreach (Page<T> page in items.AsPages())
            {
                Assert.That(page.GetRawResponse(), Is.SameAs(responses[index++]));
                names.AddRange(page.Values.Select(name));
            }
            Assert.That(index, Is.EqualTo(responses.Length));
            return names.ToArray();
        }

        private static string[] AssertSingle<T>(Response<T> response, Func<T, string> name, MockResponse raw)
        {
            Assert.That(response.GetRawResponse(), Is.SameAs(raw));
            return new[] { name(response.Value) };
        }

        private sealed class ArmClientProbe : ArmClient
        {
            internal readonly MockableProbe Probe = new MockableProbe();

            public override T GetCachedClient<T>(Func<ArmClient, T> clientFactory)
                => (T)(object)Probe;
        }

        private sealed class MockableProbe : MockableNetworkArmClient
        {
            internal readonly VirtualMachineScaleSetNetworkResource ScaleSet = new ScaleSetProbe();
            internal readonly VirtualMachineScaleSetVmNetworkResource Vm = new VmProbe();
            internal ResourceIdentifier LastId;

            public override VirtualMachineScaleSetNetworkResource GetVirtualMachineScaleSetNetworkResource(ResourceIdentifier id)
            {
                LastId = id;
                return ScaleSet;
            }

            public override VirtualMachineScaleSetVmNetworkResource GetVirtualMachineScaleSetVmNetworkResource(ResourceIdentifier id)
            {
                LastId = id;
                return Vm;
            }
        }

        private sealed class ScaleSetProbe : VirtualMachineScaleSetNetworkResource { }
        private sealed class VmProbe : VirtualMachineScaleSetVmNetworkResource { }
    }
}
