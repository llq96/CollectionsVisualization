using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CollectionsInteraction;

namespace CollectionsVisualization.Unity
{
    public class Visualization_List_Runner : MonoBehaviour
    {
        private Interactor_List<int> _interactor;

        [SerializeField] private float _delayBetweenCommands = 0.5f;

        private void Start()
        {
            _interactor = new Interactor_List<int>();
            _interactor.OnCommandInvoked += SetInvokedCommand;
            for (int i = 0; i < 10; i++)
            {
                _interactor.AddCommand_AddItem(i);
            }

            StartCoroutine(RunVisualization());
        }

        private IEnumerator RunVisualization()
        {
            while (_interactor.InvokeNextCommand())
            {
                yield return new WaitForSeconds(_delayBetweenCommands);
            }
        }

        private void SetInvokedCommand(Command<List<int>> command)
        {
            //Temp debugs
            Debug.Log(command.Expression);
            Debug.Log(_interactor.InnerArray.Length);
        }

        private void OnDestroy()
        {
            _interactor.OnCommandInvoked -= SetInvokedCommand;
        }
    }
}