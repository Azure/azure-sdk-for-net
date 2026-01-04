// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.ResourceManager.StorageActions.Models
{
    public partial class StorageTaskAction
    {
        /// <summary> List of operations to execute in the else block. </summary>
        public IList<StorageTaskOperationInfo> ElseOperations
        {
            get
            {
                return Else is null ? default : Else.Operations;
            }
            set
            {
                Else = new StorageTaskElseCondition(value);
            }
        }
    }
}
