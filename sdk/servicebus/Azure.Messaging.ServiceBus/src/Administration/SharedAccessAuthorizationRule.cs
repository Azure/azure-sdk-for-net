// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;
using Azure.Messaging.ServiceBus.Authorization;

namespace Azure.Messaging.ServiceBus.Administration
{
    /// <summary>
    /// Defines the authorization rule for an entity using SAS.
    /// </summary>
    public class SharedAccessAuthorizationRule : AuthorizationRule
    {
        private const int SupportedSASKeyLength = 44;
        private const string FixedClaimType = "SharedAccessKey";

        private string internalKeyName;
        private string internalPrimaryKey;
        private string internalSecondaryKey;
        private List<AccessRights> internalRights;

        internal SharedAccessAuthorizationRule()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SharedAccessAuthorizationRule" /> class.</summary>
        /// <param name="keyName">The authorization rule key name.</param>
        /// <param name="rights">The list of rights.</param>
        public SharedAccessAuthorizationRule(string keyName, IEnumerable<AccessRights> rights)
            : this(keyName, SharedAccessAuthorizationRule.GenerateRandomKey(), SharedAccessAuthorizationRule.GenerateRandomKey(), rights)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SharedAccessAuthorizationRule" /> class.</summary>
        /// <param name="keyName">The authorization rule key name.</param>
        /// <param name="primaryKey">The primary key for the authorization rule.</param>
        /// <param name="rights">The list of rights.</param>
        public SharedAccessAuthorizationRule(string keyName, string primaryKey, IEnumerable<AccessRights> rights)
            : this(keyName, primaryKey, SharedAccessAuthorizationRule.GenerateRandomKey(), rights)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SharedAccessAuthorizationRule" /> class.</summary>
        /// <param name="keyName">The authorization rule key name.</param>
        /// <param name="primaryKey">The primary key for the authorization rule.</param>
        /// <param name="secondaryKey">The secondary key for the authorization rule.</param>
        /// <param name="rights">The list of rights.</param>
        public SharedAccessAuthorizationRule(string keyName, string primaryKey, string secondaryKey, IEnumerable<AccessRights> rights)
        {
            PrimaryKey = primaryKey;
            SecondaryKey = secondaryKey;
            Rights = new List<AccessRights>(rights);
            KeyName = keyName;
        }

        internal override AuthorizationRule Clone() =>
            new SharedAccessAuthorizationRule(KeyName, PrimaryKey, SecondaryKey, Rights);

        /// <inheritdoc/>
        public override string ClaimType => FixedClaimType;
        internal override string ClaimValue => "None";

        /// <summary>Gets or sets the authorization rule key name.</summary>
        /// <value>The authorization rule key name.</value>
        public sealed override string KeyName
        {
            get { return internalKeyName; }
            set
            {
                Argument.AssertNotNullOrWhiteSpace(value, nameof(KeyName));
                Argument.AssertNotTooLong(
                    value,
                    SharedAccessSignature.MaximumKeyNameLength,
                    nameof(KeyName));

                if (!string.Equals(value, HttpUtility.UrlEncode(value), StringComparison.InvariantCulture))
                {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
                    throw new ArgumentException(
                        "The key name specified contains invalid characters",
                        nameof(KeyName));
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
                }

                internalKeyName = value;
            }
        }

        /// <summary>Gets or sets the primary key for the authorization rule.</summary>
        /// <value>The primary key for the authorization rule.</value>
        public string PrimaryKey
        {
            get { return internalPrimaryKey; }
            set
            {
                Argument.AssertNotNullOrWhiteSpace(value, nameof(PrimaryKey));

                if (Encoding.ASCII.GetByteCount(value) != SupportedSASKeyLength)
                {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
                    throw new ArgumentOutOfRangeException(
                        nameof(PrimaryKey),
                        $"{nameof(SharedAccessAuthorizationRule)} only supports keys of size {SupportedSASKeyLength} bytes");
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
                }

                if (!CheckBase64(value))
                {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
                    throw new ArgumentException($"{nameof(SharedAccessAuthorizationRule)} only supports base64 keys.",
                        nameof(PrimaryKey));
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
                }

                internalPrimaryKey = value;
            }
        }

        /// <summary>Gets or sets the secondary key for the authorization rule.</summary>
        /// <value>The secondary key for the authorization rule.</value>
        public string SecondaryKey
        {
            get { return internalSecondaryKey; }
            set
            {
                Argument.AssertNotNullOrWhiteSpace(value, nameof(SecondaryKey));

                if (Encoding.ASCII.GetByteCount(value) != SupportedSASKeyLength)
                {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
                    throw new ArgumentOutOfRangeException(
                        nameof(SecondaryKey),
                        $"{nameof(SharedAccessAuthorizationRule)} only supports keys of size {SupportedSASKeyLength} bytes");
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
                }

                if (!CheckBase64(value))
                {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
                    throw new ArgumentException(
                        $"{nameof(SharedAccessAuthorizationRule)} only supports base64 keys.",
                    nameof(SecondaryKey));
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
                }

                internalSecondaryKey = value;
            }
        }

        /// <inheritdoc/>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>")]
        public override List<AccessRights> Rights
        {
            get => internalRights;
            set
            {
                if (value == null || value.Count < 0 || value.Count > AdministrationClientConstants.SupportedClaimsCount)
                {
                    throw new ArgumentException($"Rights cannot be null, empty or greater than {AdministrationClientConstants.SupportedClaimsCount}");
                }

                HashSet<AccessRights> dedupedAccessRights = new HashSet<AccessRights>(value);
                if (value.Count != dedupedAccessRights.Count)
                {
                    throw new ArgumentException("Access rights on an authorization rule must be unique");
                }

                if (value.Contains(AccessRights.Manage) && value.Count != 3)
                {
                    throw new ArgumentException("Manage permission should also include Send and Listen");
                }

                internalRights = value;
            }
        }

        /// <summary>Returns the hash code for this instance.</summary>
        public override int GetHashCode()
        {
            int hash = 13;
            unchecked
            {
                hash = (hash * 7) + KeyName?.GetHashCode() ?? 0;
                hash = (hash * 7) + PrimaryKey?.GetHashCode() ?? 0;
                hash = (hash * 7) + SecondaryKey?.GetHashCode() ?? 0;
                hash = (hash * 7) + Rights.GetHashCode();
            }

            return hash;
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        public override bool Equals(object obj)
        {
            var other = obj as AuthorizationRule;
            return Equals(other);
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(AuthorizationRule other)
        {
            if (other is not SharedAccessAuthorizationRule comparand)
            {
                return false;
            }

            if (!string.Equals(KeyName, comparand.KeyName, StringComparison.OrdinalIgnoreCase) ||
                !string.Equals(PrimaryKey, comparand.PrimaryKey, StringComparison.Ordinal) ||
                !string.Equals(SecondaryKey, comparand.SecondaryKey, StringComparison.Ordinal))
            {
                return false;
            }

            if ((Rights != null && comparand.Rights == null) ||
                (Rights == null && comparand.Rights != null))
            {
                return false;
            }

            if (Rights != null && comparand.Rights != null)
            {
                HashSet<AccessRights> thisRights = new HashSet<AccessRights>(Rights);
                if (comparand.Rights.Count != thisRights.Count)
                {
                    return false;
                }

                return thisRights.SetEquals(comparand.Rights);
            }

            return true;
        }

        /// <summary></summary>
        public static bool operator ==(SharedAccessAuthorizationRule left, SharedAccessAuthorizationRule right)
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

        /// <summary></summary>
        public static bool operator !=(SharedAccessAuthorizationRule left, SharedAccessAuthorizationRule right)
        {
            return !(left == right);
        }

        /// <summary>Generates the random key for the authorization rule.</summary>
        private static string GenerateRandomKey()
        {
            byte[] key256 = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key256);
            }

            return Convert.ToBase64String(key256);
        }

        private static bool CheckBase64(string base64EncodedString)
        {
            try
            {
                Convert.FromBase64String(base64EncodedString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal static new SharedAccessAuthorizationRule ParseFromXElement(XElement xElement)
        {
            var rule = new SharedAccessAuthorizationRule();
            foreach (var element in xElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "CreatedTime":
                        rule.CreatedTime = XmlConvert.ToDateTime(element.Value, XmlDateTimeSerializationMode.Utc);
                        break;
                    case "ModifiedTime":
                        rule.ModifiedTime = XmlConvert.ToDateTime(element.Value, XmlDateTimeSerializationMode.Utc);
                        break;
                    case "KeyName":
                        rule.KeyName = element.Value;
                        break;
                    case "PrimaryKey":
                        rule.PrimaryKey = element.Value;
                        break;
                    case "SecondaryKey":
                        rule.SecondaryKey = element.Value;
                        break;
                    case "Rights":
                        var rights = new List<AccessRights>();
                        var xRights = element.Elements(XName.Get("AccessRights", AdministrationClientConstants.ServiceBusNamespace));
                        foreach (var xRight in xRights)
                        {
                            rights.Add((AccessRights)Enum.Parse(typeof(AccessRights), xRight.Value));
                        }
                        rule.Rights = rights;
                        break;
                }
            }

            return rule;
        }

        internal override XElement Serialize()
        {
            XElement rule = new XElement(
                XName.Get("AuthorizationRule", AdministrationClientConstants.ServiceBusNamespace),
                new XAttribute(XName.Get("type", AdministrationClientConstants.XmlSchemaInstanceNamespace), nameof(SharedAccessAuthorizationRule)),
                new XElement(XName.Get("ClaimType", AdministrationClientConstants.ServiceBusNamespace), ClaimType),
                new XElement(XName.Get("ClaimValue", AdministrationClientConstants.ServiceBusNamespace), ClaimValue),
                new XElement(XName.Get("Rights", AdministrationClientConstants.ServiceBusNamespace),
                    Rights.Select(right => new XElement(XName.Get("AccessRights", AdministrationClientConstants.ServiceBusNamespace), right.ToString()))),
                new XElement(XName.Get("KeyName", AdministrationClientConstants.ServiceBusNamespace), KeyName),
                new XElement(XName.Get("PrimaryKey", AdministrationClientConstants.ServiceBusNamespace), PrimaryKey),
                new XElement(XName.Get("SecondaryKey", AdministrationClientConstants.ServiceBusNamespace), SecondaryKey)
            );

            return rule;
        }
    }
}
