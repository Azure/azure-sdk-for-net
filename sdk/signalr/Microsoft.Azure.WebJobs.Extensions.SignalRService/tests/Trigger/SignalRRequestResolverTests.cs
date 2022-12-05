// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using Microsoft.Azure.SignalR;
using Xunit;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests
{
    public class SignalRRequestResolverTests
    {
        [Fact]
        public void ValidateSignatureWithAadAccessKeyFact()
        {
            var resolver = new SignalRRequestResolver();
            Assert.True(resolver.ValidateSignature(new(), new[] { new AadAccessKey(new("http://localhost"), new DefaultAzureCredential()) }));
        }
    }
}
