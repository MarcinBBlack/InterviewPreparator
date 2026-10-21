using Microsoft.Agents.AI;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPreparator.Application.Interfaces
{
    public interface IAgentFactory
    {
        AIAgent Create(String modelName, String agentName, String agentInstructions);
    }
}
