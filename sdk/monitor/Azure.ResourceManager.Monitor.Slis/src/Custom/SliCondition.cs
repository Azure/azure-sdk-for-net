// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.Monitor.Slis.Models
{
    /// <summary>
    /// Customization that layers an <see cref="IList{T}"/>-style accessor on top of the wire
    /// <see cref="Value"/> property for the <see cref="SliConditionOperator.In"/> /
    /// <see cref="SliConditionOperator.NotIn"/> list operators. The wire format joins the items
    /// with the literal separator <c>^^</c>.
    /// </summary>
    public partial class SliCondition
    {
        /// <summary> Separator used by the SLI resource provider between list items for the <c>in</c> and <c>notin</c> operators. </summary>
        private const string InValueSeparator = "^^";

        /// <summary>
        /// Gets or sets the list of values for <see cref="SliConditionOperator.In"/> /
        /// <see cref="SliConditionOperator.NotIn"/>. For all other operators use <see cref="Value"/> directly.
        /// </summary>
        /// <remarks>
        /// Backed by <see cref="Value"/>: the getter splits <see cref="Value"/> on <c>^^</c>, and the setter
        /// joins the supplied items with <c>^^</c>. Assigning <see langword="null"/> clears <see cref="Value"/>;
        /// assigning an empty collection sets <see cref="Value"/> to the empty string.
        /// </remarks>
        public IList<string> Values
        {
            get => Value is null
                ? Array.Empty<string>()
                : Value.Split(new[] { InValueSeparator }, StringSplitOptions.None);
            set => Value = value is null
                ? null
                : string.Join(InValueSeparator, value);
        }

        /// <summary>
        /// Creates a new <see cref="SliCondition"/> for a list operator (<see cref="SliConditionOperator.In"/>
        /// or <see cref="SliConditionOperator.NotIn"/>) by joining the supplied <paramref name="values"/> with
        /// the <c>^^</c> separator used on the wire.
        /// </summary>
        /// <param name="operator"> Must be <see cref="SliConditionOperator.In"/> or <see cref="SliConditionOperator.NotIn"/>. </param>
        /// <param name="values"> Values to match. Must contain at least one item; individual items must not contain the <c>^^</c> separator. </param>
        /// <param name="dimensionName"> Optional dimension name used in filtering. </param>
        /// <param name="scalarFunction"> Optional scalar function applied for filtering. </param>
        /// <param name="samplingType"> Optional sampling type. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="values"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="operator"/> is not <see cref="SliConditionOperator.In"/> or <see cref="SliConditionOperator.NotIn"/>, <paramref name="values"/> is empty, or an item contains the <c>^^</c> separator. </exception>
        public static SliCondition ForListOperator(
            SliConditionOperator @operator,
            IEnumerable<string> values,
            string dimensionName = null,
            SliScalarFunction? scalarFunction = null,
            SliSamplingType? samplingType = null)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (@operator != SliConditionOperator.In && @operator != SliConditionOperator.NotIn)
            {
                throw new ArgumentException(
                    $"Operator must be {nameof(SliConditionOperator)}.{nameof(SliConditionOperator.In)} or " +
                    $"{nameof(SliConditionOperator)}.{nameof(SliConditionOperator.NotIn)}; received '{@operator}'.",
                    nameof(@operator));
            }

            var materialized = values as IList<string> ?? values.ToList();
            if (materialized.Count == 0)
            {
                throw new ArgumentException("At least one value is required for list operators.", nameof(values));
            }

            for (int i = 0; i < materialized.Count; i++)
            {
                if (materialized[i] != null && materialized[i].Contains(InValueSeparator))
                {
                    throw new ArgumentException(
                        $"Value at index {i} contains the reserved '^^' separator, which is not supported.",
                        nameof(values));
                }
            }

            return new SliCondition(@operator, string.Join(InValueSeparator, materialized))
            {
                DimensionName = dimensionName,
                ScalarFunction = scalarFunction,
                SamplingType = samplingType,
            };
        }
    }
}
