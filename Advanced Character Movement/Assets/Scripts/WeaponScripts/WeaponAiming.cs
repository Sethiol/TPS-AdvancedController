using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAiming : MonoBehaviour
{
    private Cinemachine.CinemachineFreeLook cam;
    private PlayerControls controls;
    bool Aiming = false;
    float currentFOV;
    float standardFOV;
    public float AimSpeed;
    [HideInInspector] public string currentWeapon;
    private void Start()
    {
        Aiming = false;
        cam = FindObjectOfType<Cinemachine.CinemachineFreeLook>();
        currentFOV = cam.m_Lens.FieldOfView;
        standardFOV = cam.m_Lens.FieldOfView;
        controls = new PlayerControls();
        controls.Enable();
        controls.Keyboard.Aim.started += ctx =>
        {
            Aiming = true;
        };
        controls.Keyboard.Aim.canceled += ctx =>
        {
            Aiming = false;
        };
    }
    private void Update()
    {
        if(currentWeapon == "Axe" || currentWeapon == "") { return;  }
        if(Aiming && currentFOV > 35)
        {
            currentFOV -= Time.deltaTime * AimSpeed;
            cam.m_Lens.FieldOfView = currentFOV;
        }
        else if(Aiming && currentFOV == 35)
        {
            currentFOV = 50;
            cam.m_Lens.FieldOfView = currentFOV;
        }
        else if(!Aiming && currentFOV < standardFOV)
        {
            currentFOV += Time.deltaTime * AimSpeed;
            cam.m_Lens.FieldOfView = currentFOV;
        }
        else if(!Aiming && currentFOV  == 50)
        {
            currentFOV = 50;
            cam.m_Lens.FieldOfView = currentFOV;
        }
    }
}
