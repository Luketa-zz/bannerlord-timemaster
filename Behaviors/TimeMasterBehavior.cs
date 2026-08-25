using TaleWorlds.MountAndBlade;
using TimeMaster.Managers;

namespace TimeMaster.Behaviors
{
    public class TimeMasterBehavior : MissionBehavior
    {
        public override MissionBehaviorType BehaviorType
        {
            get { return MissionBehaviorType.Other; }
        }


        public override void OnMissionTick(float dt)
        {
            base.OnMissionTick(dt);


            Agent player = Mission.MainAgent;

            if (player != null)
            {
                player.AgentDrivenProperties.MaxSpeedMultiplier =
                    TimeMasterSpeedManager.TargetSpeed;

                // Fast Swing
                player.AgentDrivenProperties.SwingSpeedMultiplier =
                    TimeMasterCombatManager.SwingMultiplier;

                player.UpdateCustomDrivenProperties();
            }
        }
    }
}