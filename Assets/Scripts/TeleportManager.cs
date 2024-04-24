using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportManager : MonoBehaviour
{

    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider tpProvider;
    private InputAction _thumbstick;
    private bool _rayActive;

    // Start is called before the first frame update
    void Start()
    {
        rayInteractor.enabled = false;

        var activateAA = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Activate");
        activateAA.Enable();
        activateAA.performed += OnTeleportActivate;

        var cancelAA = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Cancel");
        cancelAA.Enable();
        cancelAA.performed += OnTelePortCancel;


        _thumbstick = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Move");
        _thumbstick.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_rayActive)
        {
            return;
        }

        if(_thumbstick.triggered)
        {
            return;
        }

        if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            rayInteractor.enabled = false;
            _rayActive = false;
            return;
        }
        TeleportRequest tpRequest = new TeleportRequest()
        {
            destinationPosition = hit.point,
        };

        tpProvider.QueueTeleportRequest(tpRequest);

        _rayActive = false;
        rayInteractor.enabled = false;
    }

    private void OnTeleportActivate(InputAction.CallbackContext context)
    {
        if (rayInteractor != null)
        {
        rayInteractor.enabled = true;
        _rayActive = true;
        }
    }

     private void OnTelePortCancel(InputAction.CallbackContext context)
    {
        if (rayInteractor != null)
        {
         rayInteractor.enabled = false;
        _rayActive = false;
        }
       
    }
}
