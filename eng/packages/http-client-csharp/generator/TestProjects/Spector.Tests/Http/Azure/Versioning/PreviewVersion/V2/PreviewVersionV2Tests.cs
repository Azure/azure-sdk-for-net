// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias PreviewVersionV2;

using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using PreviewVersionV2::Specs.Azure.Versioning.PreviewVersion;

namespace TestProjects.Spector.Tests.Http.Azure.Versioning.PreviewVersion.V2
{
    public class PreviewVersionV2Tests : SpectorTestBase
    {
        [SpectorTest]
        public void TestPreviewVersionMembersV2()
        {
            /* verify Widget has all properties including color (added in preview). */
            var properties = typeof(Widget).GetProperties();
            Assert.IsNotNull(properties);
            Assert.AreEqual(3, properties.Length);
            Assert.IsNotNull(typeof(Widget).GetProperty("Id"));
            Assert.IsNotNull(typeof(Widget).GetProperty("Name"));
            Assert.IsNotNull(typeof(Widget).GetProperty("Color"));

            /* verify PreviewVersionClient has all methods. */
            var methods = typeof(PreviewVersionClient).GetMethods();

            /* check getWidget method exists. */
            var getWidgetMethods = methods.Where(m => m.Name == "GetWidget" || m.Name == "GetWidgetAsync");
            Assert.AreEqual(4, getWidgetMethods.Count());

            /* check updateWidgetColor method exists (preview only operation). */
            var updateColorMethods = methods.Where(m => m.Name == "UpdateWidgetColor" || m.Name == "UpdateWidgetColorAsync");
            Assert.AreEqual(2, updateColorMethods.Count());

            /* check getWidgets/listWidgets method exists. */
            var getWidgetsMethods = methods.Where(m => m.Name == "GetWidgets" || m.Name == "GetWidgetsAsync");
            Assert.AreEqual(4, getWidgetsMethods.Count());

            /* verify ServiceVersion enum has all versions. */
            var serviceVersionEnum = typeof(PreviewVersionClientOptions.ServiceVersion);
            Assert.IsTrue(serviceVersionEnum.IsEnum);
            var enumNames = serviceVersionEnum.GetEnumNames();
            Assert.AreEqual(3, enumNames.Length);
            Assert.IsTrue(enumNames.Contains("V2024_01_01"));
            Assert.IsTrue(enumNames.Contains("V2024_06_01"));
            Assert.IsTrue(enumNames.Contains("V2024_12_01_Preview"));
        }

        [SpectorTest]
        public Task Azure_Versioning_PreviewVersion_getWidget() => Test(async (host) =>
        {
            var response = await new PreviewVersionClient(host, new PreviewVersionClientOptions(PreviewVersionClientOptions.ServiceVersion.V2024_12_01_Preview)).GetWidgetAsync("widget-123");
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("widget-123", response.Value.Id);
            Assert.AreEqual("Sample Widget", response.Value.Name);
            Assert.AreEqual("blue", response.Value.Color);
        });

        [SpectorTest]
        public Task Azure_Versioning_PreviewVersion_updateWidgetColor() => Test(async (host) =>
        {
            var content = global::Azure.Core.RequestContent.Create(new { color = "red" });
            var response = await new PreviewVersionClient(host, new PreviewVersionClientOptions(PreviewVersionClientOptions.ServiceVersion.V2024_12_01_Preview)).UpdateWidgetColorAsync("widget-123", content);
            Assert.AreEqual(200, response.Status);
        });

        [SpectorTest]
        public Task Azure_Versioning_PreviewVersion_listWidgets() => Test(async (host) =>
        {
            var response = await new PreviewVersionClient(host, new PreviewVersionClientOptions(PreviewVersionClientOptions.ServiceVersion.V2024_06_01)).GetWidgetsAsync(name: "test");
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Widgets.Count);
            Assert.AreEqual("widget-1", response.Value.Widgets[0].Id);
            Assert.AreEqual("test", response.Value.Widgets[0].Name);
        });
    }
}
