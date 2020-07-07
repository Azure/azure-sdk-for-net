// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Describes a binding rule. See <see cref="IBindingRuleProvider"/>.
    /// This is used at runtime to create script wrappers (<see cref="JobHostMetadataProvider.GetDefaultType(Attribute, System.IO.FileAccess, Type)"/>
    /// and at design-time to produce diagnostic warnings and suggested fixes.
    /// </summary>
    internal class BindingRule
    {
        public static readonly BindingRule[] Empty = new BindingRule[0];
                
        /// <summary>
        /// Gets or sets the binding rule filter.
        /// </summary>
        public FilterNode Filter { get; set; }

        /// <summary>
        /// Gets or sets the source attribute type.
        /// </summary>
        public Type SourceAttribute { get; set; }

        /// <summary>
        /// Gets or sets the intermediate converters used to
        /// get to the <see cref="UserType"/>.
        /// </summary>
        public Type[] Converters { get; set; } 

        /// <summary>
        /// Gets or sets the user type this rule can bind to.
        /// </summary>
        public OpenType UserType { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var attr = this.SourceAttribute;

            sb.Append($"[{attr.Name}] -->");
            if (this.Filter != null)
            {
                sb.Append($"[filter: {this.Filter}]-->");
            }

            if (this.Converters != null)
            {
                foreach (var converterType in this.Converters)
                {
                    sb.Append($"{OpenType.ExactMatch.TypeToString(converterType)}-->");
                }
            }

            if (this.UserType != null)
            {
                sb.Append(this.UserType.GetDisplayName());
            }
            return sb.ToString();
        }
    }
}
