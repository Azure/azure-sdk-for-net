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

        private const string PopChallenge = "PoP realm=\"\", authorization_uri=\"https://login.microsoftonline.com/common/oauth2/authorize\", client_id=\"00000003-0000-0000-c000-000000000000\", nonce=\"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjY3NDYyMDhENkQ5RTgyMkI3NzIxNjcyODg3MTg5OUIwREMzRTU4M0MifQ.eyJ0cyI6MTY5OTkwMDY5OH0.nvO9sU5EY5rQW_b1mElzUKflSKA_sWPPeeGzLAhRPdp9fcxz3HJGJbySvRgMhJCJDKxbveNBG7XrDh-jgKFggw32pAB6N7dCFQcs3Eyh8TEQoj2S303pvk1Hajw0YCcJRH_7GdqNdxyPk8UTip9vkEyOjXRj8YvYO2O8_CKcMJb7-PCaNDh9JBDVAysV8bhZS3wvUw4G--Mi1DZkaFn12kGSm_0odK1ROp11s0U2-5PW7M5gyRL9mU5EX96L9aiICseCipolm1e2tlmy_YpLOGS5oTy2qKukWiZv9cDylrgerbt8tOlO4VETH5hGZC6wken4MM2oTEIwOBZtaXIirg\", Bearer realm=\"\", authorization_uri=\"https://login.microsoftonline.com/common/oauth2/authorize\", client_id=\"00000003-0000-0000-c000-000000000001\"";
        private static Challenge[] ParsedPopChallenge = {
            new Challenge()
            {
                Scheme = "PoP",
                Parameters =
                {
                    ("realm", ""),
                    ("authorization_uri", "https://login.microsoftonline.com/common/oauth2/authorize"),
                    ("client_id", "00000003-0000-0000-c000-000000000000"),
                    ("nonce", "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjY3NDYyMDhENkQ5RTgyMkI3NzIxNjcyODg3MTg5OUIwREMzRTU4M0MifQ.eyJ0cyI6MTY5OTkwMDY5OH0.nvO9sU5EY5rQW_b1mElzUKflSKA_sWPPeeGzLAhRPdp9fcxz3HJGJbySvRgMhJCJDKxbveNBG7XrDh-jgKFggw32pAB6N7dCFQcs3Eyh8TEQoj2S303pvk1Hajw0YCcJRH_7GdqNdxyPk8UTip9vkEyOjXRj8YvYO2O8_CKcMJb7-PCaNDh9JBDVAysV8bhZS3wvUw4G--Mi1DZkaFn12kGSm_0odK1ROp11s0U2-5PW7M5gyRL9mU5EX96L9aiICseCipolm1e2tlmy_YpLOGS5oTy2qKukWiZv9cDylrgerbt8tOlO4VETH5hGZC6wken4MM2oTEIwOBZtaXIirg")
                }
            },
            new Challenge()
            {
                Scheme = "Bearer",
                Parameters =
                {
                    ("realm", ""),
                    ("authorization_uri", "https://login.microsoftonline.com/common/oauth2/authorize"),
                    ("client_id", "00000003-0000-0000-c000-000000000001")
                }
            }
        };

        private static readonly Dictionary<string, string> ChallengeStrings = new Dictionary<string, string>()
        {
            { "CaeInsufficientClaims", CaeInsufficientClaimsChallenge },
            { "CaeSessionsRevoked", CaeSessionsRevokedClaimsChallenge },
            { "KeyVault", KeyVaultChallenge },
            { "Arm", ArmChallenge },
            { "Storage", StorageChallenge },
            { "PopWithBearer", PopChallenge}
        };

        private static readonly Dictionary<string, Challenge> ParsedChallenges = new Dictionary<string, Challenge>()
        {
            { "CaeInsufficientClaims", ParsedCaeInsufficientClaimsChallenge },
            { "CaeSessionsRevoked", ParsedCaeSessionsRevokedClaimsChallenge },
            { "KeyVault", ParsedKeyVaultChallenge },
            { "Arm", ParsedArmChallenge },
            { "Storage", ParsedStorageChallenge },
            { "PopWithBearer", ParsedPopChallenge[0] }
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

        [Test]
        public void ValidateChallengeParsingWithPopAndBearerChallenge()
        {
            var challenge = PopChallenge.AsSpan();

            List<Challenge> parsedChallenges = new List<Challenge>();

            while (AuthorizationChallengeParser.TryGetNextChallenge(ref challenge, out var scheme))
            {
                Challenge parsedChallenge = new Challenge
                {
                    Scheme = scheme.ToString()
                };

                while (AuthorizationChallengeParser.TryGetNextParameter(ref challenge, out var key, out var value))
                {
                    parsedChallenge.Parameters.Add((key.ToString(), value.ToString()));
                }

                parsedChallenges.Add(parsedChallenge);
            }

            Assert.AreEqual(2, parsedChallenges.Count);

            for (int i = 0; i < parsedChallenges.Count; i++)
            {
                ValidateParsedChallenge(ParsedPopChallenge[i], parsedChallenges[i]);
            }
        }

        private void ValidateParsedChallenge(Challenge expected, Challenge actual)
        {
            Assert.AreEqual(expected.Scheme, actual.Scheme);

            CollectionAssert.AreEquivalent(expected.Parameters, actual.Parameters);
        }
    }
}
