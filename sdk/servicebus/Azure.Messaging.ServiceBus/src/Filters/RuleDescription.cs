// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus.Primitives;

namespace Azure.Messaging.ServiceBus.Filters
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
        private Filter _filter;
        private string _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleDescription" /> class with default values.
        /// </summary>
        public RuleDescription()
            : this(RuleDescription.DefaultRuleName, TrueFilter.Default)
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
        /// Initializes a new instance of the <see cref="RuleDescription" /> class with the specified name and filter expression.
        /// </summary>
        /// <param name="name"></param>
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
            get => _filter;

            set => _filter = value ?? throw Fx.Exception.ArgumentNull(nameof(Filter));
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
            get => _name;

            set
            {
                //EntityNameHelper.CheckValidRuleName(value);
                _name = value;
            }
        }

        // TODO: Implement for AMQP
        internal DateTime CreatedAt
        {
            get; set;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hash = 13;
            unchecked
            {
                hash = (hash * 7) + _filter?.GetHashCode() ?? 0;
                hash = (hash * 7) + Action?.GetHashCode() ?? 0;
            }
            return hash;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            var other = obj as RuleDescription;
            return Equals(other);
        }

        /// <inheritdoc/>
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static bool operator ==(RuleDescription o1, RuleDescription o2)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static bool operator !=(RuleDescription o1, RuleDescription o2)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return !(o1 == o2);
        }
    }
}
