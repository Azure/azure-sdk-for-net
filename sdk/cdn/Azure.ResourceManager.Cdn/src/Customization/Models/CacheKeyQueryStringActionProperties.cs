// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
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
