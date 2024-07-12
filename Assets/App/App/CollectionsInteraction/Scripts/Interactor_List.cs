using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace CollectionsInteraction
{
    public class Interactor_List<T> : Interactor<List<T>>
    {
        public ReadOnlyCollection<T> List => Collection.AsReadOnly();
        public T[] InnerArray => GetInnerArray();

        public void AddCommand_AddItem(T item)
        {
            AddCommand(list => list.Add(item), $"list.Add({item});");
        }

        private T[] GetInnerArray()
        {
            var fieldInfo = typeof(List<T>).GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance);
            var value = fieldInfo.GetValue(Collection);
            return (T[])value;
        }
    }
}