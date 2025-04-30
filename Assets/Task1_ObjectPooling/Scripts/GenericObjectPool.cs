using System.Collections.Generic;
using UnityEngine;

namespace Task1_ObjectPooling.Scripts
{
    public class GenericObjectPool <T> where T: MonoBehaviour
    {
        private const int ExpandStepSize = 10;
            
        private readonly T _poolObject;
        private readonly int _initialSize;
        private readonly Transform _parentTransform;
        private readonly Stack<T> _objectStack;

        public T Get()
        {
            var obj = _objectStack.Pop();
            obj.gameObject.SetActive(true);
            return obj;
        }

        public void Release(T obj)
        {
            obj.gameObject.SetActive(false);
            _objectStack.Push(obj);
        }

        public void Prewarm()
        {
            for (var i = 0; i < _initialSize; i++)
            {
                var obj = Object.Instantiate(_poolObject, _parentTransform);
                obj.gameObject.SetActive(false);
                _objectStack.Push(obj);
            }
        }
    }
}
