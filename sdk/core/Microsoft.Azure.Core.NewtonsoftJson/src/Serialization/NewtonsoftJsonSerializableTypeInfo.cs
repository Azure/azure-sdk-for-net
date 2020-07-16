// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Serialization;

namespace Azure.Core.Serialization
{
    internal class NewtonsoftJsonSerializableTypeInfo : SerializableTypeInfo
    {
        public NewtonsoftJsonSerializableTypeInfo(JsonContract contract)
        {
            Type = contract.UnderlyingType;

            if (contract is JsonObjectContract objectContract)
            {
                Properties = objectContract.Properties
                    .Select(property => new NewtonsoftJsonSerializablePropertyInfo(property))
                    .ToArray();
            }
            else if (contract is JsonContainerContract containerContract)
            {
                Properties = Array.Empty<NewtonsoftJsonSerializablePropertyInfo>();

                IsCollection = true;
            }
            else if (contract is JsonPrimitiveContract)
            {
                Properties = Array.Empty<NewtonsoftJsonSerializablePropertyInfo>();

                IsPrimitive = true;
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public override Type Type { get; }

        public override IReadOnlyCollection<SerializablePropertyInfo> Properties { get; }

        public override bool IsPrimitive { get; }

        public override bool IsCollection { get; }
    }
}
