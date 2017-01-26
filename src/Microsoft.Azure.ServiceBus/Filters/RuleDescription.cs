// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Filters
{
    /// <summary>
    /// Represents a description of a rule.
    /// </summary>
    public sealed class RuleDescription
    {
        Filter filter;
        string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleDescription" /> class with default values.
        /// </summary>
        public RuleDescription()
            : this(TrueFilter.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleDescription" /> class with the specified name.
        /// </summary>
        /// <param name="name">The name of the rule.</param>
        public RuleDescription(string name)
            : this(name, TrueFilter.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleDescription" /> class with the specified filter expression.
        /// </summary>
        /// <param name="filter">The filter expression used to match messages.</param>
        public RuleDescription(Filter filter)
        {
            if (filter == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(filter));
            }

            this.Filter = filter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleDescription" /> class with the specified name and filter expression.
        /// </summary>
        /// <param name="name">The name of the rule.</param>
        /// <param name="filter">The filter expression used to match messages.</param>
        public RuleDescription(string name, Filter filter)
        {
            if (filter == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(filter));
            }

            this.Filter = filter;
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets the filter expression used to match messages.
        /// </summary>
        /// <value>The filter expression used to match messages.</value>
        /// <exception cref="System.ArgumentNullException">null (Nothing in Visual Basic) is assigned.</exception>
        public Filter Filter
        {
            get
            {
                return this.filter;
            }

            set
            {
                if (value == null)
                {
                    throw Fx.Exception.ArgumentNull(nameof(this.Filter));
                }

                this.filter = value;
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
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(this.Name));
                }

                this.name = value;
            }
        }

        internal void ValidateDescriptionName()
        {
            if (string.IsNullOrWhiteSpace(this.name))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(this.name));
            }

            if (this.name.Length > Constants.RuleNameMaximumLength)
            {
                throw Fx.Exception.ArgumentOutOfRange(
                    nameof(this.name),
                    this.name,
                    Resources.EntityNameLengthExceedsLimit.FormatForUser(this.name, Constants.RuleNameMaximumLength));
            }

            if (this.name.Contains(Constants.PathDelimiter) || this.name.Contains(@"\"))
            {
                throw Fx.Exception.Argument(
                    nameof(this.name),
                    Resources.InvalidCharacterInEntityName.FormatForUser(Constants.PathDelimiter, this.name));
            }

            string[] uriSchemeKeys = { "@", "?", "#" };
            foreach (var uriSchemeKey in uriSchemeKeys)
            {
                if (this.name.Contains(uriSchemeKey))
                {
                    throw Fx.Exception.Argument(
                        nameof(this.name),
                        Resources.CharacterReservedForUriScheme.FormatForUser(nameof(this.name), uriSchemeKey));
                }
            }
        }
    }
}