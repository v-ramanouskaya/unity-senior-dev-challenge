using System.Collections.Generic;
using UnityEngine;

namespace Task1_ObjectPooling.Scripts
{
    public class GenericObjectPool <T> where T: MonoBehaviour
    {
        private readonly T _poolObject;
        private readonly int _initialSize;
        private readonly Transform _parentTransform;
        private readonly Stack<T> _objectStack;
        
        public int Count => _objectStack.Count;
        
        public GenericObjectPool(T poolObject, Transform parentTransform, int size)
        {
            _poolObject = poolObject;
            _initialSize = size;
            _parentTransform = parentTransform;
            _objectStack = new Stack<T>(size);
            
            Prewarm();
        }

        public T Get()
        {
            if (_objectStack.Count == 0)
                ExpandPool();
        
            var obj = _objectStack.Pop();
            obj.gameObject.SetActive(true);
            return obj;
        }

        public void Release(T obj)
        {
            obj.gameObject.SetActive(false);
            _objectStack.Push(obj);
        }

        private void Prewarm()
        {
            for (var i = 0; i < _initialSize; i++)
                ExpandPool();
        }
    
        private void ExpandPool()
        {
            var obj = Object.Instantiate(_poolObject, _parentTransform);
            obj.gameObject.SetActive(false);
            _objectStack.Push(obj);
        }
    }
}
