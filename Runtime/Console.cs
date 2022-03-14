using System;
using UnityEngine;

namespace Console
{
    [CreateAssetMenu(menuName = "Console/Create console", fileName = "Console")]
    public class Console : ScriptableObject
    {
        [SerializeField] 
        private bool active = true;
        public bool Active
        {
            get => active;
            set => active = value;
        }
        
        public void Log(string message)
        {
            LazyLog(Lazy(message));
        }
        
        public void LazyLog(Func<string> lazyMessage)
        {
            if (Active)
                Debug.Log(lazyMessage.Invoke());
        }
        
        public void Warning(string message)
        {
            LazyWarning(Lazy(message));
        }
        
        public void LazyWarning(Func<string> lazyMessage)
        {
            if (Active)
                Debug.LogWarning(lazyMessage.Invoke());
        }
        
        public void Error(string message)
        {
            LazyError(Lazy(message));
        }
        
        public void LazyError(Func<string> lazyMessage)
        {
            if (Active)
                Debug.LogError(lazyMessage.Invoke());
        }

        private static Func<T> Lazy<T>(T message)
        {
            return () => message;
        }
    }
}