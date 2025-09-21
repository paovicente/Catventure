using UnityEngine;

public class CheckFloor : MonoBehaviour
{
    public bool colFeet; //variable of the class not an instance

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Floor") { 
            colFeet = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Floor")
        {
            colFeet = false;
        }

    }
}
