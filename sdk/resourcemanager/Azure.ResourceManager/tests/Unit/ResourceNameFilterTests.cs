// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class ResourceNameFilterTests
    {
        //[TestCase("filter")]
        //[TestCase("")]
        //[TestCase(")(@#$)&!)(@")]
        //public void ImplicitCast(string filter)
        //{
        //    ResourceNameFilter nameFilter = filter;
        //    Assert.AreEqual(nameFilter.Name, filter);
        //}

        //[TestCase]
        //public void ImplicitCastNull()
        //{
        //    string filter = null;
        //    ResourceNameFilter nameFilter = filter;
        //    Assert.IsNull(nameFilter);
        //}

        //[TestCase(true, "foo", "foo")]
        //[TestCase(false, "foo", "")]
        //[TestCase(false, "foo", null)]
        //[TestCase(true, ")(@#$)&!)(@", ")(@#$)&!)(@")]
        //[TestCase(true, "", "")]
        //[TestCase(false, "foo", "bar")]
        //public void EqualsWithString(bool expected, string left, string right)
        //{
        //    ResourceNameFilter leftFilter = left;
        //    Assert.AreEqual(expected, leftFilter.Equals(right));
        //}

        //[TestCase(true, "foo", "foo")]
        //[TestCase(false, "foo", "")]
        //[TestCase(false, "foo", null)]
        //[TestCase(true, ")(@#$)&!)(@", ")(@#$)&!)(@")]
        //[TestCase(true, "", "")]
        //[TestCase(false, "foo", "bar")]
        //public void EqualsWithResourceNameFilter(bool expected, string left, string right)
        //{
        //    ResourceNameFilter leftFilter = left;
        //    ResourceNameFilter rightFilter = right;
        //    Assert.AreEqual(expected, leftFilter.Equals(rightFilter));
        //}

        //[TestCase("substringof('filter', name)", "filter")]
        //[TestCase("", "")]
        //[TestCase("substringof(')(@#$)&!)(@', name)", ")(@#$)&!)(@")]
        //public void GetFilterString(string expected, string filter)
        //{
        //    ResourceNameFilter nameFilter = filter;
        //    Assert.AreEqual(expected, nameFilter.GetFilterString());
        //}
    }
}
