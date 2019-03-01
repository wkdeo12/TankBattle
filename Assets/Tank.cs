using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankStatus
{
    public class Tank : MonoBehaviour
    {
        private int Hp = 5;
        private float Speed = 7f;

        public int hp
        {
            get
            {
                Hp--;
                if (Hp == 0)
                {
                    Destroy(this.gameObject);
                }
                return Hp;
            }
        }

        /// <summary>
        /// 호출할때마다 스피드 1씩 감소함
        /// </summary>
        public float speed
        {
            get
            {
                Speed--;

                return Speed;
            }
        }
    }
}