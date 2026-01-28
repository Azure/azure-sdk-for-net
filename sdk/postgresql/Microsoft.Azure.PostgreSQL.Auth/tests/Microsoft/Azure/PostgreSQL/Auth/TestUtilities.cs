// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text;
using Azure.Core;

namespace Microsoft.Azure.PostgreSQL.Auth;

/// <summary>
/// Test user constants used across integration tests
/// </summary>
public static class TestUsers
{
    public const string EntraUser = "test@example.com";
    public const string ManagedIdentityPath = "/subscriptions/12345/resourcegroups/mygroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/managed-identity";
    public const string ManagedIdentityName = "managed-identity";
    public const string FallbackUser = "fallback@example.com";
}

public static class TestJwtTokenGenerator
{
    public static string CreateBase64UrlString(string input)
    {
        var bytes = Encoding.UTF8.GetBytes(input);
        var base64 = Convert.ToBase64String(bytes);
        return base64.TrimEnd('=').Replace('+', '-').Replace('/', '_');
    }

    public static string CreateValidJwtToken(string username) =>
        string.Join('.',
            CreateBase64UrlString("{\"alg\":\"RS256\",\"typ\":\"JWT\"}"),
            CreateBase64UrlString($"{{\"upn\":\"{username}\",\"iat\":1234567890,\"exp\":9999999999}}"),
            "fake-signature");

    public static string CreateJwtTokenWithXmsMirid(string xms_mirid) =>
        string.Join('.',
            CreateBase64UrlString("{\"alg\":\"RS256\",\"typ\":\"JWT\"}"),
            CreateBase64UrlString($"{{\"xms_mirid\":\"{xms_mirid}\",\"iat\":1234567890,\"exp\":9999999999}}"),
            "fake-signature");

    public class TestTokenCredential : TokenCredential
    {
        private readonly string _token;

        public TestTokenCredential(string token)
        {
            _token = token;
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new AccessToken(_token, DateTimeOffset.UtcNow.AddHours(1));
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new ValueTask<AccessToken>(new AccessToken(_token, DateTimeOffset.UtcNow.AddHours(1)));
        }
    }
}
