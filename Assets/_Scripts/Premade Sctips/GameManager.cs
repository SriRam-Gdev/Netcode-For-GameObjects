using UnityEngine;
using Unity.Netcode;

public class GameManager : NetworkBehaviour
{
    [SerializeField] 
    private MultiplayerUI m_multiplayerUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(m_multiplayerUI != null)
        {
            m_multiplayerUI.OnStartHost += OnStartHost;
            m_multiplayerUI.OnStartClient += OnStartClient;
            m_multiplayerUI.OnStartServer += OnStartServer;
        }
    }

    // Update is called once per frame
    private void DisconnectClient()
    {
        m_multiplayerUI.EnableButtons();  
        NetworkManager.Shutdown();        
    }

    private void StartClient()
    {
        m_multiplayerUI.DisableButtons();
        NetworkManager.StartClient();
    }

    private void StartHost()
    {
        m_multiplayerUI.DisableButtons();
        NetworkManager.StartHost();
    }
}
