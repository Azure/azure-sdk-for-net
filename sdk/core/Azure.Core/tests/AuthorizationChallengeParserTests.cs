// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class AuthorizationChallengeParserTests
    {
        private const string CaeInsufficientClaimsChallenge = "Bearer realm=\"\", authorization_uri=\"https://login.microsoftonline.com/common/oauth2/authorize\", client_id=\"00000003-0000-0000-c000-000000000000\", error=\"insufficient_claims\", claims=\"eyJhY2Nlc3NfdG9rZW4iOiB7ImZvbyI6ICJiYXIifX0=\"";
        private static readonly Challenge ParsedCaeInsufficientClaimsChallenge = new Challenge
        {
            Scheme = "Bearer",
            Parameters =
            {
                ("realm", ""),
                ("authorization_uri", "https://login.microsoftonline.com/common/oauth2/authorize"),
                ("client_id", "00000003-0000-0000-c000-000000000000"),
                ("error", "insufficient_claims"),
                ("claims", "eyJhY2Nlc3NfdG9rZW4iOiB7ImZvbyI6ICJiYXIifX0="),
            }
        };

        private const string CaeSessionsRevokedClaimsChallenge = "Bearer authorization_uri=\"https://login.windows-ppe.net/\", error=\"invalid_token\", error_description=\"User session has been revoked\", claims=\"eyJhY2Nlc3NfdG9rZW4iOnsibmJmIjp7ImVzc2VudGlhbCI6dHJ1ZSwgInZhbHVlIjoiMTYwMzc0MjgwMCJ9fX0=\"";
        private static readonly Challenge ParsedCaeSessionsRevokedClaimsChallenge = new Challenge
        {
            Scheme = "Bearer",
            Parameters =
            {
                ("authorization_uri", "https://login.windows-ppe.net/"),
                ("error", "invalid_token"),
                ("error_description", "User session has been revoked"),
                ("claims", "eyJhY2Nlc3NfdG9rZW4iOnsibmJmIjp7ImVzc2VudGlhbCI6dHJ1ZSwgInZhbHVlIjoiMTYwMzc0MjgwMCJ9fX0="),
            }
        };

        private const string KeyVaultChallenge = "Bearer authorization=\"https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47\", resource=\"https://vault.azure.net\"";
        private static readonly Challenge ParsedKeyVaultChallenge = new Challenge
        {
            Scheme = "Bearer",
            Parameters =
            {
                ("authorization", "https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47"),
                ("resource", "https://vault.azure.net"),
            }
        };

        private const string ArmChallenge = "Bearer authorization_uri=\"https://login.windows.net/\", error=\"invalid_token\", error_description=\"The authentication failed because of missing 'Authorization' header.\"";
        private static readonly Challenge ParsedArmChallenge = new Challenge()
        {
            Scheme = "Bearer",
            Parameters =
            {
                ("authorization_uri", "https://login.windows.net/"),
                ("error", "invalid_token"),
                ("error_description", "The authentication failed because of missing 'Authorization' header."),
            }
        };

        private const string StorageChallenge = "Bearer authorization_uri=https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47/oauth2/authorize resource_id=https://storage.azure.com";
        private static readonly Challenge ParsedStorageChallenge = new Challenge()
        {
            Scheme = "Bearer",
            Parameters =
            {
                ("authorization_uri", "https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47/oauth2/authorize"),
                ("resource_id", "https://storage.azure.com"),
            }
        };

        private static readonly Dictionary<string, string> ChallengeStrings = new Dictionary<string, string>()
        {
            { "CaeInsufficientClaims", CaeInsufficientClaimsChallenge },
            { "CaeSessionsRevoked", CaeSessionsRevokedClaimsChallenge },
            { "KeyVault", KeyVaultChallenge },
            { "Arm", ArmChallenge },
            { "Storage", StorageChallenge },
        };

        private static readonly Dictionary<string, Challenge> ParsedChallenges = new Dictionary<string, Challenge>()
        {
            { "CaeInsufficientClaims", ParsedCaeInsufficientClaimsChallenge },
            { "CaeSessionsRevoked", ParsedCaeSessionsRevokedClaimsChallenge },
            { "KeyVault", ParsedKeyVaultChallenge },
            { "Arm", ParsedArmChallenge },
            { "Storage", ParsedStorageChallenge }
        };

        private static readonly List<Challenge> MultipleParsedChallenges = new List<Challenge>()
        {
            {  ParsedCaeInsufficientClaimsChallenge },
            {  ParsedCaeSessionsRevokedClaimsChallenge },
            {  ParsedKeyVaultChallenge },
            {  ParsedArmChallenge },
        };

        private class Challenge
        {
            public string Scheme { get; set; }

            public List<(string Name, string Value)> Parameters { get; } = new();
        }

        [Test]
        public void ValidateChallengeParsing([Values("CaeInsufficientClaims", "CaeSessionsRevoked", "KeyVault", "Arm", "Storage")] string challengeKey)
        {
            var challenge = ChallengeStrings[challengeKey].AsSpan();

            List<Challenge> parsedChallenges = new List<Challenge>();

            while (AuthorizationChallengeParser.TryGetNextChallenge(ref challenge, out var scheme))
            {
                Challenge parsedChallenge = new Challenge();

                parsedChallenge.Scheme = scheme.ToString();

                while (AuthorizationChallengeParser.TryGetNextParameter(ref challenge, out var key, out var value))
                {
                    parsedChallenge.Parameters.Add((key.ToString(), value.ToString()));
                }

                parsedChallenges.Add(parsedChallenge);
            }

            Assert.AreEqual(1, parsedChallenges.Count);

            ValidateParsedChallenge(ParsedChallenges[challengeKey], parsedChallenges[0]);
        }

        [Test]
        public void ValidateChallengeParsingWithMultipleChallenges()
        {
            var challenge = string.Join(", ", new[] { CaeInsufficientClaimsChallenge, CaeSessionsRevokedClaimsChallenge, KeyVaultChallenge, ArmChallenge }).AsSpan();

            List<Challenge> parsedChallenges = new List<Challenge>();

            while (AuthorizationChallengeParser.TryGetNextChallenge(ref challenge, out var scheme))
            {
                Challenge parsedChallenge = new Challenge();

                parsedChallenge.Scheme = scheme.ToString();

                while (AuthorizationChallengeParser.TryGetNextParameter(ref challenge, out var key, out var value))
                {
                    parsedChallenge.Parameters.Add((key.ToString(), value.ToString()));
                }

                parsedChallenges.Add(parsedChallenge);
            }

            Assert.AreEqual(MultipleParsedChallenges.Count, parsedChallenges.Count);

            for (int i = 0; i < parsedChallenges.Count; i++)
            {
                ValidateParsedChallenge(MultipleParsedChallenges[i], parsedChallenges[i]);
            }
        }

        private void ValidateParsedChallenge(Challenge expected, Challenge actual)
        {
            Assert.AreEqual(expected.Scheme, actual.Scheme);

            CollectionAssert.AreEquivalent(expected.Parameters, actual.Parameters);
        }
    }
}
