/**
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License. See License.txt in the project root for
 * license information.
 */
package com.microsoft.azure.functions.signalr.annotation;

import java.lang.annotation.Retention;
import java.lang.annotation.Target;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.ElementType;

import com.microsoft.azure.functions.annotation.CustomBinding;

/**
 * <p>Place this on a parameter to obtain a SignalRConnectionInfo object.
 * The parameter type can be one of the following:</p>
 *
 * <ul>
 *     <li>SignalRConnectionInfo type</li>
 * </ul>
 */
@Target(ElementType.PARAMETER)
@Retention(RetentionPolicy.RUNTIME)
@CustomBinding(direction = "in", name = "", type = "SignalRConnectionInfo")
public @interface SignalRConnectionInfoInput {

    /**
     * The variable name used in function.json.
     * @return The variable name used in function.json.
     */
    String name();

    /**
     * Defines the app setting name that contains the Azure SignalR Service connection string.
     * @return The app setting name of the connection string.
     */
    String connectionStringSetting() default "";

    /**
     * Defines the name of the hub in Azure SignalR Service to which to connect.
     * @return The hub name.
     */
    String hubName();
 
    /**
     * Defines the user ID to associate with the connection. Typically uses a 
     * binding expression such as {x-ms-client-principal-name} (the principal name 
     * from App Service Authentication).
     * @return The user ID.
     */
    String userId() default "";
}
