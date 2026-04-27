// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds the old constructor and ActionType property to OriginGroupOverrideActionProperties for backward API compatibility with the previous SDK.
    // Reason: The old SDK used the OriginGroupOverrideActionType struct as the discriminator (actionType),
    // with a constructor that included actionType as a parameter.
    // After the TypeSpec migration, the discriminator was changed to the string-typed TypeName property.
    // The old constructor and ActionType property (bridging to TypeName) are preserved here, marked as EditorBrowsable.Never.
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
                OriginGroup = new CdnResourceReference { Id = originGroup.Id };
            }
        }

        // Backward compatibility: old API had ctor(WritableSubResource)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OriginGroupOverrideActionProperties(WritableSubResource originGroup) : this()
        {
            if (originGroup != null)
            {
                OriginGroup = new CdnResourceReference { Id = originGroup.Id };
            }
        }
    }
}
