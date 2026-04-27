// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds the old constructor and ActionType property to CacheKeyQueryStringActionProperties for backward API compatibility with the previous SDK.
    // Reason: The old SDK used the CacheKeyQueryStringActionType struct as the discriminator (actionType),
    // with a constructor that included actionType as a parameter.
    // After the TypeSpec migration, the discriminator was changed to the string-typed TypeName property.
    // The old constructor and ActionType property (bridging to TypeName) are preserved here, marked as EditorBrowsable.Never.
    public partial class CacheKeyQueryStringActionProperties
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CacheKeyQueryStringActionProperties(CacheKeyQueryStringActionType actionType, QueryStringBehavior queryStringBehavior) : this(queryStringBehavior)
        {
            ActionType = actionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public CacheKeyQueryStringActionType ActionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}
