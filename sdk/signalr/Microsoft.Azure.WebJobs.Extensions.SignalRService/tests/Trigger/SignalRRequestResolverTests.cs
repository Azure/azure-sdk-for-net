// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests
{
    public class SignalRRequestResolverTests
    {
        [Fact]
        public void ValidateSignatureWithAadAccessKeyFact()
        {
            var resolver = new SignalRRequestResolver();
            Assert.True(resolver.ValidateSignature(new(), Mock.Of<IOptionsMonitor<SignatureValidationOptions>>(o => o.CurrentValue.RequireValidation == false)));
        }
    }
}
