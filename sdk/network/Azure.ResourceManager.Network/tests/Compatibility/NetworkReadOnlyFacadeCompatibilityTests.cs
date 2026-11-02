// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    [NUnit.Framework.Category("Compatibility")]
    public class NetworkReadOnlyFacadeCompatibilityTests
    {
        [TestCase(typeof(ConnectionMonitorData), "Endpoints", typeof(ConnectionMonitorEndpoint), "endpoints", """[{"name":"endpoint"}]""")]
        [TestCase(typeof(ConnectionMonitorData), "Outputs", typeof(ConnectionMonitorOutput), "outputs", """[{"type":"Workspace"}]""")]
        [TestCase(typeof(ConnectionMonitorData), "TestConfigurations", typeof(ConnectionMonitorTestConfiguration), "testConfigurations", """[{"name":"configuration","protocol":"Tcp"}]""")]
        [TestCase(typeof(ConnectionMonitorData), "TestGroups", typeof(ConnectionMonitorTestGroup), "testGroups", """[{"name":"group"}]""")]
        [TestCase(typeof(ActiveSecurityAdminRule), "Sources", typeof(AddressPrefixItem), "sources", """[{"addressPrefix":"10.0.0.0/24","addressPrefixType":"IPPrefix"}]""")]
        [TestCase(typeof(ActiveSecurityAdminRule), "Destinations", typeof(AddressPrefixItem), "destinations", """[{"addressPrefix":"10.1.0.0/24","addressPrefixType":"IPPrefix"}]""")]
        [TestCase(typeof(ActiveSecurityAdminRule), "SourcePortRanges", typeof(string), "sourcePortRanges", """["443"]""")]
        [TestCase(typeof(ActiveSecurityAdminRule), "DestinationPortRanges", typeof(string), "destinationPortRanges", """["80"]""")]
        public void ReleasedReadOnlyFacadeSharesNativeStorage(Type modelType, string name, Type elementType, string wireName, string values)
        {
            typeof(NetworkReadOnlyFacadeCompatibilityTests)
                .GetMethod(nameof(CheckFacade), BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(modelType, elementType)
                .Invoke(null, new object[] { name, wireName, values });
        }

        [Test]
        public void Tls13AliasRetainsExplicitMetadataAndWireValue()
        {
#pragma warning disable CS0618
            Assert.That(ApplicationGatewaySslProtocol.TLSv13, Is.EqualTo(ApplicationGatewaySslProtocol.Tls1_3));
            Assert.That(ApplicationGatewaySslProtocol.TLSv13.ToString(), Is.EqualTo("TLSv1_3"));
            PropertyInfo alias = typeof(ApplicationGatewaySslProtocol).GetProperty(nameof(ApplicationGatewaySslProtocol.TLSv13));
#pragma warning restore CS0618
            Assert.That(alias.GetCustomAttribute<ObsoleteAttribute>().Message,
                Is.EqualTo("This property is deprecated and it will be removed in a future version. Please use Tls1_3 instead."));
            Assert.That(alias.GetCustomAttribute<ObsoleteAttribute>().IsError, Is.False);
            Assert.That(alias.GetCustomAttribute<EditorBrowsableAttribute>().State, Is.EqualTo(EditorBrowsableState.Never));
            Assert.That(typeof(ApplicationGatewaySslProtocol).GetProperties().Count(p => p.Name == alias.Name), Is.EqualTo(1));
        }

        private static void CheckFacade<TModel, TElement>(string name, string wireName, string values)
        {
            PropertyInfo facade = typeof(TModel).GetProperty(name);
            Assert.That(facade.PropertyType, Is.EqualTo(typeof(IReadOnlyList<TElement>)));
            Assert.That(facade.SetMethod, Is.Null);
            Assert.That(facade.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(facade.GetCustomAttributesData()
                .Single(a => a.AttributeType.Name == "WirePathAttribute").ConstructorArguments[0].Value,
                Is.EqualTo("properties." + wireName));

            PropertyInfo properties = typeof(TModel).GetProperty("Properties", BindingFlags.NonPublic | BindingFlags.Instance);
            TModel empty = (TModel)Activator.CreateInstance(typeof(TModel), nonPublic: true);
            Assert.That(properties.GetValue(empty), Is.Null);
            Assert.That(facade.GetValue(empty), Is.Null);
            Assert.That(properties.GetValue(empty), Is.Null);

            string requiredProperties = typeof(TModel) == typeof(ActiveSecurityAdminRule)
                ? "\"protocol\":\"Tcp\",\"access\":\"Allow\",\"priority\":100,\"direction\":\"Inbound\","
                : string.Empty;
            string payload = "{\"kind\":\"Custom\",\"properties\":{" + requiredProperties + "\"" + wireName + "\":" + values + "}}";
            TModel model = ModelReaderWriter.Read<TModel>(BinaryData.FromString(payload), ModelReaderWriterOptions.Json);
            var view = (IReadOnlyList<TElement>)facade.GetValue(model);
            Assert.That(view, Has.Count.EqualTo(1));

            BinaryData serialized = ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json);
            using JsonDocument json = JsonDocument.Parse(serialized);
            Assert.That(json.RootElement.GetProperty("properties").EnumerateObject().Count(p => p.Name == wireName), Is.EqualTo(1));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty(wireName).GetArrayLength(), Is.EqualTo(1));
            TModel roundTrip = ModelReaderWriter.Read<TModel>(serialized, ModelReaderWriterOptions.Json);
            Assert.That((IReadOnlyList<TElement>)facade.GetValue(roundTrip), Has.Count.EqualTo(1));

            object nativeProperties = properties.GetValue(model);
            var backing = (IList<TElement>)nativeProperties.GetType()
                .GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(nativeProperties);
            Assert.That(((ICollection<TElement>)view).IsReadOnly, Is.True);
            Assert.Throws<NotSupportedException>(() => ((ICollection<TElement>)view).Add(default));
            backing.Add(default);
            Assert.That(view, Has.Count.EqualTo(2));
            backing.Clear();
            Assert.That(view, Is.Empty);
        }
    }
}
