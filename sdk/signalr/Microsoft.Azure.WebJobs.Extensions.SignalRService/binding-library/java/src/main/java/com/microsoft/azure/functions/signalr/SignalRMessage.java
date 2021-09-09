/**
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License. See License.txt in the project root for
 * license information.
 */
package com.microsoft.azure.functions.signalr;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * <p>
 * SignalR Message to use with SignalR output binding
 * </p>
 *
 * @since 1.0.0
 */
public class SignalRMessage {

    /**
     * Constructor
     */
    public SignalRMessage() {
    }

    /**
     * Constructor
     * 
     * @param target    Target method to invoke on clients
     * @param arguments Arguments to pass to target method
     */
    public SignalRMessage(String target, Object... arguments) {
        this.target = target;
        this.arguments.addAll(Arrays.asList(arguments));
    }

    /**
     * ConnectionId to send the message to
     */
    public String connectionId = "";  

    /**
     * User to send the message to
     */
    public String userId = "";

    /**
     * Group to send the message to
     */
    public String groupName = "";

    /**
     * Target method to invoke on clients
     */
    public String target;

    /**
     * Arguments to pass to target method
     */
    public List<Object> arguments = new ArrayList<Object>();
}