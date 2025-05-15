// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class CacheKeyQueryStringActionProperties
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CacheKeyQueryStringActionProperties(CacheKeyQueryStringActionType type, QueryStringBehavior queryStringBehavior) : this(queryStringBehavior)
        {
            CacheKeyQueryStringAction = type;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public CacheKeyQueryStringActionType CacheKeyQueryStringAction
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}
