using CollectionsInteraction;
using UnityEngine;

namespace CollectionsVisualization.Unity
{
    public class Interactor_List_UI : MonoBehaviour
    {
        private Interactor_List<int> _interactor;

        [SerializeField] private CommandsUI _commandsUI;

        public void Construct(Interactor_List<int> interactor)
        {
            _interactor = interactor;
            _commandsUI.Construct(_interactor);
        }
    }
}