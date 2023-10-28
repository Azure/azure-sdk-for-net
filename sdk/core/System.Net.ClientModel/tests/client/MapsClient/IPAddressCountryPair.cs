// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.ClientModel.Core;

namespace Maps;

public class IPAddressCountryPair
{
    public string IsoCode { get; internal set; }

    internal static IPAddressCountryPair FromResponse(PipelineResponse response)
    {
        throw new NotImplementedException();
    }
}
