// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    public interface IFunctionInstanceFactory
    {
        IFunctionInstance Create(FunctionInstanceFactoryContext context);
    }
}
