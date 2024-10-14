using Azure.Identity;
using Azure.AI.OpenAI;
using OpenAI.Chat;
using Microsoft.Extensions.Configuration;

IConfigurationRoot config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .Build();

var endpoint = config["AZURE_OPENAI_ENDPOINT"]!;
var model = config["AZURE_OPENAI_API_DEPLOYMENT_NAME"]!;

if (String.IsNullOrEmpty(endpoint) || String.IsNullOrEmpty(model))
{
    throw new Exception("Environment variables were not set. See README for details.");
}
AzureOpenAIClient azureClient = new(
    new Uri(endpoint),
    new DefaultAzureCredential());
ChatClient chatClient = azureClient.GetChatClient(model);

ChatCompletion completion = chatClient.CompleteChat(
    messages: [
        new SystemChatMessage("You are a helpful assistant that makes lots of cat references and uses emojis."),
        new UserChatMessage("Write a haiku about a hungry cat who wants tuna"),
    ],
    options: new ChatCompletionOptions
    {
        Temperature = 0.7f
    });

Console.WriteLine("Response:");
Console.WriteLine(completion.Content[0].Text);
