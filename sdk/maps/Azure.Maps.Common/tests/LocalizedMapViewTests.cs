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
            var view = new LocalizedMapView("Unified");
            var autoView = new LocalizedMapView("auto");
            #endregion
            Assert.AreEqual(LocalizedMapView.Unified, view);
            Assert.AreEqual(LocalizedMapView.Auto, autoView);
        }
    }
}
