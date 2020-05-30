using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour
{
    public RawImage rawImage;

    public VideoPlayer videoPlayer;
    // Start is called before the first frame update


    void Awake() {
        videoPlayer.Prepare();
        StartCoroutine(playVideo());
    }

    private IEnumerator playVideo()
    {
        
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared){
            yield return waitForSeconds;
            break;
        }

        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
    }
}
