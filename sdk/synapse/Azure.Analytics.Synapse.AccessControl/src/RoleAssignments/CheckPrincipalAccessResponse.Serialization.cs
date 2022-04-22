// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Analytics.Synapse.AccessControl
{
    public partial class CheckPrincipalAccessResponse
    {
        internal static CheckPrincipalAccessResponse DeserializeCheckPrincipalAccessResponse(JsonElement element)
        {
            Optional<IReadOnlyList<CheckAccessDecision>> accessDecisions = default;
            foreach (var property in element.EnumerateObject())
            {
                // Modification to generated code.
                // Tracked by https://github.com/Azure/azure-sdk-for-net/issues/24712
                if (property.NameEquals("AccessDecisions"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<CheckAccessDecision> array = new List<CheckAccessDecision>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CheckAccessDecision.DeserializeCheckAccessDecision(item));
                    }
                    accessDecisions = array;
                    continue;
                }
            }
            return new CheckPrincipalAccessResponse(Optional.ToList(accessDecisions));
        }
    }
}
