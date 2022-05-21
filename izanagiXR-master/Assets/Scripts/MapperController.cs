using UnityEngine;

public class MapperController : MonoBehaviour
{
    [SerializeField] private GameObject assetBundleMenu;
    [SerializeField] private bool menuCheck = true;

    void Update()
    {
        if(GameObject.Find("AR Space") != null && menuCheck)
        {
            GameObject.Find("Mapping UI(Clone)").SetActive(false);
            assetBundleMenu.SetActive(true);
            menuCheck = false;
        }
    }
}
