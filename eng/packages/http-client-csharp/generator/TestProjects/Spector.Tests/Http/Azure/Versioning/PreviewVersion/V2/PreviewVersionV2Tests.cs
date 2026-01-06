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
            Assert.That(properties, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(properties, Has.Length.EqualTo(3));
                Assert.That(typeof(Widget).GetProperty("Id"), Is.Not.Null);
                Assert.That(typeof(Widget).GetProperty("Name"), Is.Not.Null);
                Assert.That(typeof(Widget).GetProperty("Color"), Is.Not.Null);
            });

            /* verify PreviewVersionClient has all methods. */
            var methods = typeof(PreviewVersionClient).GetMethods();

            /* check getWidget method exists. */
            var getWidgetMethods = methods.Where(m => m.Name == "GetWidget" || m.Name == "GetWidgetAsync");
            Assert.That(getWidgetMethods.Count(), Is.EqualTo(4));

            /* check updateWidgetColor method exists (preview only operation). */
            var updateColorMethods = methods.Where(m => m.Name == "UpdateWidgetColor" || m.Name == "UpdateWidgetColorAsync");
            Assert.That(updateColorMethods.Count(), Is.EqualTo(2));

            /* check getWidgets/listWidgets method exists. */
            var getWidgetsMethods = methods.Where(m => m.Name == "GetWidgets" || m.Name == "GetWidgetsAsync");
            Assert.That(getWidgetsMethods.Count(), Is.EqualTo(4));

            /* verify ServiceVersion enum has all versions. */
            var serviceVersionEnum = typeof(PreviewVersionClientOptions.ServiceVersion);
            Assert.That(serviceVersionEnum.IsEnum, Is.True);
            var enumNames = serviceVersionEnum.GetEnumNames();
            Assert.That(enumNames, Has.Length.EqualTo(3));
            Assert.That(enumNames, Does.Contain("V2024_01_01"));
            Assert.That(enumNames, Does.Contain("V2024_06_01"));
            Assert.That(enumNames, Does.Contain("V2024_12_01_Preview"));
        }

        [SpectorTest]
        public Task Azure_Versioning_PreviewVersion_getWidget() => Test(async (host) =>
        {
            var response = await new PreviewVersionClient(host, new PreviewVersionClientOptions(PreviewVersionClientOptions.ServiceVersion.V2024_12_01_Preview)).GetWidgetAsync("widget-123");
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Id, Is.EqualTo("widget-123"));
                Assert.That(response.Value.Name, Is.EqualTo("Sample Widget"));
                Assert.That(response.Value.Color, Is.EqualTo("blue"));
            });
        });

        [SpectorTest]
        public Task Azure_Versioning_PreviewVersion_updateWidgetColor() => Test(async (host) =>
        {
            var content = global::Azure.Core.RequestContent.Create(new { color = "red" });
            var response = await new PreviewVersionClient(host, new PreviewVersionClientOptions(PreviewVersionClientOptions.ServiceVersion.V2024_12_01_Preview)).UpdateWidgetColorAsync("widget-123", content);
            Assert.That(response.Status, Is.EqualTo(200));
        });

        [SpectorTest]
        public Task Azure_Versioning_PreviewVersion_listWidgets() => Test(async (host) =>
        {
            var response = await new PreviewVersionClient(host, new PreviewVersionClientOptions(PreviewVersionClientOptions.ServiceVersion.V2024_06_01)).GetWidgetsAsync(name: "test");
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Widgets.Count, Is.EqualTo(1));
            });
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.Widgets[0].Id, Is.EqualTo("widget-1"));
                Assert.That(response.Value.Widgets[0].Name, Is.EqualTo("test"));
            });
        });
    }
}
