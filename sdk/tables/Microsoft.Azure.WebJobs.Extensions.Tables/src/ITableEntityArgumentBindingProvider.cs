// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Reflection;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal interface ITableEntityArgumentBindingProvider
    {
        IArgumentBinding<TableEntityContext> TryCreate(ParameterInfo parameter);
    }
}