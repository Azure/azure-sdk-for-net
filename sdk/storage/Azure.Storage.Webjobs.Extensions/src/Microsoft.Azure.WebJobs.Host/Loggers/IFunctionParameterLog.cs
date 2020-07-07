// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host.Timers;

namespace Microsoft.Azure.WebJobs.Host.Loggers
{
    internal interface IFunctionParameterLog : IDisposable
    {
        IRecurrentCommand UpdateCommand { get; }

        void Close();
    }
}
