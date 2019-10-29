// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Management
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public abstract class AuthorizationRule : IEquatable<AuthorizationRule>
    {
        internal AuthorizationRule()
        {
        }

        /// <summary>Gets or sets the claim type.</summary>
        /// <value>The claim type.</value>
        public abstract string ClaimType { get; }

        /// <summary>Gets or sets the list of rights.</summary>
        /// <value>The list of rights.</value>
        public abstract List<AccessRights> Rights { get; set; }

        /// <summary>Gets or sets the authorization rule key name.</summary>
        /// <value>The authorization rule key name.</value>
        public abstract string KeyName { get; set; }

        /// <summary>Gets or sets the date and time when the authorization rule was created.</summary>
        /// <value>The date and time when the authorization rule was created.</value>
        public DateTime CreatedTime { get; internal set; }

        /// <summary>Gets or sets the date and time when the authorization rule was modified.</summary>
        /// <value>The date and time when the authorization rule was modified.</value>
        public DateTime ModifiedTime { get; internal set; }

        /// <summary>Gets or sets the claim value which is either ‘Send’, ‘Listen’, or ‘Manage’.</summary>
        /// <value>The claim value which is either ‘Send’, ‘Listen’, or ‘Manage’.</value>
        internal abstract string ClaimValue { get; }

        public abstract bool Equals(AuthorizationRule comparand);

        internal static AuthorizationRule ParseFromXElement(XElement xElement)
        {
            var attribute = xElement.Attribute(XName.Get("type", ManagementClientConstants.XmlSchemaInstanceNamespace));
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
    }
}
