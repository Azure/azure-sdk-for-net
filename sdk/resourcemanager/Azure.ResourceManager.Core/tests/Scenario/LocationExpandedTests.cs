using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class LocationExpandedTests : ResourceManagerTestBase
    {
        public LocationExpandedTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        [TestCase(true, "West Us", "West Us")]
        [TestCase(true, "West Us", "WestUs")]
        [TestCase(true, "!#()@(#@", "!#()@(#@")]
        [TestCase(true, "W3$t U$", "W3$t U$")]
        [TestCase(true, "1234567890", "1234567890")]
        //[TestCase(false, "West Us", "WestUs2")]
        //[TestCase(false, "West Us", "")]
        //[TestCase(false, "West Us", "!#()@(#@")]
        //[TestCase(false, "West Us", "W3$t U$")]
        //[TestCase(false, "West Us", null)]
        public async Task VerifyMetadata(bool expected, string left, string right)
        {
            var rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testRg-"));
            //var listLocs = await rg.Value.ListAvailableLocationsAsync();
            ////foreach (LocationData loc in listLocs)
            ////{
            ////    Assert.IsNotNull(loc.Metadata);
            ////}
            //Location loc1 = left;
            //Location loc2 = right;
            //Assert.IsNotNull(loc1.Metadata);
            //Assert.IsNotNull(loc2.Metadata);

            //if (expected)
            //{
            //    Assert.AreEqual(0, loc1.Metadata.GeographyGroup.CompareTo(loc2.Metadata.GeographyGroup));
            //    Assert.AreEqual(0, loc1.Metadata.Latitude.CompareTo(loc2.Metadata.Latitude));
            //    Assert.AreEqual(0, loc1.Metadata.Longitude.CompareTo(loc2.Metadata.Longitude));
            //    Assert.AreEqual(0, loc1.Metadata.PhysicalLocation.CompareTo(loc2.Metadata.PhysicalLocation));
            //    Assert.AreEqual(loc1.Metadata.RegionCategory, loc2.Metadata.RegionCategory);
            //    Assert.AreEqual(loc1.Metadata.RegionType, loc2.Metadata.RegionType);
            //    Assert.AreEqual(loc1.Metadata.PairedRegion.Count, loc2.Metadata.PairedRegion.Count);
            //}
            //else
            //{
            //    Assert.AreNotEqual(0, loc1.Metadata.GeographyGroup.CompareTo(loc2.Metadata.GeographyGroup));
            //    Assert.AreNotEqual(0, loc1.Metadata.Latitude.CompareTo(loc2.Metadata.Latitude));
            //    Assert.AreNotEqual(0, loc1.Metadata.Longitude.CompareTo(loc2.Metadata.Longitude));
            //    Assert.AreNotEqual(0, loc1.Metadata.PhysicalLocation.CompareTo(loc2.Metadata.PhysicalLocation));
            //    Assert.AreNotEqual(loc1.Metadata.RegionCategory, loc2.Metadata.RegionCategory);
            //    Assert.AreNotEqual(loc1.Metadata.RegionType, loc2.Metadata.RegionType);
            //    Assert.AreNotEqual(loc1.Metadata.PairedRegion.Count, loc2.Metadata.PairedRegion.Count);
            //}
        }
    }
}
