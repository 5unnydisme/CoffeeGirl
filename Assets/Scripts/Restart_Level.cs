
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Level : MonoBehaviour
{
    // Start is called before the first frame update
void OnTriggerEnter2D(Collider2D other)
{
if(other.CompareTag("Player"))
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
}


}
