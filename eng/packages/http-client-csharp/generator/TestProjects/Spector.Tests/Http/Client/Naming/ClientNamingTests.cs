// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Client.Naming;
using Client.Naming._UnionEnum;
using Client.Naming.Model;
using Client.Naming.Property;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Client.Naming
{
    public class ClientNamingTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Client_Naming_Property_client() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).ClientAsync(new ClientNameModel(true));
            Assert.Multiple(() =>
            {
                Assert.That(response.Status, Is.EqualTo(204));

                Assert.That(typeof(ClientNameModel).GetProperty("ClientName"), Is.Not.Null);
                Assert.That(typeof(ClientNameModel).GetProperty("DefaultName"), Is.Null);
            });
        });

        [SpectorTest]
        public Task Client_Naming_Property_language() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).LanguageAsync(new LanguageClientNameModel(true));
            Assert.Multiple(() =>
            {
                Assert.That(response.Status, Is.EqualTo(204));

                Assert.That(typeof(LanguageClientNameModel).GetProperty("CSName"), Is.Not.Null);
                Assert.That(typeof(LanguageClientNameModel).GetProperty("DefaultName"), Is.Null);
            });
        });

        [SpectorTest]
        public Task Client_Naming_Property_compatibleWithEncodedName() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).CompatibleWithEncodedNameAsync(new ClientNameAndJsonEncodedNameModel(true));
            Assert.Multiple(() =>
            {
                Assert.That(response.Status, Is.EqualTo(204));

                Assert.That(typeof(ClientNameModel).GetProperty("ClientName"), Is.Not.Null);
                Assert.That(typeof(ClientNameModel).GetProperty("DefaultName"), Is.Null);
            });
        });

        [SpectorTest]
        public Task Client_Naming_operation() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).ClientNameAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Client_Naming_parameter() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).ParameterAsync(clientName: "true");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Client_Naming_Header_request() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).RequestAsync(clientName: "true");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Client_Naming_Header_response() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).ResponseAsync();
            Assert.That(response.Headers.Contains("default-name"), Is.True);
            foreach (var header in response.Headers)
            {
                var key = header.Name;
                if (key == "default-name")
                {
                    var value = header.Value;
                    Assert.That(value, Is.EqualTo("true"));
                }
            }
        });

        [SpectorTest]
        public Task Client_Naming_Model_client() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).GetModelClient().ClientAsync(new ClientModel(true));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Client_Naming_Model_language() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).GetModelClient().LanguageAsync(new CSModel(true));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Client_Naming_UnionEnum_unionEnumName() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).GetUnionEnumClient().UnionEnumNameAsync(ClientExtensibleEnum.EnumValue1);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Client_Naming_UnionEnum_unionEnumMemberName() => Test(async (host) =>
        {
            var response = await new NamingClient(host, null).GetUnionEnumClient().UnionEnumMemberNameAsync(ExtensibleEnum.ClientEnumValue1);
            Assert.That(response.Status, Is.EqualTo(204));
        });
    }
}