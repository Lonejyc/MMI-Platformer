using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private void Awake()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = transform.position;
        }
    }
}
