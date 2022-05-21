using UnityEngine;

public class MapperController : MonoBehaviour
{
    [SerializeField] private GameObject assetBundleMenu;

    void Update()
    {
        if(GameObject.Find("AR Space") != null)
        {
            GameObject.Find("Mapping UI(Clone)").SetActive(false);
            assetBundleMenu.SetActive(true);
        }
    }
}
