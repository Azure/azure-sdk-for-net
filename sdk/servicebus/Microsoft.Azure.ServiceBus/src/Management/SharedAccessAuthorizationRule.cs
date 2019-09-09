// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Management
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    using System.Xml;
    using System.Xml.Linq;
    using Microsoft.Azure.ServiceBus.Primitives;
    
    /// <summary>
    /// Defines the authorization rule for an entity using SAS.
    /// </summary>
    public class SharedAccessAuthorizationRule : AuthorizationRule
    {
        const int SupportedSASKeyLength = 44;
        const string FixedClaimType = "SharedAccessKey";

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
            this.PrimaryKey = primaryKey;
            this.SecondaryKey = secondaryKey;
            this.Rights = new List<AccessRights>(rights);
            this.KeyName = keyName;
        }

        public override string ClaimType => FixedClaimType;

        internal override string ClaimValue => "None";

        /// <summary>Gets or sets the authorization rule key name.</summary>
        /// <value>The authorization rule key name.</value>
        public override sealed string KeyName
        {
            get { return this.internalKeyName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(KeyName));
                }

                if (value.Length > SharedAccessSignatureToken.MaxKeyNameLength)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(KeyName), $"The argument cannot exceed {SharedAccessSignatureToken.MaxKeyNameLength} characters");
                }

                if (!string.Equals(value, HttpUtility.UrlEncode(value)))
                {
                    throw new ArgumentException("The key name specified contains invalid characters");
                }

                this.internalKeyName = value;
            }
        }

        /// <summary>Gets or sets the primary key for the authorization rule.</summary>
        /// <value>The primary key for the authorization rule.</value>
        public string PrimaryKey
        {
            get { return this.internalPrimaryKey; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(PrimaryKey));
                }

                if (Encoding.ASCII.GetByteCount(value) != SupportedSASKeyLength)
                {
                    throw new ArgumentOutOfRangeException(nameof(PrimaryKey), $"{nameof(SharedAccessAuthorizationRule)} only supports keys of size {SupportedSASKeyLength} bytes");
                }

                if (!CheckBase64(value))
                {
                    throw new ArgumentException(nameof(PrimaryKey), $"{nameof(SharedAccessAuthorizationRule)} only supports base64 keys.");
                }

                this.internalPrimaryKey = value;
            }
        }

        /// <summary>Gets or sets the secondary key for the authorization rule.</summary>
        /// <value>The secondary key for the authorization rule.</value>
        public string SecondaryKey
        {
            get { return this.internalSecondaryKey; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(SecondaryKey));
                }

                if (Encoding.ASCII.GetByteCount(value) != SupportedSASKeyLength)
                {
                    throw new ArgumentOutOfRangeException(nameof(SecondaryKey), $"{nameof(SharedAccessAuthorizationRule)} only supports keys of size {SupportedSASKeyLength} bytes");
                }

                if (!CheckBase64(value))
                {
                    throw new ArgumentException(nameof(SecondaryKey), $"{nameof(SharedAccessAuthorizationRule)} only supports base64 keys.");
                }

                this.internalSecondaryKey = value;
            }
        }

        public override List<AccessRights> Rights
        {
            get => this.internalRights;
            set
            {
                if (value == null || value.Count < 0 || value.Count > ManagementClientConstants.SupportedClaimsCount)
                {
                    throw new ArgumentException($"Rights cannot be null, empty or greater than {ManagementClientConstants.SupportedClaimsCount}");
                }

                HashSet<AccessRights> dedupedAccessRights = new HashSet<AccessRights>(value);
                if (value.Count != dedupedAccessRights.Count)
                {
                    throw new ArgumentException("Access rights on an authorization rule must be unique");
                }

                if (value.Contains(AccessRights.Manage) && value.Count != 3)
                {
                    throw new ArgumentException(nameof(Rights), "Manage permission should also include Send and Listen");
                }

                this.internalRights = value;
            }
        }

        /// <summary>Returns the hash code for this instance.</summary>
        public override int GetHashCode()
        {
            int hash = 13;
            unchecked
            {
                hash = (hash * 7) + this.KeyName?.GetHashCode() ?? 0;
                hash = (hash * 7) + this.PrimaryKey?.GetHashCode() ?? 0;
                hash = (hash * 7) + this.SecondaryKey?.GetHashCode() ?? 0;
                hash = (hash * 7) + this.Rights.GetHashCode(); 
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            var other = obj as AuthorizationRule;
            return this.Equals(other);
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(AuthorizationRule other)
        {
            if (!(other is SharedAccessAuthorizationRule))
            {
                return false;
            }

            SharedAccessAuthorizationRule comparand = (SharedAccessAuthorizationRule)other;
            if (!string.Equals(this.KeyName, comparand.KeyName, StringComparison.OrdinalIgnoreCase) ||
                !string.Equals(this.PrimaryKey, comparand.PrimaryKey, StringComparison.Ordinal) ||
                !string.Equals(this.SecondaryKey, comparand.SecondaryKey, StringComparison.Ordinal))
            {
                return false;
            }

            if ((this.Rights != null && comparand.Rights == null) ||
                (this.Rights == null && comparand.Rights != null))
            {
                return false;
            }

            if (this.Rights != null && comparand.Rights != null)
            {
                HashSet<AccessRights> thisRights = new HashSet<AccessRights>(this.Rights);
                if (comparand.Rights.Count != thisRights.Count)
                {
                    return false;
                }

                return thisRights.SetEquals(comparand.Rights);
            }

            return true;
        }

        public static bool operator ==(SharedAccessAuthorizationRule o1, SharedAccessAuthorizationRule o2)
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

        public static bool operator !=(SharedAccessAuthorizationRule o1, SharedAccessAuthorizationRule o2)
        {
            return !(o1 == o2);
        }

        /// <summary>Generates the random key for the authorization rule.</summary>        
        private static string GenerateRandomKey()
        {
            byte[] key256 = new byte[32];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetBytes(key256);
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
                        var xRights = element.Elements(XName.Get("AccessRights", ManagementClientConstants.ServiceBusNamespace));
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
                XName.Get("AuthorizationRule", ManagementClientConstants.ServiceBusNamespace),
                new XAttribute(XName.Get("type", ManagementClientConstants.XmlSchemaInstanceNamespace), nameof(SharedAccessAuthorizationRule)),
                new XElement(XName.Get("ClaimType", ManagementClientConstants.ServiceBusNamespace), this.ClaimType),
                new XElement(XName.Get("ClaimValue", ManagementClientConstants.ServiceBusNamespace), this.ClaimValue),
                new XElement(XName.Get("Rights", ManagementClientConstants.ServiceBusNamespace),
                    this.Rights.Select(right => new XElement(XName.Get("AccessRights", ManagementClientConstants.ServiceBusNamespace), right.ToString()))),
                new XElement(XName.Get("KeyName", ManagementClientConstants.ServiceBusNamespace), this.KeyName),
                new XElement(XName.Get("PrimaryKey", ManagementClientConstants.ServiceBusNamespace), this.PrimaryKey),
                new XElement(XName.Get("SecondaryKey", ManagementClientConstants.ServiceBusNamespace), this.SecondaryKey)
            );

            return rule;
        }
    }
}
