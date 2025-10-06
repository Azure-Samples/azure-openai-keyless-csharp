using Azure.Identity;
using OpenAI.Chat;
using Microsoft.Extensions.Configuration;
using Azure.AI.OpenAI;

IConfigurationRoot config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var endpoint = config["AZURE_OPENAI_ENDPOINT"];
var model = config["AZURE_OPENAI_API_DEPLOYMENT_NAME"];

if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(model))
{
    throw new Exception("Azure OpenAI connection information was not set. See README for details.");
}

// Set the environment variable to use dev tool credentials only.
// See http://aka.ms/azsdk/net/identity/credential-chains#exclude-a-credential-type-category.
Environment.SetEnvironmentVariable(DefaultAzureCredential.DefaultEnvironmentVariableName, "dev");

AzureOpenAIClient azureClient = new(
    new Uri(endpoint),
    new DefaultAzureCredential(DefaultAzureCredential.DefaultEnvironmentVariableName));
ChatClient chatClient = azureClient.GetChatClient(model);

ChatCompletion completion = chatClient.CompleteChat(
    messages: [
        new SystemChatMessage("You are a helpful assistant that makes lots of cat references and uses emojis."),
        new UserChatMessage("Write a haiku about a hungry cat who wants tuna"),
    ]);

Console.WriteLine("Response:");
Console.WriteLine(completion.Content[0].Text);
