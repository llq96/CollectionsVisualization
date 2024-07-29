using System;
using UnityEngine;
using UnityEngine.Pool;

namespace CollectionsVisualization.Unity
{
    public class Pool_CommandUI : MonoBehaviour
    {
        private ObjectPool<CommandUI> _pool;

        [SerializeField] private Transform _spawnParent;
        [SerializeField] private CommandUI _prefab;

        public CommandUI Get() => _pool.Get();
        public void Release(CommandUI commandUI) => _pool.Release(commandUI);

        private void Awake()
        {
            _pool = new(CreateFunc, ActionOnGet, ActionOnRelease);
        }

        private CommandUI CreateFunc()
        {
            CommandUI obj = Instantiate(_prefab, _spawnParent);
            return obj;
        }

        private void ActionOnRelease(CommandUI obj)
        {
            obj.gameObject.SetActive(false);
        }

        private void ActionOnGet(CommandUI obj)
        {
            obj.gameObject.SetActive(true);
        }
    }
}