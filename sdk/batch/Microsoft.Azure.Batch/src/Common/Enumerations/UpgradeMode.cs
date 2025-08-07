// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;

    /// <summary>
    /// Defines values for SecurityTypes.
    /// </summary>
    public enum UpgradeMode
    {
        /// <summary>
        /// All virtual machines in the scale set are automatically updated at
        /// the same time.
        /// </summary>
        Automatic,

        /// <summary>
        /// You control the application of updates to virtual machines in the
        /// scale set. You do this by using the manualUpgrade action.
        /// </summary>
        Manual,

        /// <summary>
        /// The existing instances in a scale set are brought down in batches
        /// to be upgraded. Once the upgraded batch is complete, the instances
        /// will begin taking traffic again and the next batch will begin. This
        /// continues until all instances brought up-to-date.
        /// </summary>
        Rolling
    }
}
