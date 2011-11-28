//-----------------------------------------------------------------------
// <copyright file="SharedAccessPolicies.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the SharedAccessPolicies class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the collection of shared access policies defined for a container.
    /// </summary>
    [Serializable]
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Microsoft.Naming",
        "CA1710:IdentifiersShouldHaveCorrectSuffix",
        Justification = "Public APIs should not expose base collection types.")]
    public class SharedAccessPolicies : Dictionary<string, SharedAccessPolicy>
    {
    }
}