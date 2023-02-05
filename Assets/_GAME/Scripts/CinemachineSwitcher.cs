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
        [SerializeField] private CinemachineVirtualCamera vcam3; //Camera3
        [SerializeField] private CinemachineVirtualCamera vcam4; //Camera4

        private bool _camera1Active = true;
        
        private void Start()
        {
            SwitchPriority();
        }

        private void OnEnable()
        {
            EventBus<StickManGameWinEvent>.AddListener(OnStickManGameWin);
        }

        private void OnDisable()
        {
            EventBus<StickManGameWinEvent>.RemoveListener(OnStickManGameWin);
        }

        private void OnStickManGameWin(object sender, StickManGameWinEvent @event)
        {
            SwitchPriority();
        }

        public void SwitchPriority()
        {
            if (_camera1Active)
            {
                vcam1.Priority = 100;
                vcam2.Priority = 50;
            }
            else
            {
                vcam1.Priority = 100;
                vcam2.Priority = 1;
            }

            _camera1Active = !_camera1Active;
        }
    }
}