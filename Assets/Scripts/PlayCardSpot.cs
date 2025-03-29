using UnityEngine;

public class PlayCardSpot : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Card"))
        {
            Debug.Log("entro cartit");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Card"))
        {
            Debug.Log("salio cartit");
        }
    }
}
