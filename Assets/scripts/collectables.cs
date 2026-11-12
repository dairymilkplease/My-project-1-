using UnityEngine;

public class collectables : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            Debug.Log("Give player coins");


            Destroy(gameObject);
        }
        
    
        
    }
}
