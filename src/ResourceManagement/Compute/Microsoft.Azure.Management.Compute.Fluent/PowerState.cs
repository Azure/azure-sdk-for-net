// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    public enum PowerState
    {
        [EnumName("PowerState/unknown")]
        UNKNOWN,
        [EnumName("PowerState/running")]
        RUNNING,
        [EnumName("PowerState/deallocating")]
        DEALLOCATING,
        [EnumName("PowerState/deallocated")]
        DEALLOCATED,
        [EnumName("PowerState/starting")]
        STARTING
    }
}
