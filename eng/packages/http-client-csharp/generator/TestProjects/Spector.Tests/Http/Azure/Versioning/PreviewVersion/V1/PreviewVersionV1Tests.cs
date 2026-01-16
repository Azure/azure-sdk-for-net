// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias PreviewVersionV1;

using System.Linq;
using NUnit.Framework;
using PreviewVersionV1::Specs.Azure.Versioning.PreviewVersion;

namespace TestProjects.Spector.Tests.Http.Azure.Versioning.PreviewVersion.V1
{
    public class PreviewVersionV1Tests : SpectorTestBase
    {
        [SpectorTest]
        public void TestPreviewVersionMembersV1()
        {
            /* verify Widget has all properties including color (added in preview). */
            var properties = typeof(Widget).GetProperties();
            Assert.That(properties, Is.Not.Null);
            Assert.That(properties.Length, Is.EqualTo(3));
            Assert.That(typeof(Widget).GetProperty("Id"), Is.Not.Null);
            Assert.That(typeof(Widget).GetProperty("Name"), Is.Not.Null);
            Assert.That(typeof(Widget).GetProperty("Color"), Is.Not.Null);

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
            Assert.That(enumNames.Length, Is.EqualTo(3));
            Assert.That(enumNames.Contains("V2024_01_01"), Is.True);
            Assert.That(enumNames.Contains("V2024_06_01"), Is.True);
            Assert.That(enumNames.Contains("V2024_12_01_Preview"), Is.True);
        }
    }
}
