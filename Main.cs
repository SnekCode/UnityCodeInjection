using UnityEngine;
namespace Hack
{
    class Main : MonoBehaviour
    {
        int count;
        public void Start()
        {

        }
        public void Update()
        {
            count++;
        }
        public void OnGUI()
        {
            // Here you can call IMGUI functions of Unity to build your UI for the hack :)
            GUI.Label(new Rect(20f, 20f, 150f, 50f), "GAME INJECTED" + count);
        }
    }
}
