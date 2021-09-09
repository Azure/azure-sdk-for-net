/**
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License. See License.txt in the project root for
 * license information.
 */
package com.microsoft.azure.functions.signalr;

/**
 * <p>
 * SignalR connection information (used with SignalRConnectionInfo input binding)
 * </p>
 *
 * @since 1.0.0
 */
public class SignalRConnectionInfo {
    /**
     * SignalR Sevice endpoint
     */
    public String url;

    /**
     * Access token to use to connect to SignalR Service endpoint
     */
    public String accessToken;
}