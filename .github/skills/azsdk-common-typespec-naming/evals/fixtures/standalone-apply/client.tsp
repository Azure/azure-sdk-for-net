import "./main.tsp";
import "@azure-tools/typespec-client-generator-core";

using Azure.ClientGenerator.Core;
using Widget;

@@clientName(WidgetProperties.enabled, "EnabledForJava", "java");
@@clientName(WidgetProperties.enabled, "enabled_for_python", "python");
