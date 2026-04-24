// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds the old constructor and ActionType property to UriRewriteActionProperties for backward API compatibility with the previous SDK.
    // Reason: The old SDK used the UriRewriteActionType struct as the discriminator (actionType),
    // with a constructor that included actionType as a parameter.
    // After the TypeSpec migration, the discriminator was changed to the string-typed TypeName property.
    // The old constructor and ActionType property (bridging to TypeName) are preserved here, marked as EditorBrowsable.Never.
    public partial class UriRewriteActionProperties
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriRewriteActionProperties(UriRewriteActionType actionType, string sourcePattern, string destination) : this(sourcePattern, destination)
        {
            ActionType = actionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriRewriteActionType ActionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}
