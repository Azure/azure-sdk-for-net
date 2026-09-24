// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxModelSerializationTests
    {
        [Test]
        public void CreateDiskImageSerializesBlobSource()
        {
            CreateDiskImageContent content = new CreateDiskImageContent(
                new CreateDiskImageSourceBlobSource(new Uri("https://storage.example.com/images/image.vhd")))
            {
                Name = "blob-image",
                VnetConnectionName = "test-vnet"
            };

            string json = Serialize(content);

            Assert.That(json, Does.Contain("\"kind\":\"blob\""));
            Assert.That(json, Does.Contain("\"blobSourceUri\":\"https://storage.example.com/images/image.vhd\""));
            Assert.That(json, Does.Contain("\"vnetConnectionName\":\"test-vnet\""));
        }

        [Test]
        public void CreateSandboxSerializesSnapshotSource()
        {
            CreateSandboxContent content = new CreateSandboxContent
            {
                SourcesRef = new SandboxSource
                {
                    Snapshot = new SandboxSourceSnapshot("snapshot-id")
                }
            };

            string json = Serialize(content);

            Assert.That(json, Does.Contain("\"snapshot\":{\"id\":\"snapshot-id\"}"));
        }

        [Test]
        public void CreateSandboxSerializesPrivateDiskImageSource()
        {
            CreateSandboxContent content = new CreateSandboxContent
            {
                SourcesRef = new SandboxSource
                {
                    DiskImage = new SandboxSourceDiskImage
                    {
                        Id = "image-id",
                        IsPublic = false
                    }
                }
            };

            string json = Serialize(content);

            Assert.That(json, Does.Contain("\"diskImage\":{\"id\":\"image-id\",\"isPublic\":false}"));
        }

        [Test]
        public void CreateVolumeSerializesUserProvidedBlobVolume()
        {
            BlobVolumeManagedIdentityAuthentication authentication =
                new BlobVolumeManagedIdentityAuthentication(
                    new SandboxGroupIdentitySelectorSystemAssignedIdentitySelector());
            UserProvidedBlobVolume volume = new UserProvidedBlobVolume(
                "/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Storage/storageAccounts/account/blobServices/default/containers/container",
                authentication);

            string json = Serialize(volume);

            Assert.That(json, Does.Contain("\"type\":\"AzureBlobByo\""));
            Assert.That(json, Does.Contain("\"storageContainerResourceId\""));
            Assert.That(json, Does.Contain("\"kind\":\"ManagedIdentity\""));
            Assert.That(json, Does.Contain("\"kind\":\"SystemAssigned\""));
        }

        [Test]
        public void CreatePodSandboxSerializesDataDiskAndBlobVolumes()
        {
            ContainerSpec container = new ContainerSpec("default")
            {
                DiskImage = new SandboxSourceDiskImage
                {
                    Name = "ubuntu",
                    IsPublic = true
                }
            };
            SandboxSourcePod pod = new SandboxSourcePod(new[] { container });
            pod.Volumes.Add(new DataDiskPodVolume("data"));
            pod.Volumes.Add(new ServiceManagedBlobPodVolume("cache", "1Gi")
            {
                ReadOnly = true
            });
            pod.Volumes.Add(new UserProvidedBlobPodVolume("byo", "2Gi"));
            CreateSandboxContent content = new CreateSandboxContent
            {
                SourcesRef = new SandboxSource
                {
                    Pod = pod
                }
            };

            string json = Serialize(content);

            Assert.That(json, Does.Contain("\"kind\":\"DataDisk\""));
            Assert.That(json, Does.Contain("\"kind\":\"AzureBlob\""));
            Assert.That(json, Does.Contain("\"kind\":\"AzureBlobByo\""));
            Assert.That(json, Does.Contain("\"fileCacheSizeLimit\":\"1Gi\""));
            Assert.That(json, Does.Contain("\"readOnly\":true"));
        }

        [Test]
        public void CreatePortSerializesProtocolAuthAndCors()
        {
            PortAuthConfigGithub github = new PortAuthConfigGithub
            {
                Enabled = true
            };
            github.EmailSuffixes.Add("@example.com");
            PortCorsConfig cors = new PortCorsConfig
            {
                AllowCredentials = true,
                MaxAge = 600
            };
            cors.AllowOrigins.Add("https://app.example.com");
            cors.AllowMethods.Add("GET");
            CreateSandboxPortContent port = new CreateSandboxPortContent(8080)
            {
                Name = "web",
                ActivationMode = PortActivationMode.OnDemand,
                Protocol = PortProtocol.Http2,
                Auth = new PortAuthConfig
                {
                    Anonymous = false,
                    Github = github
                },
                Cors = cors
            };
            CreateSandboxContent content = new CreateSandboxContent();
            content.Ports.Add(port);

            string json = Serialize(content);

            Assert.That(json, Does.Contain("\"protocol\":\"Http2\""));
            Assert.That(json, Does.Contain("\"activationMode\":\"OnDemand\""));
            Assert.That(json, Does.Contain("\"anonymous\":false"));
            Assert.That(json, Does.Contain("\"emailSuffixes\":[\"@example.com\"]"));
            Assert.That(json, Does.Contain("\"allowOrigins\":[\"https://app.example.com\"]"));
        }

        [Test]
        public void SetEgressPolicySerializesAdvancedRules()
        {
            EgressPolicyRuleMatch match = new EgressPolicyRuleMatch("api.example.com")
            {
                Path = "/v1/*",
                NormalizePath = true
            };
            match.Methods.Add("GET");
            EgressPolicyRule rule = new EgressPolicyRule("allow-api", match)
            {
                Action = new EgressPolicyRuleAction(EgressPolicyActionType.Allow)
            };
            SandboxEgressPolicy policy = new SandboxEgressPolicy
            {
                DefaultAction = EgressPolicyAction.Deny,
                TransportRules = new TransportEgressSection(
                    EgressPolicyActionType.Deny,
                    new[]
                    {
                        new TransportEgressRule(
                            EgressPolicyActionType.Allow,
                            TransportProtocol.Tcp,
                            "10.0.0.0/24",
                            443)
                    })
            };
            policy.Rules.Add(rule);

            string json = Serialize(policy);

            Assert.That(json, Does.Contain("\"defaultAction\":\"Deny\""));
            Assert.That(json, Does.Contain("\"name\":\"allow-api\""));
            Assert.That(json, Does.Contain("\"host\":\"api.example.com\""));
            Assert.That(json, Does.Contain("\"type\":\"Allow\""));
            Assert.That(json, Does.Contain("\"destination\":\"10.0.0.0/24\""));
            Assert.That(json, Does.Contain("\"protocol\":\"Tcp\""));
        }

        private static string Serialize<T>(T model) =>
            ModelReaderWriter.Write(model).ToString();
    }
}
