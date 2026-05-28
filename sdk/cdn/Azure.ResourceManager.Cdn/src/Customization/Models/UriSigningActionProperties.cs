// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class UriSigningActionProperties
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriSigningActionProperties(UriSigningActionType actionType) : this()
        {
            ActionType = actionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriSigningActionType ActionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}