using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Task1_ObjectPooling.Scripts
{
    public class TestPoolInitializer : MonoBehaviour
    {
        [SerializeField] private Transform _parentTransform;
        [SerializeField] private TestObject _prefab;
        [SerializeField] private int _objectCount = 1000;
        [SerializeField] private int _spawnRadius = 100;
    
        private GenericObjectPool<TestObject> _objectPool;
        private Stack<TestObject> _spawnedObjects;
        private bool _spawnInProgress;

        public void PreparePool()
        {
            if (_objectPool != null)
            {
                Debug.Log("Pool already prepared");
                return;
            }
            
            _objectPool = new GenericObjectPool<TestObject>(_prefab, _parentTransform, _objectCount);
            _spawnedObjects = new Stack<TestObject>(_objectCount);
        }

        public void Simulate()
        {
            if(_spawnInProgress)
                return;
            
            if(_objectPool == null)
                return;
            
            StartCoroutine(SpawnRoutine());
        }

        private IEnumerator SpawnRoutine()
        {
            _spawnInProgress = true;
            
            Spawn();
            yield return new WaitForSeconds(1);
            Release();
            
            _spawnInProgress = false;
        }

        private void Spawn()
        {
            for (var i = 0; i < _objectCount; i++)
            {
                var angle = (i / (float)_objectCount) * Mathf.PI * 2f;
                var x = Mathf.Cos(angle) * _spawnRadius;
                var z = Mathf.Sin(angle) * _spawnRadius;
                var position = Vector3.zero + new Vector3(x, 0f, z);

                var obj = _objectPool.Get();
                _spawnedObjects.Push(obj);
                
                obj.transform.position = position;
            }
            
        }

        private void Release()
        {
            for (var i = 0; i < _spawnedObjects.Count; i++)
                _objectPool.Release(_spawnedObjects.Pop());
        }
    }
}