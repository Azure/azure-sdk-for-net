// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
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