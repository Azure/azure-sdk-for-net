// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class OriginGroupOverrideActionProperties
    {
        // Backward compatibility: old API had ActionType property and constructor with WritableSubResource
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OriginGroupOverrideActionType ActionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }

        // Backward compatibility: old API had ctor(OriginGroupOverrideActionType, WritableSubResource)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OriginGroupOverrideActionProperties(OriginGroupOverrideActionType actionType, WritableSubResource originGroup) : this()
        {
            ActionType = actionType;
            if (originGroup != null)
            {
                OriginGroup = new ResourceReference { Id = originGroup.Id };
            }
        }

        // Backward compatibility: old API had ctor(WritableSubResource)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OriginGroupOverrideActionProperties(WritableSubResource originGroup) : this()
        {
            if (originGroup != null)
            {
                OriginGroup = new ResourceReference { Id = originGroup.Id };
            }
        }
    }
}
