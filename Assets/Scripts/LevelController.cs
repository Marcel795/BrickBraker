using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] int totalBlocks = 0;
    SceneLoader sceneLoader;

    public void CountBreakableBlocks()
    {
        totalBlocks++;
    }

     public void DestroyBlock()
    {
        totalBlocks--;
        if (totalBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

  
}
