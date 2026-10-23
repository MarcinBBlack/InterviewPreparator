using InterviewPreparator.Application.Interfaces;
using Microsoft.Agents.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;
using OpenAI.Chat;

namespace InterviewPreparator.Infrastructure.AgentFactory;

public class OpenAIAgentFactory : IAgentFactory
{
    #region Fields

    private readonly IConfiguration _configuration;

    #endregion

    #region Constructors

    /// <summary>
    /// Creates the OpenAI agent factory.
    /// </summary>
    /// <param name="configuration">Application configuration containing the OpenAI API key.</param>
    public OpenAIAgentFactory(IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        _configuration = configuration;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Creates an agent configured with the selected model, name, and instructions.
    /// </summary>
    /// <param name="modelName">The name of the OpenAI model to use.</param>
    /// <param name="agentName">The name assigned to the agent.</param>
    /// <param name="agentInstructions">The instructions that define the agent's behavior.</param>
    /// <returns>The configured AI agent.</returns>
    public AIAgent Create(String modelName, String agentName, String agentInstructions)
    {
        var apiKey = _configuration["OpenAPIKey"];

        if (String.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException("The OpenAI API key is not configured.");
        }

        var client = new OpenAIClient(apiKey);
        var agent = client.GetChatClient(modelName).AsAIAgent(
            name: agentName,
            instructions: agentInstructions);

        return agent;
    }

    #endregion
}
