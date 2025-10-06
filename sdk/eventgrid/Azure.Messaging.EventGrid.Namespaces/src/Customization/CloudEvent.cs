// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventGrid.Namespaces
{
    // make this type internal because it should be replaced by Azure.Messaging.CloudEvent from Azure.Core assembly
    // rename it so as to not conflict with the CloudEvent type in Azure.Core so that samples can be more user friendly
    [CodeGenType("CloudEvent")]
    internal partial class CloudEventInternal
    {
    }
}
