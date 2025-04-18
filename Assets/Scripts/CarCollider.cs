using UnityEngine;

public class CarCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            GameManager.Instance.CheckPointPassed(); // Call the CheckPointPassed method in GameManager
        }

        if (other.CompareTag("WinCheckPoint"))
        {
            GameManager.Instance.GameWin(); // Call the GameOver method in GameManager
        }
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Obstacle"))
    //     {
    //         Debug.Log("Car exited the obstacle!"); // Log the exit from the obstacle
    //     }
    // }
}
