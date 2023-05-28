﻿using System;
using _Scripts.CameraLogic;
using _Scripts.Infrastructure;
using _Scripts.Services.Input;
using UnityEngine;

namespace _Scripts.Hero
{
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed;

        private IInputService _inputService;
        private Camera _camera;

        private void Awake()
        {
            _inputService = Game.InputService;
        }

        private void Start()
        {
            _camera = Camera.main;

            SetCameraFollow();
        }

        private void SetCameraFollow()
        {
            _camera.GetComponent<CameraFollow>().SetFollow(gameObject);
        }

        private void Update()
        {
            var movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;
            
            _characterController.Move(movementVector * _movementSpeed * Time.deltaTime);
        }
    }
}