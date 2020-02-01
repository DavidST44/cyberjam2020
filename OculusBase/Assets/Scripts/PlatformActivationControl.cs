using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActivationControl : MonoBehaviour {
    public bool EnableInEditor = true;
    public bool EnableInDesktopAndWeb = true;
    public bool EnableInAndroid = true;

	// Use this for initialization
	void Start () {
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.OSXEditor:
                gameObject.SetActive(EnableInEditor);
                return;
            case RuntimePlatform.Android:
                gameObject.SetActive(EnableInAndroid);
                return;
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.OSXPlayer:
            case RuntimePlatform.WebGLPlayer:
                gameObject.SetActive(EnableInDesktopAndWeb);
                return;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
