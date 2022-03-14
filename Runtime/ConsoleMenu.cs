using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Console
{
    /// <summary>
    /// Console menu items.
    /// </summary>
    public static class ConsoleMenu
    {
        /// <summary>
        /// Disables all consoles.
        /// </summary>
        [MenuItem("Window/Consoles/Disable All")]
        public static void DisableAllConsoles() => SetActive(false);

        /// <summary>
        /// Enables all consoles.
        /// </summary>
        [MenuItem("Window/Consoles/Enable All")]
        public static void EnableAllConsoles() => SetActive(true);

        private static void SetActive(bool active) => 
            Resources.FindObjectsOfTypeAll<Console>()
                .ToList()
                .ForEach(c => c.Active = active);
    }
}