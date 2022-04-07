using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebindingDisplay : MonoBehaviour
{
        [SerializeField] private InputActionReference jumpAction = null;
        [SerializeField] private AdvancedCharacterMovement playerController = null;
        [SerializeField] private TMP_Text bindingDisplayNameText = null;
        [SerializeField] private GameObject startRebindObject = null;
        [SerializeField] private GameObject waitingForInputObject = null;

        private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

        private const string RebindsKey = "rebinds";

        private void Start()
        {
            string rebinds = PlayerPrefs.GetString(RebindsKey, string.Empty);

            if (string.IsNullOrEmpty(rebinds)) { return; }

            int bindingIndex = jumpAction.action.GetBindingIndexForControl(jumpAction.action.controls[0]);

            bindingDisplayNameText.text = InputControlPath.ToHumanReadableString(
                jumpAction.action.bindings[bindingIndex].effectivePath,
                InputControlPath.HumanReadableStringOptions.OmitDevice);
        }

        public void Save()
        {
        }

        public void StartRebinding()
        {
            startRebindObject.SetActive(false);
            waitingForInputObject.SetActive(true);
           playerController.input.SwitchCurrentActionMap("Menu"); 
            rebindingOperation = jumpAction.action.PerformInteractiveRebinding()
                .WithControlsExcluding("Gamepad")
                .OnMatchWaitForAnother(0.1f)
                .OnComplete(operation => RebindComplete())
                .Start();
        }

        private void RebindComplete()
        {
            int bindingIndex = jumpAction.action.GetBindingIndexForControl(jumpAction.action.controls[0]);

            bindingDisplayNameText.text = InputControlPath.ToHumanReadableString(
                jumpAction.action.bindings[bindingIndex].effectivePath,
                InputControlPath.HumanReadableStringOptions.OmitDevice);

            rebindingOperation.Dispose();
        playerController.input.SwitchCurrentActionMap("Keyboard");
        startRebindObject.SetActive(true);
            waitingForInputObject.SetActive(false);
        }
}