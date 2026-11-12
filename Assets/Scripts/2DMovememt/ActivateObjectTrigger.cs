using UnityEngine;

public class ActivateObjectTrigger : MonoBehaviour
{
    public GameObject objectToActivate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            objectToActivate.SetActive(true);

        }

    }
}
