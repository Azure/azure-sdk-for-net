// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Microsoft.Azure.ServiceBus.Primitives;

namespace Microsoft.Azure.ServiceBus.Filters
{
	/// <summary>
    /// Represents a description of a rule.
    /// </summary>
    public sealed class RuleDescription : IEquatable<RuleDescription>
    {
        /// <summary>
        /// Gets the name of the default rule on the subscription.
        /// </summary>
        /// <remarks>
        /// Whenever a new subscription is created, a default rule is always added.
        /// The default rule is a <see cref="TrueFilter"/> which will enable all messages in the topic to reach subscription.
        /// </remarks>
        public const string DefaultRuleName = "$Default";

        Filter filter;
        string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleDescription" /> class with default values.
        /// </summary>
        public RuleDescription()
            : this(DefaultRuleName, TrueFilter.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleDescription" /> class with the specified name.
        /// </summary>
        public RuleDescription(string name)
            : this(name, TrueFilter.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleDescription" /> class with the specified filter expression.
        /// </summary>
        /// <param name="filter">The filter expression used to match messages.</param>
        [Obsolete("This constructor will be removed in next version, please use RuleDescription(string, Filter) instead.")]
        public RuleDescription(Filter filter)
        {
            Filter = filter ?? throw Fx.Exception.ArgumentNull(nameof(filter));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleDescription" /> class with the specified name and filter expression.
        /// </summary>
        /// <param name="filter">The filter expression used to match messages.</param>
        public RuleDescription(string name, Filter filter)
        {
            Filter = filter ?? throw Fx.Exception.ArgumentNull(nameof(filter));
            Name = name;
        }

        /// <summary>
        /// Gets or sets the filter expression used to match messages.
        /// </summary>
        /// <value>The filter expression used to match messages.</value>
        /// <exception cref="System.ArgumentNullException">null (Nothing in Visual Basic) is assigned.</exception>
        public Filter Filter
        {
            get => filter;

            set => filter = value ?? throw Fx.Exception.ArgumentNull(nameof(Filter));
        }

        /// <summary>
        /// Gets or sets the action to perform if the message satisfies the filtering expression.
        /// </summary>
        /// <value>The action to perform if the message satisfies the filtering expression.</value>
        public RuleAction Action { get; set; }

        /// <summary>
        /// Gets or sets the name of the rule.
        /// </summary>
        /// <value>Returns a <see cref="System.String" /> Representing the name of the rule.</value>
        /// <remarks>Max allowed length of rule name is 50 chars.</remarks>
        public string Name
        {
            get => name;

            set
            {
                EntityNameHelper.CheckValidRuleName(value);
                name = value;
            }
        }

        // TODO: Implement for AMQP
        internal DateTime CreatedAt
        {
            get; set;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            unchecked
            {
                hash = (hash * 7) + filter?.GetHashCode() ?? 0;
                hash = (hash * 7) + Action?.GetHashCode() ?? 0; 
            }
            return hash;
        }

        public override bool Equals(object obj)
        {
            var other = obj as RuleDescription;
            return Equals(other);
        }

        public bool Equals(RuleDescription otherRule)
        {
            if (otherRule is RuleDescription other
                && string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase)
                && (Filter == null || Filter.Equals(other.Filter))
                && (Action == null || Action.Equals(other.Action)))
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(RuleDescription o1, RuleDescription o2)
        {
            if (ReferenceEquals(o1, o2))
            {
                return true;
            }

            if (ReferenceEquals(o1, null) || ReferenceEquals(o2, null))
            {
                return false;
            }

            return o1.Equals(o2);
        }

        public static bool operator !=(RuleDescription o1, RuleDescription o2)
        {
            return !(o1 == o2);
        }
    }
}