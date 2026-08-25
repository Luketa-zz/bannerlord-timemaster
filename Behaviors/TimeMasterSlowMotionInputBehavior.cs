using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using static TaleWorlds.MountAndBlade.Mission;

namespace TimeMaster.Behaviors
{
    public class TimeMasterSlowMotionInputBehavior : MissionBehavior
    {
        private readonly float[] slowLevels =
        {
            1.0f,
            0.75f,
            0.50f,
            0.25f,
            0.10f,
            0.05f,
            0.02f
        };

        private int currentLevel = 0;

        private const int TimeMasterRequestID = 9999;

        private bool requestActive = false;

        public override MissionBehaviorType BehaviorType
        {
            get { return MissionBehaviorType.Other; }
        }

        public override void OnMissionTick(float dt)
        {
            base.OnMissionTick(dt);

            if (!Input.IsKeyPressed(InputKey.X))
                return;

            currentLevel++;

            if (currentLevel >= slowLevels.Length)
                currentLevel = 0;

            Mission mission = Mission.Current;

            if (mission == null)
                return;

            if (requestActive)
            {
                mission.RemoveTimeSpeedRequest(TimeMasterRequestID);
                requestActive = false;
            }

            if (slowLevels[currentLevel] != 1.0f)
            {
                mission.AddTimeSpeedRequest(
                    new TimeSpeedRequest(
                        slowLevels[currentLevel],
                        TimeMasterRequestID));

                requestActive = true;
            }

            InformationManager.DisplayMessage(
                new InformationMessage(
                    "Slow Motion: " +
                    slowLevels[currentLevel] + "x"));
        }
    }
}