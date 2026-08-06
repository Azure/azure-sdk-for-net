// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Invocations.Voice;
using Azure.AI.AgentServer.Invocations.Voice.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class VoiceResponseConcurrencyTests
{
    [Test]
    public void ResponseCopiesInputPrefix()
    {
        var prefix = new[] { "in_original" };
        var response = new VoiceResponse(
            new CoordinatedConnection(),
            "r_test",
            prefix,
            wireOpened: false,
            accepted: true,
            CancellationToken.None);

        prefix[0] = "in_changed";

        Assert.That(response.InReplyTo, Is.EqualTo(new[] { "in_original" }));
        Assert.That(response.InReplyTo, Is.Not.InstanceOf<string[]>());
    }

    [Test]
    public async Task ConcurrentInitialSimpleDeltasShareOneItem()
    {
        var connection = new CoordinatedConnection();
        var response = new VoiceResponse(
            connection,
            "r_test",
            new[] { "in_test" },
            wireOpened: false,
            accepted: true,
            CancellationToken.None);

        var first = response.SendTextDeltaAsync("first");
        await connection.FirstSendStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));
        var second = response.SendTextDeltaAsync("second");

        connection.AllowFirstSend.TrySetResult();
        await Task.WhenAll(first, second);

        Assert.That(connection.ItemIds, Has.Count.EqualTo(2));
        Assert.That(connection.ItemIds.Distinct().Count(), Is.EqualTo(1));
    }

    [Test]
    public async Task CreateTextItemCannotRaceWithInitialSimpleSend()
    {
        var connection = new CoordinatedConnection();
        var response = new VoiceResponse(
            connection,
            "r_test",
            new[] { "in_test" },
            wireOpened: false,
            accepted: true,
            CancellationToken.None);

        var simpleSend = response.SendTextDeltaAsync("first");
        await connection.FirstSendStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));

        Assert.Throws<InvalidOperationException>(() => response.CreateTextItem());

        connection.AllowFirstSend.TrySetResult();
        await simpleSend;
        Assert.That(connection.ItemIds, Has.Count.EqualTo(1));
    }

    [Test]
    public async Task TerminalResponseReleasesConnectionCancellationRegistration()
    {
        using var connectionCancellation = new CancellationTokenSource();
        var response = new VoiceResponse(
            new CoordinatedConnection(),
            "r_test",
            new[] { "in_test" },
            wireOpened: false,
            accepted: true,
            connectionCancellation.Token);

        await response.MarkTerminalAsync();

        Assert.That(response.IsConnectionCancellationRegistrationDisposed, Is.True);
    }

    [Test]
    public async Task NormalDoneReleasesConnectionRegistrationWithoutCancellingResponseToken()
    {
        using var connectionCancellation = new CancellationTokenSource();
        var connection = new CoordinatedConnection();
        connection.AllowFirstSend.TrySetResult();
        var response = new VoiceResponse(
            connection,
            "r_test",
            new[] { "in_test" },
            wireOpened: false,
            accepted: true,
            connectionCancellation.Token);

        await response.SendTextAsync("complete");
        Assert.That(response.IsConnectionCancellationRegistrationDisposed, Is.False);

        await response.CompleteAsync();
        await connectionCancellation.CancelAsync();

        Assert.Multiple(() =>
        {
            Assert.That(response.IsTerminal, Is.True);
            Assert.That(response.IsConnectionCancellationRegistrationDisposed, Is.True);
            Assert.That(response.CancellationToken.IsCancellationRequested, Is.False);
        });
    }

    [Test]
    public async Task ReleasingTerminalResponseCompactsItemsButPreservesOwnership()
    {
        var connection = new CoordinatedConnection();
        connection.AllowFirstSend.TrySetResult();
        var response = new VoiceResponse(
            connection,
            "r_test",
            new[] { "in_test" },
            wireOpened: false,
            accepted: true,
            CancellationToken.None);
        var itemIds = new List<string>(VoiceProtocolConstants.MaxResponseItems);
        for (var index = 0; index < VoiceProtocolConstants.MaxResponseItems; index++)
        {
            var item = response.CreateTextItem();
            itemIds.Add(item.ItemId);
            await item.SendTextAsync(string.Empty);
        }

        await response.MarkTerminalAsync();
        response.ReleaseOutputBuffers();

        var itemsField = typeof(VoiceResponse).GetField(
            "_items",
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)!;
        var items = (List<VoiceTextItem>)itemsField.GetValue(response)!;
        Assert.Multiple(() =>
        {
            Assert.That(items.Count, Is.Zero);
            Assert.That(items.Capacity, Is.Zero);
            Assert.That(response.OwnsItem(itemIds[0]), Is.True);
            Assert.That(response.OwnsItem(itemIds[^1]), Is.True);
            Assert.That(response.OwnsItem("it_00000000000000000000000000000000"), Is.False);
        });
    }

    [Test]
    public void CancelledSimpleSendDoesNotSelectSimpleItemMode()
    {
        var response = new VoiceResponse(
            new CoordinatedConnection(),
            "r_test",
            new[] { "in_test" },
            wireOpened: false,
            accepted: true,
            CancellationToken.None);
        using var cancellation = new CancellationTokenSource();
        cancellation.Cancel();

        Assert.That(
            async () => await response.SendTextDeltaAsync("cancelled", cancellation.Token),
            Throws.InstanceOf<OperationCanceledException>());
        Assert.DoesNotThrow(() => response.CreateTextItem());
    }

    private sealed class CoordinatedConnection : IVoiceConnection
    {
        private int _sendCount;

        public bool Ending => false;

        public TaskCompletionSource FirstSendStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource AllowFirstSend { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public List<string> ItemIds { get; } = new();

        public async Task SendResponseFrameAsync(
            VoiceResponse response,
            string messageType,
            IReadOnlyDictionary<string, object?> fields,
            Action commit,
            bool terminal,
            string? terminalKind,
            CancellationToken cancellationToken)
        {
            var reservation = response.ReserveSend(opensResponse: !response.IsWireOpened);
            var sendNumber = Interlocked.Increment(ref _sendCount);
            if (sendNumber == 1)
            {
                FirstSendStarted.TrySetResult();
                await AllowFirstSend.Task.WaitAsync(cancellationToken);
            }

            if (!response.TryCommitSend(reservation, commit, terminal))
            {
                throw new VoiceBridgeConnectionClosedException("The response lost test arbitration.");
            }

            if (fields.TryGetValue("item_id", out var itemId))
            {
                ItemIds.Add((string)itemId!);
            }
        }

        public Task<bool> OpenResponseAsync(
            VoiceResponse response,
            IReadOnlyList<string>? inReplyTo,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public Task DeclineResponseAsync(
            VoiceResponse response,
            IReadOnlyList<string> inReplyTo,
            string? reason,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public Task<Task<ResponseCancellationOutcome>> BeginCancelAsync(
            VoiceResponse response,
            string? reason,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public Task RegisterDtmfCollectionAsync(
            VoiceResponse response,
            string collectionId,
            int maxDigits,
            string? terminator,
            int initialTimeoutMs,
            int interDigitTimeoutMs,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public Task CancelDtmfCollectionAsync(string collectionId, CancellationToken cancellationToken) =>
            throw new NotSupportedException();

        public Task EndCallAsync(string reason, string mode, CancellationToken cancellationToken) =>
            throw new NotSupportedException();

        public Task<VoiceResponse> StartProactiveResponseAsync(
            int admissionTimeoutMs,
            string? supersedeKey,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public Task ReportSessionErrorAsync(string code, string message, CancellationToken cancellationToken) =>
            throw new NotSupportedException();
    }
}
