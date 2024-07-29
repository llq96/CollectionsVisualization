using System;
using CollectionsInteraction;
using TMPro;
using UnityEngine;

namespace CollectionsVisualization.Unity
{
    public class CommandUI : MonoBehaviour
    {
        public CommandBase Command { get; private set; }

        [SerializeField] private TextMeshProUGUI _tmp_expression;
        [SerializeField] private GameObject _invokedNowObject;

        [SerializeField] private Color _textColorState_neverInvoked;
        [SerializeField] private Color _textColorState_invokedNow;
        [SerializeField] private Color _textColorState_wasInvoked;

        private bool _isCommandWasInvoked;

        public void SetCommand(CommandBase command)
        {
            Command = command;

            _tmp_expression.text = Command.Expression;
        }

        public void SetState(CommandUIState state)
        {
            _invokedNowObject.gameObject.SetActive(state == CommandUIState.InvokedNow);

            _tmp_expression.color = state switch
            {
                CommandUIState.NeverInvoked => _textColorState_neverInvoked,
                CommandUIState.InvokedNow => _textColorState_invokedNow,
                CommandUIState.WasInvoked => _textColorState_wasInvoked,
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };
        }
    }

    public enum CommandUIState
    {
        NeverInvoked,
        InvokedNow,
        WasInvoked
    }
}