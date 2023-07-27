// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
#region Snippet:ImportCommonNamespace
using Azure.Maps;
#endregion
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Maps.Tests
{
    public class LocalizedMapViewTests
    {
        [Test]
        public void LocalizedMapViewTest()
        {
            // Exception case
            Assert.Throws<ArgumentNullException>(() => new LocalizedMapView(null));

            // Normal case
            #region Snippet:LocalizedMapViewUsage
            var unifiedView = new LocalizedMapView("Unified");
            var autoView = new LocalizedMapView("auto");
            var unitedArabEmirates = new LocalizedMapView("AE");
            #endregion
            Assert.AreEqual(LocalizedMapView.Unified, unifiedView);
            Assert.AreEqual(LocalizedMapView.Auto, autoView);
            Assert.AreEqual(LocalizedMapView.UnitedArabEmirates, unitedArabEmirates);
        }
    }
}
