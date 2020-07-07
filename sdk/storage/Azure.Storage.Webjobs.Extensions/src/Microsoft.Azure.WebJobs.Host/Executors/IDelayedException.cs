// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    public interface IDelayedException
    {
        Exception Exception { get; }
        void Throw();
    }
}
