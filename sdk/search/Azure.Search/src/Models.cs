// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

// I'm having trouble getting the CodeGenSchema attribute picked up when I
// place these definitions in the Models folder so I'm grouping them all here
// temporarily.
#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Models
{
    [CodeGenSchema("ServiceStatistics")]
    public partial class SearchServiceStatistics { }

    [CodeGenSchema("ServiceCounters")]
    public partial class SearchServiceCounters { }

    [CodeGenSchema("ServiceLimits")]
    public partial class SearchServiceLimits { }

    [CodeGenSchema("ResourceCounter")]
    public partial class SearchResourceCounter { }
}
