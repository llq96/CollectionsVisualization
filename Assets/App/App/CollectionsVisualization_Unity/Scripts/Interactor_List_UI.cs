using CollectionsInteraction;
using UnityEngine;

namespace CollectionsVisualization.Unity
{
    public class Interactor_List_UI : MonoBehaviour
    {
        [SerializeField] private CommandsUI _commandsUI;

        private Interactor_List<int> _interactor;

        public void Construct(Interactor_List<int> interactor)
        {
            _interactor = interactor;

            _commandsUI.Construct(_interactor);
        }
    }
}