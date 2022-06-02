// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.Azure.Amqp.Sasl;
using Microsoft.Azure.Amqp.Transport;
using Microsoft.Azure.Devices;

namespace IotHubToEventHubsSample
{
    /// <summary>
    ///   A transient connection to the IoT Hub service, providing a set of utility-type operations that
    ///   span the service client and device roles.
    /// </summary>
    ///
    public static class IotHubConnection
    {
        /// <summary>The regular expression used to parse the Event Hub name from the IoT Hub redirection address.</summary>
        private static readonly Regex EventHubNameExpression = new Regex(@":\d+\/(?<eventHubName>.*)\/\$management", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        /// <summary>
        ///   Requests connection string for the built-in Event Hubs messaging endpoint of the associated IoT Hub.
        /// </summary>
        ///
        /// <param name="iotHubConnectionString">The connection string for the IoT Hub instance to request the Event Hubs connection string from.</param>
        /// <param name="timeout">The maximum amount of time that the request and translation should be allowed to take.  If not provided, a default of 60 seconds will be assumed.</param>
        ///
        /// <returns>A connection string which can be used to connect to the Event Hubs service and interact with the IoT Hub messaging endpoint.</returns>
        ///
        /// <exception cref="InvalidOperationException">The Event Hubs host information was not returned by the IoT Hub service.</exception>
        ///
        /// <seealso href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-endpoints" />
        /// <seealso href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-messages-read-builtin" />
        /// <seealso href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-amqp-support#receive-telemetry-messages-service-client" />
        ///
        public static async Task<string> RequestEventHubsConnectionStringAsync(string iotHubConnectionString,
                                                                               TimeSpan? timeout = default)
        {
            timeout ??= TimeSpan.FromMinutes(1);

            if (string.IsNullOrEmpty(iotHubConnectionString))
            {
                throw new ArgumentException("The IoT Hub connection string must be provided.", nameof(iotHubConnectionString));
            }

            // Parse the connection string into the necessary components, and ensure the information is available.

            var parsedConnectionString = IotHubConnectionStringBuilder.Create(iotHubConnectionString);
            var iotHubName = parsedConnectionString.HostName?.Substring(0, parsedConnectionString.HostName.IndexOf('.'));

            if ((string.IsNullOrEmpty(parsedConnectionString.HostName)) || (string.IsNullOrEmpty(parsedConnectionString.SharedAccessKeyName)) || (string.IsNullOrEmpty(parsedConnectionString.SharedAccessKey)))
            {
                throw new ArgumentException("The IoT Hub connection string is not valid; it must contain the host, shared access key, and shared access key name.", nameof(iotHubConnectionString));
            }

            if (string.IsNullOrEmpty(iotHubName))
            {
                throw new ArgumentException("Unable to parse the IoT Hub name from the connection string.", nameof(iotHubConnectionString));
            }

            // Establish the IoT Hub connection via link to the necessary endpoint, which will trigger a redirect exception
            // from which the Event Hubs connection string can be built.

            var stopWatch = Stopwatch.StartNew();
            var serviceEndpoint = new Uri($"{ AmqpConstants.SchemeAmqps }://{ parsedConnectionString.HostName }/messages/events");
            var connection = default(AmqpConnection);
            var link = default(AmqpLink);
            var eventHubsHost = default(string);
            var eventHubName = default(string);

            try
            {
                connection = await CreateAndOpenConnectionAsync(serviceEndpoint, iotHubName, parsedConnectionString.SharedAccessKeyName, parsedConnectionString.SharedAccessKey, timeout.Value).ConfigureAwait(false);
                link = await CreateRedirectLinkAsync(connection, serviceEndpoint, timeout.Value.Subtract(stopWatch.Elapsed)).ConfigureAwait(false);

                await link.OpenAsync(timeout.Value.Subtract(stopWatch.Elapsed)).ConfigureAwait(false);
            }
            catch (AmqpException ex)
                when ((ex?.Error?.Condition.Value == AmqpErrorCode.LinkRedirect.Value) && (ex?.Error?.Info != null))
            {
                // The Event Hubs host is returned as a first-party element of the redirect information.

                ex.Error.Info.TryGetValue("hostname", out eventHubsHost);

                // The Event Hub name is a variant of the IoT Hub name and must be parsed from the
                // full IoT Hub address returned by the redirect.

                if (ex.Error.Info.TryGetValue("address", out string iotAddress))
                {
                    //  If the address does not match the expected pattern, this will not result in an exception; the Event Hub
                    // name will remain null and trigger a failed validation later in the flow.

                    eventHubName = EventHubNameExpression.Match(iotAddress).Groups["eventHubName"].Value;
                }
            }
            finally
            {
                stopWatch.Stop();

                link?.Session?.SafeClose();
                link?.SafeClose();
                connection?.SafeClose();
            }

            // Attempt to assemble the Event Hubs connection string using the IoT Hub components.

            if (string.IsNullOrEmpty(eventHubsHost))
            {
                throw new InvalidOperationException("The Event Hubs host was not returned by the IoT Hub service.");
            }

            if (string.IsNullOrEmpty(eventHubName))
            {
                throw new InvalidOperationException("The Event Hub name was not returned by the IoT Hub service.");
            }

            return $"Endpoint=sb://{ eventHubsHost }/;EntityPath={ eventHubName };SharedAccessKeyName={ parsedConnectionString.SharedAccessKeyName };SharedAccessKey={ parsedConnectionString.SharedAccessKey }";
        }

        /// <summary>
        ///   Performs the tasks needed to build and open a connection to the IoT Hub
        ///   service.
        /// </summary>
        ///
        /// <param name="serviceEndpoint">The endpoint of the IoT Hub service to connect to.</param>
        /// <param name="iotHubName">The name of the IoT Hub to connect to.</param>
        /// <param name="sharedAccessKeyName">The name of the shared access key being used for authentication.</param>
        /// <param name="sharedAccessKey">The shared access key being used for authentication.</param>
        /// <param name="timeout">The maximum amount of time that establishing the connection should be allowed to take.</param>
        ///
        /// <returns>An <see cref="AmqpConnection" /> to the requested IoT Hub.</returns>
        ///
        /// <seealso href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-amqp-support"/>
        ///
        private static async Task<AmqpConnection> CreateAndOpenConnectionAsync(Uri serviceEndpoint,
                                                                               string iotHubName,
                                                                               string sharedAccessKeyName,
                                                                               string sharedAccessKey,
                                                                               TimeSpan timeout)
        {
            var hostName = serviceEndpoint.Host;
            var userName = $"{ sharedAccessKeyName }@sas.root.{ iotHubName }";
            var signature = BuildSignature($"{ hostName }{ serviceEndpoint.AbsolutePath }", sharedAccessKeyName, sharedAccessKey, TimeSpan.FromMinutes(5));
            var port = 5671;

            // Create the layers of settings needed to establish the connection.

            var amqpVersion = new Version(1, 0, 0, 0);

            var tcpSettings = new TcpTransportSettings
            {
                Host = hostName,
                Port = port,
                ReceiveBufferSize = AmqpConstants.TransportBufferSize,
                SendBufferSize = AmqpConstants.TransportBufferSize
            };

            var transportSettings = new TlsTransportSettings(tcpSettings)
            {
                TargetHost = hostName,
            };

            var connectionSettings = new AmqpConnectionSettings
            {
                IdleTimeOut = (uint)TimeSpan.FromMinutes(1).TotalMilliseconds,
                MaxFrameSize = AmqpConstants.DefaultMaxFrameSize,
                ContainerId = Guid.NewGuid().ToString(),
                HostName = hostName
            };

            var saslProvider = new SaslTransportProvider();
            saslProvider.Versions.Add(new AmqpVersion(amqpVersion));
            saslProvider.AddHandler(new SaslPlainHandler { AuthenticationIdentity = userName, Password = signature });

            var amqpProvider = new AmqpTransportProvider();
            amqpProvider.Versions.Add(new AmqpVersion(amqpVersion));

            var amqpSettings = new AmqpSettings();
            amqpSettings.TransportProviders.Add(saslProvider);
            amqpSettings.TransportProviders.Add(amqpProvider);

            // Create and open the connection, respecting the timeout constraint
            // that was received.

            var stopWatch = Stopwatch.StartNew();
            var initiator = new AmqpTransportInitiator(amqpSettings, transportSettings);
            var transport = await initiator.ConnectTaskAsync(timeout).ConfigureAwait(false);

            try
            {
                var connection = new AmqpConnection(transport, amqpSettings, connectionSettings);
                await connection.OpenAsync(timeout.Subtract(stopWatch.Elapsed)).ConfigureAwait(false);

                return connection;
            }
            catch
            {
                transport.Abort();
                throw;
            }
            finally
            {
                stopWatch.Stop();
            }
        }

        /// <summary>
        ///   Creates the AMQP link used to trigger a redirection response from the
        ///   IoT Hub service.
        /// </summary>
        ///
        /// <param name="connection">The connection to the IoT Hub service to associate the link with.</param>
        /// <param name="serviceEndpoint">The endpoint of the IoT Hub service that the connection was made to.</param>
        /// <param name="timeout">The maximum amount of time that creating the link should be allowed to take.</param>
        ///
        /// <returns>An <see cref="AmqpLink" /> to an IoT Hub resource that will trigger redirection when opened.</returns>
        ///
        /// <remarks>
        ///   The link is not opened by this method; callers are required to open the link in order to trigger
        ///   the redirection error.
        /// </remarks>
        ///
        /// <seealso href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-amqp-support"/>
        ///
        private static async Task<AmqpLink> CreateRedirectLinkAsync(AmqpConnection connection,
                                                                    Uri serviceEndpoint,
                                                                    TimeSpan timeout)
        {
            var linkPath = $"{ serviceEndpoint.AbsolutePath }/$management";
            var session = default(AmqpSession);

            try
            {
                var sessionSettings = new AmqpSessionSettings { Properties = new Fields() };
                session = connection.CreateSession(sessionSettings);

                await session.OpenAsync(timeout).ConfigureAwait(false);

                var linkSettings = new AmqpLinkSettings
                {
                    Role = true,
                    TotalLinkCredit = 1,
                    AutoSendFlow = true,
                    SettleType = SettleMode.SettleOnSend,
                    Source = new Source { Address = linkPath },
                    Target = new Target { Address = serviceEndpoint.AbsoluteUri }
                };

                var link = new ReceivingAmqpLink(linkSettings);
                linkSettings.LinkName = $"{ nameof(IotHubConnection) };{ connection.Identifier }:{ session.Identifier }:{ link.Identifier }";
                link.AttachTo(session);

                return link;
            }
            catch
            {
                session?.Abort();
                throw;
            }
        }
        /// <summary>
        ///   Builds a shared access signature to use for authentication with the IoT Hub
        ///   service.
        /// </summary>
        ///
        /// <param name="resourceUri">The address of the resource the signature is intended to authenticate for.</param>
        /// <param name="keyName">Name of the shared access key to base the signature on.</param>
        /// <param name="keyValue">The value of the shared access key to base the signature on.</param>
        /// <param name="validityDuration">The amount of time that the signature should be considered valid; after this time a new signature would be needed.</param>
        ///
        /// <returns>The shared access signature, encoded and suitable for use as a credential in service communication.</returns>
        ///
        /// <seealso href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-security#security-tokens" />
        ///
        private static string BuildSignature(string resourceUri,
                                             string keyName,
                                             string keyValue,
                                             TimeSpan validityDuration)
        {
            using var hmac = new HMACSHA256(Convert.FromBase64String(keyValue));

            var epoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
            var expirationTime = Convert.ToInt64((DateTimeOffset.UtcNow.Add(validityDuration) - epoch).TotalSeconds);
            var encodedAudience = WebUtility.UrlEncode(resourceUri);
            var expiration = Convert.ToString(expirationTime, CultureInfo.InvariantCulture);
            var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes($"{ encodedAudience }\n{ expiration }")));

            return string.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}&skn={3}",
                encodedAudience,
                WebUtility.UrlEncode(signature),
                WebUtility.UrlEncode(expiration),
                WebUtility.UrlEncode(keyName));
        }
    }
}
