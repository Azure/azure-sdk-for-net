//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

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