// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Media.Tests.ScenarioTests
{
    public class AssetFilterTests : MediaScenarioTestBase
    {
        private static readonly long HNSTimescale = 10000000;
        private static readonly int FirstQualityBitRate = 10000;

        [Fact]
        public void AssetFilterComboTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType()))
            {
                try
                {
                    CreateMediaServicesAccount();

                    string assetName = TestUtilities.GenerateName("asset");
                    string assetDescription = "A test asset";

                    string filterName = TestUtilities.GenerateName("assetfilter");

                    // Create an asset
                    Asset inputForAsset = new Asset(description: assetDescription);
                    Asset createdAsset = MediaClient.Assets.CreateOrUpdate(ResourceGroup, AccountName, assetName, inputForAsset);

                    // Get AssetFilter, which should not exist
                    AssetFilter assetFilter = MediaClient.AssetFilters.Get(ResourceGroup, AccountName, assetName, filterName);
                    Assert.Null(assetFilter);

                    // List AssetFilters, which should be empty
                    var assetFilters = MediaClient.AssetFilters.List(ResourceGroup, AccountName, assetName);
                    Assert.Empty(assetFilters);

                    // Create an AssetFilter
                    var ptr = new PresentationTimeRange(0, 600 * HNSTimescale, 120 * HNSTimescale, 0, HNSTimescale, false);
                    AssetFilter input = new AssetFilter(presentationTimeRange: ptr);
                    AssetFilter createdAssetFilter = MediaClient.AssetFilters.CreateOrUpdate(ResourceGroup, AccountName, assetName, filterName, input);
                    ValidateAssetFilter(createdAssetFilter, expectedFirstQuality: null, expectedName: filterName, expectedPresentationTimeRange: ptr, expectedTracks: null);

                    // List asset filters and validate the created filter shows up
                    assetFilters = MediaClient.AssetFilters.List(ResourceGroup, AccountName, assetName);
                    Assert.Single(assetFilters);
                    ValidateAssetFilter(assetFilters.First(), expectedFirstQuality: null, expectedName: filterName, expectedPresentationTimeRange: ptr, expectedTracks: null);

                    // Get the newly created asset
                    assetFilter = MediaClient.AssetFilters.Get(ResourceGroup, AccountName, assetName, filterName);
                    Assert.NotNull(assetFilter);
                    ValidateAssetFilter(assetFilter, expectedFirstQuality: null, expectedName: filterName, expectedPresentationTimeRange: ptr, expectedTracks: null);

                    // Update the asset filter
                    List<FilterTrackPropertyCondition> audioConditions = new List<FilterTrackPropertyCondition>()
                    {
                        new FilterTrackPropertyCondition(FilterTrackPropertyType.Type, "audio", FilterTrackPropertyCompareOperation.Equal),
                        new FilterTrackPropertyCondition(FilterTrackPropertyType.FourCC, "ec-3", FilterTrackPropertyCompareOperation.Equal),
                    };
                    List<FilterTrackPropertyCondition> videoConditions = new List<FilterTrackPropertyCondition>()
                    {
                        new FilterTrackPropertyCondition(FilterTrackPropertyType.Type, "video", FilterTrackPropertyCompareOperation.Equal),
                        new FilterTrackPropertyCondition(FilterTrackPropertyType.FourCC, "avc1", FilterTrackPropertyCompareOperation.Equal),
                    };
                    List<FilterTrackSelection> tracks = new List<FilterTrackSelection>()
                    {
                        new FilterTrackSelection(audioConditions),
                        new FilterTrackSelection(videoConditions)
                    };
                    FirstQuality firstQuality = new FirstQuality(FirstQualityBitRate);
                    AssetFilter input2 = new AssetFilter(presentationTimeRange: ptr, firstQuality: firstQuality, tracks: tracks);
                    AssetFilter updatedAssetFilter = MediaClient.AssetFilters.CreateOrUpdate(ResourceGroup, AccountName, assetName, filterName, input2);
                    ValidateAssetFilter(updatedAssetFilter, expectedFirstQuality: firstQuality, expectedName: filterName, expectedPresentationTimeRange: ptr, expectedTracks: tracks);

                    // List asset filters and validate the updated asset filter shows up as expected
                    assetFilters = MediaClient.AssetFilters.List(ResourceGroup, AccountName, assetName);
                    Assert.Single(assetFilters);
                    ValidateAssetFilter(assetFilters.First(), expectedFirstQuality: firstQuality, expectedName: filterName, expectedPresentationTimeRange: ptr, expectedTracks: tracks);

                    // Get the newly updated asset filter
                    assetFilter = MediaClient.AssetFilters.Get(ResourceGroup, AccountName, assetName, filterName);
                    Assert.NotNull(assetFilter);
                    ValidateAssetFilter(assetFilter, expectedFirstQuality: firstQuality, expectedName: filterName, expectedPresentationTimeRange: ptr, expectedTracks: tracks);

                    // Delete the asset filter
                    MediaClient.AssetFilters.Delete(ResourceGroup, AccountName, assetName, filterName);

                    // List asset filters, which should be empty again
                    assetFilters = MediaClient.AssetFilters.List(ResourceGroup, AccountName, assetName);
                    Assert.Empty(assetFilters);

                    // Get the asset filter, which should not exist
                    assetFilter = MediaClient.AssetFilters.Get(ResourceGroup, AccountName, assetName, filterName);
                    Assert.Null(assetFilter);

                    // Delete the asset
                    MediaClient.Assets.Delete(ResourceGroup, AccountName, assetName);
                }
                finally
                {
                    DeleteMediaServicesAccount();
                }
            }
        }

        [Fact]
        public void AssetFilterOptionalPropertiesTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType()))
            {
                try
                {
                    CreateMediaServicesAccount();

                    string assetName = TestUtilities.GenerateName("assetoptionalfilter");
                    string assetDescription = "A test asset";

                    string filterName = TestUtilities.GenerateName("assetoptionalfilter");

                    // Create an asset
                    Asset inputForAsset = new Asset(description: assetDescription);
                    Asset createdAsset = MediaClient.Assets.CreateOrUpdate(ResourceGroup, AccountName, assetName, inputForAsset);

                    // Get AssetFilter, which should not exist
                    AssetFilter assetFilter = MediaClient.AssetFilters.Get(ResourceGroup, AccountName, assetName, filterName);
                    Assert.Null(assetFilter);

                    // List AssetFilters, which should be empty
                    var assetFilters = MediaClient.AssetFilters.List(ResourceGroup, AccountName, assetName);
                    Assert.Empty(assetFilters);

                    // Create an AssetFilter
                    // Some of the AssetFilter parameters are for Live. Create a filter for VOD that does not specify Live parameters
                    var ptr = new PresentationTimeRange(startTimestamp: 1, endTimestamp: 600 * HNSTimescale);
                    AssetFilter input = new AssetFilter(presentationTimeRange: ptr);
                    AssetFilter createdAssetFilter = MediaClient.AssetFilters.CreateOrUpdate(ResourceGroup, AccountName, assetName, filterName, input);
                    ValidateAssetFilter(createdAssetFilter, expectedFirstQuality: null, expectedName: filterName, expectedPresentationTimeRange: ptr, expectedTracks: null);

                    // List asset filters and validate the created filter shows up
                    assetFilters = MediaClient.AssetFilters.List(ResourceGroup, AccountName, assetName);
                    Assert.Single(assetFilters);
                    ValidateAssetFilter(assetFilters.First(), expectedFirstQuality: null, expectedName: filterName, expectedPresentationTimeRange: ptr, expectedTracks: null);

                    // Get the newly created asset
                    assetFilter = MediaClient.AssetFilters.Get(ResourceGroup, AccountName, assetName, filterName);
                    Assert.NotNull(assetFilter);
                    ValidateAssetFilter(assetFilter, expectedFirstQuality: null, expectedName: filterName, expectedPresentationTimeRange: ptr, expectedTracks: null);

                    // Delete the asset filter
                    MediaClient.AssetFilters.Delete(ResourceGroup, AccountName, assetName, filterName);

                    // List asset filters, which should be empty again
                    assetFilters = MediaClient.AssetFilters.List(ResourceGroup, AccountName, assetName);
                    Assert.Empty(assetFilters);

                    // Get the asset filter, which should not exist
                    assetFilter = MediaClient.AssetFilters.Get(ResourceGroup, AccountName, assetName, filterName);
                    Assert.Null(assetFilter);

                    // Delete the asset
                    MediaClient.Assets.Delete(ResourceGroup, AccountName, assetName);
                }
                finally
                {
                    DeleteMediaServicesAccount();
                }
            }
        }

        internal static void ValidateAssetFilter(AssetFilter assetFilter, FirstQuality expectedFirstQuality, string expectedName, PresentationTimeRange expectedPresentationTimeRange, IList<FilterTrackSelection> expectedTracks)
        {
            Assert.Equal(expectedFirstQuality?.Bitrate, assetFilter.FirstQuality?.Bitrate);

            Assert.Equal(expectedName, assetFilter.Name);

            if (expectedPresentationTimeRange != null)
            {
                Assert.Equal(expectedPresentationTimeRange.StartTimestamp, assetFilter.PresentationTimeRange.StartTimestamp);
                Assert.Equal(expectedPresentationTimeRange.EndTimestamp, assetFilter.PresentationTimeRange.EndTimestamp);
                Assert.Equal(expectedPresentationTimeRange.PresentationWindowDuration, assetFilter.PresentationTimeRange.PresentationWindowDuration);
                Assert.Equal(expectedPresentationTimeRange.LiveBackoffDuration, assetFilter.PresentationTimeRange.LiveBackoffDuration);
                Assert.Equal(expectedPresentationTimeRange.Timescale?? HNSTimescale, assetFilter.PresentationTimeRange.Timescale);
                Assert.Equal(expectedPresentationTimeRange.ForceEndTimestamp, assetFilter.PresentationTimeRange.ForceEndTimestamp);
            }
            else
            {
                Assert.Null(assetFilter.PresentationTimeRange);
            }

            if (expectedTracks != null)
            {
                // A filter can include multiple track definitions
                Assert.Equal(expectedTracks.Count, assetFilter.Tracks.Count);

                for (int x = 0; x < expectedTracks.Count; x++)
                {
                    // For each track included in the filter, there can be multiple selection criteria.  The criteria have an AND relationship
                    Assert.Equal(expectedTracks[x].TrackSelections.Count, assetFilter.Tracks[x].TrackSelections.Count);

                    for (int y = 0; y < expectedTracks[x].TrackSelections.Count; y++)
                    {
                        Assert.Equal(expectedTracks[x].TrackSelections[y].Property, assetFilter.Tracks[x].TrackSelections[y].Property);
                        Assert.Equal(expectedTracks[x].TrackSelections[y].Operation, assetFilter.Tracks[x].TrackSelections[y].Operation);
                        Assert.Equal(expectedTracks[x].TrackSelections[y].Value, assetFilter.Tracks[x].TrackSelections[y].Value);
                    }
                }
            }
            else
            {
                Assert.True(assetFilter.Tracks == null || assetFilter.Tracks.Count == 0);
            }
        }
    }
}

