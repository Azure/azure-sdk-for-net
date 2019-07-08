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
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Management.RecoveryServices.Tests
{
    public static class TestUtilities
    {
        public static string GenerateRandomKey(int size)
        {
            Random rand = new Random();
            var len = (int)size / 8;
            byte[] key = new byte[len];
            for (int i = 0; i < len; i++)
            {
                key[i] = (byte)(rand.Next() % 128);
            }
            return Convert.ToBase64String(key);
        }
    }
}
