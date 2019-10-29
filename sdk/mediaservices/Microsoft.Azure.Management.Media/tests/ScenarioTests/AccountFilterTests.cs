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
    public class AccountFilterTests : MediaScenarioTestBase
    {
        private static readonly long HNSTimescale = 10000000;
        private static readonly int FirstQualityBitRate = 10000;

        [Fact]
        public void AccountFilterComboTest()
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

                    // Get AccountFilter, which should not exist
                    AccountFilter accountFilter = MediaClient.AccountFilters.Get(ResourceGroup, AccountName, filterName);
                    Assert.Null(accountFilter);

                    // List AccountFilters, which should be empty
                    var accountFilters = MediaClient.AccountFilters.List(ResourceGroup, AccountName);
                    Assert.Empty(accountFilters);

                    // Create an AccountFilter
                    var ptr = new PresentationTimeRange(0, 600 * HNSTimescale, 120 * HNSTimescale, 0, HNSTimescale, false);
                    AccountFilter input = new AccountFilter(presentationTimeRange: ptr);
                    AccountFilter createdAccountFilter = MediaClient.AccountFilters.CreateOrUpdate(ResourceGroup, AccountName, filterName, input);
                    ValidateAccountFilter(createdAccountFilter, expectedFirstQuality: null, expectedName: filterName, expectedPresentationTimeRange: ptr, expectedTracks: null);

                    // List asset filters and validate the created filter shows up
                    accountFilters = MediaClient.AccountFilters.List(ResourceGroup, AccountName);
                    Assert.Single(accountFilters);
                    ValidateAccountFilter(accountFilters.First(), expectedFirstQuality: null, expectedName: filterName, expectedPresentationTimeRange: ptr, expectedTracks: null);

                    // Get the newly created asset
                    accountFilter = MediaClient.AccountFilters.Get(ResourceGroup, AccountName, filterName);
                    Assert.NotNull(accountFilter);
                    ValidateAccountFilter(accountFilter, expectedFirstQuality: null, expectedName: filterName, expectedPresentationTimeRange: ptr, expectedTracks: null);

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
                    AccountFilter input2 = new AccountFilter(presentationTimeRange: ptr, firstQuality: firstQuality, tracks: tracks);
                    AccountFilter updatedAccountFilter = MediaClient.AccountFilters.CreateOrUpdate(ResourceGroup, AccountName, filterName, input2);
                    ValidateAccountFilter(updatedAccountFilter, expectedFirstQuality: firstQuality, expectedName: filterName, expectedPresentationTimeRange: ptr, expectedTracks: tracks);

                    // List asset filters and validate the updated asset filter shows up as expected
                    accountFilters = MediaClient.AccountFilters.List(ResourceGroup, AccountName);
                    Assert.Single(accountFilters);
                    ValidateAccountFilter(accountFilters.First(), expectedFirstQuality: firstQuality, expectedName: filterName, expectedPresentationTimeRange: ptr, expectedTracks: tracks);

                    // Get the newly updated asset filter
                    accountFilter = MediaClient.AccountFilters.Get(ResourceGroup, AccountName, filterName);
                    Assert.NotNull(accountFilter);
                    ValidateAccountFilter(accountFilter, expectedFirstQuality: firstQuality, expectedName: filterName, expectedPresentationTimeRange: ptr, expectedTracks: tracks);

                    // Delete the asset filter
                    MediaClient.AccountFilters.Delete(ResourceGroup, AccountName, filterName);

                    // List asset filters, which should be empty again
                    accountFilters = MediaClient.AccountFilters.List(ResourceGroup, AccountName);
                    Assert.Empty(accountFilters);

                    // Get the asset filter, which should not exist
                    accountFilter = MediaClient.AccountFilters.Get(ResourceGroup, AccountName, filterName);
                    Assert.Null(accountFilter);

                    // Delete the asset
                    MediaClient.Assets.Delete(ResourceGroup, AccountName, assetName);
                }
                finally
                {
                    DeleteMediaServicesAccount();
                }
            }
        }

        internal static void ValidateAccountFilter(AccountFilter accountFilter, FirstQuality expectedFirstQuality, string expectedName, PresentationTimeRange expectedPresentationTimeRange, IList<FilterTrackSelection> expectedTracks)
        {
            Assert.Equal(expectedFirstQuality?.Bitrate, accountFilter.FirstQuality?.Bitrate);

            Assert.Equal(expectedName, accountFilter.Name);

            if (expectedPresentationTimeRange != null)
            {
                Assert.Equal(expectedPresentationTimeRange.StartTimestamp, accountFilter.PresentationTimeRange.StartTimestamp);
                Assert.Equal(expectedPresentationTimeRange.EndTimestamp, accountFilter.PresentationTimeRange.EndTimestamp);
                Assert.Equal(expectedPresentationTimeRange.PresentationWindowDuration, accountFilter.PresentationTimeRange.PresentationWindowDuration);
                Assert.Equal(expectedPresentationTimeRange.LiveBackoffDuration, accountFilter.PresentationTimeRange.LiveBackoffDuration);
                Assert.Equal(expectedPresentationTimeRange.Timescale, accountFilter.PresentationTimeRange.Timescale);
                Assert.Equal(expectedPresentationTimeRange.ForceEndTimestamp, accountFilter.PresentationTimeRange.ForceEndTimestamp);
            }
            else
            {
                Assert.Null(accountFilter.PresentationTimeRange);
            }

            if (expectedTracks != null)
            {
                // A filter can include multiple track definitions
                Assert.Equal(expectedTracks.Count, accountFilter.Tracks.Count);

                for (int x = 0; x < expectedTracks.Count; x++)
                {
                    // For each track included in the filter, there can be multiple selection criteria.  The criteria have an AND relationship
                    Assert.Equal(expectedTracks[x].TrackSelections.Count, accountFilter.Tracks[x].TrackSelections.Count);

                    for (int y = 0; y < expectedTracks[x].TrackSelections.Count; y++)
                    {
                        Assert.Equal(expectedTracks[x].TrackSelections[y].Property, accountFilter.Tracks[x].TrackSelections[y].Property);
                        Assert.Equal(expectedTracks[x].TrackSelections[y].Operation, accountFilter.Tracks[x].TrackSelections[y].Operation);
                        Assert.Equal(expectedTracks[x].TrackSelections[y].Value, accountFilter.Tracks[x].TrackSelections[y].Value);
                    }
                }
            }
            else
            {
                Assert.True(accountFilter.Tracks == null || accountFilter.Tracks.Count == 0);
            }
        }
    }
}

