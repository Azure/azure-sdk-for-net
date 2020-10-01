// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    //TODO consider added SASQueryParametersTest for File and Queue
    public class SasQueryParametersTests
    {
        [Test]
        public void SasQueryParameters_RoundTrip()
        {
            var version = "2018-03-28";
            AccountSasServices service = AccountSasServices.Blobs;
            AccountSasResourceTypes resourceType = AccountSasResourceTypes.Container;
            SasProtocol protocol = SasProtocol.Https;
            DateTimeOffset startTime = DateTimeOffset.Now;
            DateTimeOffset expiryTime = startTime.AddDays(1);
            var ipRange = new SasIPRange();
            var identifier = "foo";
            var resource = "bar";
            var permissions = "rw";
            var signature = "a+b=";
            var cacheControl = "no-store";
            var contentDisposition = "inline";
            var contentEncoding = "identity";
            var contentLanguage = "en-US";
            var contentType = "text/html";

            var sasQueryParameters = SasQueryParametersInternals.Create(
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
                signature,
                cacheControl: cacheControl,
                contentDisposition: contentDisposition,
                contentEncoding: contentEncoding,
                contentLanguage: contentLanguage,
                contentType: contentType
                );

            Assert.AreEqual(signature, sasQueryParameters.Signature);

            var sasString = sasQueryParameters.ToString();

            var roundTripSas = SasQueryParametersInternals.Create(new UriQueryParamsCollection(sasString));

            Assert.AreEqual(sasQueryParameters.ToString(), roundTripSas.ToString());
        }
    }
}
