// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class HeaderActionProperties {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HeaderActionProperties(HeaderActionType actionType, HeaderAction headerAction, string headerName) : this(headerAction, headerName)
        {
            ActionType = actionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HeaderActionType ActionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}