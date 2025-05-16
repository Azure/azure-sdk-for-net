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
            CacheExpirationAction = actionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public CacheExpirationActionType CacheExpirationAction
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}
