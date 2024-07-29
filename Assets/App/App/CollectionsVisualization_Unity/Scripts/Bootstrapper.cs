using UnityEngine;

namespace CollectionsVisualization.Unity
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Visualization_List_Runner _visualization_list_runner;
        [SerializeField] private Interactor_List_UI _interactor_list_ui;


        private readonly InteractorListFactory _interactorListFactory = new();

        private void Awake()
        {
            var interactor = _interactorListFactory.GetInteractorList();

            _visualization_list_runner.Construct(interactor);
            _interactor_list_ui.Construct(interactor);
        }
    }
}