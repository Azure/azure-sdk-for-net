// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class UriRewriteActionProperties
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriRewriteActionProperties(UriRewriteActionType conditionType, string sourcePattern, string destination) : this(sourcePattern, destination)
        {
            UriRewriteActionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriRewriteActionType UriRewriteActionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}