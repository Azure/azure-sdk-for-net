# OpenTelemetry Semantic Conventions

Azure client libraries follow OpenTelemetry semantic conventions on distributed traces.
In addition to general conventions described in the [azure-sdk repo](https://github.com/Azure/azure-sdk/blob/main/docs/observability/opentelemetry-conventions.md), some of the .NET libraries emit
additional attributes on public API spans. Such attributes are described below.

## Azure Application Configuration attributes

| Attribute  | Type | Description  | Examples  | Requirement Level |
|---|---|---|---|---|
| `az.appconfiguration.key` | string | Value of the Azure Application Configuration property [key](https://learn.microsoft.com/azure/azure-app-configuration/concept-key-value). | `AppName:Service1:ApiEndpoint` | Recommended |

## Azure Cognitive Language Question Answering SDK attributes

| Attribute  | Type | Description  | Examples  | Requirement Level |
|---|---|---|---|---|
| `az.cognitivelanguage.deployment.name` | string | Name of the [Azure Questions Answering](https://learn.microsoft.com/azure/ai-services/language-service/question-answering/overview) deployment. | `production` | Recommended |
| `az.cognitivelanguage.project.name` | string | Name of the [Azure Questions Answering](https://learn.microsoft.com/azure/ai-services/language-service/question-answering/overview) project. | `production` | Recommended |

## Azure Digital Twins attributes

| Attribute  | Type | Description  | Examples  | Requirement Level |
|---|---|---|---|---|
| `az.digitaltwins.component.name` | string | The name of the digital twin component. | `thermostat` | Recommended |
| `az.digitaltwins.event_route.id` | string | The [event route](https://learn.microsoft.com/azure/digital-twins/concepts-route-events) identifier used by the digital twin. | `6f8741b1` | Recommended |
| `az.digitaltwins.job.id` | string | Digital twin job ID. | `test-job` | Recommended |
| `az.digitaltwins.message.id` | string | A unique message identifier (in the scope of the digital twin ID) used to de-duplicate telemetry messages. | `a40896c5ab954ab1` | Recommended |
| `az.digitaltwins.model.id` | string | The digital twin model ID. | `dtmi:example:Room23;1` | Recommended |
| `az.digitaltwins.query` | string | Digital twin graph query. | `SELECT * FROM DIGITALTWINS WHERE Name = "DSouza"` | Recommended |
| `az.digitaltwins.relationship.name` | string | The name of the relationship between twins. | `contains` | Recommended |
| `az.digitaltwins.twin.id` | string | The unique identifier of a [digital twin](https://learn.microsoft.com/azure/digital-twins/concepts-twins-graph). | `edf41622` | Recommended |

## Azure Key Vault attributes

### Azure Key Vault Certificates attributes

| Attribute  | Type | Description  | Examples  | Requirement Level |
|---|---|---|---|---|
| `az.keyvault.certificate.issuer.name` | string | The Azure Key Vault certificate issuer name. | `issuer01` | Recommended |
| `az.keyvault.certificate.name` | string | The Azure Key Vault certificate name. | `selfSignedCert01` | Recommended |
| `az.keyvault.certificate.version` | string | The Azure Key Vault certificate version. | `c3d31d7b36c942ad83ef36fc0785a4fc` | Recommended |

### Azure Key Vault Keys attributes

| Attribute  | Type | Description  | Examples  | Requirement Level |
|---|---|---|---|---|
| `az.keyvault.key.id` | string | The Azure Key Vault key ID (full URL). | `"https://myvault.vault.azure.net/keys/CreateSoftKeyTest/78deebed173b48e48f55abf87ed4cf71"` | Recommended |
| `az.keyvault.key.name` | string | The Azure Key Vault key name. | `test-key` | Recommended |
| `az.keyvault.key.version` | string | The Azure Key Vault key version. | `3d31e6e5c4c14eaf9be8d42c00225088` | Recommended |

### Azure Key Vault Secrets attributes

| Attribute  | Type | Description  | Examples  | Requirement Level |
|---|---|---|---|---|
| `az.keyvault.secret.name` | string | The Azure Key Vault secret name. | `test-secret` | Recommended |
| `az.keyvault.secret.version` | string | The Azure Key Vault secret version. | `4387e9f3d6e14c459867679a90fd0f79` | Recommended |

### Azure Mixed Reality Remote Rendering attributes

| Attribute  | Type | Description  | Examples  | Requirement Level |
|---|---|---|---|---|
| `az.remoterendering.conversion.id` | string | A conversion ID uniquely identifying the conversion for the given [Azure Remote Rendering](https://learn.microsoft.com/windows/mixed-reality/develop/mixed-reality-cloud-services#azure-remote-rendering) account. | `contoso-conversion-6fae2bfb754e` | Recommended |
| `az.remoterendering.session.id` | string | A session ID uniquely identifying the conversion for the given [Azure Remote Rendering](https://learn.microsoft.com/windows/mixed-reality/develop/mixed-reality-cloud-services#azure-remote-rendering) account. | `contoso-session-8c28813adc28` | Recommended |
