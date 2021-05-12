// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

#nullable disable

namespace Azure.Communication
{
    internal partial class PhoneNumberIdentifierModel
    {
        internal static PhoneNumberIdentifierModel DeserializePhoneNumberIdentifierModel(JsonElement element)
        {
            string value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    value = property.Value.GetString();
                    continue;
                }
            }
            return new PhoneNumberIdentifierModel(value);
        }
    }
}
