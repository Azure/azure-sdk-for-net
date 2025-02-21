# Chat Completions with JSON Structured Output

This sample demonstrates how to get a chat completions response with the output structured to match a provided JSON format.

## Usage

Set these two environment variables before running the sample:

1. AZURE_AI_CHAT_ENDPOINT - Your endpoint URL, in the form `https://your-deployment-name.your-azure-region.inference.ai.azure.com` where `your-deployment-name` is your unique AI Model deployment name, and `your-azure-region` is the Azure region where your model is deployed.

2. AZURE_AI_CHAT_KEY - Your model key. Keep it secret, keep it safe.

In order to instruct the model that you want the output to follow a specific structure, you need to build out the JSON schema that you want the model to use. The schema is then given a name and passed to the `ChatCompletionsResponseFormat.CreateJsonFormat` method, which can then be provided to the `ResponseFormat` property of the request options object.

```C# Snippet:Azure_AI_Inference_SampleStructuredOutput
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

var messages = new List<ChatRequestMessage>()
{
    new ChatRequestSystemMessage("You are a helpful assistant."),
    new ChatRequestUserMessage("Please give me directions and ingredients to bake a chocolate cake."),
};

var requestOptions = new ChatCompletionsOptions(messages);

Dictionary<string, BinaryData> jsonSchema = new Dictionary<string, BinaryData>
{
    { "type", BinaryData.FromString("\"object\"") },
    { "properties", BinaryData.FromString("""
        {
            "ingredients": {
                "type": "array",
                "items": {
                    "type": "string"
                }
            },
            "steps": {
                "type": "array",
                "items": {
                    "type": "object",
                    "properties": {
                        "ingredients": {
                            "type": "array",
                            "items": {
                                "type": "string"
                            }
                        },
                        "directions": {
                            "type": "string"
                        }
                    }
                }
            },
            "prep_time": {
                "type": "string"
            },
            "bake_time": {
                "type": "string"
            }
        }
        """) },
    { "required", BinaryData.FromString("[\"ingredients\", \"steps\", \"bake_time\"]") },
    { "additionalProperties", BinaryData.FromString("false") }
};

requestOptions.ResponseFormat = ChatCompletionsResponseFormat.CreateJsonFormat("cakeBakingDirections", jsonSchema);

Response<ChatCompletions> response = client.Complete(requestOptions);
```

When the response is returned, it can then be parsed into the expected JSON format.

```C# Snippet:Azure_AI_Inference_SampleStructuredOutputParseJson
using JsonDocument structuredJson = JsonDocument.Parse(result.Content);
structuredJson.RootElement.TryGetProperty("ingredients", out var ingredients);
structuredJson.RootElement.TryGetProperty("steps", out var steps);
structuredJson.RootElement.TryGetProperty("bake_time", out var bakeTime);
```

Printing the output to the console can also show that the output met the expected structure which was requested.

```C# Snippet:Azure_AI_Inference_SampleStructuredOutputPrintOutput
var options = new JsonSerializerOptions
{
    WriteIndented = true
};
Console.WriteLine($"Ingredients: {System.Text.Json.JsonSerializer.Serialize(ingredients, options)}");
Console.WriteLine($"Steps: {System.Text.Json.JsonSerializer.Serialize(steps, options)}");
Console.WriteLine($"Bake time: {System.Text.Json.JsonSerializer.Serialize(bakeTime, options)}");
```

```Text
Ingredients: [
  "2 cups of all-purpose flour",
  "2 cups of sugar",
  "3/4 cup of unsweetened cocoa powder",
  "2 teaspoons of baking powder",
  "1 1/2 teaspoons of baking soda",
  "1 teaspoon of salt",
  "1 teaspoon of instant coffee powder (optional, for enhancing chocolate flavor)",
  "1 cup of milk",
  "1/2 cup of vegetable oil",
  "2 large eggs",
  "2 teaspoons of vanilla extract",
  "1 cup of boiling water"
]
Steps: [
  {
    "ingredients": [
      "all-purpose flour",
      "sugar",
      "unsweetened cocoa powder",
      "baking powder",
      "baking soda",
      "salt",
      "instant coffee powder if using"
    ],
    "directions": "Preheat your oven to 350°F (177°C) and grease and lightly flour two 9-inch round baking pans or line them with parchment paper. In a large bowl sift together the dry ingredients."
  },
  {
    "ingredients": [
      "milk",
      "vegetable oil",
      "eggs",
      "vanilla extract"
    ],
    "directions": "Add the milk, vegetable oil, eggs, and vanilla to the bowl of dry ingredients and mix until smooth and well combined."
  },
  {
    "ingredients": [
      "boiling water"
    ],
    "directions": "Slowly add the cup of boiling water to the mixture (the batter will be thin). Stir until well mixed."
  },
  {
    "ingredients": [],
    "directions": "Divide the batter evenly between the two prepared pans and bake in the preheated oven for 30-35 minutes, or until a toothpick inserted in the center comes out clean."
  },
  {
    "ingredients": [],
    "directions": "Remove the cakes from the oven and allow them to cool in the pans for about 10 minutes, then transfer them to a wire rack to cool completely."
  }
]
Bake time: "30-35 minutes"
```
