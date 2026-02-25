// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable OPENAI001

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("OpenAPIFunctionDefinition")]
public partial class OpenAPIFunctionDefinition
{
    /// <summary> Initializes a new instance of <see cref="OpenAPIFunctionDefinition"/>. </summary>
    /// <param name="name"> The name of the function to be called. </param>
    /// <param name="specificationBytes"> The openapi function shape, described as a JSON Schema object. </param>
    /// <param name="authentication"> Open API authentication details. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="specificationBytes"/> or <paramref name="authentication"/> is null. </exception>
    public OpenAPIFunctionDefinition(string name, BinaryData specificationBytes, OpenAPIAuthenticationDetails authentication)
        : this(name, BinaryDataToDictionary(specificationBytes), authentication)
    {
    }

    private static Dictionary<string, BinaryData> BinaryDataToDictionary(BinaryData dictionaryBytes)
    {
        using JsonDocument document = JsonDocument.Parse(dictionaryBytes);
        if (document.RootElement.ValueKind == JsonValueKind.Object)
        {
            var dictionary = new Dictionary<string, BinaryData>();
            foreach (JsonProperty property in document.RootElement.EnumerateObject())
            {
                dictionary[property.Name] = BinaryData.FromString(property.Value.GetRawText());
            }
            return dictionary;
        }
        return null;
    }
}
