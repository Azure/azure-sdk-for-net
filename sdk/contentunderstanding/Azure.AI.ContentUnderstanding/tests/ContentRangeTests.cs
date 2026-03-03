// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Unit tests for <see cref="ContentRange"/>.
    /// </summary>
    [TestFixture]
    public class ContentRangeTests
    {
        #region Constructor

        [Test]
        public void Constructor_WithValue_StoresValue()
        {
            var range = new ContentRange("1-3");
            Assert.AreEqual("1-3", range.ToString());
        }

        [Test]
        public void Constructor_NullValue_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ContentRange(null!));
        }

        #endregion

        #region Page Factory Methods

        [Test]
        public void Page_ValidPageNumber_ReturnsCorrectValue()
        {
            var range = ContentRange.Page(5);
            Assert.AreEqual("5", range.ToString());
        }

        [Test]
        public void Page_PageOne_ReturnsCorrectValue()
        {
            var range = ContentRange.Page(1);
            Assert.AreEqual("1", range.ToString());
        }

        [Test]
        public void Page_ZeroPageNumber_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ContentRange.Page(0));
        }

        [Test]
        public void Page_NegativePageNumber_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ContentRange.Page(-1));
        }

        [Test]
        public void Pages_ValidRange_ReturnsCorrectValue()
        {
            var range = ContentRange.Pages(1, 3);
            Assert.AreEqual("1-3", range.ToString());
        }

        [Test]
        public void Pages_SameStartAndEnd_ReturnsCorrectValue()
        {
            var range = ContentRange.Pages(5, 5);
            Assert.AreEqual("5-5", range.ToString());
        }

        [Test]
        public void Pages_ZeroStart_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ContentRange.Pages(0, 3));
        }

        [Test]
        public void Pages_EndBeforeStart_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ContentRange.Pages(5, 3));
        }

        [Test]
        public void PagesFrom_ValidStartPage_ReturnsCorrectValue()
        {
            var range = ContentRange.PagesFrom(9);
            Assert.AreEqual("9-", range.ToString());
        }

        [Test]
        public void PagesFrom_ZeroStartPage_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ContentRange.PagesFrom(0));
        }

        #endregion

        #region Time Factory Methods

        [Test]
        public void TimeRange_ValidRange_ReturnsCorrectValue()
        {
            var range = ContentRange.TimeRange(TimeSpan.Zero, TimeSpan.FromMilliseconds(5000));
            Assert.AreEqual("0-5000", range.ToString());
        }

        [Test]
        public void TimeRange_SameStartAndEnd_ReturnsCorrectValue()
        {
            var range = ContentRange.TimeRange(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(1000));
            Assert.AreEqual("1000-1000", range.ToString());
        }

        [Test]
        public void TimeRange_NegativeStart_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ContentRange.TimeRange(TimeSpan.FromMilliseconds(-1), TimeSpan.FromMilliseconds(5000)));
        }

        [Test]
        public void TimeRange_EndBeforeStart_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ContentRange.TimeRange(TimeSpan.FromMilliseconds(5000), TimeSpan.FromMilliseconds(1000)));
        }

        [Test]
        public void TimeRangeFrom_ValidStartTime_ReturnsCorrectValue()
        {
            var range = ContentRange.TimeRangeFrom(TimeSpan.FromMilliseconds(5000));
            Assert.AreEqual("5000-", range.ToString());
        }

        [Test]
        public void TimeRangeFrom_ZeroStartTime_ReturnsCorrectValue()
        {
            var range = ContentRange.TimeRangeFrom(TimeSpan.Zero);
            Assert.AreEqual("0-", range.ToString());
        }

        [Test]
        public void TimeRangeFrom_NegativeStartTime_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ContentRange.TimeRangeFrom(TimeSpan.FromMilliseconds(-1)));
        }

        #endregion

        #region Combine

        [Test]
        public void Combine_MultipleRanges_ReturnsCommaSeparatedValue()
        {
            var combined = ContentRange.Combine(
                ContentRange.Pages(1, 3),
                ContentRange.Page(5),
                ContentRange.PagesFrom(9));
            Assert.AreEqual("1-3,5,9-", combined.ToString());
        }

        [Test]
        public void Combine_SingleRange_ReturnsSameValue()
        {
            var combined = ContentRange.Combine(ContentRange.Page(1));
            Assert.AreEqual("1", combined.ToString());
        }

        [Test]
        public void Combine_NullArray_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ContentRange.Combine(null!));
        }

        [Test]
        public void Combine_EmptyArray_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ContentRange.Combine(Array.Empty<ContentRange>()));
        }

        #endregion

        #region Implicit Conversion (ContentRange -> string)

        [Test]
        public void ImplicitConversion_ContentRangeToString_Works()
        {
            ContentRange range = ContentRange.Pages(1, 3);
            string value = range;
            Assert.AreEqual("1-3", value);
        }

        #endregion

        #region AnalysisInput.ContentRange (ContentRange? property)

        [Test]
        public void AnalysisInput_ContentRange_AcceptsContentRange()
        {
            var input = new AnalysisInput();
            input.ContentRange = ContentRange.Pages(1, 3);
            Assert.AreEqual("1-3", input.ContentRange?.ToString());
        }

        [Test]
        public void AnalysisInput_ContentRange_NullByDefault()
        {
            var input = new AnalysisInput();
            Assert.IsNull(input.ContentRange);
        }

        [Test]
        public void AnalysisInput_ContentRange_RoundTripsContentRange()
        {
            var input = new AnalysisInput();
            var range = ContentRange.Combine(ContentRange.Pages(1, 3), ContentRange.Page(5));
            input.ContentRange = range;
            Assert.AreEqual(range, input.ContentRange);
        }

        #endregion

        #region Equality

        [Test]
        public void Equals_SameValue_ReturnsTrue()
        {
            var range1 = ContentRange.Pages(1, 3);
            var range2 = new ContentRange("1-3");
            Assert.IsTrue(range1.Equals(range2));
            Assert.IsTrue(range1 == range2);
            Assert.IsFalse(range1 != range2);
        }

        [Test]
        public void Equals_DifferentValue_ReturnsFalse()
        {
            var range1 = ContentRange.Pages(1, 3);
            var range2 = ContentRange.Pages(1, 5);
            Assert.IsFalse(range1.Equals(range2));
            Assert.IsFalse(range1 == range2);
            Assert.IsTrue(range1 != range2);
        }

        [Test]
        public void Equals_ObjectOfSameType_ReturnsTrue()
        {
            var range1 = ContentRange.Page(5);
            object range2 = ContentRange.Page(5);
            Assert.IsTrue(range1.Equals(range2));
        }

        [Test]
        public void Equals_ObjectOfDifferentType_ReturnsFalse()
        {
            var range = ContentRange.Page(5);
            Assert.IsFalse(range.Equals(5));
        }

        [Test]
        public void GetHashCode_SameValue_ReturnsSameHashCode()
        {
            var range1 = ContentRange.Pages(1, 3);
            var range2 = new ContentRange("1-3");
            Assert.AreEqual(range1.GetHashCode(), range2.GetHashCode());
        }

        #endregion

        #region TimeSpan Factory Methods

        [Test]
        public void TimeRange_WithTimeSpan_ReturnsCorrectValue()
        {
            var range = ContentRange.TimeRange(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(5));
            Assert.AreEqual("1000-5000", range.ToString());
        }

        [Test]
        public void TimeRangeFrom_WithTimeSpan_ReturnsCorrectValue()
        {
            var range = ContentRange.TimeRangeFrom(TimeSpan.FromSeconds(5));
            Assert.AreEqual("5000-", range.ToString());
        }

        [Test]
        public void TimeRange_NegativeStartTimeSpan_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => ContentRange.TimeRange(TimeSpan.FromMilliseconds(-1), TimeSpan.FromSeconds(5)));
        }

        [Test]
        public void TimeRange_EndBeforeStartTimeSpan_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => ContentRange.TimeRange(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(1)));
        }

        [Test]
        public void TimeRangeFrom_NegativeTimeSpan_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => ContentRange.TimeRangeFrom(TimeSpan.FromMilliseconds(-1)));
        }

        #endregion

        #region Raw String Constructor

        [Test]
        public void Constructor_RawString_WorksForCustomFormats()
        {
            // Users can construct from a raw string for formats not covered by factory methods
            var range = new ContentRange("1-3,5,9-");
            Assert.AreEqual("1-3,5,9-", range.ToString());
        }

        #endregion
    }
}
