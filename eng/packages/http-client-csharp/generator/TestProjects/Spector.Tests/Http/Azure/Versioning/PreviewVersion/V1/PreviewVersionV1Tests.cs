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
    }
}
