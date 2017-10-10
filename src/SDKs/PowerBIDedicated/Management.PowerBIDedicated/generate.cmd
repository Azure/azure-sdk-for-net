::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

autorest -Modeler Swagger -CodeGenerator Azure.CSharp -Namespace Microsoft.Azure.Management.PowerBIDedicated -Input https://github.com/Azure/azure-rest-api-specs-pr/blob/current/specification/powerbidedicated/resource-manager/Microsoft.PowerBIdedicated/2017-10-01/powerbidedicated.json -outputDirectory .\Generated -Header MICROSOFT_MIT