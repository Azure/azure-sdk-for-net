// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Compute.Admin;
using Microsoft.AzureStack.Management.Compute.Admin.Models;
using System.Linq;
using System.Net;
using Xunit;

namespace Compute.Tests
{
    public class QuotaTests : ComputeTestBase
    {
        // Helper
        private Quota Create(int asc, int cl, int vssc, int vmc, int smds, int pmds) {
            var newQuota = new Quota()
            {
                AvailabilitySetCount = asc,
                CoresLimit = cl,
                VmScaleSetCount = vssc,
                VirtualMachineCount = vmc,
                MaxAllocationStandardManagedDisksAndSnapshots =smds,
                MaxAllocationPremiumManagedDisksAndSnapshots = pmds
            };
            return newQuota;
        }


        private void ValidateQuota(Quota quota) {
            AssertValidResource(quota);
            Assert.NotNull(quota);
            Assert.NotNull(quota.AvailabilitySetCount);
            Assert.NotNull(quota.CoresLimit);
            Assert.NotNull(quota.VirtualMachineCount);
            Assert.NotNull(quota.VmScaleSetCount);
            Assert.NotNull(quota.MaxAllocationStandardManagedDisksAndSnapshots);
            Assert.NotNull(quota.MaxAllocationPremiumManagedDisksAndSnapshots);
        }

        private void AssertSame(Quota expected, Quota given, bool resourceToo = true) {
            if (resourceToo)
            {
                AssertSameResource(expected, given);
            }
            if (expected == null)
            {
                Assert.Null(given);
            }
            else
            {
                Assert.NotNull(given);
                Assert.Equal(expected.AvailabilitySetCount, given.AvailabilitySetCount);
                Assert.Equal(expected.CoresLimit, given.CoresLimit);
                Assert.Equal(expected.VirtualMachineCount, given.VirtualMachineCount);
                Assert.Equal(expected.VmScaleSetCount, given.VmScaleSetCount);
                Assert.Equal(expected.MaxAllocationStandardManagedDisksAndSnapshots, given.MaxAllocationStandardManagedDisksAndSnapshots);
                Assert.Equal(expected.MaxAllocationPremiumManagedDisksAndSnapshots, given.MaxAllocationPremiumManagedDisksAndSnapshots);
            }
        }

        [Fact]
        public void TestListQuotas() {
            RunTest((client) => {

                var quotas = client.Quotas.List("local");
                Assert.NotNull(quotas);
                quotas.ForEach(ValidateQuota);
            });
        }

        [Fact]
        public void TestGetQuota() {
            RunTest((client) => {
                var quota = client.Quotas.List("local").FirstOrDefault();
                var result = client.Quotas.Get("local", quota.Name);
                AssertSame(quota, result);
            });
        }

        [Fact]
        public void TestGetAllQuotas() {
            RunTest((client) => {
                var quotas = client.Quotas.List("local");
                quotas.ForEach((quota) => {
                    var result = client.Quotas.Get("local", quota.Name);
                    AssertSame(quota, result);
                });
            });
        }

        private void ValidateAgainstData(Quota q, int[] d) {
            Assert.Equal(q.AvailabilitySetCount, d[0]);
            Assert.Equal(q.CoresLimit, d[1]);
            Assert.Equal(q.VmScaleSetCount, d[2]);
            Assert.Equal(q.VirtualMachineCount, d[3]);
            Assert.Equal(q.MaxAllocationStandardManagedDisksAndSnapshots, d[4]);
            Assert.Equal(q.MaxAllocationPremiumManagedDisksAndSnapshots, d[5]);
        }

        [Fact]
        public void CreateUpdateDeleteQuota() {
            RunTest((client) => {
                var location = "local";
                var name = "testQuotaCreateUpdateDelete";
                var data = new int[]{1,1,1,1,1,1 };
                var newQuota = Create(data[0], data[1], data[2], data[3], data[4], data[5]);
                var quota = client.Quotas.CreateOrUpdate(location, name, newQuota);
                ValidateAgainstData(quota, data);
                AssertSame(newQuota, quota, false);

                quota.VirtualMachineCount += 1;
                quota = client.Quotas.CreateOrUpdate(location, name, quota);
                data[3] += 1;
                ValidateAgainstData(quota, data);

                quota.AvailabilitySetCount += 1;
                quota = client.Quotas.CreateOrUpdate(location, name, quota);
                data[0] += 1;
                ValidateAgainstData(quota, data);

                quota.VmScaleSetCount += 1;
                quota = client.Quotas.CreateOrUpdate(location, name, quota);
                data[2] += 1;
                ValidateAgainstData(quota, data);

                quota.CoresLimit+= 1;
                quota = client.Quotas.CreateOrUpdate(location, name, quota);
                data[1] += 1;
                ValidateAgainstData(quota, data);

                quota.MaxAllocationStandardManagedDisksAndSnapshots+= 1;
                quota = client.Quotas.CreateOrUpdate(location, name, quota);
                data[4] += 1;
                ValidateAgainstData(quota, data);

                quota.MaxAllocationPremiumManagedDisksAndSnapshots += 1;
                quota = client.Quotas.CreateOrUpdate(location, name, quota);
                data[5] += 1;
                ValidateAgainstData(quota, data);
                client.Quotas.Delete(location, name);
            });
        }

        [Fact]
        public void TestCreateQuota() {
            RunTest((client) => {

                var location = "local";
                var quotaNamePrefix = "testQuota";

                var data = new System.Collections.Generic.List<int[]>  {
                    new [] { 0, 0, 0, 0, 0, 0, 0 },
                    new [] { 1, 0, 0, 0, 0, 0, 1 },
                    new [] { 0, 1, 0, 0, 0, 0, 2 },
                    new [] { 0, 0, 1, 0, 0, 0, 3 },
                    new [] { 0, 0, 0, 1, 0, 0, 4 },
                    new [] { 0, 0, 0, 0, 1, 0, 5 },
                    new [] { 0, 0, 0, 0, 0, 1, 6 },
                    new [] { 100, 100, 100, 100 ,100, 100,  7 },
                    new [] { 1000, 1000, 1000, 1000, 1000, 1000, 8 }
                };

                data.ForEach((d) => {
                    var name = quotaNamePrefix + d[6];
                    var newQuota = Create(d[0], d[1], d[2], d[3], d[4], d[5]);
                    var quota = client.Quotas.CreateOrUpdate(location, name, newQuota);
                    ValidateAgainstData(quota, d);
                    var result = client.Quotas.Get(location, name);
                    AssertSame(quota, result, false);
                });

                data.ForEach((d) => {
                    var name = quotaNamePrefix + d[6];
                    var list = client.Quotas.List(location);
                    Assert.Equal(1, list.Count((q) => q.Name.Equals(name)));
                });

                data.ForEach((d) => {
                    var name = quotaNamePrefix + d[6];
                    client.Quotas.Delete(location, name);
                    ValidateExpectedReturnCode(
                        () => client.Quotas.Get(location, name),
                        HttpStatusCode.NotFound
                        );
                });
            });
        }

        #region Test With Invalid data


        [Fact]
        public void TestCreateInvalidQuota() {
            RunTest((client) => {
                var name = "myQuota";
                Assert.ThrowsAny<System.Exception>(() => client.Quotas.CreateOrUpdate("local", name, Create(-1, 1, 1, 1, 1, 1)));
                Assert.ThrowsAny<System.Exception>(() => client.Quotas.CreateOrUpdate("local", name, Create(1, -1, 1, 1, 1, 1)));
                Assert.ThrowsAny<System.Exception>(() => client.Quotas.CreateOrUpdate("local", name, Create(1, 1, -1, 1, 1, 1)));
                Assert.ThrowsAny<System.Exception>(() => client.Quotas.CreateOrUpdate("local", name, Create(1, 1, 1, -1, 1, 1)));
                Assert.ThrowsAny<System.Exception>(() => client.Quotas.CreateOrUpdate("local", name, Create(1, 1, 1, 1, -1, 1)));
                Assert.ThrowsAny<System.Exception>(() => client.Quotas.CreateOrUpdate("local", name, Create(1, 1, 1, 1, 1, -1)));

                Assert.ThrowsAny<System.Exception>(() => client.Quotas.CreateOrUpdate("local", name, Create(-1, 0, 0, 0, 0, 0)));
                Assert.ThrowsAny<System.Exception>(() => client.Quotas.CreateOrUpdate("local", name, Create(0, -1, 0, 0, 0, 0)));
                Assert.ThrowsAny<System.Exception>(() => client.Quotas.CreateOrUpdate("local", name, Create(0, 0, -1, 0, 0, 0)));
                Assert.ThrowsAny<System.Exception>(() => client.Quotas.CreateOrUpdate("local", name, Create(0, 0, 0, -1, 0, 0)));
                Assert.ThrowsAny<System.Exception>(() => client.Quotas.CreateOrUpdate("local", name, Create(0, 0, 0, 0, -1, 0)));
                Assert.ThrowsAny<System.Exception>(() => client.Quotas.CreateOrUpdate("local", name, Create(0, 0, 0, 0, 0, -1)));

                Assert.ThrowsAny<System.Exception>(() => client.Quotas.CreateOrUpdate("local", name, Create(-1, -1, -1, -1, -1, -1)));

            });
        }

        // Invalid Locations

        [Fact(Skip = "CRP does not handle invalid locations correctly.")]
        public void TestListInvalidLocation() {
            RunTest((client) => {
                var list = client.Quotas.List("thisisnotarealplace");
                Assert.Empty(list);
            });
        }

        [Fact]
        public void TestDeleteNonExistingQuota() {
            RunTest((client) => {
                ValidateExpectedReturnCode(
                    () => client.Quotas.Delete("local", "thisdoesnotexistandifitdoesoops"),
                    HttpStatusCode.NotFound
                    );
                
            });
        }

        [Fact(Skip = "CRP does not handle invalid locations correctly.")]
        public void TestCreateQuotaOnInvalidLocation() {
            RunTest((client) => {

                var location = "thislocationdoesnotexist";
                var quotaNamePrefix = "testQuota";

                var data = new System.Collections.Generic.List<int[]>  {
                    new [] { 0, 0, 0, 0, 0, 0, 0 },
                    new [] { 1, 0, 0, 0, 0, 0, 1 },
                    new [] { 0, 1, 0, 0, 0, 0, 2 },
                    new [] { 0, 0, 1, 0, 0, 0, 3 },
                    new [] { 0, 0, 0, 1, 0, 0, 4 },
                    new [] { 0, 0, 0, 0, 1, 0, 5 },
                    new [] { 0, 0, 0, 0, 0, 1, 6 },
                    new [] { 100, 100, 100, 100 ,100, 100,  7 },
                    new [] { 1000, 1000, 1000, 1000, 1000, 1000, 8 }
                };

                data.ForEach((d) => {
                    var name = quotaNamePrefix + d[6];
                    var newQuota = Create(d[0], d[1], d[2], d[3], d[4], d[5]);
                    var quota = client.Quotas.CreateOrUpdate(location, name, newQuota);
                    var result = client.Quotas.Get(location, name);
                    Assert.Null(quota);
                    Assert.Null(result);
                });

                data.ForEach((d) => {
                    var name = quotaNamePrefix + d[6];
                    var list = client.Quotas.List(location);
                    Assert.Equal(0, list.Count((q) => q.Name.Equals(name)));
                });

            });
        }

        #endregion

    }
}
