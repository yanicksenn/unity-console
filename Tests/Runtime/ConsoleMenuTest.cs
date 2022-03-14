using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Console.Tests
{
    public class ConsoleMenuTest
    {
        [Test]
        public void AssertDisableAll()
        {
            var consoles = new List<Console>();
            for (var i = 0; i < Random.Range(1, 20); i++)
                consoles.Add(CreateRandomConsole());
            
            ConsoleMenu.DisableAllConsoles();
            
            consoles.ForEach(c => Assert.IsFalse(c.Active));

            DestroyAll(consoles);
        }

        [Test]
        public void AssertEnableAll()
        {
            var consoles = new List<Console>();
            for (var i = 0; i < Random.Range(1, 20); i++)
                consoles.Add(CreateRandomConsole());
            
            ConsoleMenu.EnableAllConsoles();
            
            consoles.ForEach(c => Assert.IsTrue(c.Active));

            DestroyAll(consoles);
        }

        private static void DestroyAll<T>(IList<T> objects) where T : Object
        {
            for (var i = objects.Count - 1; i >= 0; i--)
            {
                var obj = objects[i];
                objects.RemoveAt(i);
                Object.Destroy(obj);
            }
        }

        private static Console CreateRandomConsole()
        {
            var console = ScriptableObject.CreateInstance<Console>();
            console.Active = Random.Range(0, 1) == 0;
            return console;
        }
    }
}