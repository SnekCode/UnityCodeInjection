using UnityEngine;
namespace Hack
{
    class Main : MonoBehaviour
    {
        SocketListener socket;
        public void Start()
        {
            socket = new SocketListener();
        }
        public void Update()
        {
            socket.SendData("test " + Time.time);
        }
        public void OnGUI()
        {
            // Here you can call IMGUI functions of Unity to build your UI for the hack :)
            GUI.Label(new Rect(20f, 20f, 500f, 50f), "GAME INJECTED" + Time.time);
            GUI.Label(new Rect(20f, 40f, 500f, 200f), socket.ConnectionStatus());
        }
    }
}
