// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientModel.ReferenceClients.SimpleClient;

internal class LoggingOptionsResolver
{
    private readonly IEnumerable<ClientLoggingOptions> _optionsInstances;

    public LoggingOptionsResolver(IEnumerable<ClientLoggingOptions> optionsInstances)
    {
        _optionsInstances = optionsInstances;
    }

    public void GetPolicy()
    {
    }
}
