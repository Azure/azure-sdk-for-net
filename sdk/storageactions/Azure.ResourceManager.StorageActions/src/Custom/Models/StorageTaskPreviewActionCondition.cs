// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.StorageActions.Models
{
    public partial class StorageTaskPreviewActionCondition
    {
        /// <summary> Initializes a new instance of <see cref="StorageTaskPreviewActionCondition"/>. </summary>
        /// <param name="if"> The condition to be tested for a match with container and blob properties. </param>
        /// <param name="elseBlockExists"> Specify whether the else block is present in the condition. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="if"/> is null. </exception>
        public StorageTaskPreviewActionCondition(StorageTaskPreviewActionIfCondition @if, bool elseBlockExists)
        {
            Argument.AssertNotNull(@if, nameof(@if));

            If = @if;
            ElseBlockExists = elseBlockExists;
        }
    }
}
