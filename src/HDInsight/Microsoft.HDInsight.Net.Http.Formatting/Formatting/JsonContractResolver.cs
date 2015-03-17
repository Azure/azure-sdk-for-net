// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Formatting
{
    using System;
    using System.Reflection;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Represents the default <see cref="IContractResolver"/> used by <see cref="BaseJsonMediaTypeFormatter"/>.
    /// It uses the formatter's <see cref="IRequiredMemberSelector"/> to select required members and recognizes
    /// the <see cref="SerializableAttribute"/> type annotation.
    /// </summary>
    internal class JsonContractResolver : DefaultContractResolver
    {
        private readonly MediaTypeFormatter _formatter;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonContractResolver" /> class.
        /// </summary>
        /// <param name="formatter">The formatter to use for resolving required members.</param>
        public JsonContractResolver(MediaTypeFormatter formatter)
        {
            if (formatter == null)
            {
                throw Error.ArgumentNull("formatter");
            }

            this._formatter = formatter;
            // Need this setting to have [Serializable] types serialized correctly
            this.IgnoreSerializableAttribute = false;
        }

        // Determines whether a member is required or not and sets the appropriate JsonProperty settings
        private void ConfigureProperty(MemberInfo member, JsonProperty property)
        {
            if (this._formatter.RequiredMemberSelector != null && this._formatter.RequiredMemberSelector.IsRequiredMember(member))
            {
                property.Required = Required.AllowNull;
                property.DefaultValueHandling = DefaultValueHandling.Include;
                property.NullValueHandling = NullValueHandling.Include;
            }
            else
            {
                property.Required = Required.Default;
            }
        }

        /// <inheritdoc />
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            this.ConfigureProperty(member, property);
            return property;
        }
    }
}
