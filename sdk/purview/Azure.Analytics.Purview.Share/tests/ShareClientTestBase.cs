// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using Azure.Analytics.Purview.Tests;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Share.Tests
{
    public class ShareClientTestBase : RecordedTestBase<PurviewShareTestEnvironment>
    {
        public ShareClientTestBase(bool isAsync, RecordedTestMode? mode = default) : base(isAsync, mode)
        {
            this.AddPurviewSanitizers();
        }

        public SentSharesClient GetSentSharesClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewShareClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new SentSharesClient(TestEnvironment.Endpoint.ToString(), TestEnvironment.Credential, InstrumentClientOptions(options)));
        }

        public ReceivedSharesClient GetReceivedSharesClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewShareClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new ReceivedSharesClient(TestEnvironment.Endpoint.ToString(), TestEnvironment.Credential, InstrumentClientOptions(options)));
        }

        public AssetsClient GetAssetsClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewShareClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new AssetsClient(TestEnvironment.Endpoint.ToString(), TestEnvironment.Credential, InstrumentClientOptions(options)));
        }

        public AssetMappingsClient GetAssetMappingsClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewShareClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new AssetMappingsClient(TestEnvironment.Endpoint.ToString(), TestEnvironment.Credential, InstrumentClientOptions(options)));
        }

        public SentShareInvitationsClient GetSentShareInvitationsClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewShareClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new SentShareInvitationsClient(TestEnvironment.Endpoint.ToString(), TestEnvironment.Credential, InstrumentClientOptions(options)));
        }

        public AcceptedSentSharesClient GetAcceptedSentSharesClient()
        {
            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (_, _, _, _) =>
                {
                    return true;
                }
            };
            var options = new PurviewShareClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new AcceptedSentSharesClient(TestEnvironment.Endpoint.ToString(), TestEnvironment.Credential, InstrumentClientOptions(options)));
        }

        public ReceivedAssetsClient GetReceivedAssetsClient()
        {
            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (_, _, _, _) =>
                {
                    return true;
                }
            };
            var options = new PurviewShareClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new ReceivedAssetsClient(TestEnvironment.Endpoint.ToString(), TestEnvironment.Credential, InstrumentClientOptions(options)));
        }

        public ReceivedInvitationsClient GetReceivedInvitationsClient()
        {
            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (_, _, _, _) =>
                {
                    return true;
                }
            };
            var options = new PurviewShareClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new ReceivedInvitationsClient(TestEnvironment.Endpoint.ToString(), TestEnvironment.Credential, InstrumentClientOptions(options)));
        }

        public EmailRegistrationClient GetEmailRegistrationClient()
        {
            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (_, _, _, _) =>
                {
                    return true;
                }
            };
            var options = new PurviewShareClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new EmailRegistrationClient(TestEnvironment.Endpoint.ToString(), TestEnvironment.Credential, InstrumentClientOptions(options)));
        }
    }
}
