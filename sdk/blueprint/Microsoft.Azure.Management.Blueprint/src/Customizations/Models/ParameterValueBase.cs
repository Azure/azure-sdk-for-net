// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json;

namespace Microsoft.Azure.Management.Blueprint.Models
{
    [JsonConverter(typeof(ParameterValueJsonConverter))]
    public abstract partial class ParameterValueBase
    {
    }
}