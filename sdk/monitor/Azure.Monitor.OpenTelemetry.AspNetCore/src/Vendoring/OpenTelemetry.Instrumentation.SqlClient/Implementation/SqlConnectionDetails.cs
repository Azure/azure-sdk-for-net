// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace OpenTelemetry.Instrumentation.SqlClient.Implementation;

internal sealed class SqlConnectionDetails
{
    /*
     * Match...
     *  protocol[ ]:[ ]serverName
     *  serverName
     *  serverName[ ]\[ ]instanceName
     *  serverName[ ],[ ]port
     *  serverName[ ]\[ ]instanceName[ ],[ ]port
     *
     * [ ] can be any number of white-space, SQL allows it for some reason.
     *
     * Optional "protocol" can be "tcp", "lpc" (shared memory), or "np" (named pipes). See:
     *  https://docs.microsoft.com/troubleshoot/sql/connect/use-server-name-parameter-connection-string, and
     *  https://docs.microsoft.com/dotnet/api/system.data.sqlclient.sqlconnection.connectionstring?view=dotnet-plat-ext-5.0
     *
     * In case of named pipes the Data Source string can take form of:
     *  np:serverName\instanceName, or
     *  np:\\serverName\pipe\pipeName, or
     *  np:\\serverName\pipe\MSSQL$instanceName\pipeName - in this case a separate regex (see NamedPipeRegex below)
     *  is used to extract instanceName
     */
    private static readonly Regex DataSourceRegex = new("^(.*\\s*:\\s*\\\\{0,2})?(.*?)\\s*(?:[\\\\,]|$)\\s*(.*?)\\s*(?:,|$)\\s*(.*)$", RegexOptions.Compiled);

    /// <summary>
    /// In a Data Source string like "np:\\serverName\pipe\MSSQL$instanceName\pipeName" match the
    /// "pipe\MSSQL$instanceName" segment to extract instanceName if it is available.
    /// </summary>
    /// <see>
    /// <a href="https://docs.microsoft.com/previous-versions/sql/sql-server-2016/ms189307(v=sql.130)"/>
    /// </see>
    private static readonly Regex NamedPipeRegex = new("pipe\\\\MSSQL\\$(.*?)\\\\", RegexOptions.Compiled);

    private static readonly ConcurrentDictionary<string, SqlConnectionDetails> ConnectionDetailCache = new(StringComparer.OrdinalIgnoreCase);

    private SqlConnectionDetails()
    {
    }

    public string? ServerHostName { get; private set; }

    public string? ServerIpAddress { get; private set; }

    public string? InstanceName { get; private set; }

    public int? Port { get; private set; }

    public static SqlConnectionDetails ParseFromDataSource(string dataSource)
    {
        if (ConnectionDetailCache.TryGetValue(dataSource, out var connectionDetails))
        {
            return connectionDetails;
        }

        var match = DataSourceRegex.Match(dataSource);

        var serverHostName = match.Groups[2].Value;
        string? serverIpAddress = null;
        string? instanceName = null;
        int? port = null;

        var uriHostNameType = Uri.CheckHostName(serverHostName);
        if (uriHostNameType is UriHostNameType.IPv4 or UriHostNameType.IPv6)
        {
            serverIpAddress = serverHostName;
            serverHostName = null;
        }

        var maybeProtocol = match.Groups[1].Value;
        var isNamedPipe = maybeProtocol.Length > 0 &&
                          maybeProtocol.StartsWith("np", StringComparison.OrdinalIgnoreCase);

        if (isNamedPipe)
        {
            var pipeName = match.Groups[3].Value;
            if (pipeName.Length > 0)
            {
                var namedInstancePipeMatch = NamedPipeRegex.Match(pipeName);
                if (namedInstancePipeMatch.Success)
                {
                    instanceName = namedInstancePipeMatch.Groups[1].Value;
                }
            }
        }
        else
        {
            if (match.Groups[4].Length > 0)
            {
                instanceName = match.Groups[3].Value;
                port = int.TryParse(match.Groups[4].Value, out var parsedPort)
                    ? parsedPort == 1433 ? null : parsedPort
                    : null;
            }
            else if (int.TryParse(match.Groups[3].Value, out var parsedPort))
            {
                instanceName = null;
                port = parsedPort == 1433 ? null : parsedPort;
            }
            else
            {
                instanceName = match.Groups[3].Value;
                if (string.IsNullOrEmpty(instanceName))
                {
                    instanceName = null;
                }

                port = null;
            }
        }

        connectionDetails = new SqlConnectionDetails
        {
            ServerHostName = serverHostName,
            ServerIpAddress = serverIpAddress,
            InstanceName = instanceName,
            Port = port,
        };

        ConnectionDetailCache.TryAdd(dataSource, connectionDetails);
        return connectionDetails;
    }
}
