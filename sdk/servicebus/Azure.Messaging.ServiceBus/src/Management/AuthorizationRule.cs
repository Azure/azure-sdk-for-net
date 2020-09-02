// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

namespace Azure.Messaging.ServiceBus.Management
{
    /// <summary>
    /// Specifies the authorization rule.
    /// </summary>
    public abstract class AuthorizationRule : IEquatable<AuthorizationRule>
    {
        internal AuthorizationRule()
        {
        }

        internal abstract AuthorizationRule Clone();

        /// <summary>Gets or sets the claim type.</summary>
        /// <value>The claim type.</value>
        public abstract string ClaimType { get; }

        /// <summary>Gets or sets the claim value which is either ‘Send’, ‘Listen’, or ‘Manage’.</summary>
        /// <value>The claim value which is either ‘Send’, ‘Listen’, or ‘Manage’.</value>
        internal abstract string ClaimValue { get; }

        /// <summary>Gets or sets the list of rights.</summary>
        /// <value>The list of rights.</value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>")]
        public abstract List<AccessRights> Rights { get; set; }

        /// <summary>Gets or sets the authorization rule key name.</summary>
        /// <value>The authorization rule key name.</value>
        public abstract string KeyName { get; set; }

        /// <summary>Gets or sets the date and time when the authorization rule was created.</summary>
        /// <value>The date and time when the authorization rule was created.</value>
        public DateTimeOffset CreatedTime { get; internal set; }

        /// <summary>Gets or sets the date and time when the authorization rule was modified.</summary>
        /// <value>The date and time when the authorization rule was modified.</value>
        public DateTimeOffset ModifiedTime { get; internal set; }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        public abstract bool Equals(AuthorizationRule other);

        internal static AuthorizationRule ParseFromXElement(XElement xElement)
        {
            XAttribute attribute = xElement.Attribute(XName.Get("type", ManagementClientConstants.XmlSchemaInstanceNamespace));
            if (attribute == null)
            {
                return null;
            }

            switch (attribute.Value)
            {
                case "SharedAccessAuthorizationRule":
                    return SharedAccessAuthorizationRule.ParseFromXElement(xElement);
                default:
                    return null;
            }
        }

        internal abstract XElement Serialize();

        /// <inheritdoc/>
        public abstract override bool Equals(object obj);

        /// <inheritdoc/>
        public override int GetHashCode() =>
            base.GetHashCode();
    }
}
