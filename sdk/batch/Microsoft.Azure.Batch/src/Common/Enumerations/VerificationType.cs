// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// The verification type of an Azure Batch Image.
    /// </summary>
    public enum VerificationType
    {
        /// <summary>
        /// The Image is guaranteed to be compatible with the associated node
        /// agent SKU and all Batch features have been confirmed to work as
        /// expected.
        /// </summary>
        Verified,

        /// <summary>
        /// The associated node agent SKU should have binary compatibility with
        /// the Image, but specific functionality has not been verified.
        /// </summary>
        Unverified
    }
}
