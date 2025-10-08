// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// A Feature Flag, defined by a unique combination of a name and label.
    /// </summary>
    [CodeGenSerialization(nameof(ETag), SerializationValueHook = nameof(SerializationEtag), DeserializationValueHook = nameof(DeserializeEtag))]
    public partial class FeatureFlag
    {
        private IList<FeatureFlagVariantDefinition> _variants;
        private IDictionary<string, string> _tags;

        /// <summary> Initializes a new instance of <see cref="FeatureFlag"/>. </summary>
        public FeatureFlag()
        {
        }

        /// <summary>
        /// Creates a feature flag and sets it's enabled status and label.
        /// </summary>
        /// <param name="name">The primary identifier of the feature flag.</param>
        /// <param name="enabled">The enabled status of the flag.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="etag">The ETag value for the feature flag.</param>
        public FeatureFlag(string name, bool? enabled = default, string label = null, ETag etag = default) : this(name, enabled, label, null, null, null, null, null, null, null, false, null, etag, null)
        {
        }

        internal static RequestContent ToRequestContent(FeatureFlag featureFlag)
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(featureFlag);
            return content;
        }

        /// <summary>
        /// An ETag indicating the state of a feature flag within a configuration store.
        /// </summary>
        [CodeGenMember("Etag")]
        public ETag ETag { get; internal set; }

        /// <summary>
        /// The last time a modifying operation was performed on the given feature flag.
        /// </summary>
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// A value indicating whether the feature flag is read only.
        /// A read only feature flag may not be modified until it is made writable.
        /// </summary>
        [CodeGenMember("Locked")]
        public bool? IsReadOnly { get; internal set; }

        /// <summary>
        /// A list of variant definitions for the feature flag.
        /// </summary>
        public IList<FeatureFlagVariantDefinition> Variants
        {
            get => _variants ?? (_variants = new ChangeTrackingList<FeatureFlagVariantDefinition>());
            internal set => _variants = value;
        }

        /// <summary>
        /// A dictionary of tags used to assign additional properties to a feature flag.
        /// These can be used to indicate how a feature flag may be applied.
        /// </summary>
        public IDictionary<string, string> Tags
        {
            get => _tags ?? (_tags = new Dictionary<string, string>());
            internal set => _tags = value;
        }

        /// <summary>
        /// Check if two FeatureFlag instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the FeatureFlag.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        private void SerializationEtag(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => writer.WriteStringValue(ETag.ToString());

        private static void DeserializeEtag(JsonProperty property, ref ETag val)
            => val = new ETag(property.Value.GetString());
    }
}
