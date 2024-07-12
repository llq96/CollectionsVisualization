using System;
using System.Collections.Generic;

namespace CollectionsInteraction
{
    public abstract class Interactor<TCollection> where TCollection : new()
    {
        protected TCollection Collection { get; }
        protected Queue<Command<TCollection>> Commands { get; } = new();

        public event Action<Command<TCollection>> OnCommandInvoked;

        public Interactor()
            => Collection = new TCollection();

        public Interactor(TCollection collection)
            => Collection = collection;

        public void AddCommand(Command<TCollection> command)
            => Commands.Enqueue(command);

        public void AddCommand(Action<TCollection> action, string expression)
            => AddCommand(new Command<TCollection>(action, expression));


        private void DoAction(Action<TCollection> action)
        {
            action?.Invoke(Collection);
        }

        public bool InvokeNextCommand()
        {
            if (Commands.TryDequeue(out var command))
            {
                DoAction(command.Action);
                OnCommandInvoked?.Invoke(command);
                return true;
            }

            return false;
        }
    }
}