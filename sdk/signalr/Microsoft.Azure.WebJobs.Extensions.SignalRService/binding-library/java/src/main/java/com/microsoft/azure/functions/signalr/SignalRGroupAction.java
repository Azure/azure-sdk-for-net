/**
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License. See License.txt in the project root for
 * license information.
 */
package com.microsoft.azure.functions.signalr;

/**
 * <p>
 * SignalR group action (used with SignalR output binding)
 * </p>
 *
 * @since 1.0.0
 */
public class SignalRGroupAction {

    /**
     * Constructor
     */
    public SignalRGroupAction() {
    }

    /**
     * Constructor
     * @param action    Action to take ("add" or "remove")
     * @param groupName Group to add user to or remove user from
     * @param userId    User to add to or remove from group
     */
    public SignalRGroupAction(String action, String groupName, String userId, String connectionId) {
        this.action = action;
        this.groupName = groupName;
        this.userId = userId;
        this.connectionId = connectionId;
    }

    /**
     * Connection to add to or remove from group
     */
    public String connectionId = "";

    /**
     * User to add to or remove from group
     */
    public String userId = "";

    /**
     * Group to add user to or remove user from
     */
    public String groupName = "";

    /**
     * Action to take ("add" or "remove")
     */
    public String action = "";
}