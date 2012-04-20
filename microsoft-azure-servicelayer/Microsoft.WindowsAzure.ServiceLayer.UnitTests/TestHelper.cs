//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests
{
    /// <summary>
    /// Helper methods for unit tests.
    /// </summary>
    internal static class TestHelper
    {
        internal static void Equal<T>(IList<T> items1, IList<T> items2)
        {
            // null == null
            Assert.IsTrue(items1 == null && items2 == null || items1 != null && items2 != null);

            // Same number of items.
            Assert.AreEqual(items1.Count, items2.Count);

            // Same items
            for (int i = 0; i < items1.Count; i++)
            {
                Assert.AreEqual<T>(items1[i], items2[i]);
            }
        }
    }
}
