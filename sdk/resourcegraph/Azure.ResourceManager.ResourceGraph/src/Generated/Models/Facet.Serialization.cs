// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;

namespace Azure.ResourceManager.ResourceGraph.Models
{
    public partial class Facet
    {
        internal static Facet DeserializeFacet(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("resultType", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "FacetError": return FacetError.DeserializeFacetError(element);
                    case "FacetResult": return FacetResult.DeserializeFacetResult(element);
                }
            }
            return UnknownFacet.DeserializeUnknownFacet(element);
        }
    }
}
