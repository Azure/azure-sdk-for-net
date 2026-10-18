import "@azure-tools/typespec-client-generator-core";

using Azure.ClientGenerator.Core;

namespace Widget;

@@clientName(WidgetProperties.enabled, "enabled", "java");
@@clientName(WidgetProperties.enabled, "enabled", "python");

// Preserve this trailing customization.
@@clientName(WidgetProperties, "WidgetSettings", "python");
