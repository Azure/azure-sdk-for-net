// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ProviderHub
{
    // Suppress tag methods - this resource has a bodyless PATCH and no resource-level PUT,
    // so tag methods cannot function. Matches pre-migration SDK behavior.
    [CodeGenSuppress("AddTagAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("AddTag", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("SetTagsAsync", typeof(IDictionary<string, string>), typeof(CancellationToken))]
    [CodeGenSuppress("SetTags", typeof(IDictionary<string, string>), typeof(CancellationToken))]
    [CodeGenSuppress("RemoveTagAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("RemoveTag", typeof(string), typeof(CancellationToken))]
    public partial class ProviderMonitorSettingResource
    {
    }
}
