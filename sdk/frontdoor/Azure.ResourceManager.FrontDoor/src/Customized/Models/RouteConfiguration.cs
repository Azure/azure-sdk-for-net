// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: the baseline SDK had a protected no-arg constructor on
// RouteConfiguration, making it extensible. The generated code only has private
// protected/internal constructors, which makes it effectively sealed. Adding the
// protected constructor restores backward compatibility.

namespace Azure.ResourceManager.FrontDoor.Models
{
    public abstract partial class RouteConfiguration
    {
        /// <summary> Initializes a new instance of <see cref="RouteConfiguration"/>. </summary>
        protected RouteConfiguration()
        {
        }
    }
}
