Authenticate to Azure using environment variables
-------------

You'll need the following values to authenticate to Azure:

-   **Subscription ID**
-   **Client ID**
-   **Client Secret**
-   **Tenant ID**

## Obtaining the values

These values can be obtained from the [portal](https://portal.azure.com/) with the following instructions:

### Get Subscription ID

1.  Log in to your Azure account.
2.  Select **Subscriptions** in the left sidebar.
3.  Select the subscription to be used.
4.  Select **Overview**.
5.  Copy the Subscription ID.

### Get Client ID / Client Secret / Tenant ID

For information on how to get Client ID, Client Secret, and Tenant ID, see [this
document](https://docs.microsoft.com/azure/active-directory/develop/howto-create-service-principal-portal).

## Setting Environment Variables

After you obtain the values, set the following environment variables:

-   `AZURE_CLIENT_ID`
-   `AZURE_CLIENT_SECRET`
-   `AZURE_TENANT_ID`
-   `AZURE_SUBSCRIPTION_ID`

To set the environment variables on your development system:

### Windows:

_(Note: Administrator access is required)_

1.  Open the **Control Panel**.
2.  Select **System Security** > **System**.
3.  Select **Advanced system settings** on the left.
4.  Inside the **System Properties** window, select the **Environment Variables** button.
5.  Select the property you'd like to change, then select the **Edit** button. If the property name isn't listed, select the **New** button.

### Linux-based OS:

    export AZURE_CLIENT_ID="__CLIENT_ID__"
    export AZURE_CLIENT_SECRET="__CLIENT_SECRET__"
    export AZURE_TENANT_ID="__TENANT_ID__"
    export AZURE_SUBSCRIPTION_ID="__SUBSCRIPTION_ID__"
