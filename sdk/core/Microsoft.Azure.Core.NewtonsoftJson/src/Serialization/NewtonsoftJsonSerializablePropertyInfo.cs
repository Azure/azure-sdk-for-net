// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Serialization;

namespace Azure.Core.Serialization
{
    internal class NewtonsoftJsonSerializablePropertyInfo : SerializablePropertyInfo
    {
        private readonly IAttributeProvider _attributeProvider;

        public NewtonsoftJsonSerializablePropertyInfo(JsonProperty property)
        {
            PropertyType = property.PropertyType;
            PropertyName = property.UnderlyingName;
            SerializedName = property.PropertyName;
            ShouldIgnore = property.Ignored;

            _attributeProvider = property.AttributeProvider;
        }

        public override Type PropertyType { get; }

        public override string PropertyName { get; }

        public override string SerializedName { get; }

        public override bool ShouldIgnore { get; }

        public override IReadOnlyCollection<object> GetAttributes(bool inherit) =>
            _attributeProvider?.GetAttributes(inherit).ToArray() ?? Array.Empty<object>();
    }
}
