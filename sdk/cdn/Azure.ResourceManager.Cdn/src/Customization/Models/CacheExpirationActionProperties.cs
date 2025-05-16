// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class CacheExpirationActionProperties
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CacheExpirationActionProperties(CacheExpirationActionType actionType, CacheBehaviorSetting cacheBehavior, CdnCacheLevel cacheType) : this(cacheBehavior, cacheType)
        {
            ActionType = actionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public CacheExpirationActionType ActionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}
