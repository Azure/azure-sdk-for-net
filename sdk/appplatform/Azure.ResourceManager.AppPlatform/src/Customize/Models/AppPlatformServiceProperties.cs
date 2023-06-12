// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppPlatform.Models
{
    public partial class AppPlatformServiceProperties
    {
        /// <summary> DEPRECATED: ServiceInstanceEntity GUID which uniquely identifies a created resource.</summary>
        /// <remarks><see cref="FormatException">FormatException</see> will be thrown if response is not a GUID format.</remarks>
        [Obsolete("'ServiceId' is deprecated. Use 'ServiceInstanceId' instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Guid? ServiceId => ServiceInstanceId != null ? Guid.Parse(ServiceInstanceId) : null;
    }
}
