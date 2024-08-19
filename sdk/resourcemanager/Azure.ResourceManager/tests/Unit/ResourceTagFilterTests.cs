// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class ResourceTagFilterTests
    {
        //[TestCase]
        //public void ConstructNullTuple()
        //{
        //    Assert.Throws<ArgumentNullException>(() => new ResourceTagFilter(null));
        //}

        //[TestCase]
        //public void ConstructNullTupleKey()
        //{
        //    string key = null;
        //    Assert.Throws<ArgumentNullException>(() => new ResourceTagFilter(Tuple.Create(key, "")));
        //}

        //[TestCase]
        //public void ConstructNullTupleValue()
        //{
        //    string value = null;
        //    Assert.Throws<ArgumentNullException>(() => new ResourceTagFilter(Tuple.Create("", value)));
        //}

        //[TestCase]
        //public void ConstructNullKey()
        //{
        //    Assert.Throws<ArgumentNullException>(() => new ResourceTagFilter(null, ""));
        //}

        //[TestCase]
        //public void ConstructNullValue()
        //{
        //    Assert.Throws<ArgumentNullException>(() => new ResourceTagFilter("", null));
        //}

        //[TestCase(true, "key", "value", "key", "value")]
        //[TestCase(false, "key", "value", "key1", "value")]
        //[TestCase(false, "key", "value", "key", "value1")]
        //[TestCase(false, "key1", "value", "key", "value")]
        //[TestCase(false, "key", "value1", "key", "value")]
        //[TestCase(false, "key", "value", "key1", "value1")]
        //[TestCase(false, "key", "value", "", "value")]
        //[TestCase(false, "key", "value", "key", "")]
        //public void Equals(bool expected, string leftKey, string leftValue, string rightKey, string rightValue)
        //{
        //    ResourceTagFilter leftFilter = new ResourceTagFilter(leftKey, leftValue);
        //    ResourceTagFilter rightFilter = new ResourceTagFilter(rightKey, rightValue);
        //    Assert.AreEqual(expected, leftFilter.Equals(rightFilter));
        //}

        //[TestCase("tagName eq 'key' and tagValue eq 'value'", "key", "value")]
        //[TestCase("tagName eq ')(@#$)&!)(@' and tagValue eq ')#$)(USkjao'", ")(@#$)&!)(@", ")#$)(USkjao")]
        //public void GetFilterString(string expected, string key, string value)
        //{
        //    ResourceTagFilter tagFilter = new ResourceTagFilter(key, value);
        //    Assert.AreEqual(expected, tagFilter.GetFilterString());
        //}
    }
}
