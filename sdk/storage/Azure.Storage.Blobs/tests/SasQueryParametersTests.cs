// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Azure.Storage.Sas;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    //TODO consider added SASQueryParametersTest for File and Queue
    [TestFixture]
    public class SasQueryParametersTests : BlobTestBase
    {
        public SasQueryParametersTests()
            : base(/* Use RecordedTestMode.Record here to re-record just these tests */)
        {
        }

        [Test]
        public void SasQueryParameters_RoundTrip()
        {
            var version = "2018-03-28";
            var service = "b";
            var resourceType = "c";
            var protocol = SasProtocol.Https;
            var startTime = DateTimeOffset.Now;
            var expiryTime = startTime.AddDays(1);
            var ipRange = new IPRange();
            var identifier = "foo";
            var resource = "bar";
            var permissions = "rw";
            var signature = "a+b=";

            var sasQueryParameters = new SasQueryParameters(
                version,
                service,
                resourceType,
                protocol,
                startTime,
                expiryTime,
                ipRange,
                identifier,
                resource,
                permissions,
                signature
                );

            Assert.AreEqual(signature, sasQueryParameters.Signature);

            var sasString = sasQueryParameters.ToString();

            var roundTripSas = new SasQueryParameters(new UriQueryParamsCollection(sasString));

            Assert.AreEqual(sasQueryParameters.ToString(), roundTripSas.ToString());
        }
    }
}
