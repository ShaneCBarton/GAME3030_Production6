using UnityEngine;
using StarterAssets;

public class Weapon : MonoBehaviour
{

    StarterAssetsInputs starterAssetInputs;

    private void Awake()
    {
        starterAssetInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if (starterAssetInputs.shoot)
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.name);
            }            
            
            starterAssetInputs.ShootInput(false);
        }
    }
}
