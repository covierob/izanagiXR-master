﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class API : MonoBehaviour {

    const string BundleFolder = "https://www.coviello.tech/AssetBundles/";
    const string ItemList = "https://www.coviello.tech/ItemList.php";

    public void GetItemList(UnityAction<List<string>> callback) {
        StartCoroutine(GetItemListRoutine(callback));
    }

    IEnumerator GetItemListRoutine(UnityAction<List<string>> callback) {
        UnityWebRequest www = UnityWebRequest.Get(ItemList);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log("Network error: " + www.error);
        } else {
            string rawText = www.downloadHandler.text;
            //split string by comma
            string[] items = rawText.Split(',');
            //remove empty values and convert to list
            List<string> itemList = items.Where(x => !string.IsNullOrEmpty(x)).ToList();
            //return list to caller
            callback.Invoke(itemList);
        }
    }

    public void GetBundleObject(string assetName, UnityAction<GameObject> callback, Transform bundleParent) {
        StartCoroutine(GetDisplayBundleRoutine(assetName, callback, bundleParent));
    }

    IEnumerator GetDisplayBundleRoutine(string assetName, UnityAction<GameObject> callback, Transform bundleParent) {

        string bundleURL = BundleFolder + assetName + "-";

        //append platform to asset bundle name
#if UNITY_ANDROID
        bundleURL += "Android";
#else
        bundleURL += "IOS";
#endif

        Debug.Log("Requesting bundle at " + bundleURL);

        //request asset bundle
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(bundleURL);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log("Network error: " + www.error);
        } else {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
            if (bundle != null) {
                string rootAssetPath = bundle.GetAllAssetNames()[0];
                GameObject arObject = Instantiate(bundle.LoadAsset(rootAssetPath) as GameObject,bundleParent);
                bundle.Unload(false);
                callback(arObject);
            } else {
                Debug.Log("Not a valid asset bundle");
            }
        }
    }
}