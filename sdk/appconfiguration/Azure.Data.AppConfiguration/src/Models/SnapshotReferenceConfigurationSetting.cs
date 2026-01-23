// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// Represents a configuration setting that references a snapshot.
    /// </summary>
    public class SnapshotReferenceConfigurationSetting : ConfigurationSetting
    {
        internal const string SnapshotReferenceContentType = "application/json; profile=\"https://azconfig.io/mime-profiles/snapshot-ref\"; charset=utf-8";

        private string _originalValue;
        private bool _isValidValue;
        private string _snapshotName;

        internal SnapshotReferenceConfigurationSetting()
        {
        }

        /// <summary>
        /// Creates a <see cref="SnapshotReferenceConfigurationSetting"/> referencing the provided snapshot.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting.</param>
        /// <param name="snapshotName">The name of the snapshot to reference.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        public SnapshotReferenceConfigurationSetting(string key, string snapshotName, string label = null) : this(key, snapshotName, label, default)
        {
        }

        /// <summary>
        /// Creates a <see cref="SnapshotReferenceConfigurationSetting"/> referencing the provided snapshot.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting.</param>
        /// <param name="snapshotName">The name of the snapshot to reference.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        /// <param name="etag">The ETag value for the configuration setting.</param>
        public SnapshotReferenceConfigurationSetting(string key, string snapshotName, string label, ETag etag)
        {
            _isValidValue = true;
            _snapshotName = snapshotName;

            Key = key;
            Label = label;
            ETag = etag;
            ContentType = SnapshotReferenceContentType;
        }

        /// <summary>
        /// The name of the referenced snapshot.
        /// </summary>
        public string SnapshotName
        {
            get
            {
                CheckValid();
                return _snapshotName;
            }
            set
            {
                _snapshotName = value;
            }
        }

        internal override void SetValue(string value)
        {
            _originalValue = value;
            _isValidValue = TryParseValue();
        }

        internal override string GetValue()
        {
            // If the value wasn't valid, return it verbatim.
            if (!_isValidValue)
            {
                return _originalValue;
            }

            using var memoryStream = new MemoryStream();
            using var writer = new Utf8JsonWriter(memoryStream);

            writer.WriteStartObject();
            writer.WriteString("snapshot_name", _snapshotName);
            writer.WriteEndObject();
            writer.Flush();

            _originalValue = Encoding.UTF8.GetString(memoryStream.ToArray());
            return _originalValue;
        }

        private bool TryParseValue()
        {
            try
            {
                using var document = JsonDocument.Parse(_originalValue);

                if (document.RootElement.TryGetProperty("snapshot_name", out JsonElement snapshotNameElement) &&
                    snapshotNameElement.ValueKind == JsonValueKind.String)
                {
                    _snapshotName = snapshotNameElement.GetString();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void CheckValid()
        {
            if (!_isValidValue)
            {
                throw new InvalidOperationException($"The content of the {nameof(Value)} property does not represent a valid snapshot reference object.");
            }
        }
    }
}
