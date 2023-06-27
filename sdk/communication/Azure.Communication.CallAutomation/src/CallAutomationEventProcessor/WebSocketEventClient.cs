using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Azure.Communication.CallAutomation.CallAutomationEventProcessor
{
    internal class WebSocketEventClient
    {
        private readonly ClientWebSocket _client = new();
        private volatile bool _isEstablished = false;
        public bool IsEstablished
        {
            get { return _isEstablished; }
            private set { _isEstablished = value; }
        }
        public string ConnectionId { get; private set; }

        public async Task TryToEstablishWebsocketConnection(string webSocketUrl, string connectionId)
        {
            try
            {
                await _client.ConnectAsync(new Uri(webSocketUrl), CancellationToken.None).ConfigureAwait(false);
                await SendPayload(connectionId).ConfigureAwait(false);
                await ReceiveResponses().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"WebSocket error: {ex.Message}");
            }
        }

        private async Task SendPayload(string payload)
        {
            var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(payload));
            await _client.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None).ConfigureAwait(false);
        }

        private async Task ReceiveResponses()
        {
            var buffer = new byte[8192];
            var stringBuilder = new StringBuilder();

            while (_client.State == WebSocketState.Open)
            {
                var receiveResult = await _client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None).ConfigureAwait(false);

                if (receiveResult.MessageType == WebSocketMessageType.Close)
                {
                    await _client.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None).ConfigureAwait(false);
                }
                else
                {
                    var response = Encoding.UTF8.GetString(buffer, 0, receiveResult.Count);
                    stringBuilder.Append(response);

                    if (receiveResult.EndOfMessage)
                    {
                        string msg = stringBuilder.ToString();
                        stringBuilder.Clear();

                        if (msg == "ack")
                        {
                            IsEstablished = true;
                        }
                        else
                        {
                            // Handle the event
                        }
                    }
                }
            }
        }
    }
}
