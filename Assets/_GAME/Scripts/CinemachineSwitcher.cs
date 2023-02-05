using Ambrosia.EventBus;
using System;
using Cinemachine;
using UnityEngine;

namespace EasyClap.Game
{
    public class CinemachineSwitcher : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera vcam1; //Camera1
        [SerializeField] private CinemachineVirtualCamera vcam2; //Camera2

        private bool _camera1Active = true;
        
        private void Start()
        {
            SwitchPriority();
        }

        private void OnEnable()
        {
            EventBus<StickManGameWinEvent>.AddListener(OnTextWin);
        }

        private void OnDisable()
        {
            EventBus<StickManGameWinEvent>.RemoveListener(OnTextWin);
        }

        private void OnTextWin(object sender, StickManGameWinEvent @event)
        {
            SwitchPriority();
        }

        // private void Win(object sender, WinEvent e)
        // {
        //     SwitchPriority();
        // }

        public void SwitchPriority()
        {
            if (_camera1Active)
            {
                vcam1.Priority = 1;
                vcam2.Priority = 0;
            }
            else
            {
                vcam1.Priority = 0;
                vcam2.Priority = 1;
            }

            _camera1Active = !_camera1Active;
        }
    }
}