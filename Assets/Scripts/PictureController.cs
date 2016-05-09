using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class PictureController : MonoBehaviour {

    WebCamTexture _webcam;
    public Image _window;

	// Use this for initialization
	void Start () {
        _webcam = new WebCamTexture();
        _window.material.mainTexture = _webcam;
        _webcam.Play();        
	}

    public void TakePhoto()
    {
        StartCoroutine(CapturePicture());
    }

    IEnumerator CapturePicture()
    {
        yield return new WaitForEndOfFrame();

        Texture2D photo = new Texture2D(_webcam.width, _webcam.height);
        photo.SetPixels(_webcam.GetPixels());
        photo.Apply();

        //Encode to a PNG
        byte[] bytes = photo.EncodeToPNG();
        //Write out the PNG. Of course you have to substitute your_path for something sensible
        File.WriteAllBytes("photo.png", bytes);
    }
}
