using Microsoft.SemanticKernel;
using Microsoft.Extensions.Configuration;

namespace MultiAgent.API.Factories
{
    public static class KernelFactory
    {
        public static Kernel CreateKernel(IConfiguration configuration)
        {
            var builder = Kernel.CreateBuilder();

            builder.AddOpenAIChatCompletion(
                modelId: "gpt-4o",
                apiKey: configuration["OpenAI:ApiKey"]
            );

            return builder.Build();
        }
    }
}