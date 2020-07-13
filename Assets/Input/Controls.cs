// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player1"",
            ""id"": ""ce43054d-ca8c-4fb3-80fa-5ed8d143cb3d"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""6ebd753e-1ef7-4924-acd7-2bd3c508adcf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c90bc42e-6681-4bdd-bc83-921b43caf535"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""d84253e7-7332-4614-8e0f-77b9e9c10129"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WallGrab"",
                    ""type"": ""Button"",
                    ""id"": ""489a0ff4-884e-4b38-a8eb-ebe4d23a696e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""f4f552a1-3d8a-4c12-9baa-f3b5ba5c6fbf"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b7580e67-c421-4a45-88ca-7de4b03908f0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformGame"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""764130c1-38a9-421a-b7f4-ce7cc47114e0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformGame"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bb8c5f7f-7fc9-4301-b77d-68702daeb86d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformGame"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""76a2cbbd-3f2d-4e6d-9220-432bea158a24"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformGame"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""deaba24c-c88a-4202-abaf-93d0a14387c7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c9dc14ab-058b-4498-993a-88fd1a7c53bd"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformGame"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""887cebc6-f359-4402-83bf-8afbad376419"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformGame"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""634c0e6a-69cb-44bf-a32a-f342a014ea5d"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformGame"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ca787223-15e3-458d-a7fc-b030cd5a5944"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformGame"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""44b8a7bd-2623-4713-bbe6-44da8d0d77e4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformGame"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b9bdacb-318d-447b-bdea-a746e8670777"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformGame"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c5248d7-a23e-4f3f-ab2b-b1894846084e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformGame"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41cadb6b-448d-4291-bca3-9e7dea0285a4"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformGame"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34fce2e5-8225-471c-82d2-a102fe81a5ac"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformGame"",
                    ""action"": ""WallGrab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ee07e00-0e4b-4969-83fb-b0e828c7d9f0"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformGame"",
                    ""action"": ""WallGrab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PlatformGame"",
            ""bindingGroup"": ""PlatformGame"",
            ""devices"": []
        }
    ]
}");
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_Movement = m_Player1.FindAction("Movement", throwIfNotFound: true);
        m_Player1_Jump = m_Player1.FindAction("Jump", throwIfNotFound: true);
        m_Player1_Dash = m_Player1.FindAction("Dash", throwIfNotFound: true);
        m_Player1_WallGrab = m_Player1.FindAction("WallGrab", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_Movement;
    private readonly InputAction m_Player1_Jump;
    private readonly InputAction m_Player1_Dash;
    private readonly InputAction m_Player1_WallGrab;
    public struct Player1Actions
    {
        private @Controls m_Wrapper;
        public Player1Actions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player1_Movement;
        public InputAction @Jump => m_Wrapper.m_Player1_Jump;
        public InputAction @Dash => m_Wrapper.m_Player1_Dash;
        public InputAction @WallGrab => m_Wrapper.m_Player1_WallGrab;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDash;
                @WallGrab.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnWallGrab;
                @WallGrab.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnWallGrab;
                @WallGrab.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnWallGrab;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @WallGrab.started += instance.OnWallGrab;
                @WallGrab.performed += instance.OnWallGrab;
                @WallGrab.canceled += instance.OnWallGrab;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);
    private int m_PlatformGameSchemeIndex = -1;
    public InputControlScheme PlatformGameScheme
    {
        get
        {
            if (m_PlatformGameSchemeIndex == -1) m_PlatformGameSchemeIndex = asset.FindControlSchemeIndex("PlatformGame");
            return asset.controlSchemes[m_PlatformGameSchemeIndex];
        }
    }
    public interface IPlayer1Actions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnWallGrab(InputAction.CallbackContext context);
    }
}
