// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class OriginGroupOverrideActionProperties
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OriginGroupOverrideActionProperties(OriginGroupOverrideActionType actionType, WritableSubResource originGroup) : this(originGroup)
        {
            ActionType = actionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public OriginGroupOverrideActionType ActionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}