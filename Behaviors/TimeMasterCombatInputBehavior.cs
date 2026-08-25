using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TimeMaster.Managers;

namespace TimeMaster.Behaviors
{
    public class TimeMasterCombatInputBehavior : MissionBehavior
    {
        private readonly float[] swingLevels =
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
            7.0f,
            13.0f,
            25.0f
        };

        private int currentLevel = 0;

        public override MissionBehaviorType BehaviorType
        {
            get { return MissionBehaviorType.Other; }
        }

        public override void OnMissionTick(float dt)
        {
            base.OnMissionTick(dt);

            // Tecla C inicia o swing fast em niveis
            if (Input.IsKeyPressed(InputKey.C))
            {
                currentLevel++;

                if (currentLevel >= swingLevels.Length)
                    currentLevel = 0;

                TimeMasterCombatManager.SwingMultiplier =
                    swingLevels[currentLevel];

                InformationManager.DisplayMessage(
                    new InformationMessage(
                        "Fast Swing: " +
                        swingLevels[currentLevel] + "x"
                    )
                );
            }
        }
    }
}