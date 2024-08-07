// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
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

        [Test]
        [Sequential]
        public void SasQueryParameters_RoundTrip_String(
            [Values("https", "https,http", "http,https")] string protocol)
        {
            string version = "2018-03-28";
            string service = AccountSasServices.Blobs.ToPermissionsString();
            string resourceType = AccountSasResourceTypes.Container.ToPermissionsString();
            string startTime = DateTimeOffset.Now.ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture);
            string expiryTime = DateTimeOffset.Now.AddDays(1).ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture);
            string identifier = "foo";
            string resource = "bar";
            string permissions = "rw";
            string signature = "a+b=";
            string cacheControl = "no-store";
            string contentDisposition = "inline";
            string contentEncoding = "identity";
            string contentLanguage = "en-US";
            string contentType = "text/html";

            Dictionary<string, string> original = new()
            {
                { "sv", version },
                { "ss", service },
                { "srt", resourceType },
                { "spr", protocol },
                { "st", startTime },
                { "se", expiryTime },
                { "si", identifier },
                { "sr", resource },
                { "sp", permissions },
                { "rscc", cacheControl },
                { "rscd", contentDisposition },
                { "rsce", contentEncoding },
                { "rscl", contentLanguage },
                { "rsct", contentType },
                { "sig", signature },
            };

            var sasQueryParameters = SasQueryParametersInternals.Create(new Dictionary<string, string>(original));

            Assert.AreEqual(signature, sasQueryParameters.Signature);

            Dictionary<string, string> roundtrip = sasQueryParameters.ToString().Trim('?').Split('&')
                .ToDictionary(
                    s => s.Split('=')[0],
                    s => WebUtility.UrlDecode(s.Split('=')[1]));

            Assert.That(original, Is.EquivalentTo(roundtrip));
        }
    }
}
