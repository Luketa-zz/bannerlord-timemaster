using HarmonyLib;
using SandBox.GameComponents;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TimeMaster.Managers;

namespace TimeMaster.Patches
{
    [HarmonyPatch(typeof(SandboxAgentStatCalculateModel), "UpdateAgentStats")]
    public class StatPatch
    {
        private static void Postfix(
            Agent agent,
            AgentDrivenProperties agentDrivenProperties)
        {
            if (agent.IsMainAgent)
            {
                agentDrivenProperties.MaxSpeedMultiplier =
                    TimeMasterSpeedManager.TargetSpeed;

                agent.UpdateCustomDrivenProperties();
            }
        }
    }
}