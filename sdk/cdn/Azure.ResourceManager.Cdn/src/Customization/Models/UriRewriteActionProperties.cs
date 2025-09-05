// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
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