---
page_type: sample
languages:
  - azdeveloper
  - javascript
  - typescript
  - nodejs
  - bicep
products:
  - azure
  - azure-openai
  - ai-services
urlFragment: azure-openai-keyless-csharp
name: Azure OpenAI keyless deployment
description: Example Azure OpenAI deployment using C#/.NET and RBAC role for your user account for keyless access.
---

<!-- Learn samples onboarding: https://review.learn.microsoft.com/en-us/help/contribute/samples/process/onboarding?branch=main -->
<!-- prettier-ignore -->
This sample shows how to to provision an [Azure OpenAI](https://learn.microsoft.com/azure/ai-services/openai/overview) account with an [RBAC role](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles) permission for your user account to access, so that you can use the OpenAI API SDKs with [keyless (Entra) authentication](https://learn.microsoft.com/entra/identity/managed-identities-azure-resources/overview).

## Prerequisites

You need to install following tools to work on your local machine:

* [.NET 8](https://dotnet.microsoft.com/downloads/)
* [Git](https://git-scm.com/downloads)
* [Azure Developer CLI (azd)](https://aka.ms/install-azd)
* [VS Code](https://code.visualstudio.com/Download) or [Visual Studio](https://visualstudio.microsoft.com/downloads/)
    * If using VS Code, install the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

- **Azure account**. If you're new to Azure, [get an Azure account for free](https://azure.microsoft.com/free) to get free Azure credits to get started. If you're a student, you can also get free credits with [Azure for Students](https://aka.ms/azureforstudents).
- **Azure subscription with access enabled for the Azure OpenAI service**. You can request access with [this form](https://aka.ms/oaiapply).
- **Azure account permissions**:
  - Your Azure account must have `Microsoft.Authorization/roleAssignments/write` permissions, such as [Role Based Access Control Administrator](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles#role-based-access-control-administrator-preview), [User Access Administrator](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles#user-access-administrator), or [Owner](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles#owner). If you don't have subscription-level permissions, you must be granted [RBAC](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles#role-based-access-control-administrator-preview) for an existing resource group and [deploy to that existing group](docs/deploy_existing.md#resource-group).
  - Your Azure account also needs `Microsoft.Resources/deployments/write` permissions on the subscription level.

## Setup the sample

You can run this project directly in your browser by using GitHub Codespaces, which will open a web-based VS Code:

[![Open in GitHub Codespaces](https://img.shields.io/static/v1?style=for-the-badge&label=GitHub+Codespaces&message=Open&color=blue&logo=github)](https://codespaces.new/Azure-Samples/azure-openai-keyless-csharp?hide_repo_select=true&ref&quickstart=true)



## Provision Azure OpenAI resources

1. Open a terminal and navigate to the root of the project.
2. Authenticate with Azure by running `azd auth login`.
3. Run `azd provision` to provision the Azure resources.
   - You will be prompted to select a location for your OpenAI resource. If you're unsure of which location to choose, select `eastus2`. See [OpenAI model availability table](https://learn.microsoft.com/azure/ai-services/openai/concepts/models#standard-deployment-model-availability) for more information.

The deployment process will take a few minutes. Once it's done, a `.env` file will be created in the root folder with the environment variables needed to run the application. .NET User Secrets will be configured for the sample using these environment variables, so you can run it right away.

## Run the sample

First make sure you have provisioned the Azure OpenAI resources, then run the following command from the root of this repo (or run the project in Visual Studio or VSCode).

1. Run `dotnet run` to install the dependencies.

This will use the [OpenAI SDK](https://github.com/openai/openai-dotnet) to make a request to the OpenAI API and print the response to the console.

## Clean up

To clean up all the Azure resources created by this sample:

1. Run `azd down --purge`
2. When asked if you are sure you want to continue, enter `y`

The resource group and all the resources will be deleted.

## Troubleshooting

If you have any issue when running or deploying this sample, please check the [troubleshooting guide](./troubleshooting.md). If you can't find a solution to your problem, please [open an issue](https://github.com/Azure-Samples/azure-openai-keyless-csharp/issues) in this repository.

## Next steps

Here are some resources to learn more about the technologies used in this sample:

Here are some resources to learn more about Azure OpenAI and related technologies:

- [Generative AI For Beginners](https://github.com/microsoft/generative-ai-for-beginners)
- [Generative AI with .NET, for Beginners](https://www.youtube.com/watch?v=vISLS8aY0RU&list=PLdo4fOcmZ0oW_k4_eDTPWDLUVWz7A9y0M)
- [Azure OpenAI Service](https://learn.microsoft.com/azure/ai-services/openai/overview)
- [Chat + Enterprise data with Azure OpenAI and Azure AI Search](https://github.com/Azure-Samples/azure-search-openai-csharp)

You can also find [more Azure AI samples here](https://github.com/Azure-Samples/azureai-samples).