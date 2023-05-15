// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Secrets.Tests.samples
{
    public class Sample4_ErrorResponse
    {
        [Test]
        public void ParseErrorResponse()
        {
            MockTransport transport = new(
                new MockResponse(409)
                .WithJson("""
                    {
                        "error": {
                            "code": "Conflict",
                            "message": "Secret my-secret is currently in a deleted but recoverable state, and its name cannot be reused; in this state, the secret can only be recovered or purged.",
                            "innererror": {
                                "code": "ObjectIsDeletedButRecoverable"
                            }
                        }
                    }
                    """)
            );

            SecretClient client = new(new("https://myvault.vault.azure.net"), new MockCredential(), new()
            {
                Transport = transport,
            });

            #region Snippet:SecretsSample4ErrorResponse
            try
            {
                KeyVaultSecret secret = client.SetSecret("my-secret", "secret-value");
            }
            catch (RequestFailedException ex) when (ex.Status == 409)
            {
                if (ex.GetRawResponse() is Response response)
                {
                    Error error = response.Content.ToObjectFromJson<ErrorResponse>()?.Error;
                    if (error?.Code == "Conflict" &&
                       (error.InnerError?.Code == "ObjectIsBeingDeleted" || error.InnerError?.Code == "ObjectIsDeletedButRecoverable"))
                    {
                        Console.WriteLine("Please try again with a new name.");
                        return;
                    }
                }

                throw;
            }
            #endregion
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    #region Snippet:SecretsSample4Models
    public class ErrorResponse
    {
        [JsonPropertyName("error")]
        public Error Error { get; set; }
    }

    public class Error
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("innererror")]
        public InnerError InnerError { get; set; }
    }

    public class InnerError
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
    #endregion
#pragma warning restore SA1402 // File may only contain a single type
}
