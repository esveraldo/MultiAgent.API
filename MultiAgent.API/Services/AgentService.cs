using MultiAgent.API.Agents;
using MultiAgent.API.Models;

namespace MultiAgent.API.Services
{
    /// <summary>
    /// Agente Orquestrador
    /// </summary>
    public class AgentService
    {
        private readonly PlannerAgent planner;
        private readonly ResearchAgent research;
        private readonly CodeAgent code;
        private readonly ReviewAgent review;

        public AgentService(PlannerAgent planner, ResearchAgent research, CodeAgent code, ReviewAgent review)
        {
            this.planner = planner;
            this.research = research;
            this.code = code;
            this.review = review;
        }

        public async Task<AgentContextModel> Execute(string message)
        {
            //Capturando a mensagem
            var model = new AgentContextModel { UserRequest = message };

            //Gerando o plano de ação
            model.Plan = await planner.CreatePlan(model);

            //Gerando a pesquisa
            model.Research = await research.Research(model);

            //Gerando o código
            model.Code = await code.GenerateCode(model);

            //Revisar o código
            model.Review = await review.Review(model);

            //Retornar o resultado
            return model;
        }
    }
}
