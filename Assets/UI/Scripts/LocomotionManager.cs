using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionManager : MonoBehaviour
{
    public GameObject leftRayTeleport;

    private TeleportationProvider _teleportationProvider;


    private ActionBasedSnapTurnProvider _SnapTurnProvider;

    private ActionBasedContinuousMoveProvider _continuousMoveProvider;

    private ActionBasedContinuousTurnProvider _continuousTurnProvider;
    // Start is called before the first frame update
    void Start()
    {
        _teleportationProvider = GetComponent<TeleportationProvider>();
        _continuousMoveProvider = GetComponent<ActionBasedContinuousMoveProvider>();
        _continuousTurnProvider = GetComponent<ActionBasedContinuousTurnProvider>();
        _SnapTurnProvider = GetComponent<ActionBasedSnapTurnProvider>();
        
    }

    public void SwitchLocomotion(int locomotionValue)
    {
        if (locomotionValue == 0)
        {
            DisableContinuous();
            EnableTeleport();
        }
        else if (locomotionValue == 1)
        {
            DisableTeleport();
            EnableContinuous();
        }
    }

   private void DisableTeleport()
   {
    leftRayTeleport.SetActive(false);
    _teleportationProvider.enabled = false;
    _SnapTurnProvider.enabled = false;
   }

   private void EnableTeleport()
   {
    leftRayTeleport.SetActive(true);
    _teleportationProvider.enabled = true;
    _SnapTurnProvider.enabled = true;
   }

   private void DisableContinuous()
   {
    _continuousMoveProvider.enabled = false;
    _continuousTurnProvider.enabled = false;
   }

    private void EnableContinuous()
   {
    _continuousMoveProvider.enabled = true;
    _continuousTurnProvider.enabled = true;
   }
   



}
