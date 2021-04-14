using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Share : MonoBehaviour
{

    public void Compartir()
    {
        StartCoroutine("ShareImg");
    }

    IEnumerator ShareImg()
    {
        yield return new WaitForEndOfFrame();

        Texture2D tx = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        tx.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        tx.Apply();

        string path = Path.Combine(Application.temporaryCachePath, "sharedImage.png");
        File.WriteAllBytes(path, tx.EncodeToPNG());

        Destroy(tx); //to avoid memory leaks

        new NativeShare()
            .AddFile(path)
            .SetSubject("uwu")
            .SetText("uwu")
            .Share();

    }
}
