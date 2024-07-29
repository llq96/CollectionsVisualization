using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CollectionsInteraction
{
    public abstract class InteractorBase
    {
        protected abstract List<CommandBase> GetCommandsList();

        public ReadOnlyCollection<CommandBase> GetCommandsAsReadonly()
            => GetCommandsList().AsReadOnly();

        public event Action<CommandBase> OnCommandInvoked;

        protected virtual void SendCommandInvokedEvents(CommandBase command)
        {
            OnCommandInvoked?.Invoke(command);
        }

        public abstract bool InvokeNextCommand();
    }
}