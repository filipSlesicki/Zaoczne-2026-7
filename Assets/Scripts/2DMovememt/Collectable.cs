using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player2D player = other.GetComponent<Player2D>();
        if (player != null)
        {
            player.points+=value;
            Debug.Log("Add point");
            Destroy(gameObject);
        }
    }
}
