using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    private PlayerControls Controls;
    private bool Entering;
    [SerializeField] public GameObject CarButton;
    [SerializeField] private GameObject RebindingUI;
    public AdvancedCharacterMovement Player;
    bool Settings;
    public bool CancelAllMovement { get; set;}
    // Start is called before the first frame update
    void Start()
    {
        Entering = false;
        Controls = new PlayerControls();
        Controls.Enable();
        Controls.Keyboard.Equip.performed += ctx =>
        {
            Entering = true;
        };
        Controls.Keyboard.Escape.performed += ctx =>
        {
            Settings = !Settings;
        };
    }

    private void Update()
    {
        HandleOpenMenu();
    }
    private void HandleOpenMenu()
    {
        if (Settings)
        { 
          RebindingUI.SetActive(true);
          CancelAllMovement = true;
        }
        else
        {
          RebindingUI.SetActive(false);
          CancelAllMovement = false;
        }
    }
   
}
