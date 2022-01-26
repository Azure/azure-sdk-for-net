# Cognitive Language SDK - Static Test Resources

The files herein are to deploy, when needed, a set of static test resources used by the Cognitive Language SDK,
specifically in the _sdk/cognitivelanguage_ service directory.

If necessary, these resources should be deployed into a resource group defined by the Engineering Systems team.
After deployment:

1. ZIP the contents of the _static-test-resources-qna_ directory as _static-test-resources-qna.zip_.
2. Import the following files in order:
    1. _static-test-resources-conversation.json_
    2. _static-test-resources-workflow.json_
    3. _static-test-resources-qna.zip_
3. Update _../test-resources.json_ `outputs` as necessary.
4. Update the Key Vault and linked Variable Group in Azure Pipelines such that environment variables in
   _../tests.yml_ correspond to outputs of steps 1 and 2 above.
