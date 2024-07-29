using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CollectionsInteraction;
using UnityEngine;

namespace CollectionsVisualization.Unity
{
    public class CommandsUI : MonoBehaviour
    {
        [SerializeField] private Pool_CommandUI _pool_commandUI;

        private InteractorBase _interactor;

        private List<CommandUI> _commandUIs = new();

        public void Construct(InteractorBase interactor)
        {
            _interactor = interactor;
            _interactor.OnCommandInvoked += SetInvokedCommand;
        }

        private void Start()
        {
            var commands = _interactor.GetCommandsAsReadonly();
            SpawnCommands(commands);
        }

        private void SpawnCommands(ReadOnlyCollection<CommandBase> commands)
        {
            foreach (var command in commands)
            {
                var commandUI = _pool_commandUI.Get();
                commandUI.SetCommand(command);
                _commandUIs.Add(commandUI);
            }
        }

        private void SetInvokedCommand(CommandBase command)
        {
            foreach (var commandUI in _commandUIs)
            {
                var isCommandInvokedNow = commandUI.Command == command;
                var isNotInvoked = _interactor.GetCommandsAsReadonly().Any(x => x == commandUI.Command);

                var state = isCommandInvokedNow ? CommandUIState.InvokedNow
                    : isNotInvoked ? CommandUIState.NeverInvoked
                    : CommandUIState.WasInvoked;
                commandUI.SetState(state);
            }
        }
    }
}