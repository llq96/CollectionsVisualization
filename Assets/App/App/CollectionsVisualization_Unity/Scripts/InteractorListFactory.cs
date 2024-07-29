using CollectionsInteraction;

namespace CollectionsVisualization.Unity
{
    public class InteractorListFactory
    {
        public Interactor_List<int> GetInteractorList()
        {
            var _interactor = new Interactor_List<int>();

            for (int i = 0; i < 10; i++)
            {
                _interactor.AddCommand_AddItem(i);
            }

            return _interactor;
        }
    }
}