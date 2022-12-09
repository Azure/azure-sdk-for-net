// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace Azure.Core.TestFramework
{
    internal class InvalidTestClient
    {
        public Task<string> MethodAsync(int i)
        {
            return Task.FromResult("Async " + i);
        }

        public virtual string Method(int i)
        {
            return "Sync " + i;
        }
    }
}
