// Azure AI Responses Server SDK — TypeSpec view
//
// This view selectively imports the OpenAI responses routes and models from the
// upstream Azure REST API spec and applies local customizations (client.tsp) to
// generate C# model classes in our SDK namespace.
//
// Pattern based on:
//   https://github.com/Azure/azure-rest-api-specs/.../sdk-service-agents-contracts

// OpenAI responses routes + models (routes reference the model types, making them visible to the emitter)
import "./TempTypeSpecFiles/openai-responses/routes.tsp";

// Common service definition (namespace Azure.AI.Projects, Versions enum)
import "./TempTypeSpecFiles/common/service.tsp";

// Common models (FoundryFeaturesOptInKeys, operation utilities, etc.)
import "./TempTypeSpecFiles/common/models.tsp";

// Local customizations (namespace mapping, sequence_number)
import "./client.tsp";
