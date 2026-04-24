// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.AI.VoiceLive;
using Azure.Identity;

namespace Azure.AI.VoiceLive.Samples;

internal static class VoiceLiveSessionHelper
{
    internal static VoiceLiveClient CreateClient(VoiceLiveClientOptions? options = null)
    {
        string endpoint = Environment.GetEnvironmentVariable("AZURE_VOICELIVE_ENDPOINT")
            ?? Environment.GetEnvironmentVariable("AI_SERVICES_ENDPOINT")
            ?? throw new InvalidOperationException("Set AZURE_VOICELIVE_ENDPOINT");
        string? apiKey = Environment.GetEnvironmentVariable("AZURE_VOICELIVE_API_KEY");

        var opts = options ?? new VoiceLiveClientOptions();
        return apiKey is not null
            ? new VoiceLiveClient(new Uri(endpoint), new AzureKeyCredential(apiKey), opts)
            : new VoiceLiveClient(new Uri(endpoint), new DefaultAzureCredential(), opts);
    }

    internal static async Task RunAsync(VoiceLiveClient client)
    {
        string model = Environment.GetEnvironmentVariable("AZURE_VOICELIVE_MODEL")
            ?? Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME")
            ?? "gpt-4o-realtime-preview";

        Console.Error.WriteLine($"[sample] Connecting with model {model}");
        var session = await client.StartSessionAsync(model).ConfigureAwait(false);
        await using var _ = session;

        var sessionOptions = new VoiceLiveSessionOptions
        {
            Model = model,
            Instructions = "You are a helpful assistant. Say hello briefly.",
        };
        sessionOptions.Modalities.Clear();
        sessionOptions.Modalities.Add(InteractionModality.Text);

        await session.ConfigureSessionAsync(sessionOptions).ConfigureAwait(false);
        await session.WaitForUpdateAsync<SessionUpdateSessionCreated>().ConfigureAwait(false);
        Console.Error.WriteLine("[sample] session.created received");

        var userItem = new UserMessageItem([new InputTextContentPart("Hello, tell me a joke")]);
        await session.AddItemAsync(userItem).ConfigureAwait(false);
        await session.StartResponseAsync().ConfigureAwait(false);
        Console.Error.WriteLine("[sample] user message + response.create sent");

        await foreach (SessionUpdate update in session.GetUpdatesAsync().ConfigureAwait(false))
        {
            Console.Error.WriteLine($"[sample] recv: {update.GetType().Name}");
            if (update is SessionUpdateResponseDone)
            {
                Console.Error.WriteLine("[sample] response.done — stopping");
                break;
            }
            if (update is SessionUpdateError)
            {
                Console.Error.WriteLine("[sample] error — stopping");
                break;
            }
        }
    }
}
