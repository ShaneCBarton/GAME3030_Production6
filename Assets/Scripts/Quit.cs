using StarterAssets;
using UnityEngine;

public class Quit : MonoBehaviour
{

    private StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        HandleQuit();
    }

    private void HandleQuit()
    {
        if (starterAssetsInputs.quit)
        {
            Application.Quit();
        }
    }
}
