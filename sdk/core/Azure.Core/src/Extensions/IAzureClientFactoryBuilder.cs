﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Extensions
{
    public interface IAzureClientFactoryBuilder
    {
        IAzureClientBuilder<TClient, TOptions> RegisterClientFactory<TClient, TOptions>(Func<TOptions, TClient> clientFactory) where TOptions : class;
    }
}
