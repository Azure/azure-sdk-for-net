// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageCache.Tests
{
    internal static class AzureResourceTestHelper
    {
        public static async Task TestGetAll<T>(int count, Func<int, Task<T>> createFunc, Func<AsyncPageable<T>> getAllFunc) where T:ArmResource
        {
            List<T> created = new List<T>();
            for (int i = 0; i < count; i++)
            {
                created.Add(await createFunc(i));
            }

            AsyncPageable<T> retrieved = getAllFunc();

            int foundCount = 0;
            await foreach (T scr in retrieved)
            {
                T found = created.FirstOrDefault(cur => cur.Id == scr.Id);
                Assert.IsTrue(found != null);
                created.Remove(found);
                foundCount++;
            }
            Assert.AreEqual(count, foundCount);
        }

        public static async Task TestExists<T>(Func<Task<T>> createFunc, Func<Task<bool>> existsFunc)
        {
            bool result = await existsFunc();
            Assert.IsFalse(result);

            T res = await createFunc();
            result = await existsFunc();

            Assert.IsTrue(result);
        }

        public static async Task TestDelete<T>(Func<Task<T>> createFunc, Func<T, Task<ArmOperation>> deleteFunc, Func<T, Task<T>> getFunc)
        {
            T res = await createFunc();

            T gotBeforeDelete = await getFunc(res);
            Assert.IsNotNull(gotBeforeDelete);

            var operation = await deleteFunc(res);
            Assert.IsFalse(operation.WaitForCompletionResponse().IsError);

            try
            {
                T gotAfterDelete = await getFunc(res);
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(e.Status, 404);
            }
        }
    }
}
