// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

using Xunit;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests
{
    public class DefaultSecurityTokenValidatorTests
    {
        // The issue token must be longer than 32 characters.
        private const string IssuerToken = "1234567812345678912345678123456789";
        public static IEnumerable<object[]> TestData = new List<object[]>
        {
            new object []
            {
                "Bearer "+ GenerateJwtToken(IssuerToken, "issuer", "audience", 10),
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
            req.Headers.Append("Authorization", new StringValues(tokenString));

            Action<TokenValidationParameters> configureTokenValidationParameters = parameters =>
            {
                parameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IssuerToken));
                parameters.RequireSignedTokens = true;
                parameters.ValidateIssuerSigningKey = true;
                parameters.ValidateLifetime = true;
                parameters.ValidIssuer = "issuer";
                parameters.ValidAudience = "audience";
            };

            var securityTokenValidator = new DefaultSecurityTokenValidator(configureTokenValidationParameters);
            var securityTokenResult = securityTokenValidator.ValidateToken(req);

            Assert.Equal(expectedStatus, securityTokenResult.Status);
        }

        public static string GenerateJwtToken(string secretKey, string issuer, string audience, int expireMinutes)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddMinutes(expireMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}