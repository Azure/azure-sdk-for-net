// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.CloudMachine;
using Azure.Security.KeyVault.Secrets;

namespace Azure.Provisioning.CloudMachine.OpenAI;

public class OpenAIFeature : CloudMachineFeature
{
    public override void AddTo(CloudMachineInfrastructure cm)
    {
        throw new NotImplementedException();
    }
}

public static class OpenAIFeatureExtensions
{
    public static SecretClient GetOpenAIClient(this CloudMachineClient client)
    {
        throw new NotImplementedException();
        //return new(new($"https://{client.Id}.vault.azure.net/"), client.Credential);
    }
}
