using Microsoft.SemanticKernel;
using MultiAgent.API.Models;

namespace MultiAgent.API.Agents
{
    public class ResearchAgent(Kernel kernel)
    {
        public async Task<string> Research(AgentContextModel context)
        {
            var prompt = """
                Plano de execução:
                {{$plan}}
                Pesquise informações necessárias para implementar esse plano.
                Responda de forma curta e objetiva.
                Use no máximo 3 linhas.
                """;

            var function = kernel.CreateFunctionFromPrompt(prompt);

            var result = await kernel.InvokeAsync(
                function,
                new()
                {
                    ["plan"] = context.Plan
                });

            return result.ToString();
        }
    }
}
