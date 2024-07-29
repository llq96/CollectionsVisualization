using System.Collections;
using UnityEngine;
using CollectionsInteraction;

namespace CollectionsVisualization.Unity
{
    public class Visualization_Runner : MonoBehaviour
    {
        [SerializeField] private float _delayBetweenCommands = 0.5f;

        private InteractorBase _interactor;

        public void Construct(InteractorBase interactor)
        {
            _interactor = interactor;
        }

        private void Start()
        {
            StartCoroutine(RunVisualization());
        }

        private IEnumerator RunVisualization()
        {
            while (_interactor.InvokeNextCommand())
            {
                yield return new WaitForSeconds(_delayBetweenCommands);
            }
        }
    }
}