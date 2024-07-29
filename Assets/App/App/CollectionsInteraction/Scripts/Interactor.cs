using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CollectionsInteraction
{
    public abstract class Interactor<TCollection> : InteractorBase where TCollection : new()
    {
        protected TCollection Collection { get; }
        protected Queue<Command<TCollection>> Commands { get; } = new();

        public new event Action<Command<TCollection>> OnCommandInvoked;


        protected Interactor()
            => Collection = new TCollection();

        protected Interactor(TCollection collection)
            => Collection = collection;

        public void AddCommand(Command<TCollection> command)
            => Commands.Enqueue(command);

        public void AddCommand(Action<TCollection> action, string expression)
            => AddCommand(new Command<TCollection>(action, expression));


        private void DoAction(Action<TCollection> action)
        {
            action?.Invoke(Collection);
        }

        public override bool InvokeNextCommand()
        {
            if (Commands.TryDequeue(out var command))
            {
                DoAction(command.Action);
                SendCommandInvokedEvents(command);
                OnCommandInvoked?.Invoke(command);
                return true;
            }

            return false;
        }

        public new ReadOnlyCollection<Command<TCollection>> GetCommandsAsReadonly()
            => Commands.ToList().AsReadOnly();

        protected override List<CommandBase> GetCommandsList()
            => Commands.Cast<CommandBase>().ToList();
    }
}