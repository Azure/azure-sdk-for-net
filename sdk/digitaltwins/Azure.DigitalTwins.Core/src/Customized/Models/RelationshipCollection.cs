// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    [CodeGenModel("RelationshipCollection")]
    [CodeGenSuppress("DeserializeRelationshipCollection", typeof(JsonElement))]
    [CodeGenSuppress("FromResponse", typeof(Response))]
    internal partial class RelationshipCollection
    {
    }
}
