// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Hyak.Common;
using Microsoft.Azure.Management.Automation;
using Microsoft.Azure.Management.Automation.Models;

namespace Microsoft.Azure.Management.Automation
{
    public partial class AutomationManagementClient
    {
        public static List<T> ContinuationTokenHandler<T>(Func<string, ResponseWithSkipToken<T>> listFunc)
        {
            var models = new List<T>();
            string skipToken = null;
            do
            {
                var result = listFunc.Invoke(skipToken);
                models.AddRange(result.AutomationManagementModels);
                skipToken = result.SkipToken;
            }
            while (!string.IsNullOrEmpty(skipToken));
            return models;
        }
    }
}