// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System.Reflection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class MyCustomContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            CustomFieldAttribute customField = member.GetCustomAttribute<CustomFieldAttribute>();

            if (customField != null)
            {
                if (customField.ShouldIgnore)
                {
                    return null;
                }

                property.PropertyName = customField.FieldName;
            }

            return property;
        }
    }
}
