// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventDataExtensions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventDataExtensionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventDataExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsDifferentBodies()
        {
            var firstEvent = new EventData(new byte[] { 0x22, 0x44 });
            var secondEvent = new EventData(new byte[] { 0x11, 0x33 });

            Assert.That(firstEvent.IsEquivalentTo(secondEvent), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventDataExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsDifferentProperties()
        {
            var body = new byte[] { 0x22, 0x44, 0x88 };
            var firstEvent = new EventData((byte[])body.Clone());
            var secondEvent = new EventData((byte[])body.Clone());

            firstEvent.Properties["test"] = "trackOne";
            secondEvent.Properties["test"] = "trackTwo";

            Assert.That(firstEvent.IsEquivalentTo(secondEvent), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventDataExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsWhenOnePropertySetIsNull()
        {
            var body = new byte[] { 0x22, 0x44, 0x88 };
            var firstEvent = new EventData((byte[])body.Clone());
            var secondEvent = new EventData((byte[])body.Clone());

            firstEvent.Properties = null;
            secondEvent.Properties["test"] = "trackTwo";

            Assert.That(firstEvent.IsEquivalentTo(secondEvent), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventDataExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToIgnoresSystemPropertiesByDefault()
        {
            var body = new byte[] { 0x22, 0x44, 0x88 };
            var firstEvent = new EventData((byte[])body.Clone());
            var secondEvent = new EventData((byte[])body.Clone());

            firstEvent.SystemProperties = new EventData.SystemEventProperties();
            firstEvent.SystemProperties["something"] = "trackOne";

            secondEvent.SystemProperties = new EventData.SystemEventProperties();
            secondEvent.SystemProperties["something"] = "trackTwo";

            Assert.That(firstEvent.IsEquivalentTo(secondEvent), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventDataExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsDifferentSystemProperties()
        {
            var body = new byte[] { 0x22, 0x44, 0x88 };
            var firstEvent = new EventData((byte[])body.Clone());
            var secondEvent = new EventData((byte[])body.Clone());

            firstEvent.SystemProperties = new EventData.SystemEventProperties();
            firstEvent.SystemProperties["something"] = "trackOne";

            secondEvent.SystemProperties = new EventData.SystemEventProperties();
            secondEvent.SystemProperties["something"] = "trackTwo";

            Assert.That(firstEvent.IsEquivalentTo(secondEvent, true), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventDataExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsWhenOneSystemPropertySetIsNull()
        {
            var body = new byte[] { 0x22, 0x44, 0x88 };
            var firstEvent = new EventData((byte[])body.Clone());
            var secondEvent = new EventData((byte[])body.Clone());

            firstEvent.SystemProperties = new EventData.SystemEventProperties();
            firstEvent.SystemProperties["something"] = "trackOne";

            secondEvent.SystemProperties = null;

            Assert.That(firstEvent.IsEquivalentTo(secondEvent, true), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventDataExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsEqualEvents()
        {
            var body = new byte[] { 0x22, 0x44, 0x88 };
            var firstEvent = new EventData((byte[])body.Clone());
            var secondEvent = new EventData((byte[])body.Clone());

            firstEvent.Properties["test"] = "same";
            secondEvent.Properties["test"] = "same";

            firstEvent.SystemProperties = new EventData.SystemEventProperties();
            firstEvent.SystemProperties["something"] = "otherSame";

            secondEvent.SystemProperties = new EventData.SystemEventProperties();
            secondEvent.SystemProperties["something"] = "otherSame";

            Assert.That(firstEvent.IsEquivalentTo(secondEvent), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventDataExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsSameInstance()
        {
            var firstEvent = new EventData(new byte[] { 0x22, 0x44, 0x88 });
            firstEvent.SystemProperties = new EventData.SystemEventProperties();
            firstEvent.SystemProperties["something"] = "otherSame";

            Assert.That(firstEvent.IsEquivalentTo(firstEvent), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventDataExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsTwoNulls()
        {
            Assert.That(((EventData)null).IsEquivalentTo(null), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventDataExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsNullInstance()
        {
            var firstEvent = new EventData(new byte[] { 0x22, 0x44, 0x88 });
            firstEvent.SystemProperties = new EventData.SystemEventProperties();
            firstEvent.SystemProperties["something"] = "otherSame";

            Assert.That(((EventData)null).IsEquivalentTo(firstEvent), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventDataExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsNullArgument()
        {
            var firstEvent = new EventData(new byte[] { 0x22, 0x44, 0x88 });
            firstEvent.SystemProperties = new EventData.SystemEventProperties();
            firstEvent.SystemProperties["something"] = "otherSame";

            Assert.That(firstEvent.IsEquivalentTo((EventData)null), Is.False);
        }
    }
}
