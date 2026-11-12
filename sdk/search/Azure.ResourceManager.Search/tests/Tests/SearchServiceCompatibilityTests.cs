// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Search.Models;
using NUnit.Framework;

#pragma warning disable CS0618 // Intentionally exercise legacy properties for backward compatibility.

namespace Azure.ResourceManager.Search.Tests.Tests
{
    [TestFixture]
    [Category("Unit")]
    [Property("Owner", "Azure.ResourceManager.Search")]
    public class SearchServiceCompatibilityTests
    {
        [TestCase(typeof(SearchServiceData))]
        [TestCase(typeof(SearchServicePatch))]
        public void Status_ShouldWarnAndPointToServiceStatus_WhenMarkedObsolete(Type modelType)
        {
            ObsoleteAttribute obsolete = modelType.GetProperty("Status").GetCustomAttribute<ObsoleteAttribute>();

            Assert.IsNotNull(obsolete);
            Assert.IsFalse(obsolete.IsError);
            Assert.AreEqual("Use ServiceStatus instead. Status returns null for stopped services and other statuses that SearchServiceStatus cannot represent.", obsolete.Message);
            Assert.IsNull(modelType.GetProperty("ServiceStatus").GetCustomAttribute<ObsoleteAttribute>());
            Assert.IsNull(typeof(SearchServiceStatus).GetCustomAttribute<ObsoleteAttribute>());
        }

        [TestCase("running", SearchServiceStatus.Running, 0)]
        [TestCase("provisioning", SearchServiceStatus.Provisioning, 1)]
        [TestCase("deleting", SearchServiceStatus.Deleting, 2)]
        [TestCase("degraded", SearchServiceStatus.Degraded, 3)]
        [TestCase("disabled", SearchServiceStatus.Disabled, 4)]
        [TestCase("error", SearchServiceStatus.Error, 5)]
        [TestCase("RUNNING", SearchServiceStatus.Running, 0)]
        public void Status_ShouldPreserveLegacyValues_WhenStatusIsKnown(string wireValue, SearchServiceStatus expected, int numericValue)
        {
            BinaryData json = BinaryData.FromString($$$"""{"location":"eastus","properties":{"status":"{{{wireValue}}}"}}""");
            SearchServiceData data = ModelReaderWriter.Read<SearchServiceData>(json);
            SearchServicePatch patch = ModelReaderWriter.Read<SearchServicePatch>(json);

            Assert.AreEqual(numericValue, (int)expected);
            Assert.AreEqual(expected, data.Status);
            Assert.AreEqual(expected, patch.Status);
            Assert.AreEqual(new SearchServiceState(wireValue), data.ServiceStatus);
            Assert.AreEqual(new SearchServiceState(wireValue), patch.ServiceStatus);
            Assert.AreEqual(wireValue.ToLowerInvariant(), ((SearchServiceState)expected).ToString());
        }

        [TestCase("stopped")]
        [TestCase("STOPPED")]
        [TestCase("futureStatus")]
        public void Status_ShouldReturnNullAndPreserveWireValue_WhenLegacyEnumCannotRepresentStatus(string wireValue)
        {
            BinaryData json = BinaryData.FromString($$$"""{"location":"eastus","properties":{"status":"{{{wireValue}}}"}}""");
            SearchServiceData data = ModelReaderWriter.Read<SearchServiceData>(json);
            SearchServicePatch patch = ModelReaderWriter.Read<SearchServicePatch>(json);

            Assert.IsNull(data.Status);
            Assert.IsNull(patch.Status);
            Assert.AreEqual(wireValue, data.ServiceStatus?.ToString());
            Assert.AreEqual(wireValue, patch.ServiceStatus?.ToString());
            if (string.Equals(wireValue, "stopped", StringComparison.OrdinalIgnoreCase))
            {
                Assert.AreEqual(SearchServiceState.Stopped, data.ServiceStatus);
                Assert.AreEqual(SearchServiceState.Stopped, patch.ServiceStatus);
            }

            SearchServiceData dataRoundTrip = ModelReaderWriter.Read<SearchServiceData>(ModelReaderWriter.Write(data));
            SearchServicePatch patchRoundTrip = ModelReaderWriter.Read<SearchServicePatch>(ModelReaderWriter.Write(patch));
            Assert.AreEqual(wireValue, dataRoundTrip.ServiceStatus?.ToString());
            Assert.AreEqual(wireValue, patchRoundTrip.ServiceStatus?.ToString());
            Assert.IsNull(dataRoundTrip.Status);
            Assert.IsNull(patchRoundTrip.Status);

            using JsonDocument dataWireJson = JsonDocument.Parse(ModelReaderWriter.Write(data, new ModelReaderWriterOptions("W")));
            using JsonDocument patchWireJson = JsonDocument.Parse(ModelReaderWriter.Write(patch, new ModelReaderWriterOptions("W")));
            Assert.IsFalse(dataWireJson.RootElement.GetProperty("properties").TryGetProperty("status", out _));
            Assert.IsFalse(patchWireJson.RootElement.GetProperty("properties").TryGetProperty("status", out _));
        }

        [TestCase("""{"location":"eastus"}""")]
        [TestCase("""{"location":"eastus","properties":{}}""")]
        [TestCase("""{"location":"eastus","properties":{"status":null}}""")]
        public void Status_ShouldRemainNull_WhenStatusIsAbsent(string json)
        {
            SearchServiceData data = ModelReaderWriter.Read<SearchServiceData>(BinaryData.FromString(json));
            SearchServicePatch patch = ModelReaderWriter.Read<SearchServicePatch>(BinaryData.FromString(json));

            Assert.IsNull(data.Status);
            Assert.IsNull(patch.Status);
            Assert.IsNull(data.ServiceStatus);
            Assert.IsNull(patch.ServiceStatus);
        }

        [TestCase("free", SearchSkuName.Free)]
        [TestCase("basic", SearchSkuName.Basic)]
        [TestCase("standard", SearchSkuName.Standard)]
        [TestCase("standard2", SearchSkuName.Standard2)]
        [TestCase("standard3", SearchSkuName.Standard3)]
        [TestCase("storage_optimized_l1", SearchSkuName.StorageOptimizedL1)]
        [TestCase("storage_optimized_l2", SearchSkuName.StorageOptimizedL2)]
        [TestCase("STANDARD", SearchSkuName.Standard)]
        public void SkuName_ShouldPreserveLegacyMapping_WhenSkuIsKnown(string wireValue, SearchSkuName expected)
        {
            BinaryData json = BinaryData.FromString($$$"""{"location":"eastus","sku":{"name":"{{{wireValue}}}"}}""");
            SearchServiceData data = ModelReaderWriter.Read<SearchServiceData>(json);
            SearchServicePatch patch = ModelReaderWriter.Read<SearchServicePatch>(json);

            Assert.AreEqual(expected, data.SkuName);
            Assert.AreEqual(expected, patch.SkuName);

            data.SkuName = expected;
            patch.SkuName = expected;
            Assert.AreEqual(new SearchServiceSkuName(wireValue), data.SearchSkuName);
            Assert.AreEqual(new SearchServiceSkuName(wireValue), patch.SearchSkuName);

            data.SkuName = null;
            patch.SkuName = null;
            Assert.IsNull(data.SkuName);
            Assert.IsNull(patch.SkuName);
            Assert.IsNull(data.SearchSkuName);
            Assert.IsNull(patch.SearchSkuName);
        }

        [TestCase("serverless")]
        [TestCase("SERVERLESS")]
        [TestCase("futureSku")]
        public void SkuName_ShouldReturnNull_WhenLegacyEnumCannotRepresentSku(string wireValue)
        {
            BinaryData json = BinaryData.FromString($$$"""{"location":"eastus","sku":{"name":"{{{wireValue}}}"}}""");
            SearchServiceData data = ModelReaderWriter.Read<SearchServiceData>(json);
            SearchServicePatch patch = ModelReaderWriter.Read<SearchServicePatch>(json);

            Assert.IsNull(data.SkuName);
            Assert.IsNull(patch.SkuName);
            Assert.AreEqual(wireValue, data.SearchSkuName?.ToString());
            Assert.AreEqual(wireValue, patch.SearchSkuName?.ToString());
            Assert.AreEqual(new SearchServiceSkuName(wireValue), ModelReaderWriter.Read<SearchServiceData>(ModelReaderWriter.Write(data)).SearchSkuName);
            Assert.AreEqual(new SearchServiceSkuName(wireValue), ModelReaderWriter.Read<SearchServicePatch>(ModelReaderWriter.Write(patch)).SearchSkuName);
        }

        [Test]
        public void SkuName_ShouldRemainNull_WhenSkuIsAbsent()
        {
            var data = new SearchServiceData(AzureLocation.EastUS);
            var patch = new SearchServicePatch(AzureLocation.EastUS);

            Assert.IsNull(data.SkuName);
            Assert.IsNull(patch.SkuName);
            data.SearchSkuName = default(SearchServiceSkuName);
            patch.SearchSkuName = default(SearchServiceSkuName);
            Assert.IsNull(data.SkuName);
            Assert.IsNull(patch.SkuName);
        }

        [Test]
        public void SkuName_ShouldRejectInvalidValues_WhenUsedAsInputs()
        {
            var data = new SearchServiceData(AzureLocation.EastUS);
            var patch = new SearchServicePatch(AzureLocation.EastUS);

            Assert.Throws<ArgumentOutOfRangeException>(() => data.SkuName = (SearchSkuName)int.MaxValue);
            Assert.Throws<ArgumentOutOfRangeException>(() => patch.SkuName = (SearchSkuName)int.MaxValue);
        }

        [TestCase(-1)]
        [TestCase(42)]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        public void SearchServiceState_ShouldPreserveUndefinedValues_WhenConvertingLegacyStatus(int value)
        {
            SearchServiceStatus legacyStatus = (SearchServiceStatus)value;
            SearchServiceState state = legacyStatus;
            SearchServiceStatus? nullableLegacyStatus = legacyStatus;
            SearchServiceState? nullableState = nullableLegacyStatus;
            SearchServiceData data = ArmSearchModelFactory.SearchServiceData(status: legacyStatus);
            SearchServicePatch patch = ArmSearchModelFactory.SearchServicePatch(status: nullableLegacyStatus);

            Assert.AreEqual(legacyStatus.ToString(), state.ToString());
            Assert.AreEqual(state, nullableState);
            Assert.AreEqual(state, data.ServiceStatus);
            Assert.AreEqual(state, patch.ServiceStatus);
            Assert.IsNull(data.Status);
            Assert.IsNull(patch.Status);
        }

        [TestCase(SearchServiceStatus.Running)]
        [TestCase(SearchServiceStatus.Provisioning)]
        [TestCase(SearchServiceStatus.Deleting)]
        [TestCase(SearchServiceStatus.Degraded)]
        [TestCase(SearchServiceStatus.Disabled)]
        [TestCase(SearchServiceStatus.Error)]
        [TestCase(null)]
        public void ModelFactory_ShouldPreserveStatus_WhenUsingLegacyOverloads(SearchServiceStatus? status)
        {
            MethodInfo[] factories = typeof(ArmSearchModelFactory).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(method => method.GetParameters().Any(parameter => parameter.ParameterType == typeof(SearchServiceStatus?)))
                .ToArray();
            Assert.AreEqual(6, factories.Length);

            foreach (MethodInfo factory in factories)
            {
                object[] arguments = factory.GetParameters()
                    .Select(parameter => parameter.ParameterType == typeof(SearchServiceStatus?)
                        ? (object)status
                        : parameter.ParameterType.IsValueType ? Activator.CreateInstance(parameter.ParameterType) : null)
                    .ToArray();
                object model = factory.Invoke(null, arguments);
                Assert.AreEqual(status, model.GetType().GetProperty("Status").GetValue(model), factory.ToString());
                Assert.AreEqual((SearchServiceState?)status, model.GetType().GetProperty("ServiceStatus").GetValue(model), factory.ToString());
            }
        }

        [Test]
        public void ModelFactory_ShouldSupportLegacyAndExtensibleStatuses_WhenUsingNamedArguments()
        {
            Assert.AreEqual(SearchServiceStatus.Running, ArmSearchModelFactory.SearchServiceData(status: SearchServiceStatus.Running).Status);
            Assert.AreEqual(SearchServiceStatus.Running, ArmSearchModelFactory.SearchServicePatch(status: SearchServiceStatus.Running).Status);
            SearchServiceStatus? legacyStatus = SearchServiceStatus.Disabled;
            Assert.AreEqual(SearchServiceState.Disabled, ArmSearchModelFactory.SearchServiceData(status: legacyStatus).ServiceStatus);
            Assert.AreEqual(SearchServiceState.Disabled, ArmSearchModelFactory.SearchServicePatch(status: legacyStatus).ServiceStatus);
            Assert.AreEqual(SearchServiceState.Stopped, ArmSearchModelFactory.SearchServiceData(status: SearchServiceState.Stopped).ServiceStatus);
            Assert.AreEqual(SearchServiceState.Stopped, ArmSearchModelFactory.SearchServicePatch(status: SearchServiceState.Stopped).ServiceStatus);
            Assert.IsNull(ArmSearchModelFactory.SearchServiceData().ServiceStatus);
            Assert.IsNull(ArmSearchModelFactory.SearchServicePatch().ServiceStatus);
            Assert.AreEqual(6, Enum.GetValues(typeof(SearchServiceStatus)).Length);
        }

        [Test]
        public void SearchServiceState_ShouldPreserveNull_WhenConvertingNullableValues()
        {
            string wireValue = null;
            SearchServiceStatus? legacyStatus = null;
            SearchServiceState? fromString = wireValue;
            SearchServiceState? fromLegacy = legacyStatus;

            Assert.IsNull(fromString);
            Assert.IsNull(fromLegacy);
            Assert.IsNull(ArmSearchModelFactory.SearchServiceData(status: fromString).ServiceStatus);
            Assert.IsNull(ArmSearchModelFactory.SearchServicePatch(status: fromLegacy).ServiceStatus);
        }
    }
}

#pragma warning restore CS0618
