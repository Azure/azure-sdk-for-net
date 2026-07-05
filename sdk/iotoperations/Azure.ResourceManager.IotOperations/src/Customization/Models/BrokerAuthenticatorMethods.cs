// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.ResourceManager.IotOperations.Models
{
    public partial class BrokerAuthenticatorMethods
    {
        /// <summary> List of allowed audience. </summary>
        public IList<string> ServiceAccountTokenAudiences
        {
            get
            {
                return ServiceAccountTokenSettings is null ? default : ServiceAccountTokenSettings.Audiences;
            }
            set
            {
                ServiceAccountTokenSettings = new BrokerAuthenticatorMethodSat(value);
            }
        }
    }
}
