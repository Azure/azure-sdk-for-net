// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Core.TestFramework;

namespace Microsoft.Azure.PostgreSQL.Auth;

/// <summary>
/// Test environment for PostgreSQL authentication tests.
/// </summary>
public class PostgreSqlTestEnvironment : TestEnvironment
{
    /// <summary>Well-known test user for Entra ID authentication tests.</summary>
    public const string EntraUser = "test@contoso.com";

    /// <summary>Well-known managed identity resource path for token extraction tests.</summary>
    public const string ManagedIdentityPath = "/subscriptions/12345/resourcegroups/mygroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/managed-identity";

    /// <summary>Expected principal name extracted from <see cref="ManagedIdentityPath"/>.</summary>
    public const string ManagedIdentityName = "managed-identity";

    public string PostgreSqlHost => GetRecordedVariable("HOST");
    public string PostgreSqlDatabase => GetRecordedVariable("DATABASE");
    public string PostgreSqlPort => GetRecordedVariable("PORT");
    public string ConnectionString => $"Host={PostgreSqlHost};Port={PostgreSqlPort};Database={PostgreSqlDatabase};SSL Mode=Require";

    public static string CreateBase64UrlString(string input)
    {
        var bytes = Encoding.UTF8.GetBytes(input);
        var base64 = Convert.ToBase64String(bytes);
        return base64.TrimEnd('=').Replace('+', '-').Replace('/', '_');
    }

    public static string CreateValidJwtToken(string username) =>
        string.Join(".",
            CreateBase64UrlString("{\"alg\":\"RS256\",\"typ\":\"JWT\"}"),
            CreateBase64UrlString($"{{\"upn\":\"{username}\",\"iat\":1234567890,\"exp\":9999999999}}"),
            "fake-signature");

    public static string CreateJwtTokenWithXmsMirid(string xms_mirid) =>
        string.Join(".",
            CreateBase64UrlString("{\"alg\":\"RS256\",\"typ\":\"JWT\"}"),
            CreateBase64UrlString($"{{\"xms_mirid\":\"{xms_mirid}\",\"iat\":1234567890,\"exp\":9999999999}}"),
            "fake-signature");
}
