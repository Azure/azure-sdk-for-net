// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Xunit;

namespace SignalRServiceExtension.Tests
{
    public class DefaultSecurityTokenValidatorTests
    {
        public static IEnumerable<object[]> TestData = new List<object[]>
        {
            new object []
            {
                "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWFhIiwiZXhwIjoxNjk5ODE5MDI1fQ.joh9CXSfRpgZhoraozdQ0Z1DxmUhlXF4ENt_1Ttz7x8",
                SecurityTokenStatus.Valid
            },
            new object[]
            {
                "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWFhIiwiZXhwIjoyNTMwODk4OTIyMjV9.1dbS2bgRrTvxHhph9lh0TLw34a46ts5jwaJH0OeS8-s",
                SecurityTokenStatus.Error
            },
            new object[]
            {
                "",
                SecurityTokenStatus.Empty
            }
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void ValidateSecurityTokenFacts(string tokenString, SecurityTokenStatus expectedStatus)
        {
            var ctx = new DefaultHttpContext();
            var req = ctx.Request;
            req.Headers.Add("Authorization", new StringValues(tokenString));

            var issuerToken = "bXlmdW5jdGlvbmF1dGh0ZXN0"; // base64 encoded for "myfunctionauthtest";
            Action<TokenValidationParameters> configureTokenValidationParameters = parameters =>
            {
                parameters.IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(issuerToken));
                parameters.RequireSignedTokens = true;
                parameters.ValidateAudience = false;
                parameters.ValidateIssuer = false;
                parameters.ValidateIssuerSigningKey = true;
                parameters.ValidateLifetime = true;
            };

            var securityTokenValidator = new DefaultSecurityTokenValidator(configureTokenValidationParameters);
            var securityTokenResult = securityTokenValidator.ValidateToken(req);

            Assert.Equal(expectedStatus, securityTokenResult.Status);
        }
    }
}