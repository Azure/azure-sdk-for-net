// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.DataBox.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmDataBoxModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.DataboxJobSecrets"/>. </summary>
        /// <param name="dataCenterAccessSecurityCode"> Dc Access Security Code for Customer Managed Shipping. </param>
        /// <param name="error"> Error while fetching the secrets. </param>
        /// <param name="podSecrets"> Contains the list of secret objects for a job. </param>
        /// <returns> A new <see cref="Models.DataboxJobSecrets"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This class is method and will be removed in a future release.Please use DataBoxJobSecrets instead.", false)]
        public static DataboxJobSecrets DataboxJobSecrets(DataCenterAccessSecurityCode dataCenterAccessSecurityCode = null, ResponseError error = null, IEnumerable<DataBoxSecret> podSecrets = null)
        {
            podSecrets ??= new List<DataBoxSecret>();

            return new DataboxJobSecrets(DataBoxOrderType.DataBox, dataCenterAccessSecurityCode, error, serializedAdditionalRawData: null, podSecrets?.ToList());
        }
    }
}
