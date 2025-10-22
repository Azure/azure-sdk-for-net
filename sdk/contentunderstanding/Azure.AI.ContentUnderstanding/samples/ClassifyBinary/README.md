# Classify Binary Content Sample

This sample demonstrates how to classify binary content using Azure AI Content Understanding's classification API.

## What this sample does

1. **Authenticates** with Azure AI Content Understanding using either:
   - Azure Key Credential (if `AZURE_CONTENT_UNDERSTANDING_KEY` is provided)
   - Default Azure Credential (recommended for production)

2. **Loads a binary file** from the `sample_files` directory

3. **Classifies the content** using a prebuilt document classifier

4. **Displays the results** including:
   - Classification metadata (classifier ID, API version, creation time)
   - Content classification (category, kind, page range)
   - Usage information (document pages, token consumption)

## Prerequisites

- .NET 8.0 or later
- An Azure subscription
- An Azure AI Content Understanding resource
- A sample file in the `sample_files` directory

## Setup

1. **Configure authentication** by setting one of:
   - `AZURE_CONTENT_UNDERSTANDING_ENDPOINT` and `AZURE_CONTENT_UNDERSTANDING_KEY` environment variables
   - `AZURE_CONTENT_UNDERSTANDING_ENDPOINT` environment variable (uses DefaultAzureCredential)

2. **Add a sample file** to the `sample_files` directory:
   ```bash
   mkdir -p sample_files
   # Copy your PDF, DOC, DOCX, or other supported file to sample_files/sample_document.pdf
   ```

3. **Build and run** the sample:
   ```bash
   dotnet build
   dotnet run
   ```

## Configuration

The sample uses the following configuration (in order of precedence):

1. **Environment variables**:
   - `AZURE_CONTENT_UNDERSTANDING_ENDPOINT` (required)
   - `AZURE_CONTENT_UNDERSTANDING_KEY` (optional, for key-based auth)

2. **appsettings.json** (fallback):
   ```json
   {
     "AZURE_CONTENT_UNDERSTANDING_ENDPOINT": "https://your-resource.cognitiveservices.azure.com/",
     "AZURE_CONTENT_UNDERSTANDING_KEY": "your-key-here"
   }
   ```

## Supported File Types

The sample automatically detects content type based on file extension:

- **Documents**: PDF, DOC, DOCX, TXT, HTML
- **Images**: JPG, PNG, GIF, BMP, TIFF
- **Other**: Any binary content (as `application/octet-stream`)

## Sample Output

```
🔧 Creating ContentUnderstandingClient...
   Endpoint: https://your-resource.cognitiveservices.azure.com/
   Using DefaultAzureCredential authentication
✅ ContentUnderstandingClient created successfully
📄 Using sample file: sample_files/sample_document.pdf
✅ File loaded successfully (245760 bytes)
🔍 Using classifier: prebuilt-documentClassifier
📋 Content type: application/pdf
🚀 Starting content classification...
✅ Classification completed successfully!
📋 Extracted classification operation ID: 12345678-1234-1234-1234-123456789abc

🔍 Classification Results:
   Classifier ID: prebuilt-documentClassifier
   API Version: 2025-05-01-preview
   Created At: 2025-10-21T22:30:00Z
   String Encoding: utf8
   Contents Count: 1

📊 Classification Results:

📄 Content Type: DocumentContent
   MIME Type: application/pdf
   Category: invoice
   Path: sample_document.pdf
   Markdown Preview: # Invoice\n\n**Invoice Number:** INV-2025-001\n**Date:** 2025-10-21\n**Amount:** $1,234.56...
   Fields (3):
     - invoice_number: INV-2025-001
     - invoice_date: 2025-10-21
     - total_amount: $1,234.56
```

## Error Handling

The sample includes comprehensive error handling for:

- Missing configuration
- File not found
- Authentication failures
- Classification errors
- Network issues

## Related Samples

- **AnalyzeBinary**: Extract content from binary files
- **AnalyzeUrl**: Analyze content from URLs
- **CreateOrReplaceClassifier**: Create custom classifiers

## Troubleshooting

### Common Issues

1. **"Sample file not found"**
   - Ensure `sample_files/sample_document.pdf` exists
   - Check the file path is correct

2. **"AZURE_CONTENT_UNDERSTANDING_ENDPOINT is not set"**
   - Set the environment variable or update appsettings.json
   - Ensure the endpoint URL is correct

3. **Authentication errors**
   - Verify your credentials are correct
   - For DefaultAzureCredential, ensure you're logged in via Azure CLI or have appropriate permissions

4. **Classification fails**
   - Check that the file type is supported
   - Verify the classifier ID is correct
   - Ensure your Azure AI Content Understanding resource has the necessary capabilities

### Getting Help

- Check the [Azure AI Content Understanding documentation](https://docs.microsoft.com/azure/ai-services/content-understanding/)
- Review the [SDK reference documentation](https://docs.microsoft.com/dotnet/api/azure.ai.contentunderstanding)
- Open an issue in the [Azure SDK for .NET repository](https://github.com/Azure/azure-sdk-for-net)
