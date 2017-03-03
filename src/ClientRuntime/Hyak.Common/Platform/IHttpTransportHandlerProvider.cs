// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Net.Http;

namespace Hyak.Common.Platform
{
    public interface IHttpTransportHandlerProvider
    {
        HttpMessageHandler CreateHttpTransportHandler();
    }
}
