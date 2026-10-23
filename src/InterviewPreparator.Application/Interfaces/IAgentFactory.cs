using Microsoft.Agents.AI;
namespace InterviewPreparator.Application.Interfaces
{
    public interface IAgentFactory
    {
        AIAgent Create(String modelName, String agentName, String agentInstructions);
    }
}
