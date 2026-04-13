// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds the old constructor and ActionType property to UriRedirectActionProperties for backward API compatibility with the previous SDK.
    // Reason: The old SDK used the UriRedirectActionType struct as the discriminator (actionType),
    // with a constructor that included actionType as a parameter.
    // After the TypeSpec migration, the discriminator was changed to the string-typed TypeName property.
    // The old constructor and ActionType property (bridging to TypeName) are preserved here, marked as EditorBrowsable.Never.
    public partial class UriRedirectActionProperties
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriRedirectActionProperties(UriRedirectActionType actionType, RedirectType redirectType) : this(redirectType)
        {
            ActionType = actionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriRedirectActionType ActionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}
