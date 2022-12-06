// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// The policy rules under which the key can be exported.
    /// </summary>
    public class KeyReleasePolicy : IJsonSerializable, IJsonDeserializable
    {
        private const string ContentTypePropertyName = "contentType";
        private const string DataPropertyName = "data";
        private const string ImmutablePropertyName = "immutable";

        private static readonly JsonEncodedText s_contentTypePropertyNameBytes = JsonEncodedText.Encode(ContentTypePropertyName);
        private static readonly JsonEncodedText s_dataPropertyNameBytes = JsonEncodedText.Encode(DataPropertyName);
        private static readonly JsonEncodedText s_immutablePropertyName = JsonEncodedText.Encode(ImmutablePropertyName);

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyReleasePolicy"/> class.
        /// </summary>
        /// <param name="encodedPolicy">The policy rules under which the key can be released encoded based on the <see cref="ContentType"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="encodedPolicy"/> is null.</exception>
        /// <example>
        /// The <paramref name="encodedPolicy"/> can be easily read from a file:
        /// <code snippet="Snippet:KeyReleasePolicy_FromStream" language="csharp">
        /// using FileStream file = File.OpenRead(&quot;policy.dat&quot;);
        /// KeyReleasePolicy policy = new KeyReleasePolicy(BinaryData.FromStream(file));
        /// </code>
        /// </example>
        public KeyReleasePolicy(BinaryData encodedPolicy)
        {
            Argument.AssertNotNull(encodedPolicy, nameof(encodedPolicy));
            EncodedPolicy = encodedPolicy;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyReleasePolicy"/> class for deserialization.
        /// </summary>
        internal KeyReleasePolicy()
        {
        }

        /// <summary>
        /// Gets or sets the content type and version of key release policy.
        /// The service default is "application/json; charset=utf-8".
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets the policy rules under which the key can be released encoded based on the <see cref="ContentType"/>.
        /// </summary>
        /// <remarks>
        /// For more information regarding the release policy grammar for Azure Key Vault, please refer to:
        /// <list type="bullet">
        /// <item>
        /// <description>https://aka.ms/policygrammarkeys for Azure Key Vault release policy grammar.</description>
        /// </item>
        /// <item>
        /// <description>https://aka.ms/policygrammarmhsm for Azure Managed HSM release policy grammar.</description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <example>
        /// The <see cref="EncodedPolicy"/> can be easily written to a file:
        /// <code snippet="Snippet:KeyReleasePolicy_ToStream" language="csharp">
        /// KeyReleasePolicy policy = key.Properties.ReleasePolicy;
        /// using (Stream stream = policy.EncodedPolicy.ToStream())
        /// {
        ///     using FileStream file = File.OpenWrite(&quot;policy.dat&quot;);
        ///     stream.CopyTo(file);
        /// }
        /// </code>
        /// </example>
        public BinaryData EncodedPolicy { get; private set; }

        /// <summary>
        /// Gets or sets the mutability state of the policy. Once marked immutable, this flag cannot be reset and the policy cannot be changed under any circumstances.
        /// </summary>
        public bool? Immutable { get; set; }

        internal void ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case ContentTypePropertyName:
                        ContentType = prop.Value.GetString();
                        break;

                    case DataPropertyName:
                        byte[] data = Base64Url.Decode(prop.Value.GetString());
                        EncodedPolicy = new BinaryData(data);
                        break;

                    case ImmutablePropertyName:
                        Immutable = prop.Value.GetBoolean();
                        break;
                }
            }
        }

        internal void WriteProperties(Utf8JsonWriter json)
        {
            if (!string.IsNullOrEmpty(ContentType))
            {
                json.WriteString(s_contentTypePropertyNameBytes, ContentType);
            }

            json.WriteString(s_dataPropertyNameBytes, Base64Url.Encode(EncodedPolicy.ToArray()));

            if (Immutable.HasValue)
            {
                json.WriteBoolean(s_immutablePropertyName, Immutable.Value);
            }
        }

        void IJsonDeserializable.ReadProperties(JsonElement json) => ReadProperties(json);

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json) => WriteProperties(json);
    }
}
