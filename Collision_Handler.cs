using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Collision_Handler : MonoBehaviour
{
    [SerializeField] float levelLoadDdelay = 1;
  void OnCollisionEnter(Collision other)
  {
      switch (other.gameObject.tag)
      {
          case "Friendly":
          Debug.Log("This thing is friendly");
          break;

          case "Finish":
          StartSuccessSequence();
          break; 

          default:
          // Calling my method here
          startCrashSequence();
          break;

      }
  } 


        // Making delay in reloading the next level
        // todo Add SFX upon crashing
        // todo Add particles effect upon crash
        void StartSuccessSequence()
      {
          GetComponent<Movement>().enabled = false;
          Invoke("LoadNextLevel", levelLoadDdelay);
      }

        // Making delay in reloading the same level
        // todo Add SFX upon crashing
        // todo Add particles effect upon crash
      void startCrashSequence()
      {
          GetComponent<Movement>().enabled = false;
          Invoke("ReloadLevel", levelLoadDdelay);
      }

        // method created here for loading the next level
      void LoadNextLevel()
      {
          int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
          int nextSceneindex = currentSceneIndex + 1;
          if (nextSceneindex == SceneManager.sceneCountInBuildSettings)
          {
             nextSceneindex = 0;
          }

          SceneManager.LoadScene(nextSceneindex);

      }
      // method created here for reload the same level
      void ReloadLevel()
      {
          int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
          SceneManager.LoadScene(currentSceneIndex);
      }

}
