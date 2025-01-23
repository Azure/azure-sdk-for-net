# RAGMachine
An OpenAI RAG web application sample built with opinionated Azure SDK APIs

## Prerequisites
1. An Azure subscription
1. Install the Azure Developer CLI : https://learn.microsoft.com/azure/developer/azure-developer-cli/install-azd

## Getting started
1. Open a terminal
1. Clone the repository
1. cd into the repository directory
1. run `dotnet run -init` to provision resources and prepare for deployment`
1. run `azd init` to initialize the Azure Developer CLI`
   1. You may be prompted to login to your Azure subscription with 'azd auth'
1. Choose any name for the environment
1. run `azd up` to deploy the resources
