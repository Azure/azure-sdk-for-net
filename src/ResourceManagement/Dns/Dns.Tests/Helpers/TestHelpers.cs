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

using Microsoft.Azure.Management.Dns.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace Microsoft.Azure.Management.Dns.Testing
{
    public class TestHelpers
    {
        public static bool AreEqualPrereq(
           ResourceBaseExtended first,
           ResourceBaseExtended second,
           bool ignoreEtag = false)
        {
            if (first == null && second == null)
            {
                return true;
            }
            else if (first == null || second == null)
            {
                return false;
            }

            if (first.Location != second.Location
                || first.Name != second.Name)
            {
                return false;
            }

            if (first.Tags != null || second.Tags != null)
            {
                if (first.Tags == null || second.Tags == null || first.Tags.Count != second.Tags.Count)
                {
                    return false;
                }

                foreach (string key in first.Tags.Keys)
                {
                    if (!second.Tags.ContainsKey(key) || first.Tags[key] != second.Tags[key])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool AreEqualPrereq(
           RecordSet first,
           RecordSet second,
           bool ignoreEtag = false)
        {
            if (first == null && second == null)
            {
                return true;
            }
            else if (first == null || second == null)
            {
                return false;
            }

            if (first.Location != second.Location
                || first.Name != second.Name)
            {
                return false;
            }

            if (first.Properties.Metadata != null || second.Properties.Metadata != null)
            {
                if (first.Properties.Metadata == null || second.Properties.Metadata == null || first.Properties.Metadata.Count != second.Properties.Metadata.Count)
                {
                    return false;
                }

                foreach (string key in first.Properties.Metadata.Keys)
                {
                    if (!second.Properties.Metadata.ContainsKey(key) || first.Properties.Metadata[key] != second.Properties.Metadata[key])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool AreEqual(Zone first, Zone second, bool ignoreEtag = false)
        {
            if (!AreEqualPrereq(first, second))
            {
                return false;
            }

            if (first != null && second != null)
            {
                if (first.Properties == null && second.Properties == null)
                {
                    return true;
                }

                if (first.Properties == null || second.Properties == null)
                {
                    return false;
                }

                return ignoreEtag || (first.ETag == second.ETag);
            }

            return true;
        }

        public static bool AreEqual(Models.RecordSet first, Models.RecordSet second, bool ignoreEtag = false)
        {
            if (!AreEqualPrereq(first, second))
            {
                return false;
            }

            if (first != null && second != null)
            {
                if (first.Properties == null && second.Properties == null)
                {
                    return true;
                }

                if (first.Properties == null || second.Properties == null)
                {
                    return false;
                }

                return (ignoreEtag || (first.ETag == second.ETag))
                    && first.Properties.Ttl == second.Properties.Ttl
                    && AreEqual(first.Properties.ARecords, second.Properties.ARecords)
                    && AreEqual(first.Properties.AaaaRecords, second.Properties.AaaaRecords)
                    && AreEqual(first.Properties.MxRecords, second.Properties.MxRecords)
                    && AreEqual(first.Properties.NsRecords, second.Properties.NsRecords)
                    && AreEqual(first.Properties.PtrRecords, second.Properties.PtrRecords)
                    && AreEqual(first.Properties.SrvRecords, second.Properties.SrvRecords)
                    && AreEqual(first.Properties.CnameRecord, second.Properties.CnameRecord)
                    && AreEqual(first.Properties.SoaRecord, second.Properties.SoaRecord);
            }

            return true;
        }

        public static bool AreEqual(CnameRecord first, CnameRecord second)
        {
            if (first == null && second == null)
            {
                return true;
            }
            else if (first == null || second == null)
            {
                return false;
            }

            return first.Cname == second.Cname;
        }

        public static bool AreEqual(SoaRecord first, SoaRecord second)
        {
            if (first == null && second == null)
            {
                return true;
            }
            else if (first == null || second == null)
            {
                return false;
            }

            return first.Email == second.Email
                   && first.ExpireTime == second.ExpireTime
                   && first.Host == second.Host
                   && first.MinimumTtl == second.MinimumTtl
                   && first.RefreshTime == second.RefreshTime
                   && first.RetryTime == second.RetryTime
                   && first.SerialNumber == second.SerialNumber;
        }

        public static bool AreEqualCount<T>(IList<T> first, IList<T> second)
        {
            if ((first == null || first.Count == 0) && (second == null || second.Count == 0))
            {
                return true;
            }
            else if (first == null || second == null || first.Count == 0 || second.Count == 0)
            {
                return false;
            }
            else
            {
                return first.Count == second.Count;
            }
        }

        public static bool AreEqual(IList<ARecord> first, IList<ARecord> second)
        {
            if (!AreEqualCount(first, second))
            {
                return false;
            }

            if (first != null && second != null)
            {
                for (int i = 0; i < first.Count; i++)
                {
                    if (first[i].Ipv4Address != second[i].Ipv4Address)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool AreEqual(IList<AaaaRecord> first, IList<AaaaRecord> second)
        {
            if (!AreEqualCount(first, second))
            {
                return false;
            }

            if (first != null && second != null)
            {
                for (int i = 0; i < first.Count; i++)
                {
                    var firstAddress = IPAddress.Parse(first[i].Ipv6Address);
                    var secondAddress = IPAddress.Parse(second[i].Ipv6Address);
                    if (!firstAddress.Equals(secondAddress))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool AreEqual(IList<MxRecord> first, IList<MxRecord> second)
        {
            if (!AreEqualCount(first, second))
            {
                return false;
            }

            if (first != null && second != null)
            {
                for (int i = 0; i < first.Count; i++)
                {
                    if (first[i].Exchange != second[i].Exchange
                            || first[i].Preference != second[i].Preference)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool AreEqual(IList<NsRecord> first, IList<NsRecord> second)
        {
            if (!AreEqualCount(first, second))
            {
                return false;
            }

            if (first != null && second != null)
            {
                for (int i = 0; i < first.Count; i++)
                {
                    if (first[i].Nsdname != second[i].Nsdname)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool AreEqual(IList<PtrRecord> first, IList<PtrRecord> second)
        {
            if (!AreEqualCount(first, second))
            {
                return false;
            }

            if (first != null && second != null)
            {
                for (int i = 0; i < first.Count; i++)
                {
                    if (first[i].Ptrdname != second[i].Ptrdname)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool AreEqual(IList<SrvRecord> first, IList<SrvRecord> second)
        {
            if (!AreEqualCount(first, second))
            {
                return false;
            }

            if (first != null && second != null)
            {
                for (int i = 0; i < first.Count; i++)
                {
                    if (first[i].Port != second[i].Port
                            || first[i].Target != second[i].Target
                            || first[i].Weight != second[i].Weight
                            || first[i].Priority != second[i].Priority)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool AreEqual(IList<TxtRecord> first, IList<TxtRecord> second)
        {
            if (!AreEqualCount(first, second))
            {
                return false;
            }

            if (first != null && second != null)
            {
                for (int i = 0; i < first.Count; i++)
                {
                    if (first[i].Value != second[i].Value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static void AssertThrows<T>(Action actionExpectedToThrow, Func<T, bool> exceptionAsserts) where T : Exception
        {
            try
            {
                actionExpectedToThrow();
            }
            catch (T ex)
            {
                Assert.True(exceptionAsserts(ex), "An exception of the expected type was thrown but custom asserts failed.");
            }
        }
    }
}
