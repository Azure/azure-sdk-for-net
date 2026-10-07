// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.BotService.Models
{
    public static partial class ArmBotServiceModelFactory
    {
        /// <param name="etag"> Entity Tag of the resource. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <param name="location"> Specifies the location of the resource. </param>
        /// <returns> A new <see cref="Models.Omnichannel"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This class is obsolete and will be removed in a future version. Please use the Dynamics365OmnichannelChannel instead.")]
        public static Omnichannel Omnichannel(ETag? etag = default, string provisioningState = default, AzureLocation? location = default)
        {
            return new Omnichannel(default, etag, provisioningState, location, default);
        }
    }
}
