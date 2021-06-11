// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    public static class AsyncPageableHelper
    {
        public static async Task<int> CountAsync<T>(this AsyncPageable<T> asyncPageable)
        {
            var count = 0;
            await foreach (var item in asyncPageable)
            {
                ++count;
            }
            return count;
        }
    }
}
