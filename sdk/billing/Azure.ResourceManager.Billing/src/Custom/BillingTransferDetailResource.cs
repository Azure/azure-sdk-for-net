// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Billing
{
    // Generator bug: MPG emits AddTag/SetTags/RemoveTag because the resource data carries a
    // `tags` field, then PopulateUpdateMethod() falls back to PUT (Transfers_Initiate). The
    // tag-helper else-branch calls this.Update(WaitUntil, <Data>, CT) but the actual Update
    // takes BillingTransferDetailCreateOrUpdateContent (separate Request body), producing
    // CS1503. Suppress the 6 helpers entirely — GA 1.2.2 never exposed them and ARM tags are
    // still reachable via the resource's Tag* extension/TagResource. Remove these suppressions
    // once https://github.com/Azure/azure-sdk-for-net/issues/58747 ships.
    // TODO(#58747): drop the [CodeGenSuppress] block below after the generator fix lands.
    [CodeGenSuppress("AddTagAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("AddTag", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("SetTagsAsync", typeof(IDictionary<string, string>), typeof(CancellationToken))]
    [CodeGenSuppress("SetTags", typeof(IDictionary<string, string>), typeof(CancellationToken))]
    [CodeGenSuppress("RemoveTagAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("RemoveTag", typeof(string), typeof(CancellationToken))]
    public partial class BillingTransferDetailResource
    {
    }
}
