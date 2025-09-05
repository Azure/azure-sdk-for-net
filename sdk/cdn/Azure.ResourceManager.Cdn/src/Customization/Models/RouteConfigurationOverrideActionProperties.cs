// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class RouteConfigurationOverrideActionProperties
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RouteConfigurationOverrideActionProperties(RouteConfigurationOverrideActionType actionType) : this()
        {
            ActionType = actionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RouteConfigurationOverrideActionType ActionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}