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
 * <p>Output type to Azure SignalR Service</p>
 */
@Target({ ElementType.PARAMETER, ElementType.METHOD })
@Retention(RetentionPolicy.RUNTIME)
@CustomBinding(direction = "out", name = "", type = "SignalR")
public @interface SignalROutput {
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
}
