// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Azure.WebJobs.Host.Bindings.Path;
using Microsoft.Azure.WebJobs.Host.Tables;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    internal class ODataFilterResolutionPolicy : IResolutionPolicy
    {
        public string TemplateBind(PropertyInfo propInfo, Attribute attribute, BindingTemplate template, IReadOnlyDictionary<string, object> bindingData)
        {
            return TableFilterFormatter.Format(template, bindingData);
        }
    }
}
