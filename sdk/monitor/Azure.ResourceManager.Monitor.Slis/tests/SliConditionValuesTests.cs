// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Monitor.Slis.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Slis.Tests
{
    public class SliConditionValuesTests
    {
        [Test]
        public void Values_RoundTrip_Through_WireValue()
        {
            var condition = new SliCondition(SliConditionOperator.In, "east^^west^^north");

            Assert.That(condition.Values, Is.EqualTo(new[] { "east", "west", "north" }));
        }

        [Test]
        public void Values_Setter_Joins_With_Separator()
        {
            var condition = new SliCondition(SliConditionOperator.In, "placeholder")
            {
                Values = new[] { "east", "west", "north" }
            };

            Assert.That(condition.Value, Is.EqualTo("east^^west^^north"));
        }

        [Test]
        public void Values_Getter_Returns_Single_Element_For_Empty_Value()
        {
            var condition = new SliCondition(SliConditionOperator.In, string.Empty);

            Assert.That(condition.Values, Has.Count.EqualTo(1));
            Assert.That(condition.Values[0], Is.EqualTo(string.Empty));
        }

        [Test]
        public void Values_Setter_Null_Clears_Value()
        {
            var condition = new SliCondition(SliConditionOperator.In, "east^^west")
            {
                Values = null
            };

            Assert.That(condition.Value, Is.Null);
        }

        [Test]
        public void ForListOperator_Builds_Condition_For_In()
        {
            var condition = SliCondition.ForListOperator(
                SliConditionOperator.In,
                new[] { "east", "west" },
                dimensionName: "region");

            Assert.That(condition.Operator, Is.EqualTo(SliConditionOperator.In));
            Assert.That(condition.Value, Is.EqualTo("east^^west"));
            Assert.That(condition.DimensionName, Is.EqualTo("region"));
        }

        [Test]
        public void ForListOperator_Builds_Condition_For_NotIn()
        {
            var condition = SliCondition.ForListOperator(
                SliConditionOperator.NotIn,
                new List<string> { "east" });

            Assert.That(condition.Operator, Is.EqualTo(SliConditionOperator.NotIn));
            Assert.That(condition.Value, Is.EqualTo("east"));
        }

        [Test]
        public void ForListOperator_Rejects_Wrong_Operator()
        {
            Assert.Throws<ArgumentException>(() =>
                SliCondition.ForListOperator(SliConditionOperator.Equal, new[] { "east" }));
        }

        [Test]
        public void ForListOperator_Rejects_Null_Values()
        {
            Assert.Throws<ArgumentNullException>(() =>
                SliCondition.ForListOperator(SliConditionOperator.In, null));
        }

        [Test]
        public void ForListOperator_Rejects_Empty_Values()
        {
            Assert.Throws<ArgumentException>(() =>
                SliCondition.ForListOperator(SliConditionOperator.In, Array.Empty<string>()));
        }

        [Test]
        public void ForListOperator_Rejects_Item_Containing_Separator()
        {
            Assert.Throws<ArgumentException>(() =>
                SliCondition.ForListOperator(SliConditionOperator.In, new[] { "ok", "bad^^value" }));
        }
    }
}
