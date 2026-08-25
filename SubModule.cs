using HarmonyLib;
using TaleWorlds.MountAndBlade;
using TimeMaster.Behaviors;

namespace TimeMaster
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            Harmony harmony = new Harmony("TimeMaster");
            harmony.PatchAll();
        }


        public override void OnMissionBehaviorInitialize(Mission mission)
        {
            base.OnMissionBehaviorInitialize(mission);

            mission.AddMissionBehavior(new TimeMasterBehavior());
            mission.AddMissionBehavior(new TimeMasterInputBehavior());

            // Swing Fast
            mission.AddMissionBehavior(new TimeMasterCombatInputBehavior());

            // Slow Motion
            mission.AddMissionBehavior(
                new TimeMasterSlowMotionInputBehavior());

        }
    }
}