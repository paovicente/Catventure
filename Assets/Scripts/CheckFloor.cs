using UnityEngine;

public class CheckFloor : MonoBehaviour
{
    public static bool colFeet; //variable of the class not an instance

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Floor") { 
            colFeet = true;
            Debug.Log("collisioning with: " + collision.gameObject.tag);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Floor")
        {
            colFeet = false; 
            Debug.Log("out of: " + collision.gameObject.tag);
            Debug.Log("colFeet:" + colFeet);
        }

    }
}
