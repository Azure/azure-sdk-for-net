// ------------------------------------------------------------------------------------------------
// <copyright file="RecordSetAssertions.cs" company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.Azure.Management.PrivateDns.Models;

namespace PrivateDns.Tests.Validation
{
    internal class RecordSetAssertions : ReferenceTypeAssertions<RecordSet, RecordSetAssertions>
    {
        public RecordSetAssertions(RecordSet subject)
        {
            this.Subject = subject;
        }

        protected override string Identifier => "recordset";

        public AndConstraint<RecordSetAssertions> BeEquivalentTo(
            RecordSet expected,
            bool checkEtag = true,
            bool checkFqdn = false,
            string because = "",
            params object[] becauseArgs)
        {
            if (this.Subject == null)
            {
                Execute.Assertion.BecauseOf(because, becauseArgs).FailWith("Expected subject record set to be populated{reason}, but found it to be null.");
            }

            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(expected != null)
                .FailWith("You cannot assert a null record set for equivalency.")
                .Then
                .Given(() => this.Subject)
                .ForCondition(subject => AreRecordSetsEquivalent(subject, expected, checkEtag: checkEtag, checkFqdn: checkFqdn))
                .FailWith("Expected {context:recordset} {0} to be equivalent to {1}{reason}, but found them different.", this.Subject, expected);

            return new AndConstraint<RecordSetAssertions>(this);
        }

        private static bool AreRecordSetsEquivalent(RecordSet subject, RecordSet expected, bool checkEtag = true, bool checkFqdn = false)
        {
            if (subject == null)
            {
                return expected == null;
            }
            else if (expected == null)
            {
                return false;
            }

            if (checkEtag && subject.Etag != expected.Etag)
            {
                return false;
            }

            if (checkFqdn && !string.Equals(subject.Fqdn, expected.Fqdn, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return subject.Metadata == expected.Metadata
                && subject.Ttl == expected.Ttl
                && subject.IsAutoRegistered == expected.IsAutoRegistered
                && AreARecordSetsEquivalent(subject.ARecords, expected.ARecords)
                && AreAaaaRecordSetsEquivalent(subject.AaaaRecords, expected.AaaaRecords)
                && AreCnameRecordSetsEquivalent(subject.CnameRecord, expected.CnameRecord)
                && AreMxRecordSetsEquivalent(subject.MxRecords, expected.MxRecords)
                && ArePtrRecordSetsEquivalent(subject.PtrRecords, expected.PtrRecords)
                && AreSoaRecordSetsEquivalent(subject.SoaRecord, expected.SoaRecord)
                && AreSrvRecordSetsEquivalent(subject.SrvRecords, expected.SrvRecords)
                && AreTxtRecordSetsEquivalent(subject.TxtRecords, expected.TxtRecords);
        }

        private static bool AreARecordSetsEquivalent(IList<ARecord> subject, IList<ARecord> expected)
        {
            if (!HaveEqualCount(subject, expected))
            {
                return false;
            }

            if (subject != null && expected != null)
            {
                for (var i = 0; i < subject.Count; i++)
                {
                    if (subject[i].Ipv4Address != expected[i].Ipv4Address)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool AreAaaaRecordSetsEquivalent(IList<AaaaRecord> subject, IList<AaaaRecord> expected)
        {
            if (!HaveEqualCount(subject, expected))
            {
                return false;
            }

            if (subject != null && expected != null)
            {
                for (int i = 0; i < subject.Count; i++)
                {
                    var firstAddress = IPAddress.Parse(subject[i].Ipv6Address);
                    var secondAddress = IPAddress.Parse(expected[i].Ipv6Address);
                    if (!firstAddress.Equals(secondAddress))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool AreCnameRecordSetsEquivalent(CnameRecord subject, CnameRecord expected)
        {
            if (subject == null)
            {
                return expected == null;
            }
            else if (expected == null)
            {
                return false;
            }

            return subject.Cname == expected.Cname;
        }

        public static bool AreMxRecordSetsEquivalent(IList<MxRecord> subject, IList<MxRecord> expected)
        {
            if (!HaveEqualCount(subject, expected))
            {
                return false;
            }

            if (subject != null && expected != null)
            {
                for (int i = 0; i < subject.Count; i++)
                {
                    if (subject[i].Exchange != expected[i].Exchange
                        || subject[i].Preference != expected[i].Preference)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool ArePtrRecordSetsEquivalent(IList<PtrRecord> subject, IList<PtrRecord> expected)
        {
            if (!HaveEqualCount(subject, expected))
            {
                return false;
            }

            if (subject != null && expected != null)
            {
                for (int i = 0; i < subject.Count; i++)
                {
                    if (subject[i].Ptrdname != expected[i].Ptrdname)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool AreSoaRecordSetsEquivalent(SoaRecord subject, SoaRecord expected)
        {
            if (subject == null)
            {
                return expected == null;
            }
            else if (expected == null)
            {
                return false;
            }

            return subject.Email == expected.Email
                   && subject.ExpireTime == expected.ExpireTime
                   && subject.Host == expected.Host
                   && subject.MinimumTtl == expected.MinimumTtl
                   && subject.RefreshTime == expected.RefreshTime
                   && subject.RetryTime == expected.RetryTime
                   && subject.SerialNumber == expected.SerialNumber;
        }

        public static bool AreSrvRecordSetsEquivalent(IList<SrvRecord> subject, IList<SrvRecord> expected)
        {
            if (!HaveEqualCount(subject, expected))
            {
                return false;
            }

            if (subject != null && expected != null)
            {
                for (int i = 0; i < subject.Count; i++)
                {
                    if (subject[i].Port != expected[i].Port
                        || subject[i].Target != expected[i].Target
                        || subject[i].Weight != expected[i].Weight
                        || subject[i].Priority != expected[i].Priority)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool AreTxtRecordSetsEquivalent(IList<TxtRecord> subject, IList<TxtRecord> expected)
        {
            if (!HaveEqualCount(subject, expected))
            {
                return false;
            }

            if (subject != null && expected != null)
            {
                for (int i = 0; i < subject.Count; i++)
                {
                    if (subject[i].Value.Count != expected[i].Value.Count)
                    {
                        return false;
                    }

                    for (var j = 0; j < subject[i].Value.Count; j++)
                    {
                        if (subject[i].Value[j] != expected[i].Value[j])
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private static bool HaveEqualCount<T>(IList<T> first, IList<T> second)
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
    }
}
