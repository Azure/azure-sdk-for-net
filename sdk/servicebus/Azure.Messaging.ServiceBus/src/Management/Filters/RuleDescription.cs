// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Messaging.ServiceBus.Management
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
        /// The default rule is a <see cref="TrueRuleFilter"/> which will enable all messages in the topic to reach subscription.
        /// </remarks>
        public const string DefaultRuleName = "$Default";
        private RuleFilter _filter;
        private string _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleDescription" /> class with default values.
        /// </summary>
        public RuleDescription()
            : this(RuleDescription.DefaultRuleName, TrueRuleFilter.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleDescription" /> class with the specified name.
        /// </summary>
        public RuleDescription(string name)
            : this(name, TrueRuleFilter.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleDescription" /> class with the specified name and filter expression.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="filter">The filter expression used to match messages.</param>
        public RuleDescription(string name, RuleFilter filter)
        {
            Argument.AssertNotNull(filter, nameof(filter));
            Filter = filter;
            Name = name;
        }

        /// <summary>
        /// Gets or sets the filter expression used to match messages.
        /// </summary>
        /// <value>The filter expression used to match messages.</value>
        /// <exception cref="System.ArgumentNullException">null (Nothing in Visual Basic) is assigned.</exception>
        public RuleFilter Filter
        {
            get => _filter;

            set
            {
                Argument.AssertNotNull(value, nameof(Filter));
                _filter = value;
            }
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
        public bool Equals(RuleDescription other)
        {
            if (other is RuleDescription otherProperties
                && string.Equals(Name, otherProperties.Name, StringComparison.OrdinalIgnoreCase)
                && (Filter == null || Filter.Equals(otherProperties.Filter))
                && (Action == null || Action.Equals(otherProperties.Action)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(RuleDescription left, RuleDescription right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }

            return left.Equals(right);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(RuleDescription left, RuleDescription right)
        {
            return !(left == right);
        }
    }
}
