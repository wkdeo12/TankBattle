using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DD
{
    public enum TankState
    { Move, Attack, Skill, Emergencies }

    public class GodTankStateMachine : MonoBehaviour
    {
        public void ChangeState(TankState tankState)
        {
            switch (tankState)
            {
                case TankState.Move:
                    break;

                case TankState.Attack:
                    break;

                case TankState.Skill:
                    break;

                case TankState.Emergencies:
                    break;

                default:
                    break;
            }
        }

        public void SkillSet()
        {
        }
    }
}