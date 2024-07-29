using CollectionsInteraction;
using UnityEngine;

namespace CollectionsVisualization.Unity
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Visualization_Runner _visualization_runner;
        [SerializeField] private Interactor_List_UI _interactor_list_ui;

        private void Awake()
        {
            var _interactorFactory = new Interactor_List_Factory();
            var interactor = _interactorFactory.GetInteractor();

            _visualization_runner.Construct(interactor);
            _interactor_list_ui.Construct(interactor as Interactor_List<int>); //TODO
        }
    }
}