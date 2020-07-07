// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Host.Configuration
{
    public interface IWebJobsExtensionConfiguration<T> where T : IExtensionConfigProvider
    {
        IConfigurationSection ConfigurationSection { get; }
    }
}
