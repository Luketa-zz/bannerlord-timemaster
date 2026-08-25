using TaleWorlds.MountAndBlade;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TimeMaster.Managers;

namespace TimeMaster.Behaviors
{
    public class TimeMasterInputBehavior : MissionBehavior
    {
        private int speedLevel = 0;

        // Movement Speed
        private readonly float[] speedLevels =
        {
            1.0f,
            1.5f,
            2.0f,
            2.5f,
            3.0f,
            3.5f,
            4.0f,
            4.5f,
            5.0f,
            6.0f,
            6.5f,
            7.0f,
            8.0f,
            9.5f,
            20.5f,
            30.0f,
            35.0f,
            50.0f,
            80.0f,
            100.0f
        };


        public override MissionBehaviorType BehaviorType
        {
            get { return MissionBehaviorType.Other; }
        }


        public override void OnMissionTick(float dt)
        {
            base.OnMissionTick(dt);


            if (Input.IsKeyPressed(InputKey.LeftControl))
            {
                speedLevel++;

                if (speedLevel >= speedLevels.Length)
                {
                    speedLevel = 0;
                }


                TimeMasterSpeedManager.TargetSpeed =
                    speedLevels[speedLevel];


                InformationManager.DisplayMessage(
                    new InformationMessage(
                        "Velocidade alvo: " +
                        speedLevels[speedLevel]
                    )
                );
            }
        }
    }
}