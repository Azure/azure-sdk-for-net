// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    public class FeatureFlagModelTests
    {
        private static FeatureFlag CreateFullFeatureFlag()
        {
            FeatureFlag flag = new FeatureFlag
            {
                Enabled = true,
                Description = "A fully populated feature flag.",
                Conditions = new FeatureFlagConditions
                {
                    RequirementType = RequirementType.All,
                    Filters =
                    {
                        new FeatureFilter("TimeWindow"),
                        new FeatureFilter("Targeting", new System.Collections.Generic.Dictionary<string, string>
                        {
                            ["Audience"] = "beta",
                        }),
                    },
                },
                Allocation = new FeatureFlagAllocation
                {
                    DefaultWhenDisabled = "off",
                    DefaultWhenEnabled = "on",
                    Seed = "seed-value",
                    Percentile =
                    {
                        new PercentileAllocation("on", 0.0, 25.5),
                        new PercentileAllocation("off", 25.5, 100.0),
                    },
                    User =
                    {
                        new UserAllocation("on", new[] { "user-1", "user-2" }),
                    },
                    Group =
                    {
                        new GroupAllocation("off", new[] { "group-1" }),
                    },
                },
                Telemetry = new FeatureFlagTelemetryConfiguration(true)
                {
                    Metadata =
                    {
                        ["key"] = "value",
                    },
                },
            };

            flag.Variants.Add(new FeatureFlagVariantDefinition("on")
            {
                Value = "true",
                ContentType = "application/json",
                StatusOverride = StatusOverride.Enabled,
            });
            flag.Variants.Add(new FeatureFlagVariantDefinition("off")
            {
                Value = "false",
                StatusOverride = StatusOverride.Disabled,
            });

            flag.Tags.Add("owner", "team-a");
            flag.Tags.Add("env", "test");

            return flag;
        }

        [Test]
        public void FullFeatureFlagRoundTrips()
        {
            FeatureFlag flag = CreateFullFeatureFlag();

            BinaryData data = ModelReaderWriter.Write(flag);
            FeatureFlag roundTrip = ModelReaderWriter.Read<FeatureFlag>(data);

            Assert.That(roundTrip, Is.Not.Null);
            Assert.That(roundTrip.Enabled, Is.True);
            Assert.That(roundTrip.Description, Is.EqualTo("A fully populated feature flag."));

            // Conditions
            Assert.That(roundTrip.Conditions, Is.Not.Null);
            Assert.That(roundTrip.Conditions.RequirementType, Is.EqualTo(RequirementType.All));
            Assert.That(roundTrip.Conditions.Filters.Count, Is.EqualTo(2));
            Assert.That(roundTrip.Conditions.Filters[0].Name, Is.EqualTo("TimeWindow"));
            Assert.That(roundTrip.Conditions.Filters[1].Name, Is.EqualTo("Targeting"));
            Assert.That(roundTrip.Conditions.Filters[1].Parameters["Audience"], Is.EqualTo("beta"));

            // Variants
            Assert.That(roundTrip.Variants.Count, Is.EqualTo(2));
            Assert.That(roundTrip.Variants[0].Name, Is.EqualTo("on"));
            Assert.That(roundTrip.Variants[0].Value, Is.EqualTo("true"));
            Assert.That(roundTrip.Variants[0].ContentType, Is.EqualTo("application/json"));
            Assert.That(roundTrip.Variants[0].StatusOverride, Is.EqualTo(StatusOverride.Enabled));
            Assert.That(roundTrip.Variants[1].Name, Is.EqualTo("off"));
            Assert.That(roundTrip.Variants[1].StatusOverride, Is.EqualTo(StatusOverride.Disabled));

            // Allocation
            Assert.That(roundTrip.Allocation, Is.Not.Null);
            Assert.That(roundTrip.Allocation.DefaultWhenDisabled, Is.EqualTo("off"));
            Assert.That(roundTrip.Allocation.DefaultWhenEnabled, Is.EqualTo("on"));
            Assert.That(roundTrip.Allocation.Seed, Is.EqualTo("seed-value"));

            // Percentile allocation (From/To are doubles)
            Assert.That(roundTrip.Allocation.Percentile.Count, Is.EqualTo(2));
            Assert.That(roundTrip.Allocation.Percentile[0].Variant, Is.EqualTo("on"));
            Assert.That(roundTrip.Allocation.Percentile[0].From, Is.EqualTo(0.0));
            Assert.That(roundTrip.Allocation.Percentile[0].To, Is.EqualTo(25.5));
            Assert.That(roundTrip.Allocation.Percentile[1].Variant, Is.EqualTo("off"));
            Assert.That(roundTrip.Allocation.Percentile[1].From, Is.EqualTo(25.5));
            Assert.That(roundTrip.Allocation.Percentile[1].To, Is.EqualTo(100.0));

            // User / Group allocations
            Assert.That(roundTrip.Allocation.User.Count, Is.EqualTo(1));
            Assert.That(roundTrip.Allocation.User[0].Variant, Is.EqualTo("on"));
            Assert.That(roundTrip.Allocation.User[0].Users, Is.EquivalentTo(new[] { "user-1", "user-2" }));
            Assert.That(roundTrip.Allocation.Group.Count, Is.EqualTo(1));
            Assert.That(roundTrip.Allocation.Group[0].Variant, Is.EqualTo("off"));
            Assert.That(roundTrip.Allocation.Group[0].Groups, Is.EquivalentTo(new[] { "group-1" }));

            // Telemetry
            Assert.That(roundTrip.Telemetry, Is.Not.Null);
            Assert.That(roundTrip.Telemetry.Enabled, Is.True);
            Assert.That(roundTrip.Telemetry.Metadata["key"], Is.EqualTo("value"));

            // Tags
            Assert.That(roundTrip.Tags["owner"], Is.EqualTo("team-a"));
            Assert.That(roundTrip.Tags["env"], Is.EqualTo("test"));
        }

        [Test]
        public void PercentileAllocationSupportsFractionalBounds()
        {
            PercentileAllocation allocation = new PercentileAllocation("variant", 10.25, 33.75);

            BinaryData data = ModelReaderWriter.Write(allocation);
            PercentileAllocation roundTrip = ModelReaderWriter.Read<PercentileAllocation>(data);

            Assert.That(roundTrip.Variant, Is.EqualTo("variant"));
            Assert.That(roundTrip.From, Is.EqualTo(10.25));
            Assert.That(roundTrip.To, Is.EqualTo(33.75));
        }
    }
}
