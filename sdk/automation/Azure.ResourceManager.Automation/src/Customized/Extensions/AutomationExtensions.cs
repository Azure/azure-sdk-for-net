// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

#pragma warning disable CS0618
#pragma warning disable CS1591

namespace Azure.ResourceManager.Automation
{
    public static partial class AutomationExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public static DscCompilationJobResource GetDscCompilationJobResource(this ArmClient client, ResourceIdentifier id)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }
    }
}

#pragma warning restore CS0618
#pragma warning restore CS1591
