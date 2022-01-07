using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject enterPanel;
    [SerializeField]
    private GameObject scannerPanel;
    [Header("Screen")]
    [SerializeField]
    private RawImage screen, screen1;
    [Space]


    private int cam_num = 0;
    private WebCamTexture active;


    [SerializeField]
    private GameObject hide_ui;
    byte[] load_img;
    
    

    private IEnumerator Start()
    {
        /*if (Application.platform == RuntimePlatform.Android) {

            Permission.RequestUserPermission(Permission.Camera);
            if (!Permission.HasUserAuthorizedPermission(Permission.Camera)) {
                yield break;
            }
            
        }*/
        // for android permission
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                //StartCoroutine(cam_texture_string(cam_num));
            }
            else
            {

                Permission.RequestUserPermission(Permission.Camera);
            }
        }

        // for window permission
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);

            if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
            {
                yield break;

            }
            //StartCoroutine(cam_texture_string(cam_num));
        }


        if (WebCamTexture.devices.Length == 0)
        {
            yield return null;
        }


    }




    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < 3)
        {

            enterPanel.SetActive(true);

        }
        else {

            enterPanel.SetActive(false);
        }
    }
   
    public void clickEnter() {



        scannerPanel.SetActive(true);


    }

}
